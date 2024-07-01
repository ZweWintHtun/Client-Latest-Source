using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Windows.Admin.DataModel;
using System.Windows.Forms;
using System.Data;

namespace Ace.Cbs.Mnm.Ctr.Ptr
{
    public interface IMNMCTL00056
    {
        IMNMVEW00056 View { get; set; }
        void PrintExel(string TotalVault);
        //DataTable PrintExel_New2(string TotalVault, DataGridView dgv);
        DataTable PrintExel_New(string TotalVault);
        void ClearUIControl();
        IList<CounterInfoDTO> GetAllCounterListBySourceBranchCode();
        string SendReportTitle();
        int isReceive { get; set; }
    }

    public interface IMNMVEW00056
    {
        IMNMCTL00056 Controller { get; set; }

        DataGridView DgvCashControl { get; set; }

        bool IsBranch { get; set; }
        bool IsVault { get; set; }
        bool IsCounter { get; set; }
        bool IsReversal { get; set; }
        bool IsAll { get; set; }
        bool IsPayment { get; set; }
        bool IsReceipt { get; set; }
        bool IsItem { get; set; }
        bool IsNonIssue { get; set; }
        IList<CounterInfoDTO> TocounterInfolist { get; set; }
        IList<BranchDTO> BranchList { get; set; }
        string Currency { get; set; }
        string DataComboBoxString { get; set; }
        DateTime EndDateTime { get; set; }
    }
}
