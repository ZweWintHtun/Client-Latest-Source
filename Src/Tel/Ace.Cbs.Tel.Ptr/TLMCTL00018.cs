//----------------------------------------------------------------------
// <copyright file="TLMSVE00018.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hnin Thazin Shwe</CreatedUser>
// <CreatedDate>07/12/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Tel.Ptr
{
    public class TLMCTL00018 : AbstractPresenter, ITLMCTL00018
    {
        #region Properties
        string accountSign = string.Empty;
        string accountType = string.Empty;
        private decimal cashAmount;
        public CXDMD00004 _AccountType{ get; set; }
        public string AccountType { get; set; }
       // public CXDTO00001 GetDenoString { get; set; }
        public IList<PFMDTO00001> AccountInformationList { get; set; }
        
        private ITLMVEW00018 view;

        public ITLMVEW00018 View
        { 
            get {return this.view;}
            set { this.WireTo(value); }
        }
        private string _CounterNo { get; set; }
        private bool _IsContinue { get; set; }
        public bool IsDomesticAcType { get; set; }
        private decimal _AdjustAmount { get; set; }
        private string AccountSign { get; set; }
        #endregion

        private void WireTo(ITLMVEW00018 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetRemittanceEntity());
               
            }
        }
        public string GetSourceBranch()
        {
            string sourcebr = CurrentUserEntity.BranchCode+"( "+CurrentUserEntity.BranchDescription +" )";
            return sourcebr;
        }
        public void GetAccountType(string accountSign)
        {          
            if (accountSign.StartsWith("C"))
              _AccountType = CXDMD00004.CurrentAccount;
            else if (accountSign.StartsWith("S"))
            _AccountType = CXDMD00004.SavingAccount;

            this.AccountType = _AccountType.ToString();
        }              
        public void Continue()
        {
            TLMDTO00054 remittance = this.GetRemittanceEntity();
            this._IsContinue = true;
            if (this.ValidateForm(remittance))
            {
                this.view.EnableDisableControlsforContinueClick();
                this.View.DisableEnableControlsForContinueEvent(false);
                this.view.BindBranchCode();
            }
            this._IsContinue = false;
        }

        public void ClearControls(bool isCancel)
        {
            if (isCancel)
            {
                this.view.AccountNo = string.Empty;
                this.view.IsDrawingGroupBox = false;
            }
            this.view.SenderName = string.Empty;
            this.view.GroupNo = string.Empty;
            //this.view.CurrencyCode = string.Empty;
            this.view.SenderName = string.Empty;
            this.view.NRC = string.Empty;
            this.view.Address = string.Empty;                                                    
            this.view.PhoneNo = string.Empty;
            this.view.Narration = string.Empty;
            this.view.TotalAmount = 0;
            this.view.ChequeNo = string.Empty;
        }

        public void mtxtAccountNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.view.AccountNo))
            //if (false == e.HasXmlBaseError)
            {
                if (CXCLE00012.Instance.CheckAccountNoType(this.view.AccountNo, CXDMD00011.DomesticAccountType))
                {
                    try
                    {
                        ChargeOfAccountDTO coa = CXCLE00002.Instance.GetScalarObject<ChargeOfAccountDTO>("COA.Client.SelectAccountName", new object[] { this.view.AccountNo, CXCOM00007.Instance.BranchCode, true });

                        if (this.View.IsDrawingGroupBox.Equals(true)) this.View.IsDrawingGroupBox = false;
                        this.IsDomesticAcType = true;
                        if (!_IsContinue)
                            this.View.InitializedState();
                        this.view.AccountNo = this.view.AccountNo.ToUpper();
                         this.view.SenderName = coa.AccountName;
                        this.View.HideControls(false,true,_IsContinue);
                        this.IsDomesticAcType = true;
                        this.View.IsChequeNoEnable = false;
                    }
                    catch
                    {
                        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00046);
                    }
                    
                }
                else if (CXCLE00012.Instance.CheckAccountNoType(this.View.AccountNo, CXDMD00011.AccountNoType2))
                {
                    if (CXCOM00006.Instance.Validate(this.view.AccountNo, CXCOM00009.AccountNoCodeFormat, CXCOM00009.AccountNoCheckDigitFormula))
                    {
                        // Clear  Account No Error.
                        if (!_IsContinue && this.view.IsIncome) this.View.IsDrawingGroupBox = true;
                        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), string.Empty);
                        if (this.IsDomesticAcType.Equals(true)) this.IsDomesticAcType = false;
                        IList<PFMDTO00001> customerInformation = CXClientWrapper.Instance.Invoke<ICXSVE00006, IList<PFMDTO00001>>(x => x.GetCustomerInfomationByAccountNo(this.View.AccountNo, false));
                        if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                        {
                            this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode);
                            return;
                        }
                        if (customerInformation != null)
                        {
                            if (customerInformation[0].CloseDate == null)   //Added by ASDA
                            {
                                accountSign = customerInformation[0].AccountSign;
                                this.AccountSign = customerInformation[0].AccountSign;
                                this.GetAccountType(accountSign);
                                //this.CheckSavingAccountTransaction(this.view.IsVIP);

                                if (this._AccountType == CXDMD00004.SavingAccount && this.view.IsVIP.Equals(false))
                                {
                                    if (CXClientWrapper.Instance.Invoke<ITLMSVE00018, bool>(x => x.HasSavingAccountTransaction(this.view.AccountNo, CurrentUserEntity.CurrentUserID)))
                                    {
                                        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode, new object[] { this.view.AccountNo });
                                        return;
                                    }
                                    else
                                    {
                                        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), string.Empty);
                                    }
                                }

                                this.View.HideControls(false, false, false);
                                this.View.SenderName = customerInformation[0].Name;
                                this.View.NRC = customerInformation[0].NRC;
                                this.View.Address = customerInformation[0].Address + ", " +customerInformation[0].TownshipDesp+", " +
                                                    customerInformation[0].CityDesp + ", " + customerInformation[0].StateDesp;
                                this.View.PhoneNo = customerInformation[0].PhoneNo;
                                this.View.CurrencyCode = customerInformation[0].CurrencyCode;

                                
                                this.view.DisableControlsByAccountDrawing();
                                this.view.EnableControlByAccountDrawing();
                                if (!_IsContinue)
                                {
                                    this.view.TotalAmount = 0;
                                    this.view.Narration = string.Empty;
                                    if (this.AccountType.Equals("SavingAccount"))
                                    {
                                        this.view.IsChequeNoEnable = false;
                                        this.view.ChequeNo = string.Empty;
                                    }
                                }
                            }
                            else //Added by ASDA
                            {
                                this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00044);    //Account No {0} has been closed.                                
                            }
                        }
                        else
                        {
                            this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode, new object[] { this.view.AccountNo });
                        }
                    }
                    else
                    {
                        this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00046);
                    }
                }
                else
                {
                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXMessage.MV00199);
                }
         
            }
            else if (!_IsContinue)
            {
                this.View.InitializedState();
                this.View.IsChequeNoEnable = false;
                this.View.IsEnableIncomeBox = true;
                this.View.DisableGroupBox();
            }
        }
        public void txtTotalAmount_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError)
            {
                return;
            }
            else if (String.IsNullOrEmpty(this.view.AccountNo)||IsDomesticAcType)
            {
                return;
            }
            else
            {
                if (this._IsContinue)
                {
                    CXDTO00009 dto = CXClientWrapper.Instance.Invoke<ITLMSVE00018, CXDTO00009>(x => x.AmountInformationChecking(this.View.AccountNo, this.View.TotalAmount, this.View.IsVIP));
                    if (!String.IsNullOrEmpty(dto.MessageCode))
                    {
                        //Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(dto.MessageCode);
                        this.SetCustomErrorMessage(this.GetControl("txtTotalAmount"), dto.MessageCode);
                        return;
                    }
                    else
                    {
                        if (dto.IsLink)
                        {
                            if (Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC00009) == DialogResult.No)
                            {
                                this.SetCustomErrorMessage(this.GetControl("txtTotalAmount"), CXMessage.MV00109);
                                //Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00109);
                                return;
                            }
                        }
                    }
                }
            }
            
        }
        public void txtChequeNo_CustomValidating(object sender, ValidationEventArgs e)
        {
            if (e.HasXmlBaseError)
            {
                return;
            }
            else             
            {

                this.view.ChequeNo = CXCLE00007.GetFormatString(Convert.ToInt32(this.view.ChequeNo), CXCOM00009.ChequeNoDisplayFormat);
                if (this._IsContinue)
                {
                    if (!string.IsNullOrEmpty(this.view.ChequeNo))
                    {
                        if (!CXClientWrapper.Instance.Invoke<ITLMSVE00018, bool>(x => x.IsValidChequeNo(this.view.AccountNo, this.view.ChequeNo, CXCOM00007.Instance.BranchCode)))
                        {
                            this.SetCustomErrorMessage(this.GetControl("txtChequeNo"), CXClientWrapper.Instance.ServiceResult.MessageCode, new object[] { this.view.ChequeNo });
                        }
                        else
                        {
                            this.SetCustomErrorMessage(this.GetControl("txtChequeNo"), string.Empty);
                        }
                    }
                    else
                    {
                        this.SetCustomErrorMessage(this.GetControl("mtxtaccountno"), CXMessage.MV00037);
                    }
                }
            }
        }

        public bool ValidAccountNo(string accountNo,string drawerBank)
        {
            bool flag = false;
              // AccountNo Checking (Code Format and CheckDigit,etc.)
            Nullable<CXDMD00011> accountType;

            if (CXCLE00012.Instance.IsValidAccountNo(accountNo, out accountType) && (accountType == CXDMD00011.AccountNoType1 || accountType == CXDMD00011.AccountNoType2))
            {
                AccountInformationList = CXClientWrapper.Instance.Invoke<ITLMSVE00014, IList<PFMDTO00001>>(x => x.GetAccountInfoByAccountNo(accountNo, false, drawerBank,DateTime.Now));
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    flag = false;
                }
                else
                {
                    if (AccountInformationList.Count > 0 && AccountInformationList[0].SourceBranch != drawerBank)
                    {
                        CXUIMessageUtilities.ShowMessageByCode("MV00091", drawerBank);   //Invalid Account No for Branch {0}.
                        flag = false;
                    }
                    else
                        flag = true;
                }
            }
            return flag;           
        }                

        private void CheckSavingAccountTransaction(bool vip)
        {            
            if (this._AccountType == CXDMD00004.SavingAccount && vip.Equals(false))
            {
                if (CXClientWrapper.Instance.Invoke<ITLMSVE00018, bool>(x => x.HasSavingAccountTransaction(this.view.AccountNo, CurrentUserEntity.CurrentUserID)))
                {
                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), CXClientWrapper.Instance.ServiceResult.MessageCode, new object[] { this.view.AccountNo });
                    return;
                }
                else
                {
                    this.SetCustomErrorMessage(this.GetControl("mtxtAccountNo"), string.Empty);
                }
            }
       } 

        #region"Comission & TelexCharges For IBL"
        public TLMDTO00029 GetTelexChargesByIBLDrawerBranchCodeAndCurrencyCode(string drawerbranchcode, string currencycode)
        {
            try
            {
                return CXCLE00002.Instance.GetScalarObject<TLMDTO00029>("CXCLE00015.Client.IBL.TLXChargesSelectedByBranchCodeandCur", new object[] { drawerbranchcode, currencycode, CurrentUserEntity.BranchCode ,true});
            }
            catch
            {
                return null;
            }
        }
        
        public TLMDTO00030 GetCommisionByIBLDrawerBranchCodeCurrencyCodeAndAmount(string drawerbranchcode, string currencycode, decimal amount)
        {
            return CXCLE00002.Instance.GetObjectByCustomHQL<TLMDTO00030>("TLMDAO00030.SelectRateFixAmtByBranchCodeAndCur", new Dictionary<string, object>() { { "branchCode", drawerbranchcode }, { "cur", currencycode }, { "amount", amount },{"sourceBranchCode",CurrentUserEntity.BranchCode} }); ;
        }
        public TLMDTO00030 GetEndNoByIBLDrawerBranchCodeCurrencyCodeAndAmount(string drawerbranchcode, string currencycode)
        {
            return CXCLE00002.Instance.GetObjectByCustomHQL<TLMDTO00030>("TLMDAO00030.SelectRateFixAmtEndNoByBranchCodeAndCur", new Dictionary<string, object>() { { "branchCode", drawerbranchcode }, { "cur", currencycode }, { "sourceBranchCode", CurrentUserEntity.BranchCode } }); ;
        }
        #endregion

        #region"Comission & TelexCharges For IBS"
        public TLMDTO00032 GetCommisionByIBSDrawerBranchCodeCurrencyCodeAndAmount(string drawerbranchcode, string currencycode, decimal amount)
        {
            return CXCLE00002.Instance.GetObjectByCustomHQL<TLMDTO00032>("TLMDAO00032.SelectRateFixAmtByBranchCodeAndCur", new Dictionary<string, object>() { { "branchCode", drawerbranchcode }, { "cur", currencycode }, { "amount", amount }, { "sourceBranchCode", CurrentUserEntity.BranchCode } }); ;
        }
        public TLMDTO00032 GetEndNoByIBSDrawerBranchCodeCurrencyCodeAndAmount(string drawerbranchcode, string currencycode)
        {
            return CXCLE00002.Instance.GetObjectByCustomHQL<TLMDTO00032>("TLMDAO00032.SelectRateFixAmtEndNoByBranchCodeAndCur", new Dictionary<string, object>() { { "branchCode", drawerbranchcode }, { "cur", currencycode }, { "sourceBranchCode", CurrentUserEntity.BranchCode } }); ;
        }

        public TLMDTO00028 GetTelexChargesByIBSDrawerBranchCodeAndCurrencyCode(string drawerbranchcode, string currencycode)
        {
            TLMDTO00028 list = CXCLE00002.Instance.GetScalarObject<TLMDTO00028>("CXCLE00015.Client.IBS.TLXChargesSelectedByBranchCodeandCur", new object[] { drawerbranchcode, currencycode,CurrentUserEntity.BranchCode,true });
            //if (CXClientWrapper.Instance.ServiceResult.MessageCode == CXMessage.ME00021)  //Client Dat not Found
            //{
            //    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00195);  //Branch No. {0}  Remittance Info is missing
            //    return null;
            //}
            return list;           
        }


        #endregion

        private TLMDTO00054 GetRemittanceEntity()
         {
            TLMDTO00054 getRemittanceEntity = new TLMDTO00054();
            getRemittanceEntity.CurrencyCode = this.view.CurrencyCode;
            getRemittanceEntity.AccountNo = this.view.AccountNo;
            getRemittanceEntity.Name = this.view.SenderName;
            getRemittanceEntity.NRC = this.view.NRC;
            getRemittanceEntity.Address = this.view.Address;
            getRemittanceEntity.PhoneNo = this.view.PhoneNo;
            getRemittanceEntity.Narration = this.view.Narration;
            getRemittanceEntity.TotalAmount = this.view.TotalAmount;
            //getRemittanceEntity.AccountSign = Convert.ToString(this._AccountType);
            getRemittanceEntity.AccountSign = this.AccountSign;
            getRemittanceEntity.ChequeNo = this.view.ChequeNo;            
            getRemittanceEntity.CashAmount = this.cashAmount;
            getRemittanceEntity.TransactionStatus = this.view.TransactionStatus;
            getRemittanceEntity.SourceBranchCode = CXCOM00007.Instance.BranchCode;
            getRemittanceEntity.CreatedUserId = CurrentUserEntity.CurrentUserID;
            getRemittanceEntity.CounterNo = this._CounterNo;
            getRemittanceEntity.ToName = CurrentUserEntity.CurrentUserName;
            getRemittanceEntity.AdjustAmount = this._AdjustAmount;
            getRemittanceEntity.Type = this.view.IncomeType;
            getRemittanceEntity.IsTakeIncome = this.view.IsTakeIncome;//For Solve Drawing,Encash Different Amount.
            if (this.view.IsIncome)
            {
                if (!String.IsNullOrEmpty(this.view.AccountNo))
                {
                    getRemittanceEntity.RDType = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRate); // need to put in appsettings. HTZS
                }
                else
                {
                    getRemittanceEntity.RDType = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashRateType);//HTZS
                }
                if (this.view.IsCash)
                {
                    getRemittanceEntity.IncomeType = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashRateType);//HTZS
                }
                else
                {
                    getRemittanceEntity.IncomeType = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRate);//HTZS
                }
            }
            else
            {
                if (!this.view.AccountNo.Equals("") || !String.IsNullOrEmpty(this.view.AccountNo))
                {
                    getRemittanceEntity.RDType = "TR";//HTZS
                }
                //if (!this.view.AccountNo.Equals(null))
                //{
                //    getRemittanceEntity.RDType = "TR";//HTZS
                //}
                else
                {
                    getRemittanceEntity.RDType = "CS";//HTZS
                }
                if (this.view.IsCash)
                {
                    if (this.view.IncomeType != null || !String.IsNullOrEmpty(this.view.IncomeType))
                    {
                        getRemittanceEntity.IncomeType = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.CashRateType);//HTZS
                    }
                    if (this.view.IncomeType == null)
                    {
                        getRemittanceEntity.IncomeType = null;
                    }

                }
                else
                {
                    getRemittanceEntity.IncomeType = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.TransferRate);//HTZS
                }
            }
            return getRemittanceEntity;
        }

        //private bool GetDenoList()
        //{
        //    this.cashAmount = this.GetCashAmount();
        //    if (cashAmount != 0)
        //    {
        //        if (CXUIScreenTransit.Transit("frmTLMVEW00011", new object[] { this.cashAmount, this.view.CurrencyCode, CXDMD00008.Received, "frmTLMVEW00018" }) == DialogResult.OK)
        //        {
        //            //IList<TLMDTO00012> deno = CXUIScreenTransit.GetData<IList<TLMDTO00012>>("frmTLMVEW00018");
        //            //return CXCLE00009.Instance.GetDenoString(deno, true, CXCOM00007.Instance.BranchCode);
        //            this.GetDenoString = CXUIScreenTransit.GetData<CXDTO00001>("frmTLMVEW00018");
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}

        private decimal GetCashAmount()
        {
            decimal cashamount = 0;
            if (this.view.IsIncome)
            {
                if (this.view.IsCash)
                {
                    if (String.IsNullOrEmpty(this.view.AccountNo))
                    {
                        cashamount = (!this.View.IsTakeIncome)?this.view.TotalAmount + this.view.totalcomission + this.view.totaltelexcharges:this.view.TotalAmount;
                    }
                    else
                    {
                        cashamount = (this.View.IsTakeIncome)?0:this.view.totalcomission + this.view.totaltelexcharges;
                    }
                }
            }
            else
            {
                if (String.IsNullOrEmpty(this.view.AccountNo))
                {
                    cashamount = this.view.totalamount;
                }
            }
            return cashamount;
        }

        public void Save(IList<TLMDTO00054> drawingList)
        {
            /*Requested By ANS, modified by HWH.No need to load Deno Form.*/
            //if (this.GetDenoList())
            //{
                //if (this.GetDenoString == null)
                //{
                //    this._CounterNo = string.Empty;
                //    this._AdjustAmount = 0;
                //}
                //else
                //{
                //    this._CounterNo = GetDenoString.CounterNo;
                //    this._AdjustAmount = GetDenoString.AdjustAmount;
                //}

                TLMDTO00054 remittance = this.GetRemittanceEntity();
                
                IList<TLMDTO00054> RegisterNoList = CXClientWrapper.Instance.Invoke<ITLMSVE00018, IList<TLMDTO00054>>(x => x.Save(remittance, drawingList));
                
                foreach (TLMDTO00054 item in RegisterNoList)
                {
                    item.AccountNo = this.view.AccountNo;
                    item.Name = this.view.SenderName;
                    item.NRC = this.view.NRC;
                    item.PhoneNo = this.view.PhoneNo;
                    item.Narration = this.view.Narration;
                    item.Address = this.view.Address;
                    item.CurrencyCode = remittance.CurrencyCode;
                }
                #region ErrorOccurred
                if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred)
                {
                    //For IBL Drawing
                    if (remittance.TransactionStatus == "IBL")
                    {
                        for (int i = 0; i < drawingList.Count; i++)
                        {
                            string[] logItemForDrawing = new string[26];
                            logItemForDrawing[0] = RegisterNoList[i].RegisterNo;//Registerno
                            logItemForDrawing[1] = drawingList[i].Dbank;//Dbank
                            logItemForDrawing[2] = remittance.TransactionStatus;//Type
                            logItemForDrawing[3] = remittance.Name;//Name
                            logItemForDrawing[4] = drawingList[i].ToAccountNo.ToString();//ToAcctno
                            logItemForDrawing[5] = drawingList[i].ToName;//ToName
                            if (remittance.IsTakeIncome)
                            {
                                logItemForDrawing[6] = drawingList[i].RemitAmount.ToString();//Amount
                            }
                            else
                            {
                                logItemForDrawing[6] = drawingList[i].ToAmount.ToString();//Amount
                            }
                            logItemForDrawing[7] = System.DateTime.Now.ToString();//Date_time
                            logItemForDrawing[8] = string.Empty;//ReceiptDate
                            logItemForDrawing[9] = System.DateTime.Now.ToString();//IncomeDate
                            logItemForDrawing[10] = string.Empty;//SendDate
                            logItemForDrawing[11] = string.Empty;//Deno_Status
                            logItemForDrawing[12] = remittance.SourceBranchCode;//SourceBr
                            logItemForDrawing[13] = remittance.CurrencyCode;//SourceCur
                            if (drawingList.Count > 1)
                                logItemForDrawing[14] = RegisterNoList[i].GroupNo;//GroupNo
                            else
                                logItemForDrawing[14] = string.Empty;//GroupNo
                            logItemForDrawing[15] = ";TestKey=>" + drawingList[i].TestKey.ToString();//Eno
                            logItemForDrawing[16] = remittance.AccountNo;//AcctNo
                            logItemForDrawing[17] = string.Empty;//ACode
                            logItemForDrawing[18] = string.Empty;//LocalAmount
                            logItemForDrawing[19] = remittance.CurrencyCode;//SourceCur
                            logItemForDrawing[20] = remittance.ChequeNo;//Cheque
                            logItemForDrawing[21] = System.DateTime.Now.ToString();//DATE_TIME
                            logItemForDrawing[22] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), remittance.SourceBranchCode).ToString();//SettlementDate
                            logItemForDrawing[23] = string.Empty;//Status
                            logItemForDrawing[24] = string.Empty;//IssueDate
                            logItemForDrawing[25] = string.Empty;//Ebank
                            TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Drawing, "Drawing(IBL) Fail Transaction", CurrentUserEntity.BranchCode,
                                        logItemForDrawing);
                        }
                    }
                    //For IBS Drawing
                    else
                    {
                        for (int i = 0; i < drawingList.Count; i++)
                        {
                            string[] logItemForDrawing = new string[26];
                            logItemForDrawing[0] = RegisterNoList[i].RegisterNo;//Registerno
                            logItemForDrawing[1] = drawingList[i].Dbank;//Dbank
                            logItemForDrawing[2] = remittance.TransactionStatus;//Type
                            logItemForDrawing[3] = remittance.Name;//Name
                            logItemForDrawing[4] = drawingList[i].ToAccountNo.ToString();//ToAcctno
                            logItemForDrawing[5] = drawingList[i].ToName;//ToName
                            if (remittance.IsTakeIncome)
                            {
                                logItemForDrawing[6] = drawingList[i].RemitAmount.ToString();//Amount
                            }
                            else
                            {
                                logItemForDrawing[6] = drawingList[i].ToAmount.ToString();//Amount
                            }
                            logItemForDrawing[7] = System.DateTime.Now.ToString();//Date_time
                            logItemForDrawing[8] = string.Empty;//ReceiptDate
                            logItemForDrawing[9] = System.DateTime.Now.ToString();//IncomeDate
                            logItemForDrawing[10] = string.Empty;//SendDate
                            logItemForDrawing[11] = string.Empty;//Deno_Status
                            logItemForDrawing[12] = remittance.SourceBranchCode;//SourceBr
                            logItemForDrawing[13] = remittance.CurrencyCode;//SourceCur
                            if (drawingList.Count > 1)
                                logItemForDrawing[14] = RegisterNoList[i].GroupNo;//GroupNo
                            else
                                logItemForDrawing[14] = string.Empty;//GroupNo
                            logItemForDrawing[15] = ";TestKey=>" + drawingList[i].TestKey.ToString();//Eno
                            logItemForDrawing[16] = remittance.AccountNo;//AcctNo
                            logItemForDrawing[17] = string.Empty;//ACode
                            logItemForDrawing[18] = string.Empty;//LocalAmount
                            logItemForDrawing[19] = remittance.CurrencyCode;//SourceCur
                            logItemForDrawing[20] = remittance.ChequeNo;//Cheque
                            logItemForDrawing[21] = System.DateTime.Now.ToString();//DATE_TIME
                            logItemForDrawing[22] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), remittance.SourceBranchCode).ToString();//SettlementDate
                            logItemForDrawing[23] = string.Empty;//Status
                            logItemForDrawing[24] = string.Empty;//IssueDate
                            logItemForDrawing[25] = string.Empty;//Ebank
                            TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Drawing, "Drawing(IBS) Commit Transaction", CurrentUserEntity.BranchCode,
                                        logItemForDrawing);
                        }
                    }
                    this.View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
                }
                #endregion
                #region Successful
                else
                {
                    string groupNo = RegisterNoList[0].GroupNo;
                    //if (RegisterNoList.Count > 0)
                    //{
                    //    this.view.gvCustomer_DataBind(RegisterNoList);
                    //}
                    //For IBL Drawing
                    if (remittance.TransactionStatus == "IBL")
                    {
                        for (int i = 0; i < drawingList.Count; i++)
                        {
                            string[] logItemForDrawing = new string[26];
                            logItemForDrawing[0] = RegisterNoList[i].RegisterNo;//Registerno
                            logItemForDrawing[1] = drawingList[i].Dbank;//Dbank
                            logItemForDrawing[2] = remittance.TransactionStatus;//Type
                            logItemForDrawing[3] = remittance.Name;//Name
                            logItemForDrawing[4] = drawingList[i].ToAccountNo.ToString();//ToAcctno
                            logItemForDrawing[5] = drawingList[i].ToName;//ToName
                            if (remittance.IsTakeIncome)
                            {
                                logItemForDrawing[6] = drawingList[i].RemitAmount.ToString();//Amount
                            }
                            else
                            {
                                logItemForDrawing[6] = drawingList[i].ToAmount.ToString();//Amount
                            }
                            logItemForDrawing[7] = System.DateTime.Now.ToString();//Date_time
                            logItemForDrawing[8] = string.Empty;//ReceiptDate
                            logItemForDrawing[9] = System.DateTime.Now.ToString();//IncomeDate
                            logItemForDrawing[10] = string.Empty;//SendDate
                            logItemForDrawing[11] = string.Empty;//Deno_Status
                            logItemForDrawing[12] = remittance.SourceBranchCode;//SourceBr
                            logItemForDrawing[13] = remittance.CurrencyCode;//SourceCur
                            if (drawingList.Count > 1)
                                logItemForDrawing[14] = RegisterNoList[i].GroupNo;//GroupNo
                            else
                                logItemForDrawing[14] = string.Empty;//GroupNo
                            logItemForDrawing[15] = ";TestKey=>" + drawingList[i].TestKey.ToString();//Eno
                            logItemForDrawing[16] = remittance.AccountNo;//AcctNo
                            logItemForDrawing[17] = string.Empty;//ACode
                            logItemForDrawing[18] = string.Empty;//LocalAmount
                            logItemForDrawing[19] = remittance.CurrencyCode;//SourceCur
                            logItemForDrawing[20] = remittance.ChequeNo;//Cheque
                            logItemForDrawing[21] = System.DateTime.Now.ToString();//DATE_TIME
                            logItemForDrawing[22] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), remittance.SourceBranchCode).ToString();//SettlementDate
                            logItemForDrawing[23] = string.Empty;//Status
                            logItemForDrawing[24] = string.Empty;//IssueDate
                            logItemForDrawing[25] = string.Empty;//Ebank
                            TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Drawing, "Drawing(IBL) Commit Transaction", CurrentUserEntity.BranchCode,
                                        logItemForDrawing);
                        }
                    }
                    //For IBS Drawing
                    else
                    {
                        for (int i = 0; i < drawingList.Count; i++)
                        {
                            string[] logItemForDrawing = new string[26];
                            logItemForDrawing[0] = RegisterNoList[i].RegisterNo;//Registerno
                            logItemForDrawing[1] = drawingList[i].Dbank;//Dbank
                            logItemForDrawing[2] = remittance.TransactionStatus;//Type
                            logItemForDrawing[3] = remittance.Name;//Name
                            logItemForDrawing[4] = drawingList[i].ToAccountNo.ToString();//ToAcctno
                            logItemForDrawing[5] = drawingList[i].ToName;//ToName
                            if (remittance.IsTakeIncome)
                            {
                                logItemForDrawing[6] = drawingList[i].RemitAmount.ToString();//Amount
                            }
                            else
                            {
                                logItemForDrawing[6] = drawingList[i].ToAmount.ToString();//Amount
                            }
                            logItemForDrawing[7] = System.DateTime.Now.ToString();//Date_time
                            logItemForDrawing[8] = string.Empty;//ReceiptDate
                            logItemForDrawing[9] = System.DateTime.Now.ToString();//IncomeDate
                            logItemForDrawing[10] = string.Empty;//SendDate
                            logItemForDrawing[11] = string.Empty;//Deno_Status
                            logItemForDrawing[12] = remittance.SourceBranchCode;//SourceBr
                            logItemForDrawing[13] = remittance.CurrencyCode;//SourceCur
                            if (drawingList.Count > 1)
                                logItemForDrawing[14] = RegisterNoList[i].GroupNo;//GroupNo
                            else
                                logItemForDrawing[14] = string.Empty;//GroupNo
                            logItemForDrawing[15] = ";TestKey=>" + drawingList[i].TestKey.ToString();//Eno
                            logItemForDrawing[16] = remittance.AccountNo;//AcctNo
                            logItemForDrawing[17] = string.Empty;//ACode
                            logItemForDrawing[18] = string.Empty;//LocalAmount
                            logItemForDrawing[19] = remittance.CurrencyCode;//SourceCur
                            logItemForDrawing[20] = remittance.ChequeNo;//Cheque
                            logItemForDrawing[21] = System.DateTime.Now.ToString();//DATE_TIME
                            logItemForDrawing[22] = CXCOM00010.Instance.GetNextSettlementDate(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.NextSettlementDate), remittance.SourceBranchCode).ToString();//SettlementDate
                            logItemForDrawing[23] = string.Empty;//Status
                            logItemForDrawing[24] = string.Empty;//IssueDate
                            logItemForDrawing[25] = string.Empty;//Ebank
                            TransactionLogUtilities.TransactionLogWriting(Windows.Core.DataModel.TransactionLog.Drawing, "Drawing(IBS) Commit Transaction", CurrentUserEntity.BranchCode,
                                        logItemForDrawing);
                        }
                    }
                    if (!String.IsNullOrEmpty(groupNo))
                    {
                        this.view.GroupNo = RegisterNoList[0].GroupNo;
                    }
                    if (!String.IsNullOrEmpty(this.view.AccountNo) && this.view.IsIncome)
                    {
                        this.view.InformAboutCharges("MI00130");
                    }
                    if (this.view.Successful("MI00024"))
                    {
                        this.PrintMethod(RegisterNoList);
                    }
                    else
                    {
                        // if do not print, insert to drawingPrinting....
                        IList<TLMDTO00021> drawingPrintingList = new List<TLMDTO00021>();
                        if (RegisterNoList.Count > 0)
                        {
                            foreach (TLMDTO00054 drawingPrintingDto in RegisterNoList)
                            {
                                    TLMDTO00021 drawingPrintingData = new TLMDTO00021();
                                    drawingPrintingData.RegisterNo = drawingPrintingDto.RegisterNo;
                                    drawingPrintingData.RAmount = drawingPrintingDto.CashAmountInWord = CXCLE00012.Instance.CalculateAmountToWords(Convert.ToDouble(drawingPrintingDto.ToAmount), drawingPrintingDto.CurrencyCode);
                                    drawingPrintingData.WorkStation = System.Environment.MachineName;
                                    drawingPrintingData.CreatedDate = DateTime.Now;
                                    drawingPrintingData.CreatedUserId = CurrentUserEntity.CurrentUserID;
                                    drawingPrintingData.SourceBranchCode = CurrentUserEntity.BranchCode;
                                    drawingPrintingList.Add(drawingPrintingData);                               
                            }
                        }
                        
                        CXClientWrapper.Instance.Invoke<ITLMSVE00018>(x => x.Save_DrawingPrinting(drawingPrintingList));
                    }
                }
                #endregion
            // }
        }

        #region "Print Methods"

        private void PrintMethod(IList<TLMDTO00054> printList)
        {
            BranchDTO banch = new BranchDTO();
            foreach (TLMDTO00054 dto in printList)
            {
                if(this.view.TransactionStatus=="IBL")
                    banch = this.GetIBLBranchTownShipName(dto.Dbank);
                else
                    banch = this.GetBankTownName(dto.Dbank);

                dto.CashAmountInWord = CXCLE00012.Instance.CalculateAmountToWords(Convert.ToDouble(dto.ToAmount), dto.CurrencyCode);                   
                dto.AmountInZawGyiFont = this.CashInZawGyiFont(dto.RemitAmount);
                dto.BankDescription = banch.BranchDescription;
                dto.BankTown = banch.BranchCode;
                dto.Amount = dto.RemitAmount;
                dto.Type = dto.CreatedDate.ToString("dd/MM/yyyy");
            }
            CXUIScreenTransit.Transit("frmTLMVEW00074.DrawingRemittanceRegisterEntry", true, new object[] { (this.view.IsIncome) ? "Income" : "No Income", printList });
        }

        //private string CashInWord(decimal amount)
        //{
        //    return this.NumberToText((int)amount);
        //}

        private string CashInZawGyiFont(decimal amount)
        {
            //int stringCount = (amount.ToString().Length);
            string keyword = string.Empty;
            //for (int i = 0; i < stringCount; i++)
            //{
            //    keyword += (amount.ToString()).;
            //}
            //return keyword;

            char[] keys = (amount.ToString()).ToCharArray();
            foreach (char item in keys)
            {
                keyword += GetZawGyiFont(item);
            }
            return this.ThousandSeparator(keyword);
        }

        public string ThousandSeparator(string myNumber)
        {
            var myResult = "";
            for (var i = myNumber.Length - 1; i >= 0; i--)
            {
                myResult = myNumber[i] + myResult;
                if ((myNumber.Length - i) % 3 == 0 & i > 0)
                    myResult = "," + myResult;
            }

            return myResult + ".၀၀";
        }

        private string GetZawGyiFont(char key)
        {
            switch (key)
            {
                case '1':
                    return "၁";
                case '2':
                    return "၂";
                case '3':
                    return "၃";
                case '4':
                    return "၄";
                case '5':
                    return "၅";
                case '6':
                    return "၆";
                case '7':
                    return "၇";
                case '8':
                    return "၈";
                case '9':
                    return "၉";
                default:
                    return "၀";
            }
        }

        private BranchDTO GetBankTownName(string bank)
        {
            return CXCLE00002.Instance.GetObjectByCustomHQL<BranchDTO>("SelectBankCityandBranchDescription", new Dictionary<string, object>() { { "branchcode", bank } });
        }

        private BranchDTO GetIBLBranchTownShipName(string bank)
        {
            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { bank });            
            string townshipDescription = CXCLE00002.Instance.GetScalarObject<string>("TownshipCode.SelectByCode",Branch.TownshipCode, true);
            Branch.BranchCode = townshipDescription;
            return Branch;
            //return CXCLE00002.Instance.GetObjectByCustomHQL<BranchDTO>("SelectTownshipDescription", new Dictionary<string, object>() { { "branchcode", bank } });
        }

        //private string NumberToText(int n)
        //{
        //    if (n < 0)
        //        return "Minus " + NumberToText(-n);
        //    else if (n == 0)
        //        return "";
        //    else if (n <= 19)
        //        return new string[] {"One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", 
        // "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", 
        // "Seventeen", "Eighteen", "Nineteen"}[n - 1] + " ";
        //    else if (n <= 99)
        //        return new string[] {"Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", 
        // "Eighty", "Ninety"}[n / 10 - 2] + " " + NumberToText(n % 10);
        //    else if (n <= 199)
        //        return "One Hundred " + NumberToText(n % 100);
        //    else if (n <= 999)
        //        return NumberToText(n / 100) + "Hundred " + NumberToText(n % 100);
        //    else if (n <= 1999)
        //        return "One Thousand " + NumberToText(n % 1000);
        //    else if (n <= 999999)
        //        return NumberToText(n / 1000) + "Thousand " + NumberToText(n % 1000);
        //    else if (n <= 1999999)
        //        return "One Million " + NumberToText(n % 1000000);
        //    else if (n <= 999999999)
        //        return NumberToText(n / 1000000) + "Million " + NumberToText(n % 1000000);
        //    else if (n <= 1999999999)
        //        return "One Billion " + NumberToText(n % 1000000000);
        //    else
        //        return NumberToText(n / 1000000000) + "Billion " + NumberToText(n % 1000000000);
        //}
       
        #endregion
    }
}
