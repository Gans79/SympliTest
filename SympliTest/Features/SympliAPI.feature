Feature: SympliAPI

@api
Scenario: Call an API and check Staus
	Given I create a client with an endpoint
	And I add the headers to the request
	When I execute the 'Get' request
	Then I validate the '200' status code