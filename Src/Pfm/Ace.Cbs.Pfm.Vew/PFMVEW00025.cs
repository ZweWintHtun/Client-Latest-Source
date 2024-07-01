using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Microsoft.Reporting.WinForms;

namespace Ace.Cbs.Pfm.Vew
{
    public partial class frmPFMVEW00025 : BaseForm
    {
        #region Entity Variable
        private string customerIds = string.Empty;
        private string customerNames = string.Empty;
        private string nrcs = string.Empty;
        private string address = string.Empty;
        private string occupation = string.Empty;
        private string nationality = string.Empty;
        private string phone = string.Empty;

        private bool isJoint = false;
        public bool IsJoint
        {
            get { return this.isJoint; }
            set { this.isJoint = value; }
        }

        private bool isCompany = false;
        public bool IsCompany
        {
            get { return this.isCompany; }
            set { this.isCompany = value; }
        }

        private PFMDTO00060 EntityDTO { get; set; }
        private PFMDTO00061 headerEntity { get; set; }
        private IList<PFMDTO00001> customers { get; set; }
        #endregion

        #region Constructor
        public frmPFMVEW00025()
        {
            InitializeComponent();
        }

        public frmPFMVEW00025(PFMDTO00060 entity, string param)//Current Individual,Saving Individual,Saving Minor
        {
            InitializeComponent();
            this.EntityDTO = entity;
            this.IsJoint = false;
            this.Text = param;
            this.rpvCurrentAccountIndividual.ZoomMode = ZoomMode.FullPage;
        }

        public frmPFMVEW00025(PFMDTO00061 headerEntity, string param)//Current Joint,Saving Joint
        {
            InitializeComponent();
            this.headerEntity = headerEntity;
            this.customers = headerEntity.Customers;

            if (headerEntity.TransactionStatus == "Current Account (Company)" || headerEntity.TransactionStatus == "Saving Account (Co./Organization)")
            {
                this.isCompany = true;
            }
            else
            {
                this.isJoint = true;
            }

            this.Text = param;
        }
        #endregion

        #region Events
        private void PFMVEW00025_Load(object sender, EventArgs e)
        {
            if (this.headerEntity != null && this.customers.Count > 0)
            {
                if (this.isJoint)
                {
                    this.PrepareReportDataForJoint(this.headerEntity);
                }
                else if (this.isCompany)
                {
                    this.PrepareReportDataForCompany(this.headerEntity);
                }

                //Current Joint,Saving Joint
                ReportParameter[] param = new ReportParameter[15];
                param[0] = new ReportParameter("CustomerId", customerIds);
                param[1] = new ReportParameter("Name", customerNames); // 
                param[2] = new ReportParameter("Address", address);
                param[3] = new ReportParameter("Occupation", occupation);
                param[4] = new ReportParameter("Nationality", nationality);
                param[5] = new ReportParameter("NRC", nrcs);
                param[6] = new ReportParameter("IntroducedBy", this.headerEntity.IntroducedBy);
                param[7] = new ReportParameter("Phone", this.phone);
                param[8] = new ReportParameter("BankName", this.headerEntity.BankName);
                param[9] = new ReportParameter("BranchName", this.headerEntity.BranchName);
                param[10] = new ReportParameter("Currency", this.headerEntity.CurrencyCode);
                param[11] = new ReportParameter("Date", DateTime.Now.ToString(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.UIDateFormat)));
                param[12] = new ReportParameter("TypeOfAccount", this.headerEntity.TypeOfAccount);
                param[13] = new ReportParameter("TransactionStatus", this.headerEntity.TransactionStatus);
                param[14] = new ReportParameter("CustomerIdIndividual", customerIds);

                Image img = null;
                string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                {
                    img = System.Drawing.Image.FromStream(stream);

                    img.Save(tempFilePath);
                }

                param[14] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                this.rpvCurrentAccountIndividual.LocalReport.EnableExternalImages = true;
                this.rpvCurrentAccountIndividual.LocalReport.SetParameters(param);
            }
            else if (this.EntityDTO != null)
            {
                //Current Individual,Saving Individual,Saving Minor
                ReportParameter[] param = new ReportParameter[16];
                param[0] = new ReportParameter("CustomerId", this.EntityDTO.CustomerId);
                param[1] = new ReportParameter("Name", this.EntityDTO.Name);
                param[2] = new ReportParameter("Address", this.EntityDTO.Address);
                param[3] = new ReportParameter("Occupation", this.EntityDTO.Occupation);
                param[4] = new ReportParameter("Nationality", this.EntityDTO.Nationality);
                param[5] = new ReportParameter("NRC", this.EntityDTO.NRC);
                param[6] = new ReportParameter("IntroducedBy", this.EntityDTO.IntroducedBy);
                param[7] = new ReportParameter("Phone", this.EntityDTO.Phone);
                param[8] = new ReportParameter("BankName", this.EntityDTO.BankName);
                param[9] = new ReportParameter("BranchName", this.EntityDTO.BranchName);
                param[10] = new ReportParameter("Currency", this.EntityDTO.Currency);
                param[11] = new ReportParameter("Date", DateTime.Now.ToString(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.UIDateFormat)));
                param[12] = new ReportParameter("TypeOfAccount", this.EntityDTO.TypeOfAccount);
                param[13] = new ReportParameter("TransactionStatus", string.Empty);
                param[14] = new ReportParameter("CustomerIdIndividual", this.EntityDTO.CustomerId);

