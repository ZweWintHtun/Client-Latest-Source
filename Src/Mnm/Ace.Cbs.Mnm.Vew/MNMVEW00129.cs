using System;
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
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00129 : BaseForm, IMNMVEW00129
    {       

        #region Constructor

        public MNMVEW00129()
        {
            InitializeComponent();
        }
          #endregion

        #region controller

        private IMNMCTL00129 linkACController;
        public IMNMCTL00129 Controller
        {
            get
            {
                return this.linkACController;
            }
            set
            {
                this.linkACController = value;
                this.linkACController.View = this;
            }
        }

        #endregion

        IList<PFMDTO00029> LinkAutoPriorityList { get; set; }

        private void MNMVEW00129_Load(object sender, EventArgs e)
        {
            
            this.Hide();
            LinkAutoPriorityList = this.linkACController.SelectLinkAutoPriority(CurrentUserEntity.BranchCode);
            if (LinkAutoPriorityList == null)
            {
                this.Close();
                return;
            }
            this.Show();
            this.Text = "Link Auto Priority Listing";
            Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
            
            rptLinkAccountPriority.LocalReport.DataSources.Clear();
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
            para[5] = new ReportParameter("Head", this.Text);
            para[6] = new ReportParameter("TotalRecords",this.LinkAutoPriorityList.Count.ToString() );

            this.rptLinkAccountPriority.LocalReport.EnableExternalImages = true;
            rptLinkAccountPriority.LocalReport.SetParameters(para);

            //IList<PFMDTO00029> transactionlist = new List<PFMDTO00029>();
            //transactionlist = LinkAutoPriorityList;

            ReportDataSource dataset = new ReportDataSource("LinkAutoPriorityDS", LinkAutoPriorityList);
            rptLinkAccountPriority.LocalReport.DataSources.Add(dataset);
            dataset.Value = LinkAutoPriorityList;

            this.rptLinkAccountPriority.RefreshReport();
            this.rptLinkAccountPriority.RefreshReport();
         
        }
    }
}
