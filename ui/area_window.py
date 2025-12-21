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
    QHeaderView,
)
from PyQt5.QtCore import Qt
from ui.window_utils import set_default_window_state, center_table_columns


class AreaWindow(QDialog):
    def __init__(self, dao, translations):
        super().__init__()
        self.dao = dao
        self.t = translations
        self.setWindowTitle(self.t.get("area_window_title", "區域維護"))
        self.resize(700, 480)
        set_default_window_state(self)
        self._init_ui()
        self.load_data()

    def _init_ui(self):
        layout = QVBoxLayout()
        layout.setContentsMargins(18, 18, 18, 18)
        layout.setSpacing(12)

        self.headers = ["area", "area_desc", "active"]
        header_labels = [
            self.t.get("col_area", "area"),
            self.t.get("col_area_desc", "area_desc"),
            self.t.get("col_active", "active"),
        ]
        self.table = QTableWidget()
        self.table.setColumnCount(len(self.headers))
        self.table.setHorizontalHeaderLabels(header_labels)
        header = self.table.horizontalHeader()
        header.setSectionResizeMode(QHeaderView.ResizeToContents)
        header.setStretchLastSection(True)
        self.table.verticalHeader().setDefaultSectionSize(26)
        self.table.itemSelectionChanged.connect(self.on_row_selected)
        layout.addWidget(self.table)

        form_row = QHBoxLayout()
        form_row.setSpacing(10)
        self.area = QLineEdit()
        self.area.setPlaceholderText(self.t.get("col_area", "Area"))
        self.area_desc = QLineEdit()
        self.area_desc.setPlaceholderText(self.t.get("col_area_desc", "Description"))
        self.active = QCheckBox(self.t.get("active", "Active"))
        self.active.setChecked(True)
        self.create_btn = QPushButton(self.t.get("create", "Create"))
        self.update_btn = QPushButton(self.t.get("update", "Update"))
        self.delete_btn = QPushButton(self.t.get("delete", "Delete"))
        self.create_btn.clicked.connect(self.create_record)
        self.update_btn.clicked.connect(self.update_record)
        self.delete_btn.clicked.connect(self.delete_record)
        for w in [
            QLabel(self.t.get("col_area", "Area")),
            self.area,
            QLabel(self.t.get("col_area_desc", "Desc")),
            self.area_desc,
            self.active,
            self.create_btn,
            self.update_btn,
            self.delete_btn,
        ]:
            form_row.addWidget(w)
        form_row.addStretch()
        layout.addLayout(form_row)

        self.setLayout(layout)

    def load_data(self):
        rows = self.dao.list_all_areas()
        self.table.setRowCount(len(rows))
        for r_idx, row in enumerate(rows):
            for c_idx, key in enumerate(self.headers):
                item = QTableWidgetItem(str(row.get(key, "")))
                item.setFlags(item.flags() ^ Qt.ItemIsEditable)
                self.table.setItem(r_idx, c_idx, item)
        center_table_columns(self.table, [2])

    def on_row_selected(self):
        items = self.table.selectedItems()
        if not items:
            return
        r = items[0].row()
        self.area.setText(self.table.item(r, 0).text())
        self.area_desc.setText(self.table.item(r, 1).text())
        self.active.setChecked(self.table.item(r, 2).text() in ("1", "True", "true"))

    def create_record(self):
        if not self.area.text().strip():
            QMessageBox.warning(
                self, self.t.get("warn", "Warn"), self.t.get("msg_required_area", "Area is required")
            )
            return
        try:
            self.dao.create_area(self.area.text().strip(), self.area_desc.text().strip(), self.active.isChecked())
            self.load_data()
        except Exception as e:
            QMessageBox.critical(self, self.t.get("error", "Error"), str(e))

    def update_record(self):
        if not self.area.text().strip():
            QMessageBox.warning(
                self, self.t.get("warn", "Warn"), self.t.get("msg_required_area", "Area is required")
            )
            return
        try:
            self.dao.update_area(self.area.text().strip(), self.area_desc.text().strip(), self.active.isChecked())
            self.load_data()
        except Exception as e:
            QMessageBox.critical(self, self.t.get("error", "Error"), str(e))

    def delete_record(self):
        if not self.area.text().strip():
            QMessageBox.warning(
                self, self.t.get("warn", "Warn"), self.t.get("msg_required_area", "Area is required")
            )
            return
        try:
            self.dao.delete_area(self.area.text().strip())
            self.load_data()
        except Exception as e:
            QMessageBox.critical(self, self.t.get("error", "Error"), str(e))
