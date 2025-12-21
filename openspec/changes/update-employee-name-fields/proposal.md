# Change: 員工姓名拆分為姓氏與名字

## Why
現有姓名是單一欄位，無法支援姓/名分開管理與查詢需求，且後續擴充困難。

## What Changes
- **BREAKING**：`basic` 資料表移除 `c_name` 欄位，新增 `last_name` 與 `first_name`。
- 員工基本資料編輯畫面改為「姓氏 / 名字」兩個輸入區。
- 既有資料遷移規則：`c_name` 的第一個字作為姓氏，其餘作為名字。

## Impact
- Affected specs: `specs/employee-basic/spec.md` (新增能力)
- Affected code: `sqlite_schema.sql`, `dao/basic.py`, `ui/basic_window.py`, 報表與訓練紀錄查詢/匯出
- Data migration: 需要一次性資料搬遷（拆分姓名並移除舊欄位）
