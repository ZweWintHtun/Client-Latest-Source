using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Ace.Cbs.Cx.Com.Utt;
using System.Windows.Forms;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Tcm.Ctr.Ptr;

namespace Ace.Cbs.Tcm.Vew
{
    public partial class TCMVEW00068 :BaseForm, ITCMVEW00068
    {

        #region View Data Properties

        /// <summary>
        /// Current SettlementDate
        /// </summary>
        public DateTime CurrentSettlementDate
        {
            get
            {
                return this.dtpCurrentSettlementDate.Value;
            }

            set
            {
                this.dtpCurrentSettlementDate.Value = value;
            }
        }

        /// <summary>
        /// Next SettlementDate
        /// </summary>
        public DateTime NextSettlementDate
        {
            get
            {
                return this.dtpNextSettlementDate.Value;
            }

            set
            {
                this.dtpNextSettlementDate.Value = value;
            }
        }

        public string SourceBranchCode { get; set; }
        #endregion

        #region Presenter
        private ITCMCTL00068 controller;
        public ITCMCTL00068 Controller
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

        public bool CutoffStatus
        {
            get { return butcutoff.Enabled; }
            set { this.butcutoff.Enabled = value; }
        }



        public TCMVEW00068()
        {
            InitializeComponent();
        }

        #region Event 

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }
        private void TCMVEW00068_Load(object sender, EventArgs e)
        {
            this.InitializeControls();
            //Enable Disable for tool strip bar for Update/Delete/Insert/Select Operation
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);

            DateTime systemDate = this.Controller.GetSystemDate(CurrentUserEntity.BranchCode);
            if (DateTime.Now.Date > systemDate.Date)
            {
                this.butcutoff.Enabled = false;
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME00071, new object[] { systemDate.ToString("dd/MM/yyyy") }); //Cannot cut off!\nSystem date is {0}.\nPlease change server and client PC Date to {0} first.
            }
        }


        private void butcutoff_Click(object sender, EventArgs e)
        {
            controller.Process();
            butcutoff.Enabled = false;
        }
        #endregion

        private void InitializeControls()
        {
            this.SourceBranchCode = CXCOM00007.Instance.BranchCode;
            this.Controller.BindSettlementDate();
        }       

    }
}
