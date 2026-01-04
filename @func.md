# Function Index (HRMS_PYTHON)

## HRMS.py
- main: Create the QApplication, open MainScreen, and start the event loop.

## main_screen.py
- _get_base_dir: Resolve base directory for frozen or source execution.
- _read_json: Load JSON from disk using UTF-8-SIG.
- load_config: Merge default config with config.json and normalize paths.
- save_config: Persist config.json with pretty formatting.
- _normalize_config_paths: Adjust db_path when packaged DATA/hrms.db exists.
- _migrate_basic_name_schema: Migrate legacy basic table name columns if needed.
- load_i18n: Load translation file for a language code.
- MainScreen.__init__: Initialize app state, DAOs, theme, UI, and login flow.
- MainScreen._init_ui: Build main layout, navigation, sections, and status bar.
- MainScreen._create_card_button: Create a card-style button and register it.
- MainScreen._login_and_apply_permissions: Run login dialog and apply perms.
- MainScreen.get_db_path: Return the current database path as a string.
- MainScreen._resolve_db_path: Resolve absolute or base-dir relative DB path.
- MainScreen._load_schema_sql: Load schema SQL and optionally drop authority seed.
- MainScreen._create_database_with_schema: Create DB schema and copy authority rows.
- MainScreen._reload_permissions_from_db: Refresh permissions for current user.
- MainScreen.switch_database: Switch to a new database path with optional create.
- MainScreen._section_employee: Build employee section button grid.
- MainScreen._section_certify: Build certify section button grid.
- MainScreen._section_admin: Build admin section button grid.
- MainScreen._section_reports: Build reports section button grid.
- MainScreen._on_lang_change: Switch UI language from combo selection.
- MainScreen._apply_translation: Apply translation text to all UI labels.
- MainScreen.open_certify_items: Open certify items dialog.
- MainScreen.open_certify_tool_map: Open certify-tool mapping dialog.
- MainScreen.open_training_records: Open training record dialog.
- MainScreen.export_training_csv: Export training records CSV and notify user.
- MainScreen.open_basic_window: Open employee basic data dialog.
- MainScreen.open_personal_window: Open personal info dialog.
- MainScreen.open_education_window: Open education dialog.
- MainScreen.open_overdue_window: Open overdue dialog.
- MainScreen.open_authority_window: Open authority dialog.
- MainScreen.open_training_report: Open training report dialog.
- MainScreen.open_custom_export: Open custom export dialog.
- MainScreen.open_area_window: Open area maintenance dialog.
- MainScreen.open_section_window: Open section maintenance dialog.
- MainScreen.open_job_window: Open job/function maintenance dialog.
- MainScreen._apply_font_sizes: Apply font sizes across UI elements.
- MainScreen.increase_font: Increase base font size within bounds.
- MainScreen.decrease_font: Decrease base font size within bounds.
- MainScreen.toggle_full_screen: Toggle fullscreen mode.
- MainScreen._update_theme_button: Update theme toggle label text.
- MainScreen.toggle_theme: Switch theme and save to config.
- MainScreen.toggle_nav: Toggle nav collapsed state.
- MainScreen._apply_nav_texts: Update nav text labels per translation.
- MainScreen._set_nav_collapsed: Apply collapsed/expanded nav layout.
- MainScreen._update_status_labels: Refresh status bar labels.
- MainScreen._set_language_from_login: Apply language change and save config.
- MainScreen._apply_permissions: Show or hide buttons based on perms.
- MainScreen._set_nav_index: Switch stacked page index.
- MainScreen._update_nav_visibility: Show or hide nav sections by perms.

## ui/window_utils.py
- apply_window_controls: Add minimize/maximize/close flags and style hints.
- set_default_window_state: Apply window controls and start maximized.
- center_table_columns: Center text in selected table columns.
- set_combo_if_exists: Set combo box selection or fallback to text input.
- get_combo_value: Read combo box data with text fallback.
- label_text: Resolve translated label text with default fallback.

