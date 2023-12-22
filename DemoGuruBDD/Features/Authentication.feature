Feature: Authentication

End to end test for registration and signin for demoguru site

Background: User will be on the home page

@E2E
Scenario Outline: Register and Sign in
	When User clicks Register link
	Then User will be redirected to register page
	When User enters '<firstname>' in the firstname field
	* User enters '<lastname>' in the lastname field
	* User enters '<phone>' in the phone field
	* User enters '<email>' in the email field
	* User enters '<address>' in the address field
	* User enters '<city>' in the city field
	* User enters '<state>' in the state field
	* User enters '<postalcode>' in the postal code field
	* User selects '<country>' from the country dropdown
	* User enters '<username>' in the username field
	* User enters '<password>' in the password field
	* User enters '<password>' in the confirm password field
	* User clicks submit button
	Then User will be redirected to registration success page with valid '<username>' and '<password>'
	When User clicks on sign in link
	Then User will be redirected to Signin page
	When User enters '<username>' in username field in login page
	* User enters '<password>' in password field in login page
	* User clicks submit button in login page
	Then User will be redirected to login success page
	When User clicks on sign off link
	Then User will be redirected to index page

Examples:
	| firstname | lastname | phone      | email       | address       | city       | state  | postalcode | country | username | password |
	| ravi      | krishnan | 9876253672 | abc@xyz.com | abc residence | Trivandrum | Kerala | 695010     | India   | ravi123  | 12345678 |
	| invalid   |          |            | abc@xyz.com |               |            |        | 695010     | India   | a        |          |
