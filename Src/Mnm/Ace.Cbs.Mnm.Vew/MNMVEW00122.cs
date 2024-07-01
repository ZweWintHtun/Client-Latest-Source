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
    public partial class MNMVEW00122 : BaseForm
    {
        #region Properties
     
        public string Header { get; set; }
        public IList<PFMDTO00042> PrintDataList { get; set; }

        #endregion

        #region Constructor

        public MNMVEW00122()
        {
            InitializeComponent();
        }
        public MNMVEW00122(IList<PFMDTO00042> List, DateTime startDate, DateTime endDate, string formName, bool IsTransactionDate)
        {          
            this.PrintDataList = List;
            if (IsTransactionDate)
                this.Header = formName + " By Transaction Date from " + startDate.ToString("dd/MM/yyyy") + " to " + endDate.ToString("dd/MM/yyyy") ;
            else
                this.Header = formName + " By Settlement Date from " + startDate.ToString("dd/MM/yyyy") + " to " + endDate.ToString("dd/MM/yyyy");                    
            InitializeComponent();
        }

        #endregion

        #region Event

        private void MNMVEW00122_Load(object sender, EventArgs e)
        {
            Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });

            rpvPORegisterListing.LocalReport.DataSources.Clear();
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
            para[5] = new ReportParameter("Header", Header);

            #region TestCode 
            //System.Nullable<decimal> cashamount = 0;
            //System.Nullable<decimal> transferamount = 0;
            //System.Nullable<decimal> encashamount = 0;
            //foreach (PFMDTO00042 poDto in PrintDataList)
            //{
            //    if (poDto.DrawingRegisterNo == null && poDto.ACName == "PO" && poDto.AcctNo == null)
            //        cashamount = cashamount + poDto.Amount;
            //    else if (poDto.DrawingRegisterNo == null && poDto.ACName == "PO" && poDto.AcctNo != null)
            //        transferamount = transferamount + poDto.Amount;
            //    else if (poDto.DrawingRegisterNo != null && poDto.ACName == "POR")
            //        encashamount = encashamount + poDto.Amount;
             
            //}

            //totalamount = cashamount + transferamount + encashamount;
           
            //PrintDataList[0].LocalAmount = cashamount;
            //PrintDataList[0].LocalAmt = transferamount;
            //PrintDataList[0].Deliver = encashamount;
            #endregion

            System.Nullable<decimal> totalamount = 0; 
            foreach (PFMDTO00042 poDto in PrintDataList)
            {
                if (poDto.DrawingRegisterNo == null && (poDto.ACName == "PO" || poDto.ACName == "POR"))
                    totalamount = totalamount + poDto.Amount;
            }

            PrintDataList[0].ClosingBalance = totalamount;
            this.rpvPORegisterListing.LocalReport.EnableExternalImages = true;
            this.rpvPORegisterListing.LocalReport.SetParameters(para);
            ReportDataSource dataset = new ReportDataSource("PORegisterDataSet", PrintDataList);
            this.rpvPORegisterListing.LocalReport.DataSources.Add(dataset);
            dataset.Value = PrintDataList;
            
            this.rpvPORegisterListing.RefreshReport();
        }
        #endregion
    }
}
