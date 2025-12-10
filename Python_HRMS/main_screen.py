import json
import sys
from pathlib import Path
from PyQt5.QtGui import QFont
from PyQt5.QtWidgets import (
    QApplication,
    QComboBox,
    QGroupBox,
    QGridLayout,
    QHBoxLayout,
    QLabel,
    QMainWindow,
    QPushButton,
    QStatusBar,
    QVBoxLayout,
    QWidget,
)

CONFIG_PATH = Path(__file__).parent / "config.json"
I18N_DIR = Path(__file__).parent / "i18n"

def load_config():
    if CONFIG_PATH.exists():
        return json.loads(CONFIG_PATH.read_text(encoding="utf-8-sig"))
    return {"default_lang": "zh", "db_path": "./data/hrms.db", "export_path": "./export", "version": "0.1.0"}

def load_i18n(lang: str):
    lang_map = {"zh": "strings_zh.json", "en": "strings_en.json", "ja": "strings_ja.json"}
    filename = lang_map.get(lang, lang_map["zh"])
    path = I18N_DIR / filename
    if not path.exists():
        path = I18N_DIR / lang_map["zh"]
    return json.loads(path.read_text(encoding="utf-8-sig"))

class MainScreen(QMainWindow):
    def __init__(self):
        super().__init__()
        self.config = load_config()
        self.current_lang = self.config.get("default_lang", "zh")
        self.translations = load_i18n(self.current_lang)

        self.setWindowTitle(self.translations["title"])
        self.setGeometry(120, 120, 920, 620)
        self._init_ui()

    def _init_ui(self):
        self.buttons = {}

        root = QWidget()
        main_layout = QVBoxLayout()
        main_layout.setContentsMargins(18, 18, 18, 12)
        main_layout.setSpacing(14)

        lang_row = QHBoxLayout()
        self.lang_label = QLabel(self.translations["lang_label"])
        self.lang_select = QComboBox()
        self.lang_select.addItems(["繁中", "English", "日本語"])
        self.lang_select.currentIndexChanged.connect(self._on_lang_change)
        lang_row.addWidget(self.lang_label)
        lang_row.addWidget(self.lang_select)
        lang_row.addStretch()

        self.title_label = QLabel(self.translations["heading"])
        self.title_label.setFont(QFont('Microsoft JhengHei', 18, QFont.Bold))
        self.subtitle_label = QLabel(self.translations["sub"])
        self.subtitle_label.setFont(QFont('Microsoft JhengHei', 10))

        main_layout.addLayout(lang_row)
        main_layout.addWidget(self.title_label)
        main_layout.addWidget(self.subtitle_label)

        grid = QGridLayout()
        grid.setSpacing(12)

        grid.addWidget(self._section_employee(), 0, 0)
        grid.addWidget(self._section_certify(), 0, 1)
        grid.addWidget(self._section_admin(), 1, 0)
        grid.addWidget(self._section_reports(), 1, 1)

        main_layout.addLayout(grid)

        self.footer = QLabel(self.translations["footer"])
        self.footer.setFont(QFont('Microsoft JhengHei', 9))
        main_layout.addWidget(self.footer)

        root.setLayout(main_layout)
        self.setCentralWidget(root)

        self.setStatusBar(QStatusBar())
        self.statusBar().showMessage('Ready')

    def _section_employee(self):
        self.box_employee = QGroupBox(self.translations["section_employee"])
        layout = QVBoxLayout()
        layout.setSpacing(8)
        self.buttons['employee_basic'] = QPushButton(self.translations["employee_basic"])
        self.buttons['employee_personal'] = QPushButton(self.translations["employee_personal"])
        self.buttons['employee_education'] = QPushButton(self.translations["employee_education"])
        for btn in self.buttons.values():
            btn.setMinimumHeight(34)
        layout.addWidget(self.buttons['employee_basic'])
        layout.addWidget(self.buttons['employee_personal'])
        layout.addWidget(self.buttons['employee_education'])
        self.box_employee.setLayout(layout)
        return self.box_employee

    def _section_certify(self):
        self.box_certify = QGroupBox(self.translations["section_certify"])
        layout = QVBoxLayout()
        layout.setSpacing(8)
        self.buttons['certify_items'] = QPushButton(self.translations["certify_items"])
        self.buttons['certify_tool_map'] = QPushButton(self.translations["certify_tool_map"])
        self.buttons['certify_record'] = QPushButton(self.translations["certify_record"])
        self.buttons['certify_overdue'] = QPushButton(self.translations["certify_overdue"])
        for key in ['certify_items', 'certify_tool_map', 'certify_record', 'certify_overdue']:
            self.buttons[key].setMinimumHeight(34)
            layout.addWidget(self.buttons[key])
        self.box_certify.setLayout(layout)
        return self.box_certify

    def _section_admin(self):
        self.box_admin = QGroupBox(self.translations["section_admin"])
        layout = QVBoxLayout()
        layout.setSpacing(8)
        self.buttons['authority'] = QPushButton(self.translations["authority"])
        self.buttons['sync_mes'] = QPushButton(self.translations["sync_mes"])
        for key in ['authority', 'sync_mes']:
            self.buttons[key].setMinimumHeight(34)
            layout.addWidget(self.buttons[key])
        self.box_admin.setLayout(layout)
        return self.box_admin

    def _section_reports(self):
        self.box_reports = QGroupBox(self.translations["section_reports"])
        layout = QVBoxLayout()
        layout.setSpacing(8)
        self.buttons['report_training'] = QPushButton(self.translations["report_training"])
        self.buttons['report_custom'] = QPushButton(self.translations["report_custom"])
        for key in ['report_training', 'report_custom']:
            self.buttons[key].setMinimumHeight(34)
            layout.addWidget(self.buttons[key])
        self.box_reports.setLayout(layout)
        return self.box_reports

    def _on_lang_change(self, index: int):
        mapping = {0: "zh", 1: "en", 2: "ja"}
        self.current_lang = mapping.get(index, "zh")
        self.translations = load_i18n(self.current_lang)
        self._apply_translation()

    def _apply_translation(self):
        t = self.translations
        self.setWindowTitle(t["title"])
        self.lang_label.setText(t["lang_label"])
        self.title_label.setText(t["heading"])
        self.subtitle_label.setText(t["sub"])
        self.footer.setText(t["footer"])
        # Update group boxes and buttons
        self.box_employee.setTitle(t["section_employee"])
        self.box_certify.setTitle(t["section_certify"])
        self.box_admin.setTitle(t["section_admin"])
        self.box_reports.setTitle(t["section_reports"])

        self.buttons['employee_basic'].setText(t["employee_basic"])
        self.buttons['employee_personal'].setText(t["employee_personal"])
        self.buttons['employee_education'].setText(t["employee_education"])

        self.buttons['certify_items'].setText(t["certify_items"])
        self.buttons['certify_tool_map'].setText(t["certify_tool_map"])
        self.buttons['certify_record'].setText(t["certify_record"])
        self.buttons['certify_overdue'].setText(t["certify_overdue"])

        self.buttons['authority'].setText(t["authority"])
        self.buttons['sync_mes'].setText(t["sync_mes"])

        self.buttons['report_training'].setText(t["report_training"])
        self.buttons['report_custom'].setText(t["report_custom"])


if __name__ == '__main__':
    app = QApplication(sys.argv)
    mainWin = MainScreen()
    mainWin.show()
    sys.exit(app.exec_())
