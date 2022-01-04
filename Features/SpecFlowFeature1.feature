Feature: SpecFlowFeature1
	Simple calculator for adding two numbers

@mytag
Scenario Outline: Create User
Given user details  
When click on create user button
Then it redirect to create user page
When enter user user details <FirstName>,<LastName>,<EmailAddress>,<Role> and <Facility>
And click on save button 
Then sucess prompt message should appear
@Source:PeakData.xlsx:CreateUser
Examples: 
|FirstName|LastName|EmailAddress|Role|Facility|