using Orion.Core.Common.Core;

namespace OrionRentals.Client.Entities
{
    /// <summary>
    /// Rental entity client side.
    /// </summary>
    public class Rental : ObjectBase
    {
        private int _rentalId;
        private int _accountId;
        private int _carId;
        private DateTime _dateRented;
        private DateTime _dateDue;
        private DateTime _dateReturned;


        public int RentalId
        {
            get => _rentalId;
            set
            {
                if (_rentalId != value)
                {
                    _rentalId = value;
                    OnPropertyChanged(() => RentalId);
                }
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
                if (_carId != value)
                {
                    _carId = value;
                    OnPropertyChanged(() => CarId);
                }
            }
        }

        public DateTime DateRented
        {
            get => _dateRented;
            set
            {
                if (_dateRented != value)
                {
                    _dateRented = value;
                    OnPropertyChanged(() => DateRented);
                }
            }
        }

        public DateTime DateDue
        {
            get => _dateDue;
            set
            {
                if (_dateDue != value)
                {
                    _dateDue = value;
                    OnPropertyChanged(() => DateDue);
                }
            }
        }

        public DateTime DateReturned
        {
            get => _dateReturned;
            set
            {
                if (_dateReturned != value)
                {
                    _dateReturned = value;
                    OnPropertyChanged(() => DateReturned);
                }
            }
        }

    }
}
