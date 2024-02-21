Feature: Window Example test
	As a user
	I Have to navigate to the given link
	then click on the mentioned link and wait until the page is displayed
	then i have to click 'Alerts In A New Window From JavaScript' link
	then i have to click the 'Show Prompt Box' btn
	then wait until the alert is displayed
	change the prompt text and accept it

Scenario: Handling Alert Box
	When I navigate to the homepage
	And Windows Links and Example page is opened
	When I Click Alerts In A New Window From Javascript Link
	Then The Alert Box Examples Page Is opened in a new tab
	When I Click Show Prompt Box btn
	Then I Put SomeValue into the input box and accept the alert
