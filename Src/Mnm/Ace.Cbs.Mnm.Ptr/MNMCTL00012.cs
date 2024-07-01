using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Ace.Cbs.Cx.Com;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.PTR;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Tel.Dmd;
using System.Windows.Forms;
using Ace.Cbs.Tcm.Dmd;

namespace Ace.Cbs.Mnm.Ptr
{
    public class MNMCTL00012 : AbstractPresenter, IMNMCTL00012
    {
        public MNMCTL00012() 
       {
           this.BranchCode = CXCOM00007.Instance.BranchCode;
       }
        #region "Property"
        private DateTime dateIntlf { get; set; }
        private bool isSaveValidate = false;
        private string BranchCode { get; set; }
        public string strPONO = string.Empty;
        public string bud = string.Empty;
        public string eno = string.Empty;
        public string pono = string.Empty;
        public string strBank = string.Empty;
        public decimal amt,amt2;
        public string strTranCode = string.Empty;
        public DateTime dtSettlement;
        public TLMDTO00015 casndenodto;

        public IList<PFMDTO00054> AcType { get; set; }
        private IMNMVEW00012 view;
        public IMNMVEW00012 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        #endregion

        #region WireTo

        private void WireTo(IMNMVEW00012 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetPORInfoEntity());
            }
        }

        #endregion WireTo

        #region Method

        public void txtPaySlipNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError == false)
            {
                try
                {
                    eno = this.View.Eno;
                    if (!string.IsNullOrEmpty(eno))
                    {
                        this.SetCustomErrorMessage(this.GetControl("txtPaySlipNo"), string.Empty);
                        IList<PFMDTO00054> Tlfdto = new List<PFMDTO00054>();
                        Tlfdto = this.GetPORInfoByEno();
                       // Tlfdto = CXClientWrapper.Instance.Invoke<IMNMSVE00012, PFMDTO00054>(x => x.SelectTlfInfoByEntryNoandDateTime(this.view.Eno, "PORCL", "RPORCL", this.BranchCode));
                        if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                        {
                            this.SetCustomErrorMessage(this.GetControl("txtPaySlipNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                        }
                        else
                        {
                        //    this.SetCustomErrorMessage(this.GetControl("txtPaySlipNo"), string.Empty);
                            amt = Tlfdto[0].Amount;
                            this.View.Eno = Tlfdto[0].Eno;
                            strTranCode = Tlfdto[0].TransactionCode.ToString();
                            dateIntlf = Convert.ToDateTime(Tlfdto[0].DateTime);
                           // dtSettlement = CXCOM00010.Instance.GetNextSettlementDate("NEXT_SETTLEMENT_DATE", CurrentUserEntity.BranchCode);
                            this.strPONO = Tlfdto[0].PaymentOrderNo.ToString();

                            if (!string.IsNullOrEmpty(Tlfdto[0].OrgnEno))
                            {
                                //show error message ("not allowed,already reversal")
                                this.SetCustomErrorMessage(this.GetControl("txtPaySlipNo"), "ME30003");
                            }
                           
                            else if (Convert.ToDateTime(Tlfdto[0].DateTime).ToShortDateString() !=  DateTime.Now.ToShortDateString())
                            {
                                //show error message (Not allow back date transaction.) 
                                this.SetCustomErrorMessage(this.GetControl("txtPaySlipNo"), "ME30002");
                                return;
                            }
                            else
                            {
                                this.SetCustomErrorMessage(this.GetControl("txtPaySlipNo"), string.Empty);
                                this.View.OtherBank = Tlfdto[0].OtherBank;
                                this.View.Budget = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode);
                            }
                        }
                    }
                    else
                    {
                        this.SetCustomErrorMessage(this.GetControl("txtPaySlipNo"), CXClientWrapper.Instance.ServiceResult.MessageCode, new object[] { this.View.Eno });
                    } 
                }
                catch (Exception ex)
                {
                    this.SetCustomErrorMessage(this.GetControl("txtPaySlipNo"), ex.Message);
                }
            }
        }

        public void mtxtPONo_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError == false)
            {
                try
                {
                    if (checkPONo())
                    {
                        bud = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode);
                        this.View.Budget = bud;
                        this.View.Amount = amt;
                    }
                }
                catch (Exception ex)
                {
                    this.SetCustomErrorMessage(this.GetControl("mtxtPONo"), ex.Message);
                }
            }
        }

        public void txtAmount_CustomValidation(object sender, ValidationEventArgs e)
        {
            try
            {
                checkAmount();
            }
            catch (Exception ex)
            {
                this.SetCustomErrorMessage(this.GetControl("txtAmount"), ex.Message);
            }
        }

        //public TLMDTO00016 GetPOInfoByPONO(string PoNo)
        //{
        //    PoNo = strPONO;
        //    return CXClientWrapper.Instance.Invoke<IMNMSVE00012, TLMDTO00016>(x => x.SelectPOInfoByPONO(PoNo));
        //}

        public void Save()
        {
            string budget; // Use for checking valid Budget

            PFMDTO00054 PORInfo = this.GetPORInfoEntity();
            PORInfo.DateTime = dateIntlf;
            if (isSaveValidate == false)
            {
                try
                {
                    #region validation

                    // Check all Validation for text box value is null
                    if (!this.ValidateForm())
                        return;

                    #endregion

                    #region check PONo

                    if (!checkPONo())
                        return;

                    #endregion

                    #region check Budget

                    budget = this.View.Budget; // Use for checking valid Budget
                    // Not same budget Year
                    if(budget != bud)
                    {
                        //Invalid budget Year for this PO
                        this.SetCustomErrorMessage(this.GetControl("mtxtPONo"), "MV00104");
                    }

                    #endregion

                    #region check Amount
                    
                    if(!checkAmount())
                        return;
                    
                    #endregion

                    if (CXUIMessageUtilities.ShowMessageByCode("MC00004") == DialogResult.Yes) // confirm to save
                    {
                        PORInfo.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                        string vouncherNo  =  CXClientWrapper.Instance.Invoke<IMNMSVE00012,string>(x => x.Save(PORInfo)); //save to server
                      
                        if (!CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                        {
                            string[] logItemForTlf = new string[35];
                            logItemForTlf[0] = string.Empty;//GroupNo
                            logItemForTlf[1] = this.view.Eno;//EntryNo
                            logItemForTlf[2] = this.AcType[0].AccountNo;//AcctNo
                            logItemForTlf[3] = string.Empty;
                            logItemForTlf[4] = this.view.Amount.ToString();//LocalAmount
                            logItemForTlf[5] = PORInfo.SourceCurrency;//SourceCur
                            logItemForTlf[6] = string.Empty;//Cheque
                            logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                            logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), PORInfo.SourceBranchCode).ToString();//SettlementDate
                            logItemForTlf[9] = string.Empty;//Status
                            logItemForTlf[10] = PORInfo.SourceBranchCode;//SourceBr
                            logItemForTlf[11] = vouncherNo;//Rno
                            logItemForTlf[12] = string.Empty;//Duration
                            logItemForTlf[13] = string.Empty;//LasintDate
                            logItemForTlf[14] = string.Empty;//intRate
                            logItemForTlf[15] = string.Empty;//Accured
                            logItemForTlf[16] = string.Empty;//BudenAcc
                            logItemForTlf[17] = string.Empty;//Draccured
                            logItemForTlf[18] = string.Empty;//AccuredStatus
                            logItemForTlf[19] = string.Empty;//ToAccountNo
                            logItemForTlf[20] = string.Empty;//FirstRno
                            logItemForTlf[21] = string.Empty;//PoNo
                            logItemForTlf[22] = string.Empty;//ADate
                            logItemForTlf[23] = string.Empty;//IDate
                            logItemForTlf[24] = string.Empty;//ToAcctNo
                            logItemForTlf[25] = string.Empty;//Income
                            logItemForTlf[26] = string.Empty;//Budget
                            logItemForTlf[27] = string.Empty;//FromBranch
                            logItemForTlf[28] = string.Empty;//ToBranch
                            logItemForTlf[29] = string.Empty;//Inout
                            logItemForTlf[30] = string.Empty;//Success
                            logItemForTlf[31] = string.Empty;//COMMUCHARGE
                            logItemForTlf[32] = string.Empty;//IncomeType
                            logItemForTlf[33] = string.Empty;//OtherBank
                            logItemForTlf[34] = string.Empty;//OtherBankChq
                            TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, " Payment Order Receipt Reversal Commit Transaction", CurrentUserEntity.BranchCode,
                            logItemForTlf);




                            CXUIMessageUtilities.ShowMessageByCode("MI30040");  //Successfully Reversal Transaction
                        }
                        else
                        {
                            string[] logItemForTlf = new string[35];
                            logItemForTlf[0] = string.Empty;//GroupNo
                            logItemForTlf[1] = this.view.Eno;//EntryNo
                            logItemForTlf[2] = this.AcType[0].AccountNo;//AcctNo
                            logItemForTlf[3] = string.Empty;
                            logItemForTlf[4] = this.view.Amount.ToString();//LocalAmount
                            logItemForTlf[5] = PORInfo.SourceCurrency;//SourceCur
                            logItemForTlf[6] = string.Empty;//Cheque
                            logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                            logItemForTlf[8] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), PORInfo.SourceBranchCode).ToString();//SettlementDate
                            logItemForTlf[9] = string.Empty;//Status
                            logItemForTlf[10] = PORInfo.SourceBranchCode;//SourceBr
                            logItemForTlf[11] = vouncherNo;//Rno
                            logItemForTlf[12] = string.Empty;//Duration
                            logItemForTlf[13] = string.Empty;//LasintDate
                            logItemForTlf[14] = string.Empty;//intRate
                            logItemForTlf[15] = string.Empty;//Accured
                            logItemForTlf[16] = string.Empty;//BudenAcc
                            logItemForTlf[17] = string.Empty;//Draccured
                            logItemForTlf[18] = string.Empty;//AccuredStatus
                            logItemForTlf[19] = string.Empty;//ToAccountNo
                            logItemForTlf[20] = string.Empty;//FirstRno
                            logItemForTlf[21] = string.Empty;//PoNo
                            logItemForTlf[22] = string.Empty;//ADate
                            logItemForTlf[23] = string.Empty;//IDate
                            logItemForTlf[24] = string.Empty;//ToAcctNo
                            logItemForTlf[25] = string.Empty;//Income
                            logItemForTlf[26] = string.Empty;//Budget
                            logItemForTlf[27] = string.Empty;//FromBranch
                            logItemForTlf[28] = string.Empty;//ToBranch
                            logItemForTlf[29] = string.Empty;//Inout
                            logItemForTlf[30] = string.Empty;//Success
                            logItemForTlf[31] = string.Empty;//COMMUCHARGE
                            logItemForTlf[32] = string.Empty;//IncomeType
                            logItemForTlf[33] = string.Empty;//OtherBank
                            logItemForTlf[34] = string.Empty;//OtherBankChq
                            TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, " Payment Order Receipt Reversal Fail Transaction", CurrentUserEntity.BranchCode,
                            logItemForTlf);


                            CXUIMessageUtilities.ShowMessageByCode("MI30041");  //Reversal Transaction Fail
                        }
                    }
                    else
                    {
                        this.SetCustomErrorMessage(this.GetControl("txtPaySlipNo"), CXClientWrapper.Instance.ServiceResult.MessageCode, new object[] { this.view.Eno });
                    }

                }
                catch (Exception ex)
                {
                    //this.SetCustomErrorMessage(this.GetControl("mtxtPONo"), ex.Message);
                }
            }
        }

        #endregion

        #region Helper Method           

        public void ClearCustomErrorMessage()
        {
            this.ClearAllCustomErrorMessage();
        }

        private PFMDTO00054 GetPORInfoEntity()
        {
            PFMDTO00054 tlfEntity = new PFMDTO00054();

            tlfEntity.Eno = this.View.Eno;
            tlfEntity.PaymentOrderNo = this.View.PaymentOrderNo;
            tlfEntity.Amount = this.View.Amount;
            tlfEntity.OtherBank = this.View.OtherBank;
            tlfEntity.CreatedUserId = CurrentUserEntity.CurrentUserID;
            tlfEntity.SourceBranchCode = CurrentUserEntity.BranchCode;
            return tlfEntity;
        }

        public IList<PFMDTO00054> GetPORInfoByEno()
        {
            IList<PFMDTO00054> POR = new List<PFMDTO00054>();
            POR = CXClientWrapper.Instance.Invoke<IMNMSVE00012, IList<PFMDTO00054>>(x => x.SelectTlfInfoByEntryNoandDateTime(this.view.Eno, "PORCL", "RPORCL", this.BranchCode));
            this.AcType = POR;
            return POR;
        }

        private bool checkPONo() 
        {
            pono = this.View.PaymentOrderNo;
            //POTextBoxFormat
            if (pono != null || pono.Length.Equals(Convert.ToInt32(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.POFromat))))
            { 
                if (pono != strPONO)
                {
                    //show this message 'PO No. must be equal to Register PO No.'
                    this.SetCustomErrorMessage(this.GetControl("mtxtPONo"), "ME30001");
                }
                else
                {
                    this.SetCustomErrorMessage(this.GetControl("mtxtPONo"), string.Empty);
                    return true;
                }

            }
            else
            {
                //this.SetCustomErrorMessage(this.GetControl("mtxtPONo"), CXClientWrapper.Instance.ServiceResult.MessageCode, new object[] { this.View.PaymentOrderNo });
                this.SetCustomErrorMessage(this.GetControl("mtxtPONo"), CXMessage.MV00219);
            }
            return false;
        }

        private bool checkAmount() 
        {
            amt2 = this.View.Amount;
            if (amt != amt2)
            {
                //show this err msg 'Amount must equal to registered Amount'.
                this.SetCustomErrorMessage(this.GetControl("txtAmount"), CXMessage.MV00037);
            }
            //else if (amt2 <= 0)
            //{
            //    //show this err msg 'Amount is not less than or equal to zero'      --- need to add this msg
            //    this.SetCustomErrorMessage(this.GetControl("txtAmount"), CXMessage.MV00037);
            //}
            else
            {
                this.SetCustomErrorMessage(this.GetControl("txtAmount"), string.Empty);
                return true;
            }

            return false;
        }

        //Added by YMP at 30-07-2019 : [Seperating EOD Process] To show system date (not PC date) at report
        public DateTime GetSystemDate(string sourceBr)
        {
            TCMDTO00001 systemStartInfo = CXClientWrapper.Instance.Invoke<ICXSVE00006, TCMDTO00001>(x => x.SelectStartBySourceBr(sourceBr));
            DateTime systemDate = systemStartInfo.Date;
            return systemDate;
        }

        //Added by HMW at 26-08-2019 : [Seperating EOD Process] Check Settlement Date to show form
        public DateTime GetLastSettlementDate(string sourceBr)
        {
            DateTime lastSettlementDate = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.LastSettlementDate), sourceBr);
            return lastSettlementDate;
        }

        #endregion
    }
}
