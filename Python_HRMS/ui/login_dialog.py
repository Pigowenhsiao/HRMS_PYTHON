import hashlib
from PyQt5.QtWidgets import QDialog, QVBoxLayout, QHBoxLayout, QLabel, QLineEdit, QPushButton, QMessageBox


class LoginDialog(QDialog):
    def __init__(self, auth_dao, translations):
        super().__init__()
        self.auth_dao = auth_dao
        self.t = translations
        self.setWindowTitle(self.t.get("login_title", "登入"))
        self.resize(320, 180)
        self.account = None
        self.perms = {}
        self._init_ui()

    def _init_ui(self):
        layout = QVBoxLayout()
        row1 = QHBoxLayout()
        row1.addWidget(QLabel(self.t.get("col_s_account", "帳號")))
        self.account_input = QLineEdit()
        row1.addWidget(self.account_input)
        layout.addLayout(row1)

        row2 = QHBoxLayout()
        row2.addWidget(QLabel(self.t.get("password", "密碼")))
        self.pwd_input = QLineEdit()
        self.pwd_input.setEchoMode(QLineEdit.Password)
        row2.addWidget(self.pwd_input)
        layout.addLayout(row2)

        btn_row = QHBoxLayout()
        ok_btn = QPushButton(self.t.get("login", "登入"))
        cancel_btn = QPushButton(self.t.get("cancel", "取消"))
        ok_btn.clicked.connect(self.try_login)
        cancel_btn.clicked.connect(self.reject)
        btn_row.addWidget(ok_btn)
        btn_row.addWidget(cancel_btn)
        btn_row.addStretch()
        layout.addLayout(btn_row)

        self.setLayout(layout)

    def try_login(self):
        acc = self.account_input.text().strip()
        pwd = self.pwd_input.text()
        if not acc:
            QMessageBox.warning(self, "Warn", "請輸入帳號")
            return
        row = self.auth_dao.db.fetch_one("SELECT * FROM authority WHERE s_account = ? AND active = 1", (acc,))
        if not row:
            QMessageBox.critical(self, "Error", "帳號不存在或未啟用")
            return
        stored = row.get("password_hash", "")
        if stored and hashlib.md5(pwd.encode()).hexdigest() != stored:
            QMessageBox.critical(self, "Error", "密碼錯誤")
            return
        self.account = acc
        self.perms = {k: bool(row.get(k, 0)) for k in row.keys() if k.startswith("perm_")}
        self.accept()
