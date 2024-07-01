using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Ace.Windows.CXClient;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Mnm.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Loan.Dmd.DTO;

//using System.Text.RegularExpressions;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00067 : BaseDockingForm, ILOMVEW00067
    {
        public static string eventMode = "";
        public string checkStatus;
        #region constructor
        public LOMVEW00067()
        {
            InitializeComponent();
        }
        #endregion

        public IList<LOMDTO00095> lst;
        public List<LOMDTO00080> lstDealer;
        private ILOMCTL00066 controller;
        public ILOMCTL00066 Controller
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

        private LOMDTO00060 viewData;
        public LOMDTO00060 ViewData
        {
            get
            {
                return this.viewData;
            }

            set { this.viewData = value; }
        }

        public PFMDTO00067 AccountInformation { get; set; }

        public string dealerNo
        {
            get { return txtDealerRegID.Text; }
            set
            {
                this.txtDealerRegID.Text = value;

            }
        }
        public string dealerAC
        {
            get { return this.mtxtAcctno.Text.Replace("-", "").Trim(); }
            set { this.mtxtAcctno.Text = value; }
        }

        public string dname
        {
            get { return txtDealerName.Text; }
            set { this.txtDealerName.Text = value; }
        }

        public string dphone
        {
            get { return txtDealerPhone.Text; }
            set { this.txtDealerPhone.Text = value; }
        }

        public string daddress
        {
            get { return txtDealerAddress.Text; }
            set { this.txtDealerAddress.Text = value; }
        }
        public string email
        {
            get { return txtDealerEmail.Text; }
            set { this.txtDealerEmail.Text = value; }
        }

        public string nRC
        {
            get { return txtDealerNRC.Text; }
            set { this.txtDealerNRC.Text = value; }
        }

        public string fax
        {
            get { return txtDealerFax.Text; }
            set { this.txtDealerFax.Text = value; }
        }

        public string business
        {
            get { return txtDealerBusiName.Text; }
            set { this.txtDealerBusiName.Text = value; }
        }

        public string city
        {
            get { return txtDealerBusiCity.Text; }
            set { this.txtDealerBusiCity.Text = value; }
        }

        public string businessEmail
        {
            get { return txtDealerBusiEmail.Text; }
            set { this.txtDealerBusiEmail.Text = value; }
        }

        public string businessAddress
        {
            get { return txtDealerBusiAddress.Text; }
            set { this.txtDealerBusiAddress.Text = value; }
        }

        public decimal commission
        {
            get
            {
                if (string.IsNullOrEmpty(txtDealerBusiComis.Text.ToString()))
                {
                    txtDealerBusiComis.Text = "0";

                }
                return Convert.ToDecimal(txtDealerBusiComis.Text);
            }
            set { this.txtDealerBusiComis.Text = Convert.ToString(value); }
        }

        public string sourceBr { get; set; }

        public bool ValidationControls()
        {
            if (string.IsNullOrEmpty(this.dname))
            {
                errorProvider1.SetError(txtDealerName, "name");
            }
            if (string.IsNullOrEmpty(this.nRC))
            {
                errorProvider1.SetError(txtDealerNRC, "nRC");
            }
            if (string.IsNullOrEmpty(this.dphone))
            {
                errorProvider1.SetError(txtDealerPhone, "dphone");
            }
            if (string.IsNullOrEmpty(this.fax))
            {
                errorProvider1.SetError(txtDealerFax, "fax");
            }
            if (string.IsNullOrEmpty(this.email))
            {
                errorProvider1.SetError(txtDealerEmail, "email");
            }
            if (string.IsNullOrEmpty(this.daddress))
            {
                errorProvider1.SetError(txtDealerAddress, "daddress");
            }
            if (string.IsNullOrEmpty(this.business))
            {
                errorProvider1.SetError(txtDealerBusiName, "business");
            }
            if (string.IsNullOrEmpty(this.city))
            {
                errorProvider1.SetError(txtDealerBusiCity, "city");
            }
            if (string.IsNullOrEmpty(this.businessEmail))
            {
                errorProvider1.SetError(txtDealerBusiEmail, "businessEmail");
            }
            if (string.IsNullOrEmpty(this.businessAddress))
            {
                errorProvider1.SetError(txtDealerBusiAddress, "businessAddress");
            }
            if (txtDealerBusiComis.TextLength == 0)
            {
                errorProvider1.SetError(txtDealerBusiComis, "commission");
            }
            if (string.IsNullOrEmpty(this.dname) || string.IsNullOrEmpty(this.nRC) || string.IsNullOrEmpty(this.dphone) || string.IsNullOrEmpty(this.fax) || string.IsNullOrEmpty(this.email) || string.IsNullOrEmpty(this.daddress)
                || string.IsNullOrEmpty(this.business) || string.IsNullOrEmpty(this.city) || string.IsNullOrEmpty(this.businessEmail) || string.IsNullOrEmpty(this.businessAddress) || txtDealerBusiComis.TextLength == 0)
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90067);
                errorProvider1.Clear();
                return false;
            }
            else return true;
        }

        public void Successful(string message, string dealerNo)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.InitializeControls();
        }

        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }
        private void InitializeControls()
        {
            this.txtDealerRegID.Text = string.Empty;
            this.txtDealerRegID.Enabled = false; // Added By AAM (12_Apr_2018)
            this.mtxtAcctno.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            this.mtxtAcctno.Text = string.Empty;
            this.txtDealerName.Text = string.Empty;
            this.txtDealerNRC.Text = string.Empty;
            this.txtDealerPhone.Text = string.Empty;
            this.txtDealerFax.Text = string.Empty;
            this.txtDealerEmail.Text = string.Empty;
            this.txtDealerAddress.Text = string.Empty;
            this.txtDealerBusiName.Text = string.Empty;
            this.txtDealerBusiCity.Text = string.Empty;
            this.txtDealerBusiEmail.Text = string.Empty;
            this.txtDealerBusiAddress.Text = string.Empty;
            this.txtDealerBusiComis.Text = string.Empty;
            this.txtDealerName.Focus();
        }

        private void txtDealerAcctno_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar != 44 && !Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            //{
            //    e.Handled = true;
            //}
        }
        private void txtDealerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDealerNRC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '-')
            {
                e.Handled = false;
            }
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtDealerPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.KeyChar = char.ToUpper(e.KeyChar);
            //if (e.KeyChar != ',' || e.KeyChar != '-' || !Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            //{
            //    e.Handled = true;
            //}
            if (e.KeyChar != 45 && e.KeyChar != 44 && !Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void txtDealerFax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 45 && e.KeyChar != 44 && !Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void txtDealerEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToLower(e.KeyChar);
        }

        private void txtDealerAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtDealerBusiName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
            //if (char.IsDigit(e.KeyChar))
            //{
            //    e.Handled = true;
            //}
        }

        private void txtDealerBusiCity_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtDealerBusiEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToLower(e.KeyChar);
        }

        private void txtDealerBusiAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtDealerBusiComis_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void tsbCRUD_Load(object sender, EventArgs e)
        {
            tsbCRUD.ButtonEnableDisabled(false, true, true, false, true, false, true);
            btnDealerSearch.Enabled = false;
            this.InitializeControls();
        }

        private void tsbCRUD_SaveButtonClick(object sender, EventArgs e)
        {
            if (eventMode == "EDIT")
            {
                if (CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC90005) == DialogResult.Yes)
                {
                    if (!this.ValidationControls())
                        return;
                    dealerNo = this.controller.SaveDealerRegistration(dealerNo, dealerAC, dname, dphone, daddress, email, nRC, fax, business, city, businessEmail, businessAddress, commission, eventMode, CurrentUserEntity.BranchCode, CurrentUserEntity.CurrentUserID, DateTime.Now, CurrentUserEntity.CurrentUserID, DateTime.Now);
                    this.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode, dealerNo);
                }
                else
                {
                    return;
                    //this.InitializeControls();
                }
            }
            else
            {
                if (!this.ValidationControls())
                    return;
                if (CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC00004) == DialogResult.Yes)
                {
                    eventMode = "SAVE";
                    dealerNo = this.controller.SaveDealerRegistration(dealerNo, dealerAC, dname, dphone, daddress, email, nRC, fax, business, city, businessEmail, businessAddress, commission, eventMode, CurrentUserEntity.BranchCode, CurrentUserEntity.CurrentUserID, DateTime.Now, CurrentUserEntity.CurrentUserID, DateTime.Now);
                    this.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode, dealerNo);
                    this.InitializeControls();
                }
                else
                {
                    return;
                    //this.InitializeControls();
                }
            }

        }

        private void tsbCRUD_EditButtonClick(object sender, EventArgs e)
        {
            btnDealerSearch.Enabled = true;
            eventMode = "EDIT";
            this.InitializeControls();
            txtDealerRegID.Enabled = true;
            txtDealerRegID.Focus();
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            if (CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC90001) == DialogResult.Yes)
            {
                this.controller.DeleteDealerRegistration(dealerNo,CurrentUserEntity.CurrentUserID,CurrentUserEntity.BranchCode);
                this.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode, dealerNo);
            }
            else
            {
                return;
                this.InitializeControls();
            }
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            eventMode = "";
            tsbCRUD.ButtonEnableDisabled(false, false, true, false, true, false, true);
            this.SetControlsAfterCancel();
        }

        private void btnEnquiry_Click(object sender, EventArgs e)
        {
            if (dealerAC.Trim() != string.Empty)
            {
                this.AccountInformation = new PFMDTO00067();
                this.AccountInformation = this.Controller.GetAccountInformation();
                if (this.AccountInformation == null)
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00046);
                    mtxtAcctno.Focus();
                }
                else
                    //    this.InitializeControls();
                    this.controller.Call_Enquiry();
            }
            else
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME90009);
                mtxtAcctno.Focus();
            }

            //this.controller.Call_Enquiry();
        }

        private void btnDealerSearch_Click(object sender, EventArgs e)
        {
            this.controller.Call_DealerSearch();
        }
        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
            this.InitializeControls();
            eventMode = "";
        }

        private void mtxtAcctno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                checkStatus = this.controller.CheckAccountExistsOrValid(dealerAC, CurrentUserEntity.BranchCode);
                string acctno = dealerAC;
                this.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode, dealerAC);
                this.mtxtAcctno.Text = acctno;
                mtxtAcctno.Focus();
                if (checkStatus == "0")
                {
                    lst = this.controller.GetDealerAccountInfo(dealerAC, CurrentUserEntity.BranchCode);
                    dname = lst[0].Name;
                    nRC = lst[0].NRC;
                    dphone = lst[0].Phone;
                    fax = lst[0].Fax;
                    email = lst[0].Email;
                    daddress = lst[0].Address;
                }

                txtDealerBusiName.Focus();
            }
        }

        private void txtDealerRegID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        public void SetControls()
        {
            mtxtAcctno.Enabled = false;
            txtDealerName.Enabled = false;
            txtDealerNRC.Enabled = false;
            txtDealerPhone.Enabled = false;
            txtDealerFax.Enabled = false;
            txtDealerEmail.Enabled = false;
            txtDealerAddress.Enabled = false;

            txtDealerBusiName.Enabled = true;
            txtDealerBusiCity.Enabled = true;
            txtDealerBusiEmail.Enabled = true;
            txtDealerBusiAddress.Enabled = true;
            txtDealerBusiComis.Enabled = true;
        }

        public void SetControlsAfterCancel()
        {
            txtDealerRegID.Enabled = false;
            mtxtAcctno.Enabled = true;
            txtDealerName.Enabled = true;
            txtDealerNRC.Enabled = true;
            txtDealerPhone.Enabled = true;
            txtDealerFax.Enabled = true;
            txtDealerEmail.Enabled = true;
            txtDealerAddress.Enabled = true;

            txtDealerBusiName.Enabled = true;
            txtDealerBusiCity.Enabled = true;
            txtDealerBusiEmail.Enabled = true;
            txtDealerBusiAddress.Enabled = true;
            txtDealerBusiComis.Enabled = true;

            mtxtAcctno.Text = string.Empty;
            txtDealerName.Text = string.Empty;
            txtDealerNRC.Text = string.Empty;
            txtDealerPhone.Text = string.Empty;
            txtDealerFax.Text = string.Empty;
            txtDealerEmail.Text = string.Empty;
            txtDealerAddress.Text = string.Empty;

            txtDealerBusiName.Text = string.Empty;
            txtDealerBusiCity.Text = string.Empty;
            txtDealerBusiEmail.Text = string.Empty;
            txtDealerBusiAddress.Text = string.Empty;
            txtDealerBusiComis.Text = string.Empty;
        }

        private void txtDealerRegID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                lstDealer =((List<LOMDTO00080>) this.controller.GetAllDealerInformation(CurrentUserEntity.BranchCode)).Where(x => x.DealerNo == dealerNo.ToString()).ToList();
                if (lstDealer==null || lstDealer.Count==0)
                {
                    MessageBox.Show("This Dealer No is not found!");
                    return;
                }
                mtxtAcctno.Text = lstDealer[0].DealerAC;
                txtDealerName.Text = lstDealer[0].Dname;
                txtDealerNRC.Text = lstDealer[0].NRC;
                txtDealerPhone.Text = lstDealer[0].Dphone;
                txtDealerFax.Text = lstDealer[0].fax;
                txtDealerEmail.Text = lstDealer[0].email;
                txtDealerAddress.Text = lstDealer[0].Daddress;
                txtDealerBusiName.Text = lstDealer[0].Business;
                txtDealerBusiCity.Text = lstDealer[0].city;
                txtDealerBusiEmail.Text = lstDealer[0].BusinessEmail;
                txtDealerBusiAddress.Text = lstDealer[0].BusinessEmail;
                txtDealerBusiComis.Text = lstDealer[0].commission.ToString();

                this.SetControls();
            }
        }
    }
}
