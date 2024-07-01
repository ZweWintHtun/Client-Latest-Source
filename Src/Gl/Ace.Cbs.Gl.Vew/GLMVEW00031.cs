using System;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Gl.Dmd;
using Ace.Cbs.Gl.Ctr.Ptr;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Utt;//Added by HMW (8-12-2022)

namespace Ace.Cbs.Gl.Vew
{
    public partial class GLMVEW00031 : BaseDockingForm, IGLMVEW00023
    {
        #region Constructor
        public GLMVEW00031()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ProgressBar { get; set; }
        public bool Progressstatus { get; set; }
        public string BranchCode { get; set; }
        public bool IsAllBranch { get; set; }

        public string DCode
        {
            get { return this.cboBranchCode.Text; }
            set { this.cboBranchCode.Text = value; }
        }

        /*
        public string ACODE
        {
            get { return this.txtACode.Text; }
            set { this.txtACode.Text = value; }
        }
        */

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
            get { return this.txtAccountType.Text; }
            set { this.txtAccountType.Text = value; }
        }
        public string TITLE
        {
            //get { return this.cboTitle.SelectedValue.ToString(); }
            get { return this.cboTitle.Text.ToString(); }
            set { this.cboTitle.SelectedValue = value; }
        }

        public string SUBTITLE
        {
           /* get { return this.cboSubTitle.SelectedValue.ToString(); }
            set { this.cboSubTitle.SelectedValue = value; }*/
            get { return this.txtSubTitle.Text; }
            set { this.txtSubTitle.Text = value; }
        }

        public string OtherBankGroupTitle
        {
            get { return this.cboOtherBankGroup.SelectedValue == null ? "" : this.cboOtherBankGroup.SelectedValue.ToString(); }
            set { this.cboOtherBankGroup.SelectedValue = value; }
        }

        #endregion

        #region Variables
        GLMDTO00023 gLMDTO00023 = new GLMDTO00023();
        List<GLMDTO00023> gLMDTO00023lst = new List<GLMDTO00023>();
        List<GLMDTO00023> OtherBankGroupLst = new List<GLMDTO00023>();
        List<GLMDTO00023> SubTitleNamelst = new List<GLMDTO00023>();
        List<GLMDTO00023> SubgLMDTO00023lst = new List<GLMDTO00023>();
        int newTitleOrder = 0;
        int newSubTitleOrder = 0;
        string oldTitleName = "";
        string newTitleName = "";
        string oldSubTitleName = "";
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

                //this.viewData.ACODE = this.ACODE;//--aaa000
                this.viewData.SUBITEM = this.SUBITEM;
                this.viewData.TYPE = this.TYPE;
                this.viewData.TITLE = (this.txtTitleName.Text.Equals("") ? this.TITLE : this.txtTitleName.Text.Trim());
                this.viewData.SUBTITLE = (this.txtSubTitleName.Text.Equals("") ? this.SUBTITLE : this.txtSubTitleName.Text.Trim());
                
                this.viewData.ITEM = gLMDTO00023lst.Where(x => x.TITLE.Equals(this.TITLE)).Select(x => x.SrNo).FirstOrDefault().ToString(); //--1,2,3//title sno
                //this.viewData.SUBITEM_No = Convert.ToInt32(SubgLMDTO00023lst.Where(x => x.SUBTITLE.Equals(this.SUBTITLE)).Select(x => x.SUBITEM_No).FirstOrDefault());  //--1,2,3//subtitle sno

                if (OtherBankGroupLst.Count > 0)//For other bank account : there is no sub titile order. It can order by "Other Bank Group Title" ascending.
                {
                    this.viewData.OtherBankGroupTitle = (OtherBankGroupLst.Count > 0 ? ((this.txtOtherBankGroup.Text.Equals("") ? this.OtherBankGroupTitle : this.txtOtherBankGroup.Text.Trim())) : null);                    
                }
                
                newTitleName = txtTitleName.Text.Trim();
                newSubTitleName = txtSubTitleName.Text.Trim();

