namespace TakeTheSky
{
    public class Explorer
    {
        public ExplorerType Type;
    }

    public enum ExplorerType
    {
        // I'm struggling with satellite vs orbiter, but in this context I think I'm going to go with:
        //  a satellite is an artifical construct that orbits Earth
        //  an orbiter is an artificial construct that orbits not-Earth
        Satellite, Probe, Orbiter, Lander, Rover
    }
}
