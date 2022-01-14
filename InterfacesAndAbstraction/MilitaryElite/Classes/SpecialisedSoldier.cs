using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier

    {
        public string Corps { get ; set; }

        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary,string corps) 
            : base(id, firstName, lastName, salary)
        {
            Corps = corps;
        }

        
    }
}
