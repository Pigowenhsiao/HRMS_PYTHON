from PyQt5.QtWidgets import (
    QDialog,
    QVBoxLayout,
    QHBoxLayout,
    QLabel,
    QComboBox,
    QCheckBox,
    QPushButton,
    QTableWidget,
    QTableWidgetItem,
    QLineEdit,
    QMessageBox,
)
from PyQt5.QtCore import Qt


class TrainingRecordWindow(QDialog):
    def __init__(self, dao, translations, export_dir, basic_dao, certify_dao):
        super().__init__()
        self.dao = dao
        self.t = translations
        self.export_dir = export_dir
        self.basic_dao = basic_dao
        self.certify_dao = certify_dao
        self.setWindowTitle(self.t.get("certify_record", "訓練/證照紀錄"))
        self.resize(1100, 620)
        self._init_ui()
        self.load_filters()
        self.load_data()

    def _init_ui(self):
        layout = QVBoxLayout()

        # 篩選列
        filter_row = QHBoxLayout()
        self.active_only = QCheckBox(self.t.get("only_active", "Only Active"))
        self.active_only.setChecked(True)
        self.refresh_btn = QPushButton(self.t.get("refresh", "Refresh"))
        self.refresh_btn.clicked.connect(self.load_data)
        self.export_btn = QPushButton(self.t.get("export_csv", "Export CSV"))
        self.export_btn.clicked.connect(self.export_csv)
        filter_row.addWidget(self.active_only)
        filter_row.addWidget(self.refresh_btn)
        filter_row.addWidget(self.export_btn)
        filter_row.addStretch()
        layout.addLayout(filter_row)

        # 表格
        self.headers = [
            "certify_no",
            "emp_id",
            "c_name",
            "dept_code",
            "area",
            "certify_id",
            "certify_name",
            "certify_date",
            "certify_type",
            "remark",
            "active",
        ]
        header_labels = [
            self.t.get("col_certify_no", "certify_no"),
            self.t.get("col_emp_id", "emp_id"),
            self.t.get("col_c_name", "c_name"),
            self.t.get("col_dept_code", "dept_code"),
            self.t.get("col_area", "area"),
            self.t.get("col_certify_id", "certify_id"),
            self.t.get("col_certify_name", "certify_name"),
            self.t.get("col_certify_date", "certify_date"),
            self.t.get("col_certify_type", "certify_type"),
            self.t.get("col_remark", "remark"),
            self.t.get("col_active", "active"),
        ]
        self.table = QTableWidget()
        self.table.setColumnCount(len(self.headers))
        self.table.setHorizontalHeaderLabels(header_labels)
        header = self.table.horizontalHeader()
        header.setSectionResizeMode(self.table.horizontalHeader().ResizeToContents)
        header.setStretchLastSection(True)
        self.table.verticalHeader().setDefaultSectionSize(26)
        self.table.itemSelectionChanged.connect(self.on_row_selected)
        layout.addWidget(self.table)

        # 表單
        form_row1 = QHBoxLayout()
        self.emp_cb = QComboBox()
        self.certify_cb = QComboBox()
        self.certify_date = QLineEdit()
        self.certify_date.setPlaceholderText("YYYY-MM-DD")
        self.certify_type = QLineEdit()
        self.remark = QLineEdit()
        self.active = QCheckBox(self.t.get("active", "Active"))
        self.active.setChecked(True)

        form_row1.addWidget(QLabel(self.t.get("col_emp_id", "EMP_ID")))
        form_row1.addWidget(self.emp_cb)
        form_row1.addWidget(QLabel(self.t.get("col_certify_id", "Certify ID")))
        form_row1.addWidget(self.certify_cb)
        layout.addLayout(form_row1)

        form_row2 = QHBoxLayout()
        form_row2.addWidget(QLabel(self.t.get("col_certify_date", "Date")))
        form_row2.addWidget(self.certify_date)
        form_row2.addWidget(QLabel(self.t.get("col_certify_type", "Type")))
        form_row2.addWidget(self.certify_type)
        form_row2.addWidget(QLabel(self.t.get("col_remark", "Remark")))
        form_row2.addWidget(self.remark)
        form_row2.addWidget(self.active)
        layout.addLayout(form_row2)

        # 按鈕列
        btn_row = QHBoxLayout()
        self.create_btn = QPushButton(self.t.get("create", "Create"))
        self.update_btn = QPushButton(self.t.get("update", "Update"))
        self.delete_btn = QPushButton(self.t.get("delete", "Delete"))
        self.create_btn.clicked.connect(self.create_record)
        self.update_btn.clicked.connect(self.update_record)
        self.delete_btn.clicked.connect(self.delete_record)
        btn_row.addWidget(self.create_btn)
        btn_row.addWidget(self.update_btn)
        btn_row.addWidget(self.delete_btn)
        btn_row.addStretch()
        layout.addLayout(btn_row)

        # 狀態提示
        self.status_label = QLabel("")
        self.status_label.setAlignment(Qt.AlignRight)
        layout.addWidget(self.status_label)

        self.setLayout(layout)

    def load_filters(self):
        self.emp_cb.blockSignals(True)
        self.certify_cb.blockSignals(True)
        self.emp_cb.clear()
        self.certify_cb.clear()
        for row in self.basic_dao.list_basic(active_only=True):
            self.emp_cb.addItem(f"{row['emp_id']} {row.get('c_name', '')}", row["emp_id"])
        for row in self.certify_dao.list_certify_items(active_only=True):
            self.certify_cb.addItem(f"{row['certify_id']} {row.get('certify_name', '')}", row["certify_id"])
        self.emp_cb.blockSignals(False)
        self.certify_cb.blockSignals(False)

    def load_data(self):
        rows = self.dao.list_training_records(only_active=self.active_only.isChecked())
        self.table.setRowCount(len(rows))
        for r_idx, row in enumerate(rows):
            for c_idx, key in enumerate(self.headers):
                item = QTableWidgetItem(str(row.get(key, "")))
                item.setFlags(item.flags() ^ Qt.ItemIsEditable)
                self.table.setItem(r_idx, c_idx, item)
        # 隱藏流水號欄位
        self.table.setColumnHidden(0, True)
        self.selected_certify_no = None

    def on_row_selected(self):
        items = self.table.selectedItems()
        if not items:
            return
        r = items[0].row()
        values = {self.headers[c]: self.table.item(r, c).text() for c in range(len(self.headers))}
        self.selected_certify_no = values.get("certify_no", "")
        self._set_combo_if_exists(self.emp_cb, values.get("emp_id", ""))
        self._set_combo_if_exists(self.certify_cb, values.get("certify_id", ""))
        self.certify_date.setText(values.get("certify_date", ""))
        self.certify_type.setText(values.get("certify_type", ""))
        self.remark.setText(values.get("remark", ""))
        self.active.setChecked(values.get("active", "1") in ("1", "True", "true"))

    def _set_combo_if_exists(self, combo: QComboBox, value: str):
        idx = combo.findData(value)
        if idx >= 0:
            combo.setCurrentIndex(idx)

    def _collect_form(self):
        return dict(
            emp_id=self.emp_cb.currentData(),
            certify_id=self.certify_cb.currentData(),
            certify_date=self.certify_date.text().strip(),
            certify_type=self.certify_type.text().strip(),
            remark=self.remark.text().strip(),
            active=self.active.isChecked(),
        )

    def create_record(self):
        data = self._collect_form()
        if not data["emp_id"] or not data["certify_id"]:
            QMessageBox.warning(
                self,
                self.t.get("warn", "Warn"),
                self.t.get("msg_required_emp_cert", "EMP_ID / Certify ID required"),
            )
            return
        try:
            existing = self.dao.find_training_record(
                emp_id=data["emp_id"],
                certify_id=data["certify_id"],
                certify_date=data["certify_date"],
                certify_type=data["certify_type"],
                remark=data["remark"],
                active=data["active"],
            )
            if existing and existing.get("certify_no"):
                self.dao.update_training_record(
                    certify_no=int(existing["certify_no"]),
                    emp_id=data["emp_id"],
                    certify_id=data["certify_id"],
                    certify_date=data["certify_date"],
                    certify_type=data["certify_type"],
                    remark=data["remark"],
                    active=data["active"],
                    updater="",
                )
                self._show_status(self.t.get("msg_duplicate_record", "資料重複，已改為更新"))
            else:
                self.dao.create_training_record(
                    emp_id=data["emp_id"],
                    certify_id=data["certify_id"],
                    certify_date=data["certify_date"],
                    certify_type=data["certify_type"],
                    remark=data["remark"],
                    active=data["active"],
                    updater="",
                )
                self._show_status(self.t.get("msg_create_success", "新增成功"))
            self.load_data()
        except Exception as e:
            QMessageBox.critical(self, "Error", str(e))

    def update_record(self):
        data = self._collect_form()
        if not self.selected_certify_no:
            QMessageBox.warning(self, self.t.get("warn", "Warn"), self.t.get("msg_select_row", "Please select a row"))
            return
        try:
            self.dao.update_training_record(
                certify_no=int(self.selected_certify_no),
                emp_id=data["emp_id"],
                certify_id=data["certify_id"],
                certify_date=data["certify_date"],
                certify_type=data["certify_type"],
                remark=data["remark"],
                active=data["active"],
                updater="",
            )
            self.load_data()
        except Exception as e:
            QMessageBox.critical(self, "Error", str(e))

    def delete_record(self):
        if not self.selected_certify_no:
            QMessageBox.warning(self, self.t.get("warn", "Warn"), self.t.get("msg_select_row", "Please select a row"))
            return
        try:
            self.dao.delete_training_record(int(self.selected_certify_no))
            self.load_data()
        except Exception as e:
            QMessageBox.critical(self, "Error", str(e))

    def export_csv(self):
        path = self.dao.export_training_records(
            self.export_dir, "training_export.csv", only_active=self.active_only.isChecked()
        )
        QMessageBox.information(self, self.t.get("export_csv", "Export CSV"), f"CSV exported to: {path}")

    def _show_status(self, msg: str):
        self.status_label.setText(msg)
