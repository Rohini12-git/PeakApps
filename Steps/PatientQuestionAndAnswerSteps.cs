using PeakApps.Common;
using PeakApps.Custom_Class;
using System;
using TechTalk.SpecFlow;

namespace PeakApps.Steps
{
    [Binding]
    public class PatientQuestionAndAnswerSteps
    {
        DataEntry entry = new DataEntry();
        PatientAnswer answer = new PatientAnswer();

        [Given(@"select a facility from facility drop down")]
        public void GivenSelectAFacilityFromFacilityDropDown()
        {
            CommonUtility common = new CommonUtility();
            common.SelectFacilityForDataEntry();
        }
        

        [Given(@"Activate  (.*) to edit")]
        public void GivenActivateToEdit(string CustomPolicyName)
        {
            entry.ActivePolicy(CustomPolicyName);
        }

        [Given(@"Activate a (.*) to edit")]
        public void GivenActivateAToEdit(string policyName)
        {
            entry.ActivePolicy(policyName);
        }

        [When(@"Click on edit button of activated policy")]
        public void WhenClickOnEditButtonOfActivatedPolicy()
        {
            
            answer.Editpolicy();
        }
        [Then(@"Copy Policy page open with all the selected custom  question set")]
        public void ThenCopyPolicyPageOpenWithAllTheSelectedCustomQuestionSet()
        {
            answer.Policy3N();
        }


        [Then(@"Copy Policy page open with all the selected question set")]
        public void ThenCopyPolicyPageOpenWithAllTheSelectedQuestionSet()
        {
            answer.Copypolicy();
        }

        
        [Then(@"store question in a list and match with excel")]
        public void ThenStoreQuestionInAListAndMatchWithExcel()
        {
            answer.storedPolicy();
        }


        [When(@"enter the facility,date,shift and unit")]
        public void WhenEnterTheFacilityDateShiftAndUnit()
        {
            answer.SelectFacilityForDataEntry();
            entry.SelectDate();
            entry.SelectShift();
            entry.SelectUnit();
            entry.ClickStart();
        }

        

        [Then(@"dataentry page should open with set of answer of policy qs")]
        public void ThenDataentryPageShouldOpenWithSetOfAnswerOfPolicyQs()
        {
            answer.fetch3DPolicy();
           
        }

        [Then(@"verify the policy qs and answer")]
        public void ThenVerifyThePolicyQsAndAnswer()
        {
            answer.DEQs();
        }

    }
}
