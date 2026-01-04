# Change: Refactor CRUD Windows to Shared Base

## Why
Reduce duplicated CRUD code in maintenance windows and keep behavior consistent across modules.

## What Changes
- Add a shared CRUD base class for area/section/job maintenance windows.
- Move common UI helpers to shared utilities.
- Update maintenance windows to inherit the base class and use shared helpers.
- Update @func.md to reflect new shared functions and removed duplicates.

## Impact
- Affected specs: app-shell
- Affected code: ui/area_window.py, ui/section_window.py, ui/job_window.py, ui/window_utils.py, new ui/crud_base.py, @func.md
