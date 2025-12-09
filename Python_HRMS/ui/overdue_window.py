from PyQt5.QtWidgets import (
    QDialog,
    QVBoxLayout,
    QHBoxLayout,
    QLabel,
    QLineEdit,
    QPushButton,
    QTableWidget,
    QTableWidgetItem,
)
from PyQt5.QtCore import Qt


class OverdueWindow(QDialog):
    def __init__(self, dao, translations):
        super().__init__()
        self.dao = dao
        self.t = translations
        self.setWindowTitle(self.t.get("overdue_window_title", "到期檢核"))
        self.resize(900, 520)
        self._init_ui()
        self.load_data()

    def _init_ui(self):
        layout = QVBoxLayout()

        filter_row = QHBoxLayout()
        filter_row.addWidget(QLabel(self.t.get("overdue_days_label", "逾期天數大於等於")))
        self.days_input = QLineEdit()
        self.days_input.setPlaceholderText(self.t.get("overdue_days_placeholder", "天數，例如 660"))
        self.days_input.setText("660")
        self.refresh_btn = QPushButton(self.t.get("refresh", "Refresh"))
        self.refresh_btn.clicked.connect(self.load_data)
        filter_row.addWidget(self.days_input)
        filter_row.addWidget(self.refresh_btn)
        filter_row.addStretch()
        layout.addLayout(filter_row)

        self.headers = ["emp_id", "c_name", "certify_id", "certify_name", "certify_date", "overdue_days", "active"]
        header_labels = [
            self.t.get("col_emp_id", "emp_id"),
            self.t.get("col_c_name", "c_name"),
            self.t.get("col_certify_id", "certify_id"),
            self.t.get("col_certify_name", "certify_name"),
            self.t.get("col_certify_date", "certify_date"),
            self.t.get("col_overdue_days", "overdue_days"),
            self.t.get("col_active", "active"),
        ]
        self.table = QTableWidget()
        self.table.setColumnCount(len(self.headers))
        self.table.setHorizontalHeaderLabels(header_labels)
        header = self.table.horizontalHeader()
        header.setSectionResizeMode(self.table.horizontalHeader().ResizeToContents)
        header.setStretchLastSection(True)
        self.table.verticalHeader().setDefaultSectionSize(24)
        layout.addWidget(self.table)

        self.setLayout(layout)

    def load_data(self):
        try:
            days = int(self.days_input.text().strip() or "0")
        except ValueError:
            days = 0
        rows = self.dao.list_overdue(min_days=days)
        self.table.setRowCount(len(rows))
        for r_idx, row in enumerate(rows):
            for c_idx, key in enumerate(self.headers):
                item = QTableWidgetItem(str(row.get(key, "")))
                item.setFlags(item.flags() ^ Qt.ItemIsEditable)
                self.table.setItem(r_idx, c_idx, item)