## ui/crud_base.py
- CrudBaseWindow.__init__: Initialize CRUD base window config and load data.
- CrudBaseWindow._t: Resolve translation text with default fallback.
- CrudBaseWindow._init_ui: Build table, form, and CRUD buttons.
- CrudBaseWindow._get_text_value: Read trimmed text value from a field widget.
- CrudBaseWindow._get_checkbox_value: Read checkbox state for active flag.
- CrudBaseWindow._get_key_value: Read key field value for CRUD actions.
- CrudBaseWindow._warn_required: Show required-field warning per action.
- CrudBaseWindow.load_data: Populate table rows from DAO list method.
- CrudBaseWindow.on_row_selected: Load selected row into form fields.
- CrudBaseWindow.create_record: Validate and create record via DAO.
- CrudBaseWindow.update_record: Validate and update record via DAO.
- CrudBaseWindow.delete_record: Validate and delete record via DAO.

## ui/theme.py
- _build_stylesheet: Build Qt stylesheet string from theme colors.
- apply_theme: Apply stylesheet to app and return resolved theme key.

## ui/login_dialog.py
- LoginDialog.__init__: Initialize login dialog state and UI.
- LoginDialog._init_ui: Build login form layout and widgets.
- LoginDialog._apply_translation: Apply translated labels and button text.
- LoginDialog._on_lang_change: Load new language and notify parent.
- LoginDialog.try_login: Validate credentials and set permissions.

## ui/basic_window.py
- PopupDateEdit.__init__: Initialize date editor with popup calendar.
- PopupDateEdit.mousePressEvent: Toggle calendar popup on click.
- PopupDateEdit._on_date_selected: Set selected date and close popup.
- BasicWindow.__init__: Initialize basic data window and load data.
- BasicWindow._init_ui: Build filters, table, form, and action buttons.
- BasicWindow._apply_headers: Apply translated column headers.
- BasicWindow.load_filters: Load filter and form combo values.
- BasicWindow.load_data: Query and display basic employee data.
- BasicWindow.on_row_selected: Populate form from selected row.
- BasicWindow._collect_form: Collect form values into dict for DAO calls.
- BasicWindow.create_record: Validate and create basic employee record.
- BasicWindow.update_record: Validate and update basic employee record.
- BasicWindow.delete_record: Validate and delete basic employee record.

## ui/personal_window.py
- PersonalWindow.__init__: Initialize personal info window and load data.
- PersonalWindow._init_ui: Build filters, table, form, and save button.
- PersonalWindow.load_data: Query and display personal info rows.
- PersonalWindow.on_row_selected: Populate form from selected row.
- PersonalWindow._load_emp_ids: Load employee IDs into combo.
- PersonalWindow.save_info: Validate and update personal info.

## ui/education_window.py
- EducationWindow.__init__: Initialize education window and load data.
- EducationWindow._init_ui: Build filters, table, form, and update button.
- EducationWindow._apply_headers: Apply translated column headers.
- EducationWindow.load_filters: Load distinct education/school/major filters.
- EducationWindow._load_emp_ids: Load employee IDs into combo.
- EducationWindow.on_row_selected: Populate form from selected row.
- EducationWindow.load_data: Query and display education records.
- EducationWindow.update_record: Validate and upsert education record.

## ui/area_window.py
- AreaWindow.__init__: Initialize area maintenance window and load data.

## ui/section_window.py
- SectionWindow.__init__: Initialize section maintenance window and load data.

## ui/job_window.py
- JobWindow.__init__: Initialize job maintenance window and load data.

## ui/certify_items_window.py
- CertifyItemsWindow.__init__: Initialize certify items window and load data.
- CertifyItemsWindow._init_ui: Build filters, table, form, and action buttons.
- CertifyItemsWindow._load_depts: Load dept, grade, and type combo options.
- CertifyItemsWindow.load_data: Query and display certify items.
- CertifyItemsWindow.on_row_selected: Populate form from selected row.
- CertifyItemsWindow._get_dept_value: Resolve dept value and handle ALL label.
- CertifyItemsWindow.create_item: Validate and create certify item.
- CertifyItemsWindow.update_item: Validate and update certify item.
- CertifyItemsWindow._collect_form: Collect form values into dict for DAO calls.

