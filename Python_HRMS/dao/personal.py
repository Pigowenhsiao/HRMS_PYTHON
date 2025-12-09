from typing import List, Dict, Any
from .db import Database


class PersonalDAO:
    def __init__(self, db: Database):
        self.db = db

    def list_emp_ids(self, active_only: bool = True) -> List[str]:
        sql = "SELECT emp_id FROM basic"
        params = []
        if active_only:
            sql += " WHERE active = 1"
        sql += " ORDER BY emp_id"
        rows = self.db.fetch_all(sql, params)
        return [r["emp_id"] for r in rows]

    def get_person_info(self, emp_id: str) -> Dict[str, Any]:
        sql = "SELECT * FROM person_info WHERE emp_id = ?"
        row = self.db.fetch_one(sql, (emp_id,))
        return row or {}

    def ensure_person_info(self, emp_id: str):
        """若無此員工的 person_info，插入空白列"""
        sql = "INSERT OR IGNORE INTO person_info (emp_id, active) VALUES (?, 1)"
        self.db.execute(sql, (emp_id,))

    def update_person_info(
        self,
        emp_id: str,
        sex: str,
        birthday: str,
        personal_id: str,
        home_phone: str,
        current_phone: str,
        cell_phone: str,
        living_place: str,
        living_place2: str,
        emg_name1: str,
        emg_phone1: str,
        emg_releasion1: str,
        emg_name2: str,
        emg_phone2: str,
        emg_releasion2: str,
        perf_year: str,
        excomp_year: str,
        ex_compy_type: str,
        meno: str,
        active: bool,
        updater: str = "",
    ) -> int:
        self.ensure_person_info(emp_id)
        sql = """
        UPDATE person_info
        SET sex = ?, birthday = ?, personal_id = ?, home_phone = ?, current_phone = ?, cell_phone = ?,
            living_place = ?, living_place2 = ?, emg_name1 = ?, emg_phone1 = ?, emg_releasion1 = ?,
            emg_name2 = ?, emg_phone2 = ?, emg_releasion2 = ?, perf_year = ?, excomp_year = ?, ex_compy_type = ?,
            meno = ?, updater = ?, updater_date = date('now'), active = ?
        WHERE emp_id = ?
        """
        return self.db.execute(
            sql,
            (
                sex,
                birthday,
                personal_id,
                home_phone,
                current_phone,
                cell_phone,
                living_place,
                living_place2,
                emg_name1,
                emg_phone1,
                emg_releasion1,
                emg_name2,
                emg_phone2,
                emg_releasion2,
                perf_year,
                excomp_year,
                ex_compy_type,
                meno,
                updater,
                int(active),
                emp_id,
            ),
        )
