Feature: UpdateEmployee
	In order to chenge employee data
	As a customer app
	I want to be able to send update PUT request

@ValidScenarios
Scenario: Name updating scenario
	Given I Have employee with id <id> and name <baseName>
	And I update its data with new Name <updatedName>
	When Request is sent
	Then Response with the same id and new name is shown

	Examples: 
	| id | basename    | updatedname         |
	| 1  | Tiger Nixon | Tiger Nixon Updated |