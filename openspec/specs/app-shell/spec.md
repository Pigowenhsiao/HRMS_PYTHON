# App Shell

## Requirements

### Requirement: Login Language Selection
The system SHALL allow users to select the UI language on the login dialog and apply the selection immediately.

#### Scenario: User switches login language
- **WHEN** the user changes the language dropdown on the login dialog
- **THEN** the login dialog labels and buttons update immediately

### Requirement: Theme Toggle
The system SHALL provide a light/dark theme toggle on the main screen and apply the theme immediately.

#### Scenario: User toggles theme
- **WHEN** the user toggles the theme control
- **THEN** the application style updates without restarting

### Requirement: Role-Based Navigation
The system SHALL show navigation sections only when the current user has at least one permitted action in that section.

#### Scenario: User with limited permissions
- **WHEN** a user logs in with a restricted permission set
- **THEN** only the sections with permitted actions are visible in the navigation

### Requirement: Packaged Data Location
The packaged application SHALL place the SQLite database in the `DATA/` directory at the app root.

#### Scenario: Onedir packaging output
- **WHEN** the application is packaged in onedir mode
- **THEN** the database is located at `DATA/hrms.db`

### Requirement: Database Path Configuration
The system SHALL allow authorized users to configure the SQLite database path from the Authority Management screen and persist it to config.json.

#### Scenario: User updates database path
- **WHEN** the user enters a valid path and confirms
- **THEN** the system saves the path and prompts for restart so the database loads after restarting

### Requirement: Missing Database Path Handling
The system SHALL report an error when the configured database path does not exist and keep the current database active.

#### Scenario: Missing path
- **WHEN** the configured path does not exist
- **THEN** the system reports the error and keeps the current database active

### Requirement: Database Creation Action
The system SHALL provide a create-database action that creates `HRMS_Database.db` in a selected folder without overwriting an existing file.

#### Scenario: Create database in empty folder
- **WHEN** the user selects a folder where `HRMS_Database.db` does not exist
- **THEN** the system creates the database, copies authority data only, updates config.json, and prompts for restart

#### Scenario: Create database when file exists
- **WHEN** the selected folder already contains `HRMS_Database.db`
- **THEN** the system reports the conflict and does not overwrite the file

### Requirement: Status Bar Database Path
The system SHALL display the active database path and filename in the status bar.

#### Scenario: Status bar shows database path
- **WHEN** the main screen is shown
- **THEN** the status bar includes the database path
