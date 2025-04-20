

namespace PresentationLayer
{
    public static class FormsContext
    {
        public static HomeForm? HomeForm { get; set; }
        public static ReservationsForm? ReservationsForm { get; set; }
        public static ClientsForm? ClientsForm { get; set; }
        public static RoomsForm? RoomsForm { get; set; }
        public static UsersForm? UsersForm { get; set; }
        public static AddNewReservationForm? AddNewReservationForm { get; set; }
        public static AddNewClientForm? AddNewClientForm { get; set; }
        public static AddNewRoomForm? AddNewRoomForm { get; set; }
        public static AddNewUserForm? AddNewUserForm { get; set; }
       

        public static User? LoggedInUser { get; set; }
    }
}
