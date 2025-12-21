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

    def list_titles(self) -> List[str]:
        sql = "SELECT DISTINCT title FROM basic WHERE title IS NOT NULL AND title <> '' ORDER BY title"
        rows = self.db.fetch_all(sql)
        return [row.get("title", "") for row in rows if row.get("title")]

    def list_shifts(self) -> List[str]:
        sql = "SELECT DISTINCT shift FROM basic WHERE shift IS NOT NULL AND shift <> '' ORDER BY shift"
        rows = self.db.fetch_all(sql)
        return [row.get("shift", "") for row in rows if row.get("shift")]

    # --- Section (Dept) CRUD ---
    def list_all_sections(self) -> List[Dict[str, Any]]:
        sql = "SELECT dept_code, dept_desc, active FROM l_section ORDER BY dept_code"
        return self.db.fetch_all(sql)

    def create_section(self, dept_code: str, dept_desc: str, active: bool) -> int:
        sql = "INSERT OR REPLACE INTO l_section (dept_code, dept_desc, active) VALUES (?, ?, ?)"
        return self.db.execute(sql, (dept_code, dept_desc, int(active)))

    def update_section(self, dept_code: str, dept_desc: str, active: bool) -> int:
        sql = "UPDATE l_section SET dept_desc = ?, active = ? WHERE dept_code = ?"
        return self.db.execute(sql, (dept_desc, int(active), dept_code))

    def delete_section(self, dept_code: str) -> int:
        sql = "DELETE FROM l_section WHERE dept_code = ?"
        return self.db.execute(sql, (dept_code,))

    # --- Area CRUD ---
    def list_all_areas(self) -> List[Dict[str, Any]]:
        sql = "SELECT area, area_desc, active FROM area ORDER BY area"
        return self.db.fetch_all(sql)

    def create_area(self, area: str, area_desc: str, active: bool) -> int:
        sql = "INSERT OR REPLACE INTO area (area, area_desc, active) VALUES (?, ?, ?)"
        return self.db.execute(sql, (area, area_desc, int(active)))

    def update_area(self, area: str, area_desc: str, active: bool) -> int:
        sql = "UPDATE area SET area_desc = ?, active = ? WHERE area = ?"
        return self.db.execute(sql, (area_desc, int(active), area))

    def delete_area(self, area: str) -> int:
        sql = "DELETE FROM area WHERE area = ?"
        return self.db.execute(sql, (area,))

    # --- Job/Function CRUD ---
    def list_all_jobs(self) -> List[Dict[str, Any]]:
        sql = "SELECT l_job, l_job_desc, active FROM l_job ORDER BY l_job"
        return self.db.fetch_all(sql)

    def create_job(self, l_job: str, l_job_desc: str, active: bool) -> int:
        sql = "INSERT OR REPLACE INTO l_job (l_job, l_job_desc, active) VALUES (?, ?, ?)"
        return self.db.execute(sql, (l_job, l_job_desc, int(active)))

    def update_job(self, l_job: str, l_job_desc: str, active: bool) -> int:
        sql = "UPDATE l_job SET l_job_desc = ?, active = ? WHERE l_job = ?"
        return self.db.execute(sql, (l_job_desc, int(active), l_job))

    def delete_job(self, l_job: str) -> int:
        sql = "DELETE FROM l_job WHERE l_job = ?"
        return self.db.execute(sql, (l_job,))

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
               b.last_name,
               b.first_name,
               (COALESCE(b.last_name, '') || COALESCE(b.first_name, '')) AS c_name,
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
        last_name: str,
        first_name: str,
        title: str,
        on_board_date: str,
        shift: str,
        area: str,
        function: str,
        meno: str,
        active: bool,
    ) -> int:
        sql = """
        INSERT INTO basic (emp_id, dept_code, last_name, first_name, title, on_board_date, shift, meno, update_date, function, area, active)
        VALUES (?, ?, ?, ?, ?, ?, ?, ?, date('now'), ?, ?, ?)
        """
        return self.db.execute(
            sql, (emp_id, dept_code, last_name, first_name, title, on_board_date, shift, meno, function, area, int(active))
        )

    def update_basic(
        self,
        emp_id: str,
        dept_code: str,
        last_name: str,
        first_name: str,
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
        SET dept_code = ?, last_name = ?, first_name = ?, title = ?, on_board_date = ?, shift = ?, meno = ?, update_date = date('now'),
            function = ?, area = ?, active = ?
        WHERE emp_id = ?
        """
        return self.db.execute(
            sql, (dept_code, last_name, first_name, title, on_board_date, shift, meno, function, area, int(active), emp_id)
        )

    def delete_basic(self, emp_id: str) -> int:
        sql = "DELETE FROM basic WHERE emp_id = ?"
        return self.db.execute(sql, (emp_id,))
