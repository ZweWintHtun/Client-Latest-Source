using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Core.Utt;
using System.Windows.Forms;
using System.IO;
using Microsoft.Reporting.WinForms;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00081 : BaseForm, IMNMVEW00081
    {
        public MNMVEW00081()
        {
            InitializeComponent();
        }

        IList<MNMDTO00081> ReportDTOList = new List<MNMDTO00081>();

        #region Controller

        private IMNMCTL00081 controller;
        public IMNMCTL00081 Controller
        {
            get { return this.controller; }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }

        #endregion

        public void SelectInfomationForFreceipt()
        {
            ReportDTOList = this.Controller.SelectFreceipt();          
        }

        private void MNMVEW00081_Load(object sender, EventArgs e)
        {
            this.Hide();
            this.Text = "Interest Outstanding Listing";
            this.SelectInfomationForFreceipt();
            if (ReportDTOList.Count > 0)
            {
                this.Show();
                Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                rpvMNMVEW00081.LocalReport.DataSources.Clear();
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
                para[5] = new ReportParameter("Count", ReportDTOList.Count.ToString());

                this.rpvMNMVEW00081.LocalReport.EnableExternalImages = true;
                rpvMNMVEW00081.LocalReport.SetParameters(para);
                ReportDataSource dataset = new ReportDataSource("MNMDS00081", ReportDTOList);
                rpvMNMVEW00081.LocalReport.DataSources.Add(dataset);
                dataset.Value = ReportDTOList;

                this.rpvMNMVEW00081.RefreshReport();
                this.rpvMNMVEW00081.RefreshReport();
            }
            else
            {
                this.Close();
            }
        }
    }
}
