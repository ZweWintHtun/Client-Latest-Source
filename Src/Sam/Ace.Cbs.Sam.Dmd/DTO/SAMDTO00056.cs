using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Sam.Dmd
{
        [Serializable]
   public class SAMDTO00056
    {    
        public SAMDTO00056() { }

        public SAMDTO00056(string code,decimal duration,string desp,string rate,DateTime datetime,string userno,string status) 
        {
            CODE = code;
            DURATION=duration;
            DESP = desp;
            RATE = rate;
            DATE_TIME = datetime;
            USERNO = userno;
            STATUS = status;
        }
        //public int Id { get; set; }
        public string CODE { get; set; }
        public Nullable<decimal> DURATION { get; set; }
        public string DESP { get; set; }
        public string RATE { get; set; }
        public Nullable<DateTime> DATE_TIME { get; set; }
        public string USERNO { get; set; }
        public string STATUS { get; set; }
    }
}
