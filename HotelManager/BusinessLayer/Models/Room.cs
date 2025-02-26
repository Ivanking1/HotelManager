
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Room
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public int RoomNumber { get; set; }

        [Required]
        public ushort Capacity { get; set; }

        [Required]
        public RoomEnum Type { get; set; }

        [Required]
        public bool IsFree { get; set; }

        [Required]
        public decimal AdultPrice { get; set; }

        [Required]
        public decimal ChildPrice { get; set; }

        

        public Room()
        {
            Id = Guid.NewGuid();
        }
        public Room(int roomNumber, RoomEnum type, bool isFree, decimal adultPrice, decimal childPrice)
        {
            Id = Guid.NewGuid();
            if ((int)type == 1 || (int)type == 2)
            {
                Capacity = 2;
            }
            else if ((int)type == 3)
            {
                Capacity = 5;
            }
            Capacity = 0;
            Type = type;
            IsFree = isFree;
            AdultPrice = adultPrice;
            ChildPrice = childPrice;
            RoomNumber = roomNumber;
        }
    }
}
