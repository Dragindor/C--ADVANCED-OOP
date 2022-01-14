using System.Collections.Generic;

namespace MilitaryElite
{
    public interface ILieutenantGeneral
    {
        public ICollection<Private> Privates { get; set; }
    }
}