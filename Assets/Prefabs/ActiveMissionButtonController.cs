using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace TakeTheSky
{
    public class ActiveMissionButtonController : MonoBehaviour
    {
        public Button ActiveMissionButton;
        public Text ActiveMissionButtonText;

        public void Initialize(Mission mission)
        {
            /*
                {mission name}
                {target}
                {launch year - arrival year}

                eg:
                    New Horizons
                    Pluto
                    2006-2015
             */
             ActiveMissionButtonText.text = BuildText(mission.Name, mission.Target.Name, mission.LaunchYear, mission.ArrivalYear);
        }

        private string BuildText(string missionName, string targetName, int launchYear, int arrivalYear)
        {
            var missionDetails = new StringBuilder();
            missionDetails.AppendLine(missionName);
            missionDetails.AppendLine(targetName);
            missionDetails.AppendLine($"{launchYear}-{arrivalYear}");
            return missionDetails.ToString();
        }
    }
}
