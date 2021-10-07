using System;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] sites = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            SmartPhone smartPhone = new SmartPhone();
            ICall stationaryPhone = new StationaryPhone();
            for (int i = 0; i < numbers.Length; i++)
            {
                bool valid = true;
                char[] validNum = numbers[i].ToCharArray();
                for (int j = 0; j < validNum.Length; j++)
                {
                    if (!Char.IsDigit(validNum[j]))
                    {
                        valid = false;
                    }
                }
                if (!valid)
                {
                    Console.WriteLine("Invalid number!");
                    continue;
                }
                if (numbers[i].Length==10)
                {
                    smartPhone.Call(numbers[i]);
                }
                else
                {
                    stationaryPhone.Call(numbers[i]);
                }
            }
            for (int i = 0; i < sites.Length; i++)
            {
                bool valid = true;
                char[] validNum = sites[i].ToCharArray();
                for (int j = 0; j < validNum.Length; j++)
                {
                    if (Char.IsDigit(validNum[j]))
                    {
                        valid = false;
                    }
                }
                if (valid)
                {
                    smartPhone.Surf(sites[i]);
                }
                else
                {
                    Console.WriteLine("Invalid URL!");
                }
            }
        }
    }
}
