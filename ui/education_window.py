from PyQt5.QtWidgets import (
    QDialog, QVBoxLayout, QHBoxLayout, QLabel, QComboBox, QCheckBox, QPushButton,
    QTableWidget, QTableWidgetItem, QLineEdit, QMessageBox, QHeaderView, QGroupBox, QGridLayout
)
from PyQt5.QtCore import Qt
from ui.window_utils import set_default_window_state, set_combo_if_exists, get_combo_value, label_text


class EducationWindow(QDialog):
    def __init__(self, dao, translations):
        super().__init__()
        self.dao = dao
        self.t = translations
        self.setWindowTitle(self.t.get("education_window_title", "學歷 / 畢業資訊"))
        self.resize(920, 600)
        set_default_window_state(self)
        self._init_ui()
        self.load_filters()
        self.load_data()

    def _init_ui(self):
        layout = QVBoxLayout()
        layout.setContentsMargins(18, 18, 18, 18)
        layout.setSpacing(12)

        # Filters
        filter_row = QHBoxLayout()
        filter_row.setSpacing(8)
        self.active_only = QCheckBox(label_text(self.t, "only_active", "Only Active"))
        self.active_only.setChecked(True)
        all_label = label_text(self.t, "filter_all", "ALL")
        self.education_cb = QComboBox(); self.education_cb.addItem(all_label, "")
        self.school_cb = QComboBox(); self.school_cb.addItem(all_label, "")
        self.major_cb = QComboBox(); self.major_cb.addItem(all_label, "")
        filter_width = self.education_cb.sizeHint().width() * 2
        self.education_cb.setMinimumWidth(filter_width)
        self.school_cb.setMinimumWidth(filter_width)
        self.major_cb.setMinimumWidth(filter_width)
        self.refresh_btn = QPushButton(label_text(self.t, "refresh", "Refresh"))
        self.refresh_btn.clicked.connect(self.load_data)
        self.filter_edu_btn = QPushButton(label_text(self.t, "filter_edu", "Filter by Education"))
        self.filter_school_btn = QPushButton(label_text(self.t, "filter_school", "Filter by School"))
        self.filter_major_btn = QPushButton(label_text(self.t, "filter_major", "Filter by Major"))
        self.filter_edu_btn.clicked.connect(lambda: self.load_data(force_edu=True))
        self.filter_school_btn.clicked.connect(lambda: self.load_data(force_school=True))
        self.filter_major_btn.clicked.connect(lambda: self.load_data(force_major=True))

        filter_row.addWidget(QLabel(label_text(self.t, "col_education", "Education")))
        filter_row.addWidget(self.education_cb)
        filter_row.addWidget(QLabel(label_text(self.t, "col_g_school", "School")))
        filter_row.addWidget(self.school_cb)
        filter_row.addWidget(QLabel(label_text(self.t, "col_major", "Major")))
        filter_row.addWidget(self.major_cb)
        filter_row.addWidget(self.active_only)
        filter_row.addWidget(self.refresh_btn)
        filter_row.addWidget(self.filter_edu_btn)
        filter_row.addWidget(self.filter_school_btn)
        filter_row.addWidget(self.filter_major_btn)
        filter_row.addStretch()
        layout.addLayout(filter_row)

        # Table
        self.columns = [
            ("emp_id", "col_emp_id"),
            ("c_name", "col_c_name"),
            ("education", "col_education"),
            ("g_school", "col_g_school"),
            ("major", "col_major"),
        ]
        self.table = QTableWidget(); self.table.setColumnCount(len(self.columns))
        self._apply_headers()
        header = self.table.horizontalHeader()
        header.setSectionResizeMode(QHeaderView.ResizeToContents)
        header.setStretchLastSection(True)
        self.table.verticalHeader().setDefaultSectionSize(26)
        self.table.itemSelectionChanged.connect(self.on_row_selected)
        layout.addWidget(self.table)

        # Form (bottom editor)
        edit_box = QGroupBox(label_text(self.t, "edit_section", "編輯區"))
        edit_box.setMinimumHeight(180)
        edit_layout = QVBoxLayout()
        edit_layout.setContentsMargins(12, 12, 12, 12)
        edit_layout.setSpacing(10)

        form = QGridLayout()
        form.setHorizontalSpacing(12)
        form.setVerticalSpacing(10)
        self.emp_input = QComboBox()
        self.emp_input.setEditable(True)
        self.emp_input.lineEdit().setPlaceholderText(label_text(self.t, "col_emp_id", "EMP_ID"))
        self.edu_input = QLineEdit(); self.school_input = QLineEdit(); self.major_input = QLineEdit()
        form.addWidget(QLabel(label_text(self.t, "col_emp_id", "EMP_ID")), 0, 0)
        form.addWidget(self.emp_input, 0, 1)
        form.addWidget(QLabel(label_text(self.t, "col_education", "Education")), 0, 2)
        form.addWidget(self.edu_input, 0, 3)
        form.addWidget(QLabel(label_text(self.t, "col_g_school", "School")), 1, 0)
        form.addWidget(self.school_input, 1, 1)
        form.addWidget(QLabel(label_text(self.t, "col_major", "Major")), 1, 2)
        form.addWidget(self.major_input, 1, 3)
        edit_layout.addLayout(form)

        btn_row = QHBoxLayout()
        btn_row.setSpacing(10)
        self.update_btn = QPushButton(label_text(self.t, "update", "Update"))
        self.update_btn.clicked.connect(self.update_record)
        btn_row.addStretch()
        btn_row.addWidget(self.update_btn)
        edit_layout.addLayout(btn_row)

        edit_box.setLayout(edit_layout)
        layout.addWidget(edit_box)

        self.setLayout(layout)

    def _apply_headers(self):
        labels = [self.t.get(key, key) for _, key in self.columns]
        self.table.setHorizontalHeaderLabels(labels)

    def load_filters(self):
        self.education_cb.blockSignals(True); self.school_cb.blockSignals(True); self.major_cb.blockSignals(True)
        self.education_cb.clear(); self.school_cb.clear(); self.major_cb.clear()
        all_label = label_text(self.t, "filter_all", "ALL")
        self.education_cb.addItem(all_label, ""); self.school_cb.addItem(all_label, ""); self.major_cb.addItem(all_label, "")
        for v in self.dao.list_distinct("education"): self.education_cb.addItem(v, v)
        for v in self.dao.list_distinct("g_school"): self.school_cb.addItem(v, v)
        for v in self.dao.list_distinct("major"): self.major_cb.addItem(v, v)
        self.education_cb.blockSignals(False); self.school_cb.blockSignals(False); self.major_cb.blockSignals(False)
        self._load_emp_ids()

    def _load_emp_ids(self):
        self.emp_input.blockSignals(True)
        self.emp_input.clear()
        for emp_id in self.dao.list_emp_ids(active_only=True):
            self.emp_input.addItem(emp_id, emp_id)
        self.emp_input.blockSignals(False)

    def on_row_selected(self):
        items = self.table.selectedItems();
        if not items: return
        r = items[0].row()
        field_order = [f for f, _ in self.columns]
        values = {field_order[c]: self.table.item(r, c).text() for c in range(len(field_order))}
        edu = values.get("education", ""); school = values.get("g_school", ""); major = values.get("major", "")
        set_combo_if_exists(self.education_cb, edu)
        set_combo_if_exists(self.school_cb, school)
        set_combo_if_exists(self.major_cb, major)
        set_combo_if_exists(self.emp_input, values.get("emp_id", ""))
        self.edu_input.setText(edu)
        self.school_input.setText(school)
        self.major_input.setText(major)

    def load_data(self, force_edu=False, force_school=False, force_major=False):
        rows = self.dao.list_education(
            active_only=self.active_only.isChecked(),
            education=self.education_cb.currentData() if (force_edu or self.education_cb.currentData()) else "",
            g_school=self.school_cb.currentData() if (force_school or self.school_cb.currentData()) else "",
            major=self.major_cb.currentData() if (force_major or self.major_cb.currentData()) else "",
        )
        self.table.setRowCount(len(rows))
        field_order = [f for f, _ in self.columns]
        for r_idx, row in enumerate(rows):
            for c_idx, key in enumerate(field_order):
                item = QTableWidgetItem(str(row.get(key, "")))
                item.setFlags(item.flags() ^ Qt.ItemIsEditable)
                self.table.setItem(r_idx, c_idx, item)

    def update_record(self):
        emp = get_combo_value(self.emp_input)
        if not emp:
            QMessageBox.warning(
                self,
                self.t.get("warn", "Warn"),
                self.t.get("msg_emp_required", "EMP_ID 必填"),
            )
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
            set_combo_if_exists(self.emp_input, emp)
        except Exception as e:
            QMessageBox.critical(self, self.t.get("error", "Error"), str(e))
