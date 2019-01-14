using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TakeTheSky
{
    public class MissionController : MonoBehaviour
    {
        public Text CurrentYearText;
        public Text CurrentEpAmountText;

        public Transform ActiveMissionsParentContent;
        public GameObject ActiveMissionPrefab;

        public void EndYear()
        {
            CurrentState.CurrentYear++;
            CurrentState.CurrentEp += CurrentState.EpGainPerYear;
            ProcessArrivedMissions();

            CurrentYearText.text = $"{CurrentState.CurrentYear}";
            CurrentEpAmountText.text = $"{CurrentState.CurrentEp}";
        }

        public void LaunchMission()
        {
            int epCost = 1;
            CurrentState.CurrentEp -= epCost;

            Target target = new Target() { Name = "Default Target" };
            Explorer explorer = new Explorer() { Name = "Default Explorer" };
            int arrivalYear = CurrentState.CurrentYear + 2;
            Mission defaultMission = MissionBuilder.NewMission()
                .ToTarget(target)
                .UsingExplorer(explorer)
                .Costing(epCost)
                .LaunchingIn(CurrentState.CurrentYear)
                .ArrivingIn(arrivalYear)
                .Build();
            CurrentState.ActiveMissions.Add(arrivalYear, defaultMission);

            CurrentEpAmountText.text = $"{CurrentState.CurrentEp}";
            Instantiate(ActiveMissionPrefab, ActiveMissionsParentContent, false)
                .transform.Find("ActiveMissionUiComponentInitializer").GetComponent<ActiveMissionUiComponentInitializer>()
                .Initialize(explorer.Name, target.Name, CurrentState.CurrentYear, arrivalYear);
        }

        private void ProcessArrivedMissions()
        {
            List<Mission> arrivedMissions;
            bool anyMissionsArrivingThisYear = CurrentState.ActiveMissions.TryGetValue(CurrentState.CurrentYear, out arrivedMissions);

            if (anyMissionsArrivingThisYear)
            {
                foreach (var mission in arrivedMissions)
                {
                    mission.GenerateDataPacket();
                }
            }
        }
    }
}
