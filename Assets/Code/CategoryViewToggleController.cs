using UnityEngine;
using UnityEngine.UI;

namespace TakeTheSky
{
    public class CategoryViewToggleController : MonoBehaviour
    {
        public ToggleGroup CategoryViewToggleGroup;

        public Toggle ViewTargetsToggleButton;
        public GameObject TargetContainer;

        public Toggle ViewMissionsToggleButton;
        public GameObject MissionContainer;

        public Toggle ViewDataPacketsToggleButton;
        public GameObject DataPacketContainer;

        void Start()
        {
            ToggleTargetsDisplay(true);
        }

        public void ToggleTargetsDisplay(bool isOn)
        {
            ViewTargetsToggleButton.isOn = isOn;
            ToggleCategoryDisplay(viewTargets: isOn);
            UtilityMethods.ChangeBackgroundColor(ViewTargetsToggleButton);
        }

        public void ToggleMissionsDisplay(bool isOn)
        {
            ViewMissionsToggleButton.isOn = isOn;
            ToggleCategoryDisplay(viewMissions: isOn);
            UtilityMethods.ChangeBackgroundColor(ViewMissionsToggleButton);
        }

        public void ToggleDataPacketsDisplay(bool isOn)
        {
            ViewDataPacketsToggleButton.isOn = isOn;
            ToggleCategoryDisplay(viewDataPackets: isOn);
            UtilityMethods.ChangeBackgroundColor(ViewDataPacketsToggleButton);
        }

        private void ToggleCategoryDisplay(bool viewTargets = false, bool viewMissions = false, bool viewDataPackets = false)
        {
            TargetContainer.SetActive(viewTargets);
            MissionContainer.SetActive(viewMissions);
            DataPacketContainer.SetActive(viewDataPackets);
        }
    }
}
