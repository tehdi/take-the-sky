using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TakeTheSky
{
    public class MissionController : MonoBehaviour
    {
        public Text CurrentYearText;
        public Text CurrentEpAmountText;

        public GameObject MissionDetailsController;
        public GameObject ActiveMissionPrefab;
        public Transform ActiveMissionsParentContent;
        public ToggleGroup ActiveMissionsToggleGroup;
        public Transform CompletedMissionsParentContent;
        public ToggleGroup CompletedMissionsToggleGroup;

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
                    if (mission.IsComplete())
                    {
                        CompleteMission(mission);
                    }
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
            AddActiveMissionButton(defaultMission);

            CurrentEpAmountText.text = $"{CurrentState.CurrentEp}";
        }

        private void AddActiveMissionButton(Mission mission)
        {
            var missionButtonInstance = Instantiate(ActiveMissionPrefab, ActiveMissionsParentContent, false);
            missionButtonInstance.GetComponent<Toggle>().group = ActiveMissionsToggleGroup.GetComponent<ToggleGroup>();
            missionButtonInstance.GetComponent<Toggle>().onValueChanged.AddListener(
                enabled => MissionDetailsController.GetComponent<MissionDetailsController>().ToggleMissionDetails(mission));
            missionButtonInstance.transform.Find("MissionToggleButtonController").GetComponent<MissionToggleButtonController>().Initialize(mission);
            mission.Button = missionButtonInstance;
        }

        private void CompleteMission(Mission mission)
        {
            mission.Button.transform.SetParent(CompletedMissionsParentContent, false);
            mission.Button.GetComponent<Toggle>().group = CompletedMissionsToggleGroup;
        }
    }
}
