
using System.ComponentModel.Composition;
using OrionRentals.Business.Entities;
using OrionRentals.ResourceAccess.Data.Contracts.Repository_Interfaces;

namespace OrionRentals.ResourceAccess.Data.Data_Repositories
{    
    [Export(typeof(IAccountRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AccountRepository : DataRepositoryBase<Account>, IAccountRepository
    {
        protected override Account AddEntity(OrionRentalContext entityContext, Account entity)
        {
            throw new NotImplementedException();
        }

        protected override Account UpdateEntity(OrionRentalContext entityContext, Account entity)
        {
            return (from e in entityContext.Accounts
                    where e.AccountId == entity.AccountId
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<Account> GetEntities(OrionRentalContext entityContext)
        {
            return from e in entityContext.Accounts
                   select e;
        }
        
        protected override Account GetEntity(OrionRentalContext entityContext, int id)
        {
            var query = (from e in entityContext.Accounts
                         where e.AccountId == id
                         select e);
            
            var results = query.FirstOrDefault();

            return results;
        }

        public Account GetByLogin(string login)
        {
            using (var entityContext = new OrionRentalContext())
            {
                return (from a in entityContext.Accounts
                        where a.LoginEmail == login
                        select a).FirstOrDefault();
            }
        }
    }
}
