using System;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Tcm.Ctr.Sve;

namespace Ace.Cbs.Tcm.Ptr
{
    public class TCMCTL00001 : AbstractPresenter, ITCMCTL00001
    {
        #region Form Initializer

        private ITCMVEW00001 fixedDepositTransferView;
        public ITCMVEW00001 FixedDepositTransferView
        {
            get
            {
                return this.fixedDepositTransferView;
            }
            set
            {
                this.WireTo(value);
            }
        }

        private void WireTo(ITCMVEW00001 view)
        {
            if (this.fixedDepositTransferView == null)
            {
                this.fixedDepositTransferView = view;
                this.Initialize(this.fixedDepositTransferView, this.FixedDepositTransferView.FReceiptEntity);
            }
        }

        int printedLine;
        List<string[]> printingList;

        #endregion

        #region Validating Methods

        public void mtxtCreditAccountNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            // if xml base error does not exist.
            if (e.HasXmlBaseError == true)
                return;
            else if (!string.IsNullOrEmpty(this.FixedDepositTransferView.Status))
                return;
            try
            {
                Nullable<CXDMD00011> accountType;
                if (CXCLE00012.Instance.IsValidAccountNo(this.FixedDepositTransferView.CreditAccountNo, out accountType))
                {
                    if (accountType.Value != CXDMD00011.AccountNoType2)
                        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV20054); // invalid Account Type
                }
            }
            catch (Exception ex)
            {
                // Set Error Message to Control.
                this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), ex.Message);
            }
        }

        public void mtxtDebitAccountNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            // if xml base error does not exist.
            if (e.HasXmlBaseError)
                return;
            try
            {
                PFMDTO00028 CledgerDTO;
                Nullable<CXDMD00011> accountType;
                if (CXCLE00012.Instance.IsValidAccountNo(this.FixedDepositTransferView.DebitAccountNo, out accountType))
                {
                    if (accountType.Value != CXDMD00011.AccountNoType2)
                        this.SetCustomErrorMessage(this.GetControl("mtxtDebitAccountNo"), CXMessage.MV20054); // invalid Account Type
                    else
                    {
                        CledgerDTO = CXClientWrapper.Instance.Invoke<ITCMSVE00001, PFMDTO00028>(x => x.SelectByAccountNumber(this.FixedDepositTransferView.DebitAccountNo, this.FixedDepositTransferView.SourceBranchCode,DateTime.Now));
                        if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                        {
                            if (CXClientWrapper.Instance.ServiceResult.MessageCode.Equals(CXMessage.MV00224))
                                this.SetCustomErrorMessage(this.GetControl("mtxtDebitAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode, new object[] { this.FixedDepositTransferView.DebitAccountNo, CurrentUserEntity.BranchCode });
                            else
                                this.SetCustomErrorMessage(this.GetControl("mtxtDebitAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                            return;
                        }

                        this.FixedDepositTransferView.CurrencyCode = CledgerDTO.CurrencyCode;
                        this.FixedDepositTransferView.AccountSign = CledgerDTO.AccountSign;

                        if (CledgerDTO.AccountSign.Substring(0, 1) == CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CurrentAccountSign))
                        {
                            this.FixedDepositTransferView.EnableControlsForReceiptEditing("FixedDepositTransfer.ChequeNo.Enable");
                            this.fixedDepositTransferView.GetCheckNofocus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Set Error Message to Control.
                this.SetCustomErrorMessage(this.GetControl("mtxtDebitAccountNo"), ex.Message);
            }
        }

        public void cboDuration_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError)
                return;

            string desp = this.FixedDepositTransferView.Duration.ToString();
            decimal duration = this.FixedDepositTransferView.Duration;
            this.FixedDepositTransferView.Rate = this.FixedDepositTransferView.FixRateList.Where(a => a.Duration == duration).SingleOrDefault<PFMDTO00007>().Rate;
        }

        public void ntxtAmount_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError)
                return;

            decimal minimunAmount, FixedDividedAmount;
            string temp = CXCOM00007.Instance.GetValueByVariable("FATRANAMT");

            if (temp == string.Empty)
                minimunAmount = 0;
            else
                minimunAmount = Convert.ToDecimal(temp);

            temp = CXCOM00007.Instance.GetValueByVariable("FADIVIDER");

            if (temp == string.Empty)
                FixedDividedAmount = 0;
            else
                FixedDividedAmount = Convert.ToDecimal(temp);

            if (minimunAmount > FixedDepositTransferView.Amount)
                this.SetCustomErrorMessage(this.GetControl("txtAmount"), CXMessage.MV00038);
            else if (FixedDepositTransferView.Amount < FixedDividedAmount)
                this.SetCustomErrorMessage(this.GetControl("txtAmount"), CXMessage.MV00038);
            else
                this.SetCustomErrorMessage(this.GetControl("txtAmount"), string.Empty);
        }

        public void mtxtTakenAccountNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            // if xml base error does not exist.
            if (e.HasXmlBaseError == true)
                return;
            else if (string.IsNullOrEmpty(this.FixedDepositTransferView.TakenAccount))
                return;
            try
            {
                Nullable<CXDMD00011> accountType;
                if (CXCLE00012.Instance.IsValidAccountNo(this.FixedDepositTransferView.TakenAccount, out accountType))
                {
                    if (accountType.Value != CXDMD00011.AccountNoType2)
                        this.SetCustomErrorMessage(this.GetControl("mtxtInterestTakenAccount"), CXMessage.MV20054); // invalid Account Type
                }
            }
            catch (Exception ex)
            {
                // Set Error Message to Control.
                this.SetCustomErrorMessage(this.GetControl("mtxtInterestTakenAccount"), ex.Message);
            }
        }

        public void txtChequeNo_Validating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError)
                return;
            else
                this.FixedDepositTransferView.ChequeNo = CXCLE00007.GetFormatString(Convert.ToInt32(this.FixedDepositTransferView.ChequeNo), CXCOM00009.ChequeNoDisplayFormat);
        }

        #endregion

        #region Main Methods

        public bool Save(PFMDTO00032 fReceiptEntity)
        {
            if (!this.ValidateForm(fReceiptEntity))
                return false;
            //try
            //{
            fReceiptEntity.SourceBranchCode = CurrentUserEntity.BranchCode;
            this.FixedDepositTransferView.ReceiptNo = CXClientWrapper.Instance.Invoke<ITCMSVE00001, string>(x => x.Save(fReceiptEntity));

            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
            {
                if (CXClientWrapper.Instance.ServiceResult.MessageCode == CXMessage.MV00224 || CXClientWrapper.Instance.ServiceResult.MessageCode == CXMessage.MV00086)
                    CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode, CXClientWrapper.Instance.ServiceResult.MessageCode.Equals(CXMessage.MV00224) ? new object[] { this.FixedDepositTransferView.CreditAccountNo, CurrentUserEntity.BranchCode } :
                     new object[] { this.FixedDepositTransferView.CurrencyCode });
                else
                    CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);

                return false;
            }
            else
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI00051, new object[] { "Receipt No", this.FixedDepositTransferView.ReceiptNo });
                return true;
            }
            //}
            //catch (Exception ex)
            //{
            //    //CXUIMessageUtilities.ShowMessageByCode(ex.InnerException.Message);
            //    //return false;
            //}
        }

        public void PRN_FilePrinting(string accountNo)
        {
            try
            {
                IList<PFMDTO00043> PintFileList = new List<PFMDTO00043>();
                printingList = new List<string[]>();
                string[] list;

                list = new string[] { accountNo };

                PintFileList = CXCLE00006.Instance.SelectAllPrintingDataForCSAccounts(list);

                foreach (PFMDTO00043 prnFile in PintFileList)
                {
                    string[] prnFileStrArr = { prnFile.DATE_TIME.Value.ToString("yyyy/mm/dd"), prnFile.Reference, prnFile.Credit.ToString(), prnFile.Debit.ToString(), prnFile.Balance.ToString(), prnFile.Id.ToString() };

                    printingList.Add(prnFileStrArr);
                }
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI00017, new object[] { accountNo });

                CXCLE00005.Instance.StartLineNo = PintFileList[0].PrintLineNo == 0 ? 1 : Convert.ToInt32(PintFileList[0].PrintLineNo);
                printedLine = CXCLE00005.Instance.StartLineNo;
                CXCLE00005.Instance.PrintingList("PassBookCode", "LineByLine", "PassBookPrinting", printingList, false, true, out printedLine);

                if (!CXCLE00006.Instance.UpdateAfterPrintingForCS(accountNo, printedLine,CurrentUserEntity.CurrentUserID))
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME90043);
            }
            catch
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME00061);
            }
        }

        public void FPRN_FilePrinting(string accountNo)
        {
            try
            {
                IList<PFMDTO00058> PintFileList = new List<PFMDTO00058>();
                printingList = new List<string[]>();
                string[] list;

                list = new string[] { accountNo };

                PintFileList = CXCLE00006.Instance.SelectAllPrintingDataForFixedAccounts(list);

                foreach (PFMDTO00058 prnFile in PintFileList)
                {
                    string[] prnFileStrArr = { prnFile.CreatedDate.ToString("yyyy/mm/dd"), prnFile.Reference, prnFile.Credit.ToString(), prnFile.Debit.ToString(), prnFile.Balance.ToString(), prnFile.Id.ToString() };

                    printingList.Add(prnFileStrArr);
                }
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI00017, new object[] { accountNo });

                CXCLE00005.Instance.StartLineNo = PintFileList[0].lineNo == 0 ? 1 : PintFileList[0].lineNo;
                printedLine = CXCLE00005.Instance.StartLineNo;
                CXCLE00005.Instance.PrintingList("PassBookCode", "LineByLine", "PassBookPrinting", printingList, false, true, out printedLine);

                if (!CXCLE00006.Instance.UpdateAfterPrintingForFixed(accountNo, printedLine, CurrentUserEntity.CurrentUserID))
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME90043);
            }
            catch (Exception ex)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME00061);
            }
        }

        #endregion

    }
}
