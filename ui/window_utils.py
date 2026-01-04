from PyQt5.QtCore import Qt
from PyQt5.QtWidgets import QComboBox


def apply_window_controls(window):
    """Ensure the window shows minimize, maximize/restore, and close buttons."""
    flags = window.windowFlags()
    flags |= Qt.Window
    flags |= Qt.WindowMinimizeButtonHint | Qt.WindowMaximizeButtonHint | Qt.WindowCloseButtonHint
    window.setWindowFlags(flags)
    window.setAttribute(Qt.WA_StyledBackground, True)


def set_default_window_state(window):
    """Apply standard window controls and start maximized."""
    apply_window_controls(window)
    window.setWindowState(window.windowState() | Qt.WindowMaximized)
    window.setAttribute(Qt.WA_StyledBackground, True)


def center_table_columns(table, columns):
    for row in range(table.rowCount()):
        for col in columns:
            item = table.item(row, col)
            if item:
                item.setTextAlignment(Qt.AlignCenter)


def set_combo_if_exists(combo: QComboBox, value: str):
    idx = combo.findData(value)
    if idx >= 0:
        combo.setCurrentIndex(idx)
    else:
        combo.setEditText(value)


def get_combo_value(combo: QComboBox) -> str:
    data = combo.currentData()
    if data is not None and str(data).strip():
        return str(data).strip()
    return combo.currentText().strip()


def label_text(translations, key, default):
    return translations.get(key, default)
