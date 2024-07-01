using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    /// <summary>
    /// Server Version DTO Entity
    // </summary>
    [Serializable]
    public class PFMDTO00031 : EntityBase<PFMDTO00031>
    {       
        public PFMDTO00031() { }

        public PFMDTO00031(int id, decimal version, string ormName, string ormDescription, string ormProperties, string dtoName, string dataIdName, string dataIdValue, int status)
        {
            this.Id = id;
            this.Version = version;
            this.ORMName = ormName;
            this.ORMDescription = ormDescription;
            this.ORMProperties = ormProperties;
            this.DTOName = dtoName;
            this.DataIdName = dataIdName;
            this.DataIdValue = dataIdValue;
            this.Status = status;
        }

        public PFMDTO00031(int id, string ormName, string ormDescription, decimal version, int status)
        {
            this.Id = id;
            this.ORMName = ormName;
            this.ORMDescription = ormDescription;
            this.Version = version;
            this.Status = status;
        }

        public virtual decimal Version { get; set; }
        public virtual string ORMName { get; set; }
        public virtual string ORMDescription { get; set; }
        public virtual string ORMProperties { get; set; }
        public virtual string DTOName { get; set; }
        public virtual string DataIdName { get; set; }
        public virtual string DataIdValue { get; set; }
        public virtual int Status { get; set; }        
    }
}