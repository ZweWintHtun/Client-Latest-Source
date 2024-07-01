using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Utt;
using System.IO;
using Microsoft.Reporting.WinForms;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient.Controls;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00153 : BaseForm
    {

        #region Properties

        public string Header { get; set; }
        public IList<MNMDTO00077> PrintDataList { get; set; }

        #endregion


        #region Constructor

        public MNMVEW00153()
        {
            InitializeComponent();
        }

        public MNMVEW00153(IList<MNMDTO00077> List, DateTime startDate, DateTime endDate,string cur,string status,string sourceBr,string formName)
        {          
            this.PrintDataList = List;
           
           this.Header = formName +  " From "  + startDate.ToString("dd/MM/yyyy") + " To " + endDate.ToString("dd/MM/yyyy") ;
           
            InitializeComponent();
        }

        public MNMVEW00153(IList<MNMDTO00077> List, DateTime startDate, DateTime endDate, string cur, string sourceBr, string formName)
        {
            this.PrintDataList = List;

            this.Header = formName + " From " + startDate.ToString("dd/MM/yyyy") + " To " + endDate.ToString("dd/MM/yyyy");

            InitializeComponent();
        }




        #endregion

        private void MNMVEW00153_Load(object sender, EventArgs e)
        {
            Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });

            rpvFixedAutoRenewalStatus.LocalReport.DataSources.Clear();
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
            IList<MNMDTO00077> poDtoList = new List<MNMDTO00077>();

            System.Nullable<decimal> totalamount = 0;
            foreach (MNMDTO00077 poDto in PrintDataList)
            {
                //   if (poDto.EncashRegisterNo != null && poDto.ACName == "POR" && poDto.ToAccountNo == null)
                //      cashamount = cashamount + poDto.Amount;
                //if (poDto.EncashRegisterNo != null && poDto.ACName == "POR" && poDto.ToAccountNo != null)
                //    transferamount = transferamount + poDto.Amount;

                if (poDto.AccountNo != null && (poDto.ToAccountNo != null|| poDto.AccuredStatus == "12"))
                    totalamount = totalamount + poDto.Amount;
            }



            PrintDataList[0].ClosingBalance = totalamount;
            this.rpvFixedAutoRenewalStatus.LocalReport.EnableExternalImages = true;
            this.rpvFixedAutoRenewalStatus.LocalReport.SetParameters(para);
            ReportDataSource dataset = new ReportDataSource("FixedAutoRenewalDataSet", PrintDataList);
            this.rpvFixedAutoRenewalStatus.LocalReport.DataSources.Add(dataset);
            dataset.Value = PrintDataList;

            this.rpvFixedAutoRenewalStatus.RefreshReport();

      


        }

       
    }
}
