using UnityEngine;
using UnityEngine.UI;

namespace TakeTheSky
{
    public class YearAdvancer : MonoBehaviour
    {
        private static readonly int START_YEAR = 1957; // Sputnik 1!
        private static readonly int START_EP = 1;

        private int CurrentYear = START_YEAR;
        private int CurrentEp = START_EP;
        private int EpGainPerYear = 1;

        public Text CurrentYearText;
        public Text CurrentEpAmountText;
        public Button EndYearButton;

        public void EndYear()
        {
            CurrentYear++;
            CurrentEp += EpGainPerYear;

            CurrentYearText.text = $"{CurrentYear}";
            CurrentEpAmountText.text = $"{CurrentEp}";
        }
    }
}
