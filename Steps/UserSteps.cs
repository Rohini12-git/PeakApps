using NUnit.Framework;
using PeakApps.Common;
using PeakApps.Custom_Class;
using PeakApps.Settings;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace PeakApps.Steps
{
    [Binding]
    public class UserFeatureSteps
    {
        UserClass user = new UserClass();
        
        
        [When(@"I click on user tab ,it redirected to the user page")]
        public void WhenIClickOnUserTabItRedirectedToTheUserPage()
        {
            user.RedirectUser();
        }
        [Then(@"switch to Inactive user tab  from active user to check for tab functionality")]
        public void ThenSwitchToInactiveUserTabFromActiveUserToCheckForTabFunctionality()
        {
            user.ActiveInactiveUser();
        }

        
        [Then(@"Test ""(.*)"" by selecting element")]
        public void ThenTestBySelectingElement(string p0)
        {
            CommonUtility selectFacility = new CommonUtility();
            selectFacility.SelectFacility();
            user.selectAllFacility();
        }

        [Then(@"Test for search functionality\.")]
        public void ThenTestForSearchFunctionality_()
        {
            user.ActiveUserSearch();
        }
        [Then(@"Click on Create user Button to check its functionality")]
        public void ThenClickOnCreateUserButtonToCheckItsFunctionality()
        {
            user.CreateUserButton();
        }
        [Then(@"creat a user by assigning (.*),(.*),(.*),(.*),(.*)and(.*) and validate where user created or not")]
        public void ThenCreatAUserByAssigningAndAndValidateWhereUserCreatedOrNot(string FirstName, string LastName, string EmailAddress, string Role, string Facility,string HealthSystem)
        {
            user.CreateUser(FirstName, LastName, EmailAddress, Role, Facility, HealthSystem);
        }


        //[Then(@"creat a user by assigning (.*),(.*),(.*),(.*) and (.*) and validate where user created or not")]
        //public void ThenCreatAUserByAssigningAndAndValidateWhereUserCreatedOrNot(string FirstName, string LastName, string EmailAddress, string Role, string Facility)
        //{
        //    user.CreateUser(FirstName, LastName, EmailAddress, Role, Facility);
        //}
        [Then(@"validate the input field by living them blanks and click on save button\.")]
        public void ThenValidateTheInputFieldByLivingThemBlanksAndClickOnSaveButton_()
        {
            user.emptyuserValidate();
        }

        [Then(@"validate the first name and last name whether they take only letters or numbers\.")]
        public void ThenValidateTheFirstNameAndLastNameWhetherTheyTakeOnlyLettersOrNumbers_()
        {
            user.NameValidation();
        }

        [Then(@"validate the email address")]
        public void ThenValidateTheEmailAddress()
        {
            user.EmailValidation();
        }
        [Then(@"Validate a user field by assigning (.*),(.*),(.*),(.*),(.*) and leave one of the field empty to check validation")]
        public void ThenValidateAUserFieldByAssigningAndLeaveOneOfTheFieldEmptyToCheckValidation(string FirstName, string LastName, string EmailAddress, string Role, string Facility)
        {
            user.emptySinglefield(FirstName, LastName, EmailAddress, Role, Facility);
        }
        [Then(@"Count the Active user and filter Super Admin,Admin,Facility Admin,Auditor")]
        public void ThenCountTheActiveUserAndFilterSuperAdminAdminFacilityAdminAuditor()
        {
            user.activeUser();
        }
        [Then(@"Count the Active user and filter Super Admin,Admin,Facility Admin,Auditor and click on view button")]
        public void ThenCountTheActiveUserAndFilterSuperAdminAdminFacilityAdminAuditorAndClickOnViewButton()
        {
            user.View();
        }

        [Then(@"Click on Edit Button to check whether Super Admin can edit other user\.")]
        public void ThenClickOnEditButtonToCheckWhetherSuperAdminCanEditOtherUser_()
        {
            user.Edit();
        }

        [Then(@"Check for Add role whether Super Admin can assign multiple role to a user or not")]
        public void ThenCheckForAddRoleWhetherSuperAdminCanAssignMultipleRoleToAUserOrNot()
        {
            //ScenarioContext.Current.Pending();
        }


        [Given(@"User testNew User with view button")]
        public void GivenUserTestNewUserWithViewButton()
        {
            user.searchView();
        }
        [When(@"click on view button")]
        public void WhenClickOnViewButton()
        {
            user.viewButton();
        }

        [Then(@"it redirect to user role page")]
        public void ThenItRedirectToUserRolePage()
        {
            string Expectedurl = "https://peakqa.3m.com/#/user/detail";
            string Actualurl = ObjectRepository.driver.Url;
            Assert.AreEqual(Expectedurl, Actualurl);
        }

        [When(@"click on User Health Systems tab")]
        public void WhenClickOnUserHealthSystemsTab()
        {
            user.Hstab();
        }

        [Then(@"it redirect to user health system page")]
        public void ThenItRedirectToUserHealthSystemPage()
        {
            user.Hspage();
        }
         

        [Given(@"view button to enter user role page")]
        public void GivenViewButtonToEnterUserRolePage()
        {
            user.userRolePage();
        }

        [Then(@"count the facility and role a user having access")]
        public void ThenCountTheFacilityAndRoleAUserHavingAccess()
        {
            user.userRoleList();
        }


        [Given(@"Add health system button")]
        public void GivenAddHealthSystemButton()
        {
            user.VerifyAddHSButton();
        }


        [When(@"click on Add Health System button")]
        public void WhenClickOnAddHealthSystemButton()
        {
            user.clickHSButton();
        }

        [When(@"select health system from drpdown")]
        public void WhenSelectHealthSystemFromDrpdown()
        {
            user.SelectHS();
        }

        [When(@"click on Add button")]
        public void WhenClickOnAddButton()
        {
            user.AddButton();
        }

        [Then(@"message prompt ""(.*)""")]
        public void ThenMessagePrompt(string message)
        {
            string actualResult = user.sucessMsg();
            string expectedResult = message;
            Assert.AreEqual(expectedResult, actualResult);
        }
        [Given(@"List of health system a user having access")]
        public void GivenListOfHealthSystemAUserHavingAccess()
        {
            user.HealthSystemList();
        }

        [When(@"select a health system and click on remove button")]
        public void WhenSelectAHealthSystemAndClickOnRemoveButton()
        {
            Console.WriteLine("Removed hs");
        }

        
        [Then(@"that health system should removed and prompt message ""(.*)""")]
        public void ThenThatHealthSystemShouldRemovedAndPromptMessage(string message)
        {
            string actualResult = user.sucessMsg();
            string expectedResult = message;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Given(@"health system name ""(.*)""")]
        public void GivenHealthSystemName(string hsName)
        {
            user.GetHSName(hsName);
        }

        [Then(@"goto facility page to get the facilities having name attached with that hs")]
        public void ThenGotoFacilityPageToGetTheFacilitiesHavingNameAttachedWithThatHs()
        {
            FacilityClass facility = new FacilityClass();
            facility.facilityOfHs();
        }

        [Then(@"goto user role page")]
        public void ThenGotoUserRolePage()
        {
            user.UserRoleTab();
        }

        [Then(@"match that same facility should be available in user role page")]
        public void ThenMatchThatSameFacilityShouldBeAvailableInUserRolePage()
        {
            user.GetfacilityOfHs();
        }
        [Then(@"count the active users and click on inactive button of a user")]
        public void ThenCountTheActiveUsersAndClickOnInactiveButtonOfAUser()
        {
            user.CountActiveUser();
        }

        [Then(@"it should prompt a message that ""(.*)""")]
        public void ThenItShouldPromptAMessageThat(string expectedText)
        {
            string actualText = user.sucessMsg();
            Assert.AreEqual(actualText, expectedText);
        }
        [Then(@"switch to Inactive user tab  from active user\.")]
        public void ThenSwitchToInactiveUserTabFromActiveUser_()
        {
            user.SwitchInactive();
        }

        [Then(@"count the inactive users and click on active button of a user")]
        public void ThenCountTheInactiveUsersAndClickOnActiveButtonOfAUser()
        {
            user.CountInActiveUser();
        }

        



    }
}
