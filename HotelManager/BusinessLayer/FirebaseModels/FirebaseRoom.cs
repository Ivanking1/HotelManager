

namespace BusinessLayer
{
    public class FirebaseRoom
    {
        public Guid Id { get; set; }
        public int RoomNumber { get; set; }
        public ushort Capacity { get; set; }
        public RoomEnum RoomType { get; set; }
        public decimal AdultPrice { get; set; }
        public decimal ChildPrice { get; set; }
    }
}
