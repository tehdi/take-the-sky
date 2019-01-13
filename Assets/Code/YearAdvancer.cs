using UnityEngine;
using UnityEngine.UI;

namespace TakeTheSky
{
    public class YearAdvancer : MonoBehaviour
    {
        public void EndYear()
        {
            CurrentState.CurrentYear++;
            CurrentState.CurrentEp += CurrentState.EpGainPerYear;
        }
    }
}
