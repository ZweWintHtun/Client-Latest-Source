using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Core.Utt;
using System.Linq;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Tcm.Ctr.Ptr;

namespace Ace.Cbs.Tcm.Vew
{
    public partial class TCMVEW00017 : BaseDockingForm, ITCMVEW00017 
    {
        #region UI Properties

        public string TlfEntryNo
        {
            get
            {
                if (this.cboEntryNo.Text == string.Empty)
                    return string.Empty;
                else
                    return this.cboEntryNo.Text;
            }
            set
            {
                this.cboEntryNo.Text = value;
            }
        }

        private ITCMCTL00017 _controller;
        public ITCMCTL00017 Controller
        {
            get
            {
                return this._controller;
            }
            set
            {
                this._controller = value;
                _controller.View = this;
            }
        }

        private IList<TLMDTO00015> _cashDenoList;
        public IList<TLMDTO00015> CashDenoList
        {
            get
            {
                if (this._cashDenoList == null)
                    return new List<TLMDTO00015>();
                return _cashDenoList;
            }
            set
            {
                this._cashDenoList = value;
            }
        }

        public string Currency
        {
            get
            {
                return this.txtCurrency.Text;
            }
            set
            {
                this.txtCurrency.Text = value;
            }
        }

        public decimal Totalamount
        {
            get
            {
                decimal result = 0;
                decimal.TryParse(this.txtAmount.Text, out result);
                return Math.Round(result, 2);
            }
            set { this.txtAmount.Text = value.ToString(); }
        }
        #endregion

        #region Constructors

        public TCMVEW00017()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        private void BindEntryNo()
        {
            
            cboEntryNo.ValueMember = "TlfEntryNo";
            cboEntryNo.DisplayMember = "TlfEntryNo";
            
            //To Avoid firing SelectedIndexChanged Event afther binding data to combobox datasource
            this.cboEntryNo.SelectedIndexChanged -= new EventHandler(cboEntryNo_SelectedIndexChanged); 
            
            cboEntryNo.DataSource = this.CashDenoList
                                    .GroupBy(a => a.TlfEntryNo)
                                    .Select(g => g.First()).ToList();
            cboEntryNo.SelectedIndex = -1;
            
            this.cboEntryNo.SelectedIndexChanged += new EventHandler(cboEntryNo_SelectedIndexChanged);
        }

        private void BindGridData()
        {
            this.gvMultiPaymentOrderIssueInformation.DataSource = null;
            this.gvMultiPaymentOrderIssueInformation.AutoGenerateColumns = false;
            this.gvMultiPaymentOrderIssueInformation.DataSource = this.Controller.GetGridData();
        }

        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }

        public void Successful(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
            this.Controller.GetCashDeno();
            if (this.CashDenoList.Count > 0)
            {
                this.BindEntryNo();

            }

            else 
            {

                cboEntryNo.Enabled = false;            
            }

        }

        public void ClearingForm()
        {
            this.BindGridData();
            this.gvMultiPaymentOrderIssueInformation.DataSource = null;
            this.gvMultiPaymentOrderIssueInformation.Refresh();
            this.Controller.ClearErrors();
        }
        #endregion


        #region Events

        private void TCMVEW00017_Load(object sender, EventArgs e)
        {
            // Button Enable Disabled
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            this.Controller.GetCashDeno();
            this.BindEntryNo();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            if (this.gvMultiPaymentOrderIssueInformation.RowCount < 0)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00107);//At least one record must be exist to save.
                cboEntryNo.Focus();
                return;
            }
            else
            {
                this.Controller.Save();
                
                this.cboEntryNo.SelectedIndex = -1;
                this.Controller.ClearingForm();
               
                this.gvMultiPaymentOrderIssueInformation.DataSource = null;
                this.gvMultiPaymentOrderIssueInformation.Refresh();
            }
        }

        private void cboEntryNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Controller.ClearCustomErrorMessage();
            if (this.TlfEntryNo != string.Empty && cboEntryNo.SelectedIndex != -1)
            {
                this.BindGridData();
                this.Currency = (from x in this.CashDenoList
                                 where x.TlfEntryNo == this.TlfEntryNo
                                 select x.Currency).First().ToString();
            }
        }
        #endregion

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.cboEntryNo.SelectedIndex = -1;
            this.Controller.ClearingForm();
            this.gvMultiPaymentOrderIssueInformation.DataSource = null;
            this.gvMultiPaymentOrderIssueInformation.Refresh();
        }

      
    }
}
