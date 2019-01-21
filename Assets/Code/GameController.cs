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

        public MissionDetailsController MissionDetailsController;
        public DataPacketDetailsController DataPacketDetailsController;

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

            MissionDetailsController.AddActiveMissionButton(defaultMission);
            CurrentEpAmountText.text = $"{CurrentState.CurrentEp}";
        }

        public void EndYear()
        {
            CurrentState.CurrentYear++;
            CurrentState.CurrentEp += CurrentState.EpGainPerYear;
            ProcessArrivedMissions();

            CurrentYearText.text = $"{CurrentState.CurrentYear}";
            CurrentEpAmountText.text = $"{CurrentState.CurrentEp}";
            CurrentSpAmountText.text = $"{CurrentState.CurrentSp}";

            MissionDetailsController.TurnOffMissionsDisplay();
            DataPacketDetailsController.TurnOffDataPacketDetailsDisplay();
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
                    DataPacketDetailsController.AddDataPacket(dataPacket);
                    CurrentState.CurrentSp += SCIENCE_POINT_REWARDS.GetOrDefault(dataPacket.Category, 1);
                    if (mission.IsComplete())
                    {
                        MissionDetailsController.CompleteMission(mission);
                    }
                }
            }
        }
    }
}
