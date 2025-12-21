# Python HRMS (PyQt5 + SQLite)

## Overview
桌面版人資與訓練管理，重構自 VB/Access。支援多語(繁中/日/英)、權限控管、CSV 匯出。現行版本：`0.3.1`。

## Features
- 主畫面：語言切換、字級調整、全螢幕；顯示版本與登入帳號。
- 登入/權限：admin/pigo 預設啟用 (密碼 md5(admin123))；按權限控制按鈕可見。
- 功能模組：員工/個資/學歷、證照設定、證照-機台對應、訓練/證照紀錄(新增查重自動改更新)、到期檢核、區域/部門/職務維護、權限管理、訓練報表/匯出。
- 多語：所有子畫面表頭/標籤使用 i18n (zh/ja/en)。
- 資料：SQLite `./data/hrms.db`；scripts/load_sample 可產生示範資料與預設帳號。

## Setup
```bash
pip install -r requirements.txt
python scripts/load_sample.py   # optional: 建立示範 DB 與帳號
python main_screen.py
```

`config.json`
```json
{
  "db_path": "./data/hrms.db",
  "export_path": "./export",
  "default_lang": "ja",
  "version": "0.3.1"
}
```

## Notes
- 訓練/證照紀錄：新增前查重，若重複自動改為更新並提示。
- 證照設定：部門下拉來自部門維護；匯出/報表持續增補。
- 權限：表格顯示勾選，未授權按鈕隱藏。
