using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00030 : BaseForm,IMNMVEW00030
    {
        #region Constructor
        public MNMVEW00030()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        public DateTime Date
        {
            get { return this.dtpDate.Value; }
            set { this.dtpDate.Text = value.ToString(); }
        }

        public IList<PFMDTO00032> records { get; set; }
        #endregion

        #region Controller
        private IMNMCTL00030 controller;
        public IMNMCTL00030 Controller
        {
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
            get
            {
                return this.controller;
            }
        }
        #endregion     

        #region Methods
        private void InitializeControls()
        {
            //Enable Disable Menu Controls

            tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, false, true);
            this.gvFixedDepositCertificate.DataSource = null;
            this.btnPreview.Enabled = false;
        }

        public void gvFixedDepositCertificate_DataBind(IList<PFMDTO00032> records)
        {
            this.gvFixedDepositCertificate.DataSource = null;
            gvFixedDepositCertificate.AutoGenerateColumns = false;
            this.gvFixedDepositCertificate.DataSource = records;
        }
        #endregion

        #region"Public Methods"

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
            this.InitializeControls();
        }

        public void Failure(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }

        #endregion

        #region Events

        private void MNMVEW00030_Load(object sender, EventArgs e)
        {
            this.InitializeControls();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.dtpDate.Value = DateTime.Now;
            this.InitializeControls();
        }

        //Updated By HWKO (27-Apr-2017)
        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            IList<PFMDTO00032> printLists = this.records.Where<PFMDTO00032>(x => x.IsCheck == true).ToList();
            if (printLists.Count > 0)
            {
                //this.Controller.DirectPrint(printLists);
                CXUIScreenTransit.Transit("frmFixedDepositCertificateDirectPrinting", true, new object[] { printLists });
            
                //Direct Print Testing Code Start Here
                //this.Controller.DirectPrintUsingRDLC(printLists);
            }
            else
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV90012");
            }            
        }

        private void dtpDate_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Keys)e.KeyCode == Keys.Enter || (Keys)e.KeyCode == Keys.Tab)
            {
                if (!CXCOM00006.Instance.IsExceedTodayDate(this.Date))
                {
                    records = this.controller.SelectFReceiptData();
                    this.gvFixedDepositCertificate.DataSource = null;
                    if (records.Count > 0)
                    {
                        this.gvFixedDepositCertificate_DataBind(records);
                        tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
                        this.btnPreview.Enabled = true;
                    }
                    else
                    {
                        //records is null
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Print.
                    }
                }
                else
                {
                    this.gvFixedDepositCertificate.DataSource = null;
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00160, this.Date.ToShortDateString());//Require Date is not greater than today.
                }
            }
        }

        private void MNMVEW00030_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }

        //Updated By HWKO (26-Apr-2017)
        private void btnPreview_Click(object sender, EventArgs e)
        {
            IList<PFMDTO00032> printLists = this.records.Where<PFMDTO00032>(x => x.IsCheck == true).ToList();
            if (printLists.Count > 0)
            {
                CXUIScreenTransit.Transit("frmFixedDepositCertificatePrinting", true, new object[] { printLists });
            }
            else
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MV90012");
            }
        }

        #endregion
    }
}
