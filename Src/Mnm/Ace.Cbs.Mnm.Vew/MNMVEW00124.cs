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
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Mnm.Ctr.Ptr;


namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00124 : BaseForm , IMNMVEW00124
    {
        #region Properties
        string Header { get; set; }
       
        public IList<PFMDTO00042> PrintDataList { get; set; }
        private IMNMCTL00124 _controller;
        public IMNMCTL00124 Controller
        {
            get
            {
                return this._controller;
            }
            set
            {
                this._controller = value;
                this._controller.View = this;
            }
        }   
       
        #endregion

        #region Constructor
        public MNMVEW00124()
        {
         
            InitializeComponent();
            this.Header = "Internal Remittance Outstanding Listing";
           // this.Hide();
        }

        public MNMVEW00124(IList<PFMDTO00042> List, DateTime startDate, DateTime endDate, string formName, bool IsTransactionDate)
        {            
            PrintDataList = List;  
            if (IsTransactionDate)
                this.Header = formName + " By Transaction Date from " + startDate.ToString("dd/MM/yyyy") + " to " + endDate.ToString("dd/MM/yyyy");
            else
                this.Header = formName + " By Settlement Date from " + startDate.ToString("dd/MM/yyyy") + " to " + endDate.ToString("dd/MM/yyyy");
                      
            InitializeComponent();
        }
        #endregion

        #region Event
        private void MNMVEW00124_Load(object sender, EventArgs e)
        {
            if (this.Header == "Internal Remittance Outstanding Listing")
            {
                this.Hide();
                PrintDataList = this.Controller.Print();
                if (PrintDataList.Count == 0 || PrintDataList == null)
                {
                    this.Close();
                    return;
                }
                this.Show();
                //this.Header = "Internal Remittance Outstanding Listing";
            }             
            
            Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });

            rpvInternalRemittanceListing.LocalReport.DataSources.Clear();
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

            this.rpvInternalRemittanceListing.LocalReport.EnableExternalImages = true;
            this.rpvInternalRemittanceListing.LocalReport.SetParameters(para);
            ReportDataSource dataset = new ReportDataSource("InternalRemittanceDataSet", PrintDataList);
            this.rpvInternalRemittanceListing.LocalReport.DataSources.Add(dataset);
            dataset.Value = PrintDataList;
            this.rpvInternalRemittanceListing.RefreshReport();
            //PrintDataList.Clear();
        }
        #endregion
    }
}
