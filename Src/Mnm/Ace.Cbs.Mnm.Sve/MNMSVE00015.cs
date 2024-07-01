using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Windows.Core.Service;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Ctr;
using Spring.Transaction;
using Spring.Transaction.Interceptor;

namespace Ace.Cbs.Mnm.Sve
{
    public class MNMSVE00015:BaseService,IMNMSVE00015
    {
        #region Properties
        ITLMDAO00016 PODAO { get; set; }
        IPFMDAO00028 CLedgerDAO { get; set; }
        ICXDAO00006 cxDAO00006 { get; set; }
        ICXSVE00006 ReversalService { get; set; }
        ICXSVE00002 CodeGenerator { get; set; }
        IPFMDAO00054 TLFDAO { get; set; }
        #endregion
        public IList<TLMDTO00016> CheckPO(string poNo,string sourceBr)
        {
            string currentBudYear = string.Empty;
            string value = CXCOM00007.Instance.GetValueByVariable(CXCOM00009.BudgetYearCode);
            int month = Convert.ToInt32(value.ToString());
            if (DateTime.Today.Month < month)
            {
                currentBudYear = (DateTime.Today.Year - 1).ToString() + "/" + DateTime.Today.Year.ToString();
            }
            else
            {
                currentBudYear = DateTime.Today.Year.ToString() + "/" + (DateTime.Today.Year + 1).ToString();
            }

            //Select PO
             IList<TLMDTO00016> PO = this.PODAO.POData(poNo, currentBudYear, sourceBr);

            if (PO == null)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV00219"; //PO No Not Found
                return null;
            }
            if (PO[0].IDate != null && PO[0].IDate.Value != default(DateTime) && PO[0].IDate.ToString() != string.Empty)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV30037"; //This PO has been cleared
                return null;
            }
            if (PO[0].ADate.Value.ToShortDateString() != DateTime.Now.ToShortDateString())
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MI30046"; //Too Late to edit
                return null;
            }

            #region Get_Control_Account
            string controlAccount = string.Empty;
            controlAccount = CXCOM00010.Instance.GetCoaSetupAccountNo("POR", sourceBr, PO[0].Currency);   //Get Coa Account
            if (controlAccount == null || controlAccount == string.Empty)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MI30024"; //Coa Setup Account Not Found
                return null;
            }
            #endregion

            if (controlAccount == PO[0].ACode)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV30036";    //Not allow to edit Encashment PO.
                return null;
            }
            if (string.IsNullOrEmpty(PO[0].AccountNo))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV00211";    //P.O (by Transfer) Only.
                return null;
            }
            if (PO[0].AccountNo.Length > 6)
            {
                PFMDTO00028 cledgerAccount = this.CLedgerDAO.SelectByAccountNoAndSourceBr(PO[0].AccountNo, sourceBr);
                if (cledgerAccount == null)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MV00175";    //Account No. Not Found.
                    return null;
                }

                IList<PFMDTO00017> CAOFs;
                IList<PFMDTO00016> SAOFs;
                IList<PFMDTO00021> FAOFs;

                switch (cledgerAccount.AccountSign[0])
                {
                    case 'C':
                        CAOFs=this.cxDAO00006.GetCAOFsByAccountNumber(PO[0].AccountNo);
                        IList<PFMDTO00017> caofs = CAOFs.Where(x => x.CustomerID == null || x.CustomerID == string.Empty).ToList();
                        if (caofs == null || caofs.Count == 0)
                        {
                            PFMDTO00017 caof = (PFMDTO00017)CAOFs.Where(x => x.CustomerID != null && x.CustomerID != string.Empty).OrderBy(x => x.SerialofCustomer).First();
                            PO[0].CustomerName = this.cxDAO00006.GetCustomerAccountCount(caof.CustomerID).Name;
                        }
                        else
                        {
                            PO[0].CustomerName = caofs[0].Name;
                        }
                        break;
                    case 'S':
                        SAOFs = this.cxDAO00006.GetSAOFsByAccountNumber(PO[0].AccountNo);
                        IList<PFMDTO00016> saofs = SAOFs.Where(x => x.Customer_Id == null || x.Customer_Id == string.Empty).ToList();
                        if (saofs == null || saofs.Count == 0)
                        {
                            PFMDTO00016 saof = SAOFs.Where(x => x.Customer_Id != null && x.Customer_Id != string.Empty).OrderBy(x => x.SerialofCustomer).First();
                            PO[0].CustomerName = this.cxDAO00006.GetCustomerAccountCount(saof.Customer_Id).Name;
                        }
                        else
                        {
                            PO[0].CustomerName = saofs[0].Name;
                        }
                        ; break;
                    case 'F':
                        FAOFs = this.cxDAO00006.GetFAOFsByAccountNumber(PO[0].AccountNo);
                        IList<PFMDTO00021> faofs = FAOFs.Where(x => x.CustomerId == null || x.CustomerId == string.Empty).ToList();
                        if (faofs == null || faofs.Count == 0)
                        {
                            PFMDTO00021 faof = FAOFs.Where(x => x.CustomerId != null && x.CustomerId != string.Empty).OrderBy(x => x.SerialOfCustomer).First();
                            PO[0].CustomerName = this.cxDAO00006.GetCustomerAccountCount(faof.CustomerId).Name;
                        }
                        else
                        {
                            PO[0].CustomerName = faofs[0].Name;
                        }
                        ; 
                        break;
                    case 'L':
                        ; break;
                    default: ; break;
                }
            }
            return PO;
        }

        [Transaction(TransactionPropagation.Required)]
       // public string Save(string poNo,int currentUserId,string sourceBr)
        public IList<PFMDTO00054> Save(TLMDTO00016 entity)
        {
            DateTime todayDate = DateTime.Now;
            string day = todayDate.Day.ToString().PadLeft(2, '0');
            string month = todayDate.Month.ToString().PadLeft(2, '0');
            string year = todayDate.Year.ToString().Substring(2);
            string voucherNo = this.CodeGenerator.GetGenerateCode("POReversalVoucher", string.Empty, entity.CreatedUserId, entity.SourceBranchCode, new object[] { day, month, year });

            IList<PFMDTO00054> tlfList = this.TLFDAO.SelectTlfForPORegisterByTransferReversal(entity.PONo, entity.SourceBranchCode);
            if (tlfList.Count > 0)
            {
                this.ReversalService.ReversalProcess(tlfList[0].Eno, voucherNo, string.Empty, entity.SourceBranchCode, Convert.ToDateTime(tlfList[0].SettlementDate), entity.SourceBranchCode, entity.CreatedUserId, null, string.Empty, true);
                if (this.ReversalService.ServiceResult.ErrorOccurred)
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = ReversalService.ServiceResult.MessageCode;
                    throw new Exception(this.ServiceResult.MessageCode);
                }
                this.PODAO.DeletePOByActive(entity.PONo, entity.SourceBranchCode, entity.CreatedUserId);
            }
            tlfList[0].RegisterNo = voucherNo; 
            return tlfList;
        }
    }
}
