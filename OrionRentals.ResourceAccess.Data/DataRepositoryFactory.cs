using Orion.Core.Common.Core;
using System.ComponentModel.Composition;
using Orion.Core.Common.Contracts;

namespace OrionRentals.ResourceAccess.Data
{
    [Export(typeof(IDataRepositoryFactory))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class DataRepositoryFactory : IDataRepositoryFactory
    {
        T IDataRepositoryFactory.GetDataRepository<T>()
        {
            return ObjectBase.Container.GetExportedValue<T>();
        }
    }
}
