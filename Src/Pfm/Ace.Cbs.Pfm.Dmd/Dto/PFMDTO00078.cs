using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    //Solidarity DTO
    [Serializable]
    public class PFMDTO00078 : Supportfields<PFMDTO00078>
    {
        public PFMDTO00078() { }

        public PFMDTO00078(int id)
        {
            this.Id = id;
        }

        public PFMDTO00078(int id, string groupNo, string name, bool isNRC, string nrcNo, string fatherName, string villageCode, string address, DateTime openDate, string userNo, string sourceBr, bool active)
        {
            this.Id = id;
            this.GroupNo = groupNo;
            this.NameOnly = name;
            this.IsNRC = isNRC;
            this.NRCNo = nrcNo;
            this.FatherName = fatherName;
            this.VillageCode = villageCode;
            this.Address = address;
            this.OpenDate = openDate;
            this.UserNo = userNo;
            this.SourceBr = sourceBr;
            this.Active = active;
        }

        public PFMDTO00078(int id, string groupNo, string name, bool isNRC, bool isLeader, string nrcNo, string fatherName, string villageCode, string address, DateTime openDate, string userNo, string sourceBr, bool active, byte[] ts, DateTime createdDate, int createdUserID, Nullable<DateTime> updatedDate, int updatedUserID, string desp)
        {
            this.Id = id;
            this.GroupNo = groupNo;
            this.NameOnly = name;
            this.IsNRC = isNRC;
            this.IsLeader = isLeader;
            this.NRCNo = nrcNo;
            this.FatherName = fatherName;
            this.VillageCode = villageCode;
            this.Address = address;
            this.OpenDate = openDate;
            this.UserNo = userNo;
            this.SourceBr = sourceBr;
            this.Active = active;
            this.TS = ts;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserID;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = UpdatedUserId;
            this.Desp = desp;
        }

        public PFMDTO00078(int id, string groupNo, string name, bool isNRC, string nrcNo, string fatherName, string villageCode, string address, DateTime openDate, string userNo, string sourceBr, bool active, byte[] ts, DateTime createdDate, int createdUserID, Nullable<DateTime> updatedDate, int updatedUserID)
        {
            this.Id = id;
            this.GroupNo = groupNo;
            this.NameOnly = name;
            this.IsNRC = isNRC;
            this.NRCNo = nrcNo;
            this.FatherName = fatherName;
            this.VillageCode = villageCode;
            this.Address = address;
            this.OpenDate = openDate;
            this.UserNo = userNo;
            this.SourceBr = sourceBr;
            this.Active = active;
            this.TS = ts;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserID;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = UpdatedUserId;
        }      

        public PFMDTO00078(int id, string groupNo, string name, bool isNRC, string nrcNo, string fatherName, string villageCode, string address, DateTime openDate, string userNo, string sourceBr)
        {
            this.Id = id;
            this.GroupNo = groupNo;
            this.NameOnly = name;
            this.IsNRC = isNRC;
            this.NRCNo = nrcNo;
            this.FatherName = fatherName;
            this.VillageCode = villageCode;
            this.Address = address;
            this.OpenDate = openDate;
            this.UserNo = userNo;
            this.SourceBr = sourceBr;
        }      

        public PFMDTO00078(int id, string groupNo, string name, bool isNRC, string nrcNo, string fatherName, string villageCode, string address, DateTime openDate, string userNo, string sourceBr, bool active, int createdUserID, DateTime createdDate, byte[] ts)
        {
            this.Id = id;
            this.GroupNo = groupNo;
            this.NameOnly = name;
            this.IsNRC = isNRC;
            this.NRCNo = nrcNo;
            this.FatherName = fatherName;
            this.VillageCode = villageCode;
            this.Address = address;
            this.OpenDate = openDate;
            this.UserNo = userNo;
            this.SourceBr = sourceBr;
            this.Active = active;
            this.CreatedUserId = CreatedUserId;
            this.CreatedDate = createdDate;
            this.TS = ts;
        }

        public PFMDTO00078(int id, string nameOnly, bool isNRC, string nrcNo, string fatherName, string villageCode, string address)
        {
            this.Id = id;
            this.NameOnly = nameOnly;
            this.IsNRC = isNRC;
            this.NRCNo = nrcNo;
            this.FatherName = fatherName;
            this.VillageCode = villageCode;
            this.Address = address;
        }

        public virtual int Id { get; set; }
        public virtual string GroupNo { get; set; }
        public virtual string NameOnly { get; set; }
        public virtual bool IsNRC { get; set; }
        public virtual bool IsLeader { get; set; }
        public virtual string NRCNo { get; set; }
        public virtual string FatherName { get; set; }
        public virtual string VillageCode { get; set; }
        public virtual string Address { get; set; }
        public virtual DateTime OpenDate { get; set; }
        public virtual string UserNo { get; set; }
        public virtual string SourceBr { get; set; }
        public virtual bool IsCheck { get; set; }
        public virtual string Desp { get; set; }

        /// <summary>
        /// For NRC
        /// </summary>
        public string StateCodeForNRC { get; set; }
        public string TownshipCodeForNRC { get; set; }
        public string NationalityCodeForNRC { get; set; }
    }
}
