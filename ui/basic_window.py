from PyQt5.QtWidgets import (
    QDialog,
    QVBoxLayout,
    QHBoxLayout,
    QLabel,
    QLineEdit,
    QComboBox,
    QCheckBox,
    QPushButton,
    QTableWidget,
    QTableWidgetItem,
    QMessageBox,
    QGridLayout,
    QHeaderView,
    QDateEdit,
    QCalendarWidget,
)
from PyQt5.QtCore import Qt, QDate, QPoint
from ui.window_utils import set_default_window_state, center_table_columns


class PopupDateEdit(QDateEdit):
    def __init__(self, parent=None):
        super().__init__(parent)
        self._calendar = QCalendarWidget(self)
        self._calendar.setWindowFlags(Qt.Popup)
        self._calendar.clicked.connect(self._on_date_selected)

    def mousePressEvent(self, event):
        super().mousePressEvent(event)
        if self._calendar.isVisible():
            self._calendar.hide()
            return
        self._calendar.setSelectedDate(self.date())
        pos = self.mapToGlobal(QPoint(0, self.height()))
        self._calendar.move(pos)
        self._calendar.show()
        self._calendar.raise_()
        self._calendar.activateWindow()

    def _on_date_selected(self, date):
        self.setDate(date)
        self._calendar.hide()


