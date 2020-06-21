Feature: CreateEmployee
	In order to add employee
	As a client app
	I want to be able to send create request

@ValidScenario
Scenario: Create Employee with valid data input
	Given I have entered <name> as a name of employee
	And I have entered <salary> as salary
	And I have entered <age> as  age
	And Request is prepared
	When Request is sent
	Then Guest should be created with data - <name>,<salary>,<age>

	Examples:
		| name           | salary | age  |
		| Mateusz        | 30000  | 23   |
		| Mateusz Wojtas | 0      | 100  |
		| Name           | 1      | 0    |
		| null           | 30000  | 23   |
		| Mateusz        | null   | 10   |
		| Mateusz        | 30     | null |
		| Mateusz        | -30    | 10   |
		| Mateusz        | 30     | -10  |
#below should be error cases if we had any validations of data at all in dummy app
#@InvalidScenarios
#Scenario: Create Employee with Invalid data input
#	Given I have entered <name> as a name of employee
#	And I have entered <salary> as salary
#	And I have entered <age> as  age
#	And Request is prepared
#	When Request is sent
#	Then Error response is returned with message
#
#	Examples:
#		| name    | salary | age  |
#		| null    | 30000  | 23   |
#		| Mateusz | null   | 10   |
#		| Mateusz | 30     | null |
#		| Mateusz | -30    | 10   |
#| Mateusz        | 30     | -10  |