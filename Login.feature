Feature: Login
	Simple Login

#Background: Pre-Condition
#    Given the url of the webapp
#	
@mytag
	Scenario Outline: Verify the user login access
    When enter the "<username>" and "<password>"
	Then user should lend to the dashboard page
	When click on logout button 
	Then it should lend to the login page
	
	Examples: 
	| username                   | password     |
	| vikash.prasad@nathcorp.com | Nathcorp@123 |

Scenario: verify the Remember me link
When Click on Remember me checkbox
Then it should get checked

Scenario: Verify the Forgot Password
When Click on click here link
Then it should redirect to the url"<https://enl.3m.com/enl/dontknow_password.jsp>"

Scenario: Verify Terms and Condition
When Click on Terms & Condition link
Then it should redirect to the END USER LICENSE AGREEMENT page
When click on Accept button
Then it should redirect to login page


