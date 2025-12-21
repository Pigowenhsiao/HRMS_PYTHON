from PyQt5.QtWidgets import (
    QDialog,
    QVBoxLayout,
    QHBoxLayout,
    QLabel,
    QLineEdit,
    QComboBox,
    QCheckBox,
    QPushButton,
    QMessageBox,
    QGridLayout,
    QTableWidget,
    QTableWidgetItem,
    QHeaderView,
)
from PyQt5.QtCore import Qt
from ui.window_utils import set_default_window_state, center_table_columns


class PersonalWindow(QDialog):
    def __init__(self, dao, translations):
        super().__init__()
        self.dao = dao
        self.t = translations
        self.setWindowTitle(self.t.get("personal_window_title", "個人資訊 / 聯絡方式"))
        self.resize(980, 620)
        set_default_window_state(self)
        self._init_ui()
        self._load_emp_ids()
        self.load_data()

    def _label(self, key, default):
        return self.t.get(key, default)

    def _init_ui(self):
        layout = QVBoxLayout()
        layout.setContentsMargins(18, 18, 18, 18)
        layout.setSpacing(12)

        filter_row = QHBoxLayout()
        filter_row.setSpacing(8)
        filter_row.addWidget(QLabel(self._label("col_emp_id", "EMP_ID")))
        self.emp_filter = QLineEdit()
        self.emp_filter.setPlaceholderText(self._label("col_emp_id", "EMP_ID"))
        self.active_only = QCheckBox(self._label("only_active", "Only Active"))
        self.active_only.setChecked(True)
        self.refresh_btn = QPushButton(self.t.get("refresh", "Refresh"))
        self.refresh_btn.clicked.connect(self.load_data)
        filter_row.addWidget(self.emp_filter)
        filter_row.addWidget(self.active_only)
        filter_row.addWidget(self.refresh_btn)
        filter_row.addStretch()
        layout.addLayout(filter_row)

        self.headers = [
            "emp_id",
            "c_name",
            "sex",
            "birthday",
            "personal_id",
            "home_phone",
            "current_phone",
            "cell_phone",
            "living_place",
            "living_place2",
            "emg_name1",
            "emg_phone1",
            "emg_releasion1",
            "emg_name2",
            "emg_phone2",
            "emg_releasion2",
            "perf_year",
            "excomp_year",
            "ex_compy_type",
            "meno",
            "active",
        ]
        header_labels = [
            self._label("col_emp_id", "EMP_ID"),
            self._label("col_c_name", "Name"),
            self._label("col_sex", "Sex"),
            self._label("col_birthday", "Birthday"),
            self._label("col_personal_id", "Personal ID"),
            self._label("col_home_phone", "Home Phone"),
            self._label("col_current_phone", "Current Phone"),
            self._label("col_cell_phone", "Cell Phone"),
            self._label("col_living_place", "Living Place"),
            self._label("col_living_place2", "Living Place2"),
            self._label("col_emg_name1", "EMG Name1"),
            self._label("col_emg_phone1", "EMG Phone1"),
            self._label("col_emg_rel1", "Relation1"),
            self._label("col_emg_name2", "EMG Name2"),
            self._label("col_emg_phone2", "EMG Phone2"),
            self._label("col_emg_rel2", "Relation2"),
            self._label("col_perf_year", "Perf Year"),
            self._label("col_excomp_year", "Excomp Year"),
            self._label("col_ex_compy_type", "Ex Company Type"),
            self._label("col_meno", "Memo"),
            self._label("col_active", "Active"),
        ]
        self.table = QTableWidget()
        self.table.setColumnCount(len(self.headers))
        self.table.setHorizontalHeaderLabels(header_labels)
        header = self.table.horizontalHeader()
        header.setSectionResizeMode(QHeaderView.ResizeToContents)
        header.setStretchLastSection(True)
        self.table.verticalHeader().setDefaultSectionSize(26)
        self.table.setSelectionBehavior(self.table.SelectRows)
        self.table.setSelectionMode(self.table.SingleSelection)
        self.table.itemSelectionChanged.connect(self.on_row_selected)
        layout.addWidget(self.table)

        form = QGridLayout()
        form.setHorizontalSpacing(12)
        form.setVerticalSpacing(10)

        self.emp_id = QComboBox()
        self.emp_id.setEditable(True)
        self.emp_id.lineEdit().setPlaceholderText(self._label("col_emp_id", "EMP_ID"))
        self.sex = QComboBox(); self.sex.addItems(["M", "F"])
        self.birthday = QLineEdit(); self.birthday.setPlaceholderText(self._label("date_placeholder", "YYYY-MM-DD"))
        self.personal_id = QLineEdit()
        self.home_phone = QLineEdit()
        self.current_phone = QLineEdit()
        self.cell_phone = QLineEdit()
        self.living_place = QLineEdit()
        self.living_place2 = QLineEdit()
        self.emg_name1 = QLineEdit(); self.emg_phone1 = QLineEdit(); self.emg_rel1 = QLineEdit()
        self.emg_name2 = QLineEdit(); self.emg_phone2 = QLineEdit(); self.emg_rel2 = QLineEdit()
        self.perf_year = QLineEdit(); self.excomp_year = QLineEdit(); self.ex_compy_type = QLineEdit()
        self.meno = QLineEdit(); self.active = QCheckBox(self._label("col_active", "Active")); self.active.setChecked(True)

        labels = [
            ("col_emp_id", self.emp_id),
            ("col_sex", self.sex),
            ("col_birthday", self.birthday),
            ("col_personal_id", self.personal_id),
            ("col_home_phone", self.home_phone),
            ("col_current_phone", self.current_phone),
            ("col_cell_phone", self.cell_phone),
            ("col_living_place", self.living_place),
            ("col_living_place2", self.living_place2),
            ("col_emg_name1", self.emg_name1),
            ("col_emg_phone1", self.emg_phone1),
            ("col_emg_rel1", self.emg_rel1),
            ("col_emg_name2", self.emg_name2),
            ("col_emg_phone2", self.emg_phone2),
            ("col_emg_rel2", self.emg_rel2),
            ("col_perf_year", self.perf_year),
            ("col_excomp_year", self.excomp_year),
            ("col_ex_compy_type", self.ex_compy_type),
            ("col_meno", self.meno),
            ("col_active", self.active),
        ]

        for i, (key, widget) in enumerate(labels):
            form.addWidget(QLabel(self._label(key, key)), i // 2, (i % 2) * 2)
            form.addWidget(widget, i // 2, (i % 2) * 2 + 1)

        layout.addLayout(form)

        btn_row = QHBoxLayout()
        btn_row.setSpacing(10)
        self.save_btn = QPushButton(self.t.get("update", "Update"))
        self.save_btn.clicked.connect(self.save_info)
        btn_row.addWidget(self.save_btn)
        btn_row.addStretch()
        layout.addLayout(btn_row)

        self.setLayout(layout)

    def load_data(self):
        rows = self.dao.list_person_info(
            emp_id=self.emp_filter.text().strip(),
            active_only=self.active_only.isChecked(),
        )
        self.table.setRowCount(len(rows))
        for r_idx, row in enumerate(rows):
            for c_idx, key in enumerate(self.headers):
                item = QTableWidgetItem(str(row.get(key, "")))
                item.setFlags(item.flags() ^ Qt.ItemIsEditable)
                self.table.setItem(r_idx, c_idx, item)
        center_table_columns(self.table, [len(self.headers) - 1])

    def on_row_selected(self):
        items = self.table.selectedItems()
        if not items:
            return
        r = items[0].row()
        values = {self.headers[c]: self.table.item(r, c).text() for c in range(len(self.headers))}
        emp_id = values.get("emp_id", "")
        if emp_id:
            self.dao.ensure_person_info(emp_id)
        self._set_combo_if_exists(self.emp_id, emp_id)
        self.sex.setCurrentIndex(0 if values.get("sex", "M") != "F" else 1)
        self.birthday.setText(values.get("birthday", ""))
        self.personal_id.setText(values.get("personal_id", ""))
        self.home_phone.setText(values.get("home_phone", ""))
        self.current_phone.setText(values.get("current_phone", ""))
        self.cell_phone.setText(values.get("cell_phone", ""))
        self.living_place.setText(values.get("living_place", ""))
        self.living_place2.setText(values.get("living_place2", ""))
        self.emg_name1.setText(values.get("emg_name1", ""))
        self.emg_phone1.setText(values.get("emg_phone1", ""))
        self.emg_rel1.setText(values.get("emg_releasion1", ""))
        self.emg_name2.setText(values.get("emg_name2", ""))
        self.emg_phone2.setText(values.get("emg_phone2", ""))
        self.emg_rel2.setText(values.get("emg_releasion2", ""))
        self.perf_year.setText(str(values.get("perf_year", "") or ""))
        self.excomp_year.setText(str(values.get("excomp_year", "") or ""))
        self.ex_compy_type.setText(values.get("ex_compy_type", ""))
        self.meno.setText(values.get("meno", ""))
        self.active.setChecked(values.get("active", "1") in ("1", "True", "true"))

    def _load_emp_ids(self):
        self.emp_id.blockSignals(True)
        self.emp_id.clear()
        for emp_id in self.dao.list_emp_ids(active_only=True):
            self.emp_id.addItem(emp_id, emp_id)
        self.emp_id.blockSignals(False)

    def _set_combo_if_exists(self, combo: QComboBox, value: str):
        idx = combo.findData(value)
        if idx >= 0:
            combo.setCurrentIndex(idx)
        else:
            combo.setEditText(value)

    def _get_combo_value(self, combo: QComboBox) -> str:
        data = combo.currentData()
        if data is not None and str(data).strip():
            return str(data).strip()
        return combo.currentText().strip()

    def save_info(self):
        emp_id = self._get_combo_value(self.emp_id)
        if not emp_id:
            QMessageBox.warning(
                self,
                self.t.get("warn", "Warn"),
                self.t.get("msg_emp_required", "EMP_ID 必填"),
            )
            return
        try:
            self.dao.ensure_person_info(emp_id)
            self.dao.update_person_info(
                emp_id=emp_id,
                sex=self.sex.currentText(),
                birthday=self.birthday.text().strip(),
                personal_id=self.personal_id.text().strip(),
                home_phone=self.home_phone.text().strip(),
                current_phone=self.current_phone.text().strip(),
                cell_phone=self.cell_phone.text().strip(),
                living_place=self.living_place.text().strip(),
                living_place2=self.living_place2.text().strip(),
                emg_name1=self.emg_name1.text().strip(),
                emg_phone1=self.emg_phone1.text().strip(),
                emg_releasion1=self.emg_rel1.text().strip(),
                emg_name2=self.emg_name2.text().strip(),
                emg_phone2=self.emg_phone2.text().strip(),
                emg_releasion2=self.emg_rel2.text().strip(),
                perf_year=self.perf_year.text().strip(),
                excomp_year=self.excomp_year.text().strip(),
                ex_compy_type=self.ex_compy_type.text().strip(),
                meno=self.meno.text().strip(),
                active=self.active.isChecked(),
                updater="",
            )
            QMessageBox.information(
                self,
                self.t.get("info", "Info"),
                self.t.get("msg_update_done", "更新完成"),
            )
            self.load_data()
        except Exception as e:
            QMessageBox.critical(self, self.t.get("error", "Error"), str(e))
