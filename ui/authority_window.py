import sys
from pathlib import Path
from PyQt5.QtWidgets import (
    QApplication,
    QDialog,
    QVBoxLayout,
    QHBoxLayout,
    QGridLayout,
    QLabel,
    QCheckBox,
    QPushButton,
    QTableWidget,
    QTableWidgetItem,
    QLineEdit,
    QFileDialog,
    QMessageBox,
)
from PyQt5.QtCore import Qt, QProcess
from ui.window_utils import set_default_window_state, center_table_columns


class AuthorityWindow(QDialog):
    def __init__(self, dao, translations, db_path_getter=None, db_switcher=None):
        super().__init__()
        self.dao = dao
        self.t = translations
        self.db_path_getter = db_path_getter
        self.db_switcher = db_switcher
        self.setWindowTitle(self.t.get("authority_window_title", "權限管理"))
        self.resize(980, 520)
        set_default_window_state(self)
        self._init_ui()
        self.load_data()

    def _init_ui(self):
        layout = QVBoxLayout()
        layout.setContentsMargins(18, 18, 18, 18)
        layout.setSpacing(12)

        filter_row = QHBoxLayout()
        self.active_only = QCheckBox(self.t.get("only_active", "Only Active"))
        self.active_only.setChecked(True)
        self.refresh_btn = QPushButton(self.t.get("refresh", "Refresh"))
        self.refresh_btn.clicked.connect(self.load_data)
        filter_row.addWidget(self.active_only)
        filter_row.addWidget(self.refresh_btn)
        filter_row.addStretch()
        layout.addLayout(filter_row)

        db_row = QHBoxLayout()
        self.db_path_label = QLabel(self.t.get("db_path_label", "資料庫路徑"))
        self.db_path_input = QLineEdit()
        self.db_path_input.setPlaceholderText(
            self.t.get("db_path_placeholder", "輸入資料庫路徑，例如 \\\\server\\share\\hrms.db")
        )
        if self.db_path_getter:
            self.db_path_input.setText(self.db_path_getter())
        self.db_browse_btn = QPushButton(self.t.get("db_browse", "瀏覽"))       
        self.db_apply_btn = QPushButton(self.t.get("db_apply", "套用"))
        self.db_create_btn = QPushButton(self.t.get("db_create", "新增資料庫"))
        self.db_browse_btn.clicked.connect(self.on_browse_db)
        self.db_apply_btn.clicked.connect(self.on_apply_db)
        self.db_create_btn.clicked.connect(self.on_create_db)
        db_row.addWidget(self.db_path_label)
        db_row.addWidget(self.db_path_input, 1)
        db_row.addWidget(self.db_browse_btn)
        db_row.addWidget(self.db_apply_btn)
        db_row.addWidget(self.db_create_btn)
        layout.addLayout(db_row)

        self.perm_keys = [
            ("perm_basic", "employee_basic"),
            ("perm_personal", "employee_personal"),
            ("perm_education", "employee_education"),
            ("perm_certify_items", "certify_items"),
            ("perm_certify_tool", "certify_tool_map"),
            ("perm_training_record", "certify_record"),
            ("perm_overdue", "certify_overdue"),
            ("perm_authority", "authority"),
            ("perm_export", "sync_mes"),
            ("perm_area", "btn_area"),
            ("perm_section", "btn_section"),
            ("perm_job", "btn_job"),
            ("perm_report_training", "report_training"),
            ("perm_custom_export", "report_custom"),
        ]
        self.headers = ["s_account", "active", "update_date"] + [k for k, _ in self.perm_keys]
        header_labels = [
            self.t.get("col_s_account", "帳號"),
            self.t.get("col_active", "Active"),
            self.t.get("col_update_date", "更新日期"),
        ] + [self.t.get(label_key, label_key) for _, label_key in self.perm_keys]
        self.table = QTableWidget()
        self.table.setColumnCount(len(self.headers))
        self.table.setHorizontalHeaderLabels(header_labels)
        header = self.table.horizontalHeader()
        header.setSectionResizeMode(self.table.horizontalHeader().ResizeToContents)
        header.setStretchLastSection(True)
        self.table.verticalHeader().setDefaultSectionSize(24)
        self.table.itemSelectionChanged.connect(self.on_row_selected)
        layout.addWidget(self.table)

        form_col = QVBoxLayout()
        row1 = QHBoxLayout()
        self.account_input = QLineEdit()
        self.account_input.setPlaceholderText(self.t.get("placeholder_account", "帳號"))
        self.pwd_input = QLineEdit()
        self.pwd_input.setPlaceholderText(self.t.get("placeholder_password_keep", "密碼（留空不變更）"))
        self.pwd_input.setEchoMode(QLineEdit.Password)
        row1.addWidget(QLabel(self.t.get("col_s_account", "帳號")))
        row1.addWidget(self.account_input)
        row1.addWidget(QLabel(self.t.get("password", "密碼")))
        row1.addWidget(self.pwd_input)
        form_col.addLayout(row1)

        # permissions checklist
        self.perm_boxes = {}
        perm_grid = QGridLayout()
        perm_grid.setHorizontalSpacing(12)
        perm_grid.setVerticalSpacing(8)
        columns = 4
        for idx, (key, label_key) in enumerate(self.perm_keys):
            cb = QCheckBox(self.t.get(label_key, label_key))
            cb.setChecked(True)
            self.perm_boxes[key] = cb
            perm_grid.addWidget(cb, idx // columns, idx % columns)
        form_col.addLayout(perm_grid)

        form_row2 = QHBoxLayout()
        self.active = QCheckBox(self.t.get("active", "Active"))
        self.active.setChecked(True)
        self.create_btn = QPushButton(self.t.get("create", "Create"))
        self.update_btn = QPushButton(self.t.get("update", "Update"))
        self.create_btn.clicked.connect(self.create_account)
        self.update_btn.clicked.connect(self.update_account)
        form_row2.addWidget(self.active)
        form_row2.addWidget(self.create_btn)
        form_row2.addWidget(self.update_btn)
        form_row2.addStretch()
        form_col.addLayout(form_row2)
        layout.addLayout(form_col)

        self.setLayout(layout)

    def on_browse_db(self):
        start_dir = self.db_path_input.text().strip()
        if not start_dir and self.db_path_getter:
            start_dir = self.db_path_getter()
        file_path, _ = QFileDialog.getOpenFileName(
            self,
            self.t.get("db_browse", "瀏覽"),
            start_dir,
            "SQLite (*.db);;All Files (*)",
        )
        if file_path:
            self.db_path_input.setText(file_path)

    def on_apply_db(self):
        if not self.db_switcher:
            return
        raw_path = self.db_path_input.text().strip()
        if not raw_path:
            QMessageBox.warning(
                self,
                self.t.get("warn", "Warn"),
                self.t.get("msg_db_path_required", "請輸入資料庫路徑"),
            )
            return
        result = self.db_switcher(raw_path, create_if_missing=False)
        if result.get("status") == "missing":
            msg_tpl = self.t.get("msg_db_path_missing", "資料庫不存在：{path}")
            QMessageBox.warning(
                self,
                self.t.get("error", "Error"),
                msg_tpl.format(path=result.get("path", raw_path)),
            )
            return
        if result.get("status") == "ok":
            self.db_path_input.setText(result.get("path", raw_path))
            self._prompt_restart(result.get("path", raw_path), created=False)
            return
        err = result.get("error", "")
        msg_tpl = self.t.get("msg_db_switch_failed", "資料庫切換失敗：{error}")
        QMessageBox.critical(
            self, self.t.get("error", "Error"), msg_tpl.format(error=err)
        )

    def on_create_db(self):
        if not self.db_switcher:
            return
        start_dir = self.db_path_input.text().strip()
        if not start_dir and self.db_path_getter:
            start_dir = self.db_path_getter()
        if start_dir:
            start_dir = str(Path(start_dir).expanduser())
            if Path(start_dir).is_file():
                start_dir = str(Path(start_dir).parent)
        dir_path = QFileDialog.getExistingDirectory(
            self,
            self.t.get("db_create", "新增資料庫"),
            start_dir,
        )
        if not dir_path:
            return
        target_path = Path(dir_path) / "HRMS_Database.db"
        if target_path.exists():
            msg_tpl = self.t.get(
                "msg_db_create_exists",
                "資料庫檔案已存在，無法覆寫：{path}",
            )
            QMessageBox.warning(
                self,
                self.t.get("error", "Error"),
                msg_tpl.format(path=str(target_path)),
            )
            return
        result = self.db_switcher(str(target_path), create_if_missing=True)
        if result.get("status") == "ok":
            self.db_path_input.setText(result.get("path", str(target_path)))
            self._prompt_restart(result.get("path", str(target_path)), created=True)
            return
        err = result.get("error", "")
        msg_tpl = self.t.get("msg_db_create_failed", "建立資料庫失敗：{error}")
        QMessageBox.critical(
            self, self.t.get("error", "Error"), msg_tpl.format(error=err)
        )

    def _prompt_restart(self, path: str, created: bool):
        if created:
            msg_tpl = self.t.get("msg_db_create_success", "已建立資料庫：{path}")
        else:
            msg_tpl = self.t.get("msg_db_switch_success", "已更新資料庫設定：{path}")
        prompt = QMessageBox(self)
        prompt.setIcon(QMessageBox.Information)
        prompt.setWindowTitle(self.t.get("info", "Info"))
        prompt.setText(msg_tpl.format(path=path))
        prompt.setInformativeText(
            self.t.get("msg_db_restart_prompt", "是否立即重新啟動？")
        )
        prompt.setStandardButtons(QMessageBox.Yes | QMessageBox.No)
        prompt.setDefaultButton(QMessageBox.Yes)
        if prompt.exec_() == QMessageBox.Yes:
            self._restart_app()

    def _restart_app(self):
        app = QApplication.instance()
        if not app:
            return
        if getattr(sys, "frozen", False):
            QProcess.startDetached(sys.executable, sys.argv[1:])
        else:
            QProcess.startDetached(sys.executable, sys.argv)
        app.quit()

    def load_data(self):
        rows = self.dao.list_accounts(active_only=self.active_only.isChecked())
        self.table.setRowCount(len(rows))
        for r_idx, row in enumerate(rows):
            # s_account / active / update_date
            for c_idx, key in enumerate(self.headers[:3]):
                item = QTableWidgetItem(str(row.get(key, "")))
                item.setFlags(item.flags() ^ Qt.ItemIsEditable)
                self.table.setItem(r_idx, c_idx, item)
            # permissions as checkboxes
            for offset, (perm_key, _) in enumerate(self.perm_keys):
                col = 3 + offset
                item = QTableWidgetItem("")
                item.setFlags(Qt.ItemIsEnabled | Qt.ItemIsUserCheckable)
                item.setCheckState(Qt.Checked if str(row.get(perm_key, "0")) in ("1", "True", "true") else Qt.Unchecked)
                item.setTextAlignment(Qt.AlignCenter)
                self.table.setItem(r_idx, col, item)
        perm_cols = list(range(3, 3 + len(self.perm_keys)))
        center_table_columns(self.table, [1] + perm_cols)

    def on_row_selected(self):
        items = self.table.selectedItems()
        if not items:
            return
        r = items[0].row()
        account = self.table.item(r, 0).text()
        active_val = self.table.item(r, 1).text()
        self.account_input.setText(account)
        self.active.setChecked(active_val in ("1", "True", "true"))
        # reset password input
        self.pwd_input.setText("")
        # load perms
        row_data = {h: self.table.item(r, idx).text() if self.table.item(r, idx) else "" for idx, h in enumerate(self.headers)}
        # fetch full row for perms
        full = self.dao.db.fetch_one("SELECT * FROM authority WHERE s_account = ?", (account,))
        if full:
            for key, cb in self.perm_boxes.items():
                cb.setChecked(bool(full.get(key, 0)))

    def create_account(self):
        acc = self.account_input.text().strip()
        if not acc:
            QMessageBox.warning(
                self, self.t.get("warn", "Warn"), self.t.get("msg_account_required", "請輸入帳號")
            )
            return
        try:
            perms = {k: cb.isChecked() for k, cb in self.perm_boxes.items()}
            pwd_hash = ""
            if self.pwd_input.text():
                import hashlib
                pwd_hash = hashlib.md5(self.pwd_input.text().encode()).hexdigest()
            self.dao.create_account(acc, pwd_hash, self.active.isChecked(), perms)
            self.load_data()
        except Exception as e:
            QMessageBox.critical(self, self.t.get("error", "Error"), str(e))

    def update_account(self):
        acc = self.account_input.text().strip()
        if not acc:
            QMessageBox.warning(
                self, self.t.get("warn", "Warn"), self.t.get("msg_account_select", "請先選擇或輸入帳號")
            )
            return
        try:
            perms = {k: cb.isChecked() for k, cb in self.perm_boxes.items()}
            pwd_hash = ""
            if self.pwd_input.text():
                import hashlib
                pwd_hash = hashlib.md5(self.pwd_input.text().encode()).hexdigest()
            self.dao.update_account(acc, pwd_hash, self.active.isChecked(), perms)
            self.load_data()
        except Exception as e:
            QMessageBox.critical(self, self.t.get("error", "Error"), str(e))
