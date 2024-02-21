Feature: SearchCity
	As a user
	I want to search for a city
	So that I can view its weather information

Scenario: Search city by name
	When I consent data usage
	And I Input 'New York' in the search field
	Then the search results list is displayed
	When I click on the first search result
	Then the city weather page header contains the city name "New York" from the search
