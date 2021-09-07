using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Reminder_Api
{
    public abstract class Version
    {
        public static string ProductVersion
        {
            get
            {
                var productVersion = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion;

                var indexOfPlus = productVersion.IndexOf('+');
                return productVersion.Remove(indexOfPlus);
            }
        }
    }
}
