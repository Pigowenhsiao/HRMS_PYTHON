from typing import List, Dict, Any, Optional
from .db import Database


class ReportDAO:
    def __init__(self, db: Database):
        self.db = db

    def training_by_dept(self, dept_code: Optional[str] = None, min_days: int = 0) -> List[Dict[str, Any]]:
        sql = """
        SELECT t.emp_id,
               (COALESCE(b.last_name, '') || COALESCE(b.first_name, '')) AS c_name,
               s.dept_desc,
               t.certify_id,
               i.certify_name,
               t.certify_date,
               CAST(julianday('now') - julianday(t.certify_date) AS INT) AS overdue_days,
               t.active
        FROM training_record t
        LEFT JOIN certify_items i ON t.certify_id = i.certify_id
        LEFT JOIN basic b ON t.emp_id = b.emp_id
        LEFT JOIN l_section s ON b.dept_code = s.dept_code
        WHERE t.active = 1 AND i.active = 1 AND b.active = 1
        """
        params = []
        if dept_code:
            sql += " AND b.dept_code = ?"
            params.append(dept_code.strip())
        if min_days and min_days > 0:
            sql += " AND (julianday('now') - julianday(t.certify_date)) >= ?"
            params.append(min_days)
        sql += " ORDER BY t.emp_id, t.certify_id"
        return self.db.fetch_all(sql, params)

    def export_training_by_dept(self, rows: List[Dict[str, Any]], export_path, filename: str = "training_report.csv"):
        import csv
        export_path.mkdir(parents=True, exist_ok=True)
        path = export_path / filename
        headers = ["emp_id", "c_name", "dept_desc", "certify_id", "certify_name", "certify_date", "overdue_days", "active"]
        with path.open("w", newline="", encoding="utf-8-sig") as f:
            writer = csv.DictWriter(f, fieldnames=headers)
            writer.writeheader()
            for r in rows:
                writer.writerow({k: r.get(k, "") for k in headers})
        return path

    def training_filtered(self, emp_id: str = "", certify_id: str = "", active_only: bool = True) -> List[Dict[str, Any]]:
        sql = """
        SELECT t.certify_no, t.emp_id, (COALESCE(b.last_name, '') || COALESCE(b.first_name, '')) AS c_name, t.certify_id, i.certify_name, t.certify_date, t.certify_type, t.remark, t.active
        FROM training_record t
        LEFT JOIN basic b ON t.emp_id = b.emp_id
        LEFT JOIN certify_items i ON t.certify_id = i.certify_id
        WHERE 1=1
        """
        params = []
        if active_only:
            sql += " AND t.active = 1"
        if emp_id:
            sql += " AND t.emp_id = ?"
            params.append(emp_id.strip())
        if certify_id:
            sql += " AND t.certify_id = ?"
            params.append(certify_id.strip())
        sql += " ORDER BY t.certify_date DESC"
        return self.db.fetch_all(sql, params)

    def export_training_filtered(self, rows: List[Dict[str, Any]], export_path, filename: str = "custom_export.csv"):
        import csv
        export_path.mkdir(parents=True, exist_ok=True)
        path = export_path / filename
        headers = ["certify_no", "emp_id", "c_name", "certify_id", "certify_name", "certify_date", "certify_type", "remark", "active"]
        with path.open("w", newline="", encoding="utf-8-sig") as f:
            writer = csv.DictWriter(f, fieldnames=headers)
            writer.writeheader()
            for r in rows:
                writer.writerow({k: r.get(k, "") for k in headers})
        return path
