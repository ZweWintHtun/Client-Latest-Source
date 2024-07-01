//----------------------------------------------------------------------
// <copyright file="MNMVEW00006.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>KSW</CreatedUser>
// <CreatedDate>05/11/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Windows.CXClient.Controls;
using System.Globalization;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Pfm.Dmd;// Added by AAM (20_Sep_2018)
using Ace.Cbs.Pfm.Dmd.DTO;// Added by AAM (20_Sep_2018)

namespace Ace.Cbs.Mnm.Vew
{
    public partial class MNMVEW00006 : BaseForm , IMNMVEW00006
    {
        public MNMVEW00006()
        {
            InitializeComponent();
        }

        #region controller
        private IMNMCTL00006 controller;
        public IMNMCTL00006 Controller
        {
            get
            {
                return this.controller;
            }
            set
            {
                this.controller = value;
                controller.YearpostViewData = this;
            }
        }
        #endregion

        #region Properties

        public Nullable<DateTime> Date_time
        {
            get
            {
                return this.dtpYearlyPosting.Value;

            }
            set
            {
                if (value == null)
                {
                    this.dtpYearlyPosting.CustomFormat = " ";
                }
                else
                {
                    this.dtpYearlyPosting.CustomFormat = CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.UIDateFormat);
                    this.dtpYearlyPosting.Value = value.Value;
                }
            }
        }

        public string LabelStatus
        {
            get { return lblstatus.Text; }
            set { this.lblstatus.Text = value; }
        }



        public int ProgressBar
        {
            get { return progressBarPosting.Value; }
            set { this.progressBarPosting.Value = value; }
        }
        public bool Progressstatus
        {
            get { return progressBarPosting.Visible; }
            set { this.progressBarPosting.Visible = value; }
        }

        #endregion

        #region method

        public void Successful(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);

        }

        public void Failure(string message)
        {
            CXUIMessageUtilities.ShowMessageByCode(message);
        }

        #endregion

        #region Event
        private void MNMVEW00006_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
            #region Old Code
            //string year = DateTime.Now.ToString("dd/MMM/yyyy").Substring(7, 4);
            //string datestr = "31/03/" + year;
            //DateTime date = DateTime.ParseExact(datestr, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //dtpYearlyPosting.Text = date.ToString();
            #endregion
            IList<PFMDTO00079> lst = this.controller.Get_BLFInfo_ByActiveBudget(CurrentUserEntity.BranchCode);
            dtpYearlyPosting.Text = lst[0].BEND_DATE.ToString();


        }

        private void btnPosting_Click(object sender, EventArgs e)
        {
            if (CXUIMessageUtilities.ShowMessageByCode("MC30001") == DialogResult.Yes)
            {
                this.lblstatus.Visible = true;
                this.lblstatus.Text = string.Empty;
                this.Controller.Posting();
            }
            else
            {
                this.Focus();
                this.lblstatus.Visible = false;
                this.progressBarPosting.Visible = false;
            }
        }
        #endregion

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MNMVEW00006_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }

      
    }
}
