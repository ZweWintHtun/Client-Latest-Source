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
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Cle;
using System.IO;
using Microsoft.Reporting.WinForms;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Tel.Vew
{
    public partial class TLMVEW00048 : BaseForm, ITLMVEW00048
    {
        public TLMVEW00048()
        {
            InitializeComponent();
        }
        #region Controller
        private ITLMCTL00048 controller;
        public ITLMCTL00048 Controller
        {
            get { return this.controller; }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }       

        #endregion

        public TLMVEW00048(string parentFormId, DateTime startDate, DateTime endDate, bool allBranch, string branchCode, bool isActive)
        {
            InitializeComponent();
            this.ParentFormId = parentFormId;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.AllBranch = allBranch;
            this.BranchCode = branchCode;
            this.IsActive = isActive;           
        }

        private string parentFormId = string.Empty;
        public string ParentFormId
        {
            get { return this.parentFormId; }
            set { this.parentFormId = value; }
        }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool AllBranch { get; set; }
        public string BranchCode { get; set; }
        public bool IsActive { get; set; }

        private void TLMVEW00048_Load(object sender, EventArgs e)
        {
           
            TLMDTO00004 ibltlfDTO = new TLMDTO00004();
                ibltlfDTO.StartDate = this.StartDate;
                ibltlfDTO.EndDate = this.EndDate;
                IList<TLMDTO00004> list = new List<TLMDTO00004>();
                if (this.IsActive == true)
                {
                    list = this.controller.ActiveIncomeListingByAllBranch();
                    this.GetTranTypeDescription(list);
                    ibltlfDTO.ReportTitle = "IBL Income Receipt Initiated by " + CurrentUserEntity.BranchDescription;
                }
                else
                {
                    list = this.controller.HomeIncomeListingByAllBranch();
                    this.GetTranTypeDescription(list);
                    ibltlfDTO.ReportTitle = "IBL Income Receipt Initiated by Other Branches";
                }

                if (list.Count > 0)
                {

                    ibltlfDTO.BankName = CurrentUserEntity.BranchDescription;


                    Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });

                    ibltlfDTO.BranchName = Branch.Address;
              //      ibltlfDTO.SourceBranchCode = Branch.BranchCode;

                    rpvHomeIncome.LocalReport.DataSources.Clear();
                    ReportParameter[] para = new ReportParameter[9];
                    para[0] = new ReportParameter("BankName", ibltlfDTO.BankName);
                    para[1] = new ReportParameter("BranchName", ibltlfDTO.BranchName);
                    para[2] = new ReportParameter("Phone", Branch.Phone);
                    para[3] = new ReportParameter("Fax", Branch.Fax);
                    para[7] = new ReportParameter("BrCode",Branch.BranchCode);
                    para[8] = new ReportParameter("Br_Alias", Branch.Bank_Alias);


                    Image img = null;
                    string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                    using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                    {
                        img = System.Drawing.Image.FromStream(stream);

                        img.Save(tempFilePath);
                    }

                    para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);

                    
                    para[5] = new ReportParameter("ReportTitle", ibltlfDTO.ReportTitle);
                    para[6] = new ReportParameter("TotalRecords", list.Count.ToString());


                    this.rpvHomeIncome.LocalReport.EnableExternalImages = true;
                    rpvHomeIncome.LocalReport.SetParameters(para);
                    ReportDataSource dataset = new ReportDataSource("IBLHomeIncomeReportDataSet", list);
                    rpvHomeIncome.LocalReport.DataSources.Add(dataset);

                    dataset.Value = list;
                    this.rpvHomeIncome.RefreshReport();

                }

                else
                {

                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                    this.Close();
                }
                    
        }

        public void GetTranTypeDescription(IList<TLMDTO00004> list)
        {
            if (list.Count > 0)
            {
                foreach (TLMDTO00004 item in list)
                {
                    if (item.TranType == "CCD")
                    {
                        item.TranType = "Online Deposit";
                    }
                    else
                    {
                        item.TranType = "Online Withdrawal";
 
                    }
                }
            }
 
        }
        

        
    }
}
