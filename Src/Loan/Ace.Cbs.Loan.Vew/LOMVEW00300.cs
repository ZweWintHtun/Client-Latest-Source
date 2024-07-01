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
using Ace.Windows.CXClient;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00300 : BaseForm, ILOMVEW00300
    {
        #region Controller

        private ILOMCTL00300 controller;
        public ILOMCTL00300 Controller
        {
            get { return this.controller; }
            set { this.controller = value; this.controller.View = this; }
        }

        #endregion

        #region Constructor

        public LOMVEW00300()
        {
            InitializeComponent();
        }

        #endregion

        #region Control Properties

        public DateTime CalculatedDate
        {
            get { return this.dtpStartDate.Value; }
            set { this.dtpStartDate.Value = value; }
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
        }

        #endregion

        #region Events

        private void LOMVEW00300_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);

        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            this.controller.CalculatePenalFee();
        }

        #endregion
    }
}
