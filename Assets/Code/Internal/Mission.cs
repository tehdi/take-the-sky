using System.Collections.Generic;
using UnityEngine;

namespace TakeTheSky
{
    public class Mission
    {
        public string Name { get; }
        public int LaunchYear { get; }
        public int EpCost { get; }
        public Target Target { get; }
        public Explorer Explorer { get; }
        public int ArrivalYear { get; private set; }
        public List<DataPacket> DataPackets { get; private set; }
        private int MaximumDataPacketCount;
        public GameObject Button;

        public MissionStatus Status { get
        {
            return CurrentState.CurrentYear < ArrivalYear ? MissionStatus.EnRoute
                    : IsComplete() ? MissionStatus.Complete
                    : MissionStatus.DoingScience;
        }}

        public Mission(string name, int launchYear, int epCost, Target target, Explorer explorer, int arrivalYear)
        {
            Name = name;
            LaunchYear = launchYear;
            EpCost = epCost;
            Target = target;
            Explorer = explorer;
            ArrivalYear = arrivalYear;

            DataPackets = new List<DataPacket>();
        }

        public DataPacket GenerateDataPacket()
        {
            var dataPacket = new DataPacket();
            dataPacket.Category = UtilityMethods.RandomEnumValue<DataPacketCategory>();
            dataPacket.Mission = this;
            dataPacket.Target = Target;
            dataPacket.Year = CurrentState.CurrentYear;
            DataPackets.Add(dataPacket);
            return dataPacket;
        }

        public bool IsComplete() => DataPackets.Count >= MaximumDataPacketCount;
    }

    public enum MissionStatus
    {
        EnRoute, DoingScience, Complete
    }
}
