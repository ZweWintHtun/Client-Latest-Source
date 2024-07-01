using System;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00047 : BaseForm, IMNMVEW00047
    {
        public MNMVEW00047()
        {
            InitializeComponent();
        }

        public string AcSign { get; set; }
        private string formName = string.Empty;
        IList<PFMDTO00001> balConfirmList { get; set; }


        #region Properties

        #region controller
        private IMNMCTL00047 currentCompanyController;
        public IMNMCTL00047 Controller
        {
            get
            {
                return this.currentCompanyController;
            }
            set
            {
                this.currentCompanyController = value;
                this.currentCompanyController.View = this;
            }
        }
        #endregion

        public string FormName
        {
            get { return this.formName; }
            set { this.formName = value; }
        }
        public string AccountNumber 
        {
            get { return this.mtxtAccountNo.Text.Replace("-","").Trim(); }
            set { this.mtxtAccountNo.Text = value; }
        }
        public string AccountType
        {
            get;
            set;
        }

       
        public DateTime Date_time
        {
            get
            {
                return this.dtpDate.Value;
            }
            set
            {               
                this.dtpDate.Text=value.ToString();
            }      

        }


        #endregion

        #region Events

        private void MNMVEW00047_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.Text = "Balance Confirmation " + this.FormName + " Listing";
            this.Date_time = DateTime.Now;
            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            /*Get Date Format*/
            CXCOM00006.Instance.GetDateFormat(this.Date_time);
            this.grpFrame.Text = this.formName;
            if (this.FormName.Contains("Specific"))
            {
                this.gvBalanceConfirmation.Visible = false;
                this.lblSelectedAC.Visible = false;
                this.lblSelectedACDesc.Visible = false;
                this.lblTotalAC.Visible = false;
                this.lblTotalACDesc.Visible = false;
                this.Size = new System.Drawing.Size(570, 155);
                this.grpFrame.Size = new System.Drawing.Size(540, 81);
            }

            else if (this.FormName.Contains("All"))
            {
                this.gvBalanceConfirmation.Visible = true;
                this.mtxtAccountNo.Visible = false;
                this.lblAccountNo.Visible = false;
                this.lblRequiredDate.Location = new System.Drawing.Point(29, 73);
                this.dtpDate.Location = new System.Drawing.Point(135, 70);
            }
        }

        private void BalanceConfirmation_DataBind()
        {
            gvBalanceConfirmation.AutoGenerateColumns = false;
            this.balConfirmList = this.Controller.SelectInfo(this.formName);
            this.gvBalanceConfirmation.DataSource = this.balConfirmList;
            this.lblTotalAC.Text = gvBalanceConfirmation.RowCount.ToString(); 
        }

        /*To Bind Grid View,when user enters EnterKey or TabKey*/
        private void dtpDate_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Keys)e.KeyCode == Keys.Enter || (Keys)e.KeyCode == Keys.Tab)
            {
                if (this.Date_time.Date > DateTime.Now.Date)
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00160, this.Date_time.ToString("dd/MM/yyyy"));//Datetime cannot be greater than today date.
                    return;
                }

                this.BalanceConfirmation_DataBind();
            }
        }
        
        #region rsb Events

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            if (dtpDate.Value.Date > DateTime.Now.Date)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00160, this.dtpDate.Value.ToString("dd/MM/yyyy"));//Datetime cannot be greater than today date.
                this.dtpDate.Focus();
                return;
            }
            if (this.gvBalanceConfirmation.RowCount <= 0 && this.Text.Contains("All"))
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00171); //Grid Record must has at least one.
                this.dtpDate.Focus();
                return;
            }

            else if (this.Controller.accountinfo!= null)
            {
                string cur = this.Controller.SelectCurrencyByAccountNo(this.Controller.accountinfo.AccountNo);
                this.Controller.accountinfo.CurrencyCode = cur;
                this.Controller.accountinfo.DATE_TIME = DateTime.Now;
                if (this.Controller.accountinfo.IsCheck == true)
                    CXUIScreenTransit.Transit("frmMNMVEW00095BalanceConfirmationReprot", true, new object[] { this.Controller.accountinfo, this.formName });
                else Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME00054); //AccountNo not found in Cledger Table.
            }

            else
            {
                IList<PFMDTO00001> custlist = this.balConfirmList.Where<PFMDTO00001>(x => x.IsCheck == true).ToList();

                if (custlist.Count.Equals(0))
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90012);/* Please select at least one record.. */
                }
                else
                {

                    foreach (PFMDTO00001 custdto in custlist)
                    {
                        string cur = this.Controller.SelectCurrencyByAccountNo(custdto.AccountNo);
                        custdto.CurrencyCode = cur;
                        custdto.DATE_TIME = DateTime.Now;
                        CXUIScreenTransit.Transit("frmMNMVEW00095BalanceConfirmationReprot", true, new object[] { custdto, this.formName});
                    }
                }
            }
            
        }

        private int GetSelectedCount()
        {
            int count = 0;
            this.lblSelectedAC.Text = "";
            for (int i = 0; i < gvBalanceConfirmation.RowCount - 1; i++)
            {
                if (gvBalanceConfirmation.Rows[i].Cells[2].Value != null)
                {
                    bool value = Convert.ToBoolean(gvBalanceConfirmation.Rows[i].Cells[2].Value);
                    if (value)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        private void gvBalanceConfirmation_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int SelectCount = this.GetSelectedCount();
            this.lblSelectedAC.Text = SelectCount.ToString();
        }

        private void gvBalanceConfirmation_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (gvBalanceConfirmation.IsCurrentCellDirty)
            {
                gvBalanceConfirmation.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.mtxtAccountNo.Text = string.Empty;
            this.dtpDate.Text = DateTime.Now.ToString();
            this.gvBalanceConfirmation.DataSource = null;
            this.lblTotalAC.Text = "               0";
            this.lblSelectedAC.Text = "               0";
        }

        #endregion

        private void MNMVEW00047_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }

        #endregion

       
     
    }
}
