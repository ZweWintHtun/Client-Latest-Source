using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
//using Ace.Cbs.Cx.Com.Ctr;
//using Ace.Cbs.Cx.Com.Utt;
//using Ace.Windows.Core.Utt;
//using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Tcm.Vew
{
    public partial class TCMVEW00028 : BaseForm,ITCMVEW00028
    {
        #region Constructor
        public TCMVEW00028()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties

        public DateTime Date
        {
            get { return this.dtpSdate.Value; }
            set { this.dtpSdate.Text = value.ToString(); }
        }      

        public string Currency
        {
            get 
            {
                if (this.cboCurrency.SelectedValue == null)
                    return null;
                else
                    return this.cboCurrency.SelectedValue.ToString();
            }

            set { this.cboCurrency.SelectedValue = value; }
        }

        #endregion

        #region Controller
        private ITCMCTL00028 controller;
        public ITCMCTL00028 Controller
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

        #region Method
        private void BindCurrencyCombobox()
        {
            IList<CurrencyDTO> CurrencyList = CXCLE00002.Instance.GetListObject<CurrencyDTO>("CurrencyCode.Client.Select", new object[] { true });
            cboCurrency.ValueMember = "Cur";
            cboCurrency.DisplayMember = "Cur";
            cboCurrency.DataSource = CurrencyList;
            cboCurrency.SelectedIndex = 0;
        }

        private void InitializeControls()
        {
            //Enable Disable Menu Controls
            tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.BindCurrencyCombobox();
            this.dtpSdate.Value = DateTime.Now;
            ////Get Date format of Start Date
            //string startDate = this.dtpSdate.ToString();
            //startDate = CXCOM00006.Instance.GetDateFormat(this.Date);
        }

        public void Successful(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }

        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }

        #endregion


        #region Events

        private void TCMVEW00028_Load(object sender, EventArgs e)
        {
            this.InitializeControls();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.controller.ClearCustomErrorMsg();
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
                this.controller.Print();
        }  
    
        #endregion

        

    }
}
