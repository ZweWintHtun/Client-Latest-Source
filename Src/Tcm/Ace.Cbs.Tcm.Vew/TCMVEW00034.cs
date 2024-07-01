using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
    public partial class TCMVEW00034 : BaseForm , ITCMVEW00034
    {
        #region Constructors
        public TCMVEW00034()
        {
            InitializeComponent();
        }
        #endregion

        #region UI DataProperties

        public DateTime StartDateTime
        {
            get { return this.dtpStartDate.Value; }
            set { this.dtpStartDate.Text = value.ToString(); }
        }

        public DateTime EndDateTime
        {
            get { return this.dtpEndDate.Value; }
            set { this.dtpEndDate.Text = value.ToString(); }
        }

        private ITCMCTL00034 _controller;
        public ITCMCTL00034 Controller
        {
            get { return this._controller; }
            set
            {
                this._controller = value;
                this._controller.View = this;
            }
        }

        public string TransactionStatus { get; set; }
        #endregion

        #region Methods



        #endregion

        #region Events
        private void TCMVEW00034_Load(object sender, EventArgs e)
        {
            // Button Enable Disabled
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);

            if (this.FormName.Equals("Receipt"))
            {
                this.TransactionStatus = "Receipt";
                this.Text = "Clearing Paid Cheque Listing";
            }
            else
            {
                this.TransactionStatus = "POReceipt";
                this.Text = "Listing for Clearing with PO Receipt";
            }
            this.dtpStartDate.Text = DateTime.Now.ToShortDateString();
            this.dtpEndDate.Text = DateTime.Now.ToShortDateString();
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            if (CXCOM00006.Instance.IsExceedTodayDate(this.dtpStartDate.Value))
            {
                CXUIMessageUtilities.ShowMessageByCode("MV00129");//Start Date must not be greater than today.
            }
            else if (CXCOM00006.Instance.IsExceedTodayDate(this.dtpEndDate.Value))
            {
                CXUIMessageUtilities.ShowMessageByCode("MV00130");//End Date must not be greater than today.
            }
            else if (this.dtpStartDate.Value > this.dtpEndDate.Value)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV00131");//Start Date must not be greater than End Date.
            }
            else
            {
                this.Controller.Print();
            }
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.dtpStartDate.Text = DateTime.Now.ToShortDateString();
            this.dtpEndDate.Text = DateTime.Now.ToShortDateString();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