                Image img = null;
                string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                {
                    img = System.Drawing.Image.FromStream(stream);

                    img.Save(tempFilePath);
                }

                param[15] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                this.rpvCurrentAccountIndividual.LocalReport.EnableExternalImages = true;

                this.rpvCurrentAccountIndividual.LocalReport.SetParameters(param);
                
            }

            this.rpvCurrentAccountIndividual.SetDisplayMode(DisplayMode.PrintLayout);
            this.rpvCurrentAccountIndividual.ZoomMode = ZoomMode.FullPage;
            this.rpvCurrentAccountIndividual.ZoomPercent = 75;
            this.rpvCurrentAccountIndividual.RefreshReport();
        }

        private void PrepareReportDataForCompany(PFMDTO00061 entity)
        {
            customerIds = entity.Customers[0].CustomerId;
            customerNames = "(" + entity.NameOfFirm + ") " + entity.Customers[0].Name;
            nrcs = entity.Customers[0].NRC;
            address = entity.Address;
            phone = entity.Phone;
            nationality = entity.Customers[0].Nationality;
            occupation = entity.Customers[0].OccupationDesp;

            for (int i = 1; i < entity.Customers.Count; i++)
            {
                customerIds += ", " + entity.Customers[i].CustomerId;
                customerNames += ", " + entity.Customers[i].Name;
                nrcs += ", " + entity.Customers[i].NRC;
                nationality += ", " + entity.Customers[i].Nationality;
                occupation += ", " + entity.Customers[i].OccupationDesp;
            }
        }

        private void PrepareReportDataForJoint(PFMDTO00061 entity)
        {
            customerIds = entity.Customers[0].CustomerId;
            customerNames = entity.Customers[0].Name;
            address = entity.Customers[0].Address + "," + entity.Customers[0].TownshipDesp + "," + entity.Customers[0].CityDesp + "," + entity.Customers[0].StateDesp;
            phone = entity.Customers[0].PhoneNo;
            nrcs = entity.Customers[0].NRC;
            nationality = entity.Customers[0].Nationality;
            occupation = entity.Customers[0].OccupationDesp;

            for (int i = 1; i < entity.Customers.Count; i++)
            {
                customerIds += ", " + entity.Customers[i].CustomerId;
                customerNames += ", " + entity.Customers[i].Name;
                phone += ", " + entity.Customers[i].PhoneNo;
                nrcs += ", " + entity.Customers[i].NRC;
                nationality += ", " + entity.Customers[i].Nationality;
                occupation += ", " + entity.Customers[i].OccupationDesp;
            }
        }
        #endregion
    }
}