class BasicWindow(QDialog):
    def __init__(self, dao, translations):
        super().__init__()
        self.dao = dao
        self.t = translations
        self.setWindowTitle(self.t.get("basic_window_title", "員工主檔 / 基本資料"))
        self.resize(1000, 650)
        set_default_window_state(self)
        self._init_ui()
        self.load_filters()
        self.load_data()

    def _init_ui(self):
        layout = QVBoxLayout()
        layout.setContentsMargins(18, 18, 18, 18)
        layout.setSpacing(12)

        # Filter row
        filter_row = QHBoxLayout()
        filter_row.setSpacing(8)
        self.emp_filter = QLineEdit()
        self.emp_filter.setPlaceholderText(self.t.get("col_emp_id", "EMP_ID"))
        self.dept_filter = QComboBox(); self.dept_filter.addItem("ALL", "")
        self.area_filter = QComboBox(); self.area_filter.addItem("ALL", "")
        self.func_filter = QComboBox(); self.func_filter.addItem("ALL", "")
        self.active_only = QCheckBox(self.t.get("only_active", "Only Active")); self.active_only.setChecked(True)
        self.btn_filter = QPushButton(self.t.get("refresh", "Refresh")); self.btn_filter.clicked.connect(self.load_data)
        for w in [
            QLabel(self.t.get("col_emp_id", "EMP")), self.emp_filter,
            QLabel(self.t.get("col_dept", "Dept")), self.dept_filter,
            QLabel(self.t.get("col_area", "Area")), self.area_filter,
            QLabel(self.t.get("col_function", "Func")), self.func_filter,
            self.active_only, self.btn_filter]:
            filter_row.addWidget(w)
        filter_row.addStretch(); layout.addLayout(filter_row)

        # Table
        self.columns = [
            ("emp_id", "col_emp_id"),
            ("dept_code", "col_dept_code"),
            ("dept_desc", "col_dept_desc"),
            ("last_name", "col_last_name"),
            ("first_name", "col_first_name"),
            ("title", "col_title"),
            ("on_board_date", "col_on_board_date"),
            ("shift", "col_shift"),
            ("area", "col_area"),
            ("function", "col_function"),
            ("meno", "col_meno"),
            ("active", "col_active"),
        ]
        self.table = QTableWidget(); self.table.setColumnCount(len(self.columns)); self._apply_headers()
        header = self.table.horizontalHeader(); header.setSectionResizeMode(QHeaderView.ResizeToContents); header.setStretchLastSection(True)
        self.table.verticalHeader().setDefaultSectionSize(28)
        self.table.itemSelectionChanged.connect(self.on_row_selected)
        layout.addWidget(self.table)

        # Form
        form = QGridLayout()
        form.setHorizontalSpacing(12)
        form.setVerticalSpacing(10)
        form.setColumnStretch(0, 0)
        form.setColumnStretch(1, 1)
        form.setColumnStretch(2, 0)
        form.setColumnStretch(3, 1)
        self.emp_id = QLineEdit(); self.dept_code = QComboBox()
        self.last_name = QLineEdit(); self.first_name = QLineEdit(); self.title = QComboBox()
        self.title.setEditable(True)
        self.on_board_date = PopupDateEdit()
        self.on_board_date.setDisplayFormat("yyyy-MM-dd")
        self.on_board_date.setMinimumDate(QDate(1900, 1, 1))
        self.on_board_date.setSpecialValueText("")
        self.on_board_date.setDate(QDate.currentDate())
        self.shift = QComboBox(); self.shift.setEditable(True)
        self.area = QComboBox(); self.function = QComboBox(); self.meno = QLineEdit()
        self.active = QCheckBox(self.t.get("col_active", "Active")); self.active.setChecked(True)
        labels = [
            self.t.get("col_emp_id", "EMP_ID"),
            self.t.get("col_dept", "Dept"),
            self.t.get("col_last_name", "Last Name"),
            self.t.get("col_first_name", "First Name"),
            self.t.get("col_title", "Title"),
            self.t.get("col_on_board_date", "On Board"),
            self.t.get("col_shift", "Shift"),
            self.t.get("col_area", "Area"),
            self.t.get("col_function", "Function"),
            self.t.get("col_meno", "Memo"),
            self.t.get("col_active", "Active"),
        ]
        widgets = [
            self.emp_id, self.dept_code, self.last_name, self.first_name, self.title,
            self.on_board_date, self.shift, self.area, self.function, self.meno, self.active
        ]
        for i, (lab, wid) in enumerate(zip(labels, widgets)):
            form.addWidget(QLabel(lab), i // 2, (i % 2) * 2); form.addWidget(wid, i // 2, (i % 2) * 2 + 1)
        layout.addLayout(form)

        # Buttons
        btn_row = QHBoxLayout()
        btn_row.setSpacing(10)
        self.btn_create = QPushButton(self.t.get("create", "Create")); self.btn_update = QPushButton(self.t.get("update", "Update")); self.btn_delete = QPushButton(self.t.get("delete", "Delete"))
        self.btn_create.clicked.connect(self.create_record); self.btn_update.clicked.connect(self.update_record); self.btn_delete.clicked.connect(self.delete_record)
        for b in [self.btn_create, self.btn_update, self.btn_delete]: btn_row.addWidget(b)
        btn_row.addStretch(); layout.addLayout(btn_row)

        self.setLayout(layout)

    def _apply_headers(self):
        self.table.setHorizontalHeaderLabels([self.t.get(k, k) for _, k in self.columns])

    def load_filters(self):
        self.dept_filter.blockSignals(True); self.dept_filter.clear(); self.dept_filter.addItem("ALL", "")
        for row in self.dao.list_sections(): self.dept_filter.addItem(f"{row['dept_code']} {row.get('dept_desc','')}", row['dept_code'])
        self.dept_filter.blockSignals(False)

        self.area_filter.blockSignals(True); self.area_filter.clear(); self.area_filter.addItem("ALL", "")
        for row in self.dao.list_areas(): self.area_filter.addItem(f"{row['area']} {row.get('area_desc','')}", row['area'])
        self.area_filter.blockSignals(False)

        self.func_filter.blockSignals(True); self.func_filter.clear(); self.func_filter.addItem("ALL", "")
        for row in self.dao.list_jobs(): self.func_filter.addItem(f"{row['l_job']} {row.get('l_job_desc','')}", row['l_job'])
        self.func_filter.blockSignals(False)

        self.dept_code.clear(); [self.dept_code.addItem(f"{r['dept_code']} {r.get('dept_desc','')}", r['dept_code']) for r in self.dao.list_sections()]
        self.area.clear(); [self.area.addItem(f"{r['area']} {r.get('area_desc','')}", r['area']) for r in self.dao.list_areas()]
        self.function.clear(); [self.function.addItem(f"{r['l_job']} {r.get('l_job_desc','')}", r['l_job']) for r in self.dao.list_jobs()]
        self.title.blockSignals(True); self.title.clear(); self.title.addItem("", "")
        for v in self.dao.list_titles(): self.title.addItem(v, v)
        self.title.blockSignals(False)
        self.shift.blockSignals(True); self.shift.clear(); self.shift.addItem("", "")
        for v in self.dao.list_shifts(): self.shift.addItem(v, v)
        self.shift.blockSignals(False)

    def load_data(self):
        data = self.dao.list_basic(
            active_only=self.active_only.isChecked(),
            emp_id=self.emp_filter.text().strip() or None,
            dept_code=self.dept_filter.currentData(),
            area=self.area_filter.currentData(),
            function=self.func_filter.currentData(),
        )
        self.table.setRowCount(len(data))
        field_order = [c for c, _ in self.columns]
        for r, row in enumerate(data):
            for c, key in enumerate(field_order):
                item = QTableWidgetItem(str(row.get(key, "")))
                item.setFlags(item.flags() ^ Qt.ItemIsEditable)
                self.table.setItem(r, c, item)
        active_idx = field_order.index("active")
        center_table_columns(self.table, [active_idx])

    def on_row_selected(self):
        items = self.table.selectedItems();
        if not items: return
        idx = items[0].row(); field_order = [c for c, _ in self.columns]
        values = {field_order[c]: self.table.item(idx, c).text() for c in range(len(field_order))}
        self.emp_id.setText(values.get("emp_id", ""))
        self.dept_code.setCurrentIndex(max(0, self.dept_code.findData(values.get("dept_code", ""))))
        self.last_name.setText(values.get("last_name", ""))
        self.first_name.setText(values.get("first_name", ""))
        self._set_combo_if_exists(self.title, values.get("title", ""))
        raw_date = values.get("on_board_date", "")
        parsed = QDate.fromString(raw_date, "yyyy-MM-dd")
        if parsed.isValid():
            self.on_board_date.setDate(parsed)
        else:
            self.on_board_date.setDate(self.on_board_date.minimumDate())
        self._set_combo_if_exists(self.shift, values.get("shift", ""))
        self.area.setCurrentIndex(max(0, self.area.findData(values.get("area", ""))))
        self.function.setCurrentIndex(max(0, self.function.findData(values.get("function", ""))))
        self.meno.setText(values.get("meno", ""))
        self.active.setChecked(values.get("active", "1") in ("1", "True", "true"))

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

    def _collect_form(self):
        selected_date = self.on_board_date.date()
        if selected_date == self.on_board_date.minimumDate():
            on_board_date = ""
        else:
            on_board_date = selected_date.toString("yyyy-MM-dd")
        return dict(
            emp_id=self.emp_id.text().strip(),
            dept_code=self.dept_code.currentData(),
            last_name=self.last_name.text().strip(),
            first_name=self.first_name.text().strip(),
            title=self._get_combo_value(self.title),
            on_board_date=on_board_date,
            shift=self._get_combo_value(self.shift),
            area=self.area.currentData(),
            function=self.function.currentData(),
            meno=self.meno.text().strip(),
            active=self.active.isChecked(),
        )

    def create_record(self):
        data = self._collect_form()
        if not data["emp_id"] or not data["dept_code"] or not data["last_name"]:
            QMessageBox.warning(
                self,
                self.t.get("warn", "Warn"),
                self.t.get("msg_required_basic_fields", "EMP_ID / Dept / 姓氏 必填"),
            )
            return
        try:
            self.dao.create_basic(**data)
            self.load_data()
        except Exception as e:
            QMessageBox.critical(self, self.t.get("error", "Error"), str(e))

    def update_record(self):
        data = self._collect_form()
        if not data["emp_id"]:
            QMessageBox.warning(
                self,
                self.t.get("warn", "Warn"),
                self.t.get("msg_required_emp_select", "請先選擇或輸入 EMP_ID"),
            )
            return
        try:
            self.dao.update_basic(**data)
            self.load_data()
        except Exception as e:
            QMessageBox.critical(self, self.t.get("error", "Error"), str(e))

    def delete_record(self):
        emp = self.emp_id.text().strip()
        if not emp:
            QMessageBox.warning(
                self,
                self.t.get("warn", "Warn"),
                self.t.get("msg_required_emp_select", "請先選擇或輸入 EMP_ID"),
            )
            return
        try:
            self.dao.delete_basic(emp)
            self.load_data()
        except Exception as e:
            QMessageBox.critical(self, self.t.get("error", "Error"), str(e))
