using PeakApps.Interface;
using PeakApps.Settings;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakApps.Configuration
{
    public class AppConfigReader : IConfig
    {
        public BrowserType GetBrowser()
        {
            string browsers = ConfigurationManager.AppSettings.Get(AppConfigKeys.browser);
            return (BrowserType)Enum.Parse(typeof(BrowserType), browsers);
        }

        public int GetLoadTimeOut()
        {
            string timeout= ConfigurationManager.AppSettings.Get(AppConfigKeys.loadTimeOut);
            if (timeout == null)
                return 30;
            return Convert.ToInt32(timeout);

        }

        public string GetPassword()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.Password);
        }

        public string GetUserName()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.UserName);
        }

        public string GetWebUrl()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.url);
        }
        public string GetFacilityName()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.facilityName);
        }
        public string GetFacilityNameForDataEntry()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.facilityforDataEntry);
        }
        public string GetFacilityNameForHealthSystem()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.facilityforHealthSystem);
        }
    }
}
