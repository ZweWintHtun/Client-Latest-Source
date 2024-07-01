using System;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    /// <summary>
    /// AppSettings DTO Entity
    /// </summary>
    [Serializable]
    public class PFMDTO00053 : EntityBase<PFMDTO00053>
    {
        public PFMDTO00053() { }

        public PFMDTO00053(string keyValue)
        {
            this.KeyValue = keyValue;
        }

        //Id,KeyName,KeyValue,Description,Location,Type,BinaryValue,Active,CreatedDate,CreatedUserId,UpdatedDate,UpdatedUserId,TS
        public PFMDTO00053(int id, string keyName, string keyValue, string description, int clientServer, int type, byte[] binaryValue, bool active,  DateTime createdDate, int createdUserId, Nullable<DateTime> updatedDate, Nullable<int> updatedUserId,byte[] ts)
        {            
            this.Id = id;
            this.KeyName = keyName;
            this.KeyValue = keyValue;
            this.BinaryValue = binaryValue;
            this.Description = description;
            this.Location = clientServer;
            this.Type = type;
            this.Active = active;
            this.TS = ts;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        public PFMDTO00053(int id, string keyName, string keyValue, byte[] binaryValue, string description, int clientServer, int type, bool active, byte[] ts, DateTime createdDate, int createdUserId, DateTime updatedDate, int updatedUserId)
        {
            this.Id = id;
            this.KeyName = keyName;
            this.KeyValue = keyValue;
            this.BinaryValue = binaryValue;
            this.Description = description;
            this.Location = clientServer;
            this.Type = type;
            this.Active = active;
            this.TS = ts;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        public string KeyName { get; set; }
        public string KeyValue { get; set; }
        public byte[] BinaryValue { get; set; }
        public string Description { get; set; }
        public int Location { get; set; }
        public int Type { get; set; }
        public virtual bool IsCheck { get; set; }
    }
}