## ui/certify_tool_map_window.py
- CertifyToolMapWindow.__init__: Initialize tool map window and load data.
- CertifyToolMapWindow._init_ui: Build filters, table, form, and action buttons.
- CertifyToolMapWindow._load_certify_ids: Load certify IDs into combo.
- CertifyToolMapWindow.load_data: Query and display certify-tool mappings.
- CertifyToolMapWindow.on_row_selected: Populate form from selected row.
- CertifyToolMapWindow._collect_form: Collect form values into dict for DAO calls.
- CertifyToolMapWindow.create_mapping: Validate and create mapping.
- CertifyToolMapWindow.update_mapping: Validate and update mapping.
- CertifyToolMapWindow.delete_mapping: Validate and delete mapping.

## ui/training_record_window.py
- TrainingRecordWindow.__init__: Initialize training record window and load data.
- TrainingRecordWindow._init_ui: Build filters, table, form, and action buttons.
- TrainingRecordWindow.load_filters: Load employee, certify, and type options.
- TrainingRecordWindow.load_data: Query and display training records.
- TrainingRecordWindow.on_row_selected: Populate form from selected row.
- TrainingRecordWindow._collect_form: Collect form values into dict for DAO calls.
- TrainingRecordWindow.create_record: Create or update on duplicate key match.
- TrainingRecordWindow.update_record: Update selected training record.
- TrainingRecordWindow.delete_record: Delete selected training record.
- TrainingRecordWindow.export_csv: Export training records CSV and notify user.
- TrainingRecordWindow._show_status: Show inline status message.

## ui/overdue_window.py
- OverdueWindow.__init__: Initialize overdue window and load data.
- OverdueWindow._init_ui: Build filter row and table.
- OverdueWindow.load_data: Query and display overdue records.

## ui/authority_window.py
- AuthorityWindow.__init__: Initialize authority window and load data.
- AuthorityWindow._init_ui: Build filter, table, perms grid, and form.
- AuthorityWindow.load_data: Query accounts and show perms as checkboxes.
- AuthorityWindow.on_row_selected: Load selected account and perms.
- AuthorityWindow.on_browse_db: Open a file dialog for selecting DB path.
- AuthorityWindow.on_apply_db: Apply DB path setting and prompt for restart.
- AuthorityWindow.on_create_db: Create a new database with the default filename.
- AuthorityWindow._prompt_restart: Ask the user to restart after DB changes.
- AuthorityWindow._restart_app: Restart the app after confirming.
- AuthorityWindow.create_account: Validate and create account with perms.       
- AuthorityWindow.update_account: Validate and update account with perms.       

## ui/custom_export_window.py
- CustomExportWindow.__init__: Initialize custom export window and load data.
- CustomExportWindow._init_ui: Build filters, table, and export button.
- CustomExportWindow.load_data: Query filtered training records.
- CustomExportWindow.export_csv: Export filtered rows to CSV and notify user.

## ui/training_report_window.py
- TrainingReportWindow.__init__: Initialize training report window and load data.
- TrainingReportWindow._init_ui: Build filters, table, and export button.
- TrainingReportWindow.load_depts: Load dept options into combo.
- TrainingReportWindow.load_data: Query and display dept-based report rows.
- TrainingReportWindow.export_csv: Export report rows to CSV and notify user.

## dao/db.py
- Database.__init__: Store DB path, busy timeout, and ensure directory exists.
- Database.connect: Open sqlite connection with row dicts.
- Database.fetch_all: Execute query and return list of dict rows.
- Database.fetch_one: Execute query and return single row dict.
- Database.execute: Execute DML and return affected row count.
- Database.executemany: Execute DML for many params and return count.

## dao/basic.py
- BasicDAO.__init__: Store Database reference.
- BasicDAO.list_sections: Return active sections (dept list).
- BasicDAO.list_areas: Return active areas.
- BasicDAO.list_jobs: Return active jobs.
- BasicDAO.list_titles: Return distinct titles from basic table.
- BasicDAO.list_shifts: Return distinct shifts from basic table.
- BasicDAO.list_all_sections: Return all sections.
- BasicDAO.create_section: Insert or replace section.
- BasicDAO.update_section: Update section description and active flag.
- BasicDAO.delete_section: Delete section by dept_code.
- BasicDAO.list_all_areas: Return all areas.
- BasicDAO.create_area: Insert or replace area.
- BasicDAO.update_area: Update area description and active flag.
- BasicDAO.delete_area: Delete area by code.
- BasicDAO.list_all_jobs: Return all jobs.
- BasicDAO.create_job: Insert or replace job.
- BasicDAO.update_job: Update job description and active flag.
- BasicDAO.delete_job: Delete job by code.
- BasicDAO.list_basic: Query employee basic data with filters.
- BasicDAO.create_basic: Insert basic employee data.
- BasicDAO.update_basic: Update basic employee data and update_date.
- BasicDAO.delete_basic: Delete basic employee by emp_id.

