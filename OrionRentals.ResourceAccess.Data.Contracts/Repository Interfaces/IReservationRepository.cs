

using Orion.Core.Common.Contracts;
using OrionRentals.Business.Entities;
using OrionRentals.ResourceAccess.Data.Contracts.DTOs;

namespace OrionRentals.ResourceAccess.Data.Contracts.Repository_Interfaces
{
    public interface IReservationRepository : IDataRepository<Reservation>
    {
        IEnumerable<Reservation> GetReservationsByPickupDate(DateTime pickupDate);
        IEnumerable<CustomerReservationInfo> GetCurrentCustomerReservationInfo();
        IEnumerable<CustomerReservationInfo> GetCustomerOpenReservationInfo(int accountId);
    }
}
