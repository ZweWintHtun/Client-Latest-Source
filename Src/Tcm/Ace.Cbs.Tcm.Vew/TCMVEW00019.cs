using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Utt;
namespace Ace.Cbs.Tcm.Vew
{
    public partial class TCMVEW00019 : BaseDockingForm,ITCMVEW00019
    {
        #region Constructor
        public TCMVEW00019()
        {
            InitializeComponent();
        }

        public TCMVEW00019(decimal denoAmount, IList<TLMDTO00012> denoData, string transactionStatus, string parentFormId)
        {
            InitializeComponent();
            this.DenoAmount = denoAmount;
            this.DepositDeno = denoData;
            this.parentFormId = parentFormId;
            this.TransactionStatus = transactionStatus;
            
        }
        #endregion

        #region Properties
        public string TransactionStatus{ get; set; }
        public string CounterNo
        {
            get
            {
                return this.txtCounterNo.Text.ToString();
            }
            set
            {
                this.txtCounterNo.Text = value;
            }
        }

        public string CounterType { get; set; }

        public string DepositEntryNo
        {
            get { return this.txtDepositEntryNo.Text; }
            set { this.txtDepositEntryNo.Text = value; }
        }

        public string WithdrawalEntryNo
        {
            get { return this.txtWithdrawEntryNo.Text; }
            set { this.txtWithdrawEntryNo.Text = value; }
        }

        public decimal Amount
        {
            get
            {
                decimal result = 0;
                decimal.TryParse(this.txtAmount.Text, out result);
                return Math.Round(result, 2);
            }
            set { this.txtAmount.Text = value.ToString(); }
        }     

        public decimal DenoAmount
        {
            get
            {
                decimal result = 0;
                decimal.TryParse(this.txtAmount1.Text, out result);
                return Math.Round(result, 2);
            }
            set { this.txtAmount1.Text = value.ToString(); }
        }

        public decimal TotalAmount
        {
            get
            {
                decimal result = 0;
                decimal.TryParse(this.txtTotalAmount.Text, out result);
                return Math.Round(result, 2);
            }
            set
            {
                this.txtTotalAmount.Text = value.ToString();
            }
        }

        public IList<TLMDTO00015> ListCashDenoDTO { get; set; }
        public IList<TLMDTO00012> DepositDeno { get; set; }        

        private IList<TLMDTO00012> denoData;
        public IList<TLMDTO00012> DenoData
        {
            get
            {                
                return this.denoData;
            }
            set
            {
                this.denoData = value;
            }
        }

        private void BindDenoInformation()
        {
            // Get Deno data by Currency.
            gvDenomination.DataSource = null;
            denoData = CXCLE00002.Instance.GetListObject<TLMDTO00012>("Deno.SelectByCurrencyCode", new object[] { this.DepositDeno[0].Currency,true });
            gvDenomination.AutoGenerateColumns = false;
            gvDenomination.DataSource = denoData;
        }

        private string parentFormId = string.Empty;
        public string ParentFormId
        {
            get { return this.parentFormId; }
            set { this.parentFormId = value; }
        }   

        public decimal counttotal { get; set; }

        #endregion

        #region Methods

        private void InitializeControls()
        {
            //ButtonEnableDisabled(newButtonEnabled, editButtonEnabled, saveButtonEnabled, deleteButtonEnabled,cancelButtonEnabled, printButtonEnabled, exitButtonEnabled);
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, false, false, true);
            this.Amount = this.DenoAmount;
            //this.DenoAmount = this.DenoAmount;
            this.BindDenoInformation();
        }
       
        #endregion

        #region Events

        private void TCMVEW00019_Load(object sender, EventArgs e)
        {
            this.InitializeControls();
            BindDenoInformation();
            this.CounterChecking();
        }

