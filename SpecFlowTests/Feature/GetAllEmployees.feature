Feature: GetAllEmployees
	In order to check if api works properly
	As a client
	I want to check if i can extract all customers

@ValidScenario
Scenario: Get All employees data
	Given Get All Employee data request prepared
	When Request is sent
	Then The result should return all employee list
