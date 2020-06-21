Feature: CreateEmployee
	In order to add employee
	As a client app
	I want to be able to send create request

@ValidScenario
Scenario: Create Employee
	Given I have entered Mateusz as a name of employee
	And I have entered 30000 as salary
	And I have entered 23 as  age
	And Request is prepared
	When Request is sent
	Then Guest should be created with data - Mateusz,30000,23
