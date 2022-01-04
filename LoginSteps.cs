using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using PeakApps.Custom_Class;
using System;
using TechTalk.SpecFlow;

namespace PeakApps
{
    [Binding]
    public class LoginSteps
    {
        //[Given(@"the url of the webapp")]
        //public void GivenTheUrlOfTheWebapp()
        //{
        //    LoginClass.url();
        //}


        [When(@"enter the ""(.*)"" and ""(.*)""")]
        public void WhenEnterTheAnd(string username, string password)
        {
            LoginClass.login(username, password);
        }

        [Then(@"user should lend to the dashboard page")]
        public void ThenUserShouldLendToTheDashboardPage()
        {
            LoginClass.dashboardVerify();
        }

        [When(@"click on logout button")]
        public void WhenClickOnLogoutButton()
        {
            LoginClass.logout();
        }

        [Then(@"it should lend to the login page")]
        public void ThenItShouldLendToTheLoginPage()
        {
            LoginClass.homePage();
        }

        

        [When(@"Click on Remember me checkbox")]
        public void WhenClickOnRememberMeCheckbox()
        {
            LoginClass.rememberMe();
        }

        [Then(@"it should get checked")]
        public void ThenItShouldGetChecked()
        {
            LoginClass.verifyRememberMe();
        }

        [When(@"Click on click here link")]
        public void WhenClickOnClickHereLink()
        {
            LoginClass.forgotPassword();
        }

        [Then(@"it should redirect to the url""(.*)""")]
        public void ThenItShouldRedirectToTheUrl(string p0)
        {
            LoginClass.verifyForgotLink();
        }

        [When(@"Click on Terms & Condition link")]
        public void WhenClickOnTermsConditionLink()
        {
            LoginClass.termCondition();
        }

        [Then(@"it should redirect to the END USER LICENSE AGREEMENT page")]
        public void ThenItShouldRedirectToTheENDUSERLICENSEAGREEMENTPage()
        {
            LoginClass.verifyLicenceAggrement();
        }

        [When(@"click on Accept button")]
        public void WhenClickOnAcceptButton()
        {
            LoginClass.Accept();
        }

        [Then(@"it should redirect to login page")]
        public void ThenItShouldRedirectToLoginPage()
        {
            LoginClass.verifytermConditionLink();
        }

    }
}
