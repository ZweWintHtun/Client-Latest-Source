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
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Mnm.Dmd.DTO;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00119 : BaseForm
    {
        IList<MNMDTO00039> DataList { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string Currency { get; set; }
        string SourceBranch { get; set; }
        string head { get; set; }

        public MNMVEW00119()
        {
            InitializeComponent();
        }

        public MNMVEW00119(IList<MNMDTO00039> dataList, string startDate, string endDate, string currency, string sourceBranch, string header)
        {
            InitializeComponent(); 

            this.Text = header;
            this.head = header;
            this.DataList = dataList;
            this.StartDate = Convert.ToDateTime(startDate);
            this.EndDate = Convert.ToDateTime(endDate);
            this.SourceBranch = sourceBranch;
            this.Currency = currency;            
        }

        private void MNMVEW00119_Load(object sender, EventArgs e)
        {
            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            this.rpvCustIDListing.LocalReport.DataSources.Clear();

            ReportParameter[] para = new ReportParameter[12];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);
      //    para[11] = new ReportParameter("BrCode", Branch.BranchCode);
            para[11] = new ReportParameter("Br_Alias", Branch.Bank_Alias);

            Image img = null;
            string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            {
                img = System.Drawing.Image.FromStream(stream);

                img.Save(tempFilePath);
            }

            para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            para[5] = new ReportParameter("StartDate", this.StartDate.ToString("dd MMM,yyyy"));
            para[6] = new ReportParameter("EndDate", this.EndDate.ToString("dd MMM,yyyy"));
            para[7] = new ReportParameter("Head", this.head);
            para[8] = new ReportParameter("Count", Convert.ToString(DataList.Count));
            para[9] = new ReportParameter("Currency", this.Currency);
            para[10] = new ReportParameter("SourceBranch", this.SourceBranch);
            this.rpvCustIDListing.LocalReport.EnableExternalImages = true;
            this.rpvCustIDListing.LocalReport.SetParameters(para);
            this.rpvCustIDListing.RefreshReport();
            ReportDataSource dataset = new ReportDataSource("MNMDS00039", this.DataList);
            this.rpvCustIDListing.LocalReport.DataSources.Add(dataset);
            dataset.Value = this.DataList;
            this.rpvCustIDListing.LocalReport.Refresh();

            this.rpvCustIDListing.RefreshReport();
        }

      
    }
}
