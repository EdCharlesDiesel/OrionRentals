using OrionRentals.Business.Entities;

namespace OrionRentals.ResourceAccess.Data.Contracts.DTOs
{
    public class CustomerReservationInfo
    {
        public Account Customer { get; set; }
        public Car Car { get; set; }
        public Reservation Reservation { get; set; }
    }
}
