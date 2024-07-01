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
using Ace.Cbs.Gl.Ctr.Ptr;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Utt;
namespace Ace.Cbs.Gl.Vew
{
    public partial class GLMVEW00011 : BaseForm, IGLMVEW00011
    {
        string formStatus;
        string formName;
        IList<GLMDTO00001> formatFileList;

        #region Properties
        public string FormName
        {
            get { return this.formName; }
        }
        public string Currency
        {
            get { return cboCurrency.SelectedValue == null ? string.Empty : cboCurrency.SelectedValue.ToString(); }
            set { cboCurrency.SelectedValue = value; }
        }
        public string Header
        {
            get { return txtReportHeading.Text; }
            set { txtReportHeading.Text = value; }
        }
        public string ReportFormat
        {
            get
            {
                if (rdoActualFigures.Checked)
                    return "AF";    //Actual Figures
                else if (rdoBudgetedAndActualFigures.Checked)
                    return "BAF";   //Budgeted and Actual Figures
                else
                    return "MF";    //Monthly Figures
            }
        }
        public string MonthText
        {
            get { return this.txtRequiredMonth.Text; }
        }
      
        public int Month { get; set; }
      
        public bool isHomeCurrency 
        {
            get { return this.rdoByHomeCurrency.Checked; }
        }
        #endregion
       
        #region Controller
        IGLMCTL00011 controller;
        public IGLMCTL00011 Controller
        {
            get { return this.controller; }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }
        #endregion

        public GLMVEW00011()
        {
            InitializeComponent();
        }

        public GLMVEW00011(string formName, string formStatus)
        {
            InitializeComponent();
            this.formName = formName +" Format Type Selection";
            this.formStatus = formStatus;
        }

        private void rdoBySourceCurrency_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoByHomeCurrency.Checked)
            {
                this.DisableControls("ReportStatement.DisableCurrency");
                this.cboCurrency.SelectedIndex = 0;
            }
            else
                this.EnableControls("ReportStatement.EnableCurrency");
        }

        private void GLVEW00011_Load(object sender, EventArgs e)
        {
            this.Text = this.formName;
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);

            switch (this.formStatus)
            {
                case "PL": this.formatFileList = this.controller.SelectFormatFile("PL"); break;
                case "BS": this.formatFileList = this.controller.SelectFormatFile("BS"); break;
                case "TB": this.formatFileList = this.controller.SelectFormatFile("TB"); break;
                case "IE": this.formatFileList = this.controller.SelectFormatFile("IE"); break;
            }

            IList<GLMDTO00001> formatFileInfo = (from value in this.formatFileList
                                                 where !string.IsNullOrEmpty(value.ACode)
                                                 select value).ToList();

            IList<CurrencyDTO> CurrencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });
            cboCurrency.ValueMember = "Cur";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = CurrencyList;
            cboCurrency.SelectedIndex = 0;

            this.gvFormatStyle.AutoGenerateColumns = false;
            this.gvFormatStyle.DataSource = null;
            this.gvFormatStyle.DataSource = this.formatFileList;

            txtRequiredMonth.Text = DateTime.Now.ToString("MMMM");
            this.DisableControls("ReportStatement.DisableCurrency");
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtRequiredMonth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRequiredMonth.SelectedText))
            {
                txtRequiredMonth.Text = string.Empty;
            }
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                goto end;
            }
            if (string.IsNullOrEmpty(txtRequiredMonth.Text))
            {
                if (e.KeyChar == 48)
                    e.Handled = true;
            }
            else
            {
                if (txtRequiredMonth.Text.Length == 2)
                {
                    e.Handled = true;
                }
                else if (txtRequiredMonth.Text == "1")
                {
                    if (e.KeyChar != 48 && e.KeyChar != 49 && e.KeyChar != 50)
                        e.Handled = true;
                }
                else
                {
                    e.Handled = true;
                }
            }


        end:
            if (e.KeyChar == '\b')
            {
                e.Handled = false;
            }
        }

        private void txtRequiredMonth_Leave(object sender, EventArgs e)
        {  
            if (Convert.ToInt32(this.MonthText) > DateTime.Now.Month)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV30022, new object[] { this.MonthText, DateTime.Now.Month });  //Month {0} cannot be greater than Today {1}.
                this.txtRequiredMonth.Focus();
            }
            else
            {
                DateTime date = Convert.ToDateTime(txtRequiredMonth.Text + "/01/2014");
                this.Month = Convert.ToInt32(txtRequiredMonth.Text);
                txtRequiredMonth.Text = date.ToString("MMMM");
            }           
        }

        private void txtRequiredMonth_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRequiredMonth.Text)) return;
            DateTime date = Convert.ToDateTime(txtRequiredMonth.Text + "/01/2014");
            txtRequiredMonth.Text = date.Month.ToString();
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            if (CheckDate())
            {
                if (this.formatFileList != null && this.formatFileList.Count > 0)
                {
                    GLMDTO00001 selectedRow = (GLMDTO00001)this.gvFormatStyle.SelectedRows[0].DataBoundItem;
                    this.Controller.PreView(selectedRow.FormatType, selectedRow.FormatStatus);
                }
                else
                   Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI90019);
                    //MessageBox.Show("There is No Data to show in GridView. Please Insert Report Format Entry First");
            }
        }

        public bool CheckDate()
        {
            bool date = CXCOM00006.Instance.IsValidStartDateEndDate(this.dtpStartDate.Value, this.dtpEndDate.Value);           
            return date;
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.Initial_Control_State();
        }

        public void Initial_Control_State()
        {
            this.rdoByHomeCurrency.Checked = true;
            this.cboCurrency.SelectedIndex = 0;
            this.rdoActualFigures.Checked = true;
            this.txtRequiredMonth.Text = DateTime.Now.ToString("MMM");
            this.dtpStartDate.Text = DateTime.Now.ToString();
            this.dtpEndDate.Text = DateTime.Now.ToString();
            this.txtReportHeading.Text = string.Empty;
        }

        private void txtRequiredMonth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{Tab}");
            }
        }
    }
}
