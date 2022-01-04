Feature:B.Unit
	

#Background: Pre-Condition
#When I click on unit tab ,it redirected to the unit page 



@mytag

Scenario:01 Verify the unit tab
Given Unit tab redirect link
Then  it should redirect to the unit page

Scenario:02 Verify Inactive button
Given Unit tab redirect link
When click on inactive button
Then it should prompt a sucess message that unit get inactive sucessfully.


Scenario:03 Verify Active/Inactive tab of Unit Page
Given Unit tab redirect link
When click on inactive,it redirect to inactive tab
Then click on active,it should  return to active tab

Scenario: 04 Verify search functonality 
Given Unit tab redirect link
When enter the text like "test" in unit search input box
Then it  should search all the units contain word test 


Scenario: 06 Verify Edit Button
Given Unit tab redirect link
When click on Edit button
Then it should redirect to edit page
And if it redirect then close the page to verify close button

Scenario: 07 Verify Edit Page
Given Unit tab redirect link
When click on Edit button
Then it should redirect to edit page
When edit the unit name
And click on save button
Then it should prompt sucess message

Scenario:08 Verify  Enable Create Unit button
Given Unit tab redirect link
When select a facility
Then it should enable create unit 

Scenario: 09 Verify Create Unit button
Given Unit tab redirect link
When select a facility
And click on Create Unit button
Then it should redirect to Create Unit Page
And if it redirect then close the page to verify close button

Scenario: 10 Verify create unit page functionality
Given Unit tab redirect link
When select a facility
And click on Create Unit button
Then it should redirect to Create Unit Page
When enter unit name 
And click on create button
Then it should prompt a message "The unit was created successfully."





#
#Scenario: 1. Check the Unit Functionality
#   
#	Then switch to Inactive unit from active unit to check for tab functionality
#	Then Test 'Facility Drop down' Box by selecting element 
#	Then Test for search functionality of unit.
#
#	Scenario:  Vrify Creat Unit Functionality
#	Given Creat Unit button,click on it to varify if it is clickable or not
#	Then validate that unit is getting create or not on clicking save button
#
#
#	Scenario: 3. Count  the  Unit and make them inactive   	
#	Then Count the Active unit and make them inactive
#
#	Scenario: 4. Count  the  inactive Unit and make them active   
#	Then Count the Inactive unit and make some of them active
#
#	Scenario: 5. Verify edit funtionality of unit   
#	Then Count the Active unit and click on edit button
#	Then Click on Edit Button to check it's functionality
#
#
