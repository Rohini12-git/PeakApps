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

	Scenario: 06.Store the Active policy question
	
	 Given Policy tab redirect link
     When select a facility from facility drop down
	 And select policy "DataEntryAutomation" from active policy drop down
	 #Then serach for the active policy in list of policies
	 #And click on Edit button

#Scenario:05. Verify the create data entry
#	Given Redirect link of data entry tab
#	When select  facility from facility drop down
#	And date from date picker
#	And shift from drop down
#	And Unit from drop down
#	Then start button should enable
#	And click on start button
#	Then dataentry page open to answer question in yes/no
#	#When click on next button it will redirect to next page having set of qs
#	#And click on next patient to add new patient dataentry answer
#	#When click on Add catheter,it should add new catheter for same patient
#	#Then click on End Audit to finish the data entry.
#
