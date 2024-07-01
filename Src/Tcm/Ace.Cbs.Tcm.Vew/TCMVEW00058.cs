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
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Tcm.Dmd;

namespace Ace.Cbs.Tcm.Vew
{
    public partial class TCMVEW00058 : BaseForm
    {
        IList<PFMDTO00042> ReceiptReverseInfoList { get; set; }
        public DateTime s_date { get; set; }
        public DateTime e_date { get; set; }

        public TCMVEW00058()
        {
            InitializeComponent();
        }


        public TCMVEW00058(IList<PFMDTO00042> RceiptList, DateTime startDate, DateTime endDate)
        {
            this.ReceiptReverseInfoList = RceiptList;
            this.s_date = startDate;
            this.e_date = endDate;
            InitializeComponent();
        }

        private void TCMVEW00058_Load(object sender, EventArgs e)
        {
             this.Text = "Clearing Receipt Reversal Listing";
            Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            
            rptClearingReceiptReverse.LocalReport.DataSources.Clear();
            ReportParameter[] para = new ReportParameter[11];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);
            para[9] = new ReportParameter("BrCode", Branch.BranchCode);
            para[10] = new ReportParameter("Br_Alias", Branch.Bank_Alias);


            Image img = null;
            string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            {
                img = System.Drawing.Image.FromStream(stream);

                img.Save(tempFilePath);
            }

            para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            para[5] = new ReportParameter("Head", this.Text);
            para[6] = new ReportParameter("TotalRecords",this.ReceiptReverseInfoList.Count.ToString() );
            para[7] = new ReportParameter("StartDate", this.s_date.ToString("dd/MM/yyyy"));
            para[8] = new ReportParameter("EndDate", this.e_date.ToString("dd/MM/yyyy"));
          
            this.rptClearingReceiptReverse.LocalReport.EnableExternalImages = true;
            rptClearingReceiptReverse.LocalReport.SetParameters(para);


            ReportDataSource dataset = new ReportDataSource("ReceiptReverseDS", ReceiptReverseInfoList);
            rptClearingReceiptReverse.LocalReport.DataSources.Add(dataset);
            dataset.Value = ReceiptReverseInfoList;

            this.rptClearingReceiptReverse.RefreshReport();
            this.rptClearingReceiptReverse.RefreshReport();
        }




    }
}
