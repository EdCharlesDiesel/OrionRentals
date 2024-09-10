using Orion.Core.Common.Core;

namespace OrionRentals.Client.Entities
{
    /// <summary>
    /// Car entity client side.
    /// </summary>
    public class Car : ObjectBase
    {
        private int _carId;
        private string? _description;
        private string? _color;
        private int _year;
        private decimal _rentalPrice;
        private bool _currentlyRented;

        public int CarId
        {
            get => _carId;
            set {
                if (_carId != value)
                {
                    _carId = value;
                    OnPropertyChanged(()=> CarId);
                }
            }
        }        

        public string? Description
        {
            get
            {
                if (_description != null) return _description;
                return null;
            }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged(() => Description);
                }
            }
        }
        
        public string? Color
        {
            get => _color;
            set {
                if (_color != value)
                {
                    _color = value;
                    OnPropertyChanged(() => Color);
                }
            }
        }        

        public int Year
        {
            get => _year;
            set
            {
                if (_year != value)
                {
                    _year = value;
                    OnPropertyChanged(() => Year);
                }
            }
        }
               
        public decimal RentalPrice
        {
            get => _rentalPrice;
            set
            {
                if (_rentalPrice != value)
                {
                    _rentalPrice = value;
                    OnPropertyChanged(() => RentalPrice);
                }
            }
        }
        
        public bool CurrentlyRented
        {
            get => _currentlyRented;
            set
            {
                if (_currentlyRented != value)
                {
                    _currentlyRented = value;
                    OnPropertyChanged(() => CurrentlyRented);
                }
            }
        }

    }
}
