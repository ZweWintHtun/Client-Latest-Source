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
using Ace.Cbs.Cx.Cle;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.Utt;
using Microsoft.Reporting.WinForms;
using System.IO;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00052 : BaseForm
    {

        IList<LOMDTO00035> DataList { get; set; }
        string Currency { get; set; }
        string SourceBranch { get; set; }
        string head { get; set; }
        string RequiredYear { get; set; }
        string RequiredMonth { get; set; }

        public LOMVEW00052()
        {
            InitializeComponent();
        }

        public LOMVEW00052(IList<LOMDTO00035> dataList, string currency, string sourceBranch, string header,string year,string month)
        {
            this.Text = header;
            this.head = header;
            this.DataList = dataList;
            this.Currency = currency;
            this.SourceBranch = sourceBranch;
            this.RequiredYear = year;
            this.RequiredMonth = month;
            InitializeComponent();
        }

        private void LOMVEW00052_Load(object sender, EventArgs e)
        {
            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            this.rpvExpLoans.LocalReport.DataSources.Clear();

            ReportParameter[] para = new ReportParameter[12];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);
            para[7] = new ReportParameter("Br_Alias", Branch.Bank_Alias);

            Image img = null;
            string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            {
                img = System.Drawing.Image.FromStream(stream);
                img.Save(tempFilePath);
            }

            para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            para[5] = new ReportParameter("Title", this.head);
            para[8] = new ReportParameter("TotalRecords", Convert.ToString(DataList.Count));
            para[6] = new ReportParameter("BrCode", this.SourceBranch);
            para[9] = new ReportParameter("Currency", this.Currency);
            para[10] = new ReportParameter("RequiredYear", this.RequiredYear);
            para[11] = new ReportParameter("RequiredMonth", this.RequiredMonth);

            this.rpvExpLoans.LocalReport.EnableExternalImages = true;
            this.rpvExpLoans.LocalReport.SetParameters(para);
            this.rpvExpLoans.RefreshReport();

            ReportDataSource dataset = new ReportDataSource("DSLOMRDLC00007", this.DataList);
            this.rpvExpLoans.LocalReport.DataSources.Add(dataset);
            dataset.Value = this.DataList;
            this.rpvExpLoans.LocalReport.Refresh();

            this.rpvExpLoans.RefreshReport();
        }
    }
}
