using Ace.Cbs.Pfm.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Tcm.Ctr.Ptr
{
        //Freceipt Editing Interface
        public interface ITCMCTL00013 : IPresenter
        {
            bool Save(PFMDTO00032 fReceiptEntity);
            bool Delete(PFMDTO00032 fReceiptEntity);
            ITCMVEW00013 FReceiptView { get; set; }
        }

        public interface ITCMVEW00013
        {
            bool IsReverse { get; set; }
            bool IsFReceiptValidate { get; set; }
            string OldReceiptNo { get; set; }
            string AccountNo { get; set; }
            decimal Amount { get; set; }
            string Description { get; set; }
            string ReceiptNo { get; set; }
            decimal Rate { get; set; }
            decimal Duration { get; set; }
            string TakenAccount { get; set; }
            bool AutoRenewal { get; set; }
            bool OnlyPrinciple { get; set; }
            string SourceBranchCode { get; set; }
            string Status { get; set; }
            string AccountSign { get; set; }
            string CurrencyCode { get; set; }
            IList<PFMDTO00032> FReceiptList { get; set; }
            PFMDTO00032 FReceiptEntity { get; set; }
            ITCMCTL00013 FReceiptController { get; set; }
            void EnableControlsForReceiptEditing(string name);
            void VisibleControlsForReceiptEditing(bool renewalType, bool takenAccount);
            void ShowInformationMessage(string message, object[] arguments);
            void ReceiptNoDisable();
        }
}
