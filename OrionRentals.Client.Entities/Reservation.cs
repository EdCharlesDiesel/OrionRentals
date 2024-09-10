using Orion.Core.Common.Core;

namespace OrionRentals.Client.Entities
{
    /// <summary>
    /// Reservation entity client side.
    /// </summary>
    public class Reservation : ObjectBase
    {
        private int _reservationId;
        private int _accountId;
        private int _carId;
        private DateTime _rentalDate;
        private DateTime _returnDate;

        public int ReservationId
        {
            get => _reservationId;
            set
            {
                _reservationId = value;
                OnPropertyChanged(() => ReservationId);
            }
        }

        public int AccountId
        {
            get => _accountId;
            set
            {
                _accountId = value;
                OnPropertyChanged(() => AccountId);
            }
        }

        public int CarId
        {
            get => _carId;
            set
            {
                _carId = value;
                OnPropertyChanged(() => CarId);
            }
        }

        public DateTime RentalDate
        {
            get => _rentalDate;
            set
            {
                if (_rentalDate != value)
                {
                    _rentalDate = value;
                    OnPropertyChanged(() => RentalDate);
                }
            }
        }

        public DateTime ReturnDate
        {
            get => _returnDate;
            set
            {
                if (_returnDate != value)
                {
                    _returnDate = value;
                    OnPropertyChanged(() => ReturnDate);
                }
            }
        }


    }
}
