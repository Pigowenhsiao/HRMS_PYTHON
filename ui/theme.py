from typing import Dict

from PyQt5.QtWidgets import QApplication


_THEMES: Dict[str, Dict[str, str]] = {
    "light": {
        "bg": "#F7F8FB",
        "card_bg": "#FFFFFF",
        "text": "#1F2A44",
        "muted": "#6B7A99",
        "accent": "#1E6FB8",
        "accent_hover": "#185FA1",
        "accent_pressed": "#144F86",
        "accent_text": "#FFFFFF",
        "border": "#D7E1F0",
        "header_bg": "#EEF2F7",
        "grid": "#E2E9F3",
        "selection": "#CFE0FF",
        "input_bg": "#FFFFFF",
        "status_bg": "#FFFFFF",
        "scroll": "#C9D6EE",
        "ghost_hover": "#E8EFFC",
        "ghost_pressed": "#DDE7FB",
        "tooltip_bg": "#1F2A44",
        "tooltip_text": "#FFFFFF",
        "nav_bg": "#2E3F53",
        "nav_text": "#E8F0FF",
        "nav_hover": "#3A4F66",
        "nav_active_bg": "#1E6FB8",
        "nav_active_text": "#FFFFFF",
        "nav_border": "#223244",
    },
    "dark": {
        "bg": "#0E1320",
        "card_bg": "#182238",
        "text": "#E7EEF8",
        "muted": "#A8B3C7",
        "accent": "#3E7CC4",
        "accent_hover": "#346EB1",
        "accent_pressed": "#2D5F98",
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
        "nav_bg": "#141B27",
        "nav_text": "#DCE6F7",
        "nav_hover": "#1E2837",
        "nav_active_bg": "#2A6DB1",
        "nav_active_text": "#FFFFFF",
        "nav_border": "#0E1520",
    },
}


def _build_stylesheet(colors: Dict[str, str]) -> str:
    arrow_color = colors["muted"].lstrip("#")
    arrow_svg = (
        "data:image/svg+xml;utf8,"
        f"<svg xmlns='http://www.w3.org/2000/svg' width='10' height='6' viewBox='0 0 10 6'>"
        f"<path fill='%23{arrow_color}' d='M0 0h10L5 6z'/>"
        "</svg>"
    )
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
    QLabel#mainSubtitle, QLabel#mainFooter, QLabel#statusCredit {{
        color: {colors['muted']};
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
        color: {colors['nav_text']};
        border: 1px solid transparent;
        border-radius: 10px;
        padding: 8px 12px;
        text-align: left;
        font-weight: 600;
    }}
    QPushButton[variant="nav"]:hover {{
        background-color: {colors['nav_hover']};
    }}
    QPushButton[variant="nav"]:checked {{
        background-color: {colors['nav_active_bg']};
        border: 1px solid {colors['nav_active_bg']};
        color: {colors['nav_active_text']};
    }}
    QPushButton[variant="nav"][collapsed="true"] {{
        text-align: center;
        padding: 8px 0px;
    }}
    QPushButton[variant="nav-toggle"] {{
        background-color: transparent;
        color: {colors['nav_text']};
        border: 1px solid {colors['nav_border']};
        border-radius: 8px;
        padding: 4px 8px;
        font-weight: 600;
    }}
    QPushButton[variant="nav-toggle"]:hover {{
        background-color: {colors['nav_hover']};
    }}
    QWidget#navPanel {{
        background-color: {colors['nav_bg']};
        border-radius: 12px;
        padding: 8px;
    }}
    QPushButton[variant="card"] {{
        background-color: {colors['card_bg']};
        color: {colors['text']};
        border: 1px solid {colors['border']};
        border-radius: 14px;
        padding: 12px 16px;
        font-weight: 600;
        text-align: left;
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
    QComboBox, QDateEdit {{
        padding-right: 26px;
    }}
    QLineEdit:focus, QComboBox:focus, QDateEdit:focus, QTextEdit:focus {{
        border: 1px solid {colors['accent']};
    }}
    QComboBox::drop-down {{
        subcontrol-origin: padding;
        subcontrol-position: top right;
        width: 22px;
        border-left: 1px solid {colors['border']};
        background-color: {colors['input_bg']};
    }}
    QComboBox::down-arrow {{
        image: url("{arrow_svg}");
        width: 10px;
        height: 6px;
    }}
    QDateEdit::drop-down {{
        subcontrol-origin: padding;
        subcontrol-position: top right;
        width: 22px;
        border-left: 1px solid {colors['border']};
        background-color: {colors['input_bg']};
    }}
    QDateEdit::down-arrow {{
        image: url("{arrow_svg}");
        width: 10px;
        height: 6px;
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
