
namespace BusinessLayer
{
    public class Room
    {
        [Key]
        public Guid Id { get; private set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Room number must be greater than zero.")]
        public int RoomNumber { get; private set; }

        [Required]
        public ushort Capacity { get; private set; }

        [Required]
        public RoomEnum RoomType { get; private set; }

        [Required]
        public bool IsAvailable { get; private set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        public decimal AdultPrice { get; private set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        public decimal ChildPrice { get; private set; }

        
        public string RoomInfo => $"{RoomNumber} - {RoomType} (Max: {Capacity})";



        public Room() : this(Guid.NewGuid(), 0, RoomEnum.SingleRoom, true, decimal.Zero, decimal.Zero) { }

        public Room(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Id cannot be empty.", nameof(id));
            Id = id;
        }

        public Room(Guid id, int roomNumber, RoomEnum roomType, bool isAvailable, decimal adultPrice, decimal childPrice)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;

            SetRoomDetails(roomNumber, roomType, isAvailable, adultPrice, childPrice);
        }

        private void SetRoomDetails(int roomNumber, RoomEnum roomType, bool isAvailable, decimal adultPrice, decimal childPrice)
        {
            //Ensure room number is positive
            if (roomNumber < 1)
                throw new ArgumentException("Room number must be greater than zero.");

            RoomNumber = roomNumber;

            //Ensure the room type is valid
            if (!Enum.IsDefined(typeof(RoomEnum), roomType))
                throw new ArgumentException("Invalid room type.");

            RoomType = roomType;

            //Assign correct capacity based on room type
            Capacity = GetRoomCapacity(roomType);

            IsAvailable = isAvailable;

            //Validate prices
            if (adultPrice < 0 || adultPrice > 10_000)  // Assuming no room should cost more than $10,000 per night
                throw new ArgumentException("Adult price must be a positive value and not exceed $10,000.");

            if (childPrice < 0 || childPrice > 5_000)  // Assuming child price shouldn't be above $5,000
                throw new ArgumentException("Child price must be a positive value and not exceed $5,000.");

            AdultPrice = adultPrice;
            ChildPrice = childPrice;
        }

        private static ushort GetRoomCapacity(RoomEnum roomType)
        {
            switch (roomType)
            {
                case RoomEnum.SingleRoom:
                    return 1;
                case RoomEnum.TwinRoom:
                case RoomEnum.DoubleRoom:
                    return 2;
                case RoomEnum.FamilyRoom:
                    return 4;
                case RoomEnum.Suite:
                    return 5;
                case RoomEnum.Penthouse:
                    return 8;
                default:
                    throw new ArgumentException("Invalid room type.");
            }
        }

        public void UpdateRoom(int roomNumber, RoomEnum roomType, bool isAvailable, decimal adultPrice, decimal childPrice)
        {
            SetRoomDetails(roomNumber, roomType, isAvailable, adultPrice, childPrice);
        }

    }
}
