using FluentValidation;
using Orion.Core.Common.Core;

namespace Orion.Core.CommonTests.Core.Test_Classes
{
    internal class TestClass : ObjectBase
    {
        string _cleanProp = string.Empty;
        string _dirtyProp = string.Empty;
        string _stringProp = string.Empty;
        readonly TestChild _child = new TestChild();
        readonly TestChild _notNavigableChild = new TestChild();

        public string CleanProp
        {
            get => _cleanProp;
            set
            {
                if (_cleanProp == value)
                    return;

                _cleanProp = value;
                OnPropertyChanged(() => CleanProp, false);
            }
        }

        public string DirtyProp
        {
            get => _dirtyProp;
            set
            {
                if (_dirtyProp == value)
                    return;

                _dirtyProp = value;
                OnPropertyChanged(() => DirtyProp);
            }
        }

        public string StringProp
        {
            get => _stringProp;
            set
            {
                if (_stringProp == value)
                    return;

                _stringProp = value;
                OnPropertyChanged("StringProp", false);
            }
        }

        public TestChild Child
        {
            get { return _child; }
        }

        [NotNavigable]
        public TestChild NotNavigableChild
        {
            get { return _notNavigableChild; }
        }

        class TestClassValidator : AbstractValidator<TestClass>
        {
            public TestClassValidator()
            {
                RuleFor(obj => obj.StringProp).NotEmpty();
            }
        }

        protected override IValidator GetValidator()
        {
            return new TestClassValidator();
        }
    }
}
