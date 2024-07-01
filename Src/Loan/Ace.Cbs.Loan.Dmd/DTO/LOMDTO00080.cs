using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMDTO00080 : EntityBase<LOMDTO00080>
    {
        public LOMDTO00080() { }
        public LOMDTO00080(string dealerNo, string dealerAC, string dName, string businessName, string dPhone
                           , string dAddress, string email,string nrc, string fax, string city
                           , string businessEmail, string address,decimal commission)
                           //, string uId, string sourceBr, string cur, bool active, DateTime createdDate, int createdUserId, DateTime updatedDate, int updatedUserId)
        {
            DealerNo = dealerNo;
            DealerAC = dealerAC;
            Dname = dName;
            Business = businessName;
            Dphone = dPhone;
            Daddress = dAddress;
            this.email = email;
            NRC = nrc;
            this.fax = fax;
            this.city = city;
            BusinessEmail = businessEmail;
            BusinessAddress = address;
            this.commission = commission;

            //UID = uId;
            //SourceBr = sourceBr;
            //Cur = cur;
            //Active = active;
            //CreatedUserId = createdUserId;
            //CreatedDate = createdDate;
            //UpdatedUserId = updatedUserId;
            //UpdatedDate = updatedDate;

        }
        public string DealerNo { get; set; }
        public string DealerAC { get; set; }
        public string Dname { get; set; }
        public string Dphone { get; set; }
        public string Daddress { get; set; }
        public string email { get; set; }
        public string NRC { get; set; }
        public string fax { get; set; }
        public string Business { get; set; }
        public string city { get; set; }
        public string BusinessEmail { get; set; }
        public string BusinessAddress { get; set; }
        public decimal commission { get; set; }
        public string DealerNoList { get; set; }

        //public string UID { get; set; }
        //public string SourceBr { get; set; }
        //public string Cur { get; set; }
        //public bool Active { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public int CreatedUserId { get; set; }
        //public DateTime UpdatedDate { get; set; }
        //public int UpdatedUserId { get; set; }

    }

}
