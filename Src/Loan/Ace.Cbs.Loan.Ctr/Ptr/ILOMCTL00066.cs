using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Dmd.DTO;

using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00066:IPresenter
    {
        ILOMVEW00067 View { get; set; }
        string SaveDealerRegistration(string dealerNo, string dealerAC, string dName, string dPhone, string dAddress, string email, string nrc, string fax, string businessName, string city, string businessEmail, string address, decimal commission, string eventMode, string sourceBr, int createdUserId, DateTime createdDate, int updatedUserId, DateTime updatedDate);
        void DeleteDealerRegistration(string dealerNo, int createdUserId, string sourceBr);
        void Call_Enquiry();
        void Call_DealerSearch();
        IList<LOMDTO00095> GetDealerAccountInfo(string acctNo, string sourceBr);
        //void mtxtDealerAcctno_CustomValidating(object sender, ValidationEventArgs e);
        void mtxtAcctno_CustomValidating(object sender, ValidationEventArgs e);
        PFMDTO00067 GetAccountInformation();
        string CheckAccountExistsOrValid(string caccount, string sourceBr);
        IList<LOMDTO00080> GetAllDealerInformation(string sourceBr);
    }

    public interface ILOMVEW00067
    {
        ILOMCTL00066 Controller { get; set; }
        //TLMDTO00038 TransferEntity { get; set; }
        string dealerNo { get; set; }
        string dealerAC { get; set; }
        string dname { get; set; }
        string dphone { get; set; }
        string daddress { get; set; }
        string email { get; set; }
        string nRC { get; set; }
        string fax { get; set; }
        string business { get; set; }
        string city { get; set; }
        string businessEmail { get; set; }
        string businessAddress { get; set; }
        decimal commission { get; set; }
        void Successful(string message, string dealerNo);
        bool ValidationControls();
    }
}
