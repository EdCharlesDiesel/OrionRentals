using Orion.Core.Common.Contracts;
using Orion.Core.Common.Core;
using System.Runtime.Serialization;


namespace OrionRentals.Business.Entities
{
    [DataContract]
    public class Reservation : EntityBase, IIdentifiableEntity, IAccountOwnedEntity
    {
        [DataMember]
        public int ReservationId { get; set; }

        [DataMember]
        public int AccountId { get; set; }

        [DataMember]
        public int CarId { get; set; }

        [DataMember]
        public DateTime RentalDate { get; set; }

        [DataMember]
        public DateTime ReturnDate { get; set; }

        #region IIdentifiableEntity members

        public int EntityId
        {
            get => ReservationId;
            set => ReservationId = value;
        }

        #endregion

        #region IAccountOwnedEntity members

        int IAccountOwnedEntity.OwnerAccountId => AccountId;

        #endregion
    }
}
