using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Loan.Dmd.DTO
{
    [Serializable]
    public class LOMDTO00433
    {
        public LOMDTO00433(){}
        public LOMDTO00433(Int16 no, string name, string userType, int id, bool select)
        {
            this.No = no;
            this.UserName = name;
            this.UserType = userType;
            this.Id = id;
            this.Select = select;
        }

        public virtual bool Select { get; set; }
        public virtual int Id { get; set; }
        public virtual Int64 No { get; set; }
        public virtual string UserName { get; set; }
        public virtual string UserType { get; set; }
    }

}
