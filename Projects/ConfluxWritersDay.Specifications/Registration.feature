Feature: Registration

@ignore @todo
Scenario: Register Online
	Given I am choosing to register online
	When I navigate to this page
	Then I want the process to be quick and easy
	And I want it clearly explained
	And I want multiple options for payment
	And I want an automatic email confirming that my registration has gone through

@_UnderDevelopment... @Integration
Scenario: Registration Details
	Given I am on the registration page
	And my first name is entered
	And my last name is entered
	And my address is entered
	And my telephone number is entered
	And my email address is entered
	And my dietary requirements are entered
	And my special requirements are entered
	And I have selected a payment method:
		| Id            | Value          |
		| Cheque        | Cheque         |
		| PayPal        | PayPal         |
		| DirectDeposit | Direct Deposit |
	And I have selected a membership organisation:
		| Id               | Value                     |
		| Conflux9         | Conflux 9 Member          |
		| CSFG             | CSFG Member               |
		| ACTWritersCentre | ACT Writers Centre Member |
	When I submit my registration
	Then I will see thank you page
	And I will receive an email

@ignore @todo
Scenario: First name is required
	Given I am on the registration page
	And I have not entered my first name
	When I submit my registration
	Then I will see warning message that first name is required

@ignore @todo
Scenario: Last name is required
	Given I am on the registration page
	And I have not entered my email address
	When I submit my registration
	Then I will see warning message that email address is required

@ignore @todo
Scenario: Email address is required
	Given I am on the registration page
	And I have not entered my first name
	When I submit my registration
	Then I will see warning message that first name is required

@ignore @todo
Scenario: Is a member
	Given I am on the registration page
	When I am a member
	Then the price is '$120.00'

@ignore @todo
Scenario: Is not a member
	Given I am on the registration page
	When I am not a member
	Then the price is '$150.00'

@ignore @todo
Scenario: First 30 registration
	Given I am on the registration page
	When I am one of the first 30 registrations
	Then the price is '$90.00'

@ignore @todo
Scenario: 31+ registration
	Given I am on the registration page
	And I was 30th to start registration
	And someone else typed quicker than me
	When I hit submit
	Then I am told I missed out

@ignore @todo
Scenario: direct deposit
	Given I have completed registration 
	And the payment method is direct deposit payment
	When I am sent an email
	Then I the direct deposit invoice is attached

@ignore @todo
Scenario: paypal
	Given I have completed registration 
	And the payment method is Paypal payment
	When I am sent an email
	Then I the paypal invoice is attached

@ignore @todo
Scenario: cheque
	Given I have completed registration 
	And the payment method is cheque payment
	When I am sent an email
	Then I the cheque invoice is attached
