PRAGMA foreign_keys = ON;

-- 系統版本
CREATE TABLE IF NOT EXISTS software (
    s_ver       TEXT PRIMARY KEY,
    active      INTEGER DEFAULT 1,
    updated_at  TEXT
);

-- 權限帳號
CREATE TABLE IF NOT EXISTS authority (
    s_account   TEXT PRIMARY KEY,
    password    TEXT, -- 可存雜湊，預設 admin 用於開發
    active      INTEGER DEFAULT 1,
    update_date TEXT
);
INSERT OR IGNORE INTO authority (s_account, password, active, update_date)
VALUES ('admin', 'admin123', 1, date('now'));

-- 區域/部門/職務字典
CREATE TABLE IF NOT EXISTS area (
    area        TEXT PRIMARY KEY,
    area_desc   TEXT,
    active      INTEGER DEFAULT 1
);

CREATE TABLE IF NOT EXISTS l_section (
    dept_code   TEXT PRIMARY KEY,
    dept_desc   TEXT,
    active      INTEGER DEFAULT 1
);

CREATE TABLE IF NOT EXISTS l_job (
    l_job       TEXT PRIMARY KEY,
    l_job_desc  TEXT,
    active      INTEGER DEFAULT 1
);

-- 員工基本資料（Basic）
CREATE TABLE IF NOT EXISTS basic (
    emp_id        TEXT PRIMARY KEY,
    dept_code     TEXT REFERENCES l_section(dept_code),
    c_name        TEXT,
    title         TEXT,
    on_board_date TEXT,
    shift         TEXT,
    meno          TEXT,
    update_date   TEXT,
    function      TEXT REFERENCES l_job(l_job),
    area          TEXT REFERENCES area(area),
    active        INTEGER DEFAULT 1
);
CREATE INDEX IF NOT EXISTS idx_basic_dept ON basic(dept_code);
CREATE INDEX IF NOT EXISTS idx_basic_area ON basic(area);
CREATE INDEX IF NOT EXISTS idx_basic_active ON basic(active);

-- 個人資訊（Person_Info）
CREATE TABLE IF NOT EXISTS person_info (
    emp_id           TEXT PRIMARY KEY REFERENCES basic(emp_id) ON DELETE CASCADE,
    sex              TEXT,
    birthday         TEXT,
    personal_id      TEXT,
    home_phone       TEXT,
    current_phone    TEXT,
    cell_phone       TEXT,
    living_place     TEXT,
    living_place2    TEXT,
    emg_name1        TEXT,
    emg_phone1       TEXT,
    emg_releasion1   TEXT,
    emg_name2        TEXT,
    emg_phone2       TEXT,
    emg_releasion2   TEXT,
    perf_year        INTEGER,
    excomp_year      INTEGER,
    ex_compy_type    TEXT,
    meno             TEXT,
    updater          TEXT,
    updater_date     TEXT,
    active           INTEGER DEFAULT 1
);

-- 學歷（TE_EDU）
CREATE TABLE IF NOT EXISTS te_edu (
    emp_id    TEXT PRIMARY KEY REFERENCES basic(emp_id) ON DELETE CASCADE,
    education TEXT,
    g_school  TEXT,
    major     TEXT
);

-- 證照項目（Certify_items）
CREATE TABLE IF NOT EXISTS certify_items (
    certify_id    TEXT PRIMARY KEY,
    dept          TEXT,
    certify_name  TEXT,
    certify_time  TEXT,
    certify_grade TEXT,
    certify_type  TEXT,
    remark        TEXT,
    active        INTEGER DEFAULT 1
);
CREATE INDEX IF NOT EXISTS idx_certify_items_active ON certify_items(active);

-- 證照對應機台（Certify_Tool_Map）
CREATE TABLE IF NOT EXISTS certify_tool_map (
    certify_id   TEXT REFERENCES certify_items(certify_id) ON DELETE CASCADE,
    tool_id      TEXT,
    update_date  TEXT,
    remark       TEXT,
    active       INTEGER DEFAULT 1,
    PRIMARY KEY (certify_id, tool_id)
);
CREATE INDEX IF NOT EXISTS idx_ctm_active ON certify_tool_map(active);

-- 訓練/證照紀錄（Training_Record）
CREATE TABLE IF NOT EXISTS training_record (
    certify_no    INTEGER PRIMARY KEY,
    emp_id        TEXT REFERENCES basic(emp_id) ON DELETE CASCADE,
    certify_id    TEXT REFERENCES certify_items(certify_id),
    certify_date  TEXT,
    certify_type  TEXT,
    update_date   TEXT,
    remark        TEXT,
    active        INTEGER DEFAULT 1,
    updater       TEXT
);
CREATE INDEX IF NOT EXISTS idx_tr_emp ON training_record(emp_id);
CREATE INDEX IF NOT EXISTS idx_tr_certify ON training_record(certify_id);
CREATE INDEX IF NOT EXISTS idx_tr_active ON training_record(active);
CREATE INDEX IF NOT EXISTS idx_tr_date ON training_record(certify_date);

-- 證照類型（Certify_type）
CREATE TABLE IF NOT EXISTS certify_type (
    certify_type TEXT PRIMARY KEY,
    remark       TEXT,
    active       INTEGER DEFAULT 1
);
