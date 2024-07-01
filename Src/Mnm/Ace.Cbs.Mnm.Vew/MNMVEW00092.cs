using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Microsoft.Reporting.WinForms;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Utt;
using System.IO;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00092 : BaseForm
    {
        #region Property

        public bool IsReversal { get; set; }
        public bool IsSourceCurrency { get; set; }
        IList<MNMDTO00010> trialDetailList { get; set; }
        IList<MNMDTO00010> List { get; set; }
        public string FormName { get; set; }
        public string BranchNo { get; set; }
        public string Currency { get; set; }
        public string Month { get; set; }
        public decimal creditotal = 0;
        public decimal debittotal = 0;
        public IMNMCTL00092 Controller { get; set; }

        #endregion

        #region constructors
        public MNMVEW00092()
        {
            InitializeComponent();
        }

        public MNMVEW00092(IList<MNMDTO00010> trialList, string branchno, string cur, string formName, string month)
        {
            this.trialDetailList = trialList;
            this.Currency = cur.Replace("KYT","MMK");//Updated by HWKO (25-Sep-2017)
            this.BranchNo = branchno;
            this.FormName = formName;
            this.Month = month;
            InitializeComponent();
        }
        #endregion

        private void MNMVEW00092_Load(object sender, EventArgs e)
        {
            //this.Text = "Trial Balance Group Listing";
            this.Text = this.FormName;

            if (trialDetailList.Count > 0)
            {
                MNMDTO00010 trialDetailDTO = new MNMDTO00010();
                if (this.Currency == string.Empty) trialDetailDTO.CUR = "By Home Currency";
                else trialDetailDTO.CUR = this.Currency;
                if (this.BranchNo == string.Empty) trialDetailDTO.DCODE = "By All Branches";
                else trialDetailDTO.DCODE = this.BranchNo;


                Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });

                rpvTriBalanceGroup.LocalReport.DataSources.Clear();
                ReportParameter[] para = new ReportParameter[14];
                para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
                para[1] = new ReportParameter("BranchName", Branch.Address);
                para[2] = new ReportParameter("Phone", Branch.Phone);
                para[3] = new ReportParameter("Fax", Branch.Fax);
                para[11] = new ReportParameter("BrCode", Branch.BranchCode);
                para[12] = new ReportParameter("Br_Alias", Branch.BranchAlias);

                //Commented by HWKO (31-Oct-2017)
                //Image img = null;
                //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                //{
                //    img = System.Drawing.Image.FromStream(stream);

                //    img.Save(tempFilePath);
                //}

                string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

                para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                para[5] = new ReportParameter("Head", this.Text);
                para[6] = new ReportParameter("cur", trialDetailDTO.CUR.Replace("KYT", "MMK"));//Updated by HWKO (25-Sep-2017)
                para[7] = new ReportParameter("branchno", trialDetailDTO.DCODE);

                IList<MNMDTO00010> transactionlist = new List<MNMDTO00010>();
                foreach (MNMDTO00010 data in this.trialDetailList)
                {
                    MNMDTO00010 list = new MNMDTO00010();

                    if (data.ACTYPE == "I" && data.COAamount < 0 || data.ACTYPE == "L" && data.COAamount < 0 || data.ACTYPE == "A" && data.COAamount > 0 || data.ACTYPE == "E" && data.COAamount > 0)
                    {
                        list.DebitAmount = data.COAamount;
                    }

                    else if (data.ACTYPE == "I" && data.COAamount > 0 || data.ACTYPE == "L" && data.COAamount > 0 || data.ACTYPE == "A" && data.COAamount < 0 || data.ACTYPE == "E" && data.COAamount < 0)
                    {
                        list.CreditAmount = data.COAamount;
                    }

                    list.ACODE = data.ACODE;
                    list.ACNAME = data.ACNAME;

                    if (list.CreditAmount < 0)
                    {
                        list.CreditAmount = Convert.ToDecimal(list.CreditAmount.ToString().Replace('-', '+'));
                    }
                    else if (list.DebitAmount < 0)
                    {
                        list.DebitAmount = Convert.ToDecimal(list.DebitAmount.ToString().Replace('-', '+'));
                    }

                    creditotal += list.CreditAmount;
                    debittotal += list.DebitAmount;

                    transactionlist.Add(list);
                }

                para[8] = new ReportParameter("TotalRecords", transactionlist.Count.ToString());
                para[9] = new ReportParameter("TotalCredit", creditotal.ToString());
                para[10] = new ReportParameter("TotalDebit", debittotal.ToString());

                DateTime systemDate = this.Controller.GetSystemDate(CurrentUserEntity.BranchCode);
                para[13] = new ReportParameter("SelectedDate", systemDate.ToString("dd/MM/yyyy"));

                this.rpvTriBalanceGroup.LocalReport.EnableExternalImages = true;
                rpvTriBalanceGroup.LocalReport.SetParameters(para);

                ReportDataSource dataset = new ReportDataSource("TrialGroup", transactionlist);
                rpvTriBalanceGroup.LocalReport.DataSources.Add(dataset);
                dataset.Value = transactionlist;

                this.rpvTriBalanceGroup.RefreshReport();
                this.rpvTriBalanceGroup.RefreshReport();

            }
            else
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
            }
        }       

    }
}
