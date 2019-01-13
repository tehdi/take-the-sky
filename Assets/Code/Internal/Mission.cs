namespace TakeTheSky
{
    public class Mission
    {
        public int LaunchYear { get; }
        public int EpCost { get; }
        public Target Target { get; }
        public Explorer Explorer { get; }
        public int EstimatedArrivalYear { get; }
        public int ActualArrivalYear { get; private set; }

        public Mission(int launchYear, int epCost, Target target, Explorer explorer, int estimatedArrivalYear)
        {
            LaunchYear = launchYear;
            EpCost = epCost;
            Target = target;
            Explorer = explorer;
            EstimatedArrivalYear = estimatedArrivalYear;
        }
    }
}
