//----------------------------------------------------------------------
// <copyright file="TLMVEW00006.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Ye Mann Aung</CreatedUser>
// <CreatedDate>26/09/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXClient;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Dmd;
using System.Linq;



namespace Ace.Cbs.Tel.Vew
{
    public partial class frmTLMVEW00017 : BaseDockingForm,ITLMVEW00017
    {
        #region "Properties"

        private ITLMCTL00017 _controller;
        public ITLMCTL00017 Controller
        {
            get
            {
                return this._controller;
            }
            set
            {
                this._controller = value;
                _controller.View = this;
            }
        }

        public string TransactionStatus { get; set; }
        public string Status { get; set; }

        private IList<TLMDTO00017> rddto;
        public IList<TLMDTO00017> RDDto
        {
            get
            {
                if (this.rddto == null)
                    this.rddto = new List<TLMDTO00017>();
                return rddto;
            }
            set
            {
                this.rddto = value;
            }
        }

        private IList<TLMDTO00001> redto;
        public IList<TLMDTO00001> REDTO
        {
            get
            {
                if (this.redto == null)
                {
                    this.redto = new List<TLMDTO00001>();
                }
                return redto;
            }
            set
            {
                this.redto = value;
            }
        }

        public int ProcessTime
        {
            get
            {
                return Convert.ToInt32(this.txtConnectTimeOutSeconds.Value);


            }
            set
            {
                this.txtConnectTimeOutSeconds.Text = Convert.ToString(value);
            }
        }

        public int IntervalTime
        {
            get
            {
                return Convert.ToInt32(this.txtProcessInterval.Value);
            }
            set
            {
                this.txtProcessInterval.Text = Convert.ToString(value);
            }
        }


        public string ParentFormId
        {
            get { return this.Name; }
        }

        private CXDMD00010 currentFormPermissionEntity;
        public CXDMD00010 CurrentFormPermissionEntity
        {
            get
            {
                if (this.currentFormPermissionEntity == null)
                    this.currentFormPermissionEntity = new CXDMD00010();
                return this.currentFormPermissionEntity; 
            }
            set
            { this.currentFormPermissionEntity = value; }
        }

        public String[] PasstingStatus { get; set; }
        public bool isResume { get; set; }

        public string RegisterNo { get; set; }
        
        public DateTime SettlementDate { get; set; }
        public bool isSelected { get; set; }
        
        #endregion

        #region "Constructor"
        public frmTLMVEW00017(string screenName)
        {
            InitializeComponent();
            this.TransactionStatus=screenName;
            this.Text=this.TransactionStatus;
            this.pnlLog.Visible = false;
            this.Status = "Drawing.Remittance";
        }

        public frmTLMVEW00017()
        {
            InitializeComponent();
            this.pnlLog.Visible = false;
            DisableEnableControls(false);
            this.Text = "IBL Encash Remittance Passing";
            this.Status = "Encash.Remittance";
        }
        #endregion

        #region Methods

