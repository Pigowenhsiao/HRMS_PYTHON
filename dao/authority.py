from typing import List, Dict, Any
from .db import Database


class AuthorityDAO:
    def __init__(self, db: Database):
        self.db = db

    def list_accounts(self, active_only: bool = True) -> List[Dict[str, Any]]:
        sql = """
        SELECT s_account, active, update_date,
               perm_basic, perm_personal, perm_education, perm_certify_items, perm_certify_tool,
               perm_training_record, perm_overdue, perm_authority, perm_export,
               perm_area, perm_section, perm_job,
               perm_report_training, perm_custom_export
        FROM authority
        """
        params = []
        if active_only:
            sql += " WHERE active = 1"
        sql += " ORDER BY s_account"
        return self.db.fetch_all(sql, params)

    def create_account(self, s_account: str, password_hash: str, active: bool, perms: Dict[str, bool]) -> int:
        sql = """
        INSERT OR REPLACE INTO authority
        (s_account, password_hash, active,
         perm_basic, perm_personal, perm_education, perm_certify_items, perm_certify_tool,
         perm_training_record, perm_overdue, perm_authority, perm_export, perm_area, perm_section, perm_job,
         perm_report_training, perm_custom_export, update_date)
        VALUES (?, ?, ?, ?,?,?,?,?,?,?,?,?,?,?,?,?,?, date('now'))
        """
        values = (
            s_account,
            password_hash,
            int(active),
            int(perms.get("perm_basic", False)),
            int(perms.get("perm_personal", False)),
            int(perms.get("perm_education", False)),
            int(perms.get("perm_certify_items", False)),
            int(perms.get("perm_certify_tool", False)),
            int(perms.get("perm_training_record", False)),
            int(perms.get("perm_overdue", False)),
            int(perms.get("perm_authority", False)),
            int(perms.get("perm_export", False)),
            int(perms.get("perm_area", False)),
            int(perms.get("perm_section", False)),
            int(perms.get("perm_job", False)),
            int(perms.get("perm_report_training", False)),
            int(perms.get("perm_custom_export", False)),
        )
        return self.db.execute(sql, values)

    def update_account(self, s_account: str, password_hash: str, active: bool, perms: Dict[str, bool]) -> int:
        sql = """
        UPDATE authority SET
            password_hash = COALESCE(NULLIF(?, ''), password_hash),
            active = ?,
            perm_basic = ?,
            perm_personal = ?,
            perm_education = ?,
            perm_certify_items = ?,
            perm_certify_tool = ?,
            perm_training_record = ?,
            perm_overdue = ?,
            perm_authority = ?,
            perm_export = ?,
            perm_area = ?,
            perm_section = ?,
            perm_job = ?,
            perm_report_training = ?,
            perm_custom_export = ?,
            update_date = date('now')
        WHERE s_account = ?
        """
        values = (
            password_hash,
            int(active),
            int(perms.get("perm_basic", False)),
            int(perms.get("perm_personal", False)),
            int(perms.get("perm_education", False)),
            int(perms.get("perm_certify_items", False)),
            int(perms.get("perm_certify_tool", False)),
            int(perms.get("perm_training_record", False)),
            int(perms.get("perm_overdue", False)),
            int(perms.get("perm_authority", False)),
            int(perms.get("perm_export", False)),
            int(perms.get("perm_area", False)),
            int(perms.get("perm_section", False)),
            int(perms.get("perm_job", False)),
            int(perms.get("perm_report_training", False)),
            int(perms.get("perm_custom_export", False)),
            s_account,
        )
        return self.db.execute(sql, values)

    def delete_account(self, s_account: str) -> int:
        sql = "DELETE FROM authority WHERE s_account = ?"
        return self.db.execute(sql, (s_account,))
