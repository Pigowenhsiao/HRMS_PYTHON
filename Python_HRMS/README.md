# Python HRMS (PyQt5 + SQLite)

## 簡介
以 PyQt5 + SQLite 重建 HRMS，支援多語（繁中/英文/日文），並提供少量樣本資料驗證。v0.1.0 目前包含：
- 主畫面與語言切換
- SQLite schema（authority/software/basic/person_info/te_edu/certify_items/certify_tool_map/training_record/certify_type 等）
- 匯入 10 筆內的驗證資料腳本

## 環境需求
- Python 3.9+（含內建 sqlite3）
- 依賴套件：見 `requirements.txt`

安裝依賴：
```bash
pip install -r requirements.txt
```

## 設定檔
`config.json`
```json
{
  "db_path": "./data/hrms.db",
  "export_path": "./export",
  "default_lang": "zh",
  "version": "0.1.0"
}
```
可依環境修改路徑與預設語系。

## 多語資源
- `i18n/strings_zh.json`
- `i18n/strings_en.json`
- `i18n/strings_ja.json`
主畫面語言切換會讀取上述檔案。

## 初始化資料庫（載入少量樣本）
```bash
python scripts/load_sample.py
```
會建立 `data/hrms.db`，插入 admin/admin123 預設帳號、版本 0.1.0 及少量測試資料（每表 ≤10 筆）。

## 執行主畫面
```bash
python main_screen.py
```
可切換繁中/英文/日文，驗證 UI 文字更新。

## 下一步（建議）
- 建立 DAO/Service 層封裝 CRUD 與權限/版本檢查。
- 為員工/個資/學歷、權限、證照設定/紀錄等模組增加視窗並綁定資料。
- 匯出 CSV 與報表多語。

## 注意
- 預設 admin 密碼僅供開發，正式環境請改為雜湊並強制修改。
- 匯出路徑/DB 路徑請依實際環境調整。
