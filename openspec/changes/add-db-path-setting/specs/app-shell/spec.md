## ADDED Requirements

### Requirement: Database Path Configuration
The system SHALL allow authorized users to configure the SQLite database path from the Authority Management screen and persist it to config.json.

#### Scenario: User sets a UNC path and switches
- **WHEN** the user enters a UNC path (for example, \\server\share\hrms.db) and confirms
- **THEN** the system updates config.json and prompts for restart so the new database loads after restarting

### Requirement: Missing Path Handling
The system SHALL prompt with an error when the configured database path does not exist; the current database remains active.

#### Scenario: Missing path
- **WHEN** the configured path does not exist
- **THEN** the system keeps the current database and reports the error

### Requirement: Database Creation Button
The system SHALL provide a dedicated create-database action that prompts for a folder and creates a new database named `HRMS_Database.db` without overwriting existing files.

#### Scenario: Create new database in a selected folder
- **WHEN** the user selects a folder where `HRMS_Database.db` does not exist
- **THEN** the system creates the parent directory if missing, initializes the schema, copies authority data only, updates config.json, and prompts for restart

#### Scenario: Create new database when file exists
- **WHEN** the user selects a folder where `HRMS_Database.db` already exists
- **THEN** the system reports the conflict and does not overwrite the database

### Requirement: Authority Data Carryover
The system SHALL copy only authority account data to a newly created database during a path switch.

#### Scenario: Create new database
- **WHEN** a new database is created from the create-database action
- **THEN** only authority accounts and permissions are copied; other tables are empty

### Requirement: Concurrent Write Mitigation
The system SHALL configure SQLite connections with a busy timeout and attempt WAL journal mode to reduce write contention across multiple users.

#### Scenario: Multiple users write
- **WHEN** concurrent writes occur
- **THEN** the system waits within the busy timeout before failing a write
