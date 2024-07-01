using System;
using System.Drawing;
using ACE.CBS.TLM.DMD;
using ACE.CBS.PFM.DMD;
using System.Collections.Generic;
using ACE.Windows.Core.Presenter;

namespace ACE.CBS.TLM.CTR.PTR
{
    public interface ITLMCTL00010
    {
        ITLMVEW00010 View { get; set; }
        void ClearControls();
    }
    public interface ITLMVEW00010
    {
        ITLMCTL00010 Controller { get; set; }
        IList<PFMDTO00001> CustomerDataSource { get; set; }

        string AccountNo{ get; set; }       
        string Name{ get; set; }
        string CurrencyCode { get; set; }
        string Currency { get; set; }
        string Narration{ get; set; }       
        decimal Amount{ get; set; }       
        decimal CommunicationCharges{ get; set; }       
        decimal Commissions{ get; set; }
        decimal TotalAmount { get; set; }
        bool InputIncomeAmount{ get; set; }
        bool PrintTransactions { get; set; }

        void SetCursor(string txt);
        void Successful(string message, string VoucherNo);
        void Failure(string message);
    }
}
