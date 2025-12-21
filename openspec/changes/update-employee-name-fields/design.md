## Context
目前 `basic.c_name` 為單一欄位，需求改為姓氏/名字分離並移除舊欄位，避免後續維護困難。

## Goals / Non-Goals
- Goals:
  - 將姓名拆成 `last_name` 與 `first_name`
  - 既有資料可遷移且介面可編輯
- Non-Goals:
  - 不改變其他資料表結構（除非顯示需要）

## Decisions
- Decision: 移除 `c_name`，新增 `last_name` 與 `first_name`
  - Reason: 明確資料模型、避免雙欄位同步風險
- Decision: 遷移規則以第一個字為姓，其餘為名
  - Reason: 符合目前使用者需求，後續可再調整規則

## Risks / Trade-offs
- 風險：姓名顯示需要由「姓+名」組合，若規則不符合實際姓名格式可能需再調整
- 風險：SQLite 移除欄位需重建表格，需小心資料遷移與備份

## Migration Plan
1. 新增 `last_name`、`first_name` 欄位並回填
2. 將 `c_name` 的第一個字存入 `last_name`，其餘存入 `first_name`
3. 更新所有查詢/匯出使用姓名的組合邏輯
4. 以新結構重建 `basic` 表後移除 `c_name`
5. 進行資料驗證（抽樣比對）

## Open Questions
- 姓名拆分規則後續是否需要以空白或特定符號為依據？
