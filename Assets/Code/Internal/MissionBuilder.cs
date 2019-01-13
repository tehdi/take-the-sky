namespace TakeTheSky
{
    public class MissionBuilder
    {
        public static MissionBuilder NewMission()
        {
            return new MissionBuilder();
        }
        
        private Explorer Explorer;
        private Target Target;
        private int LaunchYear;
        private int EpCost;
        private int EstimatedArrivalYear;

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

        public MissionBuilder EstimatedToArriveIn(int estimatedArrivalYear)
        {
            EstimatedArrivalYear = estimatedArrivalYear;
            return this;
        }

        public Mission Build()
        {
            return new Mission(
                launchYear: LaunchYear,
                epCost: EpCost,
                target: Target,
                explorer: Explorer,
                estimatedArrivalYear: EstimatedArrivalYear
            );
        }
    }
}
