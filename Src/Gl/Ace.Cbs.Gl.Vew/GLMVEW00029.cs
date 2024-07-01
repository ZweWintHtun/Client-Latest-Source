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
        string strDate { get; set; }
        string strCurMonthYr { get; set; }
        string LastDayofRequireMonth { get; set; }

        public GLMVEW00029()
        {
            InitializeComponent();
        }

        public GLMVEW00029(IList<GLMDTO00028> dataDto, string header, string lastDayofRequireMonth)
        {
            this.Text = header;
            this.head = header;
            this.DataDto = dataDto;
            this.LastDayofRequireMonth = AddOrdinal(Convert.ToInt16(lastDayofRequireMonth));
            InitializeComponent();
        }

        public GLMVEW00029(IList<GLMDTO00028> dataDto, string header,string strDate,string strCurMonthYr)
        {
            this.Text = header;
            this.head = header;
            this.DataDto = dataDto;
            this.strDate = strDate;
            this.strCurMonthYr = strCurMonthYr;
            InitializeComponent();
        }

        private void GLMVEW00029_Load(object sender, EventArgs e)
        {
            BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            this.rpvSFP.LocalReport.DataSources.Clear();
            
            List<GLMDTO00028> lst=(List<GLMDTO00028>)this.DataDto;
            decimal PrmTotalAssets = lst.Where(x => x.ACType == "NCA" || x.ACType == "LOH" || x.ACType == "CA").ToList().Sum(x => x.Amount);
            decimal PrmTotalEquity = lst.Where(x => x.ACType == "EAL").ToList().Sum(x => x.Amount);
            decimal PrmTotalNCL = lst.Where(x => x.ACType == "NCL").ToList().Sum(x => x.Amount);
            decimal PrmTotalCL = lst.Where(x => x.ACType == "CL").ToList().Sum(x => x.Amount);
            decimal PrmTotalLiab = lst.Where(x => x.ACType == "NCL" || x.ACType == "CL").ToList().Sum(x => x.Amount);
            decimal PrmTotalEquiAndLiab = PrmTotalEquity + PrmTotalLiab;

            ReportParameter[] para = new ReportParameter[15];
            int paraIdx = 0;
            para[paraIdx++] = new ReportParameter("PrmTotalAssets", PrmTotalAssets.ToString("N2"));
            para[paraIdx++] = new ReportParameter("PrmTotalEquity", PrmTotalEquity.ToString("N2"));
            para[paraIdx++] = new ReportParameter("PrmTotalNCL", PrmTotalNCL.ToString("N2"));
            para[paraIdx++] = new ReportParameter("PrmTotalCL", PrmTotalCL.ToString("N2"));
            para[paraIdx++] = new ReportParameter("PrmTotalLiab", PrmTotalLiab.ToString("N2"));
            para[paraIdx++] = new ReportParameter("PrmTotalEquiAndLiab", PrmTotalEquiAndLiab.ToString("N2"));
            para[paraIdx++] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[paraIdx++] = new ReportParameter("BranchName", Branch.Address);
            para[paraIdx++] = new ReportParameter("Phone", Branch.Phone);
            para[paraIdx++] = new ReportParameter("Fax", Branch.Fax);
            para[paraIdx++] = new ReportParameter("Br_Alias", Branch.BranchAlias);
            para[paraIdx++] = new ReportParameter("Title", this.head);

            //Commented by HWKO (31-Oct-2017)
            //Image img = null;
            //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            //{
            //    img = System.Drawing.Image.FromStream(stream);
            //    img.Save(tempFilePath);
            //}


            string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

            para[paraIdx++] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            //para[paraIdx++] = new ReportParameter("RequiredYear", (string.IsNullOrEmpty(this.DataDto[0].RequireYear)) ? "" : this.DataDto[0].RequireYear);
            //para[paraIdx++] = new ReportParameter("RequiredMonth", this.GetMonthName(string.IsNullOrEmpty(this.DataDto[0].RequireMonth) ? "1" : this.DataDto[0].RequireMonth));
            ////if (Convert.ToInt32(this.DataDto[0].RequireMonth) == DateTime.Now.Month &&
            //    Convert.ToInt32(this.DataDto[0].RequireYear) == DateTime.Now.Year)
            //{
            //    requiredDate = DateTime.Now.ToString("dd MMMM,yyyy");
            //}
            //else
            //{
            //    requiredDate = DateTime.DaysInMonth(Convert.ToInt32(this.DataDto[0].RequireYear), Convert.ToInt32(this.DataDto[0].RequireMonth)).ToString() + " " + this.GetMonthName(this.DataDto[0].RequireMonth) + "," + this.DataDto[0].RequireYear;
            //}
            
            
            //para[paraIdx++] = new ReportParameter("PrmRequiredDate", this.strDate);
            //para[paraIdx++] = new ReportParameter("PrmCurrentMonth", this.strCurMonthYr);

            string monthName = GetMonthName(DataDto[DataDto.Count - 1].RequireMonth); //March

            #region old
            //int lastDayOfRMonth = DateTime.DaysInMonth((Convert.ToInt32(DataDto[DataDto.Count - 1].RequireYear)), Convert.ToInt32(DataDto[DataDto.Count - 1].RequireMonth)); //31
            //string dayFormat = AddOrdinal(lastDayOfRMonth); /// commented by ZMS 20181010
            //string dayFormat = AddOrdinal(DateTime.Now.Day); /// updated by ZMS 20181010
            //string dayFormat = AddOrdinal(lastDayOfRMonth); /// updated by ZMS 20181116 (requirement change again )lastDayofRequireMonth
            //para[paraIdx++] = new ReportParameter("PrmRequiredDate", dayFormat + " " + monthName + "'" + DataDto[DataDto.Count - 1].RequireYear);/// updated by ZMS 20181010
            //para[paraIdx++] = new ReportParameter("PrmCurrentMonth", GetMonthName(DateTime.Now.Month.ToString()) + " " + DateTime.Now.Year);/// updated by ZMS 20181010 (Requirement change)
            #endregion

            para[paraIdx++] = new ReportParameter("PrmRequiredDate", LastDayofRequireMonth + " " + monthName + "'" + DataDto[DataDto.Count - 1].RequireYear);/// updated by ZMS 20181204
            para[paraIdx++] = new ReportParameter("PrmCurrentMonth", monthName + "'" + DateTime.Now.Year);/// updated by ZMS 20181109 (Requirement change again)

            this.rpvSFP.LocalReport.EnableExternalImages = true;
            this.rpvSFP.LocalReport.SetParameters(para);
            //this.rpvSFP.RefreshReport();

            ReportDataSource dataset = new ReportDataSource("DSGLMRDLC00028", this.DataDto);
            this.rpvSFP.LocalReport.DataSources.Add(dataset);
            //dataset.Value = this.DataDto;
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

        public static string AddOrdinal(int num)
        {
            if (num <= 0) return num.ToString();

            switch (num % 100)
            {
                case 11:
                case 12:
                case 13:
                    return num + "th";
            }

            switch (num % 10)
            {
                case 1:
                    return num + "st";
                case 2:
                    return num + "nd";
                case 3:
                    return num + "rd";
                default:
                    return num + "th";
            }

        }
    }
}
