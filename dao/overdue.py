from typing import List, Dict, Any
from .db import Database


class OverdueDAO:
    def __init__(self, db: Database):
        self.db = db

    def list_overdue(self, min_days: int = 0) -> List[Dict[str, Any]]:
        sql = """
        SELECT t.emp_id,
               (COALESCE(b.last_name, '') || COALESCE(b.first_name, '')) AS c_name,
               t.certify_id,
               i.certify_name,
               t.certify_date,
               CAST(julianday('now') - julianday(t.certify_date) AS INT) AS overdue_days,
               t.active
        FROM training_record t
        LEFT JOIN certify_items i ON t.certify_id = i.certify_id
        LEFT JOIN basic b ON t.emp_id = b.emp_id
        WHERE t.active = 1 AND i.active = 1 AND b.active = 1
        """
        params = []
        if min_days > 0:
            sql += " AND (julianday('now') - julianday(t.certify_date)) >= ?"
            params.append(min_days)
        sql += " ORDER BY overdue_days DESC"
        return self.db.fetch_all(sql, params)
