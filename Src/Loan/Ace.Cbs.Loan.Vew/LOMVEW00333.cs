using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Microsoft.Reporting.WinForms;
using Ace.Windows.Core.Utt;
using System.IO;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tcm.Ctr.Dao;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Windows.CXClient;
using Ace.Cbs.Loan.Ctr.Sve;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00333 : BaseForm
    {
        IList<LOMDTO00311> DataList { get; set; }
        string Currency { get; set; }
        string SourceBranch { get; set; }
        string head { get; set; }        

        public LOMVEW00333()
        {
            InitializeComponent();
        }

        public LOMVEW00333(IList<LOMDTO00311> dataList, string currency,
            string sourceBranch, string header)
        {
            this.Text = header.Replace("KYT", "MMK");
            this.head = header.Replace("KYT", "MMK");
            this.DataList = dataList;
            this.Currency = currency.Replace("KYT", "MMK");
            this.SourceBranch = sourceBranch;            
            InitializeComponent();
        }

        private void LOMVEW00333_Load(object sender, EventArgs e)
        {
            string SystemDate;

            this.Text = head;

            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            TCMDTO00001 StartDTO = CXClientWrapper.Instance.Invoke<ICXSVE00006, TCMDTO00001>(x => x.SelectStartBySourceBr(CurrentUserEntity.BranchCode));                        
            SystemDate = StartDTO.Date.ToString("dd MMMM, yyyy");
            

            this.rpvPLLFOstdListing.LocalReport.DataSources.Clear();

            ReportParameter[] para = new ReportParameter[11];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);
            para[4] = new ReportParameter("Br_Alias", Branch.BranchAlias);
            para[5] = new ReportParameter("BrCode", this.SourceBranch);
            para[6] = new ReportParameter("Title", this.head);
            para[7] = new ReportParameter("Currency", this.Currency);
            para[8] = new ReportParameter("TotalRecords", Convert.ToString(DataList.Count));
            

            //Commented by HWKO (31-Oct-2017)
            //Image img = null;
            //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            //{
            //    img = System.Drawing.Image.FromStream(stream);
            //    img.Save(tempFilePath);
            //}

            string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

            para[9] = new ReportParameter("BankLogo", "file:////" + tempFilePath);


            para[10] = new ReportParameter("System_Date", SystemDate);

            this.rpvPLLFOstdListing.LocalReport.EnableExternalImages = true;
            this.rpvPLLFOstdListing.LocalReport.SetParameters(para);
            this.rpvPLLFOstdListing.RefreshReport();

            ReportDataSource dataset = new ReportDataSource("DSLOMRDLC00057", this.DataList);
            this.rpvPLLFOstdListing.LocalReport.DataSources.Add(dataset);
            dataset.Value = this.DataList;
            this.rpvPLLFOstdListing.LocalReport.Refresh();

            this.rpvPLLFOstdListing.RefreshReport();
        }


    }
}
