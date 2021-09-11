using System.Diagnostics;
using System.Reflection;

namespace Reminder.Api
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
