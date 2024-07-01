using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Ctr.Ptr;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00087 : BaseForm, ILOMVEW00087
    {
        #region Constructor
        public LOMVEW00087()
        {
            InitializeComponent();
        }

        public LOMVEW00087(string groupNo)
         {
            this.GroupNo = groupNo;
            InitializeComponent();
        }
        #endregion

        #region Controller

        private ILOMCTL00087 controller;
        public ILOMCTL00087 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }

        #endregion

        #region Properties

        private string groupNo;
        public string GroupNo
        {
            get { return this.groupNo.ToString(); }
            set { this.groupNo = value; }
        }

        public IList<PFMDTO00078> SolidarityList { get; set; }
        public IList<LOMDTO00078> FarmLoanList { get; set; }

        #endregion

        #region Methods

        private void gvSolidarityLending_DataBind()
        {
            gvSolidarityLending.AutoGenerateColumns = false;
            this.SolidarityList = this.controller.SelectSolidarityByGroupNo(this.GroupNo);
            this.gvSolidarityLending.DataSource = this.SolidarityList;
            //this.txtRecordCount.Text = SolidarityList.RowCount.ToString();
        }

        private void gvLoanInfo_DataBind()
        {
            gvLoanInfo.AutoGenerateColumns = false;
            this.FarmLoanList = this.controller.SelectFarmLoanByGroupNo(this.GroupNo);
            this.gvLoanInfo.DataSource = this.FarmLoanList;
            //this.txtRecordCount.Text = SolidarityList.RowCount.ToString();
        }

        #endregion

        #region Events

        private void LOMVEW00087_Load(object sender, EventArgs e)
        {
            this.tlspCommon.ButtonEnableDisabled(false, false, false, false, false, false, true);
            if (!String.IsNullOrEmpty(this.GroupNo))
            {
                this.txtGroupNo.Text = this.GroupNo.ToString();
                this.txtGroupNo.Enabled = false;
                this.gvSolidarityLending_DataBind();
                this.gvLoanInfo_DataBind();
            }
        }

        private void tlspCommon_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
