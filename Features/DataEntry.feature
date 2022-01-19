Feature: DataEntry
	
@mytag

Scenario:01. Verify Data Entry tab
	Given Redirect link of data entry tab
	Then it should redirect to Audit page

	Scenario:02. verify Audit page of DataEntry
	Given Redirect link of data entry tab
	When select  facility from facility drop down
	And date from date picker
	And shift from drop down
	And Unit from drop down
	Then start button should enable
	And click on start button
	Then it should redirect to data entry page having unit name selected. 

	Scenario: 03 Verify to change active policy
    Given Policy tab redirect link
    When select a facility from facility drop down
    And select policy "DataEntryAutomation" from active policy drop down
    Then selected "DataEntryAutomation" policy should appear as Active.

	
Scenario:04. Verify the create and edit data entry
    Given Policy tab redirect link
    When select a facility from facility drop down
    And select policy "DataEntryAutomation" from active policy drop down

	Given Redirect link of data entry tab
	When enter the facility name,date,shift and unit	
	Then dataentry page open to answer question in yes/no
	And click on next patient to add new patient dataentry answer
	Then click on Add catheter,it should add new catheter for same patient
	Then click on End Audit to finish the data entry.

Scenario: 05.Verify romove patient from data entry
Given Policy tab redirect link
    When select a facility from facility drop down
    And select policy "DataEntryAutomation" from active policy drop down

	Given Redirect link of data entry tab
	When enter the facility name,date,shift and unit
	Then dataentry page should open to remove patient
	And click on yes button to delete a patient or catheter

	Then click on cancel button to leave the data entry page

	Scenario:06. Verify data entry for health system(same entry for all facility of a health system whoever active policy is same)
	Given Facility tab redirect link
    Then goto facility page to get the facilities having name attached with that hs 

	Given Policy tab redirect link
    Then select a health system facility and make policy "HSDEPolicy" active

	Given Redirect link of data entry tab
	When enter the hs facility name,date,shift and unit	
	Then dataentry page open to answer question in yes/no
	And click on next patient to add new patient dataentry answer
	Then click on Add catheter,it should add new catheter for same patient
	Then click on End Audit to finish the data entry.



