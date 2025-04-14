

using System.Collections.Generic;

namespace BusinessLayer
{
    public class Reservation
    {
        [Key]
        public Guid Id { get; private set; }

        [Required]
        [ForeignKey("RoomId")]
        public Guid RoomId { get; private set; }
        public Room ReservedRoom { get; private set; }

        [Required]
        [ForeignKey("UserId")]
        public Guid UserId { get; private set; }
        public User BookedBy { get; private set; }

        [Required]
        public List<Client> Guests { get; private set; } 

        [Required]
        public DateTime StartingDate { get; private set; }

        [Required]
        public DateTime EndingDate { get; private set; }

        [Required]
        public MealsEnum MealPlan { get; private set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        public decimal Price { get; private set; }

        public Reservation() : this(Guid.NewGuid(), new Room(), new User(),
            new List<Client>(), DateTime.Now, DateTime.Now.AddDays(1), MealsEnum.None)
        { }
        

        public Reservation(Guid id, Room reservedRoom, User bookedBy, List<Client> guests, 
            DateTime startingDate, DateTime endingDate, MealsEnum mealPlan)
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id;
           
            SetReservationDetails(reservedRoom, bookedBy, guests, startingDate, endingDate, mealPlan);
        }

        private void SetReservationDetails(Room reservedRoom, User bookedBy, List<Client> guests,
        DateTime startingDate, DateTime endingDate, MealsEnum mealPlan)
        {
            if (reservedRoom == null)
                throw new ArgumentNullException(nameof(reservedRoom), "Room cannot be null.");

            if (bookedBy == null)
                throw new ArgumentNullException(nameof(bookedBy), "User cannot be null.");

            if (startingDate.Date >= endingDate.Date)
                throw new ArgumentException("Starting date must be before the ending date.");

            if (guests == null)
                throw new ArgumentNullException(nameof(guests), "Guests list cannot be null.");

            if (guests.Count > reservedRoom.Capacity)
                throw new ArgumentException("The number of guests cannot exceed the room capacity.");

            ReservedRoom = reservedRoom;
            RoomId = reservedRoom.Id;
            BookedBy = bookedBy;
            UserId = bookedBy.Id;
            Guests = new List<Client>(guests);
            StartingDate = startingDate;
            EndingDate = endingDate;
            MealPlan = mealPlan;

            //Ensure price is calculated correctly
            Price = CalculatePrice(MealPlan);
        }
        private decimal CalculatePrice(MealsEnum mealPlan)
        {
            int totalNights = (EndingDate - StartingDate).Days;
            int adults = Guests.Count(g => g.Age >= 18);
            int children = Guests.Count(g => g.Age < 18);

            // Base room price (per night)
            decimal basePrice = (ReservedRoom.AdultPrice * adults + ReservedRoom.ChildPrice * children) * totalNights;

            // Meal plan price (per night per person)
            decimal mealPlanPrice;
            switch (mealPlan)
            {
                case MealsEnum.None:
                    mealPlanPrice = 0;
                    break;
                case MealsEnum.OnlyBreakfast:
                    mealPlanPrice = (adults * 15 + children * 10) * totalNights;
                    break;
                case MealsEnum.ThreeMeals:
                    mealPlanPrice = (adults * 30 + children * 20) * totalNights;
                    break;
                case MealsEnum.AllInclusive:
                    mealPlanPrice = (adults * 50 + children * 35) * totalNights;
                    break;
                default:
                    throw new ArgumentException("Invalid meal plan selection.");
            }

            // Final total price calculation
            return basePrice + mealPlanPrice;
        }

        public void AddGuest(Client guest)
        {
            if (guest == null)
                throw new ArgumentNullException(nameof(guest), "Guest cannot be null.");

            if (Guests.Count >= ReservedRoom.Capacity)
                throw new InvalidOperationException("Cannot add more guests than room capacity.");
            
            Guests.Add(guest);
            Price = CalculatePrice(MealPlan);
        }

        public void RemoveGuest(Client guest)
        {
            if (Guests.Contains(guest))
            {
                Guests.Remove(guest);
                Price = CalculatePrice(MealPlan);
            }
        }

        public void UpdateReservation(Room reservedRoom, User bookedBy, List<Client> guests, 
            DateTime startingDate, DateTime endingDate, MealsEnum mealPlan)
        {
            SetReservationDetails(reservedRoom, bookedBy, guests, startingDate, endingDate, mealPlan);
        }
    }
}
