using System;

namespace Telephony
{
    internal interface ISurf
    {
        public string Site { get; set; }

        public void Surf(string site)
        {
            Console.WriteLine($"Browsing: {site}!");
        }
    }
}