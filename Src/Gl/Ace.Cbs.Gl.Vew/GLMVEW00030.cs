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
using Ace.Cbs.Gl.Ctr.Ptr;
using Ace.Cbs.Gl.Dmd;

namespace Ace.Cbs.Gl.Vew
{
    public partial class GLMVEW00030 : BaseDockingForm, IGLMVEW00023
    {
        

        #region Constructor
        public GLMVEW00030()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        public DateTime StartDate { get; set;  }
        public DateTime EndDate { get; set; }
        public int ProgressBar { get; set;  }
        public bool Progressstatus { get; set;  }
        public string BranchCode { get; set;  }
        public bool IsAllBranch { get; set;  }

        public string DCode
        {
            get { return this.cboBranchCode.Text; }
            set { this.cboBranchCode.Text = value; }
        }

        public string ACODE
        {
            get { return this.txtACode.Text; }
            set { this.txtACode.Text = value; }
        }        

        public string SUBITEM
        {
            get { return this.txtAccountCode.Text; }
            set { this.txtAccountCode.Text = value; }
        }

        public string AccountName
        {
            get { return this.txtAccountName.Text; }
            set { this.txtAccountName.Text = value; }
        }

        public string TYPE
        {
            get { return this.cboAccountType.Text; }
            set { this.cboAccountType.Text = value; }
        }
        public string TITLE
        {
            get { return this.cboTitle.SelectedValue.ToString(); }
            set { this.cboTitle.SelectedValue = value; }
        }

        public string SUBTITLE
        {  //added by SHO [23/Nov/21] want to remove drop down box
           /* get { return this.cboSubTitle.SelectedValue.ToString(); }
            set { this.cboSubTitle.SelectedValue = value; }*/
            get { return this.txtSubTitle.Text; }
            set { this.txtSubTitle.Text = value; }
        }

        public string OtherBankGroupTitle
        {
            get { return this.cboOtherBankGroup.SelectedValue.ToString(); }
            set { this.cboOtherBankGroup.SelectedValue = value; }
        }
        
        #endregion

        #region Variables
        GLMDTO00023 gLMDTO00023 = new GLMDTO00023();
        List<GLMDTO00023> gLMDTO00023lst = new List<GLMDTO00023>();
        List<GLMDTO00023> OtherBankGroupLst = new List<GLMDTO00023>();
        List<GLMDTO00023> SubgLMDTO00023lst = new List<GLMDTO00023>();
        List<GLMDTO00023> SubTitleNamelst = new List<GLMDTO00023>();//Added by HMW (13-12-2022)
        int newTitleOrder = 0;
        int newSubTitleOrder = 0;
        string oldTitleName = "";
        string newTitleName = "";        
        string newSubTitleName = "";
        
        #endregion

