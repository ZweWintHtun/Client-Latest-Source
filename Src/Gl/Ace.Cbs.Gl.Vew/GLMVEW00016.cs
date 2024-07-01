using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Gl.Dmd;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Microsoft.Reporting.WinForms;
using Ace.Windows.Core.Utt;
using System.IO;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient.Controls;

namespace Ace.Cbs.Gl.Vew
{
    public partial class GLMVEW00016 : BaseDockingForm
    {
        IList<GLMDTO00001> formatFileList;
        string header;
        string formName;
        string reportFormat;

        public GLMVEW00016()
        {
            InitializeComponent();
        }
        public GLMVEW00016(IList<GLMDTO00001> formatFileList, string header, string reportFormat,string formName)
        {
            this.formatFileList = formatFileList;
            this.header = header;
            this.reportFormat = reportFormat;
            this.formName = formName;
            InitializeComponent();
        }

        private void GLMVEW00016_Load(object sender, EventArgs e)
        {
            this.Text = this.formName;
            foreach (GLMDTO00001 formatFile in formatFileList)
            {
                if (formatFile.AmountTotal == "N")
                    formatFile.Total = formatFile.CBal;
                else
                    formatFile.Amount = formatFile.CBal;
            }

            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            this.rpvReportStatement.LocalReport.DataSources.Clear();

            ReportParameter[] para = new ReportParameter[7];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);

            Image img = null;
            string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            {
                img = System.Drawing.Image.FromStream(stream);

                img.Save(tempFilePath);
            }

            para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            para[5] = new ReportParameter("Header", string.IsNullOrEmpty(this.header)?" ":this.header);
            switch (reportFormat)
            {
                case "AF": para[6] = new ReportParameter("ColumnVisible", "True"); break;   //Actual Figure
                case "BAF": para[6] = new ReportParameter("ColumnVisible", "False"); break; //Budgeted and Actual Figure
                default: para[6] = new ReportParameter("ColumnVisible","False"); break;  //Monthly Figure                    
            }

            this.rpvReportStatement.LocalReport.EnableExternalImages = true;
            this.rpvReportStatement.LocalReport.SetParameters(para);
            ReportDataSource dataset = new ReportDataSource("DS00004", formatFileList);
            this.rpvReportStatement.LocalReport.DataSources.Add(dataset);
            dataset.Value = formatFileList;
            
            this.rpvReportStatement.RefreshReport();
        }
    }
}
