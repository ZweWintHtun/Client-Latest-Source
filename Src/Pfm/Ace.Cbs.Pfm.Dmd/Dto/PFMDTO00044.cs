using System;
using Ace.Windows.Core.DataModel;
namespace Ace.Cbs.Pfm.Dmd
{
    //Pass Book->Transaction Printion->Printing User
    [Serializable]
    public class PFMDTO00044 :EntityBase<PFMDTO00044>
    {
       public PFMDTO00044() { }

        public PFMDTO00044(string password)
        {
            this.Password = password;
        }

        public PFMDTO00044(string userName, string password, string confirmpassword)
        {
            this.UserName = userName;
            this.Password = password;           
            this.ConfirmPassword = confirmpassword;
        }

        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
        public virtual DateTime  UsedDate { get; set; }
        public virtual string ConfirmPassword { get; set; }
        public virtual string SourceBranchCode { get; set; }
        public virtual string OldPassword { get; set; }
        public virtual string CheckStatus { get; set; }
    }
}