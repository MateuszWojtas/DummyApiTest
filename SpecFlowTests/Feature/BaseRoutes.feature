Feature: BaseRoutes
	In order to check routing
	As a client API
	I want to see eror when bad HTTP method or route is passed in request

@InvalidScenario
Scenario: Verify bad routes
	Given I have base page url with route <route> and method <method>
	When Request is sent
	Then Result should return error message: Not found

	Examples:
		| route       | method |
		| \employees  | PUT    |
		| \employees  | PATCH  |
		| \employees  | DELETE |
		| \employees  | POST   |
		| \employee\  | GET    |
		| \employee\1 | PUT    |
		| \employee\1 | PATCH  |
		| \employee\1 | DELETE |
		| \employee\1 | POST   |

#TODO: other incorrect combinations of HTTP methods and routes
@invalidScenario
Scenario: Verify error when no session data is NOT sent
	Given I Prapare <request> that require session data without it
	When Request is sent
	Then Result should return error message: Not found

	Examples:
		| request    |
		| SingleRead |
		| Update     |
		| Update     |

#TODO
@invalidScenario
Scenario: Verify when no cookie is sent
	Given I Prepare request for single employee read without cookies
	When Request is sent
	Then Erros is returned