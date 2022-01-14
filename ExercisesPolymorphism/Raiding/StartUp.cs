using System;
using System.Collections.Generic;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<BaseHero> party = new List<BaseHero>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                string Type = Console.ReadLine().ToLower();
                if (Type=="druid")
                {
                    Druid druid = new Druid(name,80);
                    party.Add(druid);
                }
                else if (Type == "paladin")
                {
                    Paladin paladin = new Paladin(name,100);
                    party.Add(paladin);
                }
                else if (Type == "warrior")
                {
                    Warrior warrior = new Warrior(name, 100);
                    party.Add(warrior);
                }
                else if (Type == "rogue")
                {
                    Rogue rogue = new Rogue(name, 80);
                    party.Add(rogue);

                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                    i--;
                }

            }
            int bossPower =int.Parse(Console.ReadLine());
            int power=0;
            foreach (var item in party)
            {
                item.CastAbility();
                power += item.Power;
            }
            if (power>=bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
