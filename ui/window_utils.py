from PyQt5.QtCore import Qt


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
