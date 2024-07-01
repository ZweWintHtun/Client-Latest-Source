using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;

namespace Ace.Cbs.Pfm.Ctr.Sve
{
    public interface IPFMSVE00027 : IBaseService
    {
        PFMDTO00032 Save(PFMDTO00032 freceiptentity, bool forAccountOpening);
        void Update(int id, string rNo);
        //bool CheckExistAccountNoForCurrentAndSaving(string takenAccountNo);

        IPFMDAO00032 FReceiptDAO { set;}
        IPFMDAO00023 FledgerDAO { set; }
    }
}