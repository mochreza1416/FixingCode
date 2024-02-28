using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixingCode2
{
    internal class Program
    {
        public (string Path, string Name) GetInfo()
        {
            var application = new
            {
                Path = "C:/apps/",
                Name = "Shield.exe"
            };
            return (application.Path, application.Name);
        }
        static void Main(string[] args)
        {
        }
    }
}
