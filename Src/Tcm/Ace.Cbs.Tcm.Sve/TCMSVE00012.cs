using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.CXServer.Utt;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Windows.Core.Service;

namespace Ace.Cbs.Tcm.Sve
{
    public class TCMSVE00012:BaseService,ITCMSVE00012
    {
        #region DAO
        public ICXSVE00006 CodeChecker { get; set; }
        public IPFMDAO00001 CustomerIdDAO { get; set; }
        public IPFMDAO00011 SChequeDAO { get; set; }
        #endregion

        #region Method
        public IList<PFMDTO00011> GetCustomersByAccountNumber(string accountNo)
        {
            PFMDTO00011 sCheque = new PFMDTO00011();
            IList<PFMDTO00011> sChequeLists = new List<PFMDTO00011>();
            if (this.CodeChecker.IsClosedAccountForCLedger(accountNo))
            {
              sCheque.CloseAccount="Close";
              sChequeLists.Add(sCheque);
            }
            else
            {
                IList<PFMDTO00017> caofDTOLists = CXServiceWrapper.Instance.Invoke<ICXSVE00006, IList<PFMDTO00017>>(x => x.GetCAOFsByAccountNumber(accountNo));
                if (caofDTOLists.Count > 0)
                {                    
                    if (caofDTOLists[0].CustomerID == null)
                    {
                        sCheque.Name = caofDTOLists[0].Name;
                        sCheque.NRC = caofDTOLists[0].NRC;
                    }
                    else
                    {
                        PFMDTO00001 customerId = CustomerIdDAO.SelectByCustomerId(caofDTOLists[0].CustomerID);
                        sCheque.Name = customerId.Name;
                        sCheque.NRC = customerId.NRC;
                    }
                }

                sChequeLists = SChequeDAO.SelectSChequeData(accountNo);
                if (sChequeLists.Count > 0)
                {
                    sChequeLists[0].Name = sCheque.Name;
                    sChequeLists[0].NRC = sCheque.NRC;
                }
                else
                {
                    sChequeLists.Add(sCheque);
                }
                
              }

            return sChequeLists;
        }

        public IList<PFMDTO00011> GetSChequeInfoByChequeBookNo(string accountNo, string chequeBookNo, string branchCode)
        {
            IList<PFMDTO00011> chequeInfo = this.SChequeDAO.GetSChequeInfoByChequeBookNo(accountNo, chequeBookNo, branchCode);

            if (chequeInfo == null || chequeInfo.Count == 0)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV00226"; //Invalid already stopped Cheque Book No.Firstly, need to stop!!
            }
            else
            {
                if (chequeInfo.Count == 1)
                {
                    ////foreach (PFMDTO00011 cheque in chequeInfo)
                    ////{
                    ////    if (!cheque.Active)
                    ////    {
                    ////        this.ServiceResult.ErrorOccurred = true;
                    ////        this.ServiceResult.MessageCode = ""; //Already released Cheque Book No.!
                    ////    }
                    ////}
                    if (!chequeInfo[0].Active)
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = ""; //Already released Cheque Book No.!
                    }                    
                }
            }
            return chequeInfo;
        }

        public void UpdateSCheckData(PFMDTO00011 sChequeData)
        {
            try
            {
                //Update SCheck Active Field
                this.SChequeDAO.UpdateSChequeData(sChequeData.AccountNo,sChequeData.ChequeBookNo, sChequeData.StartNo, sChequeData.EndNo, sChequeData.CreatedUserId, DateTime.Now);
               
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "MI90001";//Saving Successful.
            }
            catch (Exception ex)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = ex.Message;
            }
        }
        #endregion
    }
}
