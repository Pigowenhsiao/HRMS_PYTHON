# HRMS 專案說明

## 系統概覽
- Windows Forms（VB.NET 3.5）人資/訓練管理工具，涵蓋員工基本資料、個人資訊、學歷、證照設定與紀錄、權限控管與報表。
- 資料庫：Access `HRMS.mdb`（Jet 4.0 連線字串寫死為 `\\sslproj01\00_tps\HRMS\HRMS.mdb`，常數 `mydata`），並附舊版 `HRMS_20140816160458.mdb` 備份及 `Certify_import.xls` 匯入模版。
- 啟動物件 `HRMS.My.MyApplication`，主視窗為 `TE_Start_Page`，透過按鈕開啟各模組。
- 版本控管：常數 `version = "0.032"`，啟動時查詢資料表 `software` 取 `S_VER`，不符即提示下載並關閉。
- 權限：以目前登入帳號（`Environment.UserName`）查詢 `Authority` 表，未授權時隱藏管理按鈕（權限、組織、基礎資料、證照設定/對應、MES 匯出）。

## 公用資料層（Module1.vb）
- `mDB_Exist`/`mDB_Link`：檢查資料庫檔案是否存在並以 Jet 4.0 開啟連線。
- `executeSQL`、`DATA_ReadF`、`DATA_ReadS`、`Item_Update`：提供非查詢、DataSet 查詢、單欄讀取與 ComboBox 資料填充的共用方法，使用全域連線與簡易例外處理 `ABNormal()`。
- `Export_CVS`：依 SQL 將訓練/證照資料匯出 CSV；選項 1 輸出到 `\\tsmcssl.com\cim\Upload\TE_Certification_Upload\Certify_data_<秒>.CSV`，選項 2 輸出到 `D:\Certify_data_<秒>.CSV`（啟動頁的「MES UPDATE」使用）。

## 主要功能模組
- **首頁導航 `TE_Start_Page`**：載入時檢查資料庫/版本/權限；各按鈕開啟對應功能。`BT_MESUPDATE` 匯出所有訓練資料給 MES。
- **權限管理 `Authority_Control`**：維護 `Authority` 表的帳號啟用狀態，提供新增/啟用/停用，僅授權用戶可見。
- **組織與主檔維護**：
  - `TE_Area_desc`（Area 區域）、`TE_Shop_desc`（Shop 廠區/課別）、`TE_Section_Desc`（L_Section 部門）、`TE_Job_desc`（L_Job 職務）。
  - 皆提供查詢、建立、修改、刪除，更新 `Active` 旗標並即時刷新 DataGridView。
- **員工基本資料 `TE_BASIC`**：
  - 維護 `Basic` 表（員工編號、部門、姓名、職稱、到職日、班別、區域、Function、備註、Active 等）。
  - 建立時會同步在 `Person_Info` 插入空資料列；提供依員工/部門/職稱/區域/Function 篩選以及停用清單。
- **個人資訊 `TE_Personal_INFO` / 彙總檢視 `TE_Personal_Data`**：
  - `TE_Personal_INFO` 以員工下拉載入 `Person_Info` 詳細欄位（性別、生日、身分證、聯絡方式、緊急聯絡人、年資、備註、Active），若查無資料會自動插入空白列再讓使用者更新。
  - `TE_Personal_Data` 提供所有 Active 員工的個資彙總唯讀清單。
- **學歷檢視 `TE_Education`**：
  - 讀取 `TE_EDU` 與 `Basic`，顯示學歷/畢業學校/科系，並可依學歷、學校、科系篩選。
- **證照設定 `CF_Certify__EXAM`**：
  - 維護 `Certify_items`（部門/區域、證照代碼、名稱、訓練時數、等級、類型、備註、Active），下拉來源為 `Area` 與 `Certify_type`。
- **證照與機台對應 `CF_Certify_Tool_Map`**：
  - 維護 `Certify_Tool_Map`，將證照與 `Tool_ID` 綁定並紀錄備註/啟用狀態，支援以證照或 Tool ID 查詢。
- **訓練/證照紀錄 `CF_Certify_Record`**：
  - 讀取 `Basic`、`Training_Record`、`Certify_items`，顯示員工部門/區域、證照、日期、等級、類型、啟用、Remark、`Certify_No`，並計算距今天數。
  - 依員工或證照查詢；新增時自動取得最大 `Certify_No+1`，修改會更新啟用與備註；兩者皆呼叫 `Export_CVS(選項1)` 同步單筆資料到 MES。
  - 非授權用戶隱藏新增/修改按鈕。
- **證照到期檢核 `CF_Check_OverDue`**：
  - 以 `Training_Record` + `Certify_items` + `Basic` 計算 `int(now - certify_date)`，預設列出全部 Active 紀錄，可輸入天數門檻（預設 660）過濾即將/已到期項目。
- **報表 `CF_Report`**：
  - 依選取部門（`L_Section`）篩出訓練紀錄，同樣輸出距今天數，供列印或檢視；另可依天數門檻過濾。
- **水晶報表樣板**：`TEST1.rpt` 與 `TEST1.vb`，可作為 Crystal Reports 範例或額外報表。

## 執行與部署
1. 需安裝 .NET Framework 3.5 與 Microsoft Jet OLE DB 4.0（32 位元）提供者。
2. 確保可存取資料庫路徑 `\\sslproj01\00_tps\HRMS\HRMS.mdb`；若路徑不同需修改 `Module1.mydata` 常數。
3. 在 Visual Studio 2008/2010 開啟 `HRMS.sln`、還原參考後建置並執行。
4. 若要啟用 CSV 上傳 MES，需具備 `\\tsmcssl.com\cim\Upload\TE_Certification_Upload` 寫入權限；若無則會寫入本機 `D:\Certify_data_*.CSV`。

## 注意事項與風險
- SQL 以字串串接，未做輸入驗證，存在注入與資料格式錯誤風險；日期/布林欄位倚賴字串格式與 Jet 解析。
- 連線/查詢錯誤僅彈出 `MsgBox` 並重用全域連線，未釋放 Reader/Command 可能造成潛在連線耗盡。
- `Option Strict Off` 及大量未檢查的 `On Error GoTo` 會掩蓋型別或執行期錯誤。
- 匯出/版本檢查/資料庫路徑皆為寫死的網路分享，環境變更需同步調整。
