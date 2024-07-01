using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Mnm.Dmd;
using System.IO;
using Microsoft.Reporting.WinForms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00094 : BaseForm
    {
        #region Properties
        public IList<MNMDTO00046> ReportDTOList { get; set; }
        string AccountType { get; set; }
        string Year { get; set; }
        string Month { get; set; }
        string FormName { get; set; }
        int WithdrawCount { get; set; }
        int DepositCount { get; set; }
        #endregion

        public MNMVEW00094()
        {
            InitializeComponent();
        }
        //custDTOList, this.type, this.WithdrawCount, this.DepositCount, this.view.Year, this.view.Month, formname 
        public MNMVEW00094(IList<MNMDTO00046> custDTOList, string type, int year, int month, string formname)
        {
            ReportDTOList = custDTOList;
            AccountType = type;
            this.Year = year.ToString();
            this.FormName = formname;
            this.Month = this.GetMonth(month);
            //switch (month)
            //{
            //    case 1: this.Month = "January"; break;
            //    case 2: this.Month = "February"; break;
            //    case 3: this.Month = "March"; break;
            //    case 4: this.Month = "April"; break;
            //    case 5: this.Month = "May"; break;
            //    case 6: this.Month = "June"; break;
            //    case 7: this.Month = "July"; break;
            //    case 8: this.Month = "August"; break;
            //    case 9: this.Month = "September"; break;
            //    case 10: this.Month = "October"; break;
            //    case 11: this.Month = "November"; break;
            //    case 12: this.Month = "December"; break;
            //    default: this.Month = "January"; break;
            //}

            InitializeComponent();
        }

        public MNMVEW00094(IList<MNMDTO00046> custDTOList, string type,int withdrawCount,int depositCount, int year, int month, string formname)
        {
            ReportDTOList = custDTOList;
            AccountType = type;
            this.Year = year.ToString();
            this.FormName = formname;
            this.WithdrawCount = withdrawCount;
            this.DepositCount = depositCount;
            this.Month = this.GetMonth(month);
            InitializeComponent();
        }

        public string GetMonth(int month)
        {
            switch (month)
            {
                case 1: this.Month = "January"; break;
                case 2: this.Month = "February"; break;
                case 3: this.Month = "March"; break;
                case 4: this.Month = "April"; break;
                case 5: this.Month = "May"; break;
                case 6: this.Month = "June"; break;
                case 7: this.Month = "July"; break;
                case 8: this.Month = "August"; break;
                case 9: this.Month = "September"; break;
                case 10: this.Month = "October"; break;
                case 11: this.Month = "November"; break;
                case 12: this.Month = "December"; break;
                default: this.Month = "January"; break;
            }
            return this.Month;
        }

        private void MNMVEW00094_Load(object sender, EventArgs e)
        {
            this.Text = this.FormName;
            Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });

            rpvBankStatement.LocalReport.DataSources.Clear();
            ReportParameter[] para = new ReportParameter[9];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
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
            para[5] = new ReportParameter("Month", this.Month);
            para[6] = new ReportParameter("Year", this.Year);

            this.rpvBankStatement.LocalReport.EnableExternalImages = true;
            this.rpvBankStatement.LocalReport.SetParameters(para);

            ReportDataSource dataset = new ReportDataSource("DataSet1", this.ReportDTOList);
            this.rpvBankStatement.LocalReport.DataSources.Add(dataset);
            dataset.Value = this.ReportDTOList;

            rpvBankStatement.LocalReport.Refresh();
            this.rpvBankStatement.RefreshReport();
        }

      
    }
}
