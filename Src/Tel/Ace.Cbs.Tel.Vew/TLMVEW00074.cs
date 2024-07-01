using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Ace.Windows.Core.Utt;
using Microsoft.Reporting.WinForms;
using System.IO;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient.Controls;


namespace Ace.Cbs.Tel.Vew
{
    public partial class TLMVEW00074 : BaseDockingForm
    {
        private IList<TLMDTO00054> _printData;
        private IList<TLMDTO00054> PrintDataList
        {
            get
            {
                if (_printData == null)
                    return new List<TLMDTO00054>();
                else
                    return _printData;
            }
            set
            {
                _printData = value;
            }
        }

        private string Status { get; set; }
        
        public TLMVEW00074()
        {
            InitializeComponent();
        }

        public TLMVEW00074(string status,IList<TLMDTO00054> printData)
        {
            this.PrintDataList = printData;
            this.Status = status;
            InitializeComponent();
        }

        private void TLMVEW00074_Load(object sender, EventArgs e)
        {
            this.Text = "Drawing Remittance Register Enty ("+this.Status+")";
            this.rpvDrawingRemitEntry.LocalReport.DataSources.Clear();
            ReportParameter[] para = new ReportParameter[2];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);


            Image img = null;
            string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            
            using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            {
                img = System.Drawing.Image.FromStream(stream);

                img.Save(tempFilePath);
            }
            para[1] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            this.rpvDrawingRemitEntry.LocalReport.EnableExternalImages = true;
            this.rpvDrawingRemitEntry.LocalReport.SetParameters(para);
            this.rpvDrawingRemitEntry.RefreshReport();
            ReportDataSource dataset = new ReportDataSource("DrawingRemitDataSet", this.PrintDataList);
            this.rpvDrawingRemitEntry.LocalReport.DataSources.Add(dataset);
            dataset.Value = this.PrintDataList;
            this.rpvDrawingRemitEntry.LocalReport.Refresh();
            this.rpvDrawingRemitEntry.RefreshReport();
            this.rpvDrawingRemitEntry.RefreshReport();
        }
    }
}
