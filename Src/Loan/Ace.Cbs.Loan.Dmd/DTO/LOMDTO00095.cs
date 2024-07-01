using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Dmd.DTO
{
    [Serializable]
    public class LOMDTO00095 : EntityBase<LOMDTO00095>
    {
        public LOMDTO00095() { }

        public LOMDTO00095(string name,string nrc,string ph,string fax,string email,string address)
        {
            Name = name;
            NRC = nrc;
            Phone = ph;
            Fax = fax;
            Email = email;
            Address = address;
        }
        public string Name { get; set; }
        public string NRC { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }    
        
    }
}
