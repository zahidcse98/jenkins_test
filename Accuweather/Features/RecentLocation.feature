Feature: Use Recent Location
	As a user
	I want to use recent locations for weather information
	So that I can get the weather details for my recent location easily

Scenario: Use Recent location for weather information
	When I consent data usage
	And I Input 'London' in the search field
	Then the search results list is displayed
	When I click on the first search result
	Then the city weather page header contains the city name "London" from the search
	When I go back to the Main Page
	Then Main Page is Opened
	When I choose first city in Recent locations
	Then the city weather page header contains the city name "London" from the search