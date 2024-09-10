
using Orion.Core.Common.Contracts;
using OrionRentals.Business.Entities;

namespace OrionRentals.ResourceAccess.Data.Contracts.Repository_Interfaces
{
    public interface IAccountRepository : IDataRepository<Account>
    {
        Account GetByLogin(string login);
    }
}
