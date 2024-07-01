using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Pfm.Dmd
{
    [Serializable]
    public class PFMDTO00037 : Supportfields<PFMDTO00037>
    {
        

        public PFMDTO00037(string branchCode)//added by YMA
        {
            this.BranchCode = branchCode;
        }

        public PFMDTO00037(string branchCode, string branchDesp, string branchalias)//add by YMA
        {
            this.BranchCode = branchCode;
            this.BranchDescription = branchDesp;
            this.BranchAlias = branchalias;
        }

        public PFMDTO00037()
        {
            CityCodes = new List<PFMDTO00012>();
            StateCodes = new List<PFMDTO00013>();
            TownshipCodes = new List<PFMDTO00005>();
        }

        public PFMDTO00037(string branchCode, string br_Alias, string branchDesp, string address, string fax, string phone, string email, string stateCode, string cityCode, string townshipCode, bool otherBank, string bank_Alias)
        {
            this.BranchCode = branchCode;
            this.BranchAlias = br_Alias;
            this.BranchDescription = branchDesp;
            this.Address = address;
            this.Fax = fax;
            this.Phone = phone;
            this.Email = email;
            this.StateCode = stateCode;
            this.CityCode = cityCode;
            this.TownshipCode = townshipCode;
            this.OtherBank = otherBank;
            this.Bank_Alias = bank_Alias;
        }

        public PFMDTO00037(string branchCode, string br_Alias, string branchDesp, string address, string fax, string phone, string email, string stateCode, string cityCode, string townshipCode, bool otherBank, string bank_Alias, bool active, byte[] tS, DateTime createdDate, int createdUserId, System.Nullable<DateTime> updatedDate, System.Nullable<int> updatedUserId)
        {
            this.BranchCode = branchCode;
            this.BranchAlias = br_Alias;
            this.BranchDescription = branchDesp;
            this.Address = address;
            this.Fax = fax;
            this.Phone = phone;
            this.Email = email;
            this.StateCode = stateCode;
            this.CityCode = cityCode;
            this.TownshipCode = townshipCode;
            this.OtherBank = otherBank;
            this.Bank_Alias = bank_Alias;
            this.Active = active;
            this.TS = tS;
            this.CreatedDate = createdDate;
            this.CreatedUserId = createdUserId;
            this.UpdatedDate = updatedDate;
            this.UpdatedUserId = updatedUserId;
        }

        public virtual IList<PFMDTO00012> CityCodes { get; set; }
        public virtual IList<PFMDTO00013> StateCodes { get; set; }
        public virtual IList<PFMDTO00005> TownshipCodes { get; set; }
        public virtual string BranchCode { get; set; }
        public virtual string BranchAlias { get; set; }
        public virtual string BranchDescription { get; set; }
        public virtual string Address { get; set; }
        public virtual string Fax { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Email { get; set; }
        public virtual string Status { get; set; }
        public virtual string StateCode { get; set; }
        public virtual string CityCode { get; set; }
        public virtual string TownshipCode { get; set; }
        public virtual bool OtherBank { get; set; }
        public virtual string Bank_Alias { get; set; }
        public virtual bool IsCheck { get; set; }
    }
}