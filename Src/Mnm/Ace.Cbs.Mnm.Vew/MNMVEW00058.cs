using System;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Mnm.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00058 : BaseForm, IMNMVEW00058
    {
        #region Constructor
        public MNMVEW00058()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties

      
        public DateTime StartDate
        {
            get
            {
                return this.dtpStartDate.Value;
            }
            set
            {
                this.dtpStartDate.Text = value.ToString();
            }

        }

        public DateTime EndDate
        {
            get
            {
                return this.dtpEndDate.Value;
            }
            set
            {
                this.dtpEndDate.Text = value.ToString();
            }

        }

        private string status { get; set; }
        private string formName = string.Empty;
        public string FormName
        {
            get { return this.formName; }
            set { this.formName = value; }
        }

        public string currencyNo
        {
            get
            {
                if (this.cboCurrency.Text == string.Empty)
                    return string.Empty;
                else
                    return this.cboCurrency.Text;
            }
            set
            {
                this.cboCurrency.Text = value;
            }
        }

        #endregion

        #region controller

        private IMNMCTL00058 controller;
        public IMNMCTL00058 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }

        #endregion

        #region Events

        private void MNMVEW00058_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.Text = this.FormName;
            this.dtpStartDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            this.dtpEndDate.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            this.BindCurrency();
            this.rdoAll.Checked = true;
         
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }


        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.dtpEndDate.Text = DateTime.Now.ToShortDateString();
            this.dtpStartDate.Text = DateTime.Now.ToShortDateString();
            this.cboCurrency.Focus();
            this.rdoAll.Checked = true;
            this.controller.ClearCustomErrorMessage();
            this.cboCurrency.SelectedIndex = 0;
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (this.Controller.Validate_Form())
                {
                    // Check dtpStartDate Date Time
                    if (this.dtpStartDate.Value.Date > DateTime.Now.Date)
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00129, this.dtpStartDate.Value.ToString("dd/MM/yyyy"));//Datetime cannot be greater than today date.
                        this.dtpStartDate.Focus();
                        return;
                    }

                    // Check dtpEndDate Date Time
                    else if (this.dtpEndDate.Value.Date > DateTime.Now.Date)
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00130, this.dtpEndDate.Value.ToString("dd/MM/yyyy"));//Datetime cannot be greater than today date.
                        this.dtpEndDate.Focus();
                        return;
                    }

                    else if (dtpStartDate.Value.Date > this.dtpEndDate.Value.Date)
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00131);//Start Date must not be greater than End Date.
                        this.dtpEndDate.Focus();
                        return;
                    }

                    if (rdoOnlyPrinciple.Checked) status = "12";
                    else if (rdoOther.Checked) status = "00";   //edit by ASDA
                    else if (rdoPrincipleAndInterest.Checked) status = "11";
                    else status = "";
                    this.controller.Print(this.StartDate, this.EndDate, this.currencyNo, status);

                }
            }

            catch (Exception ex)
            {
                throw new Exception(CXMessage.ME90043, ex);   //Unexpected Error Occurs
            }

        }

        private void BindCurrency()
        {
            IList<CurrencyDTO> currencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });
            cboCurrency.ValueMember = "Cur";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = currencyList;
            cboCurrency.SelectedIndex = 0;
        }

        #endregion


    }
}
