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
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Tcm.Ctr.Ptr;

namespace Ace.Cbs.Tcm.Vew
{
    public partial class TCMVEW00010 : BaseDockingForm, ITCMVEW00010
    {
        #region Constructor
        public TCMVEW00010()
        {
            InitializeComponent();
        }

        
        public TCMVEW00010(string status)
        {
            InitializeComponent();
            _status = status;            
        }
        #endregion

        #region Properties
        private string _status = string.Empty; 
        public string Status
        {
            get { return this._status; }
            set { this._status = value; }
        }        

        public DateTime StartDate
        {
            get { return this.dtpStartDate.Value; }
            set { this.dtpStartDate.Text = value.ToString(); }
        }

        public DateTime EndDate
        {
            get { return this.dtpEndDate.Value; }
            set { this.dtpEndDate.Text = value.ToString(); }
        }

        private ITCMCTL00010 controller;
        public ITCMCTL00010 Controller
        {
            get { return this.controller; }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }

        #endregion

        #region Method

        public void InitializeControls()
        {
            tsbCRUD.ButtonEnableDisabled(false, false, false, true, true, false, true);
            this.dtpStartDate.Value = DateTime.Now;
            this.dtpEndDate.Value = DateTime.Now;
            if(this._status == "P")
                this.Text = "Cash Payment Denominaton Delete";
            else if (this._status == "R")
                this.Text = "Cash Receipt Denominaton Delete";
            else
                this.Text = "Cash Receipt And Payment Denominaton Delete";
        }

        #endregion

        #region Event
        private void TCMVEW00010_Load(object sender, EventArgs e)
        {
            this.InitializeControls();
        }
       
        private void tsbCRUD_CancelButtonClick(object sender, EventArgs e)
        {
            this.InitializeControls();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbCRUD_DeleteButtonClick(object sender, EventArgs e)
        {
            if (this.Controller.Check_Data())
            {
                if (CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC30009) == DialogResult.Yes) //"Do you want to print Denomination reports before delete ?"
                {
                    CXUIMessageUtilities.ShowMessageByCode(CXMessage.MI00064); //"Go listing menu,Please print the reports " 
                }
                else
                {
                    if (CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC900011) == DialogResult.Yes)
                    {
                        this.Controller.Delete();
                    }
                }
            }            
        }

        #endregion
    }
}
