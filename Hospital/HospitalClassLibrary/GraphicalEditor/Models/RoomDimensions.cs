namespace HospitalClassLibrary.GraphicalEditor.Models
{
    public class RoomDimensions
    {
        public int Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public bool AreHorizontallyAligned(RoomDimensions roomDimensions)
        {
            return Y.Equals(roomDimensions.Y);
        }

        public bool AreVerticallyAligned(RoomDimensions roomDimensions)
        {
            return X.Equals(roomDimensions.X);
        }
    }
}
