from PyQt5.QtWidgets import (
    QDialog,
    QVBoxLayout,
    QHBoxLayout,
    QLabel,
    QComboBox,
    QLineEdit,
    QCheckBox,
    QPushButton,
    QTableWidget,
    QTableWidgetItem,
    QMessageBox,
    QGridLayout,
)
from PyQt5.QtCore import Qt
from ui.window_utils import set_default_window_state, center_table_columns


class CertifyItemsWindow(QDialog):
    def __init__(self, dao, translations, basic_dao):
        super().__init__()
        self.dao = dao
        self.t = translations
        self.basic_dao = basic_dao
        self.setWindowTitle(self.t.get("certify_items_window_title", "證照設定"))
        self.resize(900, 560)
        set_default_window_state(self)
        self._init_ui()
        self._load_depts()
        self.load_data()

    def _init_ui(self):
        layout = QVBoxLayout()
        layout.setContentsMargins(18, 18, 18, 18)
        layout.setSpacing(12)

        # 篩選
        filter_row = QHBoxLayout()
        filter_row.setSpacing(8)
        self.active_only = QCheckBox(self.t.get("only_active", "Only Active"))
        self.active_only.setChecked(True)
        self.refresh_btn = QPushButton(self.t.get("refresh", "Refresh"))
        self.refresh_btn.clicked.connect(self.load_data)
        filter_row.addWidget(self.active_only)
        filter_row.addWidget(self.refresh_btn)
        filter_row.addStretch()
        layout.addLayout(filter_row)

        # 表格
        self.headers = ["certify_id", "dept", "certify_name", "certify_time", "certify_grade", "certify_type", "remark", "active"]
        header_labels = [
            self.t.get("col_certify_id", "certify_id"),
            self.t.get("col_dept", "dept"),
            self.t.get("col_certify_name", "certify_name"),
            self.t.get("col_certify_time", "certify_time"),
            self.t.get("col_certify_grade", "certify_grade"),
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
        form = QGridLayout()
        form.setHorizontalSpacing(12)
        form.setVerticalSpacing(10)
        self.certify_id = QLineEdit()
        self.dept = QComboBox()
        self.certify_name = QLineEdit()
        self.certify_time = QLineEdit()
        self.certify_grade = QLineEdit()
        self.certify_type = QLineEdit()
        self.remark = QLineEdit()
        self.active = QCheckBox(self.t.get("active", "Active"))
        self.active.setChecked(True)

        labels = [
            self.t.get("col_certify_id", "Certify ID"),
            self.t.get("col_dept", "Dept"),
            self.t.get("col_certify_name", "Name"),
            self.t.get("col_certify_time", "Time"),
            self.t.get("col_certify_grade", "Grade"),
            self.t.get("col_certify_type", "Type"),
            self.t.get("col_remark", "Remark"),
            self.t.get("col_active", "Active"),
        ]
        widgets = [
            self.certify_id,
            self.dept,
            self.certify_name,
            self.certify_time,
            self.certify_grade,
            self.certify_type,
            self.remark,
            self.active,
        ]
        for i, (lab, wid) in enumerate(zip(labels, widgets)):
            form.addWidget(QLabel(lab), i // 2, (i % 2) * 2)
            form.addWidget(wid, i // 2, (i % 2) * 2 + 1)
        layout.addLayout(form)

        # 按鈕
        btn_row = QHBoxLayout()
        btn_row.setSpacing(10)
        self.create_btn = QPushButton(self.t.get("create", "Create"))
        self.update_btn = QPushButton(self.t.get("update", "Update"))
        self.create_btn.clicked.connect(self.create_item)
        self.update_btn.clicked.connect(self.update_item)
        btn_row.addWidget(self.create_btn)
        btn_row.addWidget(self.update_btn)
        btn_row.addStretch()
        layout.addLayout(btn_row)

        self.setLayout(layout)

    def _load_depts(self):
        self.dept.blockSignals(True)
        self.dept.clear()
        self.dept.addItem(self.t.get("filter_all", "ALL"), "")
        for row in self.basic_dao.list_sections():
            label = f"{row['dept_code']} {row.get('dept_desc','')}".strip()
            self.dept.addItem(label, row["dept_code"])
        self.dept.blockSignals(False)

    def load_data(self):
        rows = self.dao.list_certify_items(active_only=self.active_only.isChecked())
        self.table.setRowCount(len(rows))
        for r_idx, row in enumerate(rows):
            for c_idx, key in enumerate(self.headers):
                item = QTableWidgetItem(str(row.get(key, "")))
                item.setFlags(item.flags() ^ Qt.ItemIsEditable)
                self.table.setItem(r_idx, c_idx, item)
        center_table_columns(self.table, [len(self.headers) - 1])

    def on_row_selected(self):
        items = self.table.selectedItems()
        if not items:
            return
        r = items[0].row()
        values = {self.headers[c]: self.table.item(r, c).text() for c in range(len(self.headers))}
        self.certify_id.setText(values.get("certify_id", ""))
        self._set_combo_if_exists(self.dept, values.get("dept", ""))
        self.certify_name.setText(values.get("certify_name", ""))
        self.certify_time.setText(values.get("certify_time", ""))
        self.certify_grade.setText(values.get("certify_grade", ""))
        self.certify_type.setText(values.get("certify_type", ""))
        self.remark.setText(values.get("remark", ""))
        self.active.setChecked(values.get("active", "1") in ("1", "True", "true"))

    def _set_combo_if_exists(self, combo: QComboBox, value: str):
        idx = combo.findData(value)
        if idx >= 0:
            combo.setCurrentIndex(idx)

    def create_item(self):
        data = self._collect_form()
        if not data["certify_id"]:
            QMessageBox.warning(self, self.t.get("warn", "Warn"), self.t.get("msg_required_certify_id", "Certify ID required"))
            return
        try:
            self.dao.create_certify_item(**data)
            self.load_data()
        except Exception as e:
            QMessageBox.critical(self, self.t.get("error", "Error"), str(e))

    def update_item(self):
        data = self._collect_form()
        if not data["certify_id"]:
            QMessageBox.warning(self, self.t.get("warn", "Warn"), self.t.get("msg_required_certify_id", "Certify ID required"))
            return
        try:
            self.dao.update_certify_item(**data)
            self.load_data()
        except Exception as e:
            QMessageBox.critical(self, self.t.get("error", "Error"), str(e))

    def _collect_form(self):
        return dict(
            certify_id=self.certify_id.text().strip(),
            dept=self.dept.currentData() or "",
            certify_name=self.certify_name.text().strip(),
            certify_time=self.certify_time.text().strip(),
            certify_grade=self.certify_grade.text().strip(),
            certify_type=self.certify_type.text().strip(),
            remark=self.remark.text().strip(),
            active=self.active.isChecked(),
        )
