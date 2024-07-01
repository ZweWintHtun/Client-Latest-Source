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

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00204 : BaseForm, ILOMVEW00204
    {
        public LOMVEW00204()
        {
            InitializeComponent();
        }
        
        private ILOMCTL00204 controller;
        public ILOMCTL00204 Controller
        {
            get { return controller; }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }

        private void LOMVEW00204_Load(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("dd-MM-yyyy");
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                timer1.Start();
                lblStatus.Text = "Process....please wait";
                string str = this.controller.HPLateFeesCalculationProcess(CurrentUserEntity.BranchCode,CurrentUserEntity.CurrentUserID,CurrentUserEntity.CurrentUserName);
                if (str == "0")
                {
                    timer1.Stop();
                    HPLateFeesCalculationProgress.Value = 100;
                    lblStatus.Text = "Process completed successfully";
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90114);//HP Late Fees Calculation Process is successfully finshed!.

                    HPLateFeesCalculationProgress.Value = 0;
                    lblStatus.Text = "";
                }
                else if (str == "1")
                {   
                    timer1.Stop();
                    HPLateFeesCalculationProgress.Value = 0;
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90164);//Please Run HP Auto Payment Process Firtly!.

                    HPLateFeesCalculationProgress.Value = 0;
                    lblStatus.Text = "";
                }
                else //if str == "-1"
                {
                    timer1.Stop();
                    HPLateFeesCalculationProgress.Value = 0;
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90180);//There is no late fees in this date!.

                    HPLateFeesCalculationProgress.Value = 0;
                    lblStatus.Text = "";
                }
            }
            catch (Exception ex)
            {
                timer1.Stop();
                HPLateFeesCalculationProgress.Value = 0;
                lblStatus.Text = "Process fail";

                HPLateFeesCalculationProgress.Value = 0;
                lblStatus.Text = "";
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (HPLateFeesCalculationProgress.Value > 97) return;

            HPLateFeesCalculationProgress.Value += 2;
        }




    }
}
