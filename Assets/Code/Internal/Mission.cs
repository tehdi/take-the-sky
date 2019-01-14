using System.Collections.Generic;
using UnityEngine.UI;

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

        public Button MissionButton;

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

        public void GenerateDataPacket()
        {
            var dataPacket = new DataPacket() { Category = DataPacketCategory.Small };
            DataPackets.Add(dataPacket); 
        }
    }
}
