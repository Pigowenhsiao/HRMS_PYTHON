from PyQt5.QtWidgets import (
    QDialog,
    QVBoxLayout,
    QHBoxLayout,
    QLabel,
    QCheckBox,
    QPushButton,
    QTableWidget,
    QTableWidgetItem,
    QLineEdit,
    QMessageBox,
)
from PyQt5.QtCore import Qt
from ui.window_utils import set_default_window_state


class AuthorityWindow(QDialog):
    def __init__(self, dao, translations):
        super().__init__()
        self.dao = dao
        self.t = translations
        self.setWindowTitle(self.t.get("authority_window_title", "權限管理"))
        self.resize(980, 520)
        set_default_window_state(self)
        self._init_ui()
        self.load_data()

    def _init_ui(self):
        layout = QVBoxLayout()

        filter_row = QHBoxLayout()
        self.active_only = QCheckBox(self.t.get("only_active", "Only Active"))
        self.active_only.setChecked(True)
        self.refresh_btn = QPushButton(self.t.get("refresh", "Refresh"))
        self.refresh_btn.clicked.connect(self.load_data)
        filter_row.addWidget(self.active_only)
        filter_row.addWidget(self.refresh_btn)
        filter_row.addStretch()
        layout.addLayout(filter_row)

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
        self.account_input.setPlaceholderText("帳號")
        self.pwd_input = QLineEdit()
        self.pwd_input.setPlaceholderText("密碼（留空不變更）")
        self.pwd_input.setEchoMode(QLineEdit.Password)
        row1.addWidget(QLabel(self.t.get("col_s_account", "帳號")))
        row1.addWidget(self.account_input)
        row1.addWidget(QLabel(self.t.get("password", "密碼")))
        row1.addWidget(self.pwd_input)
        form_col.addLayout(row1)

        # permissions checklist
        self.perm_boxes = {}
        perm_row = QHBoxLayout()
        for key, label_key in self.perm_keys:
            cb = QCheckBox(self.t.get(label_key, label_key))
            cb.setChecked(True)
            self.perm_boxes[key] = cb
            perm_row.addWidget(cb)
        form_col.addLayout(perm_row)

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
                self.table.setItem(r_idx, col, item)

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
            QMessageBox.warning(self, "Warn", "請輸入帳號")
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
            QMessageBox.critical(self, "Error", str(e))

    def update_account(self):
        acc = self.account_input.text().strip()
        if not acc:
            QMessageBox.warning(self, "Warn", "請先選擇或輸入帳號")
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
            QMessageBox.critical(self, "Error", str(e))