        /// <summary>
        /// To hide unnecessary columns of GridView according to Transaction Status.
        /// </summary>
        /// <param name="isenable"></param>
        private void DisableEnableControls(bool isenable)
        {
            butPause.Visible = isenable;
            butClearLog.Visible = isenable;
            butProcess.Visible = isenable;
            butLog.Visible = isenable;
            lblConnectTimeOut.Visible = isenable;
            lblProcessInterval.Visible = isenable;
            txtConnectTimeOutSeconds.Visible = isenable;
            txtProcessInterval.Visible = isenable;

            this.colIsSelected.Visible = isenable;
            this.colAccountNo.Visible = isenable;
            this.colComission.Visible = isenable;
            this.colIBLCharges.Visible = isenable;
            this.colToAccountNo.Visible = !isenable;
            this.colBranchNo.DataPropertyName = "EBank";
            this.gvDrawingRemittance.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public void BindGridData()
        {
            gvDrawingRemittance.DataSource = null;
            gvDrawingRemittance.AutoGenerateColumns = false;
            if (this.Status.Equals("Drawing.Remittance"))
                gvDrawingRemittance.DataSource = this.Controller.GetRDData(this.TransactionStatus);
            else
                gvDrawingRemittance.DataSource = this.Controller.GetREData(CurrentUserEntity.BranchCode);  
                //gvDrawingRemittance.DataSource = this.Controller.GetREData();
        }

        public void AddStatusToListbox(string status)
        {
            this.gvDrawingRemittance.DataSource = this.RDDto;
            this.lbLog.Items.Add(status);
        }

        public void Failure(string message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(message);
        }

        public void Successful(IList<TLMDTO00017> rdList)
        {
            this.gvDrawingRemittance.DataSource = rdList;
        }

        private void StartTimer()
        {
            timerConnectTimeOut.Interval = ProcessTime * 1000;
            timerConnectTimeOut.Start();
        }

        private void StopTimer()
        {
            timerConnectTimeOut.Stop();
            timerProcessInterval.Stop();
        }

        #endregion

        private void TLMVEW00017_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
            this.ProcessTime = 60;
            this.IntervalTime = 15;
            this.BindGridData();
            this.lblsourcebr.Text = this.Controller.GetPassingData().Br_Alias;
            if (this.Status.Equals("Drawing.Remittance")) 
                this.StartTimer();
        }


        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void butLog_Click(object sender, EventArgs e)
        {
            this.pnlLog.Visible = true;
        }

        private void chkShowOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (this.lbLog.Items.Count > 0 && chkShowOnly.Checked.Equals(true))
            {
                this.PasstingStatus = new string[this.lbLog.Items.Count];
                for (int i = 0; i < this.lbLog.Items.Count; i++)
                {
                    this.PasstingStatus[i] = this.lbLog.Items[i].ToString();
                }
                for (int i = 0; i < this.lbLog.Items.Count; i++)
                {
                    string x = this.lbLog.Items[i].ToString();
                    if (this.lbLog.Items[i].ToString().Contains(" successed."))
                    {
                        this.lbLog.Items.RemoveAt(i);
                        i = -1;    /*Not to skip the first index of Count everytime its item is removed and reloop.*/
                    }
                }
            }
            else
            {
                this.lbLog.Items.Clear();

                if (this.PasstingStatus != null)
                {
                    foreach (string item in this.PasstingStatus)
                    {
                        this.lbLog.Items.Add(item);
                    }
                }
              
            }
            this.lbLog.Refresh();
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            this.pnlLog.Visible = false;
            this.chkShowOnly.Checked = false;
        }

        private void butClearLog_Click(object sender, EventArgs e)
        {
            this.lbLog.Items.Clear();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butProcess_Click(object sender, EventArgs e)
        {
            if(this.isResume)
                this.StopTimer();

            var rdlist = from value in this.RDDto
                         where value.IsChecked == true
                         select value;
            
            if (rdlist.Count() <1)
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV90012);
            else
                this.Controller.PassingDrawingRemittanceByCheck(this.TransactionStatus);
            if (this.isResume)
                this.StartTimer();
        }

