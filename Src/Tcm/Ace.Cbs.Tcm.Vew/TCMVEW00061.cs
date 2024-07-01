//----------------------------------------------------------------------
// <copyright file="TLMVEW00061.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-12-15</CreatedDate>
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
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Tel.Dmd;
using System.IO;
using Ace.Windows.Core.Utt;
using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.OnDemandReportRendering;
using Ace.Windows.Admin.DataModel;


namespace Ace.Cbs.Tcm.Vew
{
    /// <summary>
    /// PO Printing Report Viewer Form
    /// </summary>
	public partial class TCMVEW00061: BaseDockingForm,ITCMVEW00061
    {
        #region"Properties"
        IList<TLMDTO00001> REDTOList { get; set; }
        string screenName { get; set; }
        #endregion

        #region "Constructors"
        public TCMVEW00061()
		{
			InitializeComponent();
		}
        public TCMVEW00061(IList<TLMDTO00001> REDTOs,string screenName)
        {
            InitializeComponent();
            REDTOList = REDTOs;
            this.screenName = screenName;
            this.Text = this.screenName;
        }
        #endregion

        #region "Controller"
        private ITCMCTL00061 poprintingreportController;
        public ITCMCTL00061 POPrintingReportController
        {
            get
            {
                return this.poprintingreportController;
            }
            set
            {

                this.poprintingreportController = value;
                this.poprintingreportController.POPrintingReportView = this;

            }
        }
        #endregion

        #region "Events"
        private void TCMVEW00061_Load(object sender, EventArgs e)
        {           
            IList<TLMDTO00001> POPrintingList = this.poprintingreportController.SelectPOReportLists(REDTOList);
            if (POPrintingList.Count > 0)
            {
                for (int i = 0; i < POPrintingList.Count; i++)
                {
                    POPrintingList[i].Description = CXCLE00012.Instance.CalculateAmountToWords(Convert.ToDouble(POPrintingList[i].Amount), POPrintingList[i].Currency);                   
                    //POPrintingList[i].Ebank = CXCLE00002.Instance.GetClientData<string>("CityCode.SelectByCode",new object[] {REDTOList[i].Ebank,true});
                    //POPrintingList[i].Ebank = CXCLE00002.Instance.GetScalarObject<string>("BranchCode.Client.SelectByCode", REDTOList[i].Ebank, true);

                }

                TLMDTO00001 reDTO = new TLMDTO00001();
                reDTO.BranchName = CurrentUserEntity.BranchDescription;
             


                rpvPOPrinting.LocalReport.DataSources.Clear();
                ReportParameter[] para = new ReportParameter[1];

                para[0] = new ReportParameter("BranchName", reDTO.BranchName);
                //para[1] = new ReportParameter("BrCode", Branch.BranchCode);
                //para[2] = new ReportParameter("Br_Alias", Branch.Bank_Alias);


                this.rpvPOPrinting.LocalReport.SetParameters(para);

                ReportDataSource dataset = new ReportDataSource("POPrintingDataSet", POPrintingList);
                rpvPOPrinting.LocalReport.DataSources.Add(dataset);

                dataset.Value = POPrintingList;
                this.rpvPOPrinting.LocalReport.Refresh();
                this.rpvPOPrinting.RefreshReport();
            }
            else
            {

            }

        }

        
        #endregion
    }
}
