Feature: GetSingleEmployee
	In order to get single employee data
	As a API client
	I want to be able to send request with employee id

@ValidScenario
Scenario: Send read request with valid employee Id
	Given I have request prepared with employee id <id>
	When Request is sent
	Then Response should contain data <id>,<responseName>,<responseAge>,<responseSalary>

	Examples:
		| id | responseName | responseAge | responseSalary |
		| 20 | Dai Rios     | 35          | 217500         |
		| 1  | Tiger Nixon  | 61          | 320800         |

@InvalidScenario
Scenario: Send request with invalid employee Id but valid Id format
	Given I have request prepared with employee id 234
	When Request is sent
	Then Response should contain error No Record

	Examples:
		| id   |
		| 234  |
		| $23  |
		| asd  |
		| null |