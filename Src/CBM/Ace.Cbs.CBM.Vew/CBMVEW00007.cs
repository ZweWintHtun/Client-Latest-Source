﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Microsoft.Reporting.WinForms;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Utt;
using System.IO;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXClient.Controls;

namespace Ace.Cbs.CBM.Vew
{
    public partial class CBMVEW00007 : BaseForm
    {
        public CBMVEW00007()
        {
            InitializeComponent();
        }

          public CBMVEW00007(PFMDTO00042 dto)
        {
            this.CashDTO = dto;
            InitializeComponent();
        }

        PFMDTO00042 CashDTO {get;set;}

        private void CBMVEW00002_Load(object sender, EventArgs e)
        {
            this.Text = "Liquidity Ratio";

            Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });

            rptLiquidityRatio.LocalReport.DataSources.Clear();
            ReportParameter[] para = new ReportParameter[6];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);

            Image img = null;
            string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            {
                img = System.Drawing.Image.FromStream(stream);

                img.Save(tempFilePath);
            }

            para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            para[5] = new ReportParameter("Date", CashDTO.IDate.Value.ToString());
            this.rptLiquidityRatio.LocalReport.EnableExternalImages = true;

            rptLiquidityRatio.LocalReport.SetParameters(para);

            IList<PFMDTO00042> list = new List<PFMDTO00042>();
            list.Add(CashDTO);
            ReportDataSource dataset = new ReportDataSource("LiquidityRatioDS", list);
            rptLiquidityRatio.LocalReport.DataSources.Add(dataset);
            dataset.Value = list;

            this.rptLiquidityRatio.RefreshReport();
            this.rptLiquidityRatio.RefreshReport();
        }

        //protected void ExportExcel_Click(object sender, EventArgs e)
        //{
        //    Warning[] warnings;
        //    string[] streamids;
        //    string mimeType;
        //    string encoding;
        //    string extension;
        //    string filename;

        //    byte[] bytes = rptLiquidityRatio.LocalReport.Render(
        //       "Excel", null, out mimeType, out encoding,
        //        out extension,
        //       out streamids, out warnings);

        //    filename = string.Format("{0}.{1}", "ExportToExcel", "xls");
        //    Response.ClearHeaders();
        //    Response.Clear();
        //    Response.AddHeader("Content-Disposition", "attachment;filename=" + filename);
        //    Response.ContentType = mimeType;
        //    Response.BinaryWrite(bytes);
        //    Response.Flush();
        //    Response.End();
        //}
    }
}
