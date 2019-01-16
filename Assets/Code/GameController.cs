using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TakeTheSky
{
    public class GameController : MonoBehaviour
    {
        private static readonly Dictionary<DataPacketCategory, int> SCIENCE_POINT_REWARDS = new Dictionary<DataPacketCategory, int>
        {
            [DataPacketCategory.Small] = 3,
            [DataPacketCategory.Medium] = 5,
            [DataPacketCategory.Large] = 8,
            [DataPacketCategory.Photo] = 10
        };

        public Text CurrentYearText;
        public Text CurrentEpAmountText;
        public Text CurrentSpAmountText;

        public GameObject MissionDetailsController;
        public GameObject MissionToggleButtonPrefab;
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
            CurrentSpAmountText.text = $"{CurrentState.CurrentSp}";
            MissionDetailsController.GetComponent<MissionDetailsController>().TurnOffMissionsDisplay();
        }

        private void ProcessArrivedMissions()
        {
            List<Mission> arrivedMissions;
            bool anyMissionsArrivingThisYear = CurrentState.ActiveMissions.TryGetValue(CurrentState.CurrentYear, out arrivedMissions);

            if (anyMissionsArrivingThisYear)
            {
                foreach (var mission in arrivedMissions)
                {
                    DataPacket dataPacket = mission.GenerateDataPacket();
                    CurrentState.CurrentSp += SCIENCE_POINT_REWARDS.GetOrDefault(dataPacket.Category, 1);
                    if (mission.IsComplete())
                    {
                        CompleteMission(mission);
                    }
                }
            }
        }

        private void CompleteMission(Mission mission)
        {
            Destroy(mission.Button); // the old button is attached to all the "active" group stuff

            var missionButtonInstance = Instantiate(MissionToggleButtonPrefab, CompletedMissionsParentContent, false);
            missionButtonInstance.GetComponent<Toggle>().group = CompletedMissionsToggleGroup.GetComponent<ToggleGroup>();
            missionButtonInstance.GetComponent<Toggle>().onValueChanged.AddListener(
                enabled => MissionDetailsController.GetComponent<MissionDetailsController>().ToggleCompletedMissionDetails(mission));
            missionButtonInstance.transform.Find("MissionToggleButtonController").GetComponent<MissionToggleButtonController>().Initialize(mission);
            mission.Button = missionButtonInstance;
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
            var missionButtonInstance = Instantiate(MissionToggleButtonPrefab, ActiveMissionsParentContent, false);
            missionButtonInstance.GetComponent<Toggle>().group = ActiveMissionsToggleGroup.GetComponent<ToggleGroup>();
            missionButtonInstance.GetComponent<Toggle>().onValueChanged.AddListener(
                enabled => MissionDetailsController.GetComponent<MissionDetailsController>().ToggleActiveMissionDetails(mission));
            missionButtonInstance.transform.Find("MissionToggleButtonController").GetComponent<MissionToggleButtonController>().Initialize(mission);
            mission.Button = missionButtonInstance;
        }
    }
}
