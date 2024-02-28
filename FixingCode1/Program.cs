using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixingCode1
{
    public class Application
    {
        public class Protected
        {
            public DateTime ShieldLastRun { get; set; }
        }

        public Protected protectedInfo { get; set; }
    }
    internal class Program
    {
        public static DateTime? GetShieldLastRun(Application application)
        {
            //Start Soal No 1
            if (application?.protectedInfo?.ShieldLastRun != null)
            {
                return application.protectedInfo.ShieldLastRun;
            }
            else
            {
                return null;
            }
            //End Soal No 1
        }
        static void Main(string[] args)
        {
        }
    }
}
