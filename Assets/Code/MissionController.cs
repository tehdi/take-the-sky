using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TakeTheSky
{
    public class MissionController : MonoBehaviour
    {
        public Text CurrentYearText;
        public Text CurrentEpAmountText;

        public Transform ActiveMissionsParentContent;
        public GameObject ActiveMissionPrefab;

        public void EndYear()
        {
            CurrentState.CurrentYear++;
            CurrentState.CurrentEp += CurrentState.EpGainPerYear;
            
            CurrentYearText.text = $"{CurrentState.CurrentYear}";
            CurrentEpAmountText.text = $"{CurrentState.CurrentEp}";
        }

        public void LaunchMission()
        {
            int epCost = 1;
            CurrentState.CurrentEp -= epCost;

            Target target = new Target() { Name = "Default Target" };
            Explorer explorer = new Explorer() { Name = "Default Explorer" };
            int estimatedArrivalYear = 2015;
            Mission defaultMission = MissionBuilder.NewMission()
                .ToTarget(target)
                .UsingExplorer(explorer)
                .Costing(epCost)
                .LaunchingIn(CurrentState.CurrentYear)
                .EstimatedToArriveIn(estimatedArrivalYear)
                .Build();
            CurrentState.ActiveMissions.Add(defaultMission);

            CurrentEpAmountText.text = $"{CurrentState.CurrentEp}";
            Instantiate(ActiveMissionPrefab, ActiveMissionsParentContent, false)
                .transform.Find("ActiveMissionUiComponentInitializer").GetComponent<ActiveMissionUiComponentInitializer>()
                .Initialize(explorer.Name, target.Name, CurrentState.CurrentYear, estimatedArrivalYear);
        }
    }
}
