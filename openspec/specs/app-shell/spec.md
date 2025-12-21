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
