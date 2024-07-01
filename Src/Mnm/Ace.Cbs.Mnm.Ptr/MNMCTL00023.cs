using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Com.Dmd;
using System.Windows.Forms;
using Ace.Cbs.Tel.Ctr.Sve;

namespace Ace.Cbs.Mnm.Ptr
{
    class MNMCTL00023 : AbstractPresenter, IMNMCTL00023
    {
        CXDTO00001 denoInfo;
        bool voucher = false;
        bool denoStatus = false;
        string type = string.Empty;
        #region View
        private IMNMVEW00023 view;
        public IMNMVEW00023 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        private void WireTo(IMNMVEW00023 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetEntity());
            }
        }
        #endregion

        #region Validation Methods
        public void mtxtRegisterNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError)
            {
                return;
            }
            else
            {
                TLMDTO00017 RDInfo = CXClientWrapper.Instance.Invoke<IMNMSVE00023, TLMDTO00017>(x => x.GetRDInfo(View.RegisterNo, CurrentUserEntity.BranchCode));
                if (RDInfo != null)
                {
                    view.OCheque = RDInfo.CheckNo;
                }
                if (RDInfo == null)
                {
                    this.SetCustomErrorMessage(this.GetControl("mtxtRegisterNo"), "MV00168");    //Invalid Register No.
                    return;
                }
                else
                {
                    if (RDInfo.ReceiptDate == null && RDInfo.IncomeDate == null)
                    {
                        voucher = false;
                    }
                    else if (RDInfo.ReceiptDate == null && RDInfo.IncomeDate.Value.ToShortDateString() == DateTime.Now.ToShortDateString() && RDInfo.IncomeType == null)
                    {
                        voucher = false;
                    }
                    else
                    {
                        voucher = true;
                    }

                    //if (voucher)
                    //{
                    //    //requested by Ma AMMK , comment by ASDA  (to allow already voucher RdNo)
                    //    //this.SetCustomErrorMessage(this.GetControl("mtxtRegisterNo"), "MV30011");    //Does not allow to Edit Amount! Already Vouchered.

                    //}
                    //else
                    //{
                    if (RDInfo.IsCloseAC || RDInfo.DateTime.Value.ToShortDateString() != DateTime.Now.ToShortDateString())
                    {
                        this.View.SetEnableToEdit(false);
                    }
                    else
                    {
                        this.View.SetEnableToEdit(true);
                    }
                    this.SetCustomErrorMessage(this.GetControl("mtxtRegisterNo"), string.Empty);
                    if (!this.View.SaveStatus)
                        this.ShowData(RDInfo);
                    this.View.DisableControl();
                    //}
                }
            }
        }

        public void txtAmount_CustomValidating(object sender, ValidationEventArgs e)
        {
            #region Coding No Need
            //if (!string.IsNullOrEmpty(View.PayerAccountNo) && View.PayerAccountNo.Length > 6)
            //{
            //    PFMDTO00028 account = CXClientWrapper.Instance.Invoke<IMNMSVE00023, PFMDTO00028>(x => x.GetAccount(View.PayerAccountNo));
            //    if (account == null)
            //    {
            //        this.SetCustomErrorMessage(this.GetControl("txtAmount"), "MV00046");    //Invalid AccountNo
            //        return;
            //    }
            //    else if (account.SourceBranchCode != CurrentUserEntity.BranchCode)
            //    {
            //        CXUIMessageUtilities.ShowMessageByCode("MV00091", new object[] { "Invalid", CurrentUserEntity.BranchCode });
            //        return;
            //    }
            //    else if (account.CloseDate != null && account.CloseDate != default(DateTime))
            //    {
            //        CXUIMessageUtilities.ShowMessageByCode("MV00044");  //Account has been closed.
            //        return;
            //    }
            //    else if (View.Amount > account.CurrentBal + account.OverdraftLimit)
            //    {
            //        this.SetCustomErrorMessage(this.GetControl("txtAmount"), "MV00109");    //Insufficient Balance
            //        return;
            //    }
            //    else
            //    {
            //        this.SetCustomErrorMessage(this.GetControl("txtAmount"), string.Empty);
            //    }

            //}
            #endregion

            if (this.view.Amount.ToString().Equals(decimal.Zero.ToString()) || this.view.Amount == decimal.Zero)
            {
                this.SetCustomErrorMessage(this.GetControl("txtAmount"), "MV00037");    //Invalid Register No.
                return;
            }
            else
            {
                decimal commission = 0;
                decimal minCommission = 0;
                PFMDTO00057 newSetupDTO = CXCLE00002.Instance.GetClientData<PFMDTO00057>("NewSetup.Client.SelectValueByVariable", new object[] { "MI_RMITCOM" });
                if (newSetupDTO != null)
                {
                    minCommission = string.IsNullOrEmpty(newSetupDTO.Value) ? 0 : Convert.ToDecimal(newSetupDTO.Value);
                }
                IList<TLMDTO00032> RmitRate = CXCLE00015.Instance.GetAllRateByBranchCodeAndCur(View.DBank, View.Currency, CurrentUserEntity.BranchCode);
                if (RmitRate.Count <= 0)
                {
                    CXUIMessageUtilities.ShowMessageByCode("MV00195", new object[] { View.DBank }); //Branch Info is missing
                    return;
                }
                else
                {
                    foreach (TLMDTO00032 rate in RmitRate)
                    {
                        if (rate.StartNo == 0 && rate.EndNo == 0)
                            commission = this.Computing(View.Amount, rate.FixAmount, rate.Rate);
                        else if (rate.EndNo == 0 && View.Amount >= rate.StartNo)
                            commission = this.Computing(View.Amount, rate.FixAmount, rate.Rate);
                        else if (View.Amount >= rate.StartNo && View.Amount <= rate.EndNo)
                            commission = this.Computing(View.Amount, rate.FixAmount, rate.Rate);
                    }
                    if (commission != 0)
                    {
                        commission = commission < minCommission ? minCommission : commission;
                    }
                    View.CalculateCommission = commission;
                    View.BindCommession();
                }
            }
        }

        public void txtPayerAccountNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (!string.IsNullOrEmpty(View.PayerAccountNo))
            {
                PFMDTO00001 accountInfo = CXClientWrapper.Instance.Invoke<IMNMSVE00023, PFMDTO00001>(x => x.CheckAccount(View.PayerAccountNo, CurrentUserEntity.BranchCode, View.OldAccountNo));
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {
                    string[] msgArr = CXClientWrapper.Instance.ServiceResult.MessageCode.Split("\n".ToCharArray());
                    if (msgArr.Length == 2)
                    {
                        this.SetCustomErrorMessage(this.GetControl("txtPayerAccountNo"), msgArr[0], new object[] { msgArr[1] });
                    }
                    else if (msgArr.Length == 3)
                    {
                        this.SetCustomErrorMessage(this.GetControl("txtPayerAccountNo"), msgArr[0], new object[] { msgArr[1], msgArr[2] });
                    }
                    else
                    {
                        this.SetCustomErrorMessage(this.GetControl("txtPayerAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                }
                else
                {
                    this.SetCustomErrorMessage(this.GetControl("txtPayerAccountNo"), string.Empty);
                    if (View.PayerAccountNo.Length == 6)
                    {
                        View.PayerName = accountInfo.Name;
                        View.ChequeDisable();
                    }
                    else
                    {
                        if (View.OldAccountNo != View.PayerAccountNo)
                        {
                            View.PayerName = accountInfo.Name;
                            View.PayerNRC = accountInfo.NRC;
                            View.PayerAddress = accountInfo.Address;
                        }
                        View.AcSign = accountInfo.AccountSign;
                        if (accountInfo.AccountSign[0] == 'C')
                            View.ChequeEnable();
                        else
                            View.ChequeDisable();

                    }
                }
            }
            else
            {
                this.SetCustomErrorMessage(this.GetControl("txtPayerAccountNo"), string.Empty);
                if (View.OldDrawingType == "Account")
                {
                    View.PayerName = string.Empty;
                    View.PayerNRC = string.Empty;
                    View.PayerAddress = string.Empty;
                    View.ChequeNo = string.Empty;
                    View.ChequeDisable();
                }
            }
        }

        //public void txtChequeNo_CustomValidating(object sender, ValidationEventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(View.PayerAccountNo) && View.PayerAccountNo.Length > 6)
        //    {
        //        try
        //        {
        //            this.view.ChequeNo = CXCLE00007.GetFormatString(Convert.ToInt32(this.view.ChequeNo), CXCOM00009.ChequeNoDisplayFormat);
        //        }
        //        catch (Exception ex)
        //        {
        //            this.SetCustomErrorMessage(this.GetControl("txtChequeNo"), ex.Message);
        //        }
        //        if (!string.IsNullOrEmpty(this.view.ChequeNo))
        //        {
        //            if (!CXClientWrapper.Instance.Invoke<ITLMSVE00018, bool>(x => x.IsValidChequeNo(View.PayerAccountNo, View.ChequeNo, CurrentUserEntity.BranchCode)))
        //            {
        //                this.SetCustomErrorMessage(this.GetControl("txtChequeNo"), CXClientWrapper.Instance.ServiceResult.MessageCode, new object[] { View.ChequeNo });
        //            }
        //            else
        //            {
        //                this.SetCustomErrorMessage(this.GetControl("txtChequeNo"), string.Empty);
        //            }
        //        }
        //    }

        //}
        #endregion

        #region Main Method
        public void Save()
        {
            TLMDTO00017 Entity = this.GetEntity();
            if (this.ValidateForm(Entity))
            {
                string oldDrawingType = View.OldDrawingType;
                string newDrawingType = View.DrawingType;
                string oldIncomeType = View.OldIncomeType;
                string newIncomeType = View.IncomeType;
                decimal denoAmount = 0;



                if (view.OCheque != View.ChequeNo)
                {
                    try
                    {
                        this.view.ChequeNo = CXCLE00007.GetFormatString(Convert.ToInt32(this.view.ChequeNo), CXCOM00009.ChequeNoDisplayFormat);
                        string branch = this.view.PayerAccountNo.Substring(0, 3).Trim();
                        bool result = CXClientWrapper.Instance.Invoke<ITLMSVE00014, bool>(x => x.CheckingChequeNo(this.view.PayerAccountNo, this.view.ChequeNo, branch));
                        {
                            if (result == false)
                            {
                                //this.SetCustomErrorMessage(this.GetControl("txtChequeNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00059);
                                this.view.SetFocus();
                                return;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        this.SetCustomErrorMessage(this.GetControl("txtChequeNo"), ex.Message);
                    }
                }
                #region Account to Account
                if (oldDrawingType == "Account" && newDrawingType == "Account")
                {
                    if ((oldIncomeType == "CS" && newIncomeType == "TR") || (oldIncomeType == "CS" && string.IsNullOrEmpty(newIncomeType)))
                    {
                        //group
                        if (!string.IsNullOrEmpty(View.GroupNo))
                        {
                            decimal otherGroupAmount = CXClientWrapper.Instance.Invoke<IMNMSVE00023, TLMDTO00017>(x => x.GetOtherGroupAmount(View.GroupNo, View.RegisterNo, CurrentUserEntity.BranchCode)).Amount.Value;
                            //not last group
                            if (otherGroupAmount > 0)
                            {
                                denoAmount = otherGroupAmount;
                                if (denoAmount > 0 && denoAmount != View.OldCashAmount)
                                    denoInfo = this.GetDenoList(denoAmount, CXDMD00008.Received);
                            }
                        }
                        //single
                        else
                        {
                            //nothing
                        }
                    }
                    else if ((oldIncomeType == "TR" && newIncomeType == "CS") || (string.IsNullOrEmpty(oldIncomeType) && newIncomeType == "CS"))
                    {
                        denoAmount = View.Commission + View.TlxCharges;
                        if (denoAmount > 0 && denoAmount != View.OldCashAmount)
                            denoInfo = this.GetDenoList(denoAmount, CXDMD00008.Received);
                    }
                    else if (oldIncomeType == "TR" && string.IsNullOrEmpty(newIncomeType))
                    {
                        //nothing
                    }
                    else if (string.IsNullOrEmpty(oldIncomeType) && newIncomeType == "TR")
                    {
                        //nothing
                    }
                    else if (oldIncomeType == "CS" && newIncomeType == "CS")
                    {
                        //group
                        if (!string.IsNullOrEmpty(View.GroupNo))
                        {
                            decimal otherGroupAmount = CXClientWrapper.Instance.Invoke<IMNMSVE00023, TLMDTO00017>(x => x.GetOtherGroupAmount(View.GroupNo, View.RegisterNo, CurrentUserEntity.BranchCode)).Amount.Value;

                            denoAmount = otherGroupAmount + View.Commission + View.TlxCharges;
                            if (denoAmount > 0 && denoAmount != View.OldCashAmount)
                                denoInfo = this.GetDenoList(denoAmount, CXDMD00008.Received);
                        }
                        //single
                        else
                        {
                            denoAmount = View.Commission + View.TlxCharges;
                            if (denoAmount > 0 && denoAmount != View.OldCashAmount)
                                denoInfo = this.GetDenoList(denoAmount, CXDMD00008.Received);
                        }
                    }
                    else if (oldIncomeType == "TR" && newIncomeType == "TR")
                    {
                        //nothing
                    }
                    else if (string.IsNullOrEmpty(oldIncomeType) && string.IsNullOrEmpty(newIncomeType))
                    {
                        //nothing
                    }
                }
                #endregion

                #region Cash To Cash
                else if (oldDrawingType == "Cash" && newDrawingType == "Cash")
                {
                    if ((oldIncomeType == "CS" && string.IsNullOrEmpty(newIncomeType)) || (string.IsNullOrEmpty(oldIncomeType) && string.IsNullOrEmpty(newIncomeType)))
                    {
                        //group
                        if (!string.IsNullOrEmpty(View.GroupNo))
                        {
                            decimal otherGroupAmount = CXClientWrapper.Instance.Invoke<IMNMSVE00023, TLMDTO00017>(x => x.GetOtherGroupAmount(View.GroupNo, View.RegisterNo, CurrentUserEntity.BranchCode)).Amount.Value;
                            denoAmount = otherGroupAmount + View.Amount;
                            denoInfo = this.GetDenoList(denoAmount, CXDMD00008.Received);
                        }
                        //single
                        else
                        {
                            denoAmount = View.Amount;
                            if (denoAmount != View.OldCashAmount)
                            {
                                if (denoAmount == 0)
                                    denoInfo = new CXDTO00001();
                                else
                                    denoInfo = this.GetDenoList(denoAmount, CXDMD00008.Received);
                            }
                        }
                    }
                    else if ((oldIncomeType == "CS" && newIncomeType == "CS") || (string.IsNullOrEmpty(oldIncomeType) && newIncomeType == "CS"))
                    {
                        //group
                        if (!string.IsNullOrEmpty(View.GroupNo))
                        {
                            decimal otherGroupAmount = CXClientWrapper.Instance.Invoke<IMNMSVE00023, TLMDTO00017>(x => x.GetOtherGroupAmount(View.GroupNo, View.RegisterNo, CurrentUserEntity.BranchCode)).Amount.Value;
                            denoAmount = otherGroupAmount + View.Amount + View.Commission + View.TlxCharges;
                            denoInfo = this.GetDenoList(denoAmount, CXDMD00008.Received);
                        }
                        //single
                        else
                        {
                            denoAmount = View.Amount + View.Commission + View.TlxCharges;
                            if (denoAmount > 0 && denoAmount != View.OldCashAmount)
                                denoInfo = this.GetDenoList(denoAmount, CXDMD00008.Received);
                        }
                    }
                }
                #endregion

                #region Cash To Account
                else if (oldDrawingType == "Cash" && newDrawingType == "Account")
                {
                    if ((oldIncomeType == "CS" && newIncomeType == "TR") || (oldIncomeType == "CS" && string.IsNullOrEmpty(newIncomeType)))
                    {
                        //group
                        if (!string.IsNullOrEmpty(View.GroupNo))
                        {
                            decimal otherGroupAmount = CXClientWrapper.Instance.Invoke<IMNMSVE00023, TLMDTO00017>(x => x.GetOtherGroupAmount(View.GroupNo, View.RegisterNo, CurrentUserEntity.BranchCode)).Amount.Value;
                            //not last group
                            if (otherGroupAmount > 0)
                            {
                                denoAmount = otherGroupAmount;
                                denoInfo = this.GetDenoList(denoAmount, CXDMD00008.Received);
                            }
                        }
                        //single
                        else
                        {
                            //nothing
                        }
                    }
                    if (string.IsNullOrEmpty(oldIncomeType) && newIncomeType == "CS")
                    {
                        //group
                        if (!string.IsNullOrEmpty(View.GroupNo))
                        {
                            decimal otherGroupAmount = CXClientWrapper.Instance.Invoke<IMNMSVE00023, TLMDTO00017>(x => x.GetOtherGroupAmount(View.GroupNo, View.RegisterNo, CurrentUserEntity.BranchCode)).Amount.Value;
                            denoAmount = otherGroupAmount + View.Commission + View.TlxCharges;
                            denoInfo = this.GetDenoList(denoAmount, CXDMD00008.Received);
                        }
                        //single
                        else
                        {
                            denoAmount = View.Commission + View.TlxCharges;
                            if (denoAmount > 0 && denoAmount != View.OldCashAmount)
                                denoInfo = this.GetDenoList(denoAmount, CXDMD00008.Received);
                        }
                    }
                    if (string.IsNullOrEmpty(oldIncomeType) && newIncomeType == "TR")
                    {
                        //group
                        if (!string.IsNullOrEmpty(View.GroupNo))
                        {
                            decimal otherGroupAmount = CXClientWrapper.Instance.Invoke<IMNMSVE00023, TLMDTO00017>(x => x.GetOtherGroupAmount(View.GroupNo, View.RegisterNo, CurrentUserEntity.BranchCode)).Amount.Value;
                            //not last group
                            if (otherGroupAmount > 0)
                            {
                                denoAmount = otherGroupAmount;
                                denoInfo = this.GetDenoList(denoAmount, CXDMD00008.Received);
                            }
                        }
                        //single
                        else
                        {
                            //nothing
                        }
                    }
                    if (oldIncomeType == "CS" && newIncomeType == "CS")
                    {
                        //group
                        if (!string.IsNullOrEmpty(View.GroupNo))
                        {
                            decimal otherGroupAmount = CXClientWrapper.Instance.Invoke<IMNMSVE00023, TLMDTO00017>(x => x.GetOtherGroupAmount(View.GroupNo, View.RegisterNo, CurrentUserEntity.BranchCode)).Amount.Value;
                            denoAmount = otherGroupAmount + View.Commission + View.TlxCharges;
                            denoInfo = this.GetDenoList(denoAmount, CXDMD00008.Received);
                        }
                        //single
                        else
                        {
                            denoAmount = View.Commission + View.TlxCharges;
                            if (denoAmount > 0 && denoAmount != View.OldCashAmount)
                                denoInfo = this.GetDenoList(denoAmount, CXDMD00008.Received);
                        }
                    }
                    if (string.IsNullOrEmpty(oldIncomeType) && string.IsNullOrEmpty(newIncomeType))
                    {
                        //group
                        if (!string.IsNullOrEmpty(View.GroupNo))
                        {
                            decimal otherGroupAmount = CXClientWrapper.Instance.Invoke<IMNMSVE00023, TLMDTO00017>(x => x.GetOtherGroupAmount(View.GroupNo, View.RegisterNo, CurrentUserEntity.BranchCode)).Amount.Value;
                            //not last group
                            if (otherGroupAmount > 0)
                            {
                                denoAmount = otherGroupAmount;
                                denoInfo = this.GetDenoList(denoAmount, CXDMD00008.Received);
                            }
                        }
                        //single
                        else
                        {
                            //nothing
                        }
                    }
                }
                #endregion

                #region Account to Cash
                else if (oldDrawingType == "Account" && newDrawingType == "Cash")
                {
                    if (oldIncomeType == "CS" && newIncomeType == "CS")
                    {
                        //group
                        if (!string.IsNullOrEmpty(View.GroupNo))
                        {
                            decimal otherGroupAmount = CXClientWrapper.Instance.Invoke<IMNMSVE00023, TLMDTO00017>(x => x.GetOtherGroupAmount(View.GroupNo, View.RegisterNo, CurrentUserEntity.BranchCode)).Amount.Value;
                            denoAmount = otherGroupAmount + View.Amount + View.Commission + View.TlxCharges;
                            denoInfo = this.GetDenoList(denoAmount, CXDMD00008.Received);
                        }
                        //single
                        else
                        {
                            denoAmount = View.Amount + View.Commission + View.TlxCharges;
                            if (denoAmount > 0 && denoAmount != View.OldCashAmount)
                                denoInfo = this.GetDenoList(denoAmount, CXDMD00008.Received);
                        }
                    }
                    else if (oldIncomeType == "CS" && string.IsNullOrEmpty(newIncomeType))
                    {
                        //group
                        if (!string.IsNullOrEmpty(View.GroupNo))
                        {
                            decimal otherGroupAmount = CXClientWrapper.Instance.Invoke<IMNMSVE00023, TLMDTO00017>(x => x.GetOtherGroupAmount(View.GroupNo, View.RegisterNo, CurrentUserEntity.BranchCode)).Amount.Value;
                            denoAmount = otherGroupAmount + View.Amount;
                            denoInfo = this.GetDenoList(denoAmount, CXDMD00008.Received);
                        }
                        //single
                        else
                        {
                            denoAmount = View.Amount;
                            if (denoAmount != View.OldCashAmount)
                            {
                                if (denoAmount == 0)
                                    denoInfo = new CXDTO00001();
                                else
                                    denoInfo = this.GetDenoList(denoAmount, CXDMD00008.Received);
                            }
                        }
                    }
                    else if (string.IsNullOrEmpty(oldIncomeType) && string.IsNullOrEmpty(newIncomeType))
                    {
                        denoAmount = View.Amount;
                        if (denoAmount > 0)
                            denoInfo = this.GetDenoList(denoAmount, CXDMD00008.Received);
                    }
                    else if (string.IsNullOrEmpty(oldIncomeType) && newIncomeType == "CS")
                    {
                        denoAmount = View.Amount + View.Commission + View.TlxCharges;
                        denoInfo = this.GetDenoList(denoAmount, CXDMD00008.Received);
                    }
                    else if (oldIncomeType == "TR" && newIncomeType == "CS")
                    {
                        denoAmount = View.Amount + View.Commission + View.TlxCharges;
                        denoInfo = this.GetDenoList(denoAmount, CXDMD00008.Received);
                    }
                    else if (oldIncomeType == "TR" && string.IsNullOrEmpty(newIncomeType))
                    {
                        denoAmount = View.Amount;
                        if (denoAmount > 0)
                            denoInfo = this.GetDenoList(denoAmount, CXDMD00008.Received);
                    }
                }
                #endregion

                if (this.denoStatus)
                {
                    if (denoInfo == null)
                        return;
                }

                //Amount Checking
                if (!string.IsNullOrEmpty(View.PayerAccountNo) && View.PayerAccountNo.Length > 6)
                {
                    string messageCode;
                    if (denoAmount == 0)
                    {
                        denoAmount = View.Amount + View.Commission + View.TlxCharges;
                    }
                    if (!this.CheckAmount(denoAmount, out messageCode))
                    {
                        CXUIMessageUtilities.ShowMessageByCode(messageCode);
                        return;
                    }
                }

                TLMDTO00017 entity = this.GetEntity();
                if (denoInfo != null)
                {
                    entity.Deno_Status = "Y";
                }
                entity.CashAmount = denoAmount;
                entity.TestKey = CXCLE00017.Instance.GetTestKey(entity.Dbank, DateTime.Now.Day.ToString().PadLeft(2, '0'), DateTime.Now.Month.ToString().PadLeft(2, '0'), Convert.ToDecimal(entity.Amount), CXCOM00007.Instance.BranchCode);   //Added by ASDA
                IList<PFMDTO00054> Tlf_List = CXClientWrapper.Instance.Invoke<IMNMSVE00023, IList<PFMDTO00054>>(x => x.Save(entity, denoInfo, CurrentUserEntity.WorkStationId, voucher));   //edited by ASDA
                #region ErrorOccurred
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {
                    if (Tlf_List.Count > 0)
                    {
                        if (denoInfo != null)
                        {
                            string[] logItemForDeno = new string[14];
                            if (!string.IsNullOrEmpty(entity.GroupNo))
                                logItemForDeno[0] = entity.GroupNo.ToString();//Tlf_Eno
                            else
                                logItemForDeno[0] = string.Empty;
                            logItemForDeno[1] = string.IsNullOrEmpty(entity.GroupNo) ? entity.RegisterNo : entity.GroupNo.StartsWith("R") ? entity.RegisterNo : string.Empty ;//AcType
                            logItemForDeno[2] = string.Empty;//FromType
                            logItemForDeno[3] = entity.CashAmount.ToString();//Amount
                            logItemForDeno[4] = System.DateTime.Now.ToString();//Cash_Date
                            logItemForDeno[5] = denoInfo.DenoString;//Deno_Detail
                            logItemForDeno[6] = denoInfo.RefundString;//DenoRefund_Detail
                            logItemForDeno[7] = "R";//Status
                            logItemForDeno[8] = "0";//REVERSE
                            logItemForDeno[9] = entity.SourceBranchCode;//sourcebr
                            logItemForDeno[10] = entity.Currency;//cur
                            logItemForDeno[11] = denoInfo.DenoRateString;//DenoRate
                            logItemForDeno[12] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), entity.SourceBranchCode).ToString();//SettlementDate
                            logItemForDeno[13] = CXCOM00010.Instance.GetExchangeRate(entity.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType)).ToString();//Rate
                            TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Deno, "RD Important Data Fail Deno", CurrentUserEntity.BranchCode,
                            logItemForDeno);
                        }
                        
                        //ClientLog For Tlf
                        for (int i = 0; i < Tlf_List.Count; i++)
                        {
                            string[] logItemForTlf = new string[35];
                            logItemForTlf[0] = string.Empty;//GroupNo
                            logItemForTlf[1] = Tlf_List[i].ReferenceVoucherNo;//EntryNo
                            logItemForTlf[2] = Tlf_List[i].AccountNo;//AcctNo
                            logItemForTlf[3] = Tlf_List[i].Acode;//ACode(from COASetUp)
                            logItemForTlf[4] = Tlf_List[i].LocalAmount.ToString();//LocalAmount
                            logItemForTlf[5] = Tlf_List[i].SourceCurrency;//SourceCur
                            logItemForTlf[6] = string.Empty;//Cheque
                            logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                            logItemForTlf[8] = Tlf_List[i].SettlementDate.ToString();//SettlementDate
                            logItemForTlf[9] = Tlf_List[i].Status;//Status
                            logItemForTlf[10] = Tlf_List[i].SourceBranchCode;//SourceBr
                            logItemForTlf[11] = Tlf_List[i].Eno;//Rno
                            logItemForTlf[12] = string.Empty;//Duration
                            logItemForTlf[13] = string.Empty;//LasintDate
                            logItemForTlf[14] = Tlf_List[i].Rate.ToString();//intRate
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
                            TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "RD Important Data Fail Transaction", CurrentUserEntity.BranchCode,
                            logItemForTlf);
                        }
                    }
                    CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
                #endregion

                #region Successful
                else
                {
                    if (Tlf_List.Count > 0)
                    {
                        if (denoInfo != null)
                        {
                            string[] logItemForDeno = new string[14];
                            if (!string.IsNullOrEmpty(entity.GroupNo))
                                logItemForDeno[0] = entity.GroupNo.ToString();//Tlf_Eno
                            else
                                logItemForDeno[0] = string.Empty;
                            logItemForDeno[1] = string.IsNullOrEmpty(entity.GroupNo) ? entity.RegisterNo : entity.GroupNo.StartsWith("R") ? entity.RegisterNo : string.Empty;//AcType
                            logItemForDeno[2] = string.Empty;//FromType
                            logItemForDeno[3] = entity.CashAmount.ToString();//Amount
                            logItemForDeno[4] = System.DateTime.Now.ToString();//Cash_Date
                            logItemForDeno[5] = denoInfo.DenoString;//Deno_Detail
                            logItemForDeno[6] = denoInfo.RefundString;//DenoRefund_Detail
                            logItemForDeno[7] = "R";//Status
                            logItemForDeno[8] = "0";//REVERSE
                            logItemForDeno[9] = entity.SourceBranchCode;//sourcebr
                            logItemForDeno[10] = entity.Currency;//cur
                            logItemForDeno[11] = denoInfo.DenoRateString;//DenoRate
                            logItemForDeno[12] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), entity.SourceBranchCode).ToString();//SettlementDate
                            logItemForDeno[13] = CXCOM00010.Instance.GetExchangeRate(entity.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType)).ToString();//Rate
                            TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Deno, "RD Important Data Commit Deno", CurrentUserEntity.BranchCode,
                            logItemForDeno);
                        }

                        //ClientLog For Tlf
                        for (int i = 0; i < Tlf_List.Count; i++)
                        {
                            string[] logItemForTlf = new string[35];
                            logItemForTlf[0] = string.Empty;//GroupNo
                            logItemForTlf[1] = Tlf_List[i].ReferenceVoucherNo;//EntryNo
                            logItemForTlf[2] = Tlf_List[i].AccountNo;//AcctNo
                            logItemForTlf[3] = Tlf_List[i].Acode;//ACode(from COASetUp)
                            logItemForTlf[4] = Tlf_List[i].LocalAmount.ToString();//LocalAmount
                            logItemForTlf[5] = Tlf_List[i].SourceCurrency;//SourceCur
                            logItemForTlf[6] = string.Empty;//Cheque
                            logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                            logItemForTlf[8] = Tlf_List[i].SettlementDate.ToString();//SettlementDate
                            logItemForTlf[9] = Tlf_List[i].Status;//Status
                            logItemForTlf[10] = Tlf_List[i].SourceBranchCode;//SourceBr
                            logItemForTlf[11] = Tlf_List[i].Eno;//Rno
                            logItemForTlf[12] = string.Empty;//Duration
                            logItemForTlf[13] = string.Empty;//LasintDate
                            logItemForTlf[14] = Tlf_List[i].Rate.ToString();//intRate
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
                            TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "RD Important Data Commit Transaction", CurrentUserEntity.BranchCode,
                            logItemForTlf);
                        }
                    }
                    CXUIMessageUtilities.ShowMessageByCode("MI90001"); //Saving Successful
                    if (CXUIMessageUtilities.ShowMessageByCode("MC00002") == DialogResult.Yes)
                    {
                        entity.AmountByLetter = Tlf_List[0].ReferenceType;
                        entity.DateTime = DateTime.Now;
                        entity.status = "RDImportantData";
                        CXUIScreenTransit.Transit("frmMNMVEW00130DrawintPrintingReport", true, new object[] { entity });
                    }
                    if (voucher)
                    {
                        CXUIMessageUtilities.ShowMessageByCode("MI50009");  //  Adjustment Vouchers are already prepared.  You must re-enter the voucher entry for this Register No.
                    }
                    
                    View.SaveStatus = false;
                    View.ClearControl();
                    View.SetFocusToRegisterNo();

                }
                #endregion
            }
            else
            {
                if (string.IsNullOrEmpty(this.view.RegisterNo.ToString()))
                {
                    this.SetFocus("mtxtRegisterNo");
                }
                else if(this.view.Amount.ToString().Equals(decimal.Zero.ToString()))
                {
                    this.SetFocus("txtAmount");
                }
            }
        }

        public void Delete()
        {
            TLMDTO00017 entity = this.GetEntity();
            if (this.ValidateForm(entity))
            {
                //Group
                if (!string.IsNullOrEmpty(entity.GroupNo))
                {
                    decimal otherAmount = 0;
                    otherAmount = CXClientWrapper.Instance.Invoke<IMNMSVE00023, TLMDTO00017>(x => x.GetOtherGroupAmount(entity.GroupNo, entity.RegisterNo, entity.SourceBranchCode)).Amount.Value;
                    if (otherAmount > 0)
                    {
                        denoInfo = this.GetDenoList(otherAmount, CXDMD00008.Received);
                        entity.CashAmount = otherAmount;
                    }
                }

                //Delete
                IList<PFMDTO00054> Tlf_List = CXClientWrapper.Instance.Invoke<IMNMSVE00023,IList<PFMDTO00054>>(x => x.Delete(entity, denoInfo));
                #region ErrorOccurred
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {
                    if (Tlf_List.Count > 0)
                    {
                        if (denoInfo != null)
                        {
                            string[] logItemForDeno = new string[14];
                            if (!string.IsNullOrEmpty(entity.GroupNo))
                                logItemForDeno[0] = entity.GroupNo.ToString();//Tlf_Eno
                            else
                                logItemForDeno[0] = string.Empty;
                            logItemForDeno[1] = string.IsNullOrEmpty(entity.GroupNo) ? entity.RegisterNo : entity.GroupNo.StartsWith("R") ? entity.RegisterNo : string.Empty;//AcType
                            logItemForDeno[2] = string.Empty;//FromType
                            logItemForDeno[3] = entity.CashAmount.ToString();//Amount
                            logItemForDeno[4] = System.DateTime.Now.ToString();//Cash_Date
                            logItemForDeno[5] = denoInfo.DenoString;//Deno_Detail
                            logItemForDeno[6] = denoInfo.RefundString;//DenoRefund_Detail
                            logItemForDeno[7] = "R";//Status
                            logItemForDeno[8] = "0";//REVERSE
                            logItemForDeno[9] = entity.SourceBranchCode;//sourcebr
                            logItemForDeno[10] = entity.Currency;//cur
                            logItemForDeno[11] = denoInfo.DenoRateString;//DenoRate
                            logItemForDeno[12] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), entity.SourceBranchCode).ToString();//SettlementDate
                            logItemForDeno[13] = CXCOM00010.Instance.GetExchangeRate(entity.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType)).ToString();//Rate
                            TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Deno, "RD Important Data Fail Deno", CurrentUserEntity.BranchCode,
                            logItemForDeno);
                        }

                        //ClientLog For Tlf
                        for (int i = 0; i < Tlf_List.Count; i++)
                        {
                            string[] logItemForTlf = new string[35];
                            logItemForTlf[0] = string.Empty;//GroupNo
                            logItemForTlf[1] = Tlf_List[i].ReferenceVoucherNo;//EntryNo
                            logItemForTlf[2] = Tlf_List[i].AccountNo;//AcctNo
                            logItemForTlf[3] = Tlf_List[i].Acode;//ACode(from COASetUp)
                            logItemForTlf[4] = Tlf_List[i].LocalAmount.ToString();//LocalAmount
                            logItemForTlf[5] = Tlf_List[i].SourceCurrency;//SourceCur
                            logItemForTlf[6] = string.Empty;//Cheque
                            logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                            logItemForTlf[8] = Tlf_List[i].SettlementDate.ToString();//SettlementDate
                            logItemForTlf[9] = Tlf_List[i].Status;//Status
                            logItemForTlf[10] = Tlf_List[i].SourceBranchCode;//SourceBr
                            logItemForTlf[11] = Tlf_List[i].Eno;//Rno
                            logItemForTlf[12] = string.Empty;//Duration
                            logItemForTlf[13] = string.Empty;//LasintDate
                            logItemForTlf[14] = Tlf_List[i].Rate.ToString();//intRate
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
                            TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "RD Important Data Fail Transaction", CurrentUserEntity.BranchCode,
                            logItemForTlf);
                        }
                    }
                    CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
                #endregion

                #region Successful
                else
                {
                    if (Tlf_List.Count > 0)
                    {
                        if (denoInfo != null)
                        {
                            string[] logItemForDeno = new string[14];
                            if (!string.IsNullOrEmpty(entity.GroupNo))
                                logItemForDeno[0] = entity.GroupNo.ToString();//Tlf_Eno
                            else
                                logItemForDeno[0] = string.Empty;
                            logItemForDeno[1] = string.IsNullOrEmpty(entity.GroupNo) ? entity.RegisterNo : entity.GroupNo.StartsWith("R") ? entity.RegisterNo : string.Empty;//AcType
                            logItemForDeno[2] = string.Empty;//FromType
                            logItemForDeno[3] = entity.CashAmount.ToString();//Amount
                            logItemForDeno[4] = System.DateTime.Now.ToString();//Cash_Date
                            logItemForDeno[5] = denoInfo.DenoString;//Deno_Detail
                            logItemForDeno[6] = denoInfo.RefundString;//DenoRefund_Detail
                            logItemForDeno[7] = "R";//Status
                            logItemForDeno[8] = "0";//REVERSE
                            logItemForDeno[9] = entity.SourceBranchCode;//sourcebr
                            logItemForDeno[10] = entity.Currency;//cur
                            logItemForDeno[11] = denoInfo.DenoRateString;//DenoRate
                            logItemForDeno[12] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), entity.SourceBranchCode).ToString();//SettlementDate
                            logItemForDeno[13] = CXCOM00010.Instance.GetExchangeRate(entity.Currency, CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRateType)).ToString();//Rate
                            TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Deno, "RD Important Data Commit Deno", CurrentUserEntity.BranchCode,
                            logItemForDeno);
                        }

                        //ClientLog For Tlf
                        for (int i = 0; i < Tlf_List.Count; i++)
                        {
                            string[] logItemForTlf = new string[35];
                            logItemForTlf[0] = string.Empty;//GroupNo
                            logItemForTlf[1] = Tlf_List[i].ReferenceVoucherNo;//EntryNo
                            logItemForTlf[2] = Tlf_List[i].AccountNo;//AcctNo
                            logItemForTlf[3] = Tlf_List[i].Acode;//ACode(from COASetUp)
                            logItemForTlf[4] = Tlf_List[i].LocalAmount.ToString();//LocalAmount
                            logItemForTlf[5] = Tlf_List[i].SourceCurrency;//SourceCur
                            logItemForTlf[6] = string.Empty;//Cheque
                            logItemForTlf[7] = System.DateTime.Now.ToString();//Date_Time
                            logItemForTlf[8] = Tlf_List[i].SettlementDate.ToString();//SettlementDate
                            logItemForTlf[9] = Tlf_List[i].Status;//Status
                            logItemForTlf[10] = Tlf_List[i].SourceBranchCode;//SourceBr
                            logItemForTlf[11] = Tlf_List[i].Eno;//Rno
                            logItemForTlf[12] = string.Empty;//Duration
                            logItemForTlf[13] = string.Empty;//LasintDate
                            logItemForTlf[14] = Tlf_List[i].Rate.ToString();//intRate
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
                            TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Transaction, "RD Important Data Commit Transaction", CurrentUserEntity.BranchCode,
                            logItemForTlf);
                        }
                    }
                    CXUIMessageUtilities.ShowMessageByCode("MI90003"); //Delete Successful
                    View.ClearControl();
                    View.EnableControl();
                    View.SetFocusToRegisterNo();
                }
                #endregion
            }
            else
            {
                if (string.IsNullOrEmpty(this.view.RegisterNo.ToString()))
                {
                    this.SetFocus("mtxtRegisterNo");
                }
                else if (this.view.Amount.ToString().Equals(decimal.Zero.ToString()))
                {
                    this.SetFocus("txtAmount");
                }
            }

        }
        #endregion

        #region Helper Methods
        private CXDTO00001 GetDenoList(decimal amount, CXDMD00008 status)
        {
            denoStatus = true;
            if (CXUIScreenTransit.Transit("frmTLMVEW00011", true, new object[] { amount, View.Currency, status, "frmMNMVEW00023" }) == DialogResult.OK)
            {
                return CXUIScreenTransit.GetData<CXDTO00001>("frmMNMVEW00023");
            }
            else
            {
                //Error Occur becoz user don't enter deno entry but close the deno form.
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME00002);//Deno Amount Checking Fail. Please input again.
                return null;
            }
        }

        private bool CheckAmount(decimal amount,out string messageCode)
        {
            messageCode = CXClientWrapper.Instance.Invoke<IMNMSVE00023, string>(x => x.CheckAmount(view.PayerAccountNo, amount));
            if (string.IsNullOrEmpty(messageCode))
                return true;
            else if(messageCode=="MV00135")       //edited by ASDA
                return true;
            else 
                return false;
        }

        private decimal Computing(decimal amount, decimal fixAmt, decimal rate)
        {
            return fixAmt != 0 ? fixAmt : (amount * rate) / 100;
        }

        public void ShowData(TLMDTO00017 entity)
        {
            this.View.CalculateCommission = entity.Commission.Value;
            this.View.TlxCharges = entity.TlxCharges.Value;
            this.View.RegisterNo = entity.RegisterNo;
            this.View.DBank = entity.Dbank;
            this.View.Amount = entity.Amount.Value;
            this.View.Commission = entity.Commission.Value;
            this.View.TelexCharges = entity.TlxCharges.Value;
            this.View.PayerAccountNo = entity.AccountNo;
            this.View.PayerName = entity.Name;
            this.View.PayerNRC = entity.NRC;
            this.View.PayerAddress = entity.Address;
            this.View.PayerPhoneNo = entity.PhoneNo;
            this.View.Narration = entity.Narration;
            this.View.PayeeAccountNo = entity.ToAccountNo;
            this.View.PayeeName = entity.ToName;
            this.View.PayeeNRC = entity.ToNRC;
            this.View.PayeeAddress = entity.ToAddress;
            this.View.PayeePhoneNo = entity.ToPhoneNo;
            this.View.ChequeNo = entity.CheckNo;
            this.View.Currency = entity.Currency;
            this.View.AcSign = entity.AccountSign;
            this.View.OldCashAmount = entity.CashAmount.Value;
            this.View.OldChqueNo = entity.CheckNo;
            this.View.OldAccountNo = entity.AccountNo;
            if (entity.GroupNo != null && entity.GroupNo != string.Empty)
            {
                this.View.GroupNo = entity.GroupNo;
                this.View.GroupNoLabelVisible = true;
            }
            switch (entity.IncomeType)
            {
                case "TR": this.View.IsIncomeByTransfer = true; break;
                case "CS": this.View.IsIncomeByCash = true; break;
                default: this.View.IsNoIncome = true; break;
            }
            this.View.OldIncomeType = entity.IncomeType;
            if (string.IsNullOrEmpty(entity.AccountNo))
            {
                this.View.OldDrawingType = "Cash";
            }
            else
            {
                this.View.OldDrawingType = "Account";
            }

            type = entity.Type;    //IBS (or) IBL     edited by ASDA
        }

        private TLMDTO00017 GetEntity()
        {
            TLMDTO00017 entity = new TLMDTO00017();
            entity.RegisterNo = this.View.RegisterNo;
            entity.Dbank = this.View.DBank;
            entity.Amount = this.View.Amount;
            entity.Commission = this.View.Commission;
            entity.TlxCharges = this.View.TelexCharges;
            entity.AccountNo = this.View.PayerAccountNo;
            entity.Name = this.View.PayerName;
            entity.NRC = this.View.PayerNRC;
            entity.Address = this.View.PayerAddress;
            entity.PhoneNo = this.View.PayerPhoneNo;
            entity.Narration = this.View.Narration;
            entity.ToAccountNo = this.View.PayeeAccountNo;
            entity.ToName = this.View.PayeeName;
            entity.ToNRC = this.View.PayeeNRC;
            entity.ToAddress = this.View.PayeeAddress;
            entity.ToPhoneNo = this.View.PayeePhoneNo;
            entity.UpdatedUserId = CurrentUserEntity.CurrentUserID;
            entity.CreatedUserId = CurrentUserEntity.CurrentUserID;
            entity.SourceBranchCode = CurrentUserEntity.BranchCode;
            entity.CheckNo = this.View.ChequeNo;
            entity.GroupNo = this.View.GroupNo;
            entity.IncomeType = this.View.IncomeType;
            entity.AccountSign = this.View.AcSign;
            entity.Currency = this.View.Currency;
            entity.OldChequeNo = this.View.OldChqueNo;
            if (string.IsNullOrEmpty(View.PayerAccountNo))
            {
                entity.DrawingType = "Cash";
                entity.RDType = "CS";
            }
            else
            {
                entity.DrawingType = "Account";
                entity.RDType = "TR";
            }

            entity.OldIncomeType = View.OldIncomeType;
            entity.OldDrawingType = View.OldDrawingType;
            entity.Type = type;
            return entity;
        }
        #endregion
    }
}
