using System.Collections.Generic;

namespace TakeTheSky
{
    public class Mission
    {
        public int LaunchYear { get; }
        public int EpCost { get; }
        public Target Target { get; }
        public Explorer Explorer { get; }
        public int ArrivalYear { get; private set; }
        public List<DataPacket> DataPackets { get; private set; }

        public Mission(int launchYear, int epCost, Target target, Explorer explorer, int arrivalYear)
        {
            LaunchYear = launchYear;
            EpCost = epCost;
            Target = target;
            Explorer = explorer;
            ArrivalYear = arrivalYear;
        }

        public void GenerateDataPacket()
        {
            var dataPacket = new DataPacket() { Category = DataPacketCategory.Small };
            DataPackets.Add(dataPacket); 
        }
    }
}
