using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using PeakApps.Common;
using PeakApps.Settings;
using System;
using System.Configuration;
using System.IO;
using System.Threading;
using TechTalk.SpecFlow;

namespace PeakApps
{
    [Binding]
    public sealed class EventHooks
    {
        public static ExtentTest featureName;
        public static ExtentTest scenario;
        public static ExtentReports extent;
        

        [BeforeTestRun]
        public static void launchBrowser()
        {
            DriverUtility.OpenDriver();
            InitializeReport();
        }
        public static void InitializeReport()
        {
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\Rohini\source\repos\PeakApps\Test_Execution_Reports\Reports.html");
            htmlReporter.Configuration().Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            htmlReporter.Configuration().DocumentTitle = "SpecFlow Test Report Document";

            htmlReporter.Configuration().ReportName = "Feature Run Results";


            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);


        }
        public static string Capture(IWebDriver driver, string screenShotName)
        {
            string localpath = "";
            try
            {
                Console.WriteLine(screenShotName);
                Thread.Sleep(4000);

                var takesScreenshot = ObjectRepository.driver as ITakesScreenshot;
                var screenshot = takesScreenshot.GetScreenshot();
                string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
                var dir = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
                DirectoryInfo di = Directory.CreateDirectory(dir + "\\Defect_Screenshots\\");
                string finalpth = pth.Substring(0, pth.LastIndexOf("bin")) + "\\Defect_Screenshots\\" + screenShotName + ".png";
                localpath = new Uri(finalpth).LocalPath;
                screenshot.SaveAsFile(localpath);
            }
            catch (Exception e)
            {
                throw (e);
            }
            return localpath;
        }

        public static void TakeScreenShot(ScenarioContext scenarioContext)
        {
            var stepContext = scenarioContext.StepContext;
            var status = "Failed";
            Console.WriteLine(status);
            var stacktrace1 = scenarioContext.TestError.StackTrace;
            Console.WriteLine(stacktrace1);
            var errorMessage = scenarioContext.TestError.Message;
            Status logstatus;
            Console.WriteLine(status);
            switch (status)
            {
                case "Failed":
                    logstatus = Status.Fail;
                    string screenShotPath = Capture(ObjectRepository.driver, stepContext.StepInfo.Text);
                    Console.WriteLine(screenShotPath);
                    scenario.Log(logstatus, "Test ended with " + logstatus.ToString() + " – " + errorMessage);
                    scenario.Log(logstatus, "Snapshot below: " + scenario.AddScreenCaptureFromPath(screenShotPath));
                    break;
                case "Passed":
                    logstatus = Status.Pass;
                    scenario.Log(logstatus, "Test ended with " + logstatus);
                    break;
                default:
                    logstatus = Status.Pass;
                    scenario.Log(logstatus, "Test ended with " + logstatus);
                    break;


            }
        }
        [BeforeFeature]
       
        public static void BeforeFeature( FeatureContext featureContext)
        {
            Authentication auth = new Authentication(ObjectRepository.driver);
            auth.LaunchBrowser();
            auth.typeEmailId();
            auth.typePassword();
            auth.clickSignIn();
            auth.dashboardVerify();
            

            featureName = extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);

        }
        [BeforeScenario]

       
        public static void BeforeScenario(ScenarioContext scenarioContext)
        {
            //LoginClass.url();

            //TODO: implement logic that has to run before executing each scenario
            scenario = featureName.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }
        [AfterStep]
        
        public void InsertReportingSteps(ScenarioContext scenarioContext)
        {
            var stepContext = scenarioContext.StepContext;
            var stepType = stepContext.StepInfo.StepDefinitionType.ToString();
            if (scenarioContext.TestError == null)
            {

                if (stepType == "Given")
                {
                    scenario.CreateNode<Given>(stepContext.StepInfo.Text);

                }
                else if (stepType == "When")
                {
                    scenario.CreateNode<When>(stepContext.StepInfo.Text);

                }
                else if (stepType == "Then")
                {
                    scenario.CreateNode<Then>(stepContext.StepInfo.Text);


                }

            }
            else if (scenarioContext.TestError != null)
            {

                if (stepType == "Given")
                {
                    scenario.CreateNode<Given>(stepContext.StepInfo.Text).Fail(scenarioContext.TestError.Message);
                    TakeScreenShot(scenarioContext);

                }
                else if (stepType == "When")
                {
                    scenario.CreateNode<When>(stepContext.StepInfo.Text).Fail(scenarioContext.TestError.Message);
                    TakeScreenShot(scenarioContext);


                }
                else if (stepType == "Then")
                {
                    scenario.CreateNode<Then>(stepContext.StepInfo.Text).Fail(scenarioContext.TestError.Message);

                    TakeScreenShot(scenarioContext);

                }
            }


        }

        [AfterScenario]
        public static void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
        }
        [AfterFeature]
        public static void AfterFeature()
       {
            Authentication logout = new Authentication(ObjectRepository.driver);
            logout.clickLogout();
        }
        [AfterTestRun]
        public static void TearDownReport()
        {
            extent.Flush();
            ObjectRepository.driver.Close();
            ObjectRepository.driver.Quit();
        }
    }
}
