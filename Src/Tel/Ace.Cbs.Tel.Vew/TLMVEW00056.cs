using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Cle;
using Microsoft.Reporting.WinForms;
using System.IO;
using Ace.Cbs.Cx.Com.Utt;


namespace Ace.Cbs.Tel.Vew
{
    public partial class TLMVEW00056 : BaseForm,ITLMVEW00056
    {
       public TLMVEW00056()
        {
            InitializeComponent();
        }
           #region Controller
        private ITLMCTL00056 controller;
        public ITLMCTL00056 Controller
        {
            get { return this.controller; }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }

        #endregion

      public TLMVEW00056(bool isMainMenu, string parentFormId,string outstandingName)
        {
            InitializeComponent();
            this.IsMainMenu = isMainMenu;
            this.ParentFormId = parentFormId;
            this.OutstandingName = outstandingName;
      }

        private bool isMainMenu = true;
        public bool IsMainMenu
        {
            get { return this.isMainMenu; }
            set { this.isMainMenu = value; }
        }

        private string parentFormId = string.Empty;
        public string ParentFormId
        {
            get { return this.parentFormId; }
            set { this.parentFormId = value; }
        }
        public string OutstandingName { get; set; }
        IList<TLMDTO00017> list { get; set; }

        private void TLMVEW00056_Load(object sender, EventArgs e)
        {
        
            try
            {
                TLMDTO00001 reDTO = new TLMDTO00001();


                if (this.OutstandingName == "DrawingAmountOutstanding")
                {
                    this.list = this.controller.ShowDrawingOutStandingByDrawingAmountOutstand();
                    reDTO.ReportTitle = "Drawing Remittance  Outstanding Listing By Receipt Date as at " + DateTime.Now.ToString("dd/MM/yyyy");
                    this.Text = "Drawing Remittance Register Outstanding Outstanding Listing Report (By Amount)";                    
                }
             

                if (list.Count > 0)
                {


                    reDTO.BankName = CurrentUserEntity.BranchDescription;
                    Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });

                    reDTO.BranchName = Branch.Address;
                //    reDTO.SourceBranchCode = Branch.BranchCode;

                    rpvDrawingRegisterOutstandingByReceiptDate.LocalReport.DataSources.Clear();
                    ReportParameter[] para = new ReportParameter[9];
                    para[0] = new ReportParameter("BankName", reDTO.BankName);
                    para[1] = new ReportParameter("BranchName", Branch.Address);
                    para[2] = new ReportParameter("Phone", Branch.Phone);
                    para[3] = new ReportParameter("Fax", Branch.Fax);
                    para[7] = new ReportParameter("BrCode", Branch.BranchCode);
                    para[8] = new ReportParameter("Br_Alias", Branch.Bank_Alias);



                    Image img = null;
                    string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                    using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                    {
                        img = System.Drawing.Image.FromStream(stream);

                        img.Save(tempFilePath);
                    }

                    para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                    para[5] = new ReportParameter("ReportTitle", reDTO.ReportTitle);
                    para[6] = new ReportParameter("TotalRecords", list.Count.ToString());
                    this.rpvDrawingRegisterOutstandingByReceiptDate.LocalReport.EnableExternalImages = true;
                    rpvDrawingRegisterOutstandingByReceiptDate.LocalReport.SetParameters(para);
                    ReportDataSource dataset = new ReportDataSource("DrawingRemittanceRegisterOutstanding", list);
                    rpvDrawingRegisterOutstandingByReceiptDate.LocalReport.DataSources.Add(dataset);

                    dataset.Value = list;
                    this.rpvDrawingRegisterOutstandingByReceiptDate.RefreshReport();
                }

                else
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                }
            }
            catch (Exception ex)
            { }
        }
    }
}
