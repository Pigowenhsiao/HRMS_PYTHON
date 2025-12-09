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


class EducationWindow(QDialog):
    def __init__(self, dao, translations):
        super().__init__()
        self.dao = dao
        self.t = translations
        self.setWindowTitle(self.t.get("education_window_title", "學歷 / 畢業資訊"))
        self.resize(820, 520)
        self._init_ui()
        self.load_filters()
        self.load_data()

    def _init_ui(self):
        layout = QVBoxLayout()

        filter_row = QHBoxLayout()
        self.active_only = QCheckBox(self.t.get("only_active", "Only Active"))
        self.active_only.setChecked(True)

        self.education_cb = QComboBox()
        self.education_cb.addItem("ALL", "")
        self.school_cb = QComboBox()
        self.school_cb.addItem("ALL", "")
        self.major_cb = QComboBox()
        self.major_cb.addItem("ALL", "")

        self.refresh_btn = QPushButton(self.t.get("refresh", "Refresh"))
        self.refresh_btn.clicked.connect(self.load_data)

        # 依照 VB 行為，提供三個快速篩選按鈕
        self.filter_edu_btn = QPushButton(self.t.get("filter_edu", "Filter by Education"))
        self.filter_school_btn = QPushButton(self.t.get("filter_school", "Filter by School"))
        self.filter_major_btn = QPushButton(self.t.get("filter_major", "Filter by Major"))
        self.filter_edu_btn.clicked.connect(lambda: self.load_data(force_edu=True))
        self.filter_school_btn.clicked.connect(lambda: self.load_data(force_school=True))
        self.filter_major_btn.clicked.connect(lambda: self.load_data(force_major=True))

        filter_row.addWidget(QLabel("Education"))
        filter_row.addWidget(self.education_cb)
        filter_row.addWidget(QLabel("School"))
        filter_row.addWidget(self.school_cb)
        filter_row.addWidget(QLabel("Major"))
        filter_row.addWidget(self.major_cb)
        filter_row.addWidget(self.active_only)
        filter_row.addWidget(self.refresh_btn)
        filter_row.addWidget(self.filter_edu_btn)
        filter_row.addWidget(self.filter_school_btn)
        filter_row.addWidget(self.filter_major_btn)
        filter_row.addStretch()
        layout.addLayout(filter_row)

        self.headers = ["emp_id", "c_name", "education", "g_school", "major"]
        self.table = QTableWidget()
        self.table.setColumnCount(len(self.headers))
        self.table.setHorizontalHeaderLabels(self.headers)
        self.table.horizontalHeader().setStretchLastSection(True)
        self.table.itemSelectionChanged.connect(self.on_row_selected)
        layout.addWidget(self.table)

        # 編輯表單
        form_row = QHBoxLayout()
        self.emp_input = QLineEdit()
        self.emp_input.setPlaceholderText("EMP_ID")
        self.edu_input = QLineEdit()
        self.school_input = QLineEdit()
        self.major_input = QLineEdit()
        self.update_btn = QPushButton(self.t.get("update", "Update"))
        self.update_btn.clicked.connect(self.update_record)

        form_row.addWidget(QLabel("EMP_ID"))
        form_row.addWidget(self.emp_input)
        form_row.addWidget(QLabel("Education"))
        form_row.addWidget(self.edu_input)
        form_row.addWidget(QLabel("School"))
        form_row.addWidget(self.school_input)
        form_row.addWidget(QLabel("Major"))
        form_row.addWidget(self.major_input)
        form_row.addWidget(self.update_btn)
        form_row.addStretch()
        layout.addLayout(form_row)

        self.setLayout(layout)

    def load_filters(self):
        self.education_cb.blockSignals(True)
        self.school_cb.blockSignals(True)
        self.major_cb.blockSignals(True)
        self.education_cb.clear()
        self.school_cb.clear()
        self.major_cb.clear()
        self.education_cb.addItem("ALL", "")
        self.school_cb.addItem("ALL", "")
        self.major_cb.addItem("ALL", "")
        for v in self.dao.list_distinct("education"):
            self.education_cb.addItem(v, v)
        for v in self.dao.list_distinct("g_school"):
            self.school_cb.addItem(v, v)
        for v in self.dao.list_distinct("major"):
            self.major_cb.addItem(v, v)
        self.education_cb.blockSignals(False)
        self.school_cb.blockSignals(False)
        self.major_cb.blockSignals(False)

    def on_row_selected(self):
        """表格選取後，同步下拉以便一鍵篩選"""
        items = self.table.selectedItems()
        if not items:
            return
        row = items[0].row()
        edu = self.table.item(row, 2).text()
        school = self.table.item(row, 3).text()
        major = self.table.item(row, 4).text()
        self._set_combo_if_exists(self.education_cb, edu)
        self._set_combo_if_exists(self.school_cb, school)
        self._set_combo_if_exists(self.major_cb, major)
        # 帶入表單
        emp_id = self.table.item(row, 0).text()
        self.emp_input.setText(emp_id)
        self.edu_input.setText(edu)
        self.school_input.setText(school)
        self.major_input.setText(major)

    def _set_combo_if_exists(self, combo: QComboBox, value: str):
        idx = combo.findData(value)
        if idx >= 0:
            combo.setCurrentIndex(idx)

    def load_data(self, force_edu=False, force_school=False, force_major=False):
        rows = self.dao.list_education(
            active_only=self.active_only.isChecked(),
            education=self.education_cb.currentData() if (force_edu or self.education_cb.currentData()) else "",
            g_school=self.school_cb.currentData() if (force_school or self.school_cb.currentData()) else "",
            major=self.major_cb.currentData() if (force_major or self.major_cb.currentData()) else "",
        )
        self.table.setRowCount(len(rows))
        for r_idx, row in enumerate(rows):
            for c_idx, key in enumerate(self.headers):
                item = QTableWidgetItem(str(row.get(key, "")))
                item.setFlags(item.flags() ^ Qt.ItemIsEditable)
                self.table.setItem(r_idx, c_idx, item)

    def update_record(self):
        emp = self.emp_input.text().strip()
        if not emp:
            QMessageBox.warning(self, "Warn", "請先輸入/選擇 EMP_ID")
            return
        try:
            self.dao.upsert_education(
                emp_id=emp,
                education=self.edu_input.text().strip(),
                g_school=self.school_input.text().strip(),
                major=self.major_input.text().strip(),
            )
            self.load_filters()
            self.load_data()
        except Exception as e:
            QMessageBox.critical(self, "Error", str(e))
