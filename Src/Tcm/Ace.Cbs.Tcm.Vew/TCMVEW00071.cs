using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Windows.CXClient;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Tcm.Vew
{
    public partial class TCMVEW00071 : BaseForm,ITCMVEW00071
    {
        #region Constructor
        public TCMVEW00071()
        {
            InitializeComponent();
        }
        #endregion

        #region Controller
        private ITCMCTL00071 controller;
        public ITCMCTL00071 Controller
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
        #endregion

        #region Methods

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);

        }

        public void Failure(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }

        #endregion

        private void TCMVEW00071_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
            this.lblTodayDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void btnBackupNow_Click(object sender, EventArgs e)
        {
            if (CurrentUserEntity.IsHOUser)
            {
                string result = string.Empty;
                if (rdoImmediateBackup.Checked)
                {
                    result = this.Controller.BackupDatabaseImmediately();
                }
                else if (rdoDailyBackup.Checked)
                {
                    result = this.Controller.BackupDatabaseDaily();
                }
                else if (rdoBeforeBackup.Checked)
                {
                    result = this.Controller.BackupDatabaseBefore();
                }
                else if (rdoAfterBackup.Checked)
                {
                    result = this.Controller.BackupDatabaseAfter();
                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode("MV40001");//Please select one of the backup devices!
                }

                if (!String.IsNullOrEmpty(result))
                {
                    CXUIMessageUtilities.ShowMessageByCode("MI40001");//Database Backup Successfully Finished!
                }
            }
            else
            {
                CXUIMessageUtilities.ShowMessageByCode("MI40002");//You don't have permission for this function. 
            }
            
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
