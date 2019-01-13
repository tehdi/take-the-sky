using UnityEngine;
using UnityEngine.UI;

namespace TakeTheSky
{
    // As much as possible, try to keep UI updates here. That way you're not binding
    // a bunch of GameObjects to a million different scripts.
    public class UiUpdater : MonoBehaviour
    {
        public Text CurrentYearText;
        public Text CurrentEpAmountText;

        void Update()
        {
            CurrentYearText.text = $"{CurrentState.CurrentYear}";
            CurrentEpAmountText.text = $"{CurrentState.CurrentEp}";
        }
    }
}
