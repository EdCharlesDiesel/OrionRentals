using System.Runtime.Serialization;

namespace Orion.Core.Common.Core
{
    [DataContract]
    public abstract class EntityBase : IExtensibleDataObject
    {
        #region IExtensibleDataObject Members

        public ExtensionDataObject? ExtensionData { get; set; }

        #endregion
    }

}
