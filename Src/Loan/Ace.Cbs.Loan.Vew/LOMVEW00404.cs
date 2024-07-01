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
using Ace.Windows.Core.Utt;
using Ace.Cbs.Tcm.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Tcm.Ctr.Sve;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00404 : BaseForm, ILOMVEW00404
    {
        public string eno = "";
        public LOMVEW00404()
        {
            InitializeComponent();
        }

        #region Constructor
        private ILOMCTL00404 controller;
        public ILOMCTL00404 Controller
        {
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
            get { return controller; }

        }
        public DateTime nextSettlementdate { get; set; }
        DateTime lastSettlementdate;
        #endregion

        #region Event
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                timer1.Start();
                lblStatus.Text = "Process....please wait";

                DateTime BlAutoPayRunDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("BLMonthlyAutoPay"), CurrentUserEntity.BranchCode, true });
                nextSettlementdate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("NextSettlementDate"), CurrentUserEntity.BranchCode, true });
                lastSettlementdate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("LastSettlementDate"), CurrentUserEntity.BranchCode, true });
                //DateTime DailyIntCalculationDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("BLoansDailyIntCalDate"), CurrentUserEntity.BranchCode, true });
                DateTime LFVoucherDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("BLoansLFVoucherDate"), CurrentUserEntity.BranchCode, true });

                if (LFVoucherDate.Date >= lastSettlementdate.Date && LFVoucherDate.Date <= nextSettlementdate.Date)
                {
                    //2017-07-19 11:50:15.860
                    //if (BlAutoPayRunDate.Year == DateTime.Now.Year && BlAutoPayRunDate.Month == DateTime.Now.Month && BlAutoPayRunDate.Day == DateTime.Now.AddDays(-1).Day lastSettlementdate)

                    if (!BlAutoPayRunDate.Date.Equals(lastSettlementdate.Date))//Updated by HWKO (23-Aug-2017)
                    {
                        string str = this.controller.BusinessLoansMonthlyAutoPaymentProc(CurrentUserEntity.BranchCode, CurrentUserEntity.CurrentUserID, CurrentUserEntity.CurrentUserName);
                        if (str == "0")
                        {
                            timer1.Stop();
                            BLAutoPayRunProgress.Value = 100;
                            lblStatus.Text = "Process completed successfully";
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90124);//Business Loan Auto Payment Process is successfully finished.

                            BLAutoPayRunProgress.Value = 0;
                            lblStatus.Text = "";
                        }
                        if (str == "-2")
                        {
                            timer1.Stop();
                            BLAutoPayRunProgress.Value = 100;
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90171);//Already Run Business Loan Auto Payment Process!.

                            BLAutoPayRunProgress.Value = 0;
                            lblStatus.Text = "";
                        }
                        if (str == "-3")
                        {
                            timer1.Stop();
                            BLAutoPayRunProgress.Value = 0;
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90172);//No Records to run Business Loan Monthly Auto Payment Process!

                            BLAutoPayRunProgress.Value = 0;
                            lblStatus.Text = "";
                        }
                    }
                    else
                    {
                        timer1.Stop();
                        BLAutoPayRunProgress.Value = 100;
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90171);//Business Loan Auto Payment Process is already Calculated!.//

                        BLAutoPayRunProgress.Value = 0;
                        lblStatus.Text = "";
                    }
                }
                else
                {
                    timer1.Stop();
                    BLAutoPayRunProgress.Value = 100;
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90198);//Please Run Business Loans LateFee Auto Voucher Process Firstly!

                    BLAutoPayRunProgress.Value = 0;
                    lblStatus.Text = "";
                }
                //}
                //else
                //{
                //    timer1.Stop();
                //    BLAutoPayRunProgress.Value = 100;
                //    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90177);//Please Run Business Loans Daily Interest Calculation Process Firstly!.

                //    BLAutoPayRunProgress.Value = 0;
                //    lblStatus.Text = "";
                //}
            }
            catch (Exception ex)
            {
                timer1.Stop();
                BLAutoPayRunProgress.Value = 0;
                lblStatus.Text = "Process fail";
                //Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90172);//No Records to run Busiess loan monthly auto payment process!
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(ex.InnerException.InnerException.ToString());//No Records to run Busiess loan monthly auto payment process!

                BLAutoPayRunProgress.Value = 0;
                lblStatus.Text = "";
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LOMVEW00404_Load(object sender, EventArgs e)
        {
                // Updated By ZMS (20/12/17) to check BLAutoPay already run
                DateTime blLFdate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("BL_LF_AutoVoucher"), CurrentUserEntity.BranchCode, true });

                #region Old_Code_Valid (CommentByHMW)
                //if (blLFdate.Year == DateTime.Now.Year && blLFdate.Month == DateTime.Now.Month && blLFdate.Day == DateTime.Now.Day)
                //{
                //    //can run Auto Pay Process
                //}
                //else
                //{
                //    BLAutoPayRunProgress.Value = 0; this.btnProcess.Enabled = false;
                //    this.lblStatus.Text = "Please do Business Loans Latefee Auto Payment Process First!";
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

                if (blLFdate.Year == startDTO.Date.Year && blLFdate.Month == startDTO.Date.Month && blLFdate.Day == startDTO.Date.Day)
                {
                    if (Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC00022) == System.Windows.Forms.DialogResult.No)
                    {
                        //can run Auto Pay Process
                        lblDateTime.Text = startDTO.Date.ToString("dd-MM-yyyy");
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else
                {
                    BLAutoPayRunProgress.Value = 0;
                    this.btnProcess.Enabled = false;
                    this.lblStatus.Text = "Please Run ''Business Loan Late Fee Auto Payment Process'' First!";
                }
                            
            #endregion
        }
        #endregion
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (BLAutoPayRunProgress.Value > 97) return;

            BLAutoPayRunProgress.Value += 2;
        }
    }
}
