Feature: new_Email

@DKratok

Scenario: Log in the mailbox, create new Email and save it on Draft

	Given I have opened Login Page
	And I have input Login 
	And I have input Password
	And I have selected domain
	When I press Sign In button
	Then Mailing Page is opened

	When I have clicked "New Email" button
	And I have filled Address_field with Email Address
	| Email                  |
	|dzmitry_kratok@epam.com |

	And I have filled Subject field with Subject 
	| Subject    |
	| Autotests  |

	And I have filled Body field with Text
	| Text                                                                                                                                                                                                     |
	| Hello!/r/nBryan Do gave up his job at the software giant to become an entrepreneur in South Korea, where small businesses must find a way to thrive in the shadow of huge congolmerates./r/nBest Regards |
	And I have clicked "Save as draft" button
	And I have navigated to Drafts section
	Then created email is visible in Drafts section

