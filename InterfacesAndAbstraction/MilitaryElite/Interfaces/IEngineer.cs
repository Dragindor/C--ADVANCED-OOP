using MilitaryElite.Interfaces;
using System.Collections.Generic;

namespace MilitaryElite
{
    public interface IEngineer
    {
        public ICollection<Repairs> repairs { get; set; }
    }
}