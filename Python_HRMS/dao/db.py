import sqlite3
from pathlib import Path
from typing import Iterable, Tuple, Any, List, Dict


class Database:
    def __init__(self, db_path: Path):
        self.db_path = Path(db_path).expanduser().resolve()
        # 確保資料夾存在
        self.db_path.parent.mkdir(parents=True, exist_ok=True)

    def connect(self):
        con = sqlite3.connect(self.db_path)
        con.row_factory = sqlite3.Row
        return con

    def fetch_all(self, sql: str, params: Iterable = ()):
        with self.connect() as con:
            cur = con.execute(sql, params)
            return [dict(row) for row in cur.fetchall()]

    def fetch_one(self, sql: str, params: Iterable = ()):
        with self.connect() as con:
            cur = con.execute(sql, params)
            row = cur.fetchone()
            return dict(row) if row else None

    def execute(self, sql: str, params: Iterable = ()) -> int:
        """執行 INSERT/UPDATE/DELETE，回傳變更筆數"""
        with self.connect() as con:
            cur = con.execute(sql, params)
            con.commit()
            return cur.rowcount

    def executemany(self, sql: str, params_seq: Iterable[Iterable]) -> int:
        with self.connect() as con:
            cur = con.executemany(sql, params_seq)
            con.commit()
            return cur.rowcount
