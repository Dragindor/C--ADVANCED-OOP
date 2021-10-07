using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Interfaces
{
    public class Repairs : IRepairs
    {
        public Repairs(string partName,int hours)
        {
            PartName = partName;
            Hours = hours;
        }

        public string PartName { get ; set ; }
        public int Hours  { get ; set ; }

        public override string ToString()
        {
            return $"Part Name: {PartName} Hours Worked: {Hours}";
        }
    }
}
