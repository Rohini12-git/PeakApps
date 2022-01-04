Feature: D.CompareAuditQs
	Simple calculator for adding two numbers

Background: Pre-Condition
Given Policy tab redirect link
When select a facility from facility drop down
And click on create policy button
Then create Policy page open
When select Audit type and enter policy name
And click next button
Then define minimum compliance rate
And click on next button
@mytag

Scenario:1. Audit scope (Select all areas to include in this audit.) Policy - 3M Super Admin
    
	Then Verify all the list item i.e Audit Setup in the sheet is available in the site or not
	When  data matched click on cancel to close policy.

	Scenario:2. Single Data Audit Policy-3M Super Admin
	Then Verify the 'Audit Setup' having single flow 
	Then click on finish and make active button
    Then policy name name should prompt in active poliy drop down as selected.

	Scenario:3. Double Data Audit Policy-3M Super Admin
    When Verify the 'Audit Setup' having double flow  and click on next button
	And select the next data and match with sheet
	Then click on finish and make active button
    Then policy name name should prompt in active poliy drop down as selected.

	Scenario:4. Multi Data 3A-Audit Policy-3M Super Admin
    When  select 3A 'Audit Setup' having multiple flow  and click on next button
	Then select 4A->5(Any/All)->6(Any/All)->11(Any/All) and match with sheet 
	Then click on finish and make active button
    Then policy name name should prompt in active poliy drop down as selected.

	Scenario:5. Multi Data 3B-Audit Policy-3M Super Admin

    When  select 3B 'Audit Setup' having multiple flow  and click on next button
	Then select 7->8(Any/All)->6(Any/All)->11(Any/All) and match with sheet 
	Then click on finish and make active button
    Then policy name name should prompt in active poliy drop down as selected.
	

	Scenario:6. Multi Data 3B-7B-Audit Policy-3M Super Admin

    When  select 3B 'Audit Setup' having multiple flow  and click on next button
	Then select 7B->11(Any/All) and match with sheet 
	Then click on finish and make active button
    Then policy name name should prompt in active poliy drop down as selected.
	

	Scenario:7. Multi Data 3C-Audit Policy-3M Super Admin

    When  select 3C 'Audit Setup' having multiple flow  and click on next button
	Then select 9A->10->6(Any/All)->11(Any/All) and match with sheet 
	Then click on finish and make active button
    Then policy name name should prompt in active poliy drop down as selected.
	