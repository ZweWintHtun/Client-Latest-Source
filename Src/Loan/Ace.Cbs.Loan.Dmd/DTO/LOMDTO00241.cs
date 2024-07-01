using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Loan.Dmd.DTO
{
    [Serializable]
    public class LOMDTO00241
    {
        public List<LOMDTO00240> HpList {get; set;}

        public LOMDTO00241() { }
        public LOMDTO00241(string dealerChk,string name,string nrc,string ph,string fax,string email,
                           string address,string bName,string bEmail,string bAddress,string bPhone)
        {
            DealerCheck = dealerChk;
            Name = name;
            NRC = nrc;
            Phone = ph;
            Fax = fax;
            Email = email;
            Address = address;
            BusinessName = bName;
            BusinessEmail = bEmail;
            BusinessAddress = bAddress;
            BusinessPhone = bPhone;
        }

        public string DealerCheck { get; set; }
        public string Name { get; set; }
        public string NRC { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string BusinessName { get; set; }
        public string BusinessEmail { get; set; }
        public string BusinessAddress { get; set; }
        public string BusinessPhone { get; set; }


        public string DealerAcctNo { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Currency { get; set; }
        public string SourceBr { get; set; }

        public string HPNoList { get; set; }
        public int CreatedUserId { get; set; }
        public string FormatCode { get; set; }
        public int ValueCount { get; set; }
        public string ValueStr { get; set; }


    }
}
