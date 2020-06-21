Feature: GetSingleEmployee
	In order to get single employee data
	As a API client
	I want to be able to send request with employee id

@ValidScenario
Scenario: Send read request with valid employee Id
	Given I have valid request prepared with employee id <id>
	When Request is sent
	Then Response should contain data of employee with id <response>

	Examples: 
| id | response |
| 2  | 2        |
| 4  | 4        |


@InvalidScenario
Scenario: Send request with invalid employee Id but valid Id format
	Given I have request prepared with employee id 234
	When Request is sent
	Then Response should contain error - No Customer


Scenario: Send request with invalid employee Id with special haracter
	Given I have request prepared with employee id 23$
	When Request is sent
	Then Response should contain error - No Customer

Scenario: Send request with invalid employee Id - empty Id
	Given I have request prepared with employee id 0
	When Request is sent
	Then Response should contain error - No Customer