        private void gvDrawingRemittance_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex.Equals(-1))
            {
                return;
            }

            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                DataGridViewRow dataRow = (DataGridViewRow)gvDrawingRemittance.Rows[e.RowIndex];
                DataGridViewCell cell = dataRow.Cells[e.ColumnIndex];

                if (this.Status.Equals("Drawing.Remittance"))
                {
                    if (Convert.ToBoolean(dataRow.Cells[colIsSelected.Index].Value.Equals(true)))
                        dataRow.Cells[colIsSelected.Index].Value = false;
                    else
                        dataRow.Cells[colIsSelected.Index].Value = true;

                    if (cell.OwningColumn != null && cell.OwningColumn.Name.Equals("colIsSelected"))
                    {
                        this.RDDto[e.RowIndex].IsChecked = Convert.ToBoolean(dataRow.Cells[colIsSelected.Index].Value);
                    }
                }
                else if (this.Status.Equals("Encash.Remittance") )
                {
                    if (this.Controller.ApprovedData(e.RowIndex))
                    {
                        this.REDTO.Remove(REDTO[e.RowIndex]);
                        this.gvDrawingRemittance.DataSource = null;
                        this.gvDrawingRemittance.DataSource = this.REDTO;
                    }
                }
            }
        }

        private void txtConnectTimeOutSeconds_TextChanged(object sender, EventArgs e)
        {
            this.StopTimer();
            if (!String.IsNullOrEmpty(txtConnectTimeOutSeconds.Text) && Convert.ToInt32(txtConnectTimeOutSeconds.Text) > 240)
            {
                txtConnectTimeOutSeconds.Clear();
                this.ProcessTime = 240;
            }
            else if (!String.IsNullOrEmpty(txtConnectTimeOutSeconds.Text))
                this.ProcessTime = Convert.ToInt32(txtConnectTimeOutSeconds.Text);
        }

        private void txtProcessInterval_TextChanged(object sender, EventArgs e)
        {
            this.StopTimer();
            if (!String.IsNullOrEmpty(txtProcessInterval.Text) && Convert.ToInt32(txtProcessInterval.Text) > 240)
            {
                txtProcessInterval.Clear();
                this.IntervalTime = 180;
            }
            else if (!String.IsNullOrEmpty(txtProcessInterval.Text))
                this.IntervalTime = Convert.ToInt32(txtProcessInterval.Text);
        }

        private void txtConnectTimeOutSeconds_Validated(object sender, EventArgs e)
        {
            if (this.ProcessTime < 60)
                this.ProcessTime = 60;
            this.StartTimer();
        }

        private void txtProcessInterval_Validated(object sender, EventArgs e)
        {
            if (this.IntervalTime < 15)
                this.IntervalTime = 15;
            this.StartTimer();
        }

        private void timerConnectTimeOut_Tick(object sender, EventArgs e)
        {
            timerConnectTimeOut.Stop();
            timerProcessInterval.Interval = this.IntervalTime * 1000;
            timerProcessInterval.Start();
        }

        private void timerProcessInterval_Tick(object sender, EventArgs e)
         {
            if (RDDto.Count != 0)
            {
                timerProcessInterval.Stop();
                if (this.Controller.PassingDrawingRemittanceByTimer())
                {
                    this.gvDrawingRemittance.DataSource = null;
                    this.gvDrawingRemittance.DataSource = this.RDDto;
                }
                timerProcessInterval.Start();
            }
        }

        private void butPause_Click(object sender, EventArgs e)
        {
            if (butPause.Text.Equals("Pa&use"))
            {
                this.StopTimer();
                butPause.Text = "&Resume";
                this.isResume = false;
            }
            else
            {
                this.StartTimer();
                butPause.Text = "Pa&use";
                this.isResume = true;
            }

        }

        private void butRefresh_Click(object sender, EventArgs e)
        {
            if (this.Status.Equals("Drawing.Remittance"))
            {
                if (butPause.Text.Equals("Pa&use"))
                    this.StopTimer();

                this.BindGridData();

                if (butPause.Text.Equals("Pa&use"))
                    this.StartTimer();
            }
            else
                this.BindGridData();
        }

        private void gvDrawingRemittance_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (this.Status.Equals("Encash.Remittance") && e.RowIndex > -1 && e.ColumnIndex > -1)
            //{
            //    if (this.Controller.ApprovedData(e.RowIndex))
            //    {
            //        this.REDTO.Remove(REDTO[e.RowIndex]);
            //        this.gvDrawingRemittance.DataSource = null;
            //        this.gvDrawingRemittance.DataSource = this.REDTO;
            //    }
            //}
        }

        public void EncashPasingSuccessful(string Message, string iblpo,string registerNo,decimal amount)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(Message, new object[] {registerNo,iblpo,amount });
        }

        public void EncashPassingFail(string Message)
        {
            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(Message);
        }

    }
}