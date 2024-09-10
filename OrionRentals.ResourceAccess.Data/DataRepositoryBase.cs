using Orion.Core.Common.Contracts;
using Orion.Core.Common.Data;

namespace OrionRentals.ResourceAccess.Data
{
    public abstract class DataRepositoryBase<T> : DataRepositoryBase<T, OrionRentalContext>
        where T : class, IIdentifiableEntity, new()
    {
    }
}
