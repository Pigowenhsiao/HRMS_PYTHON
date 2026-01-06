# HRMS (PyQt5 + SQLite)

## Overview
桌面版人資與訓練管理，重構自 VB/Access。支援多語(繁中/日/英)、權限控管、CSV 匯出與主題切換。現行版本：`0.3.3`。

## Features
- 主畫面：語言切換、字級調整、明亮/黑暗主題、全螢幕；顯示版本、登入帳號與 DB 路徑。
- 登入/權限：登入畫面支援語言切換；admin/pigo 預設啟用 (密碼 md5(admin123))；按權限控制按鈕可見。
- 功能模組：員工/個資/學歷、證照設定、證照-機台對應、訓練/證照紀錄(新增查重自動改更新)、到期檢核、區域/部門/職務維護、權限管理、訓練報表/匯出。
- 資料庫路徑：權限管理可設定 DB 路徑與建立新 DB（預設 `HRMS_Database.db`），更新後需重啟生效。
- 多語：所有子畫面表頭/標籤使用 i18n (zh/ja/en)。
- 資料：SQLite `./data/hrms.db`；scripts/load_sample 可產生示範資料與預設帳號。
- 導航：左側分類導航，依權限顯示可用模組。

## Setup
```bash
pip install -r requirements.txt
python scripts/load_sample.py   # optional: 建立示範 DB 與帳號
python HRMS.py
```

`config.json`
```json
{
  "db_path": "./data/hrms.db",
  "export_path": "./export",
  "default_lang": "ja",
  "version": "0.3.3",
  "app_name": "HRMS",
  "theme": "light"
}
```

## Packaging (onedir)
```bash
pyinstaller HRMS.spec
```
輸出位置：`dist/HRMS/HRMS.exe`  
資料庫放置：`dist/HRMS/DATA/hrms.db`

## Notes
- 訓練/證照紀錄：新增前查重，若重複自動改為更新並提示。
- 證照設定：部門下拉來自部門維護；匯出/報表持續增補。
- 權限：表格顯示勾選，未授權按鈕隱藏。