        #region Controller
        private IGLMCTL00023 controller;
        public IGLMCTL00023 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                this.controller.ViewData = this;
            }
        }

        private GLMDTO00023 viewData;
        public GLMDTO00023 ViewData
        {
            get
            {
                if (this.viewData == null) this.viewData = new GLMDTO00023();

                this.viewData.ACODE = this.ACODE;//--aaa000
                this.viewData.SUBITEM = this.SUBITEM;
                this.viewData.TYPE = this.TYPE;
                this.viewData.TITLE =( this.txtTitleName.Text.Equals("") ? this.TITLE :this.txtTitleName.Text.Trim());
                this.viewData.SUBTITLE = ( this.txtSubTitleName.Text.Equals("") ? this.SUBTITLE :this.txtSubTitleName.Text.Trim());
                /*
                this.viewData.ITEM = (this.txtTitleName.Text.Equals("") ? (gLMDTO00023lst.Where(x => x.TITLE.Equals(this.TITLE)).Select(x => x.SrNo).FirstOrDefault().ToString()) : (gLMDTO00023lst.Select(x => x.MaxSrNo).FirstOrDefault().ToString())); //--1,2,3//title sno
                this.viewData.SUBITEM_No = (this.txtSubTitleName.Text.Equals("") ? ( Convert.ToInt32(SubgLMDTO00023lst.Where(x => x.SUBTITLE.Equals(this.SUBTITLE)).Select(x => x.SUBITEM_No).FirstOrDefault())) :
                                           SubgLMDTO00023lst.Count > 0 ? (Convert.ToInt32(SubgLMDTO00023lst.Select(x => x.MaxSubSrNo).FirstOrDefault())) : 1); //--1,2,3//subtitle sno
                */                

                //this.BindSubTitle(this.viewData.TITLE);
                //this.viewData.SUBITEM_No = newSubTitleOrder;
                this.viewData.Opening_bal = 0;
                this.viewData.Closing_bal =0;
                this.viewData.Credit_Amount = 0;
                this.viewData.Debit_Amount = 0;
                this.viewData.DCode = this.DCode;
                this.viewData.Active = true;
                this.viewData.OtherBankGroupTitle = (OtherBankGroupLst.Count>0 ?((this.txtOtherBankGroup.Text.Equals("") ? this.OtherBankGroupTitle : this.txtOtherBankGroup.Text.Trim())): null);

                              
                 
                if ((this.txtTitleName.Text!=""))//New Title input >> It is sure that sub title order will be start with 1 whether sub title is new or old.
                {
                    //for (int i = 1; i <= this.gLMDTO00023lst[0].MaxSrNo; i++)
                    for (int i = 0; i < this.gLMDTO00023lst[0].MaxSrNo; i++)
                    {
                        if (txtTitleName.Text.ToString().Trim() == this.gLMDTO00023lst[i].TITLE.ToString().Trim())                            
                        {
                            this.viewData.ITEM = this.gLMDTO00023lst[i].SrNo.ToString();
                            break;
                        }
                        else
                        {
                            this.viewData.ITEM = newTitleOrder.ToString();
                        }
                    } 
                    this.BindSubTitle(this.viewData.TITLE);
                    //this.viewData.ITEM = newTitleOrder.ToString();
                    this.viewData.SUBITEM_No = ((txtTitleName.Text=="Account with other Bank") ? 0 : 1);
                }
                else if (this.txtTitleName.Text=="" && cboTitle.Text.ToString()!="")//Change to another Existing Title
                {
                    this.BindSubTitle(cboTitle.Text.ToString());
                    this.viewData.ITEM = SubTitleNamelst[0].ITEM.ToString();//subtitle of another existing selected title
                    this.viewData.SUBITEM_No = ((cboTitle.Text.ToString() == "Account with other Bank") ? 0 : newSubTitleOrder);
                }              

                return this.viewData;
            }
            set 
            {
                this.viewData = value; 
            }
        }

        #endregion

        #region Method

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.InitializeControl();
        }
        public void Failure(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }

        public void BindAccountType()
        {
            this.cboAccountType.DataSource= Controller.SelectAllAccountType();
            this.cboAccountType.DisplayMember = "AccountType";
            this.cboAccountType.ValueMember = "AccountType";
            this.cboAccountType.SelectedIndex = -1;
        }

        public void BindBranchCode()
        {
            this.cboBranchCode.DataSource = Controller.SelectAllBranchCode();
            this.cboBranchCode.DisplayMember = "BranchCode";
            this.cboBranchCode.ValueMember = "BranchCode";
            this.cboBranchCode.SelectedIndex = -1;
        }

        public void BindTitle(string Type)
        {
            gLMDTO00023lst = Controller.SelectAllTITLE_By_Type(Type).ToList<GLMDTO00023>();
            this.cboTitle.DataSource = gLMDTO00023lst;
            this.cboTitle.DisplayMember = "TITLE";
            this.cboTitle.ValueMember = "TITLE";
            this.cboTitle.SelectedIndex = -1;

            //Added by HMW (13-11-2022)
            if (gLMDTO00023lst.Count <= 1)
                newTitleOrder = 1;
            else
                newTitleOrder = gLMDTO00023lst[0].MaxSrNo + 1;
        }

      /*  public void BindSubTitle(string TITLE)
        {
            SubgLMDTO00023lst = Controller.SelectAllSUBTITLE_by_TITLE(TITLE).ToList<GLMDTO00023>();
            this.cboSubTitle.DataSource = SubgLMDTO00023lst;
            this.cboSubTitle.DisplayMember = "SUBTITLE";
            this.cboSubTitle.ValueMember = "SUBTITLE";
            this.cboSubTitle.SelectedIndex = -1;
        }*/

        public void BindSubTitle(string TITLE)
        {
            SubTitleNamelst = Controller.SelectAllSUBTITLE_by_TITLE(TITLE).ToList<GLMDTO00023>();
                        
            if (SubTitleNamelst.Count <= 1)
                newSubTitleOrder = 1;
            else
                newSubTitleOrder = SubTitleNamelst[0].MaxSubSrNo + 1;
        }
      

        public void BindOtherBankGroupTitle(string ACode)
        {
            OtherBankGroupLst = Controller.SelectAllOtherBankGroupTitle(ACode).ToList<GLMDTO00023>();
            this.cboOtherBankGroup.DataSource = OtherBankGroupLst;
            this.cboOtherBankGroup.DisplayMember = "OtherBankGroupTitle";
            this.cboOtherBankGroup.ValueMember = "OtherBankGroupTitle";
            this.cboOtherBankGroup.SelectedIndex = -1;
            this.cboOtherBankGroup.Text = string.Empty;

            if (OtherBankGroupLst.Count > 0)
            {
                this.cboOtherBankGroup.Enabled = true;
                this.chkOtherBank.Enabled = true;
            }
            else
            {
                this.cboOtherBankGroup.Enabled = false;
                this.chkOtherBank.Enabled = false;
            }
        }

        public void InitializeControl()
        {            
            this.BindBranchCode();
            this.BindAccountType();
            this.BindTitle("");          
            this.BindOtherBankGroupTitle("");         

            this.controller.ClearErrors();
            this.txtAccountCode.Text = string.Empty;
            this.txtAccountName.Text = string.Empty;        
            this.txtTitleName.Text = string.Empty;
            this.txtSubTitle.Text = string.Empty; //added by SHO [23/Nov/21] want to remove drop down box
            this.txtSubTitleName.Text = string.Empty;
            this.txtOtherBankGroup.Text = string.Empty;
            this.cboOtherBankGroup.Text = string.Empty;
            this.cboBranchCode.Text = string.Empty;

            this.chkTitle.Checked = false;           
            this.cboTitle.Enabled = true;
            this.txtTitleName.Visible = false;
            this.txtTitleName.Enabled = false;
            this.chkSubTitle.Checked = false;     
            this.txtSubTitle.Enabled = true;
            this.txtSubTitleName.Visible=false;
            this.txtSubTitleName.Enabled = false;
            this.chkOtherBank.Checked = false;
            this.cboOtherBankGroup.Enabled = true;
            this.txtOtherBankGroup.Visible = false;
            this.txtOtherBankGroup.Enabled = false;
            this.chkOtherBank.Enabled = true;

            this.cboBranchCode.SelectedIndex = -1;
            this.cboAccountType.SelectedIndex = -1;
            this.cboOtherBankGroup.SelectedIndex = -1;

            this.lblNewTitle.Visible = false;
            this.lblNewSubTitle.Visible = false;
            this.lblNewOthBankGroupTitle.Visible = false;

            Cursor.Current = Cursors.Default;
            this.cboBranchCode.Focus();
        }

        private bool CheckRequiredFields()
        {
            if (this.cboBranchCode.Text == string.Empty)
            {
                MessageBox.Show("Please fill Branch Code!", CXUIMessageUtilities.MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboBranchCode.Focus();
                return false;
            }

            if (txtAccountCode.Text.Equals(""))
            {
                MessageBox.Show("Please fill Account Code!", CXUIMessageUtilities.MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtAccountCode.Focus();
                return false;
            }

            if (this.cboAccountType.Text == string.Empty)
            {
                MessageBox.Show("Please fill Account Type!", CXUIMessageUtilities.MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboAccountType.Focus();
                return false;
            }

            if (chkTitle.Checked)
            {

                if (this.txtTitleName.Text == string.Empty)
                {
                    MessageBox.Show("Please fill Title Name!", CXUIMessageUtilities.MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtTitleName.Focus();
                    return false;
                }
            }
            else
            {
                if (this.cboTitle.Text == string.Empty)
                {
                    MessageBox.Show("Please fill Title Name!", CXUIMessageUtilities.MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cboTitle.Focus();
                    return false;
                }
            }

            if (chkSubTitle.Checked)
            {
                if (this.txtSubTitleName.Text == string.Empty)
                {
                    MessageBox.Show("Please fill Sub Title Name!", CXUIMessageUtilities.MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtSubTitleName.Focus();
                    return false;
                }
            }
            else
            {
                if (this.txtSubTitle.Text == string.Empty)
                {
                    MessageBox.Show("Please fill Sub Title Name!", CXUIMessageUtilities.MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtSubTitle.Focus();
                    return false;
                }
            }

            if (OtherBankGroupLst.Count > 0)
            {

                if (chkOtherBank.Checked)
                {
                    if (this.txtOtherBankGroup.Text == string.Empty)
                    {
                        MessageBox.Show("Please fill Other Bank Group Title Name!", CXUIMessageUtilities.MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.txtOtherBankGroup.Focus();
                        return false;
                    }
                }
                else
                {
                    if (this.cboOtherBankGroup.Text == string.Empty)
                    {
                        MessageBox.Show("Please fill Other Bank Group Title Name!", CXUIMessageUtilities.MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.cboOtherBankGroup.Focus();
                        return false;
                    }
                }
            }

            return true;
        }

        #endregion

        #region "ProcessCmdKey"
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (cboBranchCode.Focused && keyData == (Keys.Enter) || cboBranchCode.Focused && keyData == (Keys.Tab))
            {
                txtAccountCode.Focus();
                return true;
            }
            else if (txtAccountCode.Focused && keyData == (Keys.Enter) || txtAccountCode.Focused && keyData == (Keys.Tab))
            {
                if (txtAccountCode.Text == "")
                {
                    MessageBox.Show("Insert Account Code!", CXUIMessageUtilities.MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtAccountCode.Text = string.Empty;
                    this.txtAccountCode.Focus();
                }
                else
                {
                    #region "Clearing all for account replace binding"
                        this.txtTitleName.Text = "";
                        this.txtSubTitleName.Text = "";
                        this.txtOtherBankGroup.Text = "";

                        this.lblNewTitle.Visible = false;
                        this.lblNewSubTitle.Visible = false;
                        this.lblNewOthBankGroupTitle.Visible = false;

                        this.txtTitleName.Visible = false;
                        this.txtSubTitleName.Visible = false;
                        this.txtOtherBankGroup.Visible = false;

                        this.chkTitle.Checked = false;
                        this.chkSubTitle.Checked = false;
                        this.chkOtherBank.Checked = false;
                    #endregion

                    gLMDTO00023 = Controller.SelectAllByAccountCode(txtAccountCode.Text.Trim().ToUpper());
                    if (gLMDTO00023 != null)
                    {
                        this.txtAccountCode.Text = gLMDTO00023.ACode;
                        this.txtAccountName.Text = gLMDTO00023.ACName;
                        this.cboAccountType.Text = gLMDTO00023.TYPE;//Modify by HMW (16-12-2022)
                        this.txtSubTitle.Text = gLMDTO00023.ACName;
                        this.txtACode.Text = gLMDTO00023.HACode;
                        this.BindOtherBankGroupTitle(this.txtAccountCode.Text.Trim());
                        this.cboAccountType.Focus();
                    }
                    else
                    {
                        this.txtAccountCode.Text = "";
                        this.txtAccountName.Text = string.Empty;
                        this.txtSubTitle.Text = string.Empty;
                        MessageBox.Show("Invalid Account Code!", CXUIMessageUtilities.MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.txtAccountCode.Focus();
                    }
                }
                return true;
            }
            else if (txtAccountCode.Focused && keyData == (Keys.Enter) || txtAccountCode.Focused && keyData == (Keys.Tab))
            {
                cboAccountType.Focus();
                return true;
            }
            else if (cboAccountType.Focused && keyData == (Keys.Enter) || cboAccountType.Focused && keyData == (Keys.Tab))
            {
                cboTitle.Focus();
                return true;
            }
            else if (cboTitle.Focused && keyData == (Keys.Enter) || cboTitle.Focused && keyData == (Keys.Tab))
            {
                txtSubTitle.Focus();
                return true;
            }
            else if (txtSubTitle.Focused && keyData == (Keys.Enter) || txtSubTitle.Focused && keyData == (Keys.Tab))
            {
                if (OtherBankGroupLst.Count > 0)  cboOtherBankGroup.Focus();

                return true;
            }

            else
                return base.ProcessCmdKey(ref msg, keyData);

        }
        #endregion

        #region Events

        private void GLMVEW00030_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            this.InitializeControl();
            this.cboBranchCode.Focus();

        }

        private void cboAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {
                this.BindTitle(cboAccountType.Text.Trim());
        }

        private void cboTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.BindSubTitle(this.cboTitle.Text.Trim());
        }

        private void chkTitle_CheckedChanged(object sender, EventArgs e)
        {
            this.txtTitleName.Text = string.Empty;

            if (chkTitle.Checked)
            {
                cboTitle.SelectedIndex = -1;
                cboTitle.Text = string.Empty;
                cboTitle.Enabled = false;

                this.lblNewTitle.Visible = true;
                txtTitleName.Visible = true;
                txtTitleName.Enabled = true;
                txtTitleName.Focus();
            }
            else
            {
                this.lblNewTitle.Visible = false;                
                txtTitleName.Visible = false;
                txtTitleName.Enabled = false;
                cboTitle.Enabled = true;
                cboTitle.Focus();
            }
        }

        private void chkSubTitle_CheckedChanged(object sender, EventArgs e)
        {
            this.txtSubTitleName.Text = string.Empty;

            if (chkSubTitle.Checked )
            {
               // txtSubTitle.SelectedIndex = -1;
                this.lblNewSubTitle.Visible = true;
                txtSubTitle.Text = string.Empty;
                txtSubTitle.Enabled = false;
                txtSubTitleName.Text = txtSubTitle.Text.Trim();

                txtSubTitleName.Visible=true;
                txtSubTitleName.Enabled = true;
                txtSubTitleName.Focus();
            }
            else
            {
                this.lblNewSubTitle.Visible = false;
                txtSubTitle.Enabled = true;
                txtSubTitleName.Visible=false;
                txtSubTitleName.Enabled = false;
                txtSubTitle.Focus();
            }
        }

        private void chkOtherBank_CheckedChanged(object sender, EventArgs e)
        {
            this.txtOtherBankGroup.Text = string.Empty;

            if (chkOtherBank.Checked)
            {
                cboOtherBankGroup.SelectedIndex = -1;
                cboOtherBankGroup.Text = string.Empty;
                cboOtherBankGroup.Enabled = false;

                this.lblNewOthBankGroupTitle.Visible = true;
                txtOtherBankGroup.Visible = true;
                txtOtherBankGroup.Enabled = true;
                txtOtherBankGroup.Focus();
            }
            else
            {
                this.lblNewOthBankGroupTitle.Visible = false;
                cboOtherBankGroup.Enabled = true;
                txtOtherBankGroup.Visible = false;
                txtOtherBankGroup.Enabled = false;
                cboOtherBankGroup.Focus();
            }
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            if (this.CheckRequiredFields())
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure want to Save?", CXUIMessageUtilities.MESSAGE_BOX_TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    this.Controller.Save(sender, e);
                }
                else if (dialogResult == DialogResult.No)
                    cboBranchCode.Focus();

            }
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControl();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
           
    }
}