                foreach (DataGridViewRow dgvr1 in gvTitleOrder.Rows)
                {
                    if (dgvr1.Cells["colTitleName"].Value.ToString() == this.cboTitle.Text.ToString())// oldTitleName)
                    {
                        if ((newTitleName != "" && oldTitleName != newTitleName))//New Title input >> It is sure that sub title order will be start with 1 whether sub title is new or old.
                        {
                            this.viewData.ITEM = newTitleOrder.ToString();
                            this.viewData.SUBITEM_No = ((newTitleName == "Account with other Bank") ? 0 : 1);
                        }
                        else if (oldTitleName != cboTitle.Text.ToString())//Change to another Existing Title
                        {
                            this.viewData.ITEM = dgvr1.Cells["colNewOrder"].Value.ToString();

                            this.BindSubTitle(cboTitle.Text.ToString());
                            this.viewData.SUBITEM_No = ((newTitleName == "Account with other Bank") ? 0 : newSubTitleOrder);
                        }
                        else//No title change (Old Title will use)
                        {
                            this.viewData.ITEM = dgvr1.Cells["colNewOrder"].Value.ToString();

                            if (this.viewData.SUBTITLE != oldSubTitleName && newSubTitleName != "" && oldSubTitleName != newSubTitleName)//New Sub Title input                            
                                this.viewData.SUBITEM_No = ((newTitleName == "Account with other Bank") ? 0 : newSubTitleOrder);//Set Next Sub Title No (max no + 1)                            

                            else// Existing Title & Existing Sub Title
                            {
                                foreach (DataGridViewRow Subdgvr1 in gvSubTitleOrder.Rows)
                                {
                                    if (oldTitleName == "Account with other Bank")
                                    {
                                        this.viewData.SUBITEM_No=0;                                        
                                    }
                                    else if (Subdgvr1.Cells["colCOAName"].Value.ToString() == oldSubTitleName)
                                        this.viewData.SUBITEM_No = Convert.ToInt32(Subdgvr1.Cells["colCOANewOrder"].Value.ToString());
                                }
                            }
                        }
                    }
                }               

                this.viewData.DCode = this.DCode;
                this.viewData.Active = true;                

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

