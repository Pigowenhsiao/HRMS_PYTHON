import hashlib
from PyQt5.QtWidgets import QDialog, QVBoxLayout, QHBoxLayout, QLabel, QLineEdit, QPushButton, QMessageBox, QComboBox
from ui.window_utils import apply_window_controls


class LoginDialog(QDialog):
    def __init__(self, auth_dao, translations, current_lang="zh", lang_loader=None, on_lang_change=None):
        super().__init__()
        self.auth_dao = auth_dao
        self.t = translations
        self.current_lang = current_lang
        self.lang_loader = lang_loader
        self.on_lang_change = on_lang_change
        self.lang_options = [("zh", "繁中"), ("en", "English"), ("ja", "日本語")]
        self.setWindowTitle(self.t.get("login_title", "登入"))
        self.resize(320, 180)
        self.account = None
        self.perms = {}
        apply_window_controls(self)
        self._init_ui()
        self._apply_translation()

    def _init_ui(self):
        layout = QVBoxLayout()
        layout.setContentsMargins(16, 16, 16, 16)
        layout.setSpacing(12)

        lang_row = QHBoxLayout()
        self.lang_label = QLabel()
        self.lang_select = QComboBox()
        for _, label in self.lang_options:
            self.lang_select.addItem(label)
        default_idx = next((i for i, (code, _) in enumerate(self.lang_options) if code == self.current_lang), 0)
        self.lang_select.setCurrentIndex(default_idx)
        self.lang_select.currentIndexChanged.connect(self._on_lang_change)
        lang_row.addWidget(self.lang_label)
        lang_row.addWidget(self.lang_select)
        lang_row.addStretch()
        layout.addLayout(lang_row)

        row1 = QHBoxLayout()
        self.account_label = QLabel()
        row1.addWidget(self.account_label)
        self.account_input = QLineEdit()
        row1.addWidget(self.account_input)
        layout.addLayout(row1)

        row2 = QHBoxLayout()
        self.password_label = QLabel()
        row2.addWidget(self.password_label)
        self.pwd_input = QLineEdit()
        self.pwd_input.setEchoMode(QLineEdit.Password)
        row2.addWidget(self.pwd_input)
        layout.addLayout(row2)

        btn_row = QHBoxLayout()
        self.ok_btn = QPushButton()
        self.cancel_btn = QPushButton()
        self.ok_btn.clicked.connect(self.try_login)
        self.cancel_btn.clicked.connect(self.reject)
        btn_row.addWidget(self.ok_btn)
        btn_row.addWidget(self.cancel_btn)
        btn_row.addStretch()
        layout.addLayout(btn_row)

        self.setLayout(layout)

    def _apply_translation(self):
        self.setWindowTitle(self.t.get("login_title", "登入"))
        self.lang_label.setText(self.t.get("lang_label", "Language"))
        self.account_label.setText(self.t.get("col_s_account", "帳號"))
        self.password_label.setText(self.t.get("password", "密碼"))
        self.ok_btn.setText(self.t.get("login", "登入"))
        self.cancel_btn.setText(self.t.get("cancel", "取消"))

    def _on_lang_change(self, index: int):
        if index < 0 or index >= len(self.lang_options):
            return
        lang = self.lang_options[index][0]
        self.current_lang = lang
        if self.lang_loader:
            self.t = self.lang_loader(lang)
            self._apply_translation()
        if self.on_lang_change:
            self.on_lang_change(lang)

    def try_login(self):
        acc = self.account_input.text().strip()
        pwd = self.pwd_input.text()
        if not acc:
            QMessageBox.warning(
                self,
                self.t.get("warn", "Warn"),
                self.t.get("msg_account_required", "請輸入帳號"),
            )
            return
        row = self.auth_dao.db.fetch_one("SELECT * FROM authority WHERE s_account = ? AND active = 1", (acc,))
        if not row:
            QMessageBox.critical(
                self,
                self.t.get("error", "Error"),
                self.t.get("msg_account_invalid", "帳號不存在或未啟用"),
            )
            return
        stored = row.get("password_hash", "")
        if stored and hashlib.md5(pwd.encode()).hexdigest() != stored:
            QMessageBox.critical(
                self,
                self.t.get("error", "Error"),
                self.t.get("msg_password_invalid", "密碼錯誤"),
            )
            return
        self.account = acc
        self.perms = {k: bool(row.get(k, 0)) for k in row.keys() if k.startswith("perm_")}
        self.accept()
