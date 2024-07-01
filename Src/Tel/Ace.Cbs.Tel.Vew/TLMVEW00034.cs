//----------------------------------------------------------------------
// <copyright file="TLMVEW00034.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-07-17</CreatedDate>
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
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Tel.Dmd;

namespace Ace.Cbs.Tel.Vew
{
    // Report => IBL Remittance
    public partial class TLMVEW00034 : BaseDockingForm
    {
        #region Properties
        IList<TLMDTO00025> ReconsileList { get; set; }
        IList<TLMDTO00017> RDList { get; set; }
        IList<TLMDTO00001> REList { get; set; }
        IList<TLMDTO00004> IBLTLFList { get; set; }
        string scrrenName
        {
            get;
            set;
        }
        string transactionType { get; set; }
        string parentFormId { get; set; }
        DateTime date { get; set; }
        string typeStatus { get; set; }
        #endregion

        #region Constructor
        public TLMVEW00034()
        {
            InitializeComponent();
        }

        //public TLMVEW00034(string status)
        //{
        //    InitializeComponent();
        //    this.Text = status;
        //}

        public TLMVEW00034(IList<TLMDTO00025> reconsilelist,IList<TLMDTO00017> rdList, string transactionType,DateTime date,string typeStatus,string screenName)
        {
            InitializeComponent();
            this.ReconsileList = reconsilelist;
            this.RDList = rdList;
            this.transactionType = transactionType;
            this.date = date;
            this.typeStatus = typeStatus;
            this.Text = screenName;
            
        }

        public TLMVEW00034(IList<TLMDTO00025> reconsilelist, IList<TLMDTO00001> reList, string transactionType, DateTime date,string typeStatus, string screenName)
        {
            InitializeComponent();
            this.ReconsileList = reconsilelist;
            this.REList = reList;
            this.transactionType = transactionType;
            this.date = date;
            this.typeStatus = typeStatus;
            this.Text = screenName;
        }


        public TLMVEW00034(IList<TLMDTO00025> reconsilelist, IList<TLMDTO00004> ibltlfList, string transactionType, DateTime date, string typeStatus, string screenName)
        {
            InitializeComponent();
            this.ReconsileList = reconsilelist;
            this.IBLTLFList = ibltlfList;
            this.transactionType = transactionType;
            this.date = date;
            this.typeStatus = typeStatus;
            this.Text = screenName;
        }
        #endregion

        #region Methods
        private void InitializeControls()
        {
            this.tsbCRUD.ButtonEnableDisabled(false/*newButtonEnabled*/, false/*editButtonEnabled*/, false/*saveButtonEnabled*/, false/*deleteButtonEnabled*/, true/*cancelButtonEnabled*/, true/*printButtonEnabled*/, true/*exitButtonEnabled*/);
            this.gVRemittanceDrawingStatusDetail.DataSource = null;
            this.gVRemittanceDrawingStatusDetail.AutoGenerateColumns = false; 
        }

        private string GetRemittanceType()
        {
            switch (this.transactionType)
            {
                case "DWT": lblRemittanceDrawingStatus.Text = "Online Transaction Status";
                    break;

                //case "RD": lblRemittanceDrawingStatus.Text += lblRemittanceDrawingStatus.Text + "Drawing Status";
                case "RD": lblRemittanceDrawingStatus.Text = "Drawing Remittance Status";
                    break;

                //case "RE": lblRemittanceDrawingStatus.Text += lblRemittanceDrawingStatus.Text + "Encashment Status";
                case "RE": lblRemittanceDrawingStatus.Text = "Encash Remittance Status";
                    break;

            }
            return lblRemittanceDrawingStatus.Text;
        }
        #endregion

        #region Events

        private void TLMVEW00034_Move(object sender, EventArgs e)
        {
            this.CenterToParent();
        }

        private void TLMVEW00034_Load(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.GetRemittanceType();           
            this.gVRemittanceDrawingStatusDetail.DataSource=this.ReconsileList;
        }

        private void tsbCRUD_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void tsbCRUD_PrintButtonClick(object sender, EventArgs e)
        {
            if (this.typeStatus == "Remittance")
            {
                if (this.RDList!=null)
                {
                    if (this.RDList.Count > 0)
                    { CXUIScreenTransit.Transit("frmRDREReconsileReport", true, new object[] { RDList, transactionType, date }); }
                    else { Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039"); }//No data for Report.
                }
                else if (this.REList != null)
                {
                    if (this.REList.Count > 0)
                    { CXUIScreenTransit.Transit("frmRDREReconsileReport", true, new object[] { REList, transactionType, date }); }
                    else { Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039"); }
                }
                else
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");//No data for Report.
                }
            }
            else
            {
                if (this.IBLTLFList != null)
                {
                    if (this.IBLTLFList.Count > 0)
                    { CXUIScreenTransit.Transit("frmTransactionReconsileReport", true, new object[] { IBLTLFList, transactionType, date }); }
                    else { Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039"); }
                }
                else
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report
                }
            }
        }
        #endregion

       
      
    }
}
