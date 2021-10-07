using MilitaryElite.Classes;
using System.Collections.Generic;

namespace MilitaryElite
{
    public interface ICommando
    {
        public ICollection<Mission> Missions { get; set; }
    }
}