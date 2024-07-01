using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;

namespace Ace.Cbs.Cx.Cle
{
    /// <summary>
    /// Printing Data Controller
    /// </summary>
    [Serializable]
    public class CXCLE00006
    {
        public CXCLE00006() {}

       private static CXCLE00006 instance;
       public static CXCLE00006 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = SpringApplicationContext.Instance.Resolve<CXCLE00006>("CXPrintingUtilities");
                }

                return instance;
            }
        }

       public PFMDTO00038 SelectPrintLocationHeaderByCodeAndPosition(string code, string position)
       {
           return CXCLE00002.Instance.GetScalarObject<PFMDTO00038>("CXCLE00006.SelectPrintLocationHeaderByCodeAndPosition", new object[] { code, position });
       }

       public IList<PFMDTO00034> SelectPrintLocationItemByPrintLocationHeaderId(int printLocationHeaderId, int lineNo)
       {
           return CXCLE00002.Instance.GetListObject<PFMDTO00034>("CXCLE00006.SelectPrintLocationItemByPrintLocationHeaderIdAndLineNo", new object[] { printLocationHeaderId, lineNo });
       }

       public IList<PFMDTO00034> SelectPrintLocationItemByPrintLocationHeaderId(int printLocationHeaderId)
       {
           return CXCLE00002.Instance.GetListObject<PFMDTO00034>("CXCLE00006.SelectPrintLocationItemByPrintLocationHeaderId", new object[] { printLocationHeaderId });
       }

       public void SavePRNFile(PFMDTO00043 entity)
       {
           CXClientWrapper.Instance.Invoke<ICXSVE00003>(x => x.PRNFile_Save(entity));
       }
       public void UpdatePRNFile(PFMDTO00043 entity)
       {
           CXClientWrapper.Instance.Invoke<ICXSVE00003>(x => x.PRNFile_Update(entity));
       }
       public void DeletePRNFile(IList<PFMDTO00043> itemList)
       {

           CXClientWrapper.Instance.Invoke<ICXSVE00003>(x => x.PRNFile_Delete(itemList));
       }

       public PFMDTO00043 SelectByPRNFileId(int id)
       {
           return CXClientWrapper.Instance.Invoke<ICXSVE00003, PFMDTO00043>(x => x.PRNFile_SelectByPRNFileId(id));
       }

       public IList<PFMDTO00043> SelectAllPRNFile()
       {
           return CXClientWrapper.Instance.Invoke<ICXSVE00003, IList<PFMDTO00043>>(x => x.PRNFile_SelectAll());
       }

       public void SavePrintCheque(PFMDTO00014  entity)
       {
           CXClientWrapper.Instance.Invoke<ICXSVE00003>(x => x.PrintCheque_Save(entity));
       }

       public void DeletePrintCheque(IList<PFMDTO00014> itemList)
       {
           CXClientWrapper.Instance.Invoke<ICXSVE00003>(x => x.PrintCheque_Delete(itemList));
       }

       public PFMDTO00014 SelectByPrintChequeId(int id)
       {
           return CXClientWrapper.Instance.Invoke<ICXSVE00003, PFMDTO00014>(x => x.PrintCheque_SelectByPrintChequeId(id));
       }

       public IList<PFMDTO00043> SelectAllPrintingDataForCSAccounts(string[] accounts)
       {
           return CXClientWrapper.Instance.Invoke<ICXSVE00003, IList<PFMDTO00043>>(x => x.SelectPrnFileByAccountNos(accounts));
       }

       public IList<PFMDTO00058> SelectAllPrintingDataForFixedAccounts(string[] accounts)
       {
           return CXClientWrapper.Instance.Invoke<ICXSVE00003, IList<PFMDTO00058>>(x => x.SelectFPrnFileByAccountNos(accounts));
       }

       public bool UpdateAfterPrintingForCS(string accountNo,decimal printLineNo,int updatedUserId)
       {
           return CXClientWrapper.Instance.Invoke<ICXSVE00003, bool>(x => x.UpdateDataAfterPrintingForCS(accountNo,printLineNo,updatedUserId));
       }

       public bool UpdateAfterPrintingForFixed(string accountNo, decimal printLineNo,int updatedUserId)
       {
           return CXClientWrapper.Instance.Invoke<ICXSVE00003, bool>(x => x.UpdateDataAfterPrintingForFixed(accountNo, printLineNo,updatedUserId));
       }
       
    }
}
