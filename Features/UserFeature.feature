Feature:A.UserFeature
	Verify the user's tab functionality
Background: Pre-Condition
#Given the user id's and password of user to login
#Then User lend to the dashboard page
When I click on user tab ,it redirected to the user page 

@mytag
Scenario: A. Verify the search,Facility drop down and active/inactive tab	
	Then switch to Inactive user tab  from active user to check for tab functionality
	Then Test "Facility Drop down Box" by selecting element 
	Then Test for search functionality.

Scenario Outline: B. Verify the CreateUser Functionality
    Then Click on Create user Button to check its functionality
	Then creat a user by assigning <FirstName>,<LastName>,<EmailAddress>,<Role>,<Facility>and<Health System> and validate where user created or not
	@source:Audit.xlsx:sheet3
	Examples: 
	|FirstName|LastName|EmailAddress|Role|Facility|Health System|

	Scenario: C. Verify the input field of Create User	  
	Then validate the input field by living them blanks and click on save button.
	And validate the first name and last name whether they take only letters or numbers.
	Then validate the email address 

	Scenario Outline: D. Check the Single Input box vlidation
	Then Validate a user field by assigning <FirstName>,<LastName>,<EmailAddress>,<Role>,<Facility> and leave one of the field empty to check validation
	@source:Audit.xlsx:sheet4
	Examples: 
	|FirstName|LastName|EmailAddress|Role|Facility|

	Scenario: F.Verify user inactive functionality
	Then count the active users and click on inactive button of a user
	Then it should prompt a message that "The user was successfully made inactive."

	Scenario: Verify user active functionality
	Then switch to Inactive user tab  from active user.
	Then count the inactive users and click on active button of a user
	Then it should prompt a message that "The user was successfully made active."



	#Scenario: F. Count  the  User and click on view button of SA,Admin,FA,Auditor   
	#Then Count the Active user and filter Super Admin,Admin,Facility Admin,Auditor and click on view button
	#Then Click on Edit Button to check whether Super Admin can edit other user.
	#Then Check for Add role whether Super Admin can assign multiple role to a user or not

	Scenario Outline:E. Verify user role and User Health Systems tab
	Given User <name> with view button
	When click on view button
	Then it redirect to user role page
	When click on User Health Systems tab 
	Then it redirect to user health system page
	Examples: 
	| name         |
	| testNew User |

	Scenario:G. Verify user having access for facility and role
	Given view button to enter user role page
	Then count the facility and role a user having access

	
	Scenario:H.Verify Add health system functionality	
	Given Add health system button
	When click on Add Health System button
	And select health system from drpdown
	And click on Add button 
	Then message prompt "The user was modified successfully."

	Scenario:I. Verify if facility of that health system added in user role
	Given Facility tab redirect link
	Then goto facility page to get the facilities having name attached with that hs
	Given health system name "TestAutoHS"	
	Then goto user role page 
	And match that same facility should be available in user role page

	Scenario:J. Verify reomove health system functionality from user's access
	Given List of health system a user having access
	When select a health system and click on remove button
	Then that health system should removed and prompt message "The user was modified successfully."

	
	#Scenario: K. Count  the  User and make them inactive
	#Then Count the Active user and filter Super Admin,Admin,Facility Admin,Auditor
	


 