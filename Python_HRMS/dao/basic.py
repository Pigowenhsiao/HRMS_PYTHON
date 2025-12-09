from typing import List, Dict, Any, Optional
from pathlib import Path
from .db import Database


class BasicDAO:
    def __init__(self, db: Database):
        self.db = db

    def list_sections(self) -> List[Dict[str, Any]]:
        sql = "SELECT dept_code, dept_desc FROM l_section WHERE active = 1 ORDER BY dept_code"
        return self.db.fetch_all(sql)

    def list_areas(self) -> List[Dict[str, Any]]:
        sql = "SELECT area, area_desc FROM area WHERE active = 1 ORDER BY area"
        return self.db.fetch_all(sql)

    def list_jobs(self) -> List[Dict[str, Any]]:
        sql = "SELECT l_job, l_job_desc FROM l_job WHERE active = 1 ORDER BY l_job"
        return self.db.fetch_all(sql)

    def list_basic(
        self,
        active_only: bool = True,
        emp_id: Optional[str] = None,
        dept_code: Optional[str] = None,
        area: Optional[str] = None,
        function: Optional[str] = None,
    ) -> List[Dict[str, Any]]:
        sql = """
        SELECT b.emp_id,
               b.dept_code,
               s.dept_desc,
               b.c_name,
               b.title,
               b.on_board_date,
               b.shift,
               b.area,
               b.function,
               j.l_job_desc,
               b.meno,
               b.active
        FROM basic b
        LEFT JOIN l_section s ON b.dept_code = s.dept_code
        LEFT JOIN l_job j ON b.function = j.l_job
        WHERE 1=1
        """
        params = []
        if active_only:
            sql += " AND b.active = 1"
        if emp_id:
            sql += " AND b.emp_id = ?"
            params.append(emp_id.strip())
        if dept_code:
            sql += " AND b.dept_code = ?"
            params.append(dept_code.strip())
        if area:
            sql += " AND b.area = ?"
            params.append(area.strip())
        if function:
            sql += " AND b.function = ?"
            params.append(function.strip())

        sql += " ORDER BY b.emp_id"
        return self.db.fetch_all(sql, params)

    def create_basic(
        self,
        emp_id: str,
        dept_code: str,
        c_name: str,
        title: str,
        on_board_date: str,
        shift: str,
        area: str,
        function: str,
        meno: str,
        active: bool,
    ) -> int:
        sql = """
        INSERT INTO basic (emp_id, dept_code, c_name, title, on_board_date, shift, meno, update_date, function, area, active)
        VALUES (?, ?, ?, ?, ?, ?, ?, date('now'), ?, ?, ?)
        """
        return self.db.execute(sql, (emp_id, dept_code, c_name, title, on_board_date, shift, meno, function, area, int(active)))

    def update_basic(
        self,
        emp_id: str,
        dept_code: str,
        c_name: str,
        title: str,
        on_board_date: str,
        shift: str,
        area: str,
        function: str,
        meno: str,
        active: bool,
    ) -> int:
        sql = """
        UPDATE basic
        SET dept_code = ?, c_name = ?, title = ?, on_board_date = ?, shift = ?, meno = ?, update_date = date('now'),
            function = ?, area = ?, active = ?
        WHERE emp_id = ?
        """
        return self.db.execute(sql, (dept_code, c_name, title, on_board_date, shift, meno, function, area, int(active), emp_id))

    def delete_basic(self, emp_id: str) -> int:
        sql = "DELETE FROM basic WHERE emp_id = ?"
        return self.db.execute(sql, (emp_id,))
