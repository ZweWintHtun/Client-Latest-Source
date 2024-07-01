using System.Collections.Generic;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;

//Controller for Print Line Entry
namespace Ace.Cbs.Pfm.Ctr.PTR
{
    public interface IPFMCTL00009 : IPresenter
    {
        IPFMVEW00009 PrintLineEntryView { get; set; }
        void SavePrintingFile();
        void UpdatePrintLineNo(string accountNo, int lineCount);
        void SelectPrintLineCount(string accountNo);
        bool Printing(bool isSaveUI);
        void DeletePrintingFile();
        void UpdatePrintingLine();
    }

    public interface IPFMVEW00009
    {
        string AccountNo { get; set; }
        int PrintLineNo { get; set; }
        string AccountSign { get; set; }
        IList<PFMDTO00043> PrnFiles { get; set; }
        IList<PFMDTO00058> FPrnFiles { get; set; }
        PFMDTO00043 PrnFileDTO { get; set; }
        PFMDTO00058 FPrnFileDTO { get; set; }
        bool IsDoPrinting { get; }
        void Successful(string message);
        void Failure(string message);
        void Confirmation(string message, bool isDelete);
        IPFMCTL00009 PrintLineEntryController { get; set; }
        List<string[]> printingList { get; set; }
        bool IsOnlyforPrint { get; set; }
    }
}