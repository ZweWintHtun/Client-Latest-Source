using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00139 : BaseForm,IMNMVEW00139 
    {
        #region Data Properties

        public string TlfEntryNo
        {
            get { return this.txtEntryNo.Text; }
            set { this.txtEntryNo.Text = value; }
        }

        public string AccountType
        {
            get { return this.txtAccountType.Text; }
            set { this.txtAccountType.Text = value; }
        }

        public decimal MultiAmount
        {
            get
            {
                decimal result = 0;
                decimal.TryParse(this.txtMultiAmount.Text, out result);
                return Math.Round(result, 2);
            }
            set { this.txtMultiAmount.Text = value.ToString(); }
        }

        public string CustomerName
        {
            get { return this.txtName.Text; }
            set { this.txtName.Text = value; }
        }

        public string NRC
        {
            get { return this.txtNRCNo.Text; }
            set { this.txtNRCNo.Text = value; }
        }

        public string Narration
        {
            get { return this.txtNarration.Text; }
            set { this.txtNarration.Text = value; }
        }

        public decimal IndividualAmount
        {
            get
            {
                decimal result = 0;
                decimal.TryParse(this.txtIndividualAmount.Text, out result);
                return Math.Round(result, 2);
            }
            set { this.txtIndividualAmount.Text = value.ToString(); }
        }

        #endregion

        #region Controller
        private IMNMCTL00139 _controller;
        public IMNMCTL00139 Controller
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
        #endregion

        #region Constructor

        public MNMVEW00139()
        {
            InitializeComponent();
        }
        #endregion

        #region Variable
        public bool IsMulti { get; set; }
        #endregion

        #region Methods 

        public void BindGridView(IList<PFMDTO00001> informationlist)
        {
            this.gvCashDenoEditInformation.AutoGenerateColumns = false;
            this.gvCashDenoEditInformation.DataSource = null;
            this.gvCashDenoEditInformation.Refresh();
            this.gvCashDenoEditInformation.DataSource = informationlist;
        }

        public void MessageShow(string messagecode)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(messagecode);
        }

        /// <summary>
        /// To Hide Some Column of GridView when AccountNos is not Customer AccountNumbers
        /// </summary>
        public void MultiNonCustomerGridChange(bool enable)
        {
            this.colName.Visible = enable;
            this.colNRC.Visible = enable;
        }

        public void FocusTlfEntryTextBox()
        {
            this.txtEntryNo.Focus();
        }
        #endregion

        #region Events
        private void MNMVEW00139_Load(object sender, EventArgs e)
        {
            #region Old_Logic
            /*
            this.tsbCRUD.ButtonEnableDisabled(false, true, false, false, true, false, true);
            if (this.FormName.Equals("CashDenoEdit.Indi"))
            {
                this.Text = "Denomination Edit (Individual)";
                this.gvCashDenoEditInformation.Visible = false;
                this.txtMultiAmount.Visible = false;
                this.IsMulti = false;
                this.Size = new System.Drawing.Size(619, 195);
                this.grpFrame.Visible = true;
            }
            else
            {
                this.Text = "Denomination Edit (Multiple Transaction)";
                this.lblAccountType.Text = "Amount:";
                this.lblEntryNo.Text = "Group No:";
                this.txtAccountType.Visible = false;
                this.gvCashDenoEditInformation.Visible = true;
                this.lblName.Visible = false;
                this.lblNarration.Visible = false;
                this.lblNRCNo.Visible = false;
                this.lblAmount.Visible = false;
                this.txtIndividualAmount.Visible = false;
                this.txtName.Visible = false;
                this.txtNarration.Visible = false;
                this.txtNRCNo.Visible = false;
                this.grpFrame.Visible = false;
                this.IsMulti = true;
            }
            */
            #endregion

            //Modified by HMW at 13-Aug-2019 : No Permission before back date EOD is successfully finished
            DateTime systemDate = this.Controller.GetSystemDate(CurrentUserEntity.BranchCode);
            this.lblTransactionDate.Text = systemDate.ToString("dd-MM-yyyy");
            
            this.tsbCRUD.ButtonEnableDisabled(false, true, false, false, true, false, true);
            if (this.FormName.Equals("CashDenoEdit.Indi")) //Cash Deno Edit (Individual)
            {
                this.Text = "Denomination Edit (Individual)";
                this.gvCashDenoEditInformation.Visible = false;
                this.txtMultiAmount.Visible = false;
                this.IsMulti = false;
                this.Size = new System.Drawing.Size(619, 250);
                this.grpFrame.Visible = true;

                if (systemDate.ToString("dd-MM-yyyy") != DateTime.Now.ToString("dd-MM-yyyy")) //Don't show the form when "Back Date EOD" is not finished
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI50013);//You have no permission.\n"Back Date EOD Process" needs to be completed!
                    this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
                    this.DisableControls("DenoEditIndividual.AllDisable");
                }                
            }
            else //Cash Deno Edit (Multiple)
            {
                this.Text = "Denomination Edit (Multiple Transaction)";
                this.lblAccountType.Text = "Amount:";
                this.lblEntryNo.Text = "Group No:";
                this.txtAccountType.Visible = false;
                this.gvCashDenoEditInformation.Visible = true;
                this.lblName.Visible = false;
                this.lblNarration.Visible = false;
                this.lblNRCNo.Visible = false;
                this.lblAmount.Visible = false;
                this.txtIndividualAmount.Visible = false;
                this.txtName.Visible = false;
                this.txtNarration.Visible = false;
                this.txtNRCNo.Visible = false;
                this.grpFrame.Visible = false;
                this.IsMulti = true;

                if (systemDate.ToString("dd-MM-yyyy") != DateTime.Now.ToString("dd-MM-yyyy")) //Don't show the form when "Back Date EOD" is not finished
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI50013);//You have no permission.\n"Back Date EOD Process" needs to be completed!
                    this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
                    this.DisableControls("DenoEditMultiple.AllDisable"); 
                }             
            }
        }  
        

        private void tsbCRUD_EditButtonClick(object sender, EventArgs e)
        {
            if (this.TlfEntryNo == null || this.TlfEntryNo == string.Empty)
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90027);    //Invalid Register No.
                this.txtEntryNo.Focus();
            }

            else
            {
                this.Controller.Update();
            }
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.Controller.CleanUIControlData();
            this.Controller.ClearErrors();
            this.txtEntryNo.Enabled = true;
            this.FocusTlfEntryTextBox();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void MNMVEW00139_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }

    }
}
