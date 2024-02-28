using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixingCode3
{
    class Laptop
    {
        private string _os;

        public string Os
        {
            get { return _os; }
            private set { _os = value; }
        }

        public Laptop(string os)
        {
            SetOs(os);
        }

        private void SetOs(string os)
        {
            _os = os;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var laptop = new Laptop("macOs");
            Console.WriteLine(laptop.Os);
        }
    }
}
