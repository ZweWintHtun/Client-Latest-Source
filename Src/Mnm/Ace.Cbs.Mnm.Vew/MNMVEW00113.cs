using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Mnm.Dmd;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Ace.Windows.Core.Utt;
using Microsoft.Reporting.WinForms;
using Ace.Cbs.Cx.Com.Utt;
using System.IO;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00113 : BaseForm
    {        
        public IList<MNMDTO00007> List { get; set; }
        public string FormName { get; set; }
        public string Month { get; set; }

        public MNMVEW00113()
        {
            InitializeComponent();
        }

        public MNMVEW00113(IList<MNMDTO00007> printDataList, string formName, string month) 
        {
            this.List = printDataList;
            this.FormName = formName;
            this.Month = month;
            InitializeComponent();
        }

        private void MNMVEW00113_Load(object sender, EventArgs e)
        {
            Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });

            rpvSavingInterest.LocalReport.DataSources.Clear();
            ReportParameter[] para = new ReportParameter[12];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);
            para[10] = new ReportParameter("BrCode", Branch.BranchCode);
            para[11] = new ReportParameter("Br_Alias", Branch.Bank_Alias);
   

            Image img = null;
            string tempFilePath = Application.StartupPath + "\\banklogo.jpg";

            using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            {
                img = System.Drawing.Image.FromStream(stream);

                img.Save(tempFilePath);
            }

            para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath); 
            para[5] = new ReportParameter("Head", FormName);

            switch (Month)
            {
                case "Apr-Jun":
                    para[6] = new ReportParameter("Month1", "Apr");
                    para[7] = new ReportParameter("Month2", "May");
                    para[8] = new ReportParameter("Month3", "Jun");
                    break;
                case "July-Sep":
                    para[6] = new ReportParameter("Month1", "July");
                    para[7] = new ReportParameter("Month2", "Aug");
                    para[8] = new ReportParameter("Month3", "Sep");
                    break;
                case "Oct-Dec":
                    para[6] = new ReportParameter("Month1", "Oct");
                    para[7] = new ReportParameter("Month2", "Nov");
                    para[8] = new ReportParameter("Month3", "Dec");
                    break;
                case "Jan-Mar":
                    para[6] = new ReportParameter("Month1", "Jan");
                    para[7] = new ReportParameter("Month2", "Feb");
                    para[8] = new ReportParameter("Month3", "Mar");
                    break;
            }

            para[9] = new ReportParameter("Count", List.Count.ToString());
            
            this.rpvSavingInterest.LocalReport.EnableExternalImages = true;
            rpvSavingInterest.LocalReport.SetParameters(para);                   
            ReportDataSource dataset = new ReportDataSource("SavingInterestDataSet", List);
            rpvSavingInterest.LocalReport.DataSources.Add(dataset);

            foreach (MNMDTO00007 si in List)
            {
                switch (Month)
                {
                    case "Apr-Jun":
                        si.Total = si.Month1 + si.Month2 + si.Month3;
                        break;
                    case "July-Sep":
                        si.Month1 = si.Month4;
                        si.Month2 = si.Month5;
                        si.Month3 = si.Month6;                        
                        break;
                    case "Oct-Dec":
                        si.Month1 = si.Month7;
                        si.Month2 = si.Month8;
                        si.Month3 = si.Month9;                        
                        break;
                    case "Jan-Mar":
                        si.Month1 = si.Month10;
                        si.Month2 = si.Month11;
                        si.Month3 = si.Month12;                        
                        break;
                }
            }

            dataset.Value = List;
            this.rpvSavingInterest.RefreshReport();
        }
    }
}
