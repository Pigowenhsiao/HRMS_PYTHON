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
)
from PyQt5.QtCore import Qt
from ui.window_utils import set_default_window_state


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

        # Filter row
        filter_row = QHBoxLayout()
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
            ("c_name", "col_c_name"),
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
        self.emp_id = QLineEdit(); self.dept_code = QComboBox(); self.c_name = QLineEdit(); self.title = QLineEdit()
        self.on_board_date = QLineEdit(); self.on_board_date.setPlaceholderText("YYYY-MM-DD")
        self.shift = QLineEdit(); self.area = QComboBox(); self.function = QComboBox(); self.meno = QLineEdit()
        self.active = QCheckBox(self.t.get("col_active", "Active")); self.active.setChecked(True)
        labels = [
            self.t.get("col_emp_id", "EMP_ID"), self.t.get("col_dept", "Dept"),
            self.t.get("col_c_name", "Name"), self.t.get("col_title", "Title"),
            self.t.get("col_on_board_date", "On Board"), self.t.get("col_shift", "Shift"),
            self.t.get("col_area", "Area"), self.t.get("col_function", "Function"),
            self.t.get("col_meno", "Memo"), self.t.get("col_active", "Active"),
        ]
        widgets = [self.emp_id, self.dept_code, self.c_name, self.title, self.on_board_date, self.shift, self.area, self.function, self.meno, self.active]
        for i, (lab, wid) in enumerate(zip(labels, widgets)):
            form.addWidget(QLabel(lab), i // 2, (i % 2) * 2); form.addWidget(wid, i // 2, (i % 2) * 2 + 1)
        layout.addLayout(form)

        # Buttons
        btn_row = QHBoxLayout()
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

    def on_row_selected(self):
        items = self.table.selectedItems();
        if not items: return
        idx = items[0].row(); field_order = [c for c, _ in self.columns]
        values = {field_order[c]: self.table.item(idx, c).text() for c in range(len(field_order))}
        self.emp_id.setText(values.get("emp_id", ""))
        self.dept_code.setCurrentIndex(max(0, self.dept_code.findData(values.get("dept_code", ""))))
        self.c_name.setText(values.get("c_name", ""))
        self.title.setText(values.get("title", ""))
        self.on_board_date.setText(values.get("on_board_date", ""))
        self.shift.setText(values.get("shift", ""))
        self.area.setCurrentIndex(max(0, self.area.findData(values.get("area", ""))))
        self.function.setCurrentIndex(max(0, self.function.findData(values.get("function", ""))))
        self.meno.setText(values.get("meno", ""))
        self.active.setChecked(values.get("active", "1") in ("1", "True", "true"))

    def _collect_form(self):
        return dict(
            emp_id=self.emp_id.text().strip(),
            dept_code=self.dept_code.currentData(),
            c_name=self.c_name.text().strip(),
            title=self.title.text().strip(),
            on_board_date=self.on_board_date.text().strip(),
            shift=self.shift.text().strip(),
            area=self.area.currentData(),
            function=self.function.currentData(),
            meno=self.meno.text().strip(),
            active=self.active.isChecked(),
        )

    def create_record(self):
        data = self._collect_form()
        if not data["emp_id"] or not data["dept_code"] or not data["c_name"]:
            QMessageBox.warning(self, "Warn", "EMP_ID / Dept / Name 必填")
            return
        try:
            self.dao.create_basic(**data)
            self.load_data()
        except Exception as e:
            QMessageBox.critical(self, "Error", str(e))

    def update_record(self):
        data = self._collect_form()
        if not data["emp_id"]:
            QMessageBox.warning(self, "Warn", "請先選擇或輸入 EMP_ID")
            return
        try:
            self.dao.update_basic(**data)
            self.load_data()
        except Exception as e:
            QMessageBox.critical(self, "Error", str(e))

    def delete_record(self):
        emp = self.emp_id.text().strip()
        if not emp:
            QMessageBox.warning(self, "Warn", "請先選擇或輸入 EMP_ID")
            return
        try:
            self.dao.delete_basic(emp)
            self.load_data()
        except Exception as e:
            QMessageBox.critical(self, "Error", str(e))
