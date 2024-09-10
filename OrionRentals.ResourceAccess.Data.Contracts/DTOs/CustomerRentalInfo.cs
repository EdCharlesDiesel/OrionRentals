using OrionRentals.Business.Entities;

namespace OrionRentals.ResourceAccess.Data.Contracts.DTOs
{
    public class CustomerRentalInfo
    {
        public Account Customer { get; set; }
        public Car Car { get; set; }
        public Rental Rental { get; set; }
    }
}