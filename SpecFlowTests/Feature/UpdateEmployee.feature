Feature: UpdateEmployee
	In order to chenge employee data
	As a customer app
	I want to be able to send update PUT request

@ValidScenarios
Scenario: Employee updating scenario
	Given I Have employee with id <id>
	And I update employee data with new values <updatedName>,<updatedSalary>,<updatedAge>
	And I created update request with updated data
	When Request is sent
	Then Response with the same id and new name is shown

	Examples:
		| id | updatedName | updatedSalary | updatedAge |
		| 2  | Mateusz     | 20            | 21         |
		| 4  | null        | 30            | 21         |
		| 6  | Max         | null          | 11         |
		| 8  | Klark Kent  | 23            | null       |
		| 11 | null        | null          | null       |