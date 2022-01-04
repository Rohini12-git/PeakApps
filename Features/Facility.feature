Feature:C.Facility
	

@mytag
Scenario:01 Verify the Facility tab
Given Facility tab redirect link
Then  it should redirect to the Facility page

Scenario:02 Verify Inactive button
Given Facility tab redirect link
When click on facility inactive button
Then it should prompt a sucess message that "The facility was successfully made inactive.".

Scenario:03 Verify Active/Inactive tab of Facility  Page
Given Facility tab redirect link
When click on inactive facilities,it redirect to inactive tab
Then click on active facilities,it should  return to active tab

Scenario: 04 Verify search functonality 
Given Facility tab redirect link
When enter the text like "test" in facility search input box
Then it  should search all the facility contain word "test" 

Scenario: 05 Verify Edit Button
Given Facility tab redirect link
When click on facilities  Edit button
Then it should redirect to Facility Edit page
And if it redirects then close the page to verify close button

Scenario Outline:06 Verify Edit Page
Given Facility tab redirect link
When click on facilities  Edit button
Then it should redirect to Facility Edit page
When edit the facility<Name>,<FacilitySAP>,<AddressLine1>,<AddressLine2>,<City>,<State> and <ZipCode>
And click on save 
Then it should prompt a message"The facility was modified successfully."
@source:Audit.xlsx:Sheet5
Examples: 
|Name|FacilitySAP|AddressLine1|AddressLine2|City|State|ZipCode|

Scenario Outline:07 Verify Create Facility button
Given Facility tab redirect link
When Click on Create and Edit Button,a drop down list open
Then select Create Facility option and click on it
When Facility page open enter <Name>,<FacilitySAP>,<AddressLine1>,<AddressLine2>, <City>, <State>and <ZipCode>
And click create button
Then it should prompt an alert message "The facility was created successfully."
@source:Audit.xlsx:Sheet5
Examples: 
|Name|FacilitySAP|AddressLine1|AddressLine2|City|State|ZipCode|

Scenario:08 Verify Create Health System
Given Facility tab redirect link
When Click on Create and Edit Button,a drop down list open
Then select Create Health System option and click on it
When Health System page open,enter 'AutoHS' in name input
And click create button
Then it should prompt an alert message "The health system was created successfully."

Scenario:9 Verify Edit Health System
Given Facility tab redirect link
When Click on Create and Edit Button,a drop down list open
Then select Edit Health System option and click on it
When Health System page open,select health system and edit  name
And click on save 
Then it should prompt an alert message "The health system was modified successfully."

Scenario: 10. List of facility under health system
Given Facility tab redirect link
Then count the facility under health system "TestAutoHS"


