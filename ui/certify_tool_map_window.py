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
)
from PyQt5.QtCore import Qt
from ui.window_utils import set_default_window_state, center_table_columns


class CertifyToolMapWindow(QDialog):
    def __init__(self, dao, translations):
        super().__init__()
        self.dao = dao
        self.t = translations
        self.setWindowTitle(self.t.get("certify_tool_map", "證照-機台對應"))
        self.resize(860, 540)
        set_default_window_state(self)
        self._init_ui()
        self.load_data()

    def _init_ui(self):
        layout = QVBoxLayout()
        layout.setContentsMargins(18, 18, 18, 18)
        layout.setSpacing(12)

        # 篩選列
        filter_row = QHBoxLayout()
        filter_row.setSpacing(8)
        self.certify_filter = QLineEdit()
        self.certify_filter.setPlaceholderText(self.t.get("col_certify_id", "Certify ID"))
        self.tool_filter = QLineEdit()
        self.tool_filter.setPlaceholderText(self.t.get("col_tool_id", "Tool ID"))
        self.active_only = QCheckBox(self.t.get("only_active", "Only Active"))
        self.active_only.setChecked(True)
        self.refresh_btn = QPushButton(self.t.get("refresh", "Refresh"))
        self.refresh_btn.clicked.connect(self.load_data)

        filter_row.addWidget(QLabel(self.t.get("col_certify_id", "Certify ID")))
        filter_row.addWidget(self.certify_filter)
        filter_row.addWidget(QLabel(self.t.get("col_tool_id", "Tool ID")))
        filter_row.addWidget(self.tool_filter)
        filter_row.addWidget(self.active_only)
        filter_row.addWidget(self.refresh_btn)
        filter_row.addStretch()
        layout.addLayout(filter_row)

        # 表格
        self.headers = ["certify_id", "certify_name", "tool_id", "remark", "active"]
        header_labels = [
            self.t.get("col_certify_id", "certify_id"),
            self.t.get("col_certify_name", "certify_name"),
            self.t.get("col_tool_id", "tool_id"),
            self.t.get("col_remark", "remark"),
            self.t.get("col_active", "active"),
        ]
        self.table = QTableWidget()
        self.table.setColumnCount(len(self.headers))
        self.table.setHorizontalHeaderLabels(header_labels)
        header = self.table.horizontalHeader()
        header.setSectionResizeMode(self.table.horizontalHeader().ResizeToContents)
        header.setStretchLastSection(True)
        self.table.verticalHeader().setDefaultSectionSize(26)
        self.table.itemSelectionChanged.connect(self.on_row_selected)
        layout.addWidget(self.table)

        # 表單
        edit_box = QGroupBox(self.t.get("edit_section", "編輯區"))
        edit_box.setMinimumHeight(180)
        edit_layout = QVBoxLayout()
        edit_layout.setContentsMargins(12, 12, 12, 12)
        edit_layout.setSpacing(10)

        form_row1 = QHBoxLayout()
        form_row1.setSpacing(10)
        self.certify_id = QLineEdit()
        self.tool_id = QLineEdit()
        form_row1.addWidget(QLabel(self.t.get("col_certify_id", "Certify ID")))
        form_row1.addWidget(self.certify_id)
        form_row1.addWidget(QLabel(self.t.get("col_tool_id", "Tool ID")))
        form_row1.addWidget(self.tool_id)
        edit_layout.addLayout(form_row1)

        form_row2 = QHBoxLayout()
        form_row2.setSpacing(10)
        self.remark = QLineEdit()
        self.active = QCheckBox(self.t.get("active", "Active"))
        self.active.setChecked(True)
        form_row2.addWidget(QLabel(self.t.get("col_remark", "Remark")))
        form_row2.addWidget(self.remark)
        form_row2.addWidget(self.active)
        form_row2.addStretch()
        edit_layout.addLayout(form_row2)

        btn_row = QHBoxLayout()
        btn_row.setSpacing(10)
        self.create_btn = QPushButton(self.t.get("create", "Create"))
        self.update_btn = QPushButton(self.t.get("update", "Update"))
        self.delete_btn = QPushButton(self.t.get("delete", "Delete"))
        self.create_btn.clicked.connect(self.create_mapping)
        self.update_btn.clicked.connect(self.update_mapping)
        self.delete_btn.clicked.connect(self.delete_mapping)
        btn_row.addWidget(self.create_btn)
        btn_row.addWidget(self.update_btn)
        btn_row.addWidget(self.delete_btn)
        btn_row.addStretch()
        edit_layout.addLayout(btn_row)

        edit_box.setLayout(edit_layout)
        layout.addWidget(edit_box)

        self.setLayout(layout)

    def load_data(self):
        rows = self.dao.list_tool_map(
            active_only=self.active_only.isChecked(),
            certify_id=self.certify_filter.text().strip(),
            tool_id=self.tool_filter.text().strip(),
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
        self.certify_id.setText(values.get("certify_id", ""))
        self.tool_id.setText(values.get("tool_id", ""))
        self.remark.setText(values.get("remark", ""))
        self.active.setChecked(values.get("active", "1") in ("1", "True", "true"))

    def _collect_form(self):
        return dict(
            certify_id=self.certify_id.text().strip(),
            tool_id=self.tool_id.text().strip(),
            remark=self.remark.text().strip(),
            active=self.active.isChecked(),
        )

    def create_mapping(self):
        data = self._collect_form()
        if not data["certify_id"] or not data["tool_id"]:
            QMessageBox.warning(
                self,
                self.t.get("warn", "Warn"),
                self.t.get("msg_required_cert_tool", "Certify ID / Tool ID required"),
            )
            return
        try:
            self.dao.create_tool_map(**data)
            self.load_data()
        except Exception as e:
            QMessageBox.critical(self, self.t.get("error", "Error"), str(e))

    def update_mapping(self):
        data = self._collect_form()
        if not data["certify_id"] or not data["tool_id"]:
            QMessageBox.warning(
                self,
                self.t.get("warn", "Warn"),
                self.t.get("msg_required_cert_tool", "Certify ID / Tool ID required"),
            )
            return
        try:
            self.dao.update_tool_map(**data)
            self.load_data()
        except Exception as e:
            QMessageBox.critical(self, self.t.get("error", "Error"), str(e))

    def delete_mapping(self):
        cid = self.certify_id.text().strip()
        tid = self.tool_id.text().strip()
        if not cid or not tid:
            QMessageBox.warning(
                self,
                self.t.get("warn", "Warn"),
                self.t.get("msg_required_cert_tool", "Certify ID / Tool ID required"),
            )
            return
        try:
            self.dao.delete_tool_map(cid, tid)
            self.load_data()
        except Exception as e:
            QMessageBox.critical(self, self.t.get("error", "Error"), str(e))
