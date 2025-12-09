from PyQt5.QtWidgets import (
    QDialog,
    QVBoxLayout,
    QHBoxLayout,
    QLabel,
    QComboBox,
    QLineEdit,
    QPushButton,
    QTableWidget,
    QTableWidgetItem,
    QMessageBox,
)
from PyQt5.QtCore import Qt


class TrainingReportWindow(QDialog):
    def __init__(self, report_dao, basic_dao, translations, export_dir):
        super().__init__()
        self.dao = report_dao
        self.basic_dao = basic_dao
        self.t = translations
        self.export_dir = export_dir
        self.setWindowTitle(self.t.get("training_report_window_title", "訓練報表"))
        self.resize(900, 560)
        self._init_ui()
        self.load_depts()
        self.load_data()

    def _init_ui(self):
        layout = QVBoxLayout()

        filter_row = QHBoxLayout()
        filter_row.addWidget(QLabel("Dept"))
        self.dept_cb = QComboBox()
        filter_row.addWidget(self.dept_cb)
        filter_row.addWidget(QLabel(self.t.get("overdue_days_label", "逾期天數大於等於")))
        self.days_input = QLineEdit()
        self.days_input.setPlaceholderText("天數，例如 660")
        self.days_input.setText("0")
        self.refresh_btn = QPushButton(self.t.get("refresh", "Refresh"))
        self.refresh_btn.clicked.connect(self.load_data)
        self.export_btn = QPushButton(self.t.get("export_csv", "Export CSV"))
        self.export_btn.clicked.connect(self.export_csv)
        for w in [self.days_input, self.refresh_btn, self.export_btn]:
            filter_row.addWidget(w)
        filter_row.addStretch()
        layout.addLayout(filter_row)

        self.headers = ["emp_id", "c_name", "dept_desc", "certify_id", "certify_name", "certify_date", "overdue_days", "active"]
        self.table = QTableWidget()
        self.table.setColumnCount(len(self.headers))
        self.table.setHorizontalHeaderLabels(self.headers)
        self.table.horizontalHeader().setStretchLastSection(True)
        layout.addWidget(self.table)

        self.setLayout(layout)

    def load_depts(self):
        self.dept_cb.blockSignals(True)
        self.dept_cb.clear()
        self.dept_cb.addItem("ALL", "")
        for row in self.basic_dao.list_sections():
            self.dept_cb.addItem(f"{row['dept_code']} {row.get('dept_desc','')}", row['dept_code'])
        self.dept_cb.blockSignals(False)

    def load_data(self):
        try:
            days = int(self.days_input.text().strip() or "0")
        except ValueError:
            days = 0
        rows = self.dao.training_by_dept(dept_code=self.dept_cb.currentData(), min_days=days)
        self.table.setRowCount(len(rows))
        for r_idx, row in enumerate(rows):
            for c_idx, key in enumerate(self.headers):
                item = QTableWidgetItem(str(row.get(key, "")))
                item.setFlags(item.flags() ^ Qt.ItemIsEditable)
                self.table.setItem(r_idx, c_idx, item)

    def export_csv(self):
        try:
            days = int(self.days_input.text().strip() or "0")
        except ValueError:
            days = 0
        rows = self.dao.training_by_dept(dept_code=self.dept_cb.currentData(), min_days=days)
        path = self.dao.export_training_by_dept(rows, self.export_dir, "training_report.csv")
        QMessageBox.information(self, self.t.get("export_csv", "Export CSV"), f"CSV exported to: {path}")
