using UnityEngine;
using UnityEngine.UI;

namespace TakeTheSky
{
    public class MissionDetailsController : MonoBehaviour
    {
        public ToggleGroup ActiveMissionsToggleGroup;
        public GameObject MissionDetailsPanel;

        public Text MissionNameText;
        public Text LaunchYearValueText;
        public Text ArrivalYearValueText;
        public Text EpCostAmountText;
        public Text ExplorerTypeValueText;
        public Text ExplorerEquipmentValueText;    

        public void ToggleMissionDetails(Mission mission)
        {
            ToggleGroup toggleGroup = ActiveMissionsToggleGroup.GetComponent<ToggleGroup>();
            if (!toggleGroup.AnyTogglesOn())
            {
                MissionDetailsPanel.SetActive(false);
            }
            else
            {
                var activeMission = toggleGroup.GetActive();
                MissionDetailsPanel.SetActive(true);

                MissionNameText.text = mission.Name;
                LaunchYearValueText.text = $"{mission.LaunchYear}";
                ArrivalYearValueText.text = $"{mission.ArrivalYear}";
                EpCostAmountText.text = $"{mission.EpCost}";
                ExplorerTypeValueText.text = $"{mission.Explorer.Type}";
            }
        }
    }
}
