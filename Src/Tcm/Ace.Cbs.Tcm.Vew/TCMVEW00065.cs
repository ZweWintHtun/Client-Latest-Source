//----------------------------------------------------------------------
// <copyright file="TCMVEW00065.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2014-02-10</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Tcm.Dmd;
using System.Windows.Forms;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient.Controls;

namespace Ace.Cbs.Tcm.Vew
{
    /// <summary>
    /// Daily Report Modify Entry
    /// </summary>
    public partial class TCMVEW00065 : BaseDockingForm,ITCMVEW00065
    {
        #region "Properties"
        public DateTime PostDate { get; set; }
        public string Currency { get; set; }
        TCMDTO00052 dailyreportDTO { get; set; }

        public decimal ReceivingCashAmount
        {
            get { return Convert.ToDecimal(this.txtReCashAmount.Text); }
            set { this.txtReCashAmount.Text = value.ToString(); }
        }
        public decimal ReceivingCashVoucher 
        { 
            get { return Convert.ToDecimal(this.txtReCashNoOfVouchers.Text); }
            set {this.txtReCashNoOfVouchers.Text=value.ToString() ;}
        }
        public decimal ReceivingTransferAmount 
        {
            get { return Convert.ToDecimal(this.txtRecTranAmount.Text);}
            set { this.txtRecTranAmount.Text=value.ToString();} 
        }
        public decimal ReceivingTransferVoucher
        {
            get { return Convert.ToDecimal(this.txtRecTranNoVouch.Text); }
            set { this.txtRecTranNoVouch.Text = value.ToString(); }
        }
        public decimal ReceivingClearingAmount 
        {
            get {return Convert.ToDecimal(this.txtRecClearingAmount.Text) ;}
            set { this.txtRecClearingAmount.Text = value.ToString(); } 
        }
        public decimal ReceivingClearingVoucher 
        {
            get { return Convert.ToDecimal(this.txtRecClearingVouch.Text); }
            set { this.txtRecClearingVouch.Text = value.ToString(); }
        }
        public decimal DrawingCashAmount
        {
            get { return Convert.ToDecimal(this.txtDrawCashAmount.Text); }
            set { this.txtDrawCashAmount.Text = value.ToString(); }
        }
        public decimal DrawingCashVoucher
        {
            get{ return Convert.ToDecimal(this.txtDrawCashVouch.Text); }
            set{ this.txtDrawCashVouch.Text = value.ToString();}            
        }
        public decimal DrawingTransferAmount
        { 
            get{return Convert.ToDecimal(this.txtDrawTransferAmount.Text); }
            set{this.txtDrawTransferAmount.Text=value.ToString(); }
        }
        public decimal DrawingTransferVoucher
        {
            get { return Convert.ToDecimal(this.txtDrawTranVouch.Text); }
            set { this.txtDrawTranVouch.Text = value.ToString(); }
        }
        public decimal PaymentCashAmount
        {
            get { return Convert.ToDecimal(this.txtPayCashAmount.Text); }
            set { this.txtPayCashAmount.Text = value.ToString(); }
        }
        public decimal PaymentCashVoucher
        {
            get { return Convert.ToDecimal(this.txtPayCashVouch.Text); }
            set { this.txtPayCashVouch.Text = value.ToString(); }
        }
        public decimal PaymentTransferAmount 
        {
            get { return Convert.ToDecimal(this.txtPayTransVouch.Text); }
            set { this.txtPayTransVouch.Text = value.ToString(); }
        }
        public decimal PaymentTransferVoucher 
        { 
            get { return Convert.ToDecimal(this.txtPayTransVouch.Text); }
            set { this.txtPayTransVouch.Text = value.ToString(); }
        }
        public decimal PaymentClearingAmount 
        {
            get { return Convert.ToDecimal(this.txtPayClrAmount.Text); }
            set { this.txtPayClrAmount.Text = value.ToString(); }
        }
        public decimal PaymentClearingVoucher
        {
            get { return Convert.ToDecimal(this.txtPayClearVouch.Text); }
            set { this.txtPayClearVouch.Text = value.ToString(); }
        }
        public decimal EncashCashAmount 
        {
            get { return Convert.ToDecimal(this.txtEncashCashAmount.Text); }
            set { this.txtEncashCashAmount.Text = value.ToString(); }
        }
        public decimal EncashCashVoucher 
        {
            get { return Convert.ToDecimal(this.txtEncashCashVouch.Text); }
            set{this.txtEncashCashVouch.Text=value.ToString();}
        }
        public decimal EncashTransferAmount 
        { 
            get{return Convert.ToDecimal(this.txtEncashTransAmount.Text);}
            set{this.txtEncashTransAmount.Text=value.ToString(); }
        }
        public decimal EncashTransferVoucher 
        {
            get { return Convert.ToDecimal(this.txtEncashTransVouch.Text); }
            set { this.txtEncashTransVouch.Text = value.ToString(); }
        }
        public decimal CashInHand
        {
            get { return Convert.ToDecimal(this.txtCashInHand.Text); }
            set { this.txtCashInHand.Text = value.ToString(); }
        }
        public decimal CashWithCBM 
        {
            get { return Convert.ToDecimal(this.txtCashWithCBM.Text); }
            set { this.txtCashWithCBM.Text = value.ToString(); }
        }
        public decimal CashWithOtherBank
        {
            get { return Convert.ToDecimal(this.txtCashWithOtherBank.Text); }
            set { this.txtCashWithOtherBank.Text = value.ToString(); }
        }
        public decimal CurrentACOpen 
        {
            get { return Convert.ToDecimal(this.txtCurrentOpen.Text); }
            set { this.txtCurrentOpen.Text = value.ToString(); }
        }
        public decimal SavingACOpen 
        {
            get { return Convert.ToDecimal(this.txtSavingOpened.Text); }
            set { this.txtSavingOpened.Text = value.ToString(); }
        }
        public decimal CallDepositACOpen 
        {
            get { return Convert.ToDecimal(this.txtCallDepositOpened.Text); }
            set { this.txtCallDepositOpened.Text = value.ToString(); }
        }
        public decimal FixDepositACOpen
        {
            get { return Convert.ToDecimal(this.txtFixedDepositOpened.Text); }
            set { this.txtFixedDepositOpened.Text = value.ToString(); }
        }
        public decimal CurrentACClose 
        {
            get { return Convert.ToDecimal(this.txtCurrentClosed.Text); }
            set { this.txtCurrentClosed.Text = value.ToString(); }
        }
        public decimal SavingACClose
        {
            get { return Convert.ToDecimal(this.txtSavingClosed.Text); }
            set { this.txtSavingClosed.Text = value.ToString(); }
        }
        public decimal CallDepositACCLose 
        { 
            get{return Convert.ToDecimal(this.txtCallDepositClosed.Text); }
            set{this.txtCallDepositClosed.Text=value.ToString(); }
        }
        public decimal FixedDepositACClose
        { 
            get{return Convert.ToDecimal(this.txtFixedDepositClosed.Text);}
            set{this.txtFixedDepositClosed.Text=value.ToString(); }
        }
        public decimal CurrentACTotal 
        {
            get { return Convert.ToDecimal(this.txtCurrentTotal.Text); }
            set { this.txtCurrentTotal.Text = value.ToString(); }
        }
        public decimal SavingACTotal
        {
            get { return Convert.ToDecimal(this.txtSavingTotal.Text); }
            set { this.txtSavingTotal.Text = value.ToString(); }
        }
        public decimal CallDepositTotal
        {
            get { return Convert.ToDecimal(this.txtCallDepositTotal.Text); }
            set { this.txtCallDepositTotal.Text = value.ToString(); }
        }
        public decimal FixedDepositTotal 
        {
            get { return Convert.ToDecimal(this.txtFixedDepositTotal.Text); }
            set { this.txtFixedDepositTotal.Text = value.ToString(); }
        }
        public decimal OpeningBalanceCurrent 
        {
            get { return Convert.ToDecimal(this.txtCurrentOpeningBalance.Text); }
            set { this.txtCurrentOpeningBalance.Text = value.ToString(); }
        }
        public decimal OpeningBalanceSaving
        {
            get { return Convert.ToDecimal(this.txtSavingOpeningBalance.Text); }
            set { this.txtSavingOpeningBalance.Text = value.ToString(); }
        }
        public decimal OpeningBanlaceCallDeposit 
        {
            get { return Convert.ToDecimal(this.txtCallDepositOBal.Text); }
            set { this.txtCallDepositOBal.Text = value.ToString(); }
        }
        public decimal OpeningBalanceFixedDeposit
        {
            get { return Convert.ToDecimal(this.txtFixedDepositOBal.Text); }
            set { this.txtFixedDepositOBal.Text = value.ToString(); }
        }
        public decimal DepositCurrent 
        {
            get { return Convert.ToDecimal(this.txtCurrentDeposit.Text); }
            set { this.txtCurrentDeposit.Text = value.ToString(); }
        }
        public decimal DepositSaving 
        {
            get { return Convert.ToDecimal(this.txtSavingDeposit.Text); }
            set { this.txtSavingDeposit.Text = value.ToString(); }
        }
        public decimal DepositCallDeposit 
        {
            get { return Convert.ToDecimal(this.txtCallDepositDeposit.Text); }
            set { this.txtCallDepositDeposit.Text = value.ToString(); }
        }
        public decimal DepositFixedDeposit
        {
            get { return Convert.ToDecimal(this.txtFixedDepositDeposit.Text); }
            set { this.txtFixedDepositDeposit.Text = value.ToString(); }
        }
        public decimal WithdrawalCurrent 
        {
            get { return Convert.ToDecimal(this.txtCurrentWithdrawal.Text); }
            set { this.txtCurrentWithdrawal.Text = value.ToString(); }
        }
        public decimal WithdrawalSaving
        {
            get { return Convert.ToDecimal(this.txtSavingWithdrawal.Text); }
            set { this.txtSavingWithdrawal.Text = value.ToString(); }
        }
        public decimal WithdrawalCallDeposit 
        { 
            get{return Convert.ToDecimal(this.txtCallDepositWithdrawal.Text);}
            set{this.txtCallDepositWithdrawal.Text=value.ToString(); }
        }
        public decimal WithdrawalFixedDeposit 
        {
            get { return Convert.ToDecimal(this.txtFixedDepositWithdrawal.Text); }
            set { this.txtFixedDepositWithdrawal.Text = value.ToString(); }
        }
        #endregion

