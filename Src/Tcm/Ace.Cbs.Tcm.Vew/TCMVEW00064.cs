using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Cx.Cle;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Tcm.Ctr.Sve;
using Microsoft.Reporting.WinForms;
using System.IO;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Tcm.Vew
{
    public partial class TCMVEW00064 : BaseForm
    {
        public TCMVEW00064()
        {
            InitializeComponent();
        }

        public TCMVEW00064(IList<TLMDTO00018> loans)
        {
            InitializeComponent();
            this.Loans = loans;
        }

        public IList<TLMDTO00018> Loans { get; set; }

        private void TCMVEW00064_Load(object sender, EventArgs e)
        {
            Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            IList<TLMDTO00018> list = this.Loans;
            rpvInsurance.LocalReport.DataSources.Clear();
            ReportParameter[] para = new ReportParameter[8];
            para[0] = new ReportParameter("BankName", Branch.BranchDescription);
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
            para[7] = new ReportParameter("TotalRecords", list.Count.ToString());
            this.rpvInsurance.LocalReport.EnableExternalImages = true;
            rpvInsurance.LocalReport.SetParameters(para);
            ReportDataSource dataset = new ReportDataSource("Loan_DataSet", list);
            rpvInsurance.LocalReport.DataSources.Add(dataset);
            dataset.Value = list;
            this.rpvInsurance.RefreshReport();

        }

        //private void TCMVEW00064_Load(object sender, EventArgs e)
        //{
        //    Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
        //    IList<TLMDTO00018> list = this.Loans;
        //    rpvInsurance.LocalReport.DataSources.Clear();
        //    ReportParameter[] para = new ReportParameter[6];
        //    para[0] = new ReportParameter("BankName", Branch.BranchDescription);
        //    para[1] = new ReportParameter("BranchName", Branch.Address);
        //    para[2] = new ReportParameter("Phone", Branch.Phone);
        //    para[3] = new ReportParameter("Fax", Branch.Fax);
        //    Image img = null;
        //    string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
        //    using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
        //    {
        //        img = System.Drawing.Image.FromStream(stream);

        //        img.Save(tempFilePath);
        //    }

        //    para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
        //    para[5] = new ReportParameter("TotalRecords", list.Count.ToString());
        //    this.rpvInsurance.LocalReport.EnableExternalImages = true;
        //    rpvInsurance.LocalReport.SetParameters(para);
        //    ReportDataSource dataset = new ReportDataSource("Loan_DataSet", list);
        //    rpvInsurance.LocalReport.DataSources.Add(dataset);
        //    dataset.Value = list;
        //    this.rpvInsurance.RefreshReport();

        //}
    }
}
