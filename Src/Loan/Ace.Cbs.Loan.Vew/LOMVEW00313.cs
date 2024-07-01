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
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00313 : BaseForm,ILOMVEW00313
    {
        public LOMVEW00313()
        {
            InitializeComponent();
        }

        private ILOMCTL00313 controller;
        public ILOMCTL00313 Controller
        {
            get { return controller; }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                timer1.Start();
                lblStatus.Text = "Process....please wait";
                string str = this.controller.PLLateFeesCalculationProcess(CurrentUserEntity.BranchCode, CurrentUserEntity.CurrentUserID, CurrentUserEntity.CurrentUserName);
                if (str == "0")
                {
                    timer1.Stop();
                    PLLateFeesCalculationProgress.Value = 100;
                    lblStatus.Text = "Process completed successfully";
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90116);//Personal Loan Late Fees Calculation Process is successfully finished!

                    PLLateFeesCalculationProgress.Value = 0;
                    lblStatus.Text = "";
                }
                else if (str == "1")
                {
                    timer1.Stop();
                    PLLateFeesCalculationProgress.Value = 0;
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90182);//Please Run PL Auto Payment Process Firstly!

                    PLLateFeesCalculationProgress.Value = 0;
                    lblStatus.Text = "";
                }
                else //if str == "-1" // Updated by HWKO (30-Aug-2017)
                {
                    timer1.Stop();
                    PLLateFeesCalculationProgress.Value = 0;
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90180);//There is no late fees in this date!.

                    PLLateFeesCalculationProgress.Value = 0;
                    lblStatus.Text = "";
                }
            }
            catch (Exception ex)
            {
                timer1.Stop();
                PLLateFeesCalculationProgress.Value = 0;
                lblStatus.Text = "Process fail";
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90163);//Process Fail

                PLLateFeesCalculationProgress.Value = 0;
                lblStatus.Text = "";
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (PLLateFeesCalculationProgress.Value > 97) return;

            PLLateFeesCalculationProgress.Value += 2;
        }

        private void LOMVEW00313_Load(object sender, EventArgs e)
        {
            if (!this.controller.CheckCutOffForToday())
            {
                this.btnProcess.Enabled = false;
                this.lblStatus.Text = "Please do System Cut Off Process First!";
            }
            else
            {
                this.btnProcess.Enabled = true;
                this.lblStatus.Text = string.Empty;
            }
        }
    }
}
