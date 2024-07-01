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
    public partial class LOMVEW00418 : BaseForm, ILOMVEW00418
    {
        string eno = "";
        public LOMVEW00418()
        {
            InitializeComponent();
        }

        private ILOMCTL00418 controller;
        public ILOMCTL00418 Controller
        {
            get { return controller; }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }

        private void LOMVEW00418_Load(object sender, EventArgs e)
        {
            DateTime lastSettlementdate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("LastSettlementDate"), CurrentUserEntity.BranchCode, true });

            #region Old_Code_Valid (CommentByHMW)
            //lblDateTime.Text = DateTime.Now.ToString("dd-MM-yyyy");
            //if (lastSettlementdate.Year == DateTime.Now.Year && lastSettlementdate.Month == DateTime.Now.Month && lastSettlementdate.Day == DateTime.Now.Day)
            //{
            //    //can run Auto Pay Process                
            //}
            //else
            //{
            //    BLLateFeesAutoVocherProgress.Value = 0;
            //    this.btnProcess.Enabled = false; 
            //    this.lblStatus.Text = "Please do System Cut Off Process First!";
            //}
            #endregion

            #region Seperating EOD Process (By HMW at 29-07-2019)
            //Getting Next Settlement Date
            DateTime nextSettlementdate = CXCOM00011.Instance.GetScalarObject<DateTime>("Sys001.SelectSettlementDate", new object[] { CXCOM00007.Instance.GetValueByKeyName("NextSettlementDate"), CurrentUserEntity.BranchCode, true });

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

            if (lastSettlementdate.Year == startDTO.Date.Year && lastSettlementdate.Month == startDTO.Date.Month && lastSettlementdate.Day == startDTO.Date.Day)
            {
                //can run Auto Pay Process
            }
            else if (nextSettlementdate.Year == startDTO.Date.Year && nextSettlementdate.Month == startDTO.Date.Month && nextSettlementdate.Day == startDTO.Date.Day)
            {
                BLLateFeesAutoVocherProgress.Value = 0;
                this.btnProcess.Enabled = false;
                this.lblStatus.Text = "Please ''Cut Off'' First!";//Please do System Cut Off Process First!
            }
            else
            {
                BLLateFeesAutoVocherProgress.Value = 0;
                this.btnProcess.Enabled = false;
                this.lblStatus.Text = "Please check the ''System Date'' and ''Settlement Date'' First!";
            }
            #endregion

        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                this.Enabled = false;// Added By AAM (16_July_2018)
                timer1.Start();
                lblStatus.Text = "Process....please wait";
                string str = this.controller.BusinessLoansLateFeesAutoPayVoucherProcess(eno, CurrentUserEntity.BranchCode, CurrentUserEntity.CurrentUserID, CurrentUserEntity.CurrentUserName);
                if (str == "0")
                {
                    timer1.Stop();
                    BLLateFeesAutoVocherProgress.Value = 100;
                    lblStatus.Text = "Process completed successfully";
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90195);//Business Loans Late Fees Auto Voucher Process is successfully finshed!

                    BLLateFeesAutoVocherProgress.Value = 0;
                    lblStatus.Text = "";
                }
                else if (str == "-2")
                {
                    timer1.Stop();
                    BLLateFeesAutoVocherProgress.Value = 0;
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90196);//Already Run Business Loans Late Fees Auto Voucher Process!  

                    BLLateFeesAutoVocherProgress.Value = 0;
                    lblStatus.Text = "";
                }
                else //if str == "-1"
                {
                    timer1.Stop();
                    BLLateFeesAutoVocherProgress.Value = 0;
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90197);//Business Loans Late Fees Auto Voucher Process is failed!

                    BLLateFeesAutoVocherProgress.Value = 0;
                    lblStatus.Text = "";
                }

                this.Enabled = true;// Added By AAM (16_July_2018)
            }
            catch (Exception ex)
            {
                timer1.Stop();
                BLLateFeesAutoVocherProgress.Value = 0;
                lblStatus.Text = "Process fail";

                BLLateFeesAutoVocherProgress.Value = 0;
                lblStatus.Text = "";

                this.Enabled = true;// Added By AAM (16_July_2018)
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (BLLateFeesAutoVocherProgress.Value > 97) return;

            BLLateFeesAutoVocherProgress.Value += 2;
        }
        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }
    }
}

