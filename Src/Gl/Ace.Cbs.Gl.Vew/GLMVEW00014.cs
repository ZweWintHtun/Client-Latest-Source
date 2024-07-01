using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Mnm.Dmd;
using System.IO;
using Microsoft.Reporting.WinForms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Gl.Vew
{
    public partial class GLMVEW00014 : BaseDockingForm
    {
        public IList<MNMDTO00037> DTOList { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string Currency { get; set; }

        public GLMVEW00014()
        {
            InitializeComponent();
        }
        public GLMVEW00014(IList<MNMDTO00037> DTOreport, DateTime startDate, DateTime endDate, string currency)
        {
            DTOList = DTOreport;
            StartDate = startDate;
            EndDate = endDate;  
            Currency = currency;                   
            InitializeComponent();
        }

        private void GLMVEW00014_Load(object sender, EventArgs e)
        {
            Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });

            rpvOLSTotalListing.LocalReport.DataSources.Clear();
            ReportParameter[] para = new ReportParameter[8];
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
            para[5] = new ReportParameter("StartDate", StartDate.ToString("dd/MM/yyyy"));
            para[6] = new ReportParameter("EndDate", EndDate.ToString("dd/MM/yyyy"));
            para[7] = new ReportParameter("Currency", Currency);

            this.rpvOLSTotalListing.LocalReport.EnableExternalImages = true;
            this.rpvOLSTotalListing.LocalReport.SetParameters(para);
            ReportDataSource dataset = new ReportDataSource("GLMDS00014", DTOList);
            this.rpvOLSTotalListing.LocalReport.DataSources.Add(dataset);
            dataset.Value = DTOList;
            this.rpvOLSTotalListing.RefreshReport();
        }
    }
}
