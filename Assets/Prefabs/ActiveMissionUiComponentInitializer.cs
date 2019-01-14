using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace TakeTheSky
{
    public class ActiveMissionUiComponentInitializer : MonoBehaviour
    {
        public Text ActiveMissionButtonText;

        public void Initialize(string missionName, string targetName, int launchYear, int arrivalYear)
        {
            /*
                {mission name} (actually the explorer name. all missions are named after their explorers)
                {target}
                {launch year - arrival year}

                eg:
                    New Horizons
                    Pluto
                    2006-2015
             */
             ActiveMissionButtonText.text = BuildText(missionName, targetName, launchYear, arrivalYear);
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