        #region"Constructors"
        public TCMVEW00065()
        {
            InitializeComponent();           
        }

        public TCMVEW00065(DateTime datetime, string currency)
        {
            this.PostDate = datetime;
            this.Currency = currency;           
            this.InitializeComponent();
        }
        #endregion

        #region "Events"

        private void TCMVEW00065_Load(object sender, EventArgs e)
        {
            tsbCRUD.ButtonEnableDisabled(false, false, true, false, false, false, true);
            this.InitializeControls(true);
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            dailyreportDTO = this.DailyReportListingModifyController.GetDailyReport(false, this.dailyReportListingModifyController.GetViewData());            
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls(false);
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region "Methods"
        public void InitializeControls(bool isSeverice)
        {
            if (this.PostDate != null && this.Currency != string.Empty || this.Currency != null)
            {
                this.lblDPFor1.Text = this.PostDate.ToString("dd/MM/yyyy");              
                if (isSeverice == true)
                {
                    dailyreportDTO = this.DailyReportListingModifyController.GetDailyReport(true, dailyreportDTO);
                }
                if (dailyreportDTO != null)
                {
                    this.txtReCashAmount.Text = dailyreportDTO.RECEIPTCASH.ToString();
                    this.txtReCashNoOfVouchers.Text = dailyreportDTO.RECEIPTCASHVOU.ToString();
                    this.txtRecTranAmount.Text = dailyreportDTO.RECEIPTTRANSFER.ToString();
                    this.txtRecTranNoVouch.Text = dailyreportDTO.RECEIPTTRANSFERVOU.ToString();
                    this.txtRecClearingAmount.Text = dailyreportDTO.RECEIPTCLEARING.ToString();
                    this.txtRecClearingVouch.Text = dailyreportDTO.RECEIPTCLEARINGVOU.ToString();
                    this.txtDrawCashAmount.Text = dailyreportDTO.DRAWINGCASH.ToString();
                    this.txtDrawCashVouch.Text = dailyreportDTO.DRAWINGCASHVOU.ToString();
                    this.txtDrawTransferAmount.Text = dailyreportDTO.DRAWINGTRANSFER.ToString();
                    this.txtDrawTranVouch.Text = dailyreportDTO.DRAWINGTRANSFERVOU.ToString();
                    this.txtPayCashAmount.Text = dailyreportDTO.PAYMENTCASH.ToString();
                    this.txtPayCashVouch.Text = dailyreportDTO.PAYMENTCASHVOU.ToString();
                    this.txtPayTransAmount.Text = dailyreportDTO.PAYMENTTRANSFER.ToString();
                    this.txtPayTransVouch.Text = dailyreportDTO.PAYMENTTRANSFERVOU.ToString();
                    this.txtPayClrAmount.Text = dailyreportDTO.PAYMENTCLEARING.ToString();
                    this.txtPayClearVouch.Text = dailyreportDTO.PAYMENTCLEARINGVOU.ToString();
                    this.txtEncashCashAmount.Text = dailyreportDTO.ENCASHCASH.ToString();
                    this.txtEncashCashVouch.Text = dailyreportDTO.ENCASHCASHVOU.ToString();
                    this.txtEncashTransAmount.Text = dailyreportDTO.ENCASHTRANSFER.ToString();
                    this.txtEncashTransVouch.Text = dailyreportDTO.ENCASHTRANSFERVOU.ToString();
                    this.txtCashInHand.Text = dailyreportDTO.CASHINHAND.ToString();
                    this.txtCashWithCBM.Text = dailyreportDTO.CASHWITHCBM.ToString();
                    this.txtCashWithOtherBank.Text = dailyreportDTO.ACWITHOTHBANK.ToString();
                    this.txtCurrentOpen.Text = dailyreportDTO.CUROPENED.ToString();
                    this.txtCurrentClosed.Text = dailyreportDTO.CURCLOSED.ToString();
                    this.txtCurrentTotal.Text = dailyreportDTO.CURTOTAL.ToString();
                    this.txtCurrentOpeningBalance.Text = dailyreportDTO.CUROBAL.ToString();
                    this.txtCurrentDeposit.Text = dailyreportDTO.CURDEP.ToString();
                    this.txtCurrentWithdrawal.Text = dailyreportDTO.CURWITH.ToString();
                    this.txtSavingOpened.Text = dailyreportDTO.SAVOPENED.ToString();
                    this.txtSavingClosed.Text = dailyreportDTO.SAVCLOSED.ToString();
                    this.txtSavingTotal.Text = dailyreportDTO.SAVTOTAL.ToString();
                    this.txtSavingOpeningBalance.Text = dailyreportDTO.SAVOBAL.ToString();
                    this.txtSavingDeposit.Text = dailyreportDTO.SAVDEP.ToString();
                    this.txtSavingWithdrawal.Text = dailyreportDTO.SAVWITH.ToString();
                    this.txtCallDepositOpened.Text = dailyreportDTO.CALOPENED.ToString();
                    this.txtCallDepositClosed.Text = dailyreportDTO.CALCLOSED.ToString();
                    this.txtCallDepositTotal.Text = dailyreportDTO.CALTOTAL.ToString();
                    this.txtCallDepositOBal.Text = dailyreportDTO.CALOBAL.ToString();
                    this.txtCallDepositDeposit.Text = dailyreportDTO.CALDEP.ToString();
                    this.txtCallDepositWithdrawal.Text = dailyreportDTO.CALWITH.ToString();
                    this.txtFixedDepositOpened.Text = dailyreportDTO.FIXOPENED.ToString();
                    this.txtFixedDepositClosed.Text = dailyreportDTO.FIXCLOSED.ToString();
                    this.txtFixedDepositTotal.Text = dailyreportDTO.FIXTOTAL.ToString();
                    this.txtFixedDepositOBal.Text = dailyreportDTO.FIXOBAL.ToString();
                    this.txtFixedDepositDeposit.Text = dailyreportDTO.FIXDEP.ToString();
                    this.txtFixedDepositWithdrawal.Text = dailyreportDTO.FIXWITH.ToString();
                    lblReceivingTotalAmount.Text = Convert.ToString(dailyreportDTO.RECEIPTCASH + dailyreportDTO.RECEIPTTRANSFER + dailyreportDTO.RECEIPTCLEARING);
                    lblReceivingTotalVouch.Text = Convert.ToString(dailyreportDTO.RECEIPTCASHVOU + dailyreportDTO.RECEIPTTRANSFERVOU + dailyreportDTO.RECEIPTCLEARINGVOU);
                    lblDrawingClearingAmount.Text = Convert.ToString(dailyreportDTO.DRAWINGCASH + dailyreportDTO.DRAWINGTRANSFER);
                    lblDrawingClearingVouch.Text = Convert.ToString(dailyreportDTO.DRAWINGCASHVOU + dailyreportDTO.DRAWINGTRANSFERVOU);
                    lblPaymentTotalAmount.Text = Convert.ToString(dailyreportDTO.PAYMENTCASH + dailyreportDTO.PAYMENTTRANSFER + dailyreportDTO.PAYMENTCLEARING);
                    lblPaymentTotalVouch.Text = Convert.ToString(dailyreportDTO.PAYMENTCASHVOU + dailyreportDTO.PAYMENTCLEARINGVOU + dailyreportDTO.PAYMENTTRANSFERVOU);
                    lblEncashClearingAmount.Text = Convert.ToString(dailyreportDTO.ENCASHCASH + dailyreportDTO.ENCASHTRANSFER);
                    lblEncashClearingVouch.Text = Convert.ToString(dailyreportDTO.ENCASHCASHVOU + dailyreportDTO.ENCASHTRANSFERVOU);

                    lblTotal.Text = Convert.ToString(dailyreportDTO.CASHINHAND + dailyreportDTO.ACWITHOTHBANK);                  
                    lblCurrentClosingBalance.Text = Convert.ToString(dailyreportDTO.CUROBAL + dailyreportDTO.CURDEP - dailyreportDTO.CURWITH);
                    lblSavingClosingBalance.Text = Convert.ToString((dailyreportDTO.SAVOBAL + dailyreportDTO.SAVDEP) - dailyreportDTO.SAVWITH);
                    lblCallDepositClosingBalance.Text = Convert.ToString((dailyreportDTO.CALOBAL + dailyreportDTO.CALDEP) - dailyreportDTO.CALWITH);
                    lblFixedDepositClosingBalance.Text = Convert.ToString((dailyreportDTO.FIXOBAL + dailyreportDTO.FIXDEP) - dailyreportDTO.FIXWITH);

                    lblOpened.Text = Convert.ToString(dailyreportDTO.CUROPENED + dailyreportDTO.SAVOPENED + dailyreportDTO.CALOPENED + dailyreportDTO.FIXOPENED);
                    lblClosed.Text = Convert.ToString(dailyreportDTO.CURCLOSED + dailyreportDTO.SAVCLOSED + dailyreportDTO.CALCLOSED + dailyreportDTO.FIXCLOSED);
                    lblTotal.Text = Convert.ToString(dailyreportDTO.CURTOTAL + dailyreportDTO.SAVTOTAL + dailyreportDTO.CALTOTAL + dailyreportDTO.FIXTOTAL);
                    lblOpeningBalance.Text = Convert.ToString(dailyreportDTO.CUROBAL + dailyreportDTO.SAVOBAL + dailyreportDTO.CALOBAL + dailyreportDTO.FIXOBAL);
                    lblDeposit.Text = Convert.ToString(dailyreportDTO.CURDEP + dailyreportDTO.CALDEP + dailyreportDTO.SAVDEP + dailyreportDTO.FIXDEP);
                    lblWithdrawal.Text = Convert.ToString(dailyreportDTO.CALWITH + dailyreportDTO.CURWITH + dailyreportDTO.SAVWITH + dailyreportDTO.FIXWITH);
                    lblTotalClosingBalance.Text = Convert.ToString(dailyreportDTO.CUROPENED + dailyreportDTO.SAVOPENED + dailyreportDTO.CALOPENED + dailyreportDTO.FIXOPENED + dailyreportDTO.CURCLOSED + dailyreportDTO.SAVCLOSED + dailyreportDTO.CALCLOSED + dailyreportDTO.FIXCLOSED + dailyreportDTO.CURTOTAL + dailyreportDTO.SAVTOTAL + dailyreportDTO.CALTOTAL + dailyreportDTO.FIXTOTAL + dailyreportDTO.CUROBAL + dailyreportDTO.SAVOBAL + dailyreportDTO.CALOBAL + dailyreportDTO.FIXOBAL + dailyreportDTO.CURDEP + dailyreportDTO.CALDEP + dailyreportDTO.SAVDEP + dailyreportDTO.FIXDEP + dailyreportDTO.CALWITH + dailyreportDTO.CURWITH + dailyreportDTO.SAVWITH + dailyreportDTO.FIXWITH);
                    this.txtReCashAmount.Focus();
                }

                else
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI30038");//Please run posting for Post Date{2013.12.02}
                }
                
            }
            else
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("ME90018");
            }
            this.label1.Text = this.Currency;      
        }

