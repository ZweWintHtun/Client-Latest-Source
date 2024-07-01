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
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Loan.Dmd.DTO;

using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00219 : BaseDockingForm, ILOMVEW00219
    {
        string resultStr;
        IList<LOMDTO00217> dto;
        public LOMVEW00219()
        {
            InitializeComponent();
        }

        private ILOMCTL00219 controller;
        public ILOMCTL00219 Controller
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

        public string AcctNo
        {
            get { return this.mtxtAccountNo.Text.Replace("-", "").Trim(); }
            set { this.mtxtAccountNo.Text = value; }
        }

        public string SourceBr { get; set; }

        private void InitializeControls()
        {
            this.mtxtAccountNo.Text = string.Empty;
            this.mtxtAccountNo.Mask = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.AccountNoDisplayFormat);
            this.txtName.Text = string.Empty;
            this.txtNRC.Text = string.Empty;
            this.txtPLNo.Text = string.Empty;
            this.txtPLDuration.Text = string.Empty;
            this.dgvPLRepayHistory.Rows.Clear();
        }

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.InitializeControls();
        }

        public void Show_RepaymentHistory_Info(string acctNo, string sourceBr)
        {
            dto = this.controller.PLAbsentHistory_Enquiry(AcctNo, sourceBr);
            if (dto == null || dto.Count == 0)
            {
                this.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                this.InitializeControls();
                return;
            }

            string chkAcctNo = dto[0].chkAcctNo;

            if (chkAcctNo == "-1")
            {
                this.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                this.InitializeControls();
                return;
            }
            txtName.Text = dto[0].NAME;
            txtNRC.Text = dto[0].NRC;
            txtPLNo.Text = dto[0].PLNo;
            txtPLDuration.Text = dto[0].Term.ToString();

            for (int i = 0; i < dto.Count; i++)
            {
                object[] str = { dto[i].TermNo, dto[i].DueDate.ToString("dd/MM/yyyy"), dto[i].TotalLateDayWithDue };

                dgvPLRepayHistory.Rows.Clear();
                dgvPLRepayHistory.Rows.Add(str);
            }

        }

        private void mtxtAccountNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Show_RepaymentHistory_Info(AcctNo, CurrentUserEntity.BranchCode);
            }
        }

        private void LOMVEW00219_Load(object sender, EventArgs e)
        {
            this.InitializeControls();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            string rptName = "PLRepaymentHistory_Enquiry";
            this.controller.Print(rptName, AcctNo, CurrentUserEntity.BranchCode);
        }

    }
}
