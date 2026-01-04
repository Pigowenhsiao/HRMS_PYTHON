## ADDED Requirements
### Requirement: Maintenance CRUD Consistency
The system SHALL keep CRUD behavior consistent across maintenance windows (area, section, job), including validation messaging and table refresh after create, update, or delete.

#### Scenario: User maintains master data
- **WHEN** the user creates, updates, or deletes a row in a maintenance window
- **THEN** the system validates inputs and refreshes the table view consistently
