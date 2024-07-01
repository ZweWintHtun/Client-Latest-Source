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
using Ace.Cbs.Tcm.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Tcm.Ctr.Sve;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00312 : BaseForm, ILOMVEW00312
    {
        public string eno = "";
        public LOMVEW00312()
        {
            InitializeComponent();
        }

        private ILOMCTL00312 controller;
        public ILOMCTL00312 Controller
        {
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
            get { return controller; }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                timer1.Start();
                lblStatus.Text = "Process....please wait";
                string str = this.controller.PLMonthlyAutoPaymentProc(CurrentUserEntity.BranchCode, CurrentUserEntity.CurrentUserID, CurrentUserEntity.CurrentUserName);
                if (str == "0")
                {
                    timer1.Stop();
                    PLAutoPayRunProgress.Value = 100;
                    lblStatus.Text = "Process completed successfully";
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90115);//Personal Loan Auto Payment Process is successfully finished.

                    PLAutoPayRunProgress.Value = 0;
                    lblStatus.Text = "";
                }
                else if (str == "1")
                {
                    timer1.Stop();
                    PLAutoPayRunProgress.Value = 0;
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90182);//Please Run PL Late Fees Auto Voucher Process Firstly!

                    PLAutoPayRunProgress.Value = 0;
                    lblStatus.Text = "";
                }
                else if (str == "-1")
                {
                    timer1.Stop();
                    PLAutoPayRunProgress.Value = 0;
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90154);//No need to run auto pay process in this date!

                    PLAutoPayRunProgress.Value = 0;
                    lblStatus.Text = "";
                }
                else if (str == "-2")
                {
                    timer1.Stop();
                    PLAutoPayRunProgress.Value = 0;
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90161);//Already Run Personal Loan Auto Payment Process!

                    PLAutoPayRunProgress.Value = 0;
                    lblStatus.Text = "";
                }
                else//str == "-3"
                {
                    timer1.Stop();
                    PLAutoPayRunProgress.Value = 0;
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90162);//No Records to run personal loan monthly auto payment process!

                    PLAutoPayRunProgress.Value = 0;
                    lblStatus.Text = "";
                }
            }
            catch (Exception ex)
            {
                timer1.Stop();
                PLAutoPayRunProgress.Value = 0;
                lblStatus.Text = "Process fail";
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90162);//No Records to run personal loan monthly auto payment process!

                PLAutoPayRunProgress.Value = 0;
                lblStatus.Text = "";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (PLAutoPayRunProgress.Value > 97) return;

            PLAutoPayRunProgress.Value += 2;
        }

        private void LOMVEW00312_Load(object sender, EventArgs e)
        {
            //if (!this.controller.CheckCutOffForToday())
            //{
            //    this.btnProcess.Enabled = false;
            //    this.lblStatus.Text = "Please do System Cut Off Process First!";
            //}
            //else
            //{
            //     this.btnProcess.Enabled = true;
            //     this.lblStatus.Text = string.Empty;
            //}

            // Updated By ZMS (20/12/17) to check HPLateFee Auto Voucher already run ?
            DateTime PlLfdate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("PLLateFees_AutoPay"), CurrentUserEntity.BranchCode, true });

            #region Old_Code_Valid (CommentByHMW)
            //if (PlLfdate.Year == DateTime.Now.Year && PlLfdate.Month == DateTime.Now.Month && PlLfdate.Day == DateTime.Now.Day)
            //{
            //    //can run Auto Pay Process
            //}
            //else
            //{
            //    PLAutoPayRunProgress.Value = 0; this.btnProcess.Enabled = false;
            //    this.lblStatus.Text = "Please do Personal Loans Latefee Auto Payment Process First!";
            //}
            #endregion

            #region Seperating EOD Process (By HMW at 05-Aug-2019)
            //Getting System Start Up Date
            TCMDTO00001 startDTO = CXClientWrapper.Instance.Invoke<ITCMSVE00014, TCMDTO00001>(x => x.SelectStartBySourceBr(CurrentUserEntity.BranchCode));
            if (startDTO == null)
            {
                CXUIMessageUtilities.ShowMessageByCode(CXMessage.ME90047);//System Start Up File has no record.
                return;
            }
            else
            {
                if (startDTO.Status == "C")
                {
                    lblDateTime.Text = startDTO.Date.ToString("dd-MM-yyyy"); //Show System Date
                }
            }

            lblDateTime.Text = startDTO.Date.ToString("dd-MM-yyyy");

            if (PlLfdate.Year == startDTO.Date.Year && PlLfdate.Month == startDTO.Date.Month && PlLfdate.Day == startDTO.Date.Day)
            {
                //can run Auto Pay Process
            }
            else
            {
                PLAutoPayRunProgress.Value = 0;
                this.btnProcess.Enabled = false;
                this.lblStatus.Text = "Please Run ''Personal Loan Late Fee Auto Payment Process'' First!";
            }
            #endregion
        }
    }
}
