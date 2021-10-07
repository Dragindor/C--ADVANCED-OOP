using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : ICall
    {
        public string Number { get ; set ; }

        public void Call(string number)
        {
            System.Console.WriteLine($"Dialing... {number}");
        }
    }
}
