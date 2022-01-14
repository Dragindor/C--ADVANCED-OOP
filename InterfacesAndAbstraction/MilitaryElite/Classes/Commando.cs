using MilitaryElite.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public ICollection<Mission> Missions { get; set; }
        public Commando(int id, string firstName, string lastName, decimal salary, string corps,List<Mission> missions) 
            : base(id, firstName, lastName, salary, corps)
        {
            Missions = missions ;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f02}");
            sb.AppendLine($"Corps: {Corps}");
            sb.AppendLine($"Missions:");
            foreach (var item in Missions)
            {
                sb.AppendLine($"  {item}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
