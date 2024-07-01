using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd
{
    [Serializable]
    public class LOMDTO00060 : EntityBase<LOMDTO00060>
    {
        public LOMDTO00060() { }

        public LOMDTO00060(string dealerNo, string dealerAC, string dName, string dPhone, string dAddress, string email,
                           string nrc, string fax, string businessName, string city, string businessEmail, string address,
                           double commission, string sourceBr, int createdUserId, DateTime createdDate, int updatedUserId, DateTime updatedDate)
        {
            this.dealerNo = dealerNo;
            this.dealerAC = dealerAC;
            this.dname = dName;
            this.dphone = dphone;
            this.daddress = daddress;
            this.email = email;
            this.nRC = nrc;
            this.fax = fax;
            this.business = businessName;
            this.city = city;
            this.businessEmail = businessEmail;
            this.businessAddress = address;
            this.commission = commission;
            this.sourceBr = sourceBr;
            this.createdUserId = createdUserId;
            this.createdDate = createdDate;
            this.updatedUserId = updatedUserId;
            this.updatedDate = updatedDate;


        }


        public string dealerNo { get; set; }
        public string dealerAC { get; set; }
        public string dname { get; set; }
        public string dphone { get; set; }
        public string daddress { get; set; }
        public string email { get; set; }
        public string nRC { get; set; }
        public string fax { get; set; }
        public string business { get; set; }
        public string city { get; set; }
        public string businessEmail { get; set; }
        public string businessAddress { get; set; }
        public double commission { get; set; }
        public string uID { get; set; }
        public string sourceBr { get; set; }
        public string cur { get; set; }
        public bool active { get; set; }
        public DateTime TS { get; set; }
        public DateTime createdDate { get; set; }
        public int createdUserId { get; set; }
        public DateTime updatedDate { get; set; }
        public int updatedUserId { get; set; }
    }


}
