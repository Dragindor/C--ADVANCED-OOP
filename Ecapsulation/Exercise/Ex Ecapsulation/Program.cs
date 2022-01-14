using System;
using System.Linq;

namespace ExEcapsulation
{
    public class Program
    {
        static void Main(string[] args)
        {
            double lenght = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            try
            {
                Box box = new Box(lenght, width, height);
                Console.WriteLine($"Surface Area - {2 * lenght * height + 2 * lenght * width + 2 * width * height:f02}");
                Console.WriteLine($"Lateral Surface Area - {2 * lenght * height + 2 * width * height:f02}");
                Console.WriteLine($"Volume - {lenght * width * height:f02}");
            }
            catch (ArgumentException ae)
            {

                Console.WriteLine(ae.Message);
            }
            
            
        }
    }
}
