using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeakApps.Common;
using PeakApps.Custom_Class;
using PeakApps.Settings;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace PeakApps.Steps
{
    [Binding]
    public class FacilitySteps
    {
        FacilityClass facility = new FacilityClass();
        
        [Given(@"Facility tab redirect link")]
        public void GivenFacilityTabRedirectLink()
        {
            facility.RedirectToFacility();
        }
        
        [Then(@"it should redirect to the Facility page")]
        public void ThenItShouldRedirectToTheFacilityPage()
        {
            string actualUrl = ObjectRepository.driver.Url;
            string expectUrl = "https://peakqa.3m.com/#/location";
            Assert.AreEqual(actualUrl, expectUrl);
        }
        [When(@"click on facility inactive button")]
        public void WhenClickOnFacilityInactiveButton()
        {
            facility.ClickInactiveButton();
        }

        [Then(@"it should prompt a sucess message that ""(.*)""\.")]
        public void ThenItShouldPromptASucessMessageThat_(string expectText)
        {

            string actualText = facility.MessageOnButtonClick();
            Assert.AreEqual(actualText, expectText);
        }

        [When(@"click on inactive facilities,it redirect to inactive tab")]
        public void WhenClickOnInactiveFacilitiesItRedirectToInactiveTab()
        {
            facility.RedirectToInactiveFacilities();            
            Thread.Sleep(3000);
            Assert.AreEqual(facility.GetTextOfMakeActive(), "Make Active");
        }

        [Then(@"click on active facilities,it should  return to active tab")]
        public void ThenClickOnActiveFacilitiesItShouldReturnToActiveTab()
        {
            facility.RedirectToActiveFacilities();
            
            Assert.AreEqual(facility.GetTextOfMakeInactive(), "Make Inactive");
        }

        [When(@"enter the text like ""(.*)"" in facility search input box")]
        public void WhenEnterTheTextLikeInFacilitySearchInputBox(string text)
        {
            facility.InputSearchText(text);
        }

        [Then(@"it  should search all the facility contain word ""(.*)""")]
        public void ThenItShouldSearchAllTheFacilityContainWord(string text)
        {
            facility.VerifySearch(text);
        }

        [When(@"click on facilities  Edit button")]
        public void WhenClickOnFacilitiesEditButton()
        {
            facility.ClickEdit();
        }
        [Then(@"it should redirect to Facility Edit page")]
        public void ThenItShouldRedirectToFacilityEditPage()
        {
            string actualvalue = facility.GetFacilityText();
            Assert.IsTrue(actualvalue.Contains("Facility"), actualvalue + " doesn't contains 'Facility'");

        }


        [Then(@"if it redirects then close the page to verify close button")]
        public void ThenIfItRedirectsThenCloseThePageToVerifyCloseButton()
        {
            CommonUtility deleteFacility = new CommonUtility();
            deleteFacility.ClickCancel();
            string actualvalue = deleteFacility.GetEditText();
            Assert.IsTrue(actualvalue.Contains("Edit"), actualvalue + " doesn't contains 'Edit text'");

        }

        
        [When(@"edit the facility(.*),(.*),(.*),(.*),(.*),(.*) and (.*)")]
        public void WhenEditTheFacilityAnd(string Name, string FacilitySAP, string AddressLine1, string AddressLine2, string City, string State, string ZipCode)
        {
            facility.CreateOrEditFacility(Name, FacilitySAP, AddressLine1, AddressLine2, City, State, ZipCode);

        }


        [When(@"click on save")]
        public void WhenClickOnSave()
        {
            Thread.Sleep(5000);
            facility.SaveFacilityAndHS();
        }

        [Then(@"it should prompt a message""(.*)""")]
        public void ThenItShouldPromptAMessage(string expectedText)
        {
            string actualText = facility.AlertMessage();          
            Assert.AreEqual(actualText, expectedText);
        }

        [When(@"Click on Create and Edit Button,a drop down list open")]
        public void WhenClickOnCreateAndEditButtonADropDownListOpen()
        {
            facility.CreateAndEditButton();
        }

        [Then(@"select Create Facility option and click on it")]
        public void ThenSelectCreateFacilityOptionAndClickOnIt()
        {
            facility.CreateFacility();
        }
        [When(@"Facility page open enter (.*),(.*),(.*),(.*), (.*), (.*)and (.*)")]
        public void WhenFacilityPageOpenEnterAnd(string Name, string FacilitySAP, string AddressLine1, string AddressLine2, string City, string State, string ZipCode)
        {
            facility.CreateOrEditFacility(Name, FacilitySAP, AddressLine1, AddressLine2, City, State, ZipCode);

        }


        
        
        [Then(@"select Create Health System option and click on it")]
        public void ThenSelectCreateHealthSystemOptionAndClickOnIt()
        {
            facility.CreateHealthSystem();
        }

        [When(@"Health System page open,enter '(.*)' in name input")]
        public void WhenHealthSystemPageOpenEnterInNameInput(string p0)
        {
            facility.InputHealthSystem();
        }

        [Then(@"select Edit Health System option and click on it")]
        public void ThenSelectEditHealthSystemOptionAndClickOnIt()
        {
            facility.EditHealthSystem();
        }

        [When(@"Health System page open,select health system and edit  name")]
        public void WhenHealthSystemPageOpenSelectHealthSystemAndEditName()
        {
            facility.InputEditHealthSystem();
        }
        [When(@"click create button")]
        public void WhenClickCreateButton()
        {
            Thread.Sleep(5000);
            facility.CreateButton();
        }
        [Then(@"it should prompt an alert message ""(.*)""")]
        public void ThenItShouldPromptAnAlertMessage(string expectedText)
        {
            string actualText = facility.AlertMessage();
            Assert.AreEqual(actualText, expectedText);
        }

        [Then(@"count the facility under health system ""(.*)""")]
        public void ThenCountTheFacilityUnderHealthSystem(string hsName)
        {
            facility.facilityOfHs();
        }


    }
}