        private void gvDenomination_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            #region OldCode
            //try
            //{
            //    if (e.ColumnIndex < 0 || e.RowIndex < 0 || gvDenomination.Columns[e.ColumnIndex].ReadOnly == true)
            //        return;
            //    else
            //    {
            //        if (gvDenomination.Rows[e.RowIndex].Cells["colDescription"].Value.ToString().IndexOf("D1") != 0)
            //            counttotal -= Convert.ToDecimal(gvDenomination.Rows[e.RowIndex].Cells["D1"].Value) * Convert.ToDecimal(gvDenomination.Rows[e.RowIndex].Cells["Count"].Value);
            //        if (gvDenomination.Rows[e.RowIndex].Cells["colDescription"].Value.ToString().IndexOf("D2") != 0)
            //            counttotal -= (Convert.ToDecimal(gvDenomination.Rows[e.RowIndex].Cells["D2"].Value) / 100) * Convert.ToDecimal(gvDenomination.Rows[e.RowIndex].Cells["Count"].Value);
            //        this.TotalAmount = counttotal;
            //    }
            //    this.DenoData[e.RowIndex].DenoCount = Convert.ToInt32(gvDenomination.Rows[e.RowIndex].Cells["Count"].Value);
            //}
            //catch
            //{ }
            #endregion OldCode
        }

        private void gvDenomination_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            #region Old Code
            //try
            //{
            //    if (e.ColumnIndex < 0 || e.RowIndex < 0 || gvDenomination.Columns[e.ColumnIndex].ReadOnly == true)
            //        return;
            //    else
            //    {
            //        if (gvDenomination.Rows[e.RowIndex].Cells["colDescription"].Value.ToString().IndexOf("D1") != 0)
            //            counttotal += Convert.ToDecimal(gvDenomination.Rows[e.RowIndex].Cells["D1"].Value) * Convert.ToDecimal(gvDenomination.Rows[e.RowIndex].Cells["Count"].Value);
            //        if (gvDenomination.Rows[e.RowIndex].Cells["colDescription"].Value.ToString().IndexOf("D2") != 0)
            //            counttotal += (Convert.ToDecimal(gvDenomination.Rows[e.RowIndex].Cells["D2"].Value) / 100) * Convert.ToDecimal(gvDenomination.Rows[e.RowIndex].Cells["Count"].Value);
            //        this.TotalAmount = counttotal;
            //        //if (counttotal != 0 && counttotal > Amount)
            //        //    RefundAmount = Math.Abs(counttotal - Amount);
            //        //else
            //        //    RefundAmount = 0;
            //        //this.DenoData[e.RowIndex].DenoCount = Convert.ToInt32(gvDenomination.Rows[e.RowIndex].Cells["Count"].Value);
            //    }
            //}
            //catch
            //{ }
            #endregion Old Code

            try
            {
                if (e.ColumnIndex < 0 || e.RowIndex < 0 || gvDenomination.Columns[e.ColumnIndex].ReadOnly == true)
                    return;
                else
                {
                    decimal tosubtract = 0;
                    if (this.DenoData[e.RowIndex].D1 != 0 && this.DenoData[e.RowIndex].DenoCount != Convert.ToInt32(gvDenomination.Rows[e.RowIndex].Cells["Count"].Value))
                    {
                        tosubtract += Convert.ToDecimal(this.DenoData[e.RowIndex].D1) * (this.DenoData[e.RowIndex].DenoCount);
                    }
                    if (this.DenoData[e.RowIndex].D2 != 0 && this.DenoData[e.RowIndex].DenoCount != Convert.ToInt32(gvDenomination.Rows[e.RowIndex].Cells["Count"].Value))
                    {
                        tosubtract += (Convert.ToDecimal(this.DenoData[e.RowIndex].D2) / 100) * (this.DenoData[e.RowIndex].DenoCount);
                    }
                    this.TotalAmount = TotalAmount - tosubtract;
                    counttotal = 0;
                    if (gvDenomination.Rows[e.RowIndex].Cells["colDescription"].Value.ToString().IndexOf("D1") != 0 && this.DenoData[e.RowIndex].DenoCount != Convert.ToInt32(gvDenomination.Rows[e.RowIndex].Cells["Count"].Value))
                        counttotal += Convert.ToDecimal(gvDenomination.Rows[e.RowIndex].Cells["D1"].Value) * Convert.ToDecimal(gvDenomination.Rows[e.RowIndex].Cells["Count"].Value);
                    if (gvDenomination.Rows[e.RowIndex].Cells["colDescription"].Value.ToString().IndexOf("D2") != 0 && this.DenoData[e.RowIndex].DenoCount != Convert.ToInt32(gvDenomination.Rows[e.RowIndex].Cells["Count"].Value))
                        counttotal += (Convert.ToDecimal(gvDenomination.Rows[e.RowIndex].Cells["D2"].Value) / 100) * Convert.ToDecimal(gvDenomination.Rows[e.RowIndex].Cells["Count"].Value);
                    this.TotalAmount = this.TotalAmount + counttotal;
                }
                this.DenoData[e.RowIndex].DenoCount = Convert.ToInt32(gvDenomination.Rows[e.RowIndex].Cells["Count"].Value);
            }
            catch
            { }
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            //this.Amount = 0;
            //this.DenoAmount = 0;
            this.TotalAmount = 0;
            gvDenomination.Focus();
        }

        #endregion

        private bool CounterChecking()
        {
            switch (this.TransactionStatus)
            {
                case "Payment":
                    CounterType = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.PaymentCounterType);
                    foreach (CurrentCounterInfo Info in CurrentUserEntity.CounterList)
                    {
                        if (Info.CounterType == CounterType)
                        {
                            this.CounterNo = Info.CounterNo;
                            return true;
                        }
                    }
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV20047);
                    this.Close();
                    break;
                case "Receiving":
                    CounterType = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.ReceiveCounterType);
                    foreach (CurrentCounterInfo Info in CurrentUserEntity.CounterList)
                    {
                        if (Info.CounterType == CounterType)
                        {
                            this.CounterNo = Info.CounterNo;
                            return true;
                        }
                    }
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV20047);
                    this.Close();
                    break;
                case "ChiefCashierEntry":
                    CounterType = string.Empty;
                    this.CounterNo = string.Empty;
                    this.txtCounterNo.Visible = false;
                    this.lblCounterNo.Visible = false;
                    return true;
                    break;
            }
            return false;
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            #region OLdCode
            //if ((Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MC00018")) == System.Windows.Forms.DialogResult.Yes)
            //{
            //    //MessageBox.Show("Saving Successful");
            //    this.DepositEntryNo = "N0000000001";
            //    this.WithdrawalEntryNo = "N0000000002";
            //    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI90001");
            //    CXUIScreenTransit.SetData(this.ParentFormId, this.DenoAmount);
            //    this.Close();
            //}
            #endregion OLdCode
            if (this.Controller.ValidateAmount())
            {
                if ((Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MC00018")) == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Controller.Save();
                    this.Close();
                }
            }
        }

        private ITCMCTL00019 notechangewithdrawlcontroller;

        public ITCMCTL00019 Controller
        {
            get { return this.notechangewithdrawlcontroller; }
            set
            {
                this.notechangewithdrawlcontroller = value;
                this.notechangewithdrawlcontroller.View = this;
            }
        }    
    }
}
