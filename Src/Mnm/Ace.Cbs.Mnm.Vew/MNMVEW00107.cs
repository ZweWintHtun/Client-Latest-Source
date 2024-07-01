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
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00107 : BaseForm
    {
        IList<PFMDTO00021> fixedDepositList { get; set; }

        private string formName = string.Empty;
        public string FormName
        {
            get { return this.formName; }
            set { this.formName = value; }
        }

        private DateTime sdate;
        public DateTime SDate
        {
            get { return this.sdate; }
            set { this.sdate = value; }
        }

        private DateTime edate;
        public DateTime EDate
        {
            get { return this.edate; }
            set { this.edate = value; }
        }

        //private DateTime sDate;
        //private DateTime eDate;

        public MNMVEW00107()
        {
            InitializeComponent();
        }

        public MNMVEW00107(IList<PFMDTO00021> fixedList,string formName)
        {
            this.fixedDepositList = fixedList;
            this.FormName = formName;
            InitializeComponent();
        }

        public MNMVEW00107(IList<PFMDTO00021> fixedList, string formName, DateTime sdate, DateTime edate)
        {
            this.fixedDepositList = fixedList;
            this.FormName = formName;
            this.SDate = sdate;
            this.EDate = edate;
            InitializeComponent();
        }


        private void MNMVEW00107_Load(object sender, EventArgs e)
        {
            this.Text = "Listing of " + this.FormName + " From ";
            Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });

            rptFixedDepositAll.LocalReport.DataSources.Clear();
            ReportParameter[] para = new ReportParameter[11];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);
            para[7] = new ReportParameter("BrCode", Branch.BranchCode);
            para[8] = new ReportParameter("Br_Alias", Branch.Bank_Alias);
            para[9] = new ReportParameter("SDate", SDate.ToShortDateString());
            para[10] = new ReportParameter("EDate", EDate.ToShortDateString());

            Image img = null;
            string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            {
                img = System.Drawing.Image.FromStream(stream);

                img.Save(tempFilePath);
            }

            para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            para[5] = new ReportParameter("Head", this.Text);
            para[6] = new ReportParameter("TotalRecords", this.fixedDepositList.Count.ToString());

            this.rptFixedDepositAll.LocalReport.EnableExternalImages = true;
            rptFixedDepositAll.LocalReport.SetParameters(para);

            ReportDataSource dataset = new ReportDataSource("FixedDeposit_AllDS", fixedDepositList);
            rptFixedDepositAll.LocalReport.DataSources.Add(dataset);
            dataset.Value = fixedDepositList;

            this.rptFixedDepositAll.RefreshReport();
            this.rptFixedDepositAll.RefreshReport();      
        }
    }
}
