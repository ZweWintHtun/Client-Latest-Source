using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Dmd.DTO;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00427 : BaseDockingForm, ILOMVEW00427
    {
        #region Properties
        public string AccountNo
        {
            get { return this.mtxtAcctNo.Text.Replace("-", "").Trim(); }
            set { this.mtxtAcctNo.Text = value; }
        }
        public string Name
        {
            get { return this.txtName.Text.ToString(); }
            set { this.txtName.Text = value; }
        }
        public string NRC
        {
            get { return this.txtNRC.Text.ToString(); }
            set { this.txtNRC.Text = value; }
        }
        public string FName
        {
            get { return this.txtFatherName.Text.ToString(); }
            set { this.txtFatherName.Text = value; }
        }
        public string CName
        {
            get { return this.txtCompanyName.Text.ToString(); }
            set { this.txtCompanyName.Text = value; }
        }
        public string AbsentTerm
        {
            get { return this.txtAbsentTerm.Text.ToString(); }
            set { this.txtAbsentTerm.Text = value; }
        }
        public string DOB { get; set; }
        public string Address { get; set; }
        public string CompanyAddress { get; set; }
        public string IsValidUser = "0";
        #endregion

        #region Constructors
        public LOMVEW00427()
        {
            InitializeComponent();
        }

        private ILOMCTL00427 controller;
        public ILOMCTL00427 Controller
        {
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
            get
            {
                return this.controller;
            }
        }
        #endregion

        #region Events

        private void mtxtAcctNo_Leave(object sender, EventArgs e)
        {
            if (this.mtxtAcctNo.Text.Replace("-", "").Trim() != "" || this.mtxtAcctNo.Text.Replace("-", "").Trim() != string.Empty || this.mtxtAcctNo.Text.Replace("-", "").Trim().Length > 6)
            {
                GetCustData();
            }
        }
        private void mtxtAcctNo_Enter(object sender, EventArgs e)
        {
            if (this.mtxtAcctNo.Text.Replace("-", "").Trim() != "" || this.mtxtAcctNo.Text.Replace("-", "").Trim() != string.Empty || this.mtxtAcctNo.Text.Replace("-", "").Trim().Length > 6)
            {
                GetCustData();
            }
        }
        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            InitializeControls();
        }

        private void LOMVEW00427_Load(object sender, EventArgs e)
        {
            try
            {
                LOMDTO00427 userLists = this.Controller.SelectUserMakerCheckerApproveByUserId();
                if (userLists != null)
                {
                    if (userLists.IsEntry == true)
                    {
                        tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
                        InitializeControls();
                        EnableDisibleControls(true);

                        //IsValidUser = "1";
                        //this.Show();
                        //this.Visible = true;
                        //mtxtAcctNo.Enabled = true;
                    }
                    else
                    {
                        CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI40002);//You do not have permission for this function.
                        EnableDisibleControls(false);
                        tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
                        txtName.Text = "";

                        //IsValidUser = "0";
                        //mtxtAcctNo.Enabled = false;
                        //this.Close();
                        //return;
                    }
                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI40002);//You do not have permission for this function.
                    EnableDisibleControls(false);
                    tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
                    txtName.Text = "";
                  
                    //IsValidUser = "0";
                    //mtxtAcctNo.Enabled = false;
                    //this.Close();
                    //return;
                }
            }
            catch (Exception ex)
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI40002);//You do not have permission for this function.
                EnableDisibleControls(false);
                tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
                txtName.Text = "";

                //this.Hide();
                //this.Visible = false;
                //mtxtAcctNo.Enabled = false;
                //this.Close();
                //IsValidUser = "0";
                //this.Close();
                //return;
            }
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            if (mtxtAcctNo.Text.Replace("-", "").Trim() != string.Empty && mtxtAcctNo.Text.Replace("-", "").Trim() != "")
            {
                string result = this.Controller.SaveBlackLists(CurrentUserEntity.CurrentUserID, CurrentUserEntity.BranchCode, DOB);
                if (result == "0000")
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90001);//Saving Successful.
                    InitializeControls();
                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90215);//This customer is already in Black List.
                    InitializeControls();
                }
            }
            else
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00046);//Invalid Account No.
                mtxtAcctNo.Text = "";
                mtxtAcctNo.Focus();
            }
        }

        private void mtxtAcctNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                GetCustData();
            }
        }
        #endregion

        #region Methods
        public void EnableDisibleControls(bool status)
        {
            this.mtxtAcctNo.Enabled = status;
            //this.txtName.Enabled = status;
            //this.txtNRC.Enabled = status;
            //this.txtFatherName.Enabled = status;
            //this.txtCompanyName.Enabled = status;
            //this.txtAbsentTerm.Enabled = status;

            //if(status == tru)

        }
        public void InitializeControls()
        {
            this.mtxtAcctNo.Text = "";
            this.mtxtAcctNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            this.txtName.Text = "";
            this.txtNRC.Text = "";
            this.txtFatherName.Text = "";
            this.txtCompanyName.Text = "";
            this.txtAbsentTerm.Text = "";
            this.DOB ="";
            this.Address ="";
            this.CompanyAddress = "";
            this.CName = "";
            mtxtAcctNo.Focus();
        }
        public void GetCustData()
        {
            this.AccountNo = mtxtAcctNo.Text.Replace("-", "").Trim();
            this.txtName.Text = "";
            this.txtNRC.Text = "";
            this.txtFatherName.Text = "";
            this.txtCompanyName.Text = "";
            this.txtAbsentTerm.Text = "";
            this.DOB = "";
            this.Address = "";
            this.CompanyAddress = "";
            this.CName = "";
            IList<LOMDTO00427> AccountInfo = Controller.GetLoansAccountInfoByACNo();
            if (AccountInfo.Count > 0)
            {
                foreach (LOMDTO00427 item in AccountInfo)
                {
                    if (txtName.Text != "")
                    {
                        txtName.Text += ", ";
                    }
                    if (txtFatherName.Text != "")
                    {
                        txtFatherName.Text += ", ";
                    }
                    if (txtNRC.Text != "")
                    {
                        txtNRC.Text += ", ";
                    }
                    if (DOB != "" && DOB != "null")
                    {
                        DOB += ", ";
                    }
                    if (Address != "" && Address != "null")
                    {
                        Address += "; ";
                    }
                    if (item.Name.ToString() != "" && item.Name.ToString() != string.Empty)
                    {
                        txtName.Text += item.Name.ToString();
                    }
                    else txtName.Text += "-";

                    if (item.FatherName.ToString() != "" && item.FatherName.ToString() != string.Empty)
                    {
                        txtFatherName.Text += item.FatherName.ToString();
                    }
                    else txtFatherName.Text += "-";

                    if (item.NRC.ToString() != "" && item.NRC.ToString() != string.Empty)
                    {
                        txtNRC.Text += item.NRC.ToString();
                    }
                    else txtNRC.Text += "-";

                    if (item.DOB.ToString() != "" && item.DOB.ToString() != string.Empty && item.DOB.ToString() != "null")
                    {
                        DOB += item.DOB.ToString();                            
                        //DOB += item.DOB.ToString().Substring(3, 2) + "-" + item.DOB.ToString().Substring(0, 2) + "-" + item.DOB.ToString().Substring(6, 4);
                       
                    }
                    //else txtNRC.Text += "-";
                    else DOB += "-";

                    if (item.Address.ToString() != "" && item.Address.ToString() != string.Empty && item.Address.ToString() != "null")
                    {
                        Address += item.Address.ToString();
                    }
                    //else txtNRC.Text += "-";
                    else Address += "-";

                    if (item.AbsentTerm.ToString() != "" && item.AbsentTerm.ToString() != string.Empty && item.AbsentTerm.ToString() != "0")
                    {
                        txtAbsentTerm.Text = item.AbsentTerm.ToString();
                    }
                    else txtAbsentTerm.Text = "0";
                   
                    if (item.CompanyName.ToString() != string.Empty && item.CompanyName.ToString() != "null")
                    {
                        txtCompanyName.Text = item.CompanyName.ToString();
                        CompanyAddress = item.CompanyAddress.ToString();
                    }
                    else txtCompanyName.Text = "-";
                    
                }
                if (CompanyAddress != string.Empty && CompanyAddress != "null" )
                {
                    Address += "; " + CompanyAddress;
                }
            }
            else
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00046);//Invalid Account No.
                
            }
        }
        #endregion
    }
}
