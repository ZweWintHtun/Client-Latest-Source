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
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00421 : BaseDockingForm, ILOMVEW00421 
    {
        string resultStr;
        IList<LOMDTO00406> dto;
        public LOMVEW00421()
        {
            InitializeComponent();
        }
        private ILOMCTL00421 controller;
        public ILOMCTL00421 Controller
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
            this.txtBLNo.Text = string.Empty;
            this.txtBLDuration.Text = string.Empty;
            this.dgvBLRepayHistory.Rows.Clear();
        }
        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.InitializeControls();
        }
        public void Show_RepaymentHistory_Info(string acctNo, string sourceBr)
        {
            dto = this.controller.BlAbsentHistory_Enquiry(AcctNo, sourceBr);
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
            txtBLNo.Text = dto[0].Lno;
            txtBLType.Text = dto[0].BLType;
            txtBLDuration.Text =dto[0].Min_Period.ToString();

            dgvBLRepayHistory.Rows.Clear();
            for (int i = 0; i < dto.Count; i++)
            {
                object[] str = { dto[i].TermNo, dto[i].EndDate.Value.ToString("dd/MM/yyyy"), dto[i].LateDays };

                this.dgvBLRepayHistory.CausesValidation = false; 
                this.dgvBLRepayHistory.AutoGenerateColumns = false;
                //dgvBLRepayHistory.Rows.Clear();
                dgvBLRepayHistory.Rows.Add(str);
                this.dgvBLRepayHistory.ReadOnly = true;
            }

        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LOMVEW00421_Load(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            string rptName = "BLRepaymentHistory_Enquiry";
            this.controller.Print(rptName, AcctNo, CurrentUserEntity.BranchCode);
        }

        private void mtxtAccountNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Show_RepaymentHistory_Info(AcctNo, CurrentUserEntity.BranchCode);
            }
        }

    }
}
