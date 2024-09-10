using Orion.Core.Common.Core;

namespace Orion.Core.CommonTests.Core.Test_Classes
{
    internal class TestChild : ObjectBase
    {
        string _childName = string.Empty;

        public string ChildName
        {
            get => _childName;
            set
            {
                if (_childName == value)
                    return;

                _childName = value;
                OnPropertyChanged(() => ChildName);
            }
        }
    }
}
