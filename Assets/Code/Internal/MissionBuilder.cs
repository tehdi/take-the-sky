namespace TakeTheSky
{
    public class MissionBuilder
    {
        public static MissionBuilder NewMission()
        {
            return new MissionBuilder();
        }

        private string Name;
        private Explorer Explorer;
        private Target Target;
        private int LaunchYear;
        private int EpCost;
        private int ArrivalYear;

        public MissionBuilder Named(string missionName)
        {
            Name = missionName;
            return this;
        }

        public MissionBuilder UsingExplorer(Explorer explorer)
        {
            Explorer = explorer;
            return this;
        }

        public MissionBuilder ToTarget(Target target)
        {
            Target = target;
            return this;
        }

        public MissionBuilder LaunchingIn(int launchYear)
        {
            LaunchYear = launchYear;
            return this;
        }

        public MissionBuilder Costing(int epCost)
        {
            EpCost = epCost;
            return this;
        }

        public MissionBuilder ArrivingIn(int arrivalYear)
        {
            ArrivalYear = arrivalYear;
            return this;
        }

        public Mission Build()
        {
            return new Mission(
                name: Name,
                launchYear: LaunchYear,
                epCost: EpCost,
                target: Target,
                explorer: Explorer,
                arrivalYear: ArrivalYear
            );
        }
    }
}
