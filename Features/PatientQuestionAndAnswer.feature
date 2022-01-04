Feature: F.PatientQuestionAndAnswer
	

@mytag
Scenario Outline: Custom question Audit Scope and DataEntry	
Given Policy tab redirect link
And select a facility from facility drop down
And Activate  <CustomPolicy> to edit
When Click on edit button of activated policy
Then Copy Policy page open with all the selected custom  question set
Then store question in a list and match with excel
Given Redirect link of data entry tab
When enter the facility,date,shift and unit
Then dataentry page should open with set of answer of policy qs
Then verify the policy qs and answer
@source:Audit.xlsx:CustomPolicy
Examples: 
| CustomPolicy|


Scenario Outline: Audit Scope and Data Entry
Given Policy tab redirect link
And select a facility from facility drop down
And Activate a <Policy> to edit
When Click on edit button of activated policy
Then Copy Policy page open with all the selected question set
Then store question in a list and match with excel
Given Redirect link of data entry tab
When enter the facility,date,shift and unit
Then dataentry page should open with set of answer of policy qs
Then verify the policy qs and answer
@source:Audit.xlsx:ActivePolicyList
Examples: 
|Policy|



