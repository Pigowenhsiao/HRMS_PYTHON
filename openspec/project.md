# Project Context

## Purpose
Desktop HRMS and training management app in Python/PyQt5 with a local SQLite database. This is a refactor of a legacy VB/Access system, with multi-language UI (Traditional Chinese/English/Japanese), role-based access, CSV exports, and light/dark themes.

## Tech Stack
- Python 3
- PyQt5 desktop UI
- SQLite (sqlite3) at `./data/hrms.db`
- JSON config and i18n (`config.json`, `i18n/strings_*.json`)
- PyInstaller onedir packaging (`HRMS.spec`)

## Project Conventions

### Code Style
- Python: snake_case for functions/variables, CapWords for classes.
- Keep UI text in i18n dictionaries (`self.t`) and avoid hard-coded labels where possible.
- Keep SQL parameterized and data access contained in `dao/` classes.
- Use `pathlib.Path` for filesystem paths and resolve config paths relative to repo.
- For editable screens, prefer table on top and editor section below.
- Main menu uses fixed-size card buttons arranged in fixed grid positions.

### Architecture Patterns
- `HRMS.py` is the entry point; `main_screen.py` coordinates login, permissions, navigation, and module windows.
- UI layer in `ui/` (QDialog/QMainWindow per window) and data access layer in `dao/`.
- `dao/db.py` wraps SQLite connections and returns dict rows for DAOs.
- Config lives in `config.json`; i18n JSON files are shared across screens.
- UI theme/QSS lives in `ui/theme.py` and is applied at app startup.

### Testing Strategy
- No automated tests in repo; rely on manual UI smoke tests and DB spot checks.
- `scripts/load_sample.py` seeds a demo DB for manual testing.

### Git Workflow
- TBD: confirm branching model and commit conventions.

## Domain Context
- Core entities: employees (basic), personal info, education, certifications, certify-to-tool mapping, training records, overdue checks.
- Role-based permissions control which modules/buttons are visible.
- Training record creation deduplicates and updates existing entries when a match is found.

## Important Constraints
- Offline-first with local SQLite as the default storage.
- Preserve legacy VB/Access schema and data mappings.
- Multi-language support is required for UI and exports.
- DB path/export path/version/theme are configured in `config.json`.
- Packaged builds keep the database in `DATA/hrms.db` (not `_internal`).

## External Dependencies
- None (no external APIs); only local SQLite DB and file exports (CSV).
