## 1. Implementation
- [ ] 1.1 Add database path controls, apply handler, and create button in ui/authority_window.py
- [ ] 1.2 Persist db_path and prompt for restart (no live DB/DAO switch) in main_screen.py
- [ ] 1.3 Implement new database creation with default HRMS_Database.db and no overwrite
- [ ] 1.4 Add SQLite busy timeout and WAL attempt in dao/db.py
- [ ] 1.5 Add i18n strings for new labels, prompts, and errors
- [ ] 1.6 Verify manual flow: apply existing path, missing path error, create new DB, existing file error, restart loads new DB
