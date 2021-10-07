using System;

namespace Telephony
{
    public interface ICall
    {
        public string Number { get; set; }
        public void Call(string number)
        {
            Console.WriteLine($"Calling... {number}");
        }
    }
}