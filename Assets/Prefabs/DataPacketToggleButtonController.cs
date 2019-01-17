using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace TakeTheSky
{
    public class DataPacketToggleButtonController : MonoBehaviour
    {
        public Toggle DataPacketToggleButton;
        public Text DataPacketToggleButtonText;

        public void Initialize(DataPacket dataPacket)
        {
            /*
                {target}
                {mission name}
                {year}

                eg:
                    Pluto
                    New Horizons
                    2015
             */
            DataPacketToggleButtonText.text = BuildText(dataPacket.Target.Name, dataPacket.Mission.Name, dataPacket.Year);
        }

        private string BuildText(string targetName, string missionName, int year)
        {
            var dataPacketDetails = new StringBuilder();
            dataPacketDetails.AppendLine(targetName);
            dataPacketDetails.AppendLine(missionName);
            dataPacketDetails.AppendLine($"{year}");
            return dataPacketDetails.ToString();
        }

        public void ChangeBackground(bool isOn)
        {
            UtilityMethods.ChangeBackgroundColor(DataPacketToggleButton);
        }
    }
}
