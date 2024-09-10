
using System.ComponentModel.Composition;
using Orion.Core.Common.Extensions;
using OrionRentals.Business.Entities;
using OrionRentals.ResourceAccess.Data.Contracts.DTOs;
using OrionRentals.ResourceAccess.Data.Contracts.Repository_Interfaces;

namespace OrionRentals.ResourceAccess.Data.Data_Repositories
{
    [Export(typeof(IRentalRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class RentalRepository : DataRepositoryBase<Rental>, IRentalRepository
    {
        protected override Rental AddEntity(OrionRentalContext entityContext, Rental entity)
        {
            //return entityContext.Rentals.Add(entity);
            throw new NotImplementedException();
        }

        protected override Rental UpdateEntity(OrionRentalContext entityContext, Rental entity)
        {
            return (from e in entityContext.Rentals
                    where e.RentalId == entity.RentalId
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<Rental> GetEntities(OrionRentalContext entityContext)
        {
            return from e in entityContext.Rentals
                   select e;
        }

        protected override Rental GetEntity(OrionRentalContext entityContext, int id)
        {
            var query = (from e in entityContext.Rentals
                         where e.RentalId == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }

        public IEnumerable<Rental> GetRentalHistoryByCar(int carId)
        {
            using (var entityContext = new OrionRentalContext())
            {
                var query = from e in entityContext.Rentals
                            where e.CarId == carId
                            select e;

                return query.ToFullyLoaded();
            }
        }

        public Rental GetCurrentRentalByCar(int carId)
        {
            using (var entityContext = new OrionRentalContext())
            {
                var query = from e in entityContext.Rentals
                            where e.CarId == carId && e.DateReturned == null
                            select e;

                return query.FirstOrDefault();
            }
        }

        public IEnumerable<Rental> GetCurrentlyRentedCars()
        {
            using (var entityContext = new OrionRentalContext())
            {
                var query = from e in entityContext.Rentals
                            where e.DateReturned == null
                            select e;

                return query.ToFullyLoaded();
            }
        }

        public IEnumerable<Rental> GetRentalHistoryByAccount(int accountId)
        {
            using (var entityContext = new OrionRentalContext())
            {
                var query = from e in entityContext.Rentals
                            where e.AccountId == accountId
                            select e;

                return query.ToFullyLoaded();
            }
        }

        public IEnumerable<CustomerRentalInfo> GetCurrentCustomerRentalInfo()
        {
            using (var entityContext = new OrionRentalContext())
            {
                var query = from r in entityContext.Rentals
                            where r.DateReturned == null
                            join a in entityContext.Accounts on r.AccountId equals a.AccountId
                            join c in entityContext.Cars on r.CarId equals c.CarId
                            select new CustomerRentalInfo()
                            {
                                Customer = a,
                                Car = c,
                                Rental = r
                            };

                return query.ToFullyLoaded();
            }
        }
    }
}
