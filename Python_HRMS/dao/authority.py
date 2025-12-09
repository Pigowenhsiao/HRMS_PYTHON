from typing import List, Dict, Any
from .db import Database


class AuthorityDAO:
    def __init__(self, db: Database):
        self.db = db

    def list_accounts(self, active_only: bool = True) -> List[Dict[str, Any]]:
        sql = "SELECT s_account, active, update_date FROM authority"
        params = []
        if active_only:
            sql += " WHERE active = 1"
        sql += " ORDER BY s_account"
        return self.db.fetch_all(sql, params)

    def create_account(self, s_account: str, active: bool) -> int:
        # 僅寫入帳號與啟用狀態，避免因缺少 password 欄位而錯誤
        sql = """
        INSERT OR REPLACE INTO authority (s_account, active, update_date)
        VALUES (?, ?, date('now'))
        """
        return self.db.execute(sql, (s_account, int(active)))

    def update_account(self, s_account: str, active: bool) -> int:
        sql = "UPDATE authority SET active = ?, update_date = date('now') WHERE s_account = ?"
        return self.db.execute(sql, (int(active), s_account))

    def delete_account(self, s_account: str) -> int:
        sql = "DELETE FROM authority WHERE s_account = ?"
        return self.db.execute(sql, (s_account,))
