import csv
from pathlib import Path
from typing import List, Dict, Iterable, Any

from .db import Database


class CertifyDAO:
    def __init__(self, db: Database):
        self.db = db

    def list_certify_items(self, active_only: bool = True) -> List[Dict[str, Any]]:
        sql = """
        SELECT certify_id, dept, certify_name, certify_time, certify_grade, certify_type, remark, active
        FROM certify_items
        """
        params = []
        if active_only:
            sql += " WHERE active = 1"
        sql += " ORDER BY certify_id"
        return self.db.fetch_all(sql, params)

    def create_certify_item(
        self,
        certify_id: str,
        dept: str,
        certify_name: str,
        certify_time: str,
        certify_grade: str,
        certify_type: str,
        remark: str,
        active: bool,
    ) -> int:
        sql = """
        INSERT INTO certify_items (certify_id, dept, certify_name, certify_time, certify_grade, certify_type, remark, active)
        VALUES (?, ?, ?, ?, ?, ?, ?, ?)
        """
        return self.db.execute(
            sql, (certify_id, dept, certify_name, certify_time, certify_grade, certify_type, remark, int(active))
        )

    def update_certify_item(
        self,
        certify_id: str,
        dept: str,
        certify_name: str,
        certify_time: str,
        certify_grade: str,
        certify_type: str,
        remark: str,
        active: bool,
    ) -> int:
        sql = """
        UPDATE certify_items
        SET dept = ?, certify_name = ?, certify_time = ?, certify_grade = ?, certify_type = ?, remark = ?, active = ?
        WHERE certify_id = ?
        """
        return self.db.execute(
            sql, (dept, certify_name, certify_time, certify_grade, certify_type, remark, int(active), certify_id)
        )

    def list_tool_map(self, active_only: bool = True, certify_id: str = "", tool_id: str = "") -> List[Dict[str, Any]]:
        sql = """
        SELECT m.certify_id,
               i.certify_name,
               m.tool_id,
               m.remark,
               m.active
        FROM certify_tool_map m
        LEFT JOIN certify_items i ON m.certify_id = i.certify_id
        """
        params = []
        conds = []
        if active_only:
            conds.append("m.active = 1")
        if certify_id:
            conds.append("m.certify_id = ?")
            params.append(certify_id.strip())
        if tool_id:
            conds.append("m.tool_id = ?")
            params.append(tool_id.strip())
        if conds:
            sql += " WHERE " + " AND ".join(conds)
        sql += " ORDER BY m.certify_id, m.tool_id"
        return self.db.fetch_all(sql, params)

    def create_tool_map(self, certify_id: str, tool_id: str, remark: str, active: bool) -> int:
        sql = """
        INSERT INTO certify_tool_map (certify_id, tool_id, update_date, remark, active)
        VALUES (?, ?, date('now'), ?, ?)
        """
        return self.db.execute(sql, (certify_id, tool_id, remark, int(active)))

    def update_tool_map(self, certify_id: str, tool_id: str, remark: str, active: bool) -> int:
        sql = """
        UPDATE certify_tool_map
        SET remark = ?, update_date = date('now'), active = ?
        WHERE certify_id = ? AND tool_id = ?
        """
        return self.db.execute(sql, (remark, int(active), certify_id, tool_id))

    def delete_tool_map(self, certify_id: str, tool_id: str) -> int:
        sql = "DELETE FROM certify_tool_map WHERE certify_id = ? AND tool_id = ?"
        return self.db.execute(sql, (certify_id, tool_id))

    def list_training_records(self, only_active: bool = True) -> List[Dict[str, Any]]:
        sql = """
        SELECT t.certify_no,
               t.emp_id,
               b.c_name,
               b.dept_code,
               b.area,
               t.certify_id,
               i.certify_name,
               t.certify_date,
               t.certify_type,
               t.remark,
               t.active
        FROM training_record t
        LEFT JOIN certify_items i ON t.certify_id = i.certify_id
        LEFT JOIN basic b ON t.emp_id = b.emp_id
        """
        if only_active:
            sql += " WHERE t.active = 1"
        sql += " ORDER BY t.certify_no DESC"
        return self.db.fetch_all(sql)

    def next_certify_no(self) -> int:
        row = self.db.fetch_one("SELECT COALESCE(MAX(certify_no), 0) + 1 AS next_no FROM training_record")
        return int(row.get("next_no", 1)) if row else 1

    def create_training_record(
        self,
        emp_id: str,
        certify_id: str,
        certify_date: str,
        certify_type: str,
        remark: str,
        active: bool,
        updater: str,
    ) -> int:
        certify_no = self.next_certify_no()
        sql = """
        INSERT INTO training_record
        (certify_no, emp_id, certify_id, certify_date, certify_type, update_date, remark, active, updater)
        VALUES (?, ?, ?, ?, ?, date('now'), ?, ?, ?)
        """
        return self.db.execute(
            sql, (certify_no, emp_id, certify_id, certify_date, certify_type, remark, int(active), updater)
        )

    def update_training_record(
        self,
        certify_no: int,
        emp_id: str,
        certify_id: str,
        certify_date: str,
        certify_type: str,
        remark: str,
        active: bool,
        updater: str,
    ) -> int:
        sql = """
        UPDATE training_record
        SET emp_id = ?, certify_id = ?, certify_date = ?, certify_type = ?, remark = ?, active = ?, updater = ?, update_date = date('now')
        WHERE certify_no = ?
        """
        return self.db.execute(
            sql, (emp_id, certify_id, certify_date, certify_type, remark, int(active), updater, certify_no)
        )

    def delete_training_record(self, certify_no: int) -> int:
        sql = "DELETE FROM training_record WHERE certify_no = ?"
        return self.db.execute(sql, (certify_no,))

    def export_training_records(self, export_dir: Path, filename: str = None, only_active: bool = True) -> Path:
        export_dir = Path(export_dir)
        export_dir.mkdir(parents=True, exist_ok=True)
        if not filename:
            filename = f"training_export.csv"
        path = export_dir / filename

        rows = self.list_training_records(only_active=only_active)
        if not rows:
            return path

        headers = [
            "certify_no",
            "emp_id",
            "c_name",
            "dept_code",
            "area",
            "certify_id",
            "certify_name",
            "certify_date",
            "certify_type",
            "remark",
            "active",
        ]
        with path.open("w", newline="", encoding="utf-8-sig") as f:
            writer = csv.DictWriter(f, fieldnames=headers)
            writer.writeheader()
            for r in rows:
                writer.writerow({k: r.get(k, "") for k in headers})
        return path
