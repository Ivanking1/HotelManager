using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Reservation
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey("RoomId")]
        public Guid RoomId { get; set; }
        public Room ReservedRoom { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }
        public User BookedUser { get; set; }

        [Required]
        public List<Client> Clients { get; set; }

        [Required]
        public DateTime StartingDate { get; set; }

        [Required]
        public DateTime EndingDate { get; set; }

        [Required]
        public ushort MealsIncluded { get; set; }

        [Required]
        public decimal Price { get; set; }

        public Reservation()
        {
            Clients = new List<Client>();
        }

        public Reservation(Room reservedRoom, User bookedUser, List<Client> clients, DateTime startingDate,
            DateTime endingDate, ushort mealsIncluded, decimal price)
        {
            ReservedRoom = reservedRoom;
            BookedUser = bookedUser;
            Clients = clients;
            StartingDate = startingDate;
            EndingDate = endingDate;
            MealsIncluded = mealsIncluded;
            Price = price;
            Clients = new List<Client>();
        }
    }
}
