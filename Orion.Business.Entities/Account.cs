﻿using Orion.Core.Common.Contracts;
using Orion.Core.Common.Core;
using System.Runtime.Serialization;

namespace OrionRentals.Business.Entities
{
    [DataContract]
    public class Account : EntityBase, IIdentifiableEntity
    {
        [DataMember]
        public int AccountId { get; set; }

        [DataMember]
        public string? LoginEmail { get; set; }

        [DataMember]
        public string? FirstName { get; set; }

        [DataMember]
        public string? LastName { get; set; }

        [DataMember]
        public string? Address { get; set; }

        [DataMember]
        public string? City { get; set; }

        [DataMember]
        public string? State { get; set; }

        [DataMember]
        public string? ZipCode { get; set; }

        [DataMember]
        public string? CreditCard { get; set; }

        [DataMember]
        public string? ExpDate { get; set; }

        #region IIdentifiableEntity members

        public int EntityId
        {
            get => AccountId;
            set => AccountId = value;
        }

        #endregion
    }
}
