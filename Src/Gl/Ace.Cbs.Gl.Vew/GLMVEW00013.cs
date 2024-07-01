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
using Ace.Cbs.Gl.Ctr.Ptr;
using Ace.Cbs.Gl.Dmd;

namespace Ace.Cbs.Gl.Vew
{
    public partial class GLMVEW00013 : BaseForm, IGLMVEW00013
    {
        private IGLMCTL00013 controller;
        public IGLMCTL00013 Controller
        {
            get { return this.controller; }
            set
            {
                this.controller = value;
                this.controller.view = this;
            }
        }

        public GLMVEW00013()
        {
            InitializeComponent();
        }

        private void GLMVEW00013_Load(object sender, EventArgs e)
        {
            IList<GLMDTO00013> DTOList = this.controller.SelectDataVW_COA_List();

            Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });

            rpvCOAListing.LocalReport.DataSources.Clear();
            ReportParameter[] para = new ReportParameter[5];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);

            //Commented by HWKO (31-Oct-2017)
            //Image img = null;
            //string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            //using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            //{
            //    img = System.Drawing.Image.FromStream(stream);

            //    img.Save(tempFilePath);
            //}

            string tempFilePath = Application.StartupPath + "\\pristinelogo.png";

            para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);

            this.rpvCOAListing.LocalReport.EnableExternalImages = true;
            rpvCOAListing.LocalReport.SetParameters(para);
            ReportDataSource dataset = new ReportDataSource("GLMDS00013", DTOList);
            rpvCOAListing.LocalReport.DataSources.Add(dataset);
            dataset.Value = DTOList;

            this.rpvCOAListing.RefreshReport();
        }

        public IGLMVEW00013 view
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
