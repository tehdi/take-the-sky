using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TakeTheSky
{
    public class DataPacketDetailsController : MonoBehaviour
    {
        public Toggle SelectedMissionDataPacketsToggleButton;
        public GameObject SelectedMissionDataPacketsScrollView;
        public ToggleGroup SelectedMissionDataPacketsToggleGroup;

        public Toggle AllDataPacketsToggleButton;
        public GameObject AllDataPacketsScrollView;
        public ToggleGroup AllDataPacketsToggleGroup;

        public GameObject DataPacketToggleButtonPrefab;
        public Transform SelectedMissionDataPacketsParentContent;
        public Transform AllDataPacketsParentContent;

        public GameObject DataPacketDetailsPanel;
        public Text ReceivedYearTextValue;
        public Text DataPacketContentsValueText;

        private List<GameObject> SelectedMissionDataPacketButtons = new List<GameObject>();

        public void ToggleSelectedMissionDataPacketsDisplay(bool isOn)
        {
            if (isOn)
            {
                AddMissionDataPackets(CurrentState.SelectedMission);
            }

            SelectedMissionDataPacketsScrollView.SetActive(isOn);
            AllDataPacketsScrollView.SetActive(!isOn);
            TurnOffDataPacketDetailsDisplay();
            SelectedMissionDataPacketsToggleButton.isOn = isOn;
            UtilityMethods.ChangeBackgroundColor(SelectedMissionDataPacketsToggleButton);
        }

        public void ToggleAllDataPacketsDisplay(bool isOn)
        {
            AllDataPacketsScrollView.SetActive(isOn);
            SelectedMissionDataPacketsScrollView.SetActive(!isOn);
            TurnOffDataPacketDetailsDisplay();
            UtilityMethods.ChangeBackgroundColor(AllDataPacketsToggleButton);
        }

        public void AddDataPacket(DataPacket dataPacket)
        {
            var dataPacketToggleButtonInstance = Instantiate(DataPacketToggleButtonPrefab, AllDataPacketsParentContent, false);
            dataPacketToggleButtonInstance.GetComponent<Toggle>().group = AllDataPacketsToggleGroup;
            dataPacketToggleButtonInstance.GetComponent<Toggle>().onValueChanged.AddListener(enabled => ToggleDataPacketDetails(dataPacket, AllDataPacketsToggleGroup));
            dataPacketToggleButtonInstance.transform.Find("DataPacketToggleButtonController").GetComponent<DataPacketToggleButtonController>().Initialize(dataPacket);
        }

        private void AddMissionDataPackets(Mission mission)
        {
            foreach (var button in SelectedMissionDataPacketButtons)
            {
                Destroy(button);
            }

            SelectedMissionDataPacketButtons = new List<GameObject>();
            if (mission?.DataPackets.Count > 0)
            {
                foreach (var dataPacket in mission.DataPackets)
                {
                    var dataPacketToggleButtonInstance = Instantiate(DataPacketToggleButtonPrefab, SelectedMissionDataPacketsParentContent, false);
                    dataPacketToggleButtonInstance.GetComponent<Toggle>().group = SelectedMissionDataPacketsToggleGroup;
                    dataPacketToggleButtonInstance.GetComponent<Toggle>().onValueChanged.AddListener(enabled => ToggleDataPacketDetails(dataPacket, SelectedMissionDataPacketsToggleGroup));
                    dataPacketToggleButtonInstance.transform.Find("DataPacketToggleButtonController").GetComponent<DataPacketToggleButtonController>().Initialize(dataPacket);
                    SelectedMissionDataPacketButtons.Add(dataPacketToggleButtonInstance);
                }
            }
        }

        private void ToggleDataPacketDetails(DataPacket dataPacket, ToggleGroup toggleGroup)
        {
            if (!toggleGroup.AnyTogglesOn())
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

        public void TurnOffDataPacketDetailsDisplay()
        {
            DataPacketDetailsPanel.SetActive(false);
            AllDataPacketsToggleGroup.SetAllTogglesOff();
            SelectedMissionDataPacketsToggleGroup.SetAllTogglesOff();
        }
    }
}
