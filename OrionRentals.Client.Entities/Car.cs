namespace OrionRentals.Client.Entities
{
    /// <summary>
    /// Car entity client side.
    /// </summary>
    public class Car
    {
        private int _carId;
        private string? _description;
        private string? _color;
        private int _year;
        private decimal _rentalPrice;
        private bool _currentlyRented;

        public int CarId
        {
            get { return _carId; }
            set { _carId = value; }
        }        

        public string? Description
        {
            get
            {
                if (_description != null) return _description;
                return null;
            }
            set { _description = value; }
        }
        
        public string? Color
        {
            get { return _color; }
            set { _color = value; }
        }        

        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }
               
        public decimal RentalPrice
        {
            get { return _rentalPrice; }
            set { _rentalPrice = value; }
        }
        
        public bool CurrentlyRented
        {
            get { return _currentlyRented; }
            set { _currentlyRented = value; }
        }

    }
}
