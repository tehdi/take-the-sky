using UnityEngine;
using UnityEngine.UI;

namespace TakeTheSky
{
    public class DataPacketDetailsController : MonoBehaviour
    {
        public GameObject DataPacketToggleButtonPrefab;
        public Transform DataPacketsParentContent;
        public ToggleGroup DataPacketsToggleGroup;

        public GameObject DataPacketDetailsPanel;
        public Text ReceivedYearTextValue;
        public Text DataPacketContentsValueText;

        public void AddDataPacket(DataPacket dataPacket)
        {
            var dataPacketToggleButtonInstance = Instantiate(DataPacketToggleButtonPrefab, DataPacketsParentContent, false);
            dataPacketToggleButtonInstance.GetComponent<Toggle>().group = DataPacketsToggleGroup;
            dataPacketToggleButtonInstance.GetComponent<Toggle>().onValueChanged.AddListener(enabled => ToggleDataPacketDetails(dataPacket));
            dataPacketToggleButtonInstance.transform.Find("DataPacketToggleButtonController").GetComponent<DataPacketToggleButtonController>().Initialize(dataPacket);
        }

        public void ToggleDataPacketDetails(DataPacket dataPacket)
        {
            if (!DataPacketsToggleGroup.AnyTogglesOn())
            {
                DataPacketDetailsPanel.SetActive(false);
            }
            else
            {
                DataPacketDetailsPanel.SetActive(true);

                ReceivedYearTextValue.text = $"{dataPacket.ReceivedYear}";
                DataPacketContentsValueText.text = dataPacket.Contents;
            }
        }
    }
}
