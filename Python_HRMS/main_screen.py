import sys
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


class MainScreen(QMainWindow):
    def __init__(self):
        super().__init__()
        self.translations = {
            "zh": {
                "title": "HRMS 人資與訓練管理",
                "heading": "人力資源與訓練管理",
                "sub": "核心功能：員工主檔、個資、學歷、證照設定/紀錄、權限、報表與到期檢核。後端：SQLite。",
                "section_employee": "員工資料",
                "employee_basic": "員工主檔 / 基本資料",
                "employee_personal": "個人資訊 / 聯絡方式",
                "employee_education": "學歷 / 畢業資訊",
                "section_certify": "證照與訓練",
                "certify_items": "證照設定",
                "certify_tool_map": "證照-機台對應",
                "certify_record": "訓練/證照紀錄",
                "certify_overdue": "到期檢核",
                "section_admin": "管理與權限",
                "authority": "權限管理",
                "sync_mes": "CSV 匯出 / 對外同步",
                "section_reports": "報表與分析",
                "report_training": "訓練報表（部門/天數篩選）",
                "report_custom": "自訂查詢/匯出",
                "footer": "狀態：後端 SQLite（預設 ./data/hrms.db） | 請先設定資料庫與匯出路徑",
                "lang_label": "介面語言"
            },
            "en": {
                "title": "HRMS - HR & Training",
                "heading": "Human Resources & Training",
                "sub": "Core: employee master/personal/education, certification setup & records, authority, reports, overdue check. Backend: SQLite.",
                "section_employee": "Employee",
                "employee_basic": "Employee Master / Basic",
                "employee_personal": "Personal Info / Contacts",
                "employee_education": "Education",
                "section_certify": "Certification & Training",
                "certify_items": "Certification Setup",
                "certify_tool_map": "Cert-Tool Mapping",
                "certify_record": "Training/Certification Records",
                "certify_overdue": "Overdue Check",
                "section_admin": "Administration",
                "authority": "Authority",
                "sync_mes": "CSV Export / External Sync",
                "section_reports": "Reports & Analytics",
                "report_training": "Training Reports (Dept/Days Filter)",
                "report_custom": "Custom Query/Export",
                "footer": "Status: SQLite backend (./data/hrms.db). Configure DB and export paths first.",
                "lang_label": "Language"
            },
            "ja": {
                "title": "HRMS 人事・訓練管理",
                "heading": "人事・訓練管理",
                "sub": "主要機能：社員基本/個人/学歴、認定設定と記録、権限、レポート、期限チェック。バックエンド：SQLite。",
                "section_employee": "社員情報",
                "employee_basic": "社員マスタ / 基本情報",
                "employee_personal": "個人情報 / 連絡先",
                "employee_education": "学歴",
                "section_certify": "認定・訓練",
                "certify_items": "認定設定",
                "certify_tool_map": "認定-設備対応",
                "certify_record": "訓練/認定記録",
                "certify_overdue": "期限チェック",
                "section_admin": "管理・権限",
                "authority": "権限管理",
                "sync_mes": "CSV 出力 / 外部連携",
                "section_reports": "レポート・分析",
                "report_training": "訓練レポート（部門/日数フィルタ）",
                "report_custom": "カスタム検索/出力",
                "footer": "状態：SQLite バックエンド（./data/hrms.db）。DB と出力先を設定してください。",
                "lang_label": "言語"
            },
        }

        self.current_lang = "zh"
        self.setWindowTitle(self.translations[self.current_lang]["title"])
        self.setGeometry(120, 120, 920, 620)
        self._init_ui()

    def _init_ui(self):
        self.buttons = {}

        root = QWidget()
        main_layout = QVBoxLayout()
        main_layout.setContentsMargins(18, 18, 18, 12)
        main_layout.setSpacing(14)

        lang_row = QHBoxLayout()
        self.lang_label = QLabel(self.translations[self.current_lang]["lang_label"])
        self.lang_select = QComboBox()
        self.lang_select.addItems(["繁中", "English", "日本語"])
        self.lang_select.currentIndexChanged.connect(self._on_lang_change)
        lang_row.addWidget(self.lang_label)
        lang_row.addWidget(self.lang_select)
        lang_row.addStretch()

        self.title_label = QLabel(self.translations[self.current_lang]["heading"])
        self.title_label.setFont(QFont('Microsoft JhengHei', 18, QFont.Bold))
        self.subtitle_label = QLabel(self.translations[self.current_lang]["sub"])
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

        self.footer = QLabel(self.translations[self.current_lang]["footer"])
        self.footer.setFont(QFont('Microsoft JhengHei', 9))
        main_layout.addWidget(self.footer)

        root.setLayout(main_layout)
        self.setCentralWidget(root)

        self.setStatusBar(QStatusBar())
        self.statusBar().showMessage('準備就緒')

    def _section_employee(self):
        self.box_employee = QGroupBox(self.translations[self.current_lang]["section_employee"])
        layout = QVBoxLayout()
        layout.setSpacing(8)
        self.buttons['employee_basic'] = QPushButton(self.translations[self.current_lang]["employee_basic"])
        self.buttons['employee_personal'] = QPushButton(self.translations[self.current_lang]["employee_personal"])
        self.buttons['employee_education'] = QPushButton(self.translations[self.current_lang]["employee_education"])
        for btn in self.buttons.values():
            btn.setMinimumHeight(34)
        layout.addWidget(self.buttons['employee_basic'])
        layout.addWidget(self.buttons['employee_personal'])
        layout.addWidget(self.buttons['employee_education'])
        self.box_employee.setLayout(layout)
        return self.box_employee

    def _section_certify(self):
        self.box_certify = QGroupBox(self.translations[self.current_lang]["section_certify"])
        layout = QVBoxLayout()
        layout.setSpacing(8)
        self.buttons['certify_items'] = QPushButton(self.translations[self.current_lang]["certify_items"])
        self.buttons['certify_tool_map'] = QPushButton(self.translations[self.current_lang]["certify_tool_map"])
        self.buttons['certify_record'] = QPushButton(self.translations[self.current_lang]["certify_record"])
        self.buttons['certify_overdue'] = QPushButton(self.translations[self.current_lang]["certify_overdue"])
        for key in ['certify_items', 'certify_tool_map', 'certify_record', 'certify_overdue']:
            self.buttons[key].setMinimumHeight(34)
            layout.addWidget(self.buttons[key])
        self.box_certify.setLayout(layout)
        return self.box_certify

    def _section_admin(self):
        self.box_admin = QGroupBox(self.translations[self.current_lang]["section_admin"])
        layout = QVBoxLayout()
        layout.setSpacing(8)
        self.buttons['authority'] = QPushButton(self.translations[self.current_lang]["authority"])
        self.buttons['sync_mes'] = QPushButton(self.translations[self.current_lang]["sync_mes"])
        for key in ['authority', 'sync_mes']:
            self.buttons[key].setMinimumHeight(34)
            layout.addWidget(self.buttons[key])
        self.box_admin.setLayout(layout)
        return self.box_admin

    def _section_reports(self):
        self.box_reports = QGroupBox(self.translations[self.current_lang]["section_reports"])
        layout = QVBoxLayout()
        layout.setSpacing(8)
        self.buttons['report_training'] = QPushButton(self.translations[self.current_lang]["report_training"])
        self.buttons['report_custom'] = QPushButton(self.translations[self.current_lang]["report_custom"])
        for key in ['report_training', 'report_custom']:
            self.buttons[key].setMinimumHeight(34)
            layout.addWidget(self.buttons[key])
        self.box_reports.setLayout(layout)
        return self.box_reports

    def _on_lang_change(self, index: int):
        mapping = {0: "zh", 1: "en", 2: "ja"}
        self.current_lang = mapping.get(index, "zh")
        self._apply_translation()

    def _apply_translation(self):
        t = self.translations[self.current_lang]
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
