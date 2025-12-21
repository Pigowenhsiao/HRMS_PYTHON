## ADDED Requirements

### Requirement: Employee Name Split Fields
The system SHALL store employee names as `last_name` and `first_name` and SHALL remove the legacy `c_name` column.

#### Scenario: Legacy data migration
- **WHEN** migrating existing `basic` records
- **THEN** the first character of `c_name` is stored in `last_name`
- **AND THEN** the remaining characters are stored in `first_name`

#### Scenario: New employee entry
- **WHEN** a user creates or updates employee basic data
- **THEN** the UI provides separate inputs for `last_name` and `first_name`
- **AND THEN** the system saves the two fields to the database

### Requirement: Full Name Display
The system SHALL display the employee full name by concatenating `last_name` + `first_name` in screens and exports that previously showed `c_name`.

#### Scenario: Training record list display
- **WHEN** a user views training/certification records
- **THEN** the employee name column shows `last_name` + `first_name`
