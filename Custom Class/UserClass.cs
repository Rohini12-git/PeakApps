using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PeakApps.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PeakApps.Custom_Class
{
    class UserClass
    {
        By UsersTab = By.XPath("//p[contains(text(),'Users')]");
        By Inactive = By.XPath("//span[contains(text(),'Inactive Users')]");
        By Active = By.XPath("//span[contains(text(),'Active Users')]");
        By MakeInactive = By.XPath("//span[text()='Make Inactive']");
        By MakeActive = By.XPath("//span[text()='Make Active']");
        By Search = By.XPath("//input[@id='search']");
        By createUser = By.XPath("//span[contains(text(),'Create User')]");
        By firstName = By.XPath("//input[@id='firstName']");
        By lastName = By.XPath("//input[@id='lastName']");
        By closeIcon = By.XPath("//button[@class='close-button']");
        By Email = By.Id("emailAddress");
        By RoleType = By.XPath("//select[@id='role']");
        By submit = By.XPath("//button[@id='submit']");

        By sucess_message = By.XPath("//div[@class='message']");
        By EditButton = By.XPath("//li//div//div[@class='column-fixed'][2]");
        By FacilityText = By.XPath("//div[@class='header']");
        By CloseButton = By.XPath("//button[text()='Cancel']");

        By EditHS = By.XPath("//div[text()='Edit Health System']");
        By UserList = By.XPath("//li");
        By viewtestuser = By.XPath("//*[@type='text']//following::button[2]");
        By hstab = By.XPath("//*[text()='User Health Systems']");
        By hstext = By.XPath("//*[text()='Health System']");
        By hsbutton = By.XPath("//*[text()='Add Health System']");
        By selecths = By.XPath("//select[@id='healthSystem']");
        By addButton = By.XPath("//button[@name='save']");
        By userRoleTab = By.XPath("//*[@class='tab-label'and text()='User Roles']");
        By facilitycolumn = By.ClassName("column-facility");
        By FacilityDropdown = By.XPath("//section[@class='facility-selector']//span");
        By FacilityselectAll = By.XPath("//span[text()='All Facilities']");




        List<string> Rolelist = new List<string>();



        public void RedirectUser()
        {
            Thread.Sleep(3000);
            ObjectRepository.driver.FindElement(UsersTab).Click();
            

        }
        public  void ActiveInactiveUser()
        {
            
            ObjectRepository.driver.FindElement(Inactive).Click();
            
            Thread.Sleep(2000);
            
            ObjectRepository.driver.FindElement(Active).Click();
            
        }
        public void SwitchInactive()
        {
            ObjectRepository.driver.FindElement(Inactive).Click();

            Thread.Sleep(2000);
        }
        public void selectAllFacility()
        {
            Thread.Sleep(3000);
            ObjectRepository.driver.FindElement(FacilityDropdown).Click();

            ObjectRepository.driver.FindElement(FacilityselectAll).Click();
            //UserClass.FacilityDropDown();
        }

        //Need to implement random search
        public  void ActiveUserSearch()
        {
            
            string search = "test";
            ObjectRepository.driver.FindElement(Search).SendKeys(search);
            ObjectRepository.driver.FindElement(Search).Clear();

        }

        public  void CreateUser(string FirstName, string LastName, string EmailAddress, string Role, string Facility,string HealthSystem )
        {
           
            ObjectRepository.driver.FindElement(createUser).Click();
            
            
            ObjectRepository.driver.FindElement(firstName).Clear();

            ObjectRepository.driver.FindElement(firstName).SendKeys(FirstName);

            

            ObjectRepository.driver.FindElement(lastName).Clear();
            ObjectRepository.driver.FindElement(lastName).SendKeys(LastName);

            ObjectRepository.driver.FindElement(Email).SendKeys(EmailAddress);

            var roleselect = ObjectRepository.driver.FindElement(RoleType);
            var roleType = roleselect.Text;
            //create select element object 
            if (roleType.Contains(Role))
            {
                var selectElement = new SelectElement(roleselect);
                selectElement.SelectByText(Role);
            }


            //Select Facility Path.. if enable
            var facility = "//select[@id='facility']";
            var facilityselect = ObjectRepository.driver.FindElement(By.XPath(facility));
            var faciltyType = facilityselect.Text;
            if (facilityselect.Enabled)
            {
                if (Role == "Super Admin" || Role == "Admin")
                {
                    Assert.Fail();
                }
                else if (Role == "Facility Admin" || Role == "Auditor")
                {
                    //create select element object 
                    var selectElement1 = new SelectElement(facilityselect);
                    ObjectRepository.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                    //selectElement1.SelectByText(Facility);
                    selectElement1.SelectByIndex(2);
                }


            }

            //Select health system Path.. if enable
            var healthsystem = "//select[@id='healthSystem']";
            var hsselect = ObjectRepository.driver.FindElement(By.XPath(healthsystem));
            var hsType = hsselect.Text;
            if (hsselect.Enabled)
            {
                if (Role == "Super Admin" || Role == "Admin"|| Role == "Facility Admin" || Role == "Auditor")
                {
                    Assert.Fail();
                }
                else if (Role == "Health System Admin")
                {
                    //create select element object 
                    var selectElement1 = new SelectElement(hsselect);
                    ObjectRepository.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                    selectElement1.SelectByText(HealthSystem);
                    //selectElement1.SelectByIndex(2);
                }


            }


            //Click on submit button
            ObjectRepository.driver.FindElement(submit).Click();

            string text = ObjectRepository.driver.FindElement(sucess_message).Text;
            Console.WriteLine("Alert text is " + text);
            if (text == "There is already a record matching these details in the database."||text=="Please select a Facility for this User")
            {
                Thread.Sleep(1000);
                ObjectRepository.driver.FindElement(CloseButton).Click();
            }
            else if (text == "The user was created sucessfully .")
            {
                Console.WriteLine("User Created");
            }


        }
        public  void CreateUserButton()
        {
            ObjectRepository.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
           
            ObjectRepository.driver.FindElement(createUser).Click();
         

            bool res = ObjectRepository.driver.FindElement(closeIcon).Enabled;
            if (res)
            {
                Thread.Sleep(5000);
                ObjectRepository.driver.FindElement(closeIcon).Click();
            }
            else
            {
                Console.WriteLine("Element not visible till now");
            }

            ObjectRepository.driver.FindElement(createUser).Click();
            //Close button

            bool res1 = ObjectRepository.driver.FindElement(CloseButton).Enabled;
            if (res1)
            {
                ObjectRepository.driver.FindElement(CloseButton).Click();
            }
            else
            {
                Console.WriteLine("Cancel button is not visible");
            }


        }

        public  void emptyuserValidate()
        {
            
            ObjectRepository.driver.FindElement(createUser).Click();
            Thread.Sleep(2000);
            ObjectRepository.driver.FindElement(submit).Click();
            IWebElement txt =ObjectRepository.driver.FindElement(sucess_message);
            string text=txt.GetAttribute("innerHTML");
            Console.WriteLine("Alert text is " + text);
            if (text == "Please fill in all required fields underlined in red.")
            {
                Thread.Sleep(1000);

                ObjectRepository.driver.FindElement(CloseButton).Click();
            }
            else
            {
                Assert.Fail();
            }

        }

        public  void NameValidation()
        {
            
            ObjectRepository.driver.FindElement(createUser).Click();
            ObjectRepository.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

           
            string FirstName = "1234";
            ObjectRepository.driver.FindElement(firstName).Clear();

            ObjectRepository.driver.FindElement(firstName).SendKeys(FirstName);

            
            string LastName = "1234";


            ObjectRepository.driver.FindElement(lastName).Clear();
            ObjectRepository.driver.FindElement(lastName).SendKeys(LastName);

            //check email is enable/disable
             ObjectRepository.driver.FindElement(Email);

            string emailAddress = "EmailAddress@gmail.com";
            ObjectRepository.driver.FindElement(Email).SendKeys(emailAddress);
            //Select Role Path.. Faculty Admin or Auditor
            

            var roleselect = ObjectRepository.driver.FindElement(RoleType);

            //create select element object 

            var selectElement = new SelectElement(roleselect);
            selectElement.SelectByText("3M Super Admin");

            //Click on submit button
            ObjectRepository.driver.FindElement(submit).Click();
            string text = ObjectRepository.driver.FindElement(sucess_message).Text;
            Console.WriteLine("Alert text is " + text);
            if (text == "Name must be letters only")
            {

                ObjectRepository.driver.FindElement(CloseButton).Click();
            }

        }

        public  void EmailValidation()
        {
            
            ObjectRepository.driver.FindElement(createUser).Click();
            
            string FirstName = "First";
            ObjectRepository.driver.FindElement(firstName).Clear();

            ObjectRepository.driver.FindElement(firstName).SendKeys(FirstName);

            string LastName = "Last";
            ObjectRepository.driver.FindElement(lastName).Clear();
            ObjectRepository.driver.FindElement(lastName).SendKeys(LastName);

            //check email is enable/disable
            var email = ObjectRepository.driver.FindElement(Email);



            string emailAddress = "EmailAddress";
            ObjectRepository.driver.FindElement(Email).SendKeys(emailAddress);
            //Select Role Path.. Faculty Admin or Auditor
            
            var roleselect = ObjectRepository.driver.FindElement(RoleType);

            //create select element object 

            var selectElement = new SelectElement(roleselect);
            selectElement.SelectByText("3M Super Admin");

            //Click on submit button
            ObjectRepository.driver.FindElement(By.XPath("//button[@id='submit']")).Click();
            string text = ObjectRepository.driver.FindElement(By.XPath("//div[@class='message']")).Text;
            Console.WriteLine("Alert text is " + text);
            if (text == "The email address entered is invalid.")
            {

                ObjectRepository.driver.FindElement(CloseButton).Click();
            }
            else
            {
                Assert.Fail();
            }


        }

        public  void emptySinglefield(string FirstName, string LastName, string EmailAddress, string Role, string Facility)
        {
            
            ObjectRepository.driver.FindElement(createUser).Click();
            ObjectRepository.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            
            ObjectRepository.driver.FindElement(firstName).Clear();

            ObjectRepository.driver.FindElement(firstName).SendKeys(FirstName);


            ObjectRepository.driver.FindElement(lastName).Clear();
            ObjectRepository.driver.FindElement(lastName).SendKeys(LastName);

            //check email is enable/disable
            var email = ObjectRepository.driver.FindElement(Email);

            ObjectRepository.driver.FindElement(Email).SendKeys(EmailAddress);
            //Select Role Path.. Faculty Admin or Auditor
            

            var roleselect = ObjectRepository.driver.FindElement(RoleType);
            var roleType = roleselect.Text;
            //create select element object 
            if (roleType.Contains(Role))
            {
                var selectElement = new SelectElement(roleselect);
                selectElement.SelectByText(Role);
            }


            //Select Facility Path.. if enable
            var facility = "//select[@id='facility']";
            var facilityselect = ObjectRepository.driver.FindElement(By.XPath(facility));
            var faciltyType = facilityselect.Text;
            if (facilityselect.Enabled)
            {
                if (Role == "3M Super Admin" || Role == "3M Admin")
                {
                    Assert.Fail();
                }
                else if (Role == "Facility Admin" || Role == "Facility Auditor")
                {
                    //create select element object 
                    var selectElement1 = new SelectElement(facilityselect);
                    ObjectRepository.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                    //selectElement1.SelectByText(Facility);
                    selectElement1.SelectByIndex(2);
                }
            }
            //Click on submit button
            ObjectRepository.driver.FindElement(submit).Click();

            string text = ObjectRepository.driver.FindElement(sucess_message).Text;
            Console.WriteLine("Alert text is " + text);
            Assert.IsTrue(text.Equals("Please select a valid Role from the list") || text.Equals("Please fill in all required fields underlined in red.") || text.Equals("Something went wrong, please try again"), text + " doesn't contains actual value'");
            if(text.Equals("Please select a valid Role from the list") || text.Equals("Please fill in all required fields underlined in red.") || text.Equals("Something went wrong, please try again")){
                ObjectRepository.driver.FindElement(CloseButton).Click();
            }

        }
        public void CountActiveUser()
        {
            Thread.Sleep(15000);
            IList<IWebElement> activeUsers = null;
            activeUsers = ObjectRepository.driver.FindElements(UserList);
            int count = activeUsers.Count;
            for (int i = 0; i < count; i++)
            {
               
                string actualvalue = activeUsers[i].Text;
                Console.WriteLine(actualvalue);
              
            }
            IWebElement inactiveButton = activeUsers[5].FindElement(By.XPath("//button[text()=' Inactive ']"));
            inactiveButton.Click();

        }
        public void CountInActiveUser()
        {
            Thread.Sleep(15000);
            IList<IWebElement> inactiveUsers = null;
            inactiveUsers = ObjectRepository.driver.FindElements(UserList);
            int count = inactiveUsers.Count;
            for (int i = 0; i < count; i++)
            {

                string actualvalue = inactiveUsers[i].Text;
                Console.WriteLine(actualvalue);

            }
            IWebElement activeButton = inactiveUsers[5].FindElement(By.XPath("//button[text()=' Active ']"));
            activeButton.Click();

        }
        public  void activeUser()
        {
            IList<IWebElement> products = null;
            Thread.Sleep(15000);
            List<string> allUserRoles = new List<string>() { "Super Admin", "Admin", "Facility Admin", "Auditor" };
            List<int> userIndex = new List<int>();
            WebDriverWait wait = new WebDriverWait(ObjectRepository.driver, TimeSpan.FromSeconds(20));
            wait.Until(driver => driver.FindElements(UserList));
            products = ObjectRepository.driver.FindElements(UserList);
            //Thread.Sleep(10000);
            //products = ObjectRepository.driver.FindElements(By.ClassName("row-container"));
            int count = products.Count;
            for (int i = 0; i <count; i--)
            {
                Thread.Sleep(5000);
                string actualvalue = products[i].Text;
                Console.WriteLine(actualvalue);
                List<IWebElement> columns = products[i].FindElements(By.TagName("div")).ToList();

                Console.WriteLine("Number of columns:" + columns.Count());


                for (int j = 0; j < columns.Count(); j++)

                {

                    var col_val = columns[j].Text;
                    //  userIndex.Add(j); 

                    var role = columns[j].FindElement(By.ClassName("column-roles"));
                    var buttons = columns[j].FindElement(By.TagName("button"));



                    foreach (var data in allUserRoles)
                    {
                        Console.WriteLine(role.Text);

                        if (data.Equals(role.Text))
                        {

                            Console.WriteLine(buttons.Text);
                            buttons.Click();
                            allUserRoles.Remove(data);
                            break;

                        }

                    }
                    break;
                }

            }




        }
        public  void View()
        {
            IList<IWebElement> products = null;
            Thread.Sleep(5000);
            List<string> allUserRoles = new List<string>() { "Super Admin", "Admin", "Facility Admin", "Facility Auditor" };
            List<int> userIndex = new List<int>();
            products = ObjectRepository.driver.FindElements(UserList);
            Thread.Sleep(5000);
            //products = ObjectRepository.driver.FindElements(By.ClassName("row-container"));
            int count = products.Count;
            for (int i = 0; i < count; i++)
            {
                Thread.Sleep(5000);
                string actualvalue = products[i].Text;
                Console.WriteLine(actualvalue);
                List<IWebElement> columns = products[i].FindElements(By.TagName("div")).ToList();

                Console.WriteLine("Number of columns:" + columns.Count());


                for (int j = 0; j < columns.Count(); j++)

                {

                    var col_val = columns[j].Text;
                    //  userIndex.Add(j); 

                    var role = columns[j].FindElement(By.ClassName("column-roles"));
                    var buttons = columns[j].FindElements(By.TagName("button"));
                    var last_button = buttons.Last().Text;



                    foreach (var data in allUserRoles)
                    {
                        Console.WriteLine(role.Text);

                        if (data.Equals(role.Text))
                        {

                            Console.WriteLine(buttons.Last().Text);
                            buttons.Last().Click();
                            allUserRoles.Remove(data);
                            ObjectRepository.driver.Navigate().Back();
                            //Edit();
                            break;

                        }

                    }
                    break;
                }

            }

        }


        public  void Edit()
        {
            List<string> allUserRoles = new List<string>() { "Super Admin", "Admin", "Facility Admin", "Auditor" };
            IList<IWebElement> products = null;
            products = ObjectRepository.driver.FindElements(By.XPath("//li//div[1]//div[2]//div[1]"));
            int count = products.Count;
            List<int> userIndex = new List<int>();
            for (int i = 0; i < count; i++)
            {
                string actualvalue = products[i].Text;
                Console.WriteLine(actualvalue);

                foreach (var data in allUserRoles)
                {
                    if (actualvalue.IndexOf(data) == 0)
                    {
                        Console.WriteLine(data);
                        userIndex.Add(i);
                        allUserRoles.Remove(data);
                        break;
                    }

                }
            }
            userIndex.Reverse();
            foreach (var index in userIndex)
            {
                //ObjectRepository.driver.FindElements(By.XPath("//li//div[1]//div[2]//div[1]"))[index].FindElement(By.XPath("//button[contains(text(),'View')]")).Click();
                var view_email = "//span[@class='email-address']";
                var mail = ObjectRepository.driver.FindElement(By.XPath(view_email)).Text;
                Console.WriteLine(mail);
                if (mail.Equals(ObjectRepository.config.GetUserName()))
                {
                    ObjectRepository.driver.Navigate().Back();


                }
                else
                {

                    Edits();
                    ObjectRepository.driver.Navigate().Back();
                }

            }
        }

        public  void Edits()
        {

            string EditXpath = "/html[1]/body[1]/app-root[1]/div[1]/div[1]/ng-component[1]/div[1]/div[2]/div[2]/button[2]";
            ObjectRepository.driver.FindElement(By.XPath(EditXpath)).Click();
            // close icon
            var icon = "//button[@class='close-button']";

            bool res = ObjectRepository.driver.FindElement(closeIcon).Enabled;
            if (res)
            {
                ObjectRepository.driver.FindElement(closeIcon).Click();
            }
            else
            {
                Console.WriteLine("Element not visible till now");
            }

            ObjectRepository.driver.FindElement(By.XPath(EditXpath)).Click();
            //Close button


            
            bool res1 = ObjectRepository.driver.FindElement(CloseButton).Enabled;
            if (res1)
            {
                ObjectRepository.driver.FindElement(CloseButton).Click();
            }
            else
            {
                Console.WriteLine("Cancel button is not visible");
            }

            //user info

            ObjectRepository.driver.FindElement(By.XPath(EditXpath)).Click();
            ObjectRepository.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            
            string FirstName = "peakadmin1234";
            ObjectRepository.driver.FindElement(firstName).Clear();

            ObjectRepository.driver.FindElement(firstName).SendKeys(FirstName);

            string LastName = "mmmPeak@1234vvj";
            ObjectRepository.driver.FindElement(lastName).Clear();
            ObjectRepository.driver.FindElement(lastName).SendKeys(LastName);

            //check email is enable/disable
            var email = ObjectRepository.driver.FindElement(Email);

            Console.WriteLine(email);
            if (email.Enabled)
            {

                string emailAddress = "mmmPeak@1234";
                ObjectRepository.driver.FindElement(Email).SendKeys(emailAddress);
                Assert.Fail();
            }
            //save button
            ObjectRepository.driver.FindElement(submit).Click();


        }

        public void searchView()
        {
            
                string search = "testNew User";
                ObjectRepository.driver.FindElement(Search).SendKeys(search);                                                
        }
        public void viewButton()
        {
            ObjectRepository.driver.FindElement(viewtestuser).Click();
        }
        public void Hstab()
        {
            ObjectRepository.driver.FindElement(hstab).Click();
        }
        public void Hspage()
        {
            Thread.Sleep(3000);
            string text = ObjectRepository.driver.FindElement(hstext).Text;
            Assert.AreEqual(text, "Health System");
            
        }
        public bool VerifyAddHSButton()
        {
            searchView();
            viewButton();
            Hstab();
            bool displayhsButton=ObjectRepository.driver.FindElement(hsbutton).Displayed;
            if (displayhsButton)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public void clickHSButton()
        {
            ObjectRepository.driver.FindElement(hsbutton).Click();

        }
        public void SelectHS()
        {
            IWebElement element = ObjectRepository.driver.FindElement(selecths);
            SelectElement oSelect = new SelectElement(element);
            oSelect.SelectByText("TestAutoHS");
            Thread.Sleep(3000);

        }
        public void AddButton()
        {
            ObjectRepository.driver.FindElement(addButton).Click();
        }
        public string sucessMsg()
        {
            string text = ObjectRepository.driver.FindElement(sucess_message).Text;
            Console.WriteLine("Alert text is " + text);
            return text;
        }
        
        public void HealthSystemList() {
            searchView();
            viewButton();
            Hstab();
            IList<IWebElement> hslist = null;
            hslist = ObjectRepository.driver.FindElements(By.XPath("//div[@class='row-container ']"));
            int count = hslist.Count;
            DataModal.hsname = hslist[1].FindElement(facilitycolumn).Text;
            hslist[1].FindElement(By.ClassName("column-fixed")).Click();


            //for (int i = 0; i <= count; i++)
            //{
            //    List<IWebElement> columns = hslist[i].FindElements(By.ClassName("row-container")).ToList();

            //    Console.WriteLine("Number of columns:" + columns.Count());


            //    for (int j = 0; j < columns.Count(); j++)

            //    {

            //        var col_val = columns[j].Text;
            //        //  userIndex.Add(j); 

            //        var hsname = columns[j].FindElement(By.ClassName("column-facility "));
            //        var button = columns[j].FindElement(By.TagName("button"));
            //        var last_button = button.Text;

            //        string hsnameText = hsname.Text;
            //        button.Click();

            //    }
            //}



        }
        public void userRoleList()
        {
            
            IList<IWebElement> userRolelist = null;
            userRolelist = ObjectRepository.driver.FindElements(By.XPath("//div[@class='row-container ']"));
            int count = userRolelist.Count;
            for(int i = 0; i < count; i++) {
            string facility = userRolelist[i].FindElement(facilitycolumn).Text;
            string role = userRolelist[i].FindElement(By.ClassName("column-roles")).Text;
            Rolelist.Add(role);
                //userRolelist[1].FindElement(By.ClassName("column-fixed")).Click();
            }
            List<string> roleCount = Rolelist;
        }
        public void userRolePage()
        {
            searchView();
            viewButton();
        }
        public void GetHSName(string hsName)
        {
            RedirectUser();
            userRolePage();
            Hstab();
            //string hsNames= DataModal.hsname;
            Assert.AreEqual(hsName, "TestAutoHS");

        }
        public void UserRoleTab()
        {
            ObjectRepository.driver.FindElement(userRoleTab).Click();
        }
        public void GetfacilityOfHs()
        {
            List<string> hsfacility = DataModal.healthSystemFacility;
            IList<IWebElement> facility = ObjectRepository.driver.FindElements(facilitycolumn);
            int countFacility = facility.Count;
            for(int i=0;i< countFacility; i++)
            {
                if (hsfacility.Contains(facility[i].Text))
                {
                    Console.WriteLine(facility[i].Text);
                }
            }


        }

    }

    }


