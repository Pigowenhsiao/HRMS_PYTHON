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


class CrudBaseWindow(QDialog):
    def __init__(
        self,
        dao,
        translations,
        *,
        title_key,
        title_default,
        size,
        headers,
        header_label_keys,
        fields,
        checkbox_field,
        key_field,
        list_method,
        create_method,
        update_method,
        delete_method,
        required_messages,
        center_columns=None,
    ):
        super().__init__()
        self.dao = dao
        self.t = translations
        self.headers = headers
        self._header_label_keys = header_label_keys
        self._fields = fields
        self._checkbox_field = checkbox_field
        self._key_field = key_field
        self._list_method = list_method
        self._create_method = create_method
        self._update_method = update_method
        self._delete_method = delete_method
        self._required_messages = required_messages
        self._center_columns = center_columns or []
        self._field_widgets = {}

        self.setWindowTitle(self._t(title_key, title_default))
        self.resize(*size)
        set_default_window_state(self)
        self._init_ui()
        self.load_data()

    def _t(self, key, default):
        return self.t.get(key, default)

    def _init_ui(self):
        layout = QVBoxLayout()
        layout.setContentsMargins(18, 18, 18, 18)
        layout.setSpacing(12)

        header_labels = [self._t(key, default) for key, default in self._header_label_keys]
        self.table = QTableWidget()
        self.table.setColumnCount(len(self.headers))
        self.table.setHorizontalHeaderLabels(header_labels)
        header = self.table.horizontalHeader()
        header.setSectionResizeMode(QHeaderView.ResizeToContents)
        header.setStretchLastSection(True)
        self.table.verticalHeader().setDefaultSectionSize(26)
        self.table.itemSelectionChanged.connect(self.on_row_selected)
        layout.addWidget(self.table)

        edit_box = QGroupBox(self._t("edit_section", "編輯區"))
        edit_box.setMinimumHeight(180)
        edit_layout = QVBoxLayout()
        edit_layout.setContentsMargins(12, 12, 12, 12)
        edit_layout.setSpacing(10)

        form_row = QHBoxLayout()
        form_row.setSpacing(10)
        for field in self._fields:
            label = QLabel(self._t(field["label_key"], field["label_default"]))
            edit = QLineEdit()
            placeholder_key = field.get("placeholder_key", field["label_key"])
            placeholder_default = field.get("placeholder_default", field["label_default"])
            edit.setPlaceholderText(self._t(placeholder_key, placeholder_default))
            self._field_widgets[field["name"]] = edit
            setattr(self, field["name"], edit)
            form_row.addWidget(label)
            form_row.addWidget(edit)

        if self._checkbox_field:
            checkbox = QCheckBox(
                self._t(self._checkbox_field["label_key"], self._checkbox_field["label_default"])
            )
            checkbox.setChecked(True)
            self._field_widgets[self._checkbox_field["name"]] = checkbox
            setattr(self, self._checkbox_field["name"], checkbox)
            form_row.addWidget(checkbox)

        self.create_btn = QPushButton(self._t("create", "Create"))
        self.update_btn = QPushButton(self._t("update", "Update"))
        self.delete_btn = QPushButton(self._t("delete", "Delete"))
        self.create_btn.clicked.connect(self.create_record)
        self.update_btn.clicked.connect(self.update_record)
        self.delete_btn.clicked.connect(self.delete_record)

        for btn in [self.create_btn, self.update_btn, self.delete_btn]:
            form_row.addWidget(btn)
        form_row.addStretch()
        edit_layout.addLayout(form_row)
        edit_box.setLayout(edit_layout)
        layout.addWidget(edit_box)

        self.setLayout(layout)

    def _get_text_value(self, name):
        widget = self._field_widgets.get(name)
        if isinstance(widget, QLineEdit):
            return widget.text().strip()
        return ""

    def _get_checkbox_value(self):
        if not self._checkbox_field:
            return False
        widget = self._field_widgets.get(self._checkbox_field["name"])
        return bool(widget.isChecked()) if isinstance(widget, QCheckBox) else False

    def _get_key_value(self):
        return self._get_text_value(self._key_field)

    def _warn_required(self, action):
        key, default = self._required_messages.get(action, ("", ""))
        QMessageBox.warning(self, self._t("warn", "Warn"), self._t(key, default))

    def load_data(self):
        rows = self._list_method()
        self.table.setRowCount(len(rows))
        for r_idx, row in enumerate(rows):
            for c_idx, key in enumerate(self.headers):
                item = QTableWidgetItem(str(row.get(key, "")))
                item.setFlags(item.flags() ^ Qt.ItemIsEditable)
                self.table.setItem(r_idx, c_idx, item)
        if self._center_columns:
            center_table_columns(self.table, self._center_columns)

    def on_row_selected(self):
        items = self.table.selectedItems()
        if not items:
            return
        row_idx = items[0].row()
        for field in self._fields:
            try:
                col_idx = self.headers.index(field["name"])
            except ValueError:
                continue
            item = self.table.item(row_idx, col_idx)
            self._field_widgets[field["name"]].setText(item.text() if item else "")
        if self._checkbox_field:
            try:
                col_idx = self.headers.index(self._checkbox_field["name"])
            except ValueError:
                col_idx = None
            if col_idx is not None:
                item = self.table.item(row_idx, col_idx)
                value = item.text() if item else ""
                checked = value in ("1", "True", "true")
                self._field_widgets[self._checkbox_field["name"]].setChecked(checked)

    def create_record(self):
        if not self._get_key_value():
            self._warn_required("create")
            return
        try:
            values = [self._get_text_value(field["name"]) for field in self._fields]
            values.append(self._get_checkbox_value())
            self._create_method(*values)
            self.load_data()
        except Exception as exc:
            QMessageBox.critical(self, self._t("error", "Error"), str(exc))

    def update_record(self):
        if not self._get_key_value():
            self._warn_required("update")
            return
        try:
            values = [self._get_text_value(field["name"]) for field in self._fields]
            values.append(self._get_checkbox_value())
            self._update_method(*values)
            self.load_data()
        except Exception as exc:
            QMessageBox.critical(self, self._t("error", "Error"), str(exc))

    def delete_record(self):
        key = self._get_key_value()
        if not key:
            self._warn_required("delete")
            return
        try:
            self._delete_method(key)
            self.load_data()
        except Exception as exc:
            QMessageBox.critical(self, self._t("error", "Error"), str(exc))
