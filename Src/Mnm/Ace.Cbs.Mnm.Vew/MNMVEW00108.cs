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
    public partial class MNMVEW00108 : BaseForm
    {
        IList<MNMDTO00035> FReceiptList { get; set; }
        public string acctno { get; set; }
        public string name { get; set; }
        public decimal total { get; set; }

        public MNMVEW00108()
        {
            InitializeComponent();
        }


        public MNMVEW00108(IList<MNMDTO00035> freceiptList)
        {
            this.FReceiptList = freceiptList;
           
            InitializeComponent();
        }


        private void MNMVEW00108_Load(object sender, EventArgs e)
        {
            this.Text = "Fixed Deposit Balance For AccountNo. " + this.FReceiptList[0].AcctNo;
            Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });

            rptFixedReceiptListing.LocalReport.DataSources.Clear();
            ReportParameter[] para = new ReportParameter[12];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);
            para[10] = new ReportParameter("BrCode", Branch.BranchCode);
            para[11] = new ReportParameter("Br_Alias", Branch.Bank_Alias);


            Image img = null;
            string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            {
                img = System.Drawing.Image.FromStream(stream);

                img.Save(tempFilePath);
            }

            para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            para[5] = new ReportParameter("Head", this.Text);
            para[6] = new ReportParameter("TotalRecords", this.FReceiptList.Count.ToString());
            para[7] = new ReportParameter("acctno", this.FReceiptList[0].AcctNo);
            para[8] = new ReportParameter("name", this.FReceiptList[0].Name);


            IList<MNMDTO00035> transactionlist = new List<MNMDTO00035>();
            foreach (MNMDTO00035 freceiptdto in FReceiptList)
            {
                MNMDTO00035 linkAC = new MNMDTO00035();
                linkAC.Rno = freceiptdto.Rno;
                linkAC.Rdate = freceiptdto.Rdate;
                linkAC.MatureDate = freceiptdto.MatureDate;
                linkAC.Duration = freceiptdto.Duration;
                linkAC.Cbal = freceiptdto.Cbal;
                total += linkAC.Cbal;
                transactionlist.Add(linkAC);

            }
            para[9] = new ReportParameter("Total",total.ToString() );

            this.rptFixedReceiptListing.LocalReport.EnableExternalImages = true;
            rptFixedReceiptListing.LocalReport.SetParameters(para);

            ReportDataSource dataset = new ReportDataSource("FixedReceiptDS", transactionlist);
            rptFixedReceiptListing.LocalReport.DataSources.Add(dataset);
            dataset.Value = transactionlist;

            this.rptFixedReceiptListing.RefreshReport();
            this.rptFixedReceiptListing.RefreshReport();
        }


    }
}
