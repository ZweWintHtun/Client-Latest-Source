using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Utt;
using System.IO;
using Microsoft.Reporting.WinForms;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient.Controls;


namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00137 : BaseDockingForm
    {
        #region Properties

        public string FormName { get; set; }
        public DateTime RequiredDate { get; set; }
        public string Header { get; set; }
        public IList<TLMDTO00001> PrintDataList { get; set; }

        #endregion

        #region Constructor
        public MNMVEW00137()
        {
            InitializeComponent();
        }

        public MNMVEW00137(IList<TLMDTO00001> List, string formName, DateTime requiredDate, bool IsTransactionDate)
        {
            this.RequiredDate = requiredDate;            
            this.PrintDataList = List;
           
            if(formName == "Daily Encashment Remittance Listing")
            {
                if (IsTransactionDate == true)
                {
                    this.Header = "Daily Encashment Remittance Listing By Transaction Date For " + requiredDate.ToString("dd/MM/yyyy");
                }
                else
                {
                    this.Header = "Daily Encashment Remittance Listing By Settlement Date For " + requiredDate.ToString("dd/MM/yyyy");
                } 
            }

            InitializeComponent();               
        }
        #endregion

        #region Event
        private void MNMVEW00137_Load(object sender, EventArgs e)
        {
            Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });

            rpvDailyEncashRemittance.LocalReport.DataSources.Clear();
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

            this.rpvDailyEncashRemittance.LocalReport.EnableExternalImages = true;
            this.rpvDailyEncashRemittance.LocalReport.SetParameters(para);
            ReportDataSource dataset = new ReportDataSource("DailyEncashRemittanceDS", PrintDataList);
            this.rpvDailyEncashRemittance.LocalReport.DataSources.Add(dataset);
            dataset.Value = PrintDataList;

            this.rpvDailyEncashRemittance.RefreshReport();
        }
        #endregion
    }
}
