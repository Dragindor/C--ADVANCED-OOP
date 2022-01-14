using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Druid : BaseHero
    {
        public Druid(string name, int power) 
            : base(name, power)
        {
        }
        public override void CastAbility()
        {
            Console.WriteLine($"Druid - {Name} healed for {Power}");
        }
    }
}