        public void Successful(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }

        public void Failure(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME90000);
            }
            else
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
            }
        }

        public void GetViewData()
        {
            TCMDTO00052 dailyReportDTO = new TCMDTO00052();
            dailyReportDTO.CUR = this.Currency;
            this.txtReCashAmount.Text = dailyreportDTO.RECEIPTCASH.ToString();
            this.txtReCashNoOfVouchers.Text = dailyreportDTO.RECEIPTCASHVOU.ToString();
            this.txtRecTranAmount.Text = dailyreportDTO.RECEIPTTRANSFER.ToString();
            this.txtRecTranNoVouch.Text = dailyreportDTO.RECEIPTTRANSFERVOU.ToString();
            this.txtRecClearingAmount.Text = dailyreportDTO.RECEIPTCLEARING.ToString();
            this.txtRecClearingVouch.Text = dailyreportDTO.RECEIPTCLEARINGVOU.ToString();
            this.txtDrawCashAmount.Text = dailyreportDTO.DRAWINGCASH.ToString();
            this.txtDrawCashVouch.Text = dailyreportDTO.DRAWINGCASHVOU.ToString();
            this.txtDrawTransferAmount.Text = dailyreportDTO.DRAWINGTRANSFER.ToString();
            this.txtDrawTranVouch.Text = dailyreportDTO.DRAWINGTRANSFERVOU.ToString();
            this.txtPayCashAmount.Text = dailyreportDTO.PAYMENTCASH.ToString();
            this.txtPayCashVouch.Text = dailyreportDTO.PAYMENTCASHVOU.ToString();
            this.txtPayTransAmount.Text = dailyreportDTO.PAYMENTTRANSFER.ToString();
            this.txtPayTransVouch.Text = dailyreportDTO.PAYMENTTRANSFERVOU.ToString();
            this.txtPayClrAmount.Text = dailyreportDTO.PAYMENTCLEARING.ToString();
            this.txtPayClearVouch.Text = dailyreportDTO.PAYMENTCLEARINGVOU.ToString();
            this.txtEncashCashAmount.Text = dailyreportDTO.ENCASHCASH.ToString();
            this.txtEncashCashVouch.Text = dailyreportDTO.ENCASHCASHVOU.ToString();
            this.txtEncashTransAmount.Text = dailyreportDTO.ENCASHTRANSFER.ToString();
            this.txtEncashTransVouch.Text = dailyreportDTO.ENCASHTRANSFERVOU.ToString();
            this.txtCashInHand.Text = dailyreportDTO.CASHINHAND.ToString();
            this.txtCashWithCBM.Text = dailyreportDTO.CASHWITHCBM.ToString();
            this.txtCashWithOtherBank.Text = dailyreportDTO.ACWITHOTHBANK.ToString();
            this.txtCurrentOpen.Text = dailyreportDTO.CUROPENED.ToString();
            this.txtCurrentClosed.Text = dailyreportDTO.CURCLOSED.ToString();
            this.txtCurrentTotal.Text = dailyreportDTO.CURTOTAL.ToString();
            this.txtCurrentOpeningBalance.Text = dailyreportDTO.CUROBAL.ToString();
            this.txtCurrentDeposit.Text = dailyreportDTO.CURDEP.ToString();
            this.txtCurrentWithdrawal.Text = dailyreportDTO.CURWITH.ToString();
            this.txtSavingOpened.Text = dailyreportDTO.SAVOPENED.ToString();
            this.txtSavingClosed.Text = dailyreportDTO.SAVCLOSED.ToString();
            this.txtSavingTotal.Text = dailyreportDTO.SAVTOTAL.ToString();
            this.txtSavingOpeningBalance.Text = dailyreportDTO.SAVOBAL.ToString();
            this.txtSavingDeposit.Text = dailyreportDTO.SAVDEP.ToString();
            this.txtSavingWithdrawal.Text = dailyreportDTO.SAVWITH.ToString();
            this.txtCallDepositOpened.Text = dailyreportDTO.CALOPENED.ToString();
            this.txtCallDepositClosed.Text = dailyreportDTO.CALCLOSED.ToString();
            this.txtCallDepositTotal.Text = dailyreportDTO.CALTOTAL.ToString();
            this.txtCallDepositOBal.Text = dailyreportDTO.CALOBAL.ToString();
            this.txtCallDepositDeposit.Text = dailyreportDTO.CALDEP.ToString();
            this.txtCallDepositWithdrawal.Text = dailyreportDTO.CALWITH.ToString();
            this.txtFixedDepositOpened.Text = dailyreportDTO.FIXOPENED.ToString();
            this.txtFixedDepositClosed.Text = dailyreportDTO.FIXCLOSED.ToString();
            this.txtFixedDepositTotal.Text = dailyreportDTO.FIXTOTAL.ToString();
            this.txtFixedDepositOBal.Text = dailyreportDTO.FIXOBAL.ToString();
            this.txtFixedDepositDeposit.Text = dailyreportDTO.FIXDEP.ToString();
            this.txtFixedDepositWithdrawal.Text = dailyreportDTO.FIXWITH.ToString();
          
        }
        #endregion

        #region "Controller"
        private ITCMCTL00065 dailyReportListingModifyController;
        public ITCMCTL00065 DailyReportListingModifyController
        {
            get
            {
                return this.dailyReportListingModifyController;
            }
            set
            {

                this.dailyReportListingModifyController = value;
                this.dailyReportListingModifyController.DailyReportListingModifyView = this;

            }
        }
        #endregion
    }
}
