using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Sam.Ctr.PTR;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Ace.Windows.Core.Utt;
using System.IO;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Dmd;
using Microsoft.Reporting.WinForms;



namespace Ace.Cbs.Sam.Vew
{
    public partial class SAMVEW00056 : BaseForm
    {       

        public SAMVEW00056()
        {
            InitializeComponent();
        }

        public SAMVEW00056(IList<PFMDTO00004> occupationList)
        {
            this.OccupationList = occupationList;
            InitializeComponent();
        }

        private IList<PFMDTO00004> OccupationList { get; set; }

        private void SAMVEW00056_Load(object sender, EventArgs e)
        {
            try
            {
                BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                this.rptOccupation.LocalReport.DataSources.Clear();
                ReportParameter[] para = new ReportParameter[9];
                para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
                para[1] = new ReportParameter("BranchName", Branch.Address);
                para[2] = new ReportParameter("Phone", Branch.Phone);
                para[3] = new ReportParameter("Fax", Branch.Fax);
                para[4] = new ReportParameter("BrCode", Branch.BranchCode);
                para[5] = new ReportParameter("Br_Alias", Branch.Bank_Alias);
                Image img = null;
                string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                {
                    img = System.Drawing.Image.FromStream(stream);
                    img.Save(tempFilePath);
                }
                para[6] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                para[7] = new ReportParameter("ReportTitle", this.Text);
                para[8] = new ReportParameter("TotalRecords", this.OccupationList.Count.ToString());
                this.rptOccupation.LocalReport.EnableExternalImages = true;
                this.rptOccupation.LocalReport.SetParameters(para);

                ReportDataSource dataset = new ReportDataSource("Occupation_DataSet", this.OccupationList);
                this.rptOccupation.LocalReport.DataSources.Add(dataset);
                dataset.Value = this.OccupationList;

                this.rptOccupation.LocalReport.Refresh();
                this.rptOccupation.RefreshReport();
            }
            catch (Exception ex)
            { }
        }

        private void SAMVEW00056_FormClosing(object sender, FormClosingEventArgs e)
        {
            rptOccupation.LocalReport.ReleaseSandboxAppDomain();
        }

       

       

      
    }
}
