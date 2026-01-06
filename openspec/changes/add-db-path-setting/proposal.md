# Change: Add database path setting in Authority Management

## Why
Users need to point multiple machines to the same SQLite database via network paths and switch the active database with a controlled restart.

## What Changes
- Add a database path setting UI in the Authority Management screen with apply/browse and create actions.
- Persist the selected path to config.json and prompt for restart so the new database loads after restarting.
- Provide a create database flow that uses the default filename `HRMS_Database.db` and never overwrites existing files.
- Show the active database path and filename in the main status bar.
- Configure SQLite connections with a busy timeout and attempt WAL mode to reduce write contention.
- Add i18n strings for the new UI and messages.

## Impact
- Affected specs: app-shell
- Affected code: ui/authority_window.py, main_screen.py, dao/db.py, config.json, i18n/strings_*.json, sqlite_schema.sql
