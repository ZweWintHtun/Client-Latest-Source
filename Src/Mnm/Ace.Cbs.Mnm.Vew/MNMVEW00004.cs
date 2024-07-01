//----------------------------------------------------------------------
// <copyright file="MNMVEW00004.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Zin Mon Aung</CreatedUser>
// <CreatedDate>11/20/2013</CreatedDate>
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
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Windows.CXClient;
using System.Globalization;

namespace Ace.Cbs.Mnm.Vew

{
    public partial class MNMVEW00004 : BaseForm, IMNMVEW00004
    {
        public MNMVEW00004()
        {
            InitializeComponent();
        }

        #region Properties

        public DateTime dtTmp = DateTime.Now;
        public string sdate = string.Empty;
        public string d,mm,yyyy;
        public Int32 dy,dd,tdy;
        public float d3;
        public int start {get;set;}
        public DateTime edate;
        CultureInfo provider = CultureInfo.InvariantCulture;

        public int Id
        {
            get { throw new NotImplementedException(); }
        }

        public DateTime RenewalStartDate
        {
            get { 
                IFormatProvider theCultureInfo = new System.Globalization.CultureInfo("en-GB", true);
                return DateTime.ParseExact(mtxtRenewalStartDate.Text, "dd/MM/yyyy", theCultureInfo);
            }
            set { this.mtxtRenewalStartDate.Text = value.ToString("dd/MM/yyyy"); }
        }

        public DateTime RenewalEndDate
        {
            get
            {
                IFormatProvider theCultureInfo = new System.Globalization.CultureInfo("en-GB", true);
                return DateTime.ParseExact(mtxtRenewalEndDate.Text, "dd/MM/yyyy", theCultureInfo);
            }
            set { this.mtxtRenewalEndDate.Text = value.ToString("dd/MM/yyyy"); }
        }

        private PFMDTO00056 viewData;
        public PFMDTO00056 ViewData
        {
            get
            {
                if (this.viewData == null) this.viewData = new PFMDTO00056();

                //this.viewData.Type = this.Type;
                //this.viewData.SysDate = Convert.ToDateTime(this.dtTmp);

                return this.viewData;
            }
            set { this.viewData = value; }
        }

        #endregion

        #region Controller

        private IMNMCTL00004 controller;

        public IMNMCTL00004 Controller
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

        #region Events

        private void MNMVEW00004_Load(object sender, EventArgs e)
        {
            this.tsbCRUD.ButtonEnableDisabled(false, false, false, false, false, false, true);
            this.BindDate();
            btnCalculate.Focus();
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (this.checkDate()==false)
            {
                return;
            }

            if (CXUIMessageUtilities.ShowMessageByCode(CXMessage.MC30006) == DialogResult.Yes)
            {
                if (mtxtRenewalStartDate.Text == mtxtRenewalEndDate.Text)
                {
                    start = 0;
                }
                else
                {
                    start = 1;
                }
                this.Controller.Save();
            }
        }

        #endregion

        #region Method

        private void BindDate()
        {
            this.dtTmp = this.Controller.SelectSysDate();
            DateTime intdate = dtTmp.AddDays(+1);


            this.dd = Convert.ToInt32(intdate.ToString("dd"));
            this.tdy = Convert.ToInt32(DateTime.Now.ToString("dd"));
            this.d3 = tdy-dd;
            if (d3 == 0)
            {
                mtxtRenewalStartDate.Text = intdate.ToString("dd/MM/yyyy");
                mtxtRenewalEndDate.Text = intdate.ToString("dd/MM/yyyy");
            }
            else
            {
                if (d3 > 0)
                {

                    mtxtRenewalStartDate.Text = intdate.ToString("dd/MM/yyyy");
                    mtxtRenewalEndDate.Text = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");
                }
                else
                {

                    mtxtRenewalStartDate.Text = dtTmp.ToString("dd/MM/yyyy");
                    mtxtRenewalEndDate.Text = dtTmp.ToString("dd/MM/yyyy");
                }
            }
        }
        private bool checkDate()
        {
            this.dtTmp = this.Controller.SelectSysDate();
            DateTime intdate = dtTmp.AddDays(+1);
            string getDate = DateTime.Now.ToString("dd/MM/yyyy");
            string dtIntdate = dtTmp.ToString("dd/MM/yyyy");



            this.dd = Convert.ToInt32(intdate.ToString("dd"));
            this.tdy = Convert.ToInt32(DateTime.Now.ToString("dd"));
            this.d3 = tdy - dd;

             if (d3 == 0)
            {
                return true;
            }
            else
            {
                if (d3 > 0)
                {

                    return true;
                }
                else
                {
                    if (dtIntdate == getDate)
                    {
                        CXUIMessageUtilities.ShowMessageByCode("MI30035"); //already renewed
                        return false;
                    }
                    else
                    {
                        CXUIMessageUtilities.ShowMessageByCode("MI30036"); //invaild fixed deposit renew date
                        return false;
                    }

                    
                }
            }
    
        } 

        #endregion

        private void MNMVEW00004_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }

        
    }
}
  