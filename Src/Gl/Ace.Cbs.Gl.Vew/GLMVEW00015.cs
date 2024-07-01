using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Gl.Dmd;
using System.IO;
using Microsoft.Reporting.WinForms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Gl.Vew
{
    public partial class GLMVEW00015 : BaseDockingForm
    {
        public IList<GLMDTO00013> ReportDTO { get; set; }
        string Month { get; set; }
        IList<GLMDTO00013> IDTO = new List<GLMDTO00013>();
        IList<GLMDTO00013> EDTO = new List<GLMDTO00013>();
        decimal ITotal;
        decimal ETotal;
        decimal GrandTotal;
        decimal CurrentITotal;
        decimal CurrentETotal;
        decimal CurrentGrandTotal;

        public GLMVEW00015()
        {
            InitializeComponent();
        }

        public GLMVEW00015(IList<GLMDTO00013> dtoList, string month)
        {
            this.ReportDTO = dtoList;
            this.Month = month;
            InitializeComponent();
        }
        private void GLMVEW00015_Load(object sender, EventArgs e)
        {
            this.Text = "Income And Expenditure Report For The Month of " + this.Month;
            Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });

            rpvIncomeExpenditure.LocalReport.DataSources.Clear();
            ReportParameter[] para = new ReportParameter[8];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);

            //Image img = null;
            //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            //{
            //    img = System.Drawing.Image.FromStream(stream);

            //    img.Save(tempFilePath);
            //}
            Image img = null;
            string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

            para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            para[5] = new ReportParameter("Month", Month);


            foreach (GLMDTO00013 dto in ReportDTO)
            {
                if (dto.ACTYPE == "I")
                {
                    ITotal = ITotal + dto.AMOUNT;
                    CurrentITotal = CurrentITotal + dto.CAMOUNT;
                }
                else
                {
                    ETotal = ETotal + dto.AMOUNT;
                    CurrentETotal = CurrentETotal + dto.CAMOUNT;
                }
            }

            GrandTotal = ITotal - ETotal;
            string GrandTotalAfterThousandSeparate = "";
            string CurrentGrandTotalAfterThousandSeparate = "";
            //Added by AAM(12_Sep_2018)
            if (GrandTotal != 0) GrandTotalAfterThousandSeparate = GrandTotal.ToString("N2");

            //Commented by AAM(12_Sep_2018)
            //if (GrandTotal != 0)
            //    GrandTotalAfterThousandSeparate = this.ThousandSeparator(GrandTotal.ToString());
            //else GrandTotalAfterThousandSeparate = GrandTotal.ToString();

            para[6] = new ReportParameter("GrandTotal", GrandTotalAfterThousandSeparate);

            CurrentGrandTotal = CurrentITotal - CurrentETotal;
            //Added by AAM(12_Sep_2018)
            if (CurrentGrandTotal != 0) 
                CurrentGrandTotalAfterThousandSeparate = CurrentGrandTotal.ToString("N2");

            //Commented by AAM(12_Sep_2018)
            //if (CurrentGrandTotal != 0)
            //    CurrentGrandTotalAfterThousandSeparate = this.ThousandSeparator(CurrentGrandTotal.ToString());
            //else CurrentGrandTotalAfterThousandSeparate = CurrentGrandTotal.ToString();

            para[7] = new ReportParameter("CurrentGrandTotal", CurrentGrandTotalAfterThousandSeparate);

            this.rpvIncomeExpenditure.LocalReport.EnableExternalImages = true;
            this.rpvIncomeExpenditure.LocalReport.SetParameters(para);
            ReportDataSource dataset = new ReportDataSource("GLMDS00015", ReportDTO);
            this.rpvIncomeExpenditure.LocalReport.DataSources.Add(dataset);
            dataset.Value = ReportDTO;

            this.rpvIncomeExpenditure.RefreshReport();
        }
        public string ThousandSeparator(string myNumber)
        {
            string number = myNumber.ToString().Substring(0, myNumber.Length - 3);
            var myResult = "";
            for (var i = number.Length - 1; i >= 0; i--)
            {
                myResult = number[i] + myResult;
                if ((number.Length - i) % 3 == 0 & i > 0)
                    myResult = "," + myResult;
            }

            return myResult + ".00"; 
        }
    }
}
