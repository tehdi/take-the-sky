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

        public GameObject MissionDetailsPanel;


        public void EndYear()
        {
            CurrentState.CurrentYear++;
            CurrentState.CurrentEp += CurrentState.EpGainPerYear;
            ProcessArrivedMissions();

            CurrentYearText.text = $"{CurrentState.CurrentYear}";
            CurrentEpAmountText.text = $"{CurrentState.CurrentEp}";
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

        public void LaunchMission()
        {
            int epCost = 1;
            CurrentState.CurrentEp -= epCost;

            Target target = new Target() { Name = "Default Target" };
            Explorer explorer = new Explorer();
            int arrivalYear = CurrentState.CurrentYear + 2;
            Mission defaultMission = MissionBuilder.NewMission()
                .Named("Default Mission")
                .ToTarget(target)
                .UsingExplorer(explorer)
                .Costing(epCost)
                .LaunchingIn(CurrentState.CurrentYear)
                .ArrivingIn(arrivalYear)
                .Build();
            CurrentState.ActiveMissions.Add(arrivalYear, defaultMission);
            AddMissionButton(defaultMission);

            CurrentEpAmountText.text = $"{CurrentState.CurrentEp}";
        }

        private void AddMissionButton(Mission mission)
        {
            var missionButtonInstance = Instantiate(ActiveMissionPrefab, ActiveMissionsParentContent, false);
            missionButtonInstance.GetComponent<Button>().onClick.AddListener(() => ToggleMissionDetails(mission));
            missionButtonInstance.transform.Find("ActiveMissionButtonController").GetComponent<ActiveMissionButtonController>().Initialize(mission);
            mission.MissionButton = missionButtonInstance.GetComponent<Button>();
        }

        private void ToggleMissionDetails(Mission mission)
        {
            if (MissionDetailsPanel.activeInHierarchy)
            {
                MissionDetailsPanel.SetActive(false);
            }
            else
            {
                MissionDetailsPanel.SetActive(true);
                
            }
        }
    }
}
