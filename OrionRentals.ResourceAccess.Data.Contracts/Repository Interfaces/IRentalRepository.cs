using Orion.Core.Common.Contracts;
using OrionRentals.Business.Entities;
using OrionRentals.ResourceAccess.Data.Contracts.DTOs;

namespace OrionRentals.ResourceAccess.Data.Contracts.Repository_Interfaces
{
    public interface IRentalRepository : IDataRepository<Rental>
    {
        IEnumerable<Rental> GetRentalHistoryByCar(int carId);
        Rental GetCurrentRentalByCar(int carId);
        IEnumerable<Rental> GetCurrentlyRentedCars();
        IEnumerable<Rental> GetRentalHistoryByAccount(int accountId);
        IEnumerable<CustomerRentalInfo> GetCurrentCustomerRentalInfo();
    }
}
