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

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00089 : BaseForm, ILOMVEW00089
    {
        #region Controller

        private ILOMCTL00089 controller;
        public ILOMCTL00089 Controller
        {
            get { return this.controller; }
            set { this.controller = value; this.controller.View = this; }
        }

        #endregion

        #region Constructor

        public LOMVEW00089()
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

        private void LOMVEW00089_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
            this.lblBudgetYear.Text = CXCOM00010.Instance.GetBudgetYear1(CXCOM00009.BudgetYearCode); 
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            this.controller.CalculateInterest();
        }

        #endregion
    }
}
