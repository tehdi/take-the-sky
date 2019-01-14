namespace TakeTheSky
{
    public class DataPacket
    {
        public bool Viewed;
        public DataPacketCategory Category;
    }

    public enum DataPacketCategory
    {
        Small, Medium, Large, Photo
    }
}
