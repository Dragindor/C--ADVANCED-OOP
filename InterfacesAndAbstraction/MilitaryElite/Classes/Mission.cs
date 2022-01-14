using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Classes
{
    public class Mission : IMission
    {
        public Mission(string missionName, string missionProgress)
        {
            MissionName = missionName;
            MissionProgress = missionProgress;
        }
        public string MissionName     { get ; set ; }
        public string MissionProgress { get ; set ; }

        public void IMission()
        {
            MissionProgress = "Finished";
        }

        public override string ToString()
        {
            return $"Code Name: {MissionName} State: {MissionProgress}";
        }
    }
}
