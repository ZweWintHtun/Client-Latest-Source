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

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00044 : BaseForm, ILOMVEW00044
    {
        #region Constructor
        public LOMVEW00044()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        public DateTime InterestCalculationDate
        {
            get { return this.dtpIntCalcDate.Value; }
            set { this.dtpIntCalcDate.Text = value.ToString(); }
        }
        #endregion

        #region Controller
        private ILOMCTL00044 controller;
        public ILOMCTL00044 Controller
        {
            get { return controller; }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }
        #endregion

        #region Events
        private void LOMVEW00044_Load(object sender, EventArgs e)
        {
            InitailizeControl();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            this.controller.CalculateOD();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Initialize
        private void InitailizeControl()
        {
            this.dtpIntCalcDate.Value = DateTime.Now;
        }
        #endregion

    }
}
