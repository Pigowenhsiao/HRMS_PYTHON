import json
import sys
from pathlib import Path
from PyQt5.QtGui import QFont
from PyQt5.QtWidgets import (
    QApplication,
    QComboBox,
    QGroupBox,
    QHBoxLayout,
    QLabel,
    QMainWindow,
    QButtonGroup,
    QPushButton,
    QGridLayout,
    QStackedWidget,
    QStatusBar,
    QVBoxLayout,
    QWidget,
)

from dao.db import Database
from dao.certify import CertifyDAO
from dao.basic import BasicDAO
from dao.personal import PersonalDAO
from dao.education import EducationDAO
from dao.overdue import OverdueDAO
from dao.authority import AuthorityDAO
from dao.report import ReportDAO
from ui.area_window import AreaWindow
from ui.section_window import SectionWindow
from ui.job_window import JobWindow
from ui.certify_items_window import CertifyItemsWindow
from ui.certify_tool_map_window import CertifyToolMapWindow
from ui.training_record_window import TrainingRecordWindow
from ui.basic_window import BasicWindow
from ui.personal_window import PersonalWindow
from ui.education_window import EducationWindow
from ui.overdue_window import OverdueWindow
from ui.authority_window import AuthorityWindow
from ui.training_report_window import TrainingReportWindow
from ui.custom_export_window import CustomExportWindow
from ui.login_dialog import LoginDialog
from ui.theme import apply_theme

CONFIG_PATH = Path(__file__).parent / "config.json"
I18N_DIR = Path(__file__).parent / "i18n"
APP_NAME = "HRMS_NEW"
DEFAULT_CONFIG = {
    "default_lang": "ja",
    "db_path": "./data/hrms.db",
    "export_path": "./export",
    "version": "0.1.0",
    "app_name": APP_NAME,
    "theme": "light",
}


def _read_json(path: Path):
    return json.loads(path.read_text(encoding="utf-8-sig"))


def load_config():
    config = DEFAULT_CONFIG.copy()
    if CONFIG_PATH.exists():
        config.update(_read_json(CONFIG_PATH))
    return config


def save_config(config: dict):
    CONFIG_PATH.write_text(json.dumps(config, ensure_ascii=False, indent=2), encoding="utf-8")


def load_i18n(lang: str):
    lang_map = {"zh": "strings_zh.json", "en": "strings_en.json", "ja": "strings_ja.json"}
    filename = lang_map.get(lang, lang_map["zh"])
    path = I18N_DIR / filename
    if not path.exists():
        path = I18N_DIR / lang_map["zh"]
    return _read_json(path)


