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
)
from PyQt5.QtCore import Qt
from ui.window_utils import set_default_window_state


class PersonalWindow(QDialog):
    def __init__(self, dao, translations):
        super().__init__()
        self.dao = dao
        self.t = translations
        self.setWindowTitle(self.t.get("personal_window_title", "個人資訊 / 聯絡方式"))
        self.resize(820, 520)
        set_default_window_state(self)
        self._init_ui()
        self.load_emp_ids()
        if self.emp_combo.count() > 0:
            self.emp_combo.setCurrentIndex(0)
            self.load_person_info()

    def _label(self, key, default):
        return self.t.get(key, default)

    def _init_ui(self):
        layout = QVBoxLayout()
        layout.setContentsMargins(18, 18, 18, 18)
        layout.setSpacing(12)

        # EMP selector
        top_row = QHBoxLayout()
        top_row.setSpacing(10)
        top_row.addWidget(QLabel(self._label("col_emp_id", "EMP_ID")))
        self.emp_combo = QComboBox()
        self.emp_combo.currentIndexChanged.connect(self.load_person_info)
        top_row.addWidget(self.emp_combo)
        top_row.addStretch()
        layout.addLayout(top_row)

        form = QGridLayout()
        form.setHorizontalSpacing(12)
        form.setVerticalSpacing(10)

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
            form.addWidget(QLabel(self._label(key, key)), i, 0)
            form.addWidget(widget, i, 1)

        layout.addLayout(form)

        btn_row = QHBoxLayout()
        btn_row.setSpacing(10)
        self.save_btn = QPushButton(self.t.get("update", "Update"))
        self.save_btn.clicked.connect(self.save_info)
        btn_row.addWidget(self.save_btn)
        btn_row.addStretch()
        layout.addLayout(btn_row)

        self.setLayout(layout)

    def load_emp_ids(self):
        self.emp_combo.blockSignals(True)
        self.emp_combo.clear()
        for emp in self.dao.list_emp_ids(active_only=True):
            self.emp_combo.addItem(emp, emp)
        self.emp_combo.blockSignals(False)

    def load_person_info(self):
        emp_id = self.emp_combo.currentData()
        if not emp_id:
            return
        self.dao.ensure_person_info(emp_id)
        data = self.dao.get_person_info(emp_id)
        self.sex.setCurrentIndex(0 if data.get("sex", "M") != "F" else 1)
        self.birthday.setText(data.get("birthday", ""))
        self.personal_id.setText(data.get("personal_id", ""))
        self.home_phone.setText(data.get("home_phone", ""))
        self.current_phone.setText(data.get("current_phone", ""))
        self.cell_phone.setText(data.get("cell_phone", ""))
        self.living_place.setText(data.get("living_place", ""))
        self.living_place2.setText(data.get("living_place2", ""))
        self.emg_name1.setText(data.get("emg_name1", ""))
        self.emg_phone1.setText(data.get("emg_phone1", ""))
        self.emg_rel1.setText(data.get("emg_releasion1", ""))
        self.emg_name2.setText(data.get("emg_name2", ""))
        self.emg_phone2.setText(data.get("emg_phone2", ""))
        self.emg_rel2.setText(data.get("emg_releasion2", ""))
        self.perf_year.setText(str(data.get("perf_year", "") or ""))
        self.excomp_year.setText(str(data.get("excomp_year", "") or ""))
        self.ex_compy_type.setText(data.get("ex_compy_type", ""))
        self.meno.setText(data.get("meno", ""))
        self.active.setChecked(str(data.get("active", "1")) in ("1", "True", "true"))

    def save_info(self):
        emp_id = self.emp_combo.currentData()
        if not emp_id:
            QMessageBox.warning(
                self,
                self.t.get("warn", "Warn"),
                self.t.get("msg_emp_required", "EMP_ID 必填"),
            )
            return
        try:
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
        except Exception as e:
            QMessageBox.critical(self, self.t.get("error", "Error"), str(e))
