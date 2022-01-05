using PeakApps.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakApps.Interface
{
   public interface IConfig
    {
        BrowserType GetBrowser();
        string GetWebUrl();
        string GetUserName();
        string GetPassword();
        int GetLoadTimeOut();
        string GetFacilityName();
        string GetFacilityNameForDataEntry();
        string GetFacilityNameForHealthSystem();
    }
}
