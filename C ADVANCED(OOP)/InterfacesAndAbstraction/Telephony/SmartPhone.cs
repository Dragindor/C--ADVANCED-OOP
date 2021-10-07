using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class SmartPhone : ICall, ISurf
    {
        public string Number { get; set; }
        public string Site { get; set; }

        internal void Surf(string site)
        {
            Console.WriteLine($"Browsing: {site}!");
        }

        internal void Call(string number)
        {
            Console.WriteLine($"Calling... {number}");
        }
    }
}