class MainScreen(QMainWindow):
    CARD_WIDTH = 240
    CARD_HEIGHT = 78
    def __init__(self, app=None):
        super().__init__()
        self.app = app or QApplication.instance()
        self.config = load_config()
        self.current_lang = self.config.get("default_lang", "ja")
        self.app_version = self.config.get("version", "0.1.0")
        self.app_name = self.config.get("app_name", APP_NAME)
        self.translations = load_i18n(self.current_lang)
        self.base_font_size = 13
        self.perms = {}
        self.current_user = None
        self.current_theme = self.config.get("theme", "light")

        if self.app:
            self.app.setApplicationName(self.app_name)
            self.current_theme = apply_theme(self.app, self.current_theme)

        self.setWindowTitle(self.translations["title"])
        self.setGeometry(120, 120, 1024, 768)
        self.setMinimumSize(1024, 768)

        base_dir = Path(__file__).parent
        db_path_cfg = Path(self.config.get("db_path", "./data/hrms.db"))
        export_path_cfg = Path(self.config.get("export_path", "./export"))
        db_path = db_path_cfg if db_path_cfg.is_absolute() else (base_dir / db_path_cfg)
        export_path = export_path_cfg if export_path_cfg.is_absolute() else (base_dir / export_path_cfg)

        self.db = Database(db_path)
        self.certify_dao = CertifyDAO(self.db)
        self.basic_dao = BasicDAO(self.db)
        self.personal_dao = PersonalDAO(self.db)
        self.education_dao = EducationDAO(self.db)
        self.overdue_dao = OverdueDAO(self.db)
        self.authority_dao = AuthorityDAO(self.db)
        self.report_dao = ReportDAO(self.db)
        self.export_dir = export_path

        self._init_ui()
        if not self._login_and_apply_permissions():
            sys.exit(0)

    def _init_ui(self):
        self.buttons = {}
        self.nav_buttons = {}
        self.nav_order = ["employee", "certify", "admin", "reports"]
        self.section_button_keys = {
            "employee": ["employee_basic", "employee_personal", "employee_education"],
            "certify": ["certify_items", "certify_tool_map", "certify_record", "certify_overdue"],
            "admin": ["authority", "sync_mes", "btn_area", "btn_section", "btn_job"],
            "reports": ["report_training", "report_custom"],
        }
        self.perm_map = {
            "employee_basic": "perm_basic",
            "employee_personal": "perm_personal",
            "employee_education": "perm_education",
            "certify_items": "perm_certify_items",
            "certify_tool_map": "perm_certify_tool",
            "certify_record": "perm_training_record",
            "certify_overdue": "perm_overdue",
            "authority": "perm_authority",
            "sync_mes": "perm_export",
            "btn_area": "perm_area",
            "btn_section": "perm_section",
            "btn_job": "perm_job",
            "report_training": "perm_report_training",
            "report_custom": "perm_custom_export",
        }

        root = QWidget()
        main_layout = QVBoxLayout()
        main_layout.setContentsMargins(20, 20, 14, 14)
        main_layout.setSpacing(16)

        lang_row = QHBoxLayout()
        self.lang_label = QLabel(self.translations["lang_label"])
        self.lang_select = QComboBox()
        self.lang_select.addItems(["繁中", "English", "日本語"])
        default_idx = 2 if self.current_lang == "ja" else (0 if self.current_lang == "zh" else 1)
        self.lang_select.setCurrentIndex(default_idx)
        self.lang_select.currentIndexChanged.connect(self._on_lang_change)
        self.font_inc = QPushButton("+A")
        self.font_dec = QPushButton("-A")
        self.font_inc.setFixedWidth(40)
        self.font_dec.setFixedWidth(40)
        self.font_inc.clicked.connect(self.increase_font)
        self.font_dec.clicked.connect(self.decrease_font)
        self.font_inc.setProperty("variant", "ghost")
        self.font_dec.setProperty("variant", "ghost")
        self.full_btn = QPushButton(self.translations.get("btn_fullscreen", "Full Screen"))
        self.full_btn.setFixedWidth(110)
        self.full_btn.clicked.connect(self.toggle_full_screen)
        self.full_btn.setProperty("variant", "ghost")
        self.theme_label = QLabel(self.translations.get("theme_label", "Theme"))
        self.theme_toggle = QPushButton()
        self.theme_toggle.setFixedWidth(90)
        self.theme_toggle.setProperty("variant", "ghost")
        self.theme_toggle.clicked.connect(self.toggle_theme)
        self._update_theme_button()
        lang_row.addWidget(self.lang_label)
        lang_row.addWidget(self.lang_select)
        lang_row.addWidget(self.font_inc)
        lang_row.addWidget(self.font_dec)
        lang_row.addWidget(self.theme_label)
        lang_row.addWidget(self.theme_toggle)
        lang_row.addWidget(self.full_btn)
        lang_row.addStretch()

        self.title_label = QLabel(self.translations["heading"])
        self.subtitle_label = QLabel(self.translations["sub"])

        main_layout.addLayout(lang_row)
        main_layout.addWidget(self.title_label)
        main_layout.addWidget(self.subtitle_label)

        body_layout = QHBoxLayout()
        body_layout.setSpacing(16)

        nav_layout = QVBoxLayout()
        nav_layout.setSpacing(8)
        self.nav_group = QButtonGroup()
        self.nav_group.setExclusive(True)
        nav_items = [
            ("employee", "section_employee"),
            ("certify", "section_certify"),
            ("admin", "section_admin"),
            ("reports", "section_reports"),
        ]
        for idx, (key, label_key) in enumerate(nav_items):
            btn = QPushButton(self.translations.get(label_key, label_key))
            btn.setCheckable(True)
            btn.setProperty("variant", "nav")
            btn.clicked.connect(lambda _, i=idx: self._set_nav_index(i))
            self.nav_group.addButton(btn, idx)
            self.nav_buttons[key] = btn
            nav_layout.addWidget(btn)
        nav_layout.addStretch()
        nav_widget = QWidget()
        nav_widget.setLayout(nav_layout)
        nav_widget.setFixedWidth(200)
        body_layout.addWidget(nav_widget, 0)

        self.page_stack = QStackedWidget()
        self.page_stack.addWidget(self._section_employee())
        self.page_stack.addWidget(self._section_certify())
        self.page_stack.addWidget(self._section_admin())
        self.page_stack.addWidget(self._section_reports())
        body_layout.addWidget(self.page_stack, 1)

        main_layout.addLayout(body_layout)

        self.footer = QLabel(self.translations["footer"])
        main_layout.addWidget(self.footer)

        root.setLayout(main_layout)
        self.setCentralWidget(root)

        self.status = QStatusBar()
        self.status_label = QLabel()
        self.status_user_label = QLabel()
        self.status.addWidget(self.status_label, 1)
        self.status.addPermanentWidget(self.status_user_label, 0)
        self.setStatusBar(self.status)
        self._update_status_labels()

        self._apply_font_sizes()
        self._set_nav_index(0)
        self.nav_buttons["employee"].setChecked(True)

    def _create_card_button(self, key: str, text: str, handler):
        btn = QPushButton(text)
        btn.setProperty("variant", "card")
        btn.setFixedSize(self.CARD_WIDTH, self.CARD_HEIGHT)
        btn.clicked.connect(handler)
        self.buttons[key] = btn
        return btn

    def _login_and_apply_permissions(self):
        dlg = LoginDialog(
            self.authority_dao,
            self.translations,
            current_lang=self.current_lang,
            lang_loader=load_i18n,
            on_lang_change=self._set_language_from_login,
        )
        if dlg.exec_() != dlg.Accepted:
            return False
        self.current_user = dlg.account
        self.perms = dlg.perms
        self._update_status_labels()
        self._apply_permissions()
        return True

    def _section_employee(self):
        self.box_employee = QGroupBox(self.translations["section_employee"])
        layout = QGridLayout()
        layout.setHorizontalSpacing(18)
        layout.setVerticalSpacing(18)
        layout.setContentsMargins(14, 18, 14, 18)
        btn_basic = self._create_card_button("employee_basic", self.translations["employee_basic"], self.open_basic_window)
        btn_personal = self._create_card_button(
            "employee_personal", self.translations["employee_personal"], self.open_personal_window
        )
        btn_education = self._create_card_button(
            "employee_education", self.translations["employee_education"], self.open_education_window
        )
        layout.addWidget(btn_basic, 0, 0)
        layout.addWidget(btn_personal, 0, 1)
        layout.addWidget(btn_education, 1, 0)
        layout.setRowStretch(2, 1)
        layout.setColumnStretch(2, 1)
        self.box_employee.setLayout(layout)
        return self.box_employee

    def _section_certify(self):
        self.box_certify = QGroupBox(self.translations["section_certify"])
        layout = QGridLayout()
        layout.setHorizontalSpacing(18)
        layout.setVerticalSpacing(18)
        layout.setContentsMargins(14, 18, 14, 18)
        btn_items = self._create_card_button("certify_items", self.translations["certify_items"], self.open_certify_items)
        btn_map = self._create_card_button(
            "certify_tool_map", self.translations["certify_tool_map"], self.open_certify_tool_map
        )
        btn_record = self._create_card_button(
            "certify_record", self.translations["certify_record"], self.open_training_records
        )
        btn_overdue = self._create_card_button(
            "certify_overdue", self.translations["certify_overdue"], self.open_overdue_window
        )
        layout.addWidget(btn_items, 0, 0)
        layout.addWidget(btn_map, 0, 1)
        layout.addWidget(btn_record, 1, 0)
        layout.addWidget(btn_overdue, 1, 1)
        layout.setRowStretch(2, 1)
        layout.setColumnStretch(2, 1)
        self.box_certify.setLayout(layout)
        return self.box_certify

    def _section_admin(self):
        self.box_admin = QGroupBox(self.translations["section_admin"])
        layout = QGridLayout()
        layout.setHorizontalSpacing(18)
        layout.setVerticalSpacing(18)
        layout.setContentsMargins(14, 18, 14, 18)
        btn_auth = self._create_card_button("authority", self.translations["authority"], self.open_authority_window)
        btn_sync = self._create_card_button("sync_mes", self.translations["sync_mes"], self.export_training_csv)
        btn_area = self._create_card_button("btn_area", self.translations.get("btn_area", "區域維護"), self.open_area_window)
        btn_section = self._create_card_button(
            "btn_section", self.translations.get("btn_section", "部門維護"), self.open_section_window
        )
        btn_job = self._create_card_button("btn_job", self.translations.get("btn_job", "職務/Function"), self.open_job_window)
        layout.addWidget(btn_auth, 0, 0)
        layout.addWidget(btn_sync, 0, 1)
        layout.addWidget(btn_area, 1, 0)
        layout.addWidget(btn_section, 1, 1)
        layout.addWidget(btn_job, 2, 0, 1, 2)
        layout.setRowStretch(3, 1)
        layout.setColumnStretch(2, 1)
        self.box_admin.setLayout(layout)
        return self.box_admin

    def _section_reports(self):
        self.box_reports = QGroupBox(self.translations["section_reports"])
        layout = QGridLayout()
        layout.setHorizontalSpacing(18)
        layout.setVerticalSpacing(18)
        layout.setContentsMargins(14, 18, 14, 18)
        btn_training = self._create_card_button(
            "report_training", self.translations["report_training"], self.open_training_report
        )
        btn_custom = self._create_card_button("report_custom", self.translations["report_custom"], self.open_custom_export)
        layout.addWidget(btn_training, 0, 0)
        layout.addWidget(btn_custom, 0, 1)
        layout.setRowStretch(1, 1)
        layout.setColumnStretch(2, 1)
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
        self.theme_label.setText(t.get("theme_label", "Theme"))
        self._update_theme_button()
        self.nav_buttons["employee"].setText(t["section_employee"])
        self.nav_buttons["certify"].setText(t["section_certify"])
        self.nav_buttons["admin"].setText(t["section_admin"])
        self.nav_buttons["reports"].setText(t["section_reports"])
        self.box_employee.setTitle(t["section_employee"])
        self.box_certify.setTitle(t["section_certify"])
        self.box_admin.setTitle(t["section_admin"])
        self.box_reports.setTitle(t["section_reports"])
        self.buttons["employee_basic"].setText(t["employee_basic"])
        self.buttons["employee_personal"].setText(t["employee_personal"])
        self.buttons["employee_education"].setText(t["employee_education"])
        self.buttons["certify_items"].setText(t["certify_items"])
        self.buttons["certify_tool_map"].setText(t["certify_tool_map"])
        self.buttons["certify_record"].setText(t["certify_record"])
        self.buttons["certify_overdue"].setText(t["certify_overdue"])
        self.buttons["authority"].setText(t["authority"])
        self.buttons["sync_mes"].setText(t["sync_mes"])
        self.buttons["report_training"].setText(t["report_training"])
        self.buttons["report_custom"].setText(t["report_custom"])
        if "btn_area" in self.buttons:
            self.buttons["btn_area"].setText(t.get("btn_area", "區域維護"))
            self.buttons["btn_section"].setText(t.get("btn_section", "部門維護"))
            self.buttons["btn_job"].setText(t.get("btn_job", "職務/Function"))
        if hasattr(self, "full_btn"):
            self.full_btn.setText(t.get("btn_fullscreen", "全螢幕"))
        self._update_status_labels()
        self._apply_font_sizes()

    # --- actions ---
    def open_certify_items(self):
        dlg = CertifyItemsWindow(self.certify_dao, self.translations, self.basic_dao)
        dlg.exec_()

    def open_certify_tool_map(self):
        dlg = CertifyToolMapWindow(self.certify_dao, self.translations)
        dlg.exec_()

    def open_training_records(self):
        dlg = TrainingRecordWindow(self.certify_dao, self.translations, self.export_dir, self.basic_dao, self.certify_dao)
        dlg.exec_()

    def export_training_csv(self):
        path = self.certify_dao.export_training_records(self.export_dir, "training_export.csv", only_active=False)
        from PyQt5.QtWidgets import QMessageBox
        msg_tpl = self.translations.get("msg_export_csv_done", "CSV exported to: {path}")
        QMessageBox.information(self, self.translations.get("sync_mes", "Export"), msg_tpl.format(path=path))

    def open_basic_window(self):
        dlg = BasicWindow(self.basic_dao, self.translations)
        dlg.exec_()

    def open_personal_window(self):
        dlg = PersonalWindow(self.personal_dao, self.translations)
        dlg.exec_()

    def open_education_window(self):
        dlg = EducationWindow(self.education_dao, self.translations)
        dlg.exec_()

    def open_overdue_window(self):
        dlg = OverdueWindow(self.overdue_dao, self.translations)
        dlg.exec_()

    def open_authority_window(self):
        dlg = AuthorityWindow(self.authority_dao, self.translations)
        dlg.exec_()

    def open_training_report(self):
        dlg = TrainingReportWindow(self.report_dao, self.basic_dao, self.translations, self.export_dir)
        dlg.exec_()

    def open_custom_export(self):
        dlg = CustomExportWindow(self.report_dao, self.translations, self.export_dir)
        dlg.exec_()

    def open_area_window(self):
        dlg = AreaWindow(self.basic_dao, self.translations)
        dlg.exec_()

    def open_section_window(self):
        dlg = SectionWindow(self.basic_dao, self.translations)
        dlg.exec_()

    def open_job_window(self):
        dlg = JobWindow(self.basic_dao, self.translations)
        dlg.exec_()

    # --- font size control ---
    def _apply_font_sizes(self):
        base = self.base_font_size
        app_font = QFont("Microsoft JhengHei")
        app_font.setPointSize(base)
        QApplication.instance().setFont(app_font)

        title_font = QFont("Microsoft JhengHei")
        title_font.setPointSize(base + 12)
        title_font.setBold(True)

        subtitle_font = QFont("Microsoft JhengHei")
        subtitle_font.setPointSize(base + 4)

        label_font = QFont("Microsoft JhengHei")
        label_font.setPointSize(base + 2)

        group_font = QFont("Microsoft JhengHei")
        group_font.setPointSize(base + 3)
        group_font.setBold(True)

        button_font = QFont("Microsoft JhengHei")
        button_font.setPointSize(base + 2)

        footer_font = QFont("Microsoft JhengHei")
        footer_font.setPointSize(base + 1)

        status_font = QFont("Microsoft JhengHei")
        status_font.setPointSize(base + 1)
        status_font.setBold(True)

        self.title_label.setFont(title_font)
        self.subtitle_label.setFont(subtitle_font)
        self.lang_label.setFont(label_font)
        self.lang_select.setFont(label_font)
        self.font_inc.setFont(label_font)
        self.font_dec.setFont(label_font)
        self.theme_label.setFont(label_font)
        self.theme_toggle.setFont(label_font)
        if hasattr(self, "full_btn"):
            self.full_btn.setFont(label_font)
        self.box_employee.setFont(group_font)
        self.box_certify.setFont(group_font)
        self.box_admin.setFont(group_font)
        self.box_reports.setFont(group_font)
        for btn in self.buttons.values():
            btn.setFont(button_font)
        for btn in self.nav_buttons.values():
            btn.setFont(button_font)
        self.footer.setFont(footer_font)
        self.status.setFont(status_font)
        self.status_label.setFont(status_font)
        self.status_user_label.setFont(status_font)

        self._apply_permissions()

    def increase_font(self):
        if self.base_font_size < 22:
            self.base_font_size += 1
            self._apply_font_sizes()

    def decrease_font(self):
        if self.base_font_size > 11:
            self.base_font_size -= 1
            self._apply_font_sizes()

    def toggle_full_screen(self):
        if self.isFullScreen():
            self.showNormal()
        else:
            self.showFullScreen()

    def _update_theme_button(self):
        if self.current_theme == "dark":
            label = self.translations.get("theme_dark", "Dark")
        else:
            label = self.translations.get("theme_light", "Light")
        self.theme_toggle.setText(label)

    def toggle_theme(self):
        self.current_theme = "dark" if self.current_theme == "light" else "light"
        if self.app:
            self.current_theme = apply_theme(self.app, self.current_theme)
        self._update_theme_button()
        self.config["theme"] = self.current_theme
        save_config(self.config)

    def _update_status_labels(self):
        ready = self.translations.get("status_ready", "Ready")
        tpl = self.translations.get("status_user_version", "User: {user} | Version: {version}")
        user = self.current_user or "-"
        version = self.app_version
        self.status_label.setText(ready)
        self.status_user_label.setText(tpl.format(user=user, version=version))

    def _set_language_from_login(self, lang: str):
        if lang == self.current_lang:
            return
        self.current_lang = lang
        self.translations = load_i18n(lang)
        self.config["default_lang"] = lang
        save_config(self.config)
        self._apply_translation()

    def _apply_permissions(self):
        if not hasattr(self, "perms"):
            return
        for btn_key, perm_key in self.perm_map.items():
            if btn_key in self.buttons:
                self.buttons[btn_key].setVisible(bool(self.perms.get(perm_key, False)))
        self._update_nav_visibility()

    def _set_nav_index(self, index: int):
        self.page_stack.setCurrentIndex(index)

    def _update_nav_visibility(self):
        visible_sections = []
        perms_empty = not bool(self.perms)
        for section_key in self.nav_order:
            button_keys = self.section_button_keys.get(section_key, [])
            if perms_empty:
                visible = True
            else:
                visible = any(self.perms.get(self.perm_map.get(k, ""), False) for k in button_keys)
            self.nav_buttons[section_key].setVisible(visible)
            if visible:
                visible_sections.append(section_key)

        if not visible_sections:
            return
        current_key = self.nav_order[self.page_stack.currentIndex()]
        if not self.nav_buttons[current_key].isVisible():
            first_key = visible_sections[0]
            self.nav_buttons[first_key].setChecked(True)
            self.page_stack.setCurrentIndex(self.nav_order.index(first_key))


if __name__ == "__main__":
    app = QApplication([])
    mainWin = MainScreen(app)
    mainWin.show()
    app.exec_()
