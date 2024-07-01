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
    public partial class LOMVEW00403 : BaseForm, ILOMVEW00403
    {
        #region Constructor
        public LOMVEW00403()
        {
            InitializeComponent();
        }
        #endregion

        #region Controller
        private ILOMCTL00403 controller;
        public ILOMCTL00403 Controller
        {
            get { return controller; }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }
        public DateTime lastSettlementdate { get; set; }
        public DateTime nextSettlementdate { get; set; }
        #endregion

        #region Event
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                timer1.Start();
                lblStatus.Text = "Process....please wait";
                lastSettlementdate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("LastSettlementDate"), CurrentUserEntity.BranchCode, true });
                DateTime BlAutoPayRunDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("BLMonthlyAutoPay"), CurrentUserEntity.BranchCode, true });
                DateTime BlLateFeeAutoRunDate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("BLLateFeesAutoRun"), CurrentUserEntity.BranchCode, true });
                nextSettlementdate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("NextSettlementDate"), CurrentUserEntity.BranchCode, true });

                if (lastSettlementdate.Year == DateTime.Now.Year && lastSettlementdate.Month == DateTime.Now.Month && lastSettlementdate.Day == DateTime.Now.Day)
                {
                    if (BlAutoPayRunDate.Year == DateTime.Now.Year && BlAutoPayRunDate.Month == DateTime.Now.Month && BlAutoPayRunDate.Day == DateTime.Now.Day)
                    {
                        //if (BlLateFeeAutoRunDate.Year == DateTime.Now.Year && BlLateFeeAutoRunDate.Month == DateTime.Now.Month && BlLateFeeAutoRunDate.Day == DateTime.Now.AddDays(-1).Day)

                        if (!BlLateFeeAutoRunDate.Date.Equals(lastSettlementdate.Date))//Updated by HWKO (23-Aug-2017)
                        {
                            string str = this.controller.BusinessLoansLateFeesCalculationProcess(CurrentUserEntity.BranchCode, CurrentUserEntity.CurrentUserID, CurrentUserEntity.CurrentUserName);
                            if (str == "0")
                            {
                                timer1.Stop();
                                BLLateFeeAutoRunProgress.Value = 100;
                                lblStatus.Text = "Process completed successfully";
                                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90125);//Business Loan Late Fees Calculation Process is successfully finished!

                                BLLateFeeAutoRunProgress.Value = 0;
                                lblStatus.Text = "";
                            }
                            else if (str == "1")
                            {
                                timer1.Stop();
                                BLLateFeeAutoRunProgress.Value = 100;
                                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90165);//Please Run Business Loan Auto Payment Process Firstly!.

                                BLLateFeeAutoRunProgress.Value = 0;
                                lblStatus.Text = "";
                            }
                            else if (str == "2")
                            {
                                timer1.Stop();
                                BLLateFeeAutoRunProgress.Value = 100;
                                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90166);//Please Run Cut Off Process Firstly!.

                                BLLateFeeAutoRunProgress.Value = 0;
                                lblStatus.Text = "";
                            }
                            else if (str == "3")
                            {
                                timer1.Stop();
                                BLLateFeeAutoRunProgress.Value = 100;
                                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90183);//Late Fee Calculation Already Calculated!.  

                                BLLateFeeAutoRunProgress.Value = 0;
                                lblStatus.Text = "";
                            }
                            else //str == "-1" // Updated by HWKO (30-Aug-2017)
                            {
                                timer1.Stop();
                                BLLateFeeAutoRunProgress.Value = 100;
                                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90180);//There is no late fees in this date!.  

                                BLLateFeeAutoRunProgress.Value = 0;
                                lblStatus.Text = "";
                            }
                        }
                        else
                        {
                            timer1.Stop();
                            BLLateFeeAutoRunProgress.Value = 100;
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90183);//BL Late Fee Calculation Already Calculated!.  

                            BLLateFeeAutoRunProgress.Value = 0;
                            lblStatus.Text = "";
                        }
                    }
                    else
                    {  
                        timer1.Stop();
                        BLLateFeeAutoRunProgress.Value = 100;
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90165);//Please Run Business Loan Auto Payment Process Firstly!.

                        BLLateFeeAutoRunProgress.Value = 0;
                        lblStatus.Text = "";
                    }
                }
                else
                {
                    timer1.Stop();
                    BLLateFeeAutoRunProgress.Value = 100;
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90166);//Please Run Cut Off Process Firstly!.

                    BLLateFeeAutoRunProgress.Value = 0;
                    lblStatus.Text = "";
                }
            }
            catch (Exception ex)
            {
                timer1.Stop();
                BLLateFeeAutoRunProgress.Value = 0;
                lblStatus.Text = "Process fail";
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90168);//Business Loans Late Fees Calculation Fail!

                BLLateFeeAutoRunProgress.Value = 0;
                lblStatus.Text = "";
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (BLLateFeeAutoRunProgress.Value > 97) return;

            BLLateFeeAutoRunProgress.Value += 2;
        }
    }
}
