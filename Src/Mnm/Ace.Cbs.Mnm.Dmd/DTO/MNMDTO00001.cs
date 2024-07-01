using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Mnm.Dmd
{
    [Serializable]
    public class MNMDTO00001 : Supportfields<MNMDTO00001>
    {
        public MNMDTO00001()
        { }

        public MNMDTO00001(int id, string postingname, DateTime Date_time, string status)
        {
            this.Id = id;
            this.PostingName = postingname;
            this.Date_time = Date_time;
            this.Status = status;
        }
        public int Id { get; set; }
        public string PostingName { get; set; }
        public System.Nullable<DateTime> Date_time { get; set; }
        public string Status { get; set; }
        public string UID { get; set; }
        public string SourceBr { get; set; }
        public int Month{ get; set; }
        public int Year { get; set; }
        public string Currency { get; set; }
        public string DataComboBoxString { get; set; }

        public string MessageCode { get; set; }

    }
}
