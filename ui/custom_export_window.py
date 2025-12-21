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
)
from PyQt5.QtCore import Qt
from ui.window_utils import set_default_window_state


class CustomExportWindow(QDialog):
    def __init__(self, report_dao, translations, export_dir):
        super().__init__()
        self.dao = report_dao
        self.t = translations
        self.export_dir = export_dir
        self.setWindowTitle(self.t.get("custom_export_window_title", "自訂查詢 / 匯出"))
        self.resize(900, 560)
        set_default_window_state(self)
        self._init_ui()
        self.load_data()

    def _init_ui(self):
        layout = QVBoxLayout()

        filter_row = QHBoxLayout()
        self.emp_input = QLineEdit()
        self.emp_input.setPlaceholderText(self.t.get("col_emp_id", "EMP_ID"))
        self.certify_input = QLineEdit()
        self.certify_input.setPlaceholderText(self.t.get("col_certify_id", "Certify_ID"))
        self.active_only = QCheckBox(self.t.get("only_active", "Only Active"))
        self.active_only.setChecked(True)
        self.refresh_btn = QPushButton(self.t.get("refresh", "Refresh"))
        self.refresh_btn.clicked.connect(self.load_data)
        self.export_btn = QPushButton(self.t.get("export_csv", "Export CSV"))
        self.export_btn.clicked.connect(self.export_csv)

        for w in [
            QLabel(self.t.get("col_emp_id", "EMP")), self.emp_input,
            QLabel(self.t.get("col_certify_id", "Certify")), self.certify_input,
            self.active_only, self.refresh_btn, self.export_btn
        ]:
            filter_row.addWidget(w)
        filter_row.addStretch()
        layout.addLayout(filter_row)

        self.headers = [
            "certify_no",
            "emp_id",
            "c_name",
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
        self.table.horizontalHeader().setStretchLastSection(True)
        layout.addWidget(self.table)

        self.setLayout(layout)

    def load_data(self):
        rows = self.dao.training_filtered(
            emp_id=self.emp_input.text().strip(),
            certify_id=self.certify_input.text().strip(),
            active_only=self.active_only.isChecked(),
        )
        self.table.setRowCount(len(rows))
        for r_idx, row in enumerate(rows):
            for c_idx, key in enumerate(self.headers):
                item = QTableWidgetItem(str(row.get(key, "")))
                item.setFlags(item.flags() ^ Qt.ItemIsEditable)
                self.table.setItem(r_idx, c_idx, item)

    def export_csv(self):
        rows = self.dao.training_filtered(
            emp_id=self.emp_input.text().strip(),
            certify_id=self.certify_input.text().strip(),
            active_only=self.active_only.isChecked(),
        )
        path = self.dao.export_training_filtered(rows, self.export_dir, "custom_export.csv")
        msg_tpl = self.t.get("msg_export_csv_done", "CSV exported to: {path}")
        QMessageBox.information(self, self.t.get("export_csv", "Export CSV"), msg_tpl.format(path=path))
