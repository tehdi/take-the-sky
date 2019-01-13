using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace TakeTheSky
{
    public class MissionControl : MonoBehaviour
    {
        public Transform ActiveMissionsParentContent;
        public GameObject ActiveMissionPrefab;

        private List<Mission> ActiveMissions = new List<Mission>();

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
            ActiveMissions.Add(defaultMission);

            Instantiate(ActiveMissionPrefab, ActiveMissionsParentContent, false)
                .transform.Find("ActiveMissionUiComponentInitializer").GetComponent<ActiveMissionUiComponentInitializer>()
                .Initialize(explorer.Name, target.Name, CurrentState.CurrentYear, estimatedArrivalYear);
        }
    }
}
