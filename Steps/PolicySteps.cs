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
            Thread.Sleep(3000);
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

        [When(@"select a health system's facility from facility drop down")]
        public void WhenSelectAHealthSystemSFacilityFromFacilityDropDown()
        {
            CommonUtility selectFacility = new CommonUtility();
            selectFacility.SelectFacilityForHealthSystem();
        }

        [When(@"switch to health system toggle")]
        public void WhenSwitchToHealthSystemToggle()
        {
            policy.toggleSwitch();
        }

        [Then(@"it should contains same health system name of which facility is selected\.")]
        public void ThenItShouldContainsSameHealthSystemNameOfWhichFacilityIsSelected_()
        {
            policy.VerifyHSName();
            
        }

        [Then(@"Policy name should listed in policies with health system name  for which it is created")]
        public void ThenPolicyNameShouldListedInPoliciesWithHealthSystemNameForWhichItIsCreated()
        {
            policy.HSPolicy();
            Thread.Sleep(5000);
        }
        [Then(@"view/print button of active policy get enabled")]
        public void ThenViewPrintButtonOfActivePolicyGetEnabled()
        {
            policy.EnableViewPrint();
        }
        [Then(@"click on view/print button to verify that popup menu should open with ""(.*)"" and ""(.*)"" as option\.")]
        public void ThenClickOnViewPrintButtonToVerifyThatPopupMenuShouldOpenWithAndAsOption_(string Policy, string AuditForm)
        {
            policy.ClickViewPrint(Policy, AuditForm);
        }
        [When(@"click on Policy option")]
        public void WhenClickOnPolicyOption()
        {
            policy.Policyclick();
        }

        [Then(@"it should open new window of policy")]
        public void ThenItShouldOpenNewWindowOfPolicy()
        {
            policy.Newwindow();
        }

        [When(@"click on AuditForm option")]
        public void WhenClickOnAuditFormOption()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"it should open new window of AuditForm")]
        public void ThenItShouldOpenNewWindowOfAuditForm()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"select a facility of health system and toggle health system")]
        public void ThenSelectAFacilityOfHealthSystemAndToggleHealthSystem()
        {
            policy.SelectFacilityForHealthSystemPolicy();
        }


    }
}
