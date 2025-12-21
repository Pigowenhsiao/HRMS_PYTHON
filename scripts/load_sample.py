import sqlite3
import datetime
import hashlib
from pathlib import Path

DB_PATH = Path(__file__).resolve().parent.parent / "data" / "hrms.db"

sample_dept = [
    ("D001", "製造部"),
    ("D002", "品保部"),
]

sample_area = [("A1", "台北"), ("A2", "新竹")]

sample_job = [("FUN01", "工程"), ("FUN02", "測試")]

sample_basic = [
    ("000001", "D001", "王", "小明", "工程師", "2024-01-02", "A", "樣本", "FUN01", "A1", 1),
    ("000002", "D002", "林", "小華", "技術員", "2023-12-15", "B", "樣本", "FUN02", "A2", 1),
]

sample_person = [
    ("000001", "M", "1990-05-05", "A123456789", "02-12345678", "02-87654321", "0912-345678", "台北", "台北備用", "王爸", "02-12345678", "父", "王媽", "02-12345679", "母", 5, 2, "製造", "樣本", "admin", 1),
    ("000002", "F", "1992-08-08", "B123456789", "03-12345678", "03-87654321", "0912-876543", "新竹", "新竹備用", "林爸", "03-12345678", "父", "林媽", "03-12345679", "母", 3, 1, "製造", "樣本", "admin", 1),
]

sample_edu = [
    ("000001", "Bachelor", "NTU", "EE"),
    ("000002", "Bachelor", "NTHU", "CS"),
]

sample_certify_items = [
    ("C001", "A1", "安全訓練", "2h", "A", "TYPE1", "樣本", 1),
    ("C002", "A2", "機台操作", "3h", "B", "TYPE2", "樣本", 1),
]

sample_certify_type = [("TYPE1", "安全" ,1), ("TYPE2", "設備",1)]

sample_ctm = [
    ("C001", "T001", "樣本", 1),
    ("C002", "T002", "樣本", 1),
]

sample_training = [
    (1, "000001", "C001", "2024-02-01", "TYPE1", "樣本", 1, "admin"),
    (2, "000002", "C002", "2024-03-01", "TYPE2", "樣本", 1, "admin"),
]

def main():
    DB_PATH.parent.mkdir(parents=True, exist_ok=True)
    con = sqlite3.connect(DB_PATH)
    cur = con.cursor()
    now = datetime.date.today().isoformat()
    admin_hash = hashlib.md5("admin123".encode()).hexdigest()

    # create tables from schema
    schema = (Path(__file__).resolve().parent.parent / "sqlite_schema.sql").read_text(encoding="utf-8")
    cur.executescript(schema)

    cur.execute(
        """
        INSERT OR IGNORE INTO authority
        (s_account, password_hash, active,
         perm_basic, perm_personal, perm_education, perm_certify_items, perm_certify_tool,
         perm_training_record, perm_overdue, perm_authority, perm_export, perm_area, perm_section, perm_job,
         perm_report_training, perm_custom_export, update_date)
        VALUES ('admin', ?, 1, 1,1,1,1,1,1,1,1,1,1,1,1,1,1, ?)
        """,
        (admin_hash, now),
    )
    cur.execute("INSERT OR IGNORE INTO software (s_ver, active, updated_at) VALUES ('0.3.0',1,?)", (now,))

    cur.executemany("INSERT OR IGNORE INTO l_section (dept_code, dept_desc, active) VALUES (?,?,1)", sample_dept)
    cur.executemany("INSERT OR IGNORE INTO area (area, area_desc, active) VALUES (?,?,1)", sample_area)
    cur.executemany("INSERT OR IGNORE INTO l_job (l_job, l_job_desc, active) VALUES (?,?,1)", sample_job)

    cur.executemany(
        "INSERT OR IGNORE INTO basic (emp_id, dept_code, last_name, first_name, title, on_board_date, shift, meno, update_date, function, area, active) VALUES (?,?,?,?,?,?,?,?,?,?,?,?)",
        [(e, d, ln, fn, t, ob, sh, m, now, f, a, act) for e, d, ln, fn, t, ob, sh, m, f, a, act in sample_basic],
    )

    cur.executemany(
        "INSERT OR IGNORE INTO person_info (emp_id, sex, birthday, personal_id, home_phone, current_phone, cell_phone, living_place, living_place2, emg_name1, emg_phone1, emg_releasion1, emg_name2, emg_phone2, emg_releasion2, perf_year, excomp_year, ex_compy_type, meno, updater, updater_date, active) VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)",
        [(e, s, b, pid, hp, cp, cell, lp1, lp2, n1, p1, r1, n2, p2, r2, perf, exy, extype, memo, upd, now, act) for e,s,b,pid,hp,cp,cell,lp1,lp2,n1,p1,r1,n2,p2,r2,perf,exy,extype,memo,upd,act in sample_person],
    )

    cur.executemany("INSERT OR IGNORE INTO te_edu (emp_id, education, g_school, major) VALUES (?,?,?,?)", sample_edu)

    cur.executemany(
        "INSERT OR IGNORE INTO certify_items (certify_id, dept, certify_name, certify_time, certify_grade, certify_type, remark, active) VALUES (?,?,?,?,?,?,?,?)",
        sample_certify_items,
    )
    cur.executemany(
        "INSERT OR IGNORE INTO certify_type (certify_type, remark, active) VALUES (?,?,?)",
        sample_certify_type,
    )
    cur.executemany(
        "INSERT OR IGNORE INTO certify_tool_map (certify_id, tool_id, update_date, remark, active) VALUES (?,?,?,?,?)",
        [(cid, tid, now, remark, act) for cid, tid, remark, act in sample_ctm],
    )
    cur.executemany(
        "INSERT OR IGNORE INTO training_record (certify_no, emp_id, certify_id, certify_date, certify_type, update_date, remark, active, updater) VALUES (?,?,?,?,?,?,?,?,?)",
        [(no, emp, cid, cdate, ctype, now, remark, act, upd) for no, emp, cid, cdate, ctype, remark, act, upd in sample_training],
    )

    con.commit()
    con.close()
    print(f"Initialized DB at {DB_PATH} with sample data (<=10 rows per table)")

if __name__ == "__main__":
    main()
