from PyQt5.QtWidgets import (
    QDialog,
    QVBoxLayout,
    QHBoxLayout,
    QLabel,
    QLineEdit,
    QCheckBox,
    QPushButton,
    QTableWidget,
    QTableWidgetItem,
    QMessageBox,
    QGridLayout,
)
from PyQt5.QtCore import Qt


class CertifyItemsWindow(QDialog):
    def __init__(self, dao, translations):
        super().__init__()
        self.dao = dao
        self.t = translations
        self.setWindowTitle(self.t.get("certify_items_window_title", "證照設定"))
        self.resize(900, 560)
        self._init_ui()
        self.load_data()

    def _init_ui(self):
        layout = QVBoxLayout()

        # 篩選
        filter_row = QHBoxLayout()
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
        self.table = QTableWidget()
        self.table.setColumnCount(len(self.headers))
        self.table.setHorizontalHeaderLabels(self.headers)
        header = self.table.horizontalHeader()
        header.setSectionResizeMode(self.table.horizontalHeader().ResizeToContents)
        header.setStretchLastSection(True)
        self.table.verticalHeader().setDefaultSectionSize(26)
        self.table.itemSelectionChanged.connect(self.on_row_selected)
        layout.addWidget(self.table)

        # 表單
        form = QGridLayout()
        self.certify_id = QLineEdit()
        self.dept = QLineEdit()
        self.certify_name = QLineEdit()
        self.certify_time = QLineEdit()
        self.certify_grade = QLineEdit()
        self.certify_type = QLineEdit()
        self.remark = QLineEdit()
        self.active = QCheckBox(self.t.get("active", "Active"))
        self.active.setChecked(True)

        labels = ["Certify ID", "Dept", "Name", "Time", "Grade", "Type", "Remark", "Active"]
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
        self.create_btn = QPushButton(self.t.get("create", "Create"))
        self.update_btn = QPushButton(self.t.get("update", "Update"))
        self.create_btn.clicked.connect(self.create_item)
        self.update_btn.clicked.connect(self.update_item)
        btn_row.addWidget(self.create_btn)
        btn_row.addWidget(self.update_btn)
        btn_row.addStretch()
        layout.addLayout(btn_row)

        self.setLayout(layout)

    def load_data(self):
        rows = self.dao.list_certify_items(active_only=self.active_only.isChecked())
        self.table.setRowCount(len(rows))
        for r_idx, row in enumerate(rows):
            for c_idx, key in enumerate(self.headers):
                item = QTableWidgetItem(str(row.get(key, "")))
                item.setFlags(item.flags() ^ Qt.ItemIsEditable)
                self.table.setItem(r_idx, c_idx, item)

    def on_row_selected(self):
        items = self.table.selectedItems()
        if not items:
            return
        r = items[0].row()
        values = {self.headers[c]: self.table.item(r, c).text() for c in range(len(self.headers))}
        self.certify_id.setText(values.get("certify_id", ""))
        self.dept.setText(values.get("dept", ""))
        self.certify_name.setText(values.get("certify_name", ""))
        self.certify_time.setText(values.get("certify_time", ""))
        self.certify_grade.setText(values.get("certify_grade", ""))
        self.certify_type.setText(values.get("certify_type", ""))
        self.remark.setText(values.get("remark", ""))
        self.active.setChecked(values.get("active", "1") in ("1", "True", "true"))

    def create_item(self):
        data = self._collect_form()
        if not data["certify_id"]:
            QMessageBox.warning(self, "Warn", "Certify ID 必填")
            return
        try:
            self.dao.create_certify_item(**data)
            self.load_data()
        except Exception as e:
            QMessageBox.critical(self, "Error", str(e))

    def update_item(self):
        data = self._collect_form()
        if not data["certify_id"]:
            QMessageBox.warning(self, "Warn", "請先選擇或輸入 Certify ID")
            return
        try:
            self.dao.update_certify_item(**data)
            self.load_data()
        except Exception as e:
            QMessageBox.critical(self, "Error", str(e))

    def _collect_form(self):
        return dict(
            certify_id=self.certify_id.text().strip(),
            dept=self.dept.text().strip(),
            certify_name=self.certify_name.text().strip(),
            certify_time=self.certify_time.text().strip(),
            certify_grade=self.certify_grade.text().strip(),
            certify_type=self.certify_type.text().strip(),
            remark=self.remark.text().strip(),
            active=self.active.isChecked(),
        )
