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
    QGroupBox,
    QHeaderView,
)
from PyQt5.QtCore import Qt
from ui.window_utils import set_default_window_state, center_table_columns


class SectionWindow(QDialog):
    def __init__(self, dao, translations):
        super().__init__()
        self.dao = dao
        self.t = translations
        self.setWindowTitle(self.t.get("section_window_title", "部門維護"))
        self.resize(760, 500)
        set_default_window_state(self)
        self._init_ui()
        self.load_data()

    def _init_ui(self):
        layout = QVBoxLayout()
        layout.setContentsMargins(18, 18, 18, 18)
        layout.setSpacing(12)

        self.headers = ["dept_code", "dept_desc", "active"]
        header_labels = [
            self.t.get("col_dept_code", "dept_code"),
            self.t.get("col_dept_desc", "dept_desc"),
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

        edit_box = QGroupBox(self.t.get("edit_section", "編輯區"))
        edit_box.setMinimumHeight(180)
        edit_layout = QVBoxLayout()
        edit_layout.setContentsMargins(12, 12, 12, 12)
        edit_layout.setSpacing(10)

        form_row = QHBoxLayout()
        form_row.setSpacing(10)
        self.dept_code = QLineEdit()
        self.dept_code.setPlaceholderText(self.t.get("col_dept_code", "Dept Code"))
        self.dept_desc = QLineEdit()
        self.dept_desc.setPlaceholderText(self.t.get("col_dept_desc", "Description"))
        self.active = QCheckBox(self.t.get("active", "Active"))
        self.active.setChecked(True)
        self.create_btn = QPushButton(self.t.get("create", "Create"))
        self.update_btn = QPushButton(self.t.get("update", "Update"))
        self.delete_btn = QPushButton(self.t.get("delete", "Delete"))
        self.create_btn.clicked.connect(self.create_record)
        self.update_btn.clicked.connect(self.update_record)
        self.delete_btn.clicked.connect(self.delete_record)
        for w in [
            QLabel(self.t.get("col_dept_code", "Dept")),
            self.dept_code,
            QLabel(self.t.get("col_dept_desc", "Desc")),
            self.dept_desc,
            self.active,
            self.create_btn,
            self.update_btn,
            self.delete_btn,
        ]:
            form_row.addWidget(w)
        form_row.addStretch()
        edit_layout.addLayout(form_row)
        edit_box.setLayout(edit_layout)
        layout.addWidget(edit_box)

        self.setLayout(layout)

    def load_data(self):
        rows = self.dao.list_all_sections()
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
        self.dept_code.setText(self.table.item(r, 0).text())
        self.dept_desc.setText(self.table.item(r, 1).text())
        self.active.setChecked(self.table.item(r, 2).text() in ("1", "True", "true"))

    def create_record(self):
        if not self.dept_code.text().strip():
            QMessageBox.warning(
                self, self.t.get("warn", "Warn"), self.t.get("msg_required_dept", "Dept Code is required")
            )
            return
        try:
            self.dao.create_section(self.dept_code.text().strip(), self.dept_desc.text().strip(), self.active.isChecked())
            self.load_data()
        except Exception as e:
            QMessageBox.critical(self, self.t.get("error", "Error"), str(e))

    def update_record(self):
        if not self.dept_code.text().strip():
            QMessageBox.warning(
                self, self.t.get("warn", "Warn"), self.t.get("msg_required_dept", "Dept Code is required")
            )
            return
        try:
            self.dao.update_section(self.dept_code.text().strip(), self.dept_desc.text().strip(), self.active.isChecked())
            self.load_data()
        except Exception as e:
            QMessageBox.critical(self, self.t.get("error", "Error"), str(e))

    def delete_record(self):
        if not self.dept_code.text().strip():
            QMessageBox.warning(
                self, self.t.get("warn", "Warn"), self.t.get("msg_required_dept", "Dept Code is required")
            )
            return
        try:
            self.dao.delete_section(self.dept_code.text().strip())
            self.load_data()
        except Exception as e:
            QMessageBox.critical(self, self.t.get("error", "Error"), str(e))
