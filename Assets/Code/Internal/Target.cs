namespace TakeTheSky
{
    public class Target
    {
         // I need to be able to change some info about a Target, eg. I want all new discoveries to be "???" until they're explored further
        public string Name;
        public TargetClassification Classification;
        public Mission DiscoveredBy;
    }

    public enum TargetClassification
    {
        Planet, Moon, Asteroid, Comet, Star, DeepSpace, DwarfPlanet, KuiperBeltObject
    }
}
