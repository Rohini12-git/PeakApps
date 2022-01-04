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
    public class PolicySteps
    {
        PolicyClass policy = new PolicyClass();

        [Given(@"Policy tab redirect link")]
        public void GivenPolicyTabRedirectLink()
        {
            policy.RedirectToPolicy();
        }
        
        [Then(@"it should redirect to the Policy page")]
        public void ThenItShouldRedirectToThePolicyPage()
        {
            string actualUrl = ObjectRepository.driver.Url;
            string expectUrl = "https://peakqa.3m.com/#/policy";
            Assert.AreEqual(actualUrl, expectUrl);
        }
        [When(@"select a facility from facility drop down")]
        public void WhenSelectAFacilityFromFacilityDropDown()
        {
            CommonUtility selectFacility = new CommonUtility();
            selectFacility.SelectFacility();
        }

        [Then(@"Create Policy button become enabled")]
        public void ThenCreatePolicyButtonBecomeEnabled()
        {
            bool actualValue = policy.EnablePolicyButton();
            Assert.IsTrue(actualValue, "Create Policy button is not enabled");
        }
        [When(@"click on create policy button")]
        public void WhenClickOnCreatePolicyButton()
        {
            policy.ClickCreatePolicy();
        }

        [Then(@"create Policy page open")]
        public void ThenCreatePolicyPageOpen()
        {
            string actualValue = policy.GetText();
            string expectedValue = "Create Policy";
            Assert.AreEqual(actualValue, expectedValue);
        }

        [When(@"select Audit type and enter policy name")]
        public void WhenSelectAuditTypeAndEnterPolicyName()
        {
            policy.SelectAuditType();
        }
        [When(@"select (.*)-Day Audit type and enter policy name")]
        public void WhenSelect_DayAuditTypeAndEnterPolicyName(int p0)
        {
            policy.Select21DayAuditType();
        }

        [When(@"click next button")]
        public void WhenClickNextButton()
        {
            policy.ClickNext();
        }

        [Then(@"define minimum compliance rate")]
        public void ThenDefineMinimumComplianceRate()
        {
            policy.compliance_rate();
        }

        [Then(@"click on next button")]
        public void ThenClickOnNextButton()
        {
            
            policy.ClickNext();
        }

        [Then(@"Audit Scope Page open")]
        public void ThenAuditScopePageOpen()
        {
            string actualValue = policy.AuditScope();
            string expectedValue = "Audit scope (Select all areas to include in this audit.)";
            Assert.AreEqual(actualValue, expectedValue);
        }
        [When(@"(.*)-Day Audit Scope Page open")]
        public void When_DayAuditScopePageOpen(int p0)
        {
            
            string actualValue = policy.MatchQuestionHeader();
            string expectedValue = "3M™ Curos™ Disinfecting Port Protectors currently used (Select all that apply.)";
            Assert.AreEqual(actualValue, expectedValue);
        }


        [Then(@"select any single qs and click next")]
        public void ThenSelectAnySingleQsAndClickNext()
        {
            policy.AuditScopeQ3();
        }
        [Then(@"compare the set of qs with excel and select one of that")]
        public void ThenCompareTheSetOfQsWithExcelAndSelectOneOfThat()
        {
            PolicyClass.Match21Daypolicy();
            policy.SelectRandomQs();
        }
        [Then(@"Facility protocol set of qs appear match with excel and select one option")]
        public void ThenFacilityProtocolSetOfQsAppearMatchWithExcelAndSelectOneOption()
        {
            policy.NeedlelessConnectors21Day();
        }


        [Then(@"next summary page open with all selected audit scope qs")]
        public void ThenNextSummaryPageOpenWithAllSelectedAuditScopeQs()
        {
            
           policy.SummaryPage();
            
            
        }

        [Then(@"click on finish and make active button")]
        public void ThenClickOnFinishAndMakeActiveButton()
        {
            policy.FinishAndMakeActive();
        }

        [Then(@"policy name name should prompt in active poliy drop down as selected\.")]
        public void ThenPolicyNameNameShouldPromptInActivePoliyDropDownAsSelected_()
        {
            Assert.AreEqual(policy.SetActivePolicy(), policy.setPolicyName());
            Thread.Sleep(3000);
        }


    }
}
