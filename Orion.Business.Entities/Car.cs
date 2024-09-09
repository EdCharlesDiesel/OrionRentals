﻿using System.Runtime.Serialization;

namespace OrionRentals.Business.Entities
{
    /// <summary>
    /// Car entity for the business side
    /// </summary>
    [DataContract]
    public class Car
    {
        [DataMember]
        public int CarId { get; set; }

        [DataMember]
        public string? Description { get; set; }

        [DataMember]
        public string? Color { get; set; }

        [DataMember]
        public int Year { get; set; }

        [DataMember]
        public decimal RentalPrice { get; set; }

        [DataMember]
        public bool CurrentlyRented { get; set; }
    }
}