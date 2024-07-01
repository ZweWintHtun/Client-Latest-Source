using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer.Utt;
using Spring.Transaction;
using Spring.Transaction.Interceptor;

namespace Ace.Cbs.Tcm.Sve
{
    public class TCMSVE00045 : BaseService, ITCMSVE00045
    {
        #region DAO Properties
        private ICXSVE00006 InformationService { get; set; }
        #endregion

        #region DTO Properties

        private IList<TCMDTO00045> AccountCount { get; set; }

        private IList<TCMDTO00045> AccountDetialInfo { get; set; }

        private IList<TLMDTO00018> LoanGuaranteeList { get; set; }
        #endregion

        #region Helper Methods

        private PFMDTO00001 GetCustomerAccountCount(string custid)
        {
            return InformationService.SelectCustomerAccountCount(custid);
        }

        private void CollectAccountCount(string status, int count)
        {
            if (this.AccountCount == null)
                this.AccountCount = new List<TCMDTO00045>();
            TCMDTO00045 dto = new TCMDTO00045();
            dto.AccountType = status;
            dto.AccountCount = count;
            this.AccountCount.Add(dto);
        }

        private IList<TCMDTO00045> GetCAOFSAOFFAOFDataList(IList<PFMDTO00028> customerCAOFInfo, IList<PFMDTO00028> customerSAOFInfo, IList<PFMDTO00021> CustomerFAOFInfo)
        {
            // Updated by HWKO (26-Jun-2016) Start
            IList<TCMDTO00045> dtolist = new List<TCMDTO00045>();
            IList<PFMDTO00028> businessLoanInfo = new List<PFMDTO00028>();
            IList<PFMDTO00028> hirePurchaseLoanInfo = new List<PFMDTO00028>();
            IList<PFMDTO00028> personalLoanInfo = new List<PFMDTO00028>();

            foreach (PFMDTO00028 dto in customerCAOFInfo)
            {
                if (dto.AccountSign.Contains("B"))
                {
                    businessLoanInfo.Add(dto);
                }
                else if (dto.AccountSign.Contains("H"))
                {
                    hirePurchaseLoanInfo.Add(dto);
                }
                else if (dto.AccountSign.Contains("P"))
                {
                    personalLoanInfo.Add(dto);
                }
            }

            this.CollectAccountCount("Business Loan Account", businessLoanInfo.Count);
            this.CollectAccountCount("Hire Purchase Loan Account", hirePurchaseLoanInfo.Count);
            this.CollectAccountCount("Personal Loan Account", personalLoanInfo.Count);

            dtolist.Add(new TCMDTO00045("Business Loan Account", "Account No.", "Balance"));
            int serialCA;
            if (businessLoanInfo == null || businessLoanInfo.Count < 1)
            {
                dtolist.Add(new TCMDTO00045());
            }
            else
            {
                serialCA = 1;
                foreach (PFMDTO00028 dto in businessLoanInfo)
                {
                    // dtolist.Add(new TCMDTO00045(Convert.ToString(serial++), dto.AccountNo, dto.CurrentBal.ToString("N2")));  comment by ASDA (duplicate data)

                    if (dto.CloseDate != null)
                    {
                        dtolist.Add(new TCMDTO00045(Convert.ToString(serialCA++), dto.AccountNo, dto.CurrentBal.ToString("N2"), dto.CloseDate.Value));
                    }
                    else
                    {
                        dtolist.Add(new TCMDTO00045(Convert.ToString(serialCA++), dto.AccountNo, dto.CurrentBal.ToString("N2")));
                    }
                }
            }

            dtolist.Add(new TCMDTO00045("Hire Purchase Loan Account", "Account No.", "Balance"));
            int serialHP;
            if (hirePurchaseLoanInfo == null || hirePurchaseLoanInfo.Count < 1)
            {
                dtolist.Add(new TCMDTO00045());
            }
            else
            {
                serialHP = 1;
                foreach (PFMDTO00028 dto in hirePurchaseLoanInfo)
                {
                    // dtolist.Add(new TCMDTO00045(Convert.ToString(serial++), dto.AccountNo, dto.CurrentBal.ToString("N2")));  comment by ASDA (duplicate data)

                    if (dto.CloseDate != null)
                    {
                        dtolist.Add(new TCMDTO00045(Convert.ToString(serialHP++), dto.AccountNo, dto.CurrentBal.ToString("N2"), dto.CloseDate.Value));
                    }
                    else
                    {
                        dtolist.Add(new TCMDTO00045(Convert.ToString(serialHP++), dto.AccountNo, dto.CurrentBal.ToString("N2")));
                    }
                }
            }

            dtolist.Add(new TCMDTO00045("Personal Loan Account", "Account No.", "Balance"));
            int serialPL;
            if (personalLoanInfo == null || personalLoanInfo.Count < 1)
            {
                dtolist.Add(new TCMDTO00045());
            }
            else
            {
                serialPL = 1;
                foreach (PFMDTO00028 dto in personalLoanInfo)
                {
                    // dtolist.Add(new TCMDTO00045(Convert.ToString(serial++), dto.AccountNo, dto.CurrentBal.ToString("N2")));  comment by ASDA (duplicate data)

                    if (dto.CloseDate != null)
                    {
                        dtolist.Add(new TCMDTO00045(Convert.ToString(serialPL++), dto.AccountNo, dto.CurrentBal.ToString("N2"), dto.CloseDate.Value));
                    }
                    else
                    {
                        dtolist.Add(new TCMDTO00045(Convert.ToString(serialPL++), dto.AccountNo, dto.CurrentBal.ToString("N2")));
                    }
                }
            }
            // Updated by HWKO (26-Jun-2016) End

            #region Old Code

            //dtolist.Add(new TCMDTO00045("Saving Account", "Account No.", "Balance"));
                //int serial;

                //if (customerSAOFInfo == null || customerSAOFInfo.Count < 1)
                //{
                //    dtolist.Add(new TCMDTO00045());
                //}
                //else
                //{
                //    serial = 1;
                //    foreach (PFMDTO00028 dto in customerSAOFInfo)
                //    {
                //        //dtolist.Add(new TCMDTO00045(Convert.ToString(serial++), dto.AccountNo, dto.CurrentBal.ToString("N2"))); comment by ASDA (duplicate data)
                //        //{
                //        if (dto.CloseDate != null)
                //        {
                //            dtolist.Add(new TCMDTO00045(Convert.ToString(serial++), dto.AccountNo, dto.CurrentBal.ToString("N2"), dto.CloseDate.Value));
                //        }
                //        else
                //        {
                //            dtolist.Add(new TCMDTO00045(Convert.ToString(serial++), dto.AccountNo, dto.CurrentBal.ToString("N2")));
                //        }
                //        //}
                //    }
                //}

                //dtolist.Add(new TCMDTO00045("Current Account", "Account No.", "Balance"));
                //int serialCA;
                //if (customerCAOFInfo == null || customerCAOFInfo.Count < 1)
                //{
                //    dtolist.Add(new TCMDTO00045());
                //}
                //else
                //{
                //    serialCA = 1;
                //    foreach (PFMDTO00028 dto in customerCAOFInfo)
                //    {
                //        // dtolist.Add(new TCMDTO00045(Convert.ToString(serial++), dto.AccountNo, dto.CurrentBal.ToString("N2")));  comment by ASDA (duplicate data)

                //        if (dto.CloseDate != null)
                //        {
                //            dtolist.Add(new TCMDTO00045(Convert.ToString(serialCA++), dto.AccountNo, dto.CurrentBal.ToString("N2"), dto.CloseDate.Value));
                //        }
                //        else
                //        {
                //            dtolist.Add(new TCMDTO00045(Convert.ToString(serialCA++), dto.AccountNo, dto.CurrentBal.ToString("N2")));
                //        }
                //    }
                //}

                //dtolist.Add(new TCMDTO00045("Fixed Deposit Account", "Account No.", "Receipt"));
                //int serialFDA;
                //if (CustomerFAOFInfo == null || CustomerFAOFInfo.Count < 1)
                //{
                //    dtolist.Add(new TCMDTO00045());
                //}
                //else
                //{
                //    serialFDA = 1;
                //    foreach (PFMDTO00021 dto in CustomerFAOFInfo)
                //    {
                //        if (dto.CloseDate != null)
                //        {
                //            dtolist.Add(new TCMDTO00045(Convert.ToString(serialFDA++), dto.FledgerAccountNo, dto.ReceiptNo, dto.CloseDate.Value));
                //        }
                //        else
                //        {
                //            dtolist.Add(new TCMDTO00045(Convert.ToString(serialFDA++), dto.FledgerAccountNo, dto.ReceiptNo));
                //        }
                //    }
                //}
            #endregion
            //return dtolist;
            return dtolist;
        }
        #endregion

        #region Main Method

        [Transaction(TransactionPropagation.Required)]
        public CXDTO00011 SelectCustomerAccountInformation(string custid)
        {
            PFMDTO00001 customerInfo = this.GetCustomerAccountCount(custid);

            if (customerInfo != null)
            {
                try
                {
                    int currentCount = 0;
                    IList<PFMDTO00028> CustomerCAOFInfo = this.InformationService.SelectCustomerAccountData(custid, "C", ref currentCount);
                    //this.CollectAccountCount("Current Account", currentCount);
                    int savingCount = 0;
                    IList<PFMDTO00028> CustomerSAOFInfo = this.InformationService.SelectCustomerAccountData(custid, "S", ref savingCount);
                    //this.CollectAccountCount("Saving Account", savingCount);
                    int fixedCount = 0;
                    IList<PFMDTO00021> CustomerFAOFInfo = this.InformationService.SelectFLedgerByCustomerId(custid, ref fixedCount);
                    //this.CollectAccountCount("Fixed Deposit Account", fixedCount);
                    //if (CustomerFAOFInfo == null)
                    //{ this.CollectAccountCount("Fixed Deposit Acount", fixedCount); }
                    //else
                    //{ this.CollectAccountCount("Fixed Deposit Acount", CustomerFAOFInfo.Count); }

                    IList<TCMDTO00045> returndtolist = this.GetCAOFSAOFFAOFDataList(CustomerCAOFInfo, CustomerSAOFInfo, CustomerFAOFInfo);
                    if (CustomerCAOFInfo.Count > 0) //<--------- For LoanGuarantee
                    {
                        foreach (PFMDTO00028 dto in CustomerCAOFInfo)
                        {
                            IList<TLMDTO00018> lgList = this.InformationService.SelectLoanGuarantee(dto.AccountNo);
                            if (lgList.Count > 0)
                            {
                                if (this.LoanGuaranteeList == null)
                                    this.LoanGuaranteeList = new List<TLMDTO00018>();
                                foreach (TLMDTO00018 lg in lgList)
                                    this.LoanGuaranteeList.Add(lg);
                                //this.LoanGuaranteeList.Add(lg);
                            }
                        }
                    }
                    if (this.LoanGuaranteeList != null)
                        this.CollectAccountCount("Loan Account", this.LoanGuaranteeList.Count);
                    else
                        this.CollectAccountCount("Loan Account", 0);
                    int LoanCount = this.InformationService.SelectLoanCountByCustomerId(custid);
                    if (LoanCount > 0)
                        this.CollectAccountCount("Loans", this.LoanGuaranteeList.Count);
                    return new CXDTO00011(customerInfo, returndtolist, AccountCount, this.LoanGuaranteeList);
                }
                catch
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "ME90039";
                    return null;
                }
            }
            else
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV00016";
                return null;
            }
        }

        #endregion
    }
}
