using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Core.Utt;

using System.IO;
using Microsoft.Reporting.WinForms;
using Ace.Cbs.Mnm.Dmd.DTO;
using Ace.Cbs.Mnm.Ctr.Ptr;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00088 : BaseDockingForm
    { 
        #region Properties 
        public string Header { get; set; }
        public IList<PFMDTO00029> PrintDataList { get; set; }
        #endregion
        
        #region Constructor
        public MNMVEW00088()
        {
            InitializeComponent();
        }
        public MNMVEW00088(IList<PFMDTO00029> List,  DateTime requiredDate,bool isWithReversal)
        {            
            if (isWithReversal)
            {
                this.Header = "Auto Link Voucher Listing as at " + requiredDate.ToString("dd/MM/yyyy") + " With Reversal";
            }
            else
            {
                this.Header = "Auto Link Voucher Listing as at " + requiredDate.ToString("dd/MM/yyyy") + " Without Reversal";
            }
            this.PrintDataList = List;
            InitializeComponent();
        }
        #endregion

        private void MNMVEW00088_Load(object sender, EventArgs e)
        {
            Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });

            rpvAutoLinkSchdule.LocalReport.DataSources.Clear();
            ReportParameter[] para = new ReportParameter[8];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);
            para[6] = new ReportParameter("BrCode", Branch.BranchCode);
            para[7] = new ReportParameter("Br_Alias", Branch.Bank_Alias);

            Image img = null;
            string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            {
                img = System.Drawing.Image.FromStream(stream);

                img.Save(tempFilePath);
            }

            para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);          
            para[5] = new ReportParameter("Header", this.Header);

            this.rpvAutoLinkSchdule.LocalReport.EnableExternalImages = true;
            rpvAutoLinkSchdule.LocalReport.SetParameters(para);
            ReportDataSource dataset = new ReportDataSource("AutoLinkScheduleDataSet", PrintDataList);
            rpvAutoLinkSchdule.LocalReport.DataSources.Add(dataset);
            dataset.Value = PrintDataList;

            this.rpvAutoLinkSchdule.RefreshReport();
        }
    }
}
