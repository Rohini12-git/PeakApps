using OpenQA.Selenium;
using PeakApps.Configuration;
using PeakApps.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakApps.Settings
{
   public class ObjectRepository
    {
        public static IConfig config
        {
            get
            {
                return new AppConfigReader();
            }
        }
       // public static IConfig config{ get; set;}
        public static IWebDriver driver { get; set; }
    }
}
 