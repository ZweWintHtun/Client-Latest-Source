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
    public partial class MNMVEW00131 : BaseForm
    {
        IList<MNMDTO00035> FDurationList { get; set; }
        public string Duration { get; set; }
        public decimal total { get; set; }

        public MNMVEW00131()
        {
            InitializeComponent();
        }


        public MNMVEW00131(IList<MNMDTO00035> fdurationList,string duration)
        {
            this.FDurationList = fdurationList;
            Duration = duration;

            InitializeComponent();
        }


        private void MNMVEW00131_Load(object sender, EventArgs e)
        {
            this.Text = "Fixed Deposit Listing For Duration " + Duration;
            Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });

            rptFixedDuration.LocalReport.DataSources.Clear();
            ReportParameter[] para = new ReportParameter[10];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);
            para[8] = new ReportParameter("BrCode", Branch.BranchCode);
            para[9] = new ReportParameter("Br_Alias", Branch.BranchAlias);


            Image img = null;
            string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            {
                img = System.Drawing.Image.FromStream(stream);

                img.Save(tempFilePath);
            }

            para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            para[5] = new ReportParameter("Head", this.Text);
            para[6] = new ReportParameter("TotalRecords", this.FDurationList.Count.ToString());
                    

            IList<MNMDTO00035> transactionlist = new List<MNMDTO00035>();
            foreach (MNMDTO00035 fdurationdto in FDurationList)
            {
                MNMDTO00035 linkAC = new MNMDTO00035();
                linkAC.AcctNo = fdurationdto.AcctNo;
                linkAC.Name = fdurationdto.Name;
                linkAC.Rno = fdurationdto.Rno;
                linkAC.Rdate = fdurationdto.Rdate;
                linkAC.MatureDate = fdurationdto.MatureDate;
                linkAC.Cbal = fdurationdto.Cbal;
                total += linkAC.Cbal;
                transactionlist.Add(linkAC);

            }
            para[7] = new ReportParameter("Total", total.ToString());

            this.rptFixedDuration.LocalReport.EnableExternalImages = true;
            rptFixedDuration.LocalReport.SetParameters(para);

            ReportDataSource dataset = new ReportDataSource("FixedDurationDS", transactionlist);
            rptFixedDuration.LocalReport.DataSources.Add(dataset);
            dataset.Value = transactionlist;

            this.rptFixedDuration.RefreshReport();
            this.rptFixedDuration.RefreshReport();
        }


    }
}
