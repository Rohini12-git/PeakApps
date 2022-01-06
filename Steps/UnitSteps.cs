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
    public class UnitSteps
    {
        UnitClass unit = new UnitClass(ObjectRepository.driver);
        [Given(@"Unit tab redirect link")]
        public void GivenUnitTabRedirectLink()
        {
            unit.RedirectToUnits();
        }
        
        [Then(@"it should redirect to the unit page")]
        public void ThenItShouldRedirectToTheUnitPage()
        {
            string actualUrl = ObjectRepository.driver.Url;
            string expectUrl = "https://peakqa.3m.com/#/unit";
            Assert.AreEqual(actualUrl, expectUrl);
        }
        

        [When(@"click on inactive,it redirect to inactive tab")]
        public void WhenClickOnInactiveItRedirectToInactiveTab()
        {
            unit.RedirectToInactiveUnits();
            Thread.Sleep(3000);
            Assert.AreEqual(unit.GetTextOfMakeActive(), "Make Active");

        }

        [Then(@"click on active,it should  return to active tab")]
        public void ThenClickOnActiveItShouldReturnToActiveTab()
        {
            unit.RedirectToActiveUnits();
            Assert.AreEqual(unit.GetTextOfMakeInactive(), "Make Inactive");

        }
        [When(@"enter the text like ""(.*)"" in unit search input box")]
        public void WhenEnterTheTextLikeInUnitSearchInputBox(string search)
        {
            unit.InputSearchText(search);
        }
        [Then(@"it  should search all the units contain word ""(.*)""")]
        public void ThenItShouldSearchAllTheUnitsContainWord(string search)
        {
            unit.VerifySearch(search);
        }


        

        [When(@"click on inactive button")]
        public void WhenClickOnInactiveButton()
        {
            unit.ClickInactiveButton();
        }

        [Then(@"it should prompt a sucess message that unit get inactive sucessfully\.")]
        public void ThenItShouldPromptASucessMessageThatUnitGetInactiveSucessfully_()
        {
            unit.MessageOnButtonClick();
        }
        [When(@"click on Edit button")]
        public void WhenClickOnEditButton()
        {
            unit.ClickEdit();
        }

        [Then(@"it should redirect to edit page")]
        public void ThenItShouldRedirectToEditPage()
        {
            string actualvalue = unit.GetUnitText();
            Assert.IsTrue(actualvalue.Contains("Unit"), actualvalue + " doesn't contains 'Unit'");
        }
        [Then(@"if it redirect then close the page to verify close button")]
        public void ThenIfItRedirectThenCloseThePageToVerifyCloseButton()
        {
            CommonUtility deleteUnit = new CommonUtility();
            deleteUnit.ClickCancel();
            string actualvalue = deleteUnit.GetEditText();
            Assert.IsTrue(actualvalue.Contains("Edit"), actualvalue + " doesn't contains 'Edit text'");
        }

        
        [When(@"edit the unit name")]
        public void WhenEditTheUnitName()
        {
            unit.InputUnit();
        }

        [When(@"click on save button")]
        public void WhenClickOnSaveButton()
        {
            unit.ClickSave();
        }

        [Then(@"it should prompt sucess message")]
        public void ThenItShouldPromptSucessMessage()
        {
            unit.MessageOnButtonClick();
        }
        [When(@"select a facility")]
        public void WhenSelectAFacility()
        {
            CommonUtility selectFacility = new CommonUtility();
            selectFacility.SelectFacility();
        }

        [Then(@"it should enable create unit")]
        public void ThenItShouldEnableCreateUnit()
            
        {
            bool actualValue = unit.EnableUnitButton();
            Assert.IsTrue(actualValue,"Create Unit button is not enabled");
        }
        [When(@"click on Create Unit button")]
        public void WhenClickOnCreateUnitButton()
        {
            unit.ClickCreateUnit();
        }

        [Then(@"it should redirect to Create Unit Page")]
        public void ThenItShouldRedirectToCreateUnitPage()
        {
            string actualvalue = unit.GetUnitText();
            Assert.IsTrue(actualvalue.Contains("Unit"), actualvalue + " doesn't contains 'Unit'");
        }
        [When(@"enter unit name")]
        public void WhenEnterUnitName()
        {
            unit.InputUnit();
        }

        [When(@"click on create button")]
        public void WhenClickOnCreateButton()
        {
            unit.ClickCreate();
        }

        [Then(@"it should prompt a message ""(.*)""")]
        public void ThenItShouldPromptAMessage(string expectText)
        {
            string actualText = unit.AlertMessage();
            //string expectText = "The unit was created successfully.";
            Assert.AreEqual(actualText, expectText);
        }








        
    }
}
