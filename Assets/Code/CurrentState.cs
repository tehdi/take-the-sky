using System.Collections.Generic;

namespace TakeTheSky
{
    public static class CurrentState
    {
        private static readonly int START_YEAR = 1957; // Sputnik 1!
        private static readonly int START_EP = 1;
        private static readonly int START_SP = 0;

        public static int CurrentYear = START_YEAR;
        public static int CurrentEp = START_EP;
        public static int EpGainPerYear = 1;
        public static int CurrentSp = START_SP;

        public static Dictionary<int, List<Mission>> ActiveMissions = new Dictionary<int, List<Mission>>();
    }
}
