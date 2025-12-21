from typing import Dict

from PyQt5.QtWidgets import QApplication


_THEMES: Dict[str, Dict[str, str]] = {
    "light": {
        "bg": "#F3F6FB",
        "card_bg": "#FFFFFF",
        "text": "#1F2A44",
        "muted": "#6B7A99",
        "accent": "#2F6BFF",
        "accent_hover": "#2458D6",
        "accent_pressed": "#1E4EB8",
        "accent_text": "#FFFFFF",
        "border": "#D9E2F2",
        "header_bg": "#EFF4FF",
        "grid": "#E6EDF8",
        "selection": "#CFE0FF",
        "input_bg": "#FFFFFF",
        "status_bg": "#FFFFFF",
        "scroll": "#C9D6EE",
        "ghost_hover": "#E8EFFC",
        "ghost_pressed": "#DDE7FB",
        "tooltip_bg": "#1F2A44",
        "tooltip_text": "#FFFFFF",
    },
    "dark": {
        "bg": "#0E1320",
        "card_bg": "#182238",
        "text": "#E7EEF8",
        "muted": "#A8B3C7",
        "accent": "#4C7DFF",
        "accent_hover": "#3A6BF0",
        "accent_pressed": "#2F5FD8",
        "accent_text": "#FFFFFF",
        "border": "#2A3854",
        "header_bg": "#22314D",
        "grid": "#2A3854",
        "selection": "#2E4372",
        "input_bg": "#121A2B",
        "status_bg": "#121A2B",
        "scroll": "#364A70",
        "ghost_hover": "#1B2842",
        "ghost_pressed": "#15213A",
        "tooltip_bg": "#E7EEF8",
        "tooltip_text": "#0E1320",
    },
}


def _build_stylesheet(colors: Dict[str, str]) -> str:
    return f"""
    QWidget {{
        background-color: {colors['bg']};
        color: {colors['text']};
        font-family: "Segoe UI", "Microsoft JhengHei", "Noto Sans CJK TC", sans-serif;
    }}
    QMainWindow, QDialog {{
        background-color: {colors['bg']};
    }}
    QGroupBox {{
        background-color: {colors['card_bg']};
        border: 1px solid {colors['border']};
        border-radius: 12px;
        margin-top: 14px;
        padding: 12px;
    }}
    QGroupBox::title {{
        subcontrol-origin: margin;
        left: 12px;
        padding: 0 8px;
        color: {colors['text']};
        font-weight: 600;
    }}
    QLabel {{
        color: {colors['text']};
    }}
    QPushButton {{
        background-color: {colors['accent']};
        color: {colors['accent_text']};
        border: none;
        border-radius: 8px;
        padding: 6px 12px;
        font-weight: 600;
    }}
    QPushButton:hover {{
        background-color: {colors['accent_hover']};
    }}
    QPushButton:pressed {{
        background-color: {colors['accent_pressed']};
    }}
    QPushButton[variant="ghost"] {{
        background-color: transparent;
        color: {colors['text']};
        border: 1px solid {colors['border']};
        font-weight: 500;
    }}
    QPushButton[variant="ghost"]:hover {{
        background-color: {colors['ghost_hover']};
    }}
    QPushButton[variant="ghost"]:pressed {{
        background-color: {colors['ghost_pressed']};
    }}
    QPushButton[variant="nav"] {{
        background-color: transparent;
        color: {colors['text']};
        border: 1px solid transparent;
        border-radius: 10px;
        padding: 8px 12px;
        text-align: left;
        font-weight: 600;
    }}
    QPushButton[variant="nav"]:hover {{
        background-color: {colors['ghost_hover']};
    }}
    QPushButton[variant="nav"]:checked {{
        background-color: {colors['card_bg']};
        border: 1px solid {colors['border']};
        color: {colors['accent']};
    }}
    QPushButton[variant="card"] {{
        background-color: {colors['card_bg']};
        color: {colors['text']};
        border: 1px solid {colors['border']};
        border-radius: 14px;
        padding: 10px 12px;
        font-weight: 600;
    }}
    QPushButton[variant="card"]:hover {{
        border: 1px solid {colors['accent']};
        background-color: {colors['header_bg']};
    }}
    QPushButton[variant="card"]:pressed {{
        background-color: {colors['ghost_pressed']};
    }}
    QLineEdit, QComboBox, QDateEdit, QTextEdit {{
        background-color: {colors['input_bg']};
        border: 1px solid {colors['border']};
        border-radius: 8px;
        padding: 6px 8px;
        selection-background-color: {colors['accent']};
        selection-color: {colors['accent_text']};
    }}
    QLineEdit:focus, QComboBox:focus, QDateEdit:focus, QTextEdit:focus {{
        border: 1px solid {colors['accent']};
    }}
    QComboBox::drop-down {{
        border: none;
        width: 18px;
    }}
    QTableWidget {{
        background-color: {colors['card_bg']};
        border: 1px solid {colors['border']};
        border-radius: 10px;
        gridline-color: {colors['grid']};
    }}
    QHeaderView::section {{
        background-color: {colors['header_bg']};
        color: {colors['text']};
        border: none;
        padding: 6px 8px;
        font-weight: 600;
    }}
    QTableWidget::item:selected {{
        background-color: {colors['selection']};
        color: {colors['text']};
    }}
    QStatusBar {{
        background-color: {colors['status_bg']};
        color: {colors['text']};
        border-top: 1px solid {colors['border']};
    }}
    QCheckBox::indicator {{
        width: 16px;
        height: 16px;
    }}
    QCheckBox::indicator:unchecked {{
        border: 1px solid {colors['border']};
        background: {colors['input_bg']};
        border-radius: 4px;
    }}
    QCheckBox::indicator:checked {{
        background: {colors['accent']};
        border: 1px solid {colors['accent']};
        border-radius: 4px;
    }}
    QScrollBar:vertical {{
        background: {colors['bg']};
        width: 10px;
        margin: 2px;
    }}
    QScrollBar::handle:vertical {{
        background: {colors['scroll']};
        border-radius: 5px;
        min-height: 20px;
    }}
    QScrollBar::add-line:vertical, QScrollBar::sub-line:vertical {{
        height: 0px;
    }}
    QToolTip {{
        background-color: {colors['tooltip_bg']};
        color: {colors['tooltip_text']};
        border: none;
        padding: 4px 6px;
        border-radius: 6px;
    }}
    """


def apply_theme(app: QApplication, theme_name: str) -> str:
    theme_key = theme_name if theme_name in _THEMES else "light"
    app.setStyleSheet(_build_stylesheet(_THEMES[theme_key]))
    return theme_key
