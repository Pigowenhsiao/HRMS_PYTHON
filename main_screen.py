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

CONFIG_PATH = Path(__file__).parent / "config.json"
I18N_DIR = Path(__file__).parent / "i18n"


def _read_json(path: Path):
    return json.loads(path.read_text(encoding="utf-8-sig"))


def load_config():
    if CONFIG_PATH.exists():
        return _read_json(CONFIG_PATH)
    return {"default_lang": "ja", "db_path": "./data/hrms.db", "export_path": "./export", "version": "0.1.0"}


def load_i18n(lang: str):
    lang_map = {"zh": "strings_zh.json", "en": "strings_en.json", "ja": "strings_ja.json"}
    filename = lang_map.get(lang, lang_map["zh"])
    path = I18N_DIR / filename
    if not path.exists():
        path = I18N_DIR / lang_map["zh"]
    return _read_json(path)


class MainScreen(QMainWindow):
    def __init__(self):
        super().__init__()
        self.config = load_config()
        self.current_lang = self.config.get("default_lang", "ja")
        self.app_version = self.config.get("version", "0.1.0")
        self.translations = load_i18n(self.current_lang)
        self.base_font_size = 13
        self.perms = {}
        self.current_user = None

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
        self.full_btn = QPushButton(self.translations.get("btn_fullscreen", "Full Screen"))
        self.full_btn.setFixedWidth(110)
        self.full_btn.clicked.connect(self.toggle_full_screen)
        lang_row.addWidget(self.lang_label)
        lang_row.addWidget(self.lang_select)
        lang_row.addWidget(self.font_inc)
        lang_row.addWidget(self.font_dec)
        lang_row.addWidget(self.full_btn)
        lang_row.addStretch()

        self.title_label = QLabel(self.translations["heading"])
        self.subtitle_label = QLabel(self.translations["sub"])

        main_layout.addLayout(lang_row)
        main_layout.addWidget(self.title_label)
        main_layout.addWidget(self.subtitle_label)

        grid = QGridLayout()
        grid.setSpacing(16)

        grid.addWidget(self._section_employee(), 0, 0)
        grid.addWidget(self._section_certify(), 0, 1)
        grid.addWidget(self._section_admin(), 1, 0)
        grid.addWidget(self._section_reports(), 1, 1)

        main_layout.addLayout(grid)

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

    def _login_and_apply_permissions(self):
        dlg = LoginDialog(self.authority_dao, self.translations)
        if dlg.exec_() != dlg.Accepted:
            return False
        self.current_user = dlg.account
        self.perms = dlg.perms
        self._update_status_labels()
        self._apply_permissions()
        return True

    def _section_employee(self):
        self.box_employee = QGroupBox(self.translations["section_employee"])
        layout = QVBoxLayout()
        layout.setSpacing(10)
        self.buttons["employee_basic"] = QPushButton(self.translations["employee_basic"])
        self.buttons["employee_personal"] = QPushButton(self.translations["employee_personal"])
        self.buttons["employee_education"] = QPushButton(self.translations["employee_education"])
        self.buttons["employee_basic"].clicked.connect(self.open_basic_window)
        self.buttons["employee_personal"].clicked.connect(self.open_personal_window)
        self.buttons["employee_education"].clicked.connect(self.open_education_window)
        for btn in self.buttons.values():
            btn.setMinimumHeight(38)
        layout.addWidget(self.buttons["employee_basic"])
        layout.addWidget(self.buttons["employee_personal"])
        layout.addWidget(self.buttons["employee_education"])
        self.box_employee.setLayout(layout)
        return self.box_employee

    def _section_certify(self):
        self.box_certify = QGroupBox(self.translations["section_certify"])
        layout = QVBoxLayout()
        layout.setSpacing(10)
        self.buttons["certify_items"] = QPushButton(self.translations["certify_items"])
        self.buttons["certify_tool_map"] = QPushButton(self.translations["certify_tool_map"])
        self.buttons["certify_record"] = QPushButton(self.translations["certify_record"])
        self.buttons["certify_overdue"] = QPushButton(self.translations["certify_overdue"])
        self.buttons["certify_items"].clicked.connect(self.open_certify_items)
        self.buttons["certify_tool_map"].clicked.connect(self.open_certify_tool_map)
        self.buttons["certify_record"].clicked.connect(self.open_training_records)
        self.buttons["certify_overdue"].clicked.connect(self.open_overdue_window)
        for key in ["certify_items", "certify_tool_map", "certify_record", "certify_overdue"]:
            self.buttons[key].setMinimumHeight(38)
            layout.addWidget(self.buttons[key])
        self.box_certify.setLayout(layout)
        return self.box_certify

    def _section_admin(self):
        self.box_admin = QGroupBox(self.translations["section_admin"])
        layout = QVBoxLayout()
        layout.setSpacing(10)
        self.buttons["authority"] = QPushButton(self.translations["authority"])
        self.buttons["sync_mes"] = QPushButton(self.translations["sync_mes"])
        self.buttons["btn_area"] = QPushButton(self.translations.get("btn_area", "區域維護"))
        self.buttons["btn_section"] = QPushButton(self.translations.get("btn_section", "部門維護"))
        self.buttons["btn_job"] = QPushButton(self.translations.get("btn_job", "職務/Function"))
        self.buttons["sync_mes"].clicked.connect(self.export_training_csv)
        self.buttons["authority"].clicked.connect(self.open_authority_window)
        self.buttons["btn_area"].clicked.connect(self.open_area_window)
        self.buttons["btn_section"].clicked.connect(self.open_section_window)
        self.buttons["btn_job"].clicked.connect(self.open_job_window)
        for key in ["authority", "sync_mes"]:
            self.buttons[key].setMinimumHeight(38)
            layout.addWidget(self.buttons[key])
        for key in ["btn_area", "btn_section", "btn_job"]:
            self.buttons[key].setMinimumHeight(36)
            layout.addWidget(self.buttons[key])
        self.box_admin.setLayout(layout)
        return self.box_admin

    def _section_reports(self):
        self.box_reports = QGroupBox(self.translations["section_reports"])
        layout = QVBoxLayout()
        layout.setSpacing(10)
        self.buttons["report_training"] = QPushButton(self.translations["report_training"])
        self.buttons["report_custom"] = QPushButton(self.translations["report_custom"])
        self.buttons["report_training"].clicked.connect(self.open_training_report)
        self.buttons["report_custom"].clicked.connect(self.open_custom_export)
        for key in ["report_training", "report_custom"]:
            self.buttons[key].setMinimumHeight(38)
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
        QMessageBox.information(self, self.translations.get("sync_mes", "Export"), f"CSV exported to: {path}")

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
        if hasattr(self, "full_btn"):
            self.full_btn.setFont(label_font)
        self.box_employee.setFont(group_font)
        self.box_certify.setFont(group_font)
        self.box_admin.setFont(group_font)
        self.box_reports.setFont(group_font)
        for btn in self.buttons.values():
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

    def _update_status_labels(self):
        ready = self.translations.get("status_ready", "Ready")
        tpl = self.translations.get("status_user_version", "User: {user} | Version: {version}")
        user = self.current_user or "-"
        version = self.app_version
        self.status_label.setText(ready)
        self.status_user_label.setText(tpl.format(user=user, version=version))

    def _apply_permissions(self):
        if not hasattr(self, "perms"):
            return
        perm_map = {
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
        for btn_key, perm_key in perm_map.items():
            if btn_key in self.buttons:
                self.buttons[btn_key].setVisible(bool(self.perms.get(perm_key, False)))


if __name__ == "__main__":
    app = QApplication([])
    mainWin = MainScreen()
    mainWin.show()
    app.exec_()
