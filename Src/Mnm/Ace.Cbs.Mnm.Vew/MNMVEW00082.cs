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
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00082 : BaseForm
    {
        #region Property
        public bool IsReversal { get; set; }
        public bool IsSourceCurrency { get; set; }
        public string Currency { get; set; }
        public string BranchNo { get; set; }
        public IList<MNMDTO00033> TrScrollDatalist { get; set; }
        public PFMDTO00042 ReportTLFDTO { get; set; }
        public string FormName { get; set; }
        #endregion

        #region constructors
        public MNMVEW00082()
        {
            InitializeComponent();
        }

        public MNMVEW00082(bool isReversal, string formName, IList<MNMDTO00033> DTOList, PFMDTO00042 DTO)
        {
            InitializeComponent();
            this.IsReversal = isReversal;
            this.FormName = formName;
            this.TrScrollDatalist = DTOList;
            this.ReportTLFDTO = DTO;
        }
        #endregion

        private void MNMVEW00082_Load(object sender, EventArgs e)
        {
            decimal transferTotal = 0;
            decimal clearingTotal = 0;
            decimal transferAndClearing = 0;
            decimal totalCash = 0;
            decimal grandTotal = 0;
            string DataDate = ((DateTime)this.ReportTLFDTO.DATE_TIME).ToString("dd/MM/yyyy");
            if (TrScrollDatalist.Count > 0)
            {
                string amountStatus = " By Home Amount";
                MNMDTO00033 TrScrollDTO = new MNMDTO00033();

                if (this.IsReversal == false)
                {
                    TrScrollDTO.StatusReversal = FormName + " (Without Reversal) Listing as at " + DataDate ;
                }
                else if (this.IsReversal == true)
                {
                    TrScrollDTO.StatusReversal = FormName + " (With Reversal) Listing as at " + DataDate;
                }

                Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });

                rpvTransferScroll.LocalReport.DataSources.Clear();
                ReportParameter[] para = new ReportParameter[14];
                para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
                para[1] = new ReportParameter("BranchName", Branch.Address);
                para[2] = new ReportParameter("Phone", Branch.Phone);
                para[3] = new ReportParameter("Fax", Branch.Fax);
                para[12] = new ReportParameter("BrCode", Branch.BranchCode);
                para[13] = new ReportParameter("Br_Alias", Branch.BranchAlias);

                //Commented by HWKO (31-Oct-2017)
                //Image img = null;
                //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                //{
                //    img = System.Drawing.Image.FromStream(stream);

                //    img.Save(tempFilePath);
                //}


                string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

                para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);


                para[5] = new ReportParameter("Head", TrScrollDTO.StatusReversal);
                para[6] = new ReportParameter("branchno", (ReportTLFDTO.IsAllBranches == true) ? "All Branches" : "Branch Code :" + ReportTLFDTO.SourceBranch);
                if (ReportTLFDTO.CurrencyType == "Home Currency")
                {
                    para[7] = new ReportParameter("Currency", "All Currencies" + amountStatus);
                }
                else
                {
                    para[7] = new ReportParameter("Currency", "Currency: " + ReportTLFDTO.SourceCur.Replace("KYT","MMK"));//Updated by HWKO (25-Sep-2017)
                }

                foreach (MNMDTO00033 tempDTO in TrScrollDatalist)
                {
                    transferTotal += tempDTO.CR_CURRENT + tempDTO.CR_DOMESTIC + tempDTO.CR_FIXED + tempDTO.CR_SAVING;
                }
                clearingTotal = this.ReportTLFDTO.ClearingTotal;
                totalCash = this.ReportTLFDTO.TotalCash;
                transferAndClearing = transferTotal + clearingTotal;
                grandTotal = transferAndClearing + totalCash;

                para[8] = new ReportParameter("ClearingTotal", clearingTotal.ToString("n2"));
                para[9] = new ReportParameter("TransferAndClearing", transferAndClearing.ToString("n2"));
                para[10] = new ReportParameter("TotalCash", totalCash.ToString("n2"));
                para[11] = new ReportParameter("GrandTotal", grandTotal.ToString("n2"));

                this.rpvTransferScroll.LocalReport.EnableExternalImages = true;
                rpvTransferScroll.LocalReport.SetParameters(para);
                ReportDataSource dataset = new ReportDataSource("TRScrollDataSet", TrScrollDatalist);
                rpvTransferScroll.LocalReport.DataSources.Add(dataset);

                dataset.Value = TrScrollDatalist;
                this.rpvTransferScroll.RefreshReport();
                this.rpvTransferScroll.RefreshReport();
            }
        }

        
    }
}
