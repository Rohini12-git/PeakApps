using PeakApps.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakApps.Custom_Class
{
    public static class DataModal
    {
        public static PolicyDataModal policy = new PolicyDataModal();
        public static List<string> activePolicyName = new List<string>();
        public static List<string> dataentryQs { get; set; } = new List<string>();
        public static List<string> healthSystemFacility { get; set; } = new List<string>();
        public static string dataentryAns { get; set; }
        public static string activePolicy { get; set; }
        public static string hsname { get; set; }
    }
}
//policy.PolicyName