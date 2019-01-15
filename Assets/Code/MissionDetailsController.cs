using UnityEngine;
using UnityEngine.UI;

namespace TakeTheSky
{
    public class MissionDetailsController : MonoBehaviour
    {
        public ToggleGroup ActiveMissionsToggleGroup;
        public GameObject MissionDetailsPanel;

        public Text MissionNameText;
        public Text MissionStatusValueText;
        public Text LaunchYearValueText;
        public Text ArrivalYearValueText;
        public Text EpCostAmountText;
        public Text ExplorerTypeValueText;
        public Text ExplorerEquipmentValueText;    

        public void ToggleMissionDetails(Mission mission)
        {
            if (!ActiveMissionsToggleGroup.GetComponent<ToggleGroup>().AnyTogglesOn())
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
