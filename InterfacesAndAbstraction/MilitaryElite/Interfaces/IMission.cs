using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Interfaces
{
    public interface IMission
    {
        
        public string MissionName { get; set; }
        public string MissionProgress { get; set; }

        public void IMission();
    }
}
