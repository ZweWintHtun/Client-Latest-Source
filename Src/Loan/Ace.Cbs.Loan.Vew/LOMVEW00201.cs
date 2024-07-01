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
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Tcm.Ctr.Sve;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00201 : BaseForm, ILOMVEW00201
    {
        public string eno = "";
        public LOMVEW00201()
        {
            InitializeComponent();
        }

        private ILOMCTL00201 controller;
        public ILOMCTL00201 Controller
        {
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
            get { return controller; }

        }

        private void LOMVEW00201_Load(object sender, EventArgs e)
        {
            
            //if (!this.controller.CheckCutOffForToday())
            //{
            //    this.btnProcess.Enabled = false;
            //    this.lblStatus.Text = "Please do System Cut Off Process First!";
            //}
            //else
            //{
            //    this.btnProcess.Enabled = true;
            //    this.lblStatus.Text = string.Empty; 
            //}

            #region Old_Code_Valid (CommentByHMW)
            // Updated By ZMS (20/12/17) to check HPLateFee Auto Voucher already run ?
            //lblDateTime.Text = DateTime.Now.ToString("dd-MM-yyyy");
            //DateTime HpLfdate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("HPLateFees_AutoPay"), CurrentUserEntity.BranchCode, true });
            //if (HpLfdate.Year == DateTime.Now.Year && HpLfdate.Month == DateTime.Now.Month && HpLfdate.Day == DateTime.Now.Day)
            //{
            //    //can run Auto Pay Process
            //}
            //else
            //{
            //    HPAutoPayRunProgress.Value = 0; this.btnProcess.Enabled = false;
            //    this.lblStatus.Text = "Please do HirePurchase Latefee Auto Payment Process First!";
            //}
            #endregion

            #region Seperating EOD Process (By HMW at 02-08-2019)            
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
            DateTime HpLfdate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("HPLateFees_AutoPay"), CurrentUserEntity.BranchCode, true });
            
            if (HpLfdate.Year == startDTO.Date.Year && HpLfdate.Month == startDTO.Date.Month && HpLfdate.Day == startDTO.Date.Day)
            {
                //can run Auto Pay Process
            }          
            else
            {
                HPAutoPayRunProgress.Value = 0;
                this.btnProcess.Enabled = false;
                this.lblStatus.Text = "Please Run ''Hire Purchase Late Fee Auto Payment Process'' First!";
            }
            #endregion
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                timer1.Start();
                lblStatus.Text = "Process....please wait";
                string str = this.controller.HPMonthlyAutoPaymentProc(CurrentUserEntity.BranchCode, CurrentUserEntity.CurrentUserID, CurrentUserEntity.CurrentUserName);
                if (str == "0")
                {
                    timer1.Stop();
                    HPAutoPayRunProgress.Value = 100;
                    lblStatus.Text = "Process completed successfully";
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90112);

                    HPAutoPayRunProgress.Value = 0;
                    lblStatus.Text = "";
                }
                else if (str == "-1")
                {
                    timer1.Stop();
                    HPAutoPayRunProgress.Value = 0;
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90154);//No need to run auto pay process in this date!

                    HPAutoPayRunProgress.Value = 0;
                    lblStatus.Text = "";
                }
                else if (str == "-2")
                {
                    timer1.Stop();
                    HPAutoPayRunProgress.Value = 0;
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90155);//Already Run HP Auto Payment Process!

                    HPAutoPayRunProgress.Value = 0;
                    lblStatus.Text = "";
                }
                else if (str == "1")
                {
                    timer1.Stop();
                    HPAutoPayRunProgress.Value = 0;
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90164);//Please Run HP Late Fees Auto Voucher Process Firstly!.

                    HPAutoPayRunProgress.Value = 0;
                    lblStatus.Text = "";
                }                
                else //if (str=="-3")
                {
                    timer1.Stop();
                    HPAutoPayRunProgress.Value = 0;
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90150);//No Records to run HP Monthly Auto Payment Process!

                    HPAutoPayRunProgress.Value = 0;
                    lblStatus.Text = ""; 
                }
                //else // str=="-4"
                //{
                //    timer1.Stop();
                //    HPAutoPayRunProgress.Value = 0;
                //    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI30024);//Coa Setup Account Not Found.

                //    HPAutoPayRunProgress.Value = 0;
                //    lblStatus.Text = "";
                //}
            }
            catch (Exception ex)
            {
                timer1.Stop();
                HPAutoPayRunProgress.Value = 0;
                lblStatus.Text = "Process fail";
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90150);//No Records to run HP Monthly Auto Payment Process!

                HPAutoPayRunProgress.Value = 0;
                lblStatus.Text = "";
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (HPAutoPayRunProgress.Value > 97) return;

            HPAutoPayRunProgress.Value += 2;
        }
    }
}
