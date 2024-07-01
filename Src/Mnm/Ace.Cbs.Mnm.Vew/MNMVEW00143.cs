using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Utt;
using System.IO;
using Microsoft.Reporting.WinForms;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Mnm.Ctr.Ptr;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00143 : BaseForm, IMNMVEW00143
    {
        public MNMVEW00143()
        {
            InitializeComponent();
        }

        public MNMVEW00143(string formname,IList<MNMDTO00043> FiList)
        {
            //InitializeComponent();
            this.FormName = formname;
            this.PrintDataFiList = FiList;
          //  this.StartDate = startDate;
       }


        #region Properties

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Header { get; set; }
        public IList<MNMDTO00043> PrintDataFiList { get; set; }
      
        public string FormName { get; set; }

        #endregion

        #region Controller
        private IMNMCTL00143 controller;
        public IMNMCTL00143 Controller
        {
            get { return this.controller; }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }

        #endregion

        #region Event

        private void MNMVEW00143_Load(object sender, EventArgs e)
        {

            this.Hide();
          PrintDataFiList = controller.showReport(FormName);

            if (PrintDataFiList == null)
            {
                this.Close();
                return;
            }
            this.Show();
            this.Text = this.FormName + " Listing ";
            Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });


            this.rpvFixedYearEndInterest.LocalReport.DataSources.Clear();
            ReportParameter[] para = new ReportParameter[10];
            para[0] = new ReportParameter("BankName", CurrentUserEntity.BranchDescription);
            para[1] = new ReportParameter("BranchName", Branch.Address);
            para[2] = new ReportParameter("Phone", Branch.Phone);
            para[3] = new ReportParameter("Fax", Branch.Fax);
            para[7] = new ReportParameter("BrCode", Branch.BranchCode);
            para[8] = new ReportParameter("Br_Alias", Branch.Bank_Alias);
            para[9] = new ReportParameter("DateTime", Convert.ToDateTime(PrintDataFiList[0].LasIntDate).ToString("dd/MM/yyyy"));
           
             Image img = null;
            string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
            using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
            {
                img = System.Drawing.Image.FromStream(stream);

                img.Save(tempFilePath);
            }

            para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
            para[5] = new ReportParameter("Head", FormName + " Listing as at ");
            para[6] = new ReportParameter("TotalRecords", this.PrintDataFiList.Count.ToString());

            this.rpvFixedYearEndInterest.LocalReport.EnableExternalImages = true;
            this.rpvFixedYearEndInterest.LocalReport.SetParameters(para);
            ReportDataSource dataset = new ReportDataSource("DSMNMDTO00043", PrintDataFiList);
            this.rpvFixedYearEndInterest.LocalReport.DataSources.Add(dataset);
            dataset.Value = PrintDataFiList;
            this.rpvFixedYearEndInterest.LocalReport.Refresh();
            this.rpvFixedYearEndInterest.RefreshReport();
        }
       
        private void MNMVEW00143_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.rpvFixedYearEndInterest.LocalReport.ReleaseSandboxAppDomain();
        }

        #endregion 

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MNMVEW00143));
            this.MNMDTO00043BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rpvFixedYearEndInterest = new Microsoft.Reporting.WinForms.ReportViewer();
            this.MNMDTO00010BindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.MNMDTO00043BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MNMDTO00010BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rpvFixedYearEndInterest
            // 
            this.rpvFixedYearEndInterest.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DSMNMDTO00043";
            reportDataSource1.Value = this.MNMDTO00043BindingSource;
            this.rpvFixedYearEndInterest.LocalReport.DataSources.Add(reportDataSource1);
            this.rpvFixedYearEndInterest.LocalReport.ReportEmbeddedResource = "Ace.Cbs.Mnm.Vew.MNM_RDLC.MNMRDLC00092.rdlc";
            this.rpvFixedYearEndInterest.Location = new System.Drawing.Point(0, 0);
            this.rpvFixedYearEndInterest.Name = "rpvFixedYearEndInterest";
            this.rpvFixedYearEndInterest.Size = new System.Drawing.Size(615, 460);
            this.rpvFixedYearEndInterest.TabIndex = 0;
            // 
            // MNMVEW00143
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(615, 460);
            this.Controls.Add(this.rpvFixedYearEndInterest);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MNMVEW00143";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MNMVEW00143_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MNMDTO00043BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MNMDTO00010BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        private ReportViewer rpvFixedYearEndInterest;

        private void MNMVEW00143_Load_1(object sender, EventArgs e)
        {

            this.rpvFixedYearEndInterest.RefreshReport();
        }

        private BindingSource MNMDTO00010BindingSource;
        private IContainer components;
        private BindingSource MNMDTO00043BindingSource;

      
    }
}
