

using System.ComponentModel.Composition;
using Orion.Core.Common.Extensions;
using OrionRentals.Business.Entities;
using OrionRentals.ResourceAccess.Data.Contracts.DTOs;
using OrionRentals.ResourceAccess.Data.Contracts.Repository_Interfaces;

namespace OrionRentals.ResourceAccess.Data.Data_Repositories
{
    [Export(typeof(IReservationRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ReservationRepository : DataRepositoryBase<Reservation>, IReservationRepository
    {
        protected override Reservation AddEntity(OrionRentalContext entityContext, Reservation entity)
        {
            //return entityContext.Reservations.Add(entity);
            throw new NotImplementedException();

        }

        protected override Reservation UpdateEntity(OrionRentalContext entityContext, Reservation entity)
        {
            return (from e in entityContext.Reservations
                    where e.ReservationId == entity.ReservationId
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<Reservation> GetEntities(OrionRentalContext entityContext)
        {
            return from e in entityContext.Reservations
                   select e;
        }

        protected override Reservation GetEntity(OrionRentalContext entityContext, int id)
        {
            var query = (from e in entityContext.Reservations
                         where e.ReservationId == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }

        public IEnumerable<CustomerReservationInfo> GetCurrentCustomerReservationInfo()
        {
            using (OrionRentalContext entityContext = new OrionRentalContext())
            {
                var query = from r in entityContext.Reservations
                            join a in entityContext.Accounts on r.AccountId equals a.AccountId
                            join c in entityContext.Cars on r.CarId equals c.CarId
                            select new CustomerReservationInfo()
                            {
                                Customer = a,
                                Car = c,
                                Reservation = r
                            };

                return query.ToFullyLoaded();
            }
        }

        public IEnumerable<Reservation> GetReservationsByPickupDate(DateTime pickupDate)
        {
            using (var entityContext = new OrionRentalContext())
            {
                var query = from r in entityContext.Reservations
                            where r.RentalDate < pickupDate
                            select r;

                return query.ToFullyLoaded();
            }
        }

        public IEnumerable<CustomerReservationInfo> GetCustomerOpenReservationInfo(int accountId)
        {
            using (OrionRentalContext entityContext = new OrionRentalContext())
            {
                var query = from r in entityContext.Reservations
                            join a in entityContext.Accounts on r.AccountId equals a.AccountId
                            join c in entityContext.Cars on r.CarId equals c.CarId
                            where r.AccountId == accountId
                            select new CustomerReservationInfo()
                            {
                                Customer = a,
                                Car = c,
                                Reservation = r
                            };

                return query.ToFullyLoaded();
            }
        }
    }
}
