using Orion.Core.Common.Core;

namespace OrionRentals.Client.Entities
{
    /// <summary>
    /// Account entity client side.
    /// </summary>
    public class Account : ObjectBase
    {
        private int _accountId;
        private string? _loginEmail;
        private string? _firstName;
        private string? _lastName;
        private string? _address;
        private string? _city;
        private string? _state;
        private string? _zipCode;
        private string? _creditCard;
        private string? _expDate;

        public int AccountId
        {
            get => _accountId;
            set {
                if (_accountId != value)
                {
                    _accountId  = value;
                    OnPropertyChanged(()=> _accountId);
                }
            }
        }        

        public string? LoginEmail
        {
            get
            {
                if (_loginEmail != null) return _loginEmail;
                return null;
            }
            set
            {
                if (_loginEmail != value)
                {
                    _loginEmail = value;
                    OnPropertyChanged(() => LoginEmail);
                }
            }
        }
        
        public string? FirstName
        {
            get => _firstName;
            set {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged(() => FirstName);
                }
            }
        }

        public string? LastName
        {
            get => _lastName;
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged(() => LastName);
                }
            }
        }

        public string? Address
        {
            get => _address;
            set
            {
                if (_address != value)
                {
                    _address = value;
                    OnPropertyChanged(() => Address);
                }
            }
        }

        public string? City
        {
            get => _city;
            set
            {
                if (_city != value)
                {
                    _city = value;
                    OnPropertyChanged(() => City);
                }
            }
        }

        public string? State
        {
            get => _state;
            set
            {
                if (_state != value)
                {
                    _state = value;
                    OnPropertyChanged(() => State);
                }
            }
        }

        public string? ZipCode
        {
            get => _zipCode;
            set
            {
                if (_zipCode != value)
                {
                    _zipCode = value;
                    OnPropertyChanged(() => ZipCode);
                }
            }
        }

        public string? CreditCard
        {
            get => _creditCard;
            set
            {
                if (_creditCard != value)
                {
                    _creditCard = value;
                    OnPropertyChanged(() => CreditCard);
                }
            }
        }
        public string? ExpDate
        {
            get => _expDate;
            set
            {
                if (_expDate != value)
                {
                    _expDate = value;
                    OnPropertyChanged(() => ExpDate);
                }
            }
        }

    }
}
