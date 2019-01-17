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
            ToggleCategoryDisplay();
            UtilityMethods.ChangeBackgroundColor(ViewTargetsToggleButton);
        }

        public void ToggleMissionsDisplay(bool isOn)
        {
            ToggleCategoryDisplay();
            UtilityMethods.ChangeBackgroundColor(ViewMissionsToggleButton);
        }

        public void ToggleDataPacketsDisplay(bool isOn)
        {
            ToggleCategoryDisplay();
            UtilityMethods.ChangeBackgroundColor(ViewDataPacketsToggleButton);
        }

        private void ToggleCategoryDisplay()
        {
            TargetContainer.SetActive(ViewTargetsToggleButton.isOn);
            MissionContainer.SetActive(ViewMissionsToggleButton.isOn);
            DataPacketContainer.SetActive(ViewDataPacketsToggleButton.isOn);
        }
    }
}
