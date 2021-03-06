﻿using UnityEngine;
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

        public GameObject MissionToggleButtonPrefab;
        public Transform ActiveMissionsParentContent;
        public Transform CompletedMissionsParentContent;

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
            UtilityMethods.ChangeBackgroundColor(ActiveMissionsToggleButton);
        }

        public void ToggleCompletedMissionsDisplay(bool isOn)
        {
            CompletedMissionsScrollView.SetActive(isOn);
            ActiveMissionsScrollView.SetActive(!isOn);
            TurnOffMissionsDisplay();
            UtilityMethods.ChangeBackgroundColor(CompletedMissionsToggleButton);
        }

        public void AddActiveMissionButton(Mission mission)
        {
            var missionButtonInstance = Instantiate(MissionToggleButtonPrefab, ActiveMissionsParentContent, false);
            missionButtonInstance.GetComponent<Toggle>().group = ActiveMissionsToggleGroup;
            missionButtonInstance.GetComponent<Toggle>().onValueChanged.AddListener(enabled => ToggleMissionDetails(mission, ActiveMissionsToggleGroup));
            missionButtonInstance.transform.Find("MissionToggleButtonController").GetComponent<MissionToggleButtonController>().Initialize(mission);
            mission.Button = missionButtonInstance;
        }

        public void CompleteMission(Mission mission)
        {
            Destroy(mission.Button); // the old button is attached to all the "active" group stuff

            var missionButtonInstance = Instantiate(MissionToggleButtonPrefab, CompletedMissionsParentContent, false);
            missionButtonInstance.GetComponent<Toggle>().group = CompletedMissionsToggleGroup;
            missionButtonInstance.GetComponent<Toggle>().onValueChanged.AddListener(enabled => ToggleMissionDetails(mission, CompletedMissionsToggleGroup));
            missionButtonInstance.transform.Find("MissionToggleButtonController").GetComponent<MissionToggleButtonController>().Initialize(mission);
            mission.Button = missionButtonInstance;
        } 

        private void ToggleMissionDetails(Mission mission, ToggleGroup toggleGroup)
        {
            if (!toggleGroup.AnyTogglesOn())
            {
                MissionDetailsPanel.SetActive(false);
                CurrentState.SelectedMission = null;
            }
            else
            {
                MissionDetailsPanel.SetActive(true);
                CurrentState.SelectedMission = mission;

                MissionNameText.text = mission.Name;
                MissionStatusValueText.text = $"{mission.Status}";
                LaunchYearValueText.text = $"{mission.LaunchYear}";
                ArrivalYearValueText.text = $"{mission.ArrivalYear}";
                EpCostAmountText.text = $"{mission.EpCost}";
                ExplorerTypeValueText.text = $"{mission.Explorer.Type}";
            }
        }

        public void TurnOffMissionsDisplay()
        {
            CurrentState.SelectedMission = null;
            MissionDetailsPanel.SetActive(false);
            ActiveMissionsToggleGroup.SetAllTogglesOff();
            CompletedMissionsToggleGroup.SetAllTogglesOff();
        }
    }
}
