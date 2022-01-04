using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakApps.Common
{
   public  class PolicyDataModal
    {
        public string PolicyName { get; set; }
        public List<string> PolicyQuestions { get; set; } = new List<string>();
        public bool IsActive { get; set; }

    }
}
