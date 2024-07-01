using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Sam.Ctr.PTR;
using Ace.Windows.CXClient;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Sam.Vew
{
    public partial class SAMVEW00055 : BaseForm, ISAMVEW00055
    {
        public SAMVEW00055()
        {
            InitializeComponent();
        }

        public string CodeType
        {
            get
            {
                if (this.cboCodeType.Text == null)
                {
                    return null;
                }
                else
                {
                    return this.cboCodeType.Text.ToString();
                }
            }
            set
            {
                this.cboCodeType.Text = value;
                this.cboCodeType.SelectedValue = value;
            }
        }

        private ISAMCTL00055 controller;
        public ISAMCTL00055 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                controller.View = this;
            }
        }

        private void SAMVEW00055_Load(object sender, EventArgs e)
        {
            tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.tsbCRUD.butPrint.TabIndex = 0;
            BindCodeTypeCombobox();
        }

        private void BindCodeTypeCombobox()
        {
            Dictionary<string, string> codeType = SpringApplicationContext.Instance.Resolve<Dictionary<string, string>>("CodeType");
            BindingSource codeTypeDS = new BindingSource(codeType, null);
            cboCodeType.DisplayMember = "Key";
            cboCodeType.ValueMember = "Value";
            cboCodeType.DataSource = codeTypeDS;
            cboCodeType.SelectedIndex = -1;
        }

        private void cxcliC0011_ExitButtonClick(object sender, EventArgs e)
        {            
            this.Close();
        }

        private void cxcliC0011_CancelButtonClick(object sender, EventArgs e)
        {
            this.controller.ClearErrors();
            cboCodeType.SelectedIndex = -1;
        }

        private void cboCodeType_Validated(object sender, EventArgs e)
        {
            //if (cboCodeType.SelectedIndex == -1)
            //{
            //    Ace.Windows.Core.Utt.MessageUtilities.ShowMessage(MessageTypes.Information, "Please choose requied Code Type");
            //    cboCodeType.Focus();
            //}
        }

      

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(cboCodeType.Text.ToString()))
            {
                MessageBox.Show("Please Choose Required Code Type!");
                return;
            }
            if (cboCodeType.SelectedValue.ToString() == "Occupation")
            {
                IList<PFMDTO00004> occupationList = this.controller.SelectOccupation();
                if (occupationList.Count > 0)
                    CXUIScreenTransit.Transit("frmSAMVEW00056", true, new object[] { occupationList });
                else
                    CXUIMessageUtilities.ShowMessageByCode("ME90033");   //No Data For Report.
            }
            else if (cboCodeType.SelectedValue.ToString() == "Initial")
            {
                IList<PFMDTO00003> initial = this.controller.SelectInitial();
                if(initial.Count>0)
                CXUIScreenTransit.Transit("frmSAMVEW00057", true, new object[] { initial });
                else
                    CXUIMessageUtilities.ShowMessageByCode("ME90033");  //No Data For Report.
            }
            else if (cboCodeType.SelectedValue.ToString() == "City")
            {
                IList<CityDTO> city = this.controller.SelectCity();               
                if(city.Count>0)
                CXUIScreenTransit.Transit("frmSAMVEW00058", true, new object[] { city });
                else
                    CXUIMessageUtilities.ShowMessageByCode("ME90033");   //No Data For Report.
            }
            else if (cboCodeType.SelectedValue.ToString() == "State/Division")
            {
                IList<StateDTO> state = this.controller.SelectState();
                if(state.Count>0)
                CXUIScreenTransit.Transit("frmSAMVEW00059", true, new object[] { state });
                else
                    CXUIMessageUtilities.ShowMessageByCode("ME90033");   //No Data For Report.
            }
            else
            {
                IList<TownshipDTO> township = this.controller.SelectTownship();
                if(township.Count>0)
                CXUIScreenTransit.Transit("frmSAMVEW00060", true, new object[] { township });
                else
                    CXUIMessageUtilities.ShowMessageByCode("ME90033");   //No Data For Report.
            } 

        }
    }
}
