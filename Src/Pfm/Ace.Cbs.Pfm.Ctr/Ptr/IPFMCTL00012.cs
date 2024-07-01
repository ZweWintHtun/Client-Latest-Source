using System.Collections.Generic;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;


namespace Ace.Cbs.Pfm.Ctr.PTR
{
    /// <summary>
    /// LinkAccount Controller Interface
    /// </summary>
    public interface IPFMCTL00012 : IPresenter 
    {        
        void Save(PFMDTO00029 entity);
        void ClearControls();
        IPFMVEW00012 LinkAccountView { set; get; }
    }
    /// <summary>
    /// LinkAccount View Interface
    /// </summary>
    public interface IPFMVEW00012 //LinkAccountView
    {
        string CurrentAccountNo { get; set; }
        string SavingAccountNo { get; set; }
        decimal CurrentAccountMinimumBalance { get; set; }
        decimal SavingAccountMinimumBalance { get; set; }        

        PFMDTO00029 LinkAccountEntity { get; set; }
        IPFMCTL00012 LinkAccountController { set; get; }
        void Successful(string message);
        void Failure(string message,string accountno);
        void lvCurrentNames_DataBind(IList<string> customerNames);
        void lvSavingNames_DataBind(IList<string> customerNames);
    }
}