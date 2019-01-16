using UnityEngine;
using UnityEngine.UI;

namespace TakeTheSky
{
    public class MissionDetailsController : MonoBehaviour
    {
        public Toggle ActiveMissionsToggleButton;
        public GameObject ActiveMissionsScrollView;
        public ToggleGroup ActiveMissionsToggleGroup;

        public Toggle CompletedMissionsToggleButton;
        public GameObject CompletedMissionsScrollView;
        public ToggleGroup CompletedMissionsToggleGroup;

        public GameObject MissionDetailsPanel;
        public Text MissionNameText;
        public Text MissionStatusValueText;
        public Text LaunchYearValueText;
        public Text ArrivalYearValueText;
        public Text EpCostAmountText;
        public Text ExplorerTypeValueText;
        public Text ExplorerEquipmentValueText;    

        void Start()
        {
            ToggleActiveMissionsDisplay(true);
            ToggleCompletedMissionsDisplay(false);
        }

        public void ToggleActiveMissionsDisplay(bool isOn)
        {
            ActiveMissionsScrollView.SetActive(isOn);
            CompletedMissionsScrollView.SetActive(!isOn);
            TurnOffMissionsDisplay();
            ChangeBackgroundColor(ActiveMissionsToggleButton);
        }

        public void ToggleCompletedMissionsDisplay(bool isOn)
        {
            CompletedMissionsScrollView.SetActive(isOn);
            ActiveMissionsScrollView.SetActive(!isOn);
            TurnOffMissionsDisplay();
            ChangeBackgroundColor(CompletedMissionsToggleButton);
        }

        public void TurnOffMissionsDisplay()
        {
            MissionDetailsPanel.SetActive(false);
            ActiveMissionsToggleGroup.SetAllTogglesOff();
            CompletedMissionsToggleGroup.SetAllTogglesOff();
        }

        private void ChangeBackgroundColor(Toggle toggleButton)
        {
            if (toggleButton.isOn)
            {
                toggleButton.image.color = new Color32(92, 205, 253, 255);
            }
            else
            {
                toggleButton.image.color = Color.white;
            }
        }

        public void ToggleActiveMissionDetails(Mission mission)
        {
            ToggleMissionDetails(ActiveMissionsToggleGroup, mission);
        }

        public void ToggleCompletedMissionDetails(Mission mission)
        {
            ToggleMissionDetails(CompletedMissionsToggleGroup, mission);
        }

        private void ToggleMissionDetails(ToggleGroup toggleGroup, Mission mission)
        {
            if (!toggleGroup.GetComponent<ToggleGroup>().AnyTogglesOn())
            {
                MissionDetailsPanel.SetActive(false);
            }
            else
            {
                MissionDetailsPanel.SetActive(true);

                MissionNameText.text = mission.Name;
                MissionStatusValueText.text = $"{mission.Status}";
                LaunchYearValueText.text = $"{mission.LaunchYear}";
                ArrivalYearValueText.text = $"{mission.ArrivalYear}";
                EpCostAmountText.text = $"{mission.EpCost}";
                ExplorerTypeValueText.text = $"{mission.Explorer.Type}";
            }
        }
    }
}
