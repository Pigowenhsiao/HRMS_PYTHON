from typing import List, Dict, Any, Optional
from .db import Database


class EducationDAO:
    def __init__(self, db: Database):
        self.db = db

    def list_distinct(self, column: str) -> List[str]:
        if column not in ("education", "g_school", "major"):
            return []
        sql = f"SELECT DISTINCT {column} FROM te_edu ORDER BY {column}"
        rows = self.db.fetch_all(sql)
        return [r.get(column, "") for r in rows if r.get(column, "")]

    def list_education(
        self,
        active_only: bool = True,
        education: Optional[str] = None,
        g_school: Optional[str] = None,
        major: Optional[str] = None,
    ) -> List[Dict[str, Any]]:
        sql = """
        SELECT e.emp_id,
               (COALESCE(b.last_name, '') || COALESCE(b.first_name, '')) AS c_name,
               e.education,
               e.g_school,
               e.major
        FROM te_edu e
        LEFT JOIN basic b ON e.emp_id = b.emp_id
        WHERE 1=1
        """
        params = []
        if active_only:
            sql += " AND b.active = 1"
        if education:
            sql += " AND e.education = ?"
            params.append(education.strip())
        if g_school:
            sql += " AND e.g_school = ?"
            params.append(g_school.strip())
        if major:
            sql += " AND e.major = ?"
            params.append(major.strip())
        sql += " ORDER BY e.emp_id"
        return self.db.fetch_all(sql, params)

    def upsert_education(self, emp_id: str, education: str, g_school: str, major: str) -> int:
        """若有該 emp_id 則更新，否則插入"""
        update_sql = """
        UPDATE te_edu
        SET education = ?, g_school = ?, major = ?
        WHERE emp_id = ?
        """
        updated = self.db.execute(update_sql, (education, g_school, major, emp_id))
        if updated == 0:
            insert_sql = """
            INSERT INTO te_edu (emp_id, education, g_school, major)
            VALUES (?, ?, ?, ?)
            """
            return self.db.execute(insert_sql, (emp_id, education, g_school, major))
        return updated
