Feature: Login

@DKratok
Scenario: Log in the mailbox

	Given I have opened Login Page
	And I have input Login 
	And I have input Password
	And I have selected domain
	When I press Sign In button
	Then Mailing Page is opened


	Scenario: Log in the mailbox_Failed

	Given I have opened Login Page
	And I have input Login 
	And I have input Password not correct
	And I have selected domain
	When I press Sign In button
	Then Mailing Page is not opened