            //Added by HMW (24-11-2022) : For Deleteing issue in "Monthly Report Setup Edit" (Wrong data select logic from COA)
            this.cboTitle.Text = gLMDTO00023.TITLE;
            oldTitleName = gLMDTO00023.TITLE;
            if(gLMDTO00023lst.Count<=1)
                newTitleOrder = 1;
            else
                newTitleOrder = gLMDTO00023lst[0].MaxSrNo+1;
        }
        //removed by SHO [23/Nov/21] want to remove drop down box
       /* public void BindSubTitle(string TITLE)
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

            oldSubTitleName = gLMDTO00023.SUBTITLE;
            if(SubTitleNamelst.Count<=1)
                newSubTitleOrder = 1;
            else
                newSubTitleOrder = SubTitleNamelst[0].MaxSubSrNo+1;
        }

        public void BindOtherBankGroupTitle(string ACode)
        {
            OtherBankGroupLst = Controller.SelectAllOtherBankGroupTitle(ACode).ToList<GLMDTO00023>();
            this.cboOtherBankGroup.DataSource = OtherBankGroupLst;
            this.cboOtherBankGroup.DisplayMember = "OtherBankGroupTitle";
            this.cboOtherBankGroup.ValueMember = "OtherBankGroupTitle";
            this.cboOtherBankGroup.SelectedIndex = -1;
            if (gLMDTO00023.OtherBankGroupTitle != "" || gLMDTO00023.OtherBankGroupTitle != null)
                this.cboOtherBankGroup.Text = gLMDTO00023.OtherBankGroupTitle;//Added by HMW (24-11-2022) : For Deleteing issue in "Monthly Report Setup Edit" (Wrong data select logic from COA)

            if (OtherBankGroupLst.Count > 0)
            {
                this.cboOtherBankGroup.Enabled = true;
                this.chkOtherBank.Enabled = true;
                
                this.lblOtherBankGroupTitle.Visible = true;
                this.cboOtherBankGroup.Visible = true;
                this.chkOtherBank.Visible = true;                
                this.lblOtherBankOrderAlert.Visible = true;

                this.lblSubTitleOrder.Visible = false;
                this.gvSubTitleOrder.Visible = false;
            }
            else
            {
                this.cboOtherBankGroup.Enabled = false;                
                this.chkOtherBank.Enabled = false;

                //Added by HMW (28-11-2022)
                this.lblOtherBankGroupTitle.Visible = false;
                this.cboOtherBankGroup.Visible = false;                
                this.chkOtherBank.Visible = false;
                this.txtOtherBankGroup.Visible = false;
                this.lblOtherBankOrderAlert.Visible = false;
                this.lblSubTitleOrder.Visible = true;
                this.gvSubTitleOrder.Visible = true;
            }
        }

        public void InitializeControl()
        {
            this.BindBranchCode();
            this.BindTitle("");
            //this.BindSubTitle("");
            this.BindOtherBankGroupTitle("");

            this.controller.ClearErrors();
            this.txtAccountCode.Text = string.Empty;
            this.txtAccountName.Text = string.Empty;
            this.txtTitleName.Text = string.Empty;            
            this.txtSubTitleName.Text = string.Empty;
            this.txtOtherBankGroup.Text = string.Empty;
            this.cboOtherBankGroup.Text = string.Empty;
            this.cboBranchCode.Text = string.Empty;
            this.cboTitle.Text = string.Empty;
            this.txtSubTitle.Text = string.Empty;
            this.txtAccountType.Text = string.Empty;

            this.chkTitle.Checked = false;
            //this.cboTitle.Enabled = true;
            this.txtTitleName.Visible = false;            
            this.txtTitleName.Enabled = false;
            this.chkSubTitle.Checked = false;
            //this.cboSubTitle.Enabled = true;
            this.txtSubTitleName.Visible = false;
            this.txtSubTitleName.Enabled = false;
            this.chkOtherBank.Checked = false;
            this.cboOtherBankGroup.Enabled = true;
            this.txtOtherBankGroup.Visible = false;
            this.txtOtherBankGroup.Enabled = false;
            this.chkOtherBank.Enabled = true;

            this.cboBranchCode.SelectedIndex = -1;
            this.cboTitle.SelectedIndex = -1;
            //this.txtSubTitle.DataSource = null;
            this.cboOtherBankGroup.SelectedIndex = -1;
            this.gvTitleOrder.DataSource = null;
            this.gvTitleOrder.Refresh();
            this.gvSubTitleOrder.DataSource = null;
            this.gvSubTitleOrder.Refresh();
            
            this.lblNewTitle.Visible = false;
            this.lblNewSubTitle.Visible = false;
            this.lblNewOthBankGroupTitle.Visible = false;
            
            this.lblOtherBankOrderAlert.Visible = false;

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

            if (gvTitleOrder.RowCount > 0)
            {
                for (int i = 0; i < gvTitleOrder.RowCount; i++)
                {
                    int _found = 0;
                    int NewTSNo= Convert.ToInt32(gvTitleOrder.Rows[i].Cells[2].Value);

                    for (int k = 0; k < gvTitleOrder.RowCount; k++)
                    {
                        int NewSNo = Convert.ToInt32(gvTitleOrder.Rows[k].Cells[2].Value);

                        if (i != k)
                        {
                            if (NewTSNo == NewSNo)
                            {
                                gvTitleOrder.ClearSelection();
                                gvTitleOrder.CurrentCell = null;
                                MessageBox.Show("Title Name's New Order No. is Duplicate", CXUIMessageUtilities.MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                this.gvTitleOrder.Rows[k].Cells[2].Selected = true;
                                this.gvTitleOrder.Rows[k].Cells[2].ToolTipText = "Duplicate Title Order!";
                                return false;
                            }                            
                        }

                        if (i + 1 == NewSNo) _found += 1;                 
                    }

                    if (_found == 0)
                    {
                        gvTitleOrder.ClearSelection();
                        gvTitleOrder.CurrentCell = null;
                        MessageBox.Show("Title Name's New Order No. " + (i + 1).ToString() + " is lost!", CXUIMessageUtilities.MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }               
            }

            if (gLMDTO00023.TITLE != "Account with other Bank" && gvSubTitleOrder.RowCount > 0)//Modify by HMW (07-12-2022)
            {
                for (int i = 0; i < gvSubTitleOrder.RowCount; i++)
                {
                    int _Sfound = 0;
                    int SNewTSNo = Convert.ToInt32(gvSubTitleOrder.Rows[i].Cells[2].Value);

                    for (int k = 0; k < gvSubTitleOrder.RowCount; k++)
                    {
                        int SNewSNo = Convert.ToInt32(gvSubTitleOrder.Rows[k].Cells[2].Value);

                        if (i != k)
                        {
                            if (SNewTSNo == SNewSNo)
                            {
                                gvSubTitleOrder.ClearSelection();
                                gvSubTitleOrder.CurrentCell = null;
                                MessageBox.Show("SubTitle Name's New Order No. is Duplicate!", CXUIMessageUtilities.MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                this.gvSubTitleOrder.Rows[k].Cells[2].Selected = true;
                                this.gvSubTitleOrder.Rows[k].Cells[2].ToolTipText = "Duplicate SubTitle Order!";
                                return false;
                            }
                        }

                        if (i + 1 == SNewSNo) _Sfound += 1;
                    }

                    if (_Sfound == 0)
                    {
                        gvSubTitleOrder.ClearSelection();
                        gvSubTitleOrder.CurrentCell = null;
                        MessageBox.Show("SubTitle Name's New Order No. " + (i + 1).ToString() + " is lost!", CXUIMessageUtilities.MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }

            return true;
        }

        private bool CheckRequiredFields_ForDelete()
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


            if (this.cboTitle.Text == string.Empty)
            {
                MessageBox.Show("Please fill Title Name!", CXUIMessageUtilities.MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cboTitle.Focus();
                return false;
            }           

            
            if (this.txtSubTitle.Text == string.Empty)
            {
                MessageBox.Show("Please fill Sub Title Name!", CXUIMessageUtilities.MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtSubTitle.Focus();
                return false;
            }

            return true;
        }

        private List<GLMDTO00023> ItemOrderCollection()
        {
            List<GLMDTO00023> collection = new List<GLMDTO00023>();
            
            
            foreach (DataGridViewRow dgvr in gvTitleOrder.Rows)
            {                
                if ((Convert.ToString(dgvr.Cells["colTitleName"].Value) != "") && (dgvr.Cells["colTitleName"].Value != null))
                {
                    GLMDTO00023 GLMDTO00023 = new GLMDTO00023();                    
                   
                    GLMDTO00023.DCode = DCode;
                    GLMDTO00023.Active = true;
                    GLMDTO00023.TYPE = txtAccountType.Text.Trim();
                    GLMDTO00023.TITLE = dgvr.Cells["colTitleName"].Value.ToString();
                    GLMDTO00023.ITEM = dgvr.Cells["colNewOrder"].Value.ToString();

                    /*
                    //Setting the title order(max +1) when the new title input
                    newTitleName = txtTitleName.Text.Trim();
                    
                    if (dgvr.Cells["colTitleName"].Value.ToString() == oldTitleName && newTitleName != "" && oldTitleName != newTitleName)//New Title input                    {
                    {
                        //GLMDTO00023.TITLE = newTitleName;
                        GLMDTO00023.ITEM = (newTitleOrder + 1).ToString();                        
                    }
                    else
                    {
                        GLMDTO00023.TITLE = dgvr.Cells["colTitleName"].Value.ToString();
                        GLMDTO00023.ITEM = dgvr.Cells["colNewOrder"].Value.ToString();
                    }
                    */

                    collection.Add(GLMDTO00023);
                }
            }

            return collection;
        }

        private List<GLMDTO00023> SubItemOrderCollection()
        {
            List<GLMDTO00023> subcollection = new List<GLMDTO00023>();
            int curOrder;

            foreach (DataGridViewRow dgvr in gvSubTitleOrder.Rows)
            {
                if ((Convert.ToString(dgvr.Cells["colCOAName"].Value) != "") && (dgvr.Cells["colCOAName"].Value != null))
                {
                    GLMDTO00023 SGLMDTO00023 = new GLMDTO00023();
                    curOrder = Int32.Parse(dgvr.Cells["colCOANewOrder"].Value.ToString());

                    SGLMDTO00023.DCode = DCode;
                    SGLMDTO00023.Active = true;                    
                    SGLMDTO00023.TYPE = txtAccountType.Text.Trim();                    
                    SGLMDTO00023.SUBTITLE = dgvr.Cells["colCOAName"].Value.ToString();                    
                    SGLMDTO00023.SUBITEM_No = Convert.ToInt32(dgvr.Cells["colCOANewOrder"].Value);

                    SGLMDTO00023.TITLE = cboTitle.Text.Trim(); //Added by HMW 

                    /*
                    //Setting the sub title order(max +1) when the new sub title input
                    newSubTitleName = txtSubTitleName.Text.Trim();
                    if (dgvr.Cells["colCOAName"].Value.ToString() == oldSubTitleName && newSubTitleName != "" && oldSubTitleName != newSubTitleName)//New Sub Title input                    {
                    {   
                        SGLMDTO00023.TITLE = txtTitleName.Text.Trim();
                        
                        SGLMDTO00023.SUBITEM_No = newSubTitleOrder; // 1 (or) something
                    }
                    else
                    {                        
                        SGLMDTO00023.SUBITEM_No = Convert.ToInt32(dgvr.Cells["colCOANewOrder"].Value);
                    }
                    */
                    subcollection.Add(SGLMDTO00023);                   
                }
            }

            return subcollection;
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
                if (this.cboBranchCode.Text == string.Empty)//Added by HMW (8-12-2022)
                {
                    MessageBox.Show("Please fill Branch Code!", CXUIMessageUtilities.MESSAGE_BOX_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.cboBranchCode.Focus();
                    return false;
                }

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
                        this.lblNewOthBankGroupTitle.Visible= false;

                        this.txtTitleName.Visible = false;                        
                        this.txtSubTitleName.Visible = false;                        
                        this.txtOtherBankGroup.Visible = false;                        

                        this.chkTitle.Checked = false;
                        this.chkSubTitle.Checked = false;
                        this.chkOtherBank.Checked = false;
                    #endregion

                    //gLMDTO00023 = Controller.SelectAllByAccountCode(txtAccountCode.Text.Trim().ToUpper());

                    gLMDTO00023 = Controller.SelectAllMonthlyCOAByAccountCode(txtAccountCode.Text.Trim().ToUpper());                    
                    if (gLMDTO00023 != null)
                    {
                        this.txtAccountCode.Text = gLMDTO00023.ACode;
                        this.txtAccountName.Text = gLMDTO00023.ACName;
                        //this.txtACode.Text = gLMDTO00023.HACode;//Comment by HMW (28-11-2022) : No need control & remove control
                        this.txtAccountType.Text = gLMDTO00023.TYPE.Trim();
                        this.txtSubTitle.Text = gLMDTO00023.SUBTITLE; //Updated by HMW (24-11-2022) : For Deleteing issue in "Monthly Report Setup Edit" (Wrong data select logic from COA)
                        
                        this.BindOtherBankGroupTitle(this.txtAccountCode.Text.Trim());
                        this.BindTitle(gLMDTO00023.TYPE.Trim());                        
                        
                        this.gvTitleOrder.DataSource = null;
                        this.gvTitleOrder.AutoGenerateColumns = false;
                        this.gvTitleOrder.DataSource = Controller.SelectAllTITLE_By_Type(gLMDTO00023.TYPE.Trim());
                        this.gvTitleOrder.Refresh();

                        this.gvSubTitleOrder.DataSource = null;
                        this.gvSubTitleOrder.AutoGenerateColumns = false;

                        //Added by HMW (25-11-2022) : For Deleteing issue in "Monthly Report Setup Edit" (Wrong data select logic from COA)
                        if (gLMDTO00023.TITLE != "Account with other Bank")// It is no need sub title order. It can order by "OtherBankGroupTitle" col naming ascending.
                        {
                            //this.gvSubTitleOrder.DataSource = Controller.SelectAllSUBTITLE_by_TITLE(gLMDTO00023.TITLE.Trim());

                            SubTitleNamelst = Controller.SelectAllSUBTITLE_by_TITLE(gLMDTO00023.TITLE.Trim()).ToList<GLMDTO00023>();
                            this.BindSubTitle(gLMDTO00023.TITLE.Trim());

                            if (SubTitleNamelst.Count > 0)
                                this.gvSubTitleOrder.DataSource = SubTitleNamelst;

                        }
                        else
                        {
                            this.gvSubTitleOrder.DataSource = null;
                            this.gvSubTitleOrder.AutoGenerateColumns = false;
                            this.gvSubTitleOrder.Refresh();
                            OtherBankGroupLst = Controller.SelectAllOtherBankGroupTitle(gLMDTO00023.ACode).ToList<GLMDTO00023>();

                        }
                        this.gvSubTitleOrder.Refresh(); 
                        this.cboTitle.Focus();                        
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
                if (OtherBankGroupLst.Count > 0) cboOtherBankGroup.Focus();

                return true;
            }

            else
                return base.ProcessCmdKey(ref msg, keyData);

        }
        #endregion

        #region Events
        private void GLMVEW00031_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, true, true, true, false, true);
            this.InitializeControl();
            this.cboBranchCode.Focus();
        }

        /*
        private void cboTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindSubTitle(this.cboTitle.Text.Trim());
        }
        */
        

        private void chkTitle_CheckedChanged(object sender, EventArgs e)
        {
            this.txtTitleName.Text = string.Empty;

            if (chkTitle.Checked)
            {
                //cboTitle.SelectedIndex = -1;
                //cboTitle.Text = string.Empty;
                //cboTitle.Enabled = false;

                this.lblNewTitle.Visible = true;
                //lblNewTitle.Visible = true;
                txtTitleName.Visible = true;
                txtTitleName.Enabled = true;
                txtTitleName.Text = cboTitle.Text.Trim();
                txtTitleName.Focus();
            }
            else
            {
                cboTitle.Enabled = true;
                this.lblNewTitle.Visible = false;
                //lblNewTitle.Visible = false;
                txtTitleName.Visible = false;
                txtTitleName.Enabled = false;
                cboTitle.Focus();
            }
        }

        private void chkSubTitle_CheckedChanged(object sender, EventArgs e)
        {
            this.txtSubTitleName.Text = string.Empty;

            if (chkSubTitle.Checked)
            {
                //cboSubTitle.SelectedIndex = -1;
                //cboSubTitle.Text = string.Empty;
                //cboSubTitle.Enabled = false;

                this.lblNewSubTitle.Visible = true;
                lblNewSubTitle.Visible = true;
                txtSubTitleName.Visible = true;
                txtSubTitleName.Enabled = true;
                txtSubTitleName.Text = txtSubTitle.Text.Trim();
                txtSubTitleName.Focus();
            }
            else
            {
                //cboSubTitle.Enabled = true;
                this.lblNewSubTitle.Visible = false;
                //lblNewSubTitle.Visible = false;
                txtSubTitleName.Visible = false;
                txtSubTitleName.Enabled = false;
                txtSubTitle.Focus();
            }
        }

        private void chkOtherBank_CheckedChanged(object sender, EventArgs e)
        {
            this.txtOtherBankGroup.Text = string.Empty;

            if (chkOtherBank.Checked)
            {
                //cboOtherBankGroup.SelectedIndex = -1;
                //cboOtherBankGroup.Text = string.Empty;
                //cboOtherBankGroup.Enabled = false;

                this.lblNewOthBankGroupTitle.Visible = true;
                //lblNewOthBankGroupTitle.Visible = true;
                txtOtherBankGroup.Visible = true;
                txtOtherBankGroup.Enabled = true;
                txtOtherBankGroup.Text = cboOtherBankGroup.Text.Trim();
                txtOtherBankGroup.Focus();
            }
            else
            {
                //cboOtherBankGroup.Enabled = true;
                this.lblNewOthBankGroupTitle.Visible = false;
                //lblNewOthBankGroupTitle.Visible = false;
                txtOtherBankGroup.Visible = false;
                txtOtherBankGroup.Enabled = false;
                cboOtherBankGroup.Focus();
            }
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            if (this.CheckRequiredFields())
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure want to Update?", CXUIMessageUtilities.MESSAGE_BOX_TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                    this.Controller.Update(sender, e, ItemOrderCollection(), SubItemOrderCollection());                  

                else if (dialogResult == DialogResult.No)
                    cboBranchCode.Focus();
            }
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            
            if (CheckRequiredFields_ForDelete())
            {
                if (this.cboTitle.Text.Trim().ToString() == oldTitleName)//Added by HMW (8-12-2022)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure want to Delete?", CXUIMessageUtilities.MESSAGE_BOX_TITLE, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.Yes)
                        this.Controller.Delete(sender, e);

                    else if (dialogResult == DialogResult.No)
                        cboBranchCode.Focus();
                }
                else
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV30044);//Invalid Title Name!\nPlease select to the original one!                    
                    this.cboTitle.Focus();
                }
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

        private void gvTitleOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1))
            {
                return;
            }
            DataGridViewRow dataRow = (DataGridViewRow)gvTitleOrder.Rows[e.RowIndex];
            DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

            if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colTitleName"))
            {
                string TitleName = gvTitleOrder.Rows[e.RowIndex].Cells["colTitleName"].Value.ToString();
                if (TitleName != "" && gLMDTO00023.TITLE != "Account with other Bank")
                {
                    //this.txtTitle.Text = TitleName;//Comment by HMW (28-11-2022) : No need control & remove
                    this.gvSubTitleOrder.DataSource = null;
                    this.gvSubTitleOrder.AutoGenerateColumns = false;
                    SubTitleNamelst = Controller.SelectAllSUBTITLE_by_TITLE(TitleName).ToList<GLMDTO00023>();

                    if (SubTitleNamelst.Count > 0)
                        this.gvSubTitleOrder.DataSource = SubTitleNamelst;

                    this.gvSubTitleOrder.Refresh();
                }
            }
        }
        #endregion      
    }
}