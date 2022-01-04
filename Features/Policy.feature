Feature: E.Policy
	

@mytag
Scenario:01 Verify the Policy tab
Given Policy tab redirect link
Then  it should redirect to the Policy page

Scenario:02 Verify Create Policy button - 3M Super Admin
    
	Given Policy tab redirect link
	When select a facility from facility drop down
	Then Create Policy button become enabled 

Scenario: 03 Verify Create Policy for Comprehensive Audit type
Given Policy tab redirect link
When select a facility from facility drop down
And click on create policy button
Then create Policy page open
When select Audit type and enter policy name
And click next button
Then define minimum compliance rate
And click on next button
Then Audit Scope Page open
Then select any single qs and click next
Then next summary page open with all selected audit scope qs
Then click on finish and make active button
Then policy name name should prompt in active poliy drop down as selected.

Scenario: 04 Verify Create Policy for 21-Day Challenge Audit type
Given Policy tab redirect link
When select a facility from facility drop down
And click on create policy button
Then create Policy page open
When select 21-Day Audit type and enter policy name
And click next button
Then define minimum compliance rate
And click on next button
When 21-Day Audit Scope Page open
Then compare the set of qs with excel and select one of that
And click on next button
Then Facility protocol set of qs appear match with excel and select one option
And click on next button
Then click on finish and make active button
Then policy name name should prompt in active poliy drop down as selected.

Scenario: 05 Verify Create Policy for health system
Given Policy tab redirect link
When select a health system facility from facility drop down
And click on create policy button
Then create Policy page open


