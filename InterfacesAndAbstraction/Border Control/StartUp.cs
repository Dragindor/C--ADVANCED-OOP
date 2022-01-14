using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Citizen> citizens = new List<Citizen>();
            List<Rebel> rebels = new List<Rebel>();
            int n = int.Parse(Console.ReadLine());
            int food = 0;
            for (int i = 0; i < n; i++)
            {
                string[] GoingIn = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                
                if (GoingIn.Length == 4)
                {
                    Citizen person = new Citizen(GoingIn[0],int.Parse(GoingIn[1]),GoingIn[2],GoingIn[3]);
                    citizens.Add(person);

                }
                else if (GoingIn.Length == 3 )
                {
                    Rebel person = new Rebel(GoingIn[0], int.Parse(GoingIn[1]), GoingIn[2]);
                    rebels.Add(person);
                }
            }
            while (true)
            {
                string name = Console.ReadLine();
                if (name == "End")
                {
                    break;
                }
                
                var found =citizens.Find(x=>x.Name==name);
                if (found!=null)
                {
                    food += 10;
                }
                else if (rebels.Find(x => x.Name == name)!=null)
                {
                    food += 5;
                }
                
                
            }
            Console.WriteLine(food);
            
            
        }
    }
}
