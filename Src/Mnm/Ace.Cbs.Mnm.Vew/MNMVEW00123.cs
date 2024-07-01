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
using Ace.Cbs.Cx.Com.Utt;
using System.IO;
using Microsoft.Reporting.WinForms;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient.Controls;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00123 : BaseForm
    {
        #region Properties

        public string Header { get; set; }
        public IList<PFMDTO00042> PrintDataList { get; set; }

        #endregion

        #region Constructor
        public MNMVEW00123()
        {
            InitializeComponent();
        }

        public MNMVEW00123(IList<PFMDTO00042> List, DateTime startDate, DateTime endDate, string formName, bool IsTransactionDate)
        {          
            this.PrintDataList = List;
            if (IsTransactionDate)
                this.Header = formName + " By Transaction Date from " + startDate.ToString("dd/MM/yyyy") + " to " + endDate.ToString("dd/MM/yyyy") ;
            else
                this.Header = formName + " By Settlement Date from " + startDate.ToString("dd/MM/yyyy") + " to " + endDate.ToString("dd/MM/yyyy");                    
            InitializeComponent();
        }
        #endregion

        private void MNMVEW00123_Load(object sender, EventArgs e)
        {
            Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });

            rpvPOWithdrawalListing.LocalReport.DataSources.Clear();
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
            para[5] = new ReportParameter("Header", Header);
            
            IList<PFMDTO00042> poDtoList = new List<PFMDTO00042>();

            System.Nullable<decimal> cashamount = 0;
            System.Nullable<decimal> transferamount = 0;
          
            foreach (PFMDTO00042 poDto in PrintDataList)
            {
                if (poDto.DrawingRegisterNo == null && poDto.ACName == "PO" && poDto.AcctNo == null)
                    cashamount = cashamount + poDto.Amount;
                if (poDto.DrawingRegisterNo == null && poDto.ACName == "PO" && poDto.AcctNo != null)
                    transferamount = transferamount + poDto.Amount;
            }

            para[6] = new ReportParameter("totalCashAmount", cashamount.ToString());
            para[7] = new ReportParameter("totalTransferAmount", transferamount.ToString());
          
            this.rpvPOWithdrawalListing.LocalReport.EnableExternalImages = true;
            this.rpvPOWithdrawalListing.LocalReport.SetParameters(para);
            ReportDataSource dataset = new ReportDataSource("POWithdrawalDataSet", PrintDataList);
            this.rpvPOWithdrawalListing.LocalReport.DataSources.Add(dataset);
            dataset.Value = PrintDataList;

            this.rpvPOWithdrawalListing.RefreshReport();
        }
    }
}
