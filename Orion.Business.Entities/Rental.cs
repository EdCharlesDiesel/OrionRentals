using Orion.Core.Common.Contracts;
using Orion.Core.Common.Core;
using System.Runtime.Serialization;

namespace OrionRentals.Business.Entities
{
    [DataContract]
        public class Rental : EntityBase, IIdentifiableEntity, IAccountOwnedEntity
        {
            [DataMember]
            public int RentalId { get; set; }

            [DataMember]
            public int AccountId { get; set; }

            [DataMember]
            public int CarId { get; set; }

            [DataMember]
            public DateTime DateRented { get; set; }

            [DataMember]
            public DateTime DateDue { get; set; }

            [DataMember]
            public DateTime? DateReturned { get; set; }

            #region IIdentifiableEntity members

            public int EntityId
            {
                get { return RentalId; }
                set { RentalId = value; }
            }

            #endregion

            #region IAccountOwnedEntity members

            int IAccountOwnedEntity.OwnerAccountId
            {
                get { return AccountId; }
            }

            #endregion
        }   
}
