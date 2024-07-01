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
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Loan.Ctr.Ptr;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Loan.Dmd;
using Ace.Cbs.Loan.Dmd.DTO;
using Ace.Windows.Core.Service;
using System.Diagnostics;

namespace Ace.Cbs.Loan.Vew
{
    public partial class LOMVEW00444 : BaseForm, ILOMVEW00444
    {
        //public LOMVEW00444()
        //{
        //    InitializeComponent();
        //}

        public LOMVEW00444()
        {
            InitializeComponent();
        }


        public string SourceBr
        {
            get
            {
                //if (this.cboBranch.SelectedValue == null)
                //{
                //    if (!CurrentUserEntity.IsHOUser)
                //    {
                        //SourceBr = CurrentUserEntity.BranchCode;
                        return CurrentUserEntity.BranchCode;
                    //}
                    //else return null;
                    
                //}
                //else
                //{
                //    return this.cboBranch.SelectedValue.ToString();
                //}
            }
            set { this.SourceBr = value.ToString(); }
        }

        public DateTime Date
        {
            get { return this.dtpDate.Value; }
            set { this.dtpDate.Text = value.ToString(); }
        }
        public string rptName { get; set; }

        private ILOMCTL00444 controller;
        public ILOMCTL00444 Controller
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

        private void LOMVEW00444_Load(object sender, EventArgs e)
        {
            InitializeControls();
        }

        public void InitializeControls()
        {
            tsbCRUD.ButtonEnableDisabled(false, false, false, false, true, true, true);
            this.dtpDate.Value = DateTime.Now;
            cboSortBy.SelectedIndex = 0;
        }

        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            InitializeControls();
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            try
            {
                this.Controller.Print(this.dtpDate.Value, (Convert.ToInt16(this.cboSortBy.SelectedIndex) + 1).ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
