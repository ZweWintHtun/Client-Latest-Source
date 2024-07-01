using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Mnm.Dmd
{
    [Serializable]
    public class MNMVIW00023
    {
        public MNMVIW00023() { }

        public virtual int Id { get; set; }
        public virtual string CustID { get; set; }
        public virtual string Name { get; set; }
        public virtual string Nrc { get; set; }
        public virtual string FatherName { get; set; }
        public virtual string OccupationCode { get; set; }
        public virtual string Nationality { get; set; }
        public virtual string PassportNo { get; set; }
        public virtual string TownshipCode { get; set; }
        public virtual string StateCode { get; set; }
        public virtual int CloseAc { get; set; }
        public virtual int OpenAc { get; set; }
        public virtual DateTime Date_Time { get; set; }
        public virtual DateTime CloseDate { get; set; }
        public virtual string CityCode { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Fax { get; set; }
        public virtual string Email { get; set; }
        public virtual string Address { get; set; }
        public virtual string NameOnly { get; set; }
        public virtual string SourceBr { get; set; }
        //public virtual string Cur { get; set; }//Updated by HWKO (25-Aug-2017)
        public virtual string StateDesp { get; set; }
        public virtual string CityDesp { get; set; }
        public virtual string TownShipDesp { get; set; }
        public virtual string OccupationDesp { get; set; }
    }
}
