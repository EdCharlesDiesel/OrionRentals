
using System.ComponentModel.Composition;
using System.Linq;
using OrionRentals.Business.Entities;
using OrionRentals.ResourceAccess.Data.Contracts.Repository_Interfaces;

namespace OrionRentals.ResourceAccess.Data.Data_Repositories
{
    [Export(typeof(ICarRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CarRepository : DataRepositoryBase<Car>, ICarRepository
    {
        protected override Car AddEntity(OrionRentalContext entityContext, Car entity)
        {
            throw new NotImplementedException();
        }

        protected override Car UpdateEntity(OrionRentalContext entityContext, Car entity)
        {
            return (entityContext.Cars.Where(e => e.CarId == entity.CarId)).FirstOrDefault();
        }

        protected override IEnumerable<Car> GetEntities(OrionRentalContext entityContext)
        {
            return from e in entityContext.Cars
                   select e;
        }

        protected override Car GetEntity(OrionRentalContext entityContext, int id)
        {
            var query = (from e in entityContext.Cars
                         where e.CarId == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }
    }
}
