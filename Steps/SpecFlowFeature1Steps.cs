using System;
using TechTalk.SpecFlow;

namespace PeakApps.Steps
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        [Given(@"user details")]
        public void GivenUserDetails()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"click on create user button")]
        public void WhenClickOnCreateUserButton()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"enter user user details (.*),(.*),(.*),(.*) and (.*)")]
        public void WhenEnterUserUserDetailsAnd(string p0, string p1, string p2, string p3, string p4)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"click on save button")]
        public void WhenClickOnSaveButton()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"it redirect to create user page")]
        public void ThenItRedirectToCreateUserPage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"sucess prompt message should appear")]
        public void ThenSucessPromptMessageShouldAppear()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
