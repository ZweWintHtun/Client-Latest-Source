using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Loan.Dmd.DTO;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00425 : BaseDockingForm, ILOMVEW00425
    {
        #region Properties
        private ILOMCTL00425 controller;
        public ILOMCTL00425 Controller
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
        private string name;
        public string Name
        {
            get
            {
                if (this.txtName.Text == null)
                {
                    return null;
                }
                else
                {
                    return this.txtName.Text.ToString();
                }
            }
            set
            {
                this.txtName.Text = value;
            }
        }
        private string nrc;
        public string NRC
        {
            get
            {
                if (this.txtNRC.Text == null)
                {
                    return null;
                }
                else
                {
                    return this.txtNRC.Text.ToString();
                }
            }
            set
            {
                this.txtNRC.Text = value;
            }
        }
        private bool nameExact;
        public bool NameExact
        {
            get
            {
                if (this.chkNameExactly.Checked == false)
                {
                    nameExact = false;
                    return false;
                }
                else
                {
                    return true;
                    nameExact = true;
                }
            }
            set
            {
                this.chkNameExactly.Checked = value;
                nameExact = true;
            }
        }
        private bool nrcExact;
        public bool NrcExact
        {
            get
            {
                if (this.chkNRCExactly.Checked == false)
                {
                    return false;
                    nrcExact = false;
                }
                else
                {
                    return true;
                    nrcExact = true;
                }
            }
            set
            {
                this.chkNRCExactly.Checked = value;
                nrcExact = true;
            }
        }
        private string formname;
        public string FormName
        {
            get { return this.formname; }
            set { this.formname = value; }
        }
        public IList<LOMDTO00423> lstgv;
        public string ACType { get; set; }
        public int IndexfAC { get; set; }
        public string searchType { get; set; }
        #endregion

        #region Constructor
        public LOMVEW00425()
        {
            InitializeComponent();
        }
        public LOMVEW00425(int index)
        {
            IndexfAC = index;
            InitializeComponent();
        }
        #endregion

        #region Events
        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvCustomerInfo.DataSource = null;
            if (dgvCustomerInfo.RowCount > 0)
                dgvCustomerInfo.Rows.Clear();
            lstgv = this.controller.GetAllCustomerInformation();
            if (lstgv.Count == 0)
            {
                // Invalid file format.Please re-choose again.
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME30012); //Data Not Found.
                return;
            }
            else
            {
                dgvCustomerInfo.DataSource = null;
                dgvCustomerInfo.Rows.Clear();
                dgvCustomerInfo.Refresh();
                for (int i = 0; i < lstgv.Count; i++)
                {
                    object[] row = { lstgv[i].CustID,lstgv[i].Caccount, lstgv[i].NAME, lstgv[i].NRC, lstgv[i].Occu
                                   ,lstgv[i].Phone,lstgv[i].Address};
                    dgvCustomerInfo.Rows.Add(row);
                }
            }
        }
        private void LOMVEW00425_Load(object sender, EventArgs e)
        {
            tlspCommon.ButtonEnableDisabled(false, false, false, false, true, false, true);
            InitializeControl();
            if (IndexfAC == 0)
            {
                this.ACType = "BusinessLoan";
                this.Text = "Account Information Enquiry (Business Loan)";
            }
            if (IndexfAC == 1)
            {
                this.ACType = "Dealer";
                this.Text = "Account Information Enquiry (Dealer)";
            }
            if (IndexfAC == 2)
            {
                this.ACType = "HirePurchase";
                this.Text = "Account Information Enquiry (HirePurchase)";
            }
            if (IndexfAC == 3)
            {
                this.ACType = "PersonalLoan";
                this.Text = "Account Information Enquiry (Personal Loan)";
            }
        }

        private void tlspCommon_CancelButtonClick(object sender, EventArgs e)
        {
            InitializeControl();
        }

        private void tlspCommon_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }
        private void OptName_CheckedChanged(object sender, EventArgs e)
        {
            NameCheckChange();
        }

        private void OptByCompanyName_CheckedChanged(object sender, EventArgs e)
        {
            NameCheckChange();
        }
        #endregion

        #region Methods
        public void InitializeControl()
        {           
            txtName.Text = "";
            txtNRC.Text = "";
            chkNameExactly.Checked = false;
            chkNRCExactly.Checked = false;
            lstgv = null;
            nrcExact = false;
            NameExact = false;
            OptName.Checked = true;
            lblName.Text = "Name :";

            dgvCustomerInfo.DataSource = null;
            if (dgvCustomerInfo.RowCount > 0)
                dgvCustomerInfo.Rows.Clear();
        }
        private void NameCheckChange()
        {
            if (OptName.Checked == true)
            {
                lblName.Text = "Name :";
                searchType = "Name";
                OptName.Checked = true;
                OptByCompanyName.Checked = false;
            }
            else if (OptByCompanyName.Checked == true)
            {
                lblName.Text = "Company Name :";
                searchType = "CompanyName";
                OptName.Checked = false;
                OptByCompanyName.Checked = true;
            }
        }
        #endregion

        
    }
}
