namespace TakeTheSky
{
    public class DataPacket
    {
        public Target Target;
        public Mission Mission;
        public int ReceivedYear;
        public DataPacketCategory Category;
        public string Contents;
        public bool Viewed;
    }

    public enum DataPacketCategory
    {
        Small, Medium, Large, Photo
    }
}