## dao/certify.py
- CertifyDAO.__init__: Store Database reference.
- CertifyDAO.list_certify_items: Return certify items with optional active filter.
- CertifyDAO.list_certify_types: Return certify types with optional active filter.
- CertifyDAO.list_certify_grades: Return distinct certify grades.
- CertifyDAO.create_certify_item: Insert certify item.
- CertifyDAO.update_certify_item: Update certify item.
- CertifyDAO.list_tool_map: Return certify-tool mappings with filters.
- CertifyDAO.create_tool_map: Insert certify-tool mapping.
- CertifyDAO.update_tool_map: Update mapping remark/active and update_date.
- CertifyDAO.delete_tool_map: Delete mapping by certify_id and tool_id.
- CertifyDAO.list_training_records: Return training records with joins.
- CertifyDAO.next_certify_no: Compute next certify_no sequence.
- CertifyDAO.create_training_record: Insert training record with new ID.
- CertifyDAO.update_training_record: Update training record fields.
- CertifyDAO.delete_training_record: Delete training record by certify_no.
- CertifyDAO.find_training_record: Find existing record by full key fields.
- CertifyDAO.export_training_records: Export training records to CSV.

## dao/personal.py
- PersonalDAO.__init__: Store Database reference.
- PersonalDAO.list_person_info: Query personal info with optional filters.
- PersonalDAO.list_emp_ids: Return employee IDs (optionally active only).
- PersonalDAO.get_person_info: Fetch one person_info row by emp_id.
- PersonalDAO.ensure_person_info: Insert blank person_info if missing.
- PersonalDAO.update_person_info: Update personal info fields and updater metadata.

## dao/education.py
- EducationDAO.__init__: Store Database reference.
- EducationDAO.list_distinct: List distinct education/school/major values.
- EducationDAO.list_emp_ids: Return employee IDs (optionally active only).
- EducationDAO.list_education: Query education records with filters.
- EducationDAO.upsert_education: Update existing or insert new education row.

## dao/overdue.py
- OverdueDAO.__init__: Store Database reference.
- OverdueDAO.list_overdue: Query overdue training records by min days.

## dao/authority.py
- AuthorityDAO.__init__: Store Database reference.
- AuthorityDAO.list_accounts: Query accounts and permission flags.
- AuthorityDAO.create_account: Insert or replace account with perms.
- AuthorityDAO.update_account: Update account fields and perms.
- AuthorityDAO.delete_account: Delete account by s_account.

## dao/report.py
- ReportDAO.__init__: Store Database reference.
- ReportDAO.training_by_dept: Query training records by dept and min days.
- ReportDAO.export_training_by_dept: Export dept report rows to CSV.
- ReportDAO.training_filtered: Query training records by emp_id/certify_id.
- ReportDAO.export_training_filtered: Export filtered rows to CSV.

## scripts/load_sample.py
- main: Create database schema and insert sample data.

## scripts/ui_smoke.au3
- LogLine: Append a line to the UI smoke test log file.
- ClickRel: Click a position relative to a window rectangle.
- ClickRelYOffset: Click a position relative to a window rectangle with Y offset.
- OpenDialogByClick: Open a dialog by click, then close it with a key.
- OpenDialogByClickAndWaitNewWindow: Click then wait for a new window and close it.
- FindWindowByPid: Find a visible window handle for a process id.
- WaitForWindowByPid: Wait for a visible window for a process id.
- FindWindowByTitleAndPid: Find a window by title regex and process id.
- FindWindowByTitleRegex: Find a window handle by title regex.
- WaitForWindowByTitleAndPid: Wait for a window by title regex and process id.
- CloseErrorDialogs: Close error dialogs matching title keywords and log them.
- LogWindowsByPid: Log window titles and states for a process id.
