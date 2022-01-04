using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeakApps.Common;
using PeakApps.Custom_Class;
using PeakApps.Settings;
using System.Threading;
using TechTalk.SpecFlow;



namespace PeakApps.Steps
{
    [Binding]
    public class DataEntrySteps
    {
        
        DataEntry entry = new DataEntry();
        [Given(@"Redirect link of data entry tab")]
        public void GivenRedirectLinkOfDataEntryTab()
        {
            entry.RedirectToDataEntry();
        }
        
        [Then(@"it should redirect to Audit page")]
        public void ThenItShouldRedirectToAuditPage()
        {
            string actualUrl = ObjectRepository.driver.Url;
            string expectUrl = "https://peakqa.3m.com/#/data-entry";
            Assert.AreEqual(actualUrl, expectUrl);
        }
        [When(@"select  facility from facility drop down")]
        public void WhenSelectFacilityFromFacilityDropDown()
        {
            entry.SelectFacility();
        }

        [When(@"date from date picker")]
        public void WhenDateFromDatePicker()
        {
            entry.SelectDate();
        }
        [When(@"shift from drop down")]
        public void WhenShiftFromDropDown()
        {
            entry.SelectShift();
        }


        [When(@"Unit from drop down")]
        public void WhenUnitFromDropDown()
        {
            entry.SelectUnit();
        }

        [Then(@"start button should enable")]
        public void ThenStartButtonShouldEnable()
        {
            entry.EnableStart();
        }

        [Then(@"click on start button")]
        public void ThenClickOnStartButton()
        {
            entry.ClickStart();
        }

        [Then(@"it should redirect to data entry page having unit name selected\.")]
        public void ThenItShouldRedirectToDataEntryPageHavingUnitNameSelected_()
        {

            entry.verifyUnitName();
        }

        [When(@"select policy ""(.*)"" from active policy drop down")]
        public void WhenSelectPolicyFromActivePolicyDropDown(string activepolicy)
        {
            entry.ActivePolicy(activepolicy);
        }
        [Then(@"selected ""(.*)"" policy should appear as Active\.")]
        public void ThenSelectedPolicyShouldAppearAsActive_(string policyName)
        {
            string expectedText = policyName;
            string actualText = entry.FetchActivePolicyName();
           
            Assert.AreEqual(actualText, expectedText);
        }
        [Then(@"dataentry page open to answer question in yes/no")]
        public void ThenDataentryPageOpenToAnswerQuestionInYesNo()
        {
            entry.DEQs();
        }


    }
}
