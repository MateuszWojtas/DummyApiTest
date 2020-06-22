Feature: DeleteEmployee
	In order to delete dmployee data
	As a client API
	I want to be able to send delete request with employee id

@ValidScenario
Scenario: Deleting employee with valid data
	Given Employee to be deleted exist
	And I prepared delete request
	When Request is sent
	Then Delete confirmation message is returned

@InvalidScenario
Scenario: Deleting employee with invalid data
	Given I want to delete employee with <id>
	And I prepared delete request
	When Request is sent
	Then Error message is returned

	Examples:
		| id   |
		| 123  |
		| aa   |
		| 12$  |