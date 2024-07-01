using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Windows.CXClient.Controls;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00407 : BaseDockingForm, ILOMVEW00407
    {       
        #region Controller

        private ILOMCTL00407 controller;
        public ILOMCTL00407 Controller
        {
            get { return this.controller; }
            set { this.controller = value; this.controller.View = this; }
        }

        #endregion

        #region Constructor
        public LOMVEW00407()
        {
            InitializeComponent();
        }
        #endregion

        #region Control Properties

        public DateTime WithdrawDate
        {
            get { return this.dtpStartDate.Value; }
            set { this.dtpStartDate.Value = value; }
        }

        public DateTime RepaymentDate
        {
            get { return this.dtpEndDate.Value; }
            set { this.dtpEndDate.Value = value; }
        }
        public string sourceBranch { get;set;}
        public int userName { get; set; }
        DateTime lastSettlementdate, nextSettlementdate;
        #endregion

        #region Variable

        #endregion

        #region "Methods"

        /// <summary>
        ///Failure Message
        /// </summary>
        public void Failure(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now;
        }

        #endregion

        #region Events
        private void LOMVEW00407_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
            this.lblBudgetYear.Text = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode);

            lastSettlementdate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("LastSettlementDate"), CurrentUserEntity.BranchCode, true });
            nextSettlementdate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("NextSettlementDate"), CurrentUserEntity.BranchCode, true });

            dtpStartDate.Value = lastSettlementdate;//Friday(14/07/2017)
            dtpEndDate.Value = nextSettlementdate;
            dtpEndDate.Value = dtpEndDate.Value.AddDays(-1);//Sat(16/07/2017)
            this.userName = CurrentUserEntity.CurrentUserID;
            this.sourceBranch = CurrentUserEntity.BranchCode;
        }
        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            this.controller.CalculateInterest();
            dtpStartDate.Value = lastSettlementdate;//Friday(14/07/2017)
            dtpEndDate.Value = nextSettlementdate;
            dtpEndDate.Value = dtpEndDate.Value.AddDays(-1);//Sat(16/07/2017
        }
        #endregion

    }
}
