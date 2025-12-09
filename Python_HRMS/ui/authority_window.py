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


class AuthorityWindow(QDialog):
    def __init__(self, dao, translations):
        super().__init__()
        self.dao = dao
        self.t = translations
        self.setWindowTitle(self.t.get("authority_window_title", "權限管理"))
        self.resize(600, 420)
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

        self.headers = ["s_account", "active", "update_date"]
        self.table = QTableWidget()
        self.table.setColumnCount(len(self.headers))
        self.table.setHorizontalHeaderLabels(self.headers)
        self.table.horizontalHeader().setStretchLastSection(True)
        self.table.itemSelectionChanged.connect(self.on_row_selected)
        layout.addWidget(self.table)

        form_row = QHBoxLayout()
        self.account_input = QLineEdit()
        self.account_input.setPlaceholderText("帳號")
        self.active = QCheckBox(self.t.get("active", "Active"))
        self.active.setChecked(True)
        self.create_btn = QPushButton(self.t.get("create", "Create"))
        self.update_btn = QPushButton(self.t.get("update", "Update"))
        self.create_btn.clicked.connect(self.create_account)
        self.update_btn.clicked.connect(self.update_account)

        form_row.addWidget(QLabel("帳號"))
        form_row.addWidget(self.account_input)
        form_row.addWidget(self.active)
        form_row.addWidget(self.create_btn)
        form_row.addWidget(self.update_btn)
        form_row.addStretch()
        layout.addLayout(form_row)

        self.setLayout(layout)

    def load_data(self):
        rows = self.dao.list_accounts(active_only=self.active_only.isChecked())
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
        account = self.table.item(r, 0).text()
        active_val = self.table.item(r, 1).text()
        self.account_input.setText(account)
        self.active.setChecked(active_val in ("1", "True", "true"))

    def create_account(self):
        acc = self.account_input.text().strip()
        if not acc:
            QMessageBox.warning(self, "Warn", "請輸入帳號")
            return
        try:
            self.dao.create_account(acc, self.active.isChecked())
            self.load_data()
        except Exception as e:
            QMessageBox.critical(self, "Error", str(e))

    def update_account(self):
        acc = self.account_input.text().strip()
        if not acc:
            QMessageBox.warning(self, "Warn", "請先選擇或輸入帳號")
            return
        try:
            self.dao.update_account(acc, self.active.isChecked())
            self.load_data()
        except Exception as e:
            QMessageBox.critical(self, "Error", str(e))
