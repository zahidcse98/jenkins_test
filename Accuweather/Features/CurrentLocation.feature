Feature: Use Current Location
	As a user
	I want to use my current location for weather information
	So that I can get the weather details for my current location easily

Scenario: Use Current location for weather information
	When I consent data usage
	And I click on the search field
	Then the search results list is displayed
	Then the use your current location label is displayed