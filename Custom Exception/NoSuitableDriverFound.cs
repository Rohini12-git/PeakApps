using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakApps.Custom_Exception
{
   public class NoSuitableDriverFound:Exception
    {
        public  NoSuitableDriverFound(string msg) : base(msg)
        {

        }

    }
}
