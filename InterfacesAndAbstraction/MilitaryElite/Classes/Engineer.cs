using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public ICollection<Repairs> repairs { get; set; }
        public Engineer(int id, string firstName, string lastName, decimal salary, string corps, List<Repairs> repairs) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.repairs = repairs;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f02}");
            sb.AppendLine($"Corps: {Corps}");
            sb.AppendLine($"Repairs:");
            foreach (var item in repairs)
            {
                sb.AppendLine($"  {item}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
