namespace OrionRentals.Client.Entities
{
    /// <summary>
    /// Car entity client side.
    /// </summary>
    public class Car
    {
        private int _carId;

        public int MyProperty
        {
            get { return _carId; }
            set { _carId = value; }
        }

    }
}
