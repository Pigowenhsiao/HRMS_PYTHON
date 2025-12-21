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
from ui.window_utils import set_default_window_state


class TrainingReportWindow(QDialog):
    def __init__(self, report_dao, basic_dao, translations, export_dir):
        super().__init__()
        self.dao = report_dao
        self.basic_dao = basic_dao
        self.t = translations
        self.export_dir = export_dir
        self.setWindowTitle(self.t.get("training_report_window_title", "訓練報表"))
        self.resize(900, 560)
        set_default_window_state(self)
        self._init_ui()
        self.load_depts()
        self.load_data()

    def _init_ui(self):
        layout = QVBoxLayout()

        filter_row = QHBoxLayout()
        filter_row.addWidget(QLabel(self.t.get("col_dept", "Dept")))
        self.dept_cb = QComboBox()
        filter_row.addWidget(self.dept_cb)
        filter_row.addWidget(QLabel(self.t.get("overdue_days_label", "逾期天數大於等於")))
        self.days_input = QLineEdit()
        self.days_input.setPlaceholderText(self.t.get("overdue_days_placeholder", "Days, e.g. 660"))
        self.days_input.setText("0")
        self.refresh_btn = QPushButton(self.t.get("refresh", "Refresh"))
        self.refresh_btn.clicked.connect(self.load_data)
        self.export_btn = QPushButton(self.t.get("export_csv", "Export CSV"))
        self.export_btn.clicked.connect(self.export_csv)
        for w in [self.days_input, self.refresh_btn, self.export_btn]:
            filter_row.addWidget(w)
        filter_row.addStretch()
        layout.addLayout(filter_row)

        self.headers = [
            "emp_id",
            "c_name",
            "dept_desc",
            "certify_id",
            "certify_name",
            "certify_date",
            "overdue_days",
            "active",
        ]
        header_labels = [
            self.t.get("col_emp_id", "emp_id"),
            self.t.get("col_c_name", "c_name"),
            self.t.get("col_dept_desc", "dept_desc"),
            self.t.get("col_certify_id", "certify_id"),
            self.t.get("col_certify_name", "certify_name"),
            self.t.get("col_certify_date", "certify_date"),
            self.t.get("col_overdue_days", "overdue_days"),
            self.t.get("col_active", "active"),
        ]
        self.table = QTableWidget()
        self.table.setColumnCount(len(self.headers))
        self.table.setHorizontalHeaderLabels(header_labels)
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
        msg_tpl = self.t.get("msg_export_csv_done", "CSV exported to: {path}")
        QMessageBox.information(self, self.t.get("export_csv", "Export CSV"), msg_tpl.format(path=path))
