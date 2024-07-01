using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Gl.Dmd;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Ace.Windows.Core.Utt;
using Microsoft.Reporting.WinForms;
using System.IO;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Gl.Vew
{
    public partial class GLMVEW00029 : BaseForm
    {
        IList<GLMDTO00028> DataDto { get; set; }
        string head { get; set; }
        string requiredDate { get; set; }

        public GLMVEW00029()
        {
            InitializeComponent();
        }

        public GLMVEW00029(IList<GLMDTO00028> dataDto, string header)
        {
            this.Text = header;
            this.head = header;
            this.DataDto = dataDto;
            InitializeComponent();
        }

        private void GLMVEW00029_Load(object sender, EventArgs e)
        {
            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            this.rpvSFP.LocalReport.DataSources.Clear();

            ReportParameter[] para = new ReportParameter[10];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);
            para[4] = new ReportParameter("Br_Alias", Branch.BranchAlias);
            para[5] = new ReportParameter("Title", this.head);

            //Commented by HWKO (31-Oct-2017)
            //Image img = null;
            //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            //{
            //    img = System.Drawing.Image.FromStream(stream);
            //    img.Save(tempFilePath);
            //}


            string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

            para[6] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            para[7] = new ReportParameter("RequiredYear",this.DataDto[0].RequireYear);
            para[8] = new ReportParameter("RequiredMonth", this.GetMonthName(this.DataDto[0].RequireMonth));
            if (Convert.ToInt32(this.DataDto[0].RequireMonth) == DateTime.Now.Month &&
                Convert.ToInt32(this.DataDto[0].RequireYear) == DateTime.Now.Year)
            {
                requiredDate = DateTime.Now.ToString("dd MMMM,yyyy");
            }
            else
            {
                requiredDate = DateTime.DaysInMonth(Convert.ToInt32(this.DataDto[0].RequireYear), Convert.ToInt32(this.DataDto[0].RequireMonth)).ToString() + " " + this.GetMonthName(this.DataDto[0].RequireMonth) + "," + this.DataDto[0].RequireYear;
            }
            para[9] = new ReportParameter("RequiredDate", requiredDate);

            this.rpvSFP.LocalReport.EnableExternalImages = true;
            this.rpvSFP.LocalReport.SetParameters(para);
            this.rpvSFP.RefreshReport();

            ReportDataSource dataset = new ReportDataSource("DSGLMRDLC00028", this.DataDto);
            this.rpvSFP.LocalReport.DataSources.Add(dataset);
            dataset.Value = this.DataDto;
            this.rpvSFP.LocalReport.Refresh();

            this.rpvSFP.RefreshReport();
        }

        public string GetMonthName(string month)
        {
            if (!String.IsNullOrEmpty(month))
            {
                int monthNo = Convert.ToInt32(month);
                switch (monthNo)
                {
                    case 1:
                        return "January";
                    case 2:
                        return "February";
                    case 3:
                        return "March";
                    case 4:
                        return "April";
                    case 5:
                        return "May";
                    case 6:
                        return "June";
                    case 7:
                        return "July";
                    case 8:
                        return "August";
                    case 9:
                        return "September";
                    case 10:
                        return "October";
                    case 11:
                        return "November";
                    case 12:
                        return "December";
                }
            }
            return String.Empty;
        }
    }
}
