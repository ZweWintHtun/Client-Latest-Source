using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Core.Utt;
using System.Linq;
using Microsoft.Reporting.WinForms;
using System.IO;



namespace Ace.Cbs.Tel.Vew
{
    /// <summary>
    /// Deposit Listing By Account No
    /// </summary>
    public partial class TLMVEW00064 : BaseForm, ITLMVEW00064
    {
        public TLMVEW00064()
        {
            InitializeComponent();
        }

        public TLMVEW00064(string parentFormId, DateTime startDate, DateTime endDate, string accountNo)
        {
            InitializeComponent();            
            this.ParentFormId = parentFormId;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.AccountNo = accountNo;

        }

        public TLMVEW00064(string parentFormId, DateTime startDate, DateTime endDate, string accountNo,IList<PFMDTO00042> lists)
        {
            InitializeComponent();
            this.ParentFormId = parentFormId;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.AccountNo = accountNo;
            this.List = lists;

        }

        private ITLMCTL00064 controller;
        public ITLMCTL00064 Controller
        {
            get { return this.controller; }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }

         private string parentFormId = string.Empty;
        public string ParentFormId
        {
            get { return this.parentFormId; }
            set { this.parentFormId = value; }
        }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string AccountNo { get; set; }
        IList<PFMDTO00042> List { get; set; }

        private void TLMVEW00064_Load(object sender, EventArgs e)
        {
            PFMDTO00042 reporttlfDTO = new PFMDTO00042();
            //IList<PFMDTO00042> list = this.controller.ShowDepositByAccountNoReport();
            IList<PFMDTO00042> list = this.List;
            if (list == null)
                list = new List<PFMDTO00042>();
            if (list.Count > 0)
            {

                reporttlfDTO.BankName = CurrentUserEntity.BranchDescription;
                reporttlfDTO.ReportTitle = "Deposit Listing (By Account No - "+ this.AccountNo + ") from "+ this.StartDate.ToString("dd/MM/yyyy")+" to "+ this.EndDate.ToString("dd/MM/yyyy");

                Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });

                reporttlfDTO.BranchName = Branch.Address;
             //   reporttlfDTO.SourceBranch = Branch.BranchCode;

                rpvDepositListingByAccountNo.LocalReport.DataSources.Clear();
                ReportParameter[] para = new ReportParameter[9] ;
                para[0] = new ReportParameter("BankName", reporttlfDTO.BankName);
                para[1] = new ReportParameter("BranchName", reporttlfDTO.BranchName);
                para[2] = new ReportParameter("Phone", Branch.Phone);
                para[3] = new ReportParameter("Fax", Branch.Fax);
                para[7] = new ReportParameter("BrCode", Branch.BranchCode);
                para[8] = new ReportParameter("Br_Alias", Branch.Bank_Alias);

                Image img = null;
                string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

                //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                //{
                //    img = System.Drawing.Image.FromStream(stream);

                //    img.Save(tempFilePath);
                //}

                para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);


                para[5] = new ReportParameter("ReportTitle", reporttlfDTO.ReportTitle);
                para[6] = new ReportParameter("TotalRecords", list.Count.ToString());


                this.rpvDepositListingByAccountNo.LocalReport.EnableExternalImages = true;
                rpvDepositListingByAccountNo.LocalReport.SetParameters(para);
                ReportDataSource dataset = new ReportDataSource("DepositListingByAllandByCounterDTO_DataSet", list);
                rpvDepositListingByAccountNo.LocalReport.DataSources.Add(dataset);

                dataset.Value = list;
                this.rpvDepositListingByAccountNo.RefreshReport();
            }

            else
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                this.Close();
            }
            }
         
        }
    }

