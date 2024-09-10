using System.ComponentModel;
using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore;
using Orion.Core.Common.Contracts;
using OrionRentals.Business.Entities;

namespace OrionRentals.ResourceAccess.Data
{
    public class OrionRentalContext : DbContext
    {
        public OrionRentalContext()
            : base()
        {
        }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Rental> Rentals { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<PropertyChangedEventHandler>();
            modelBuilder.Ignore<ExtensionDataObject>();
            modelBuilder.Ignore<IIdentifiableEntity>();

            //modelBuilder.Entity<Account>().HasKey<int>(e => e.AccountId).Ignore(e => e.EntityId);
            //modelBuilder.Entity<Car>().HasKey<int>(e => e.CarId).Ignore(e => e.EntityId);
            //modelBuilder.Entity<Rental>().HasKey<int>(e => e.RentalId).Ignore(e => e.EntityId);
            //modelBuilder.Entity<Reservation>().HasKey<int>(e => e.ReservationId).Ignore(e => e.EntityId);
            modelBuilder.Entity<Car>().Ignore(e => e.CurrentlyRented);
        }
    }
}
