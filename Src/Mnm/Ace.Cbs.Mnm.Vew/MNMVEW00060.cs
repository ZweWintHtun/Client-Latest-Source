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
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00060 : BaseForm ,IMNMVEW00060
    {
        public MNMVEW00060()
        {
            InitializeComponent();
        }

        #region controller

        private IMNMCTL00060 controller;
        public IMNMCTL00060 Controller
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


        private string requiredDuration;

        public string RequiredDuration
        {
            get
            {
                if (this.cboRequiredDuration.Text == string.Empty)
                    return string.Empty;
                else
                    return this.cboRequiredDuration.Text;
            }
            set
            {
                this.cboRequiredDuration.Text = value;
            }
        }

        private void MNMVEW00060_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.BindDuration();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.controller.ClearCustomErrorMessage();
            this.cboRequiredDuration.SelectedIndex = -1;
            this.cboRequiredDuration.Focus();

        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            this.controller.Print(cboRequiredDuration.SelectedValue.ToString());
        }

        private void BindDuration()
        {
            IList<PFMDTO00007> fixRateList = this.controller.SelectDuration();
            cboRequiredDuration.ValueMember = "Duration";
            cboRequiredDuration.DisplayMember = "Description";
            cboRequiredDuration.DataSource = fixRateList;
            cboRequiredDuration.SelectedIndex = -1; 
        }


    }
}
