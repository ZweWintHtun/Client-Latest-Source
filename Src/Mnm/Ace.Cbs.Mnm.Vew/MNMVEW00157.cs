//----------------------------------------------------------------------
// <copyright file="MNMVEW00157.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser> Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2015-02-12</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.CXClient.Controls;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Cle;
using Ace.Windows.Admin.DataModel;
using Microsoft.Reporting.WinForms;
using System.IO;
using Ace.Cbs.Cx.Com.Utt;
using System.Collections.Generic;
using System.Drawing;
using System;

namespace Ace.Cbs.Mnm.Vew
{
    /// <summary>
   ///Closing -->Monthly Closing-->Drawing Remittance Report Viewer
    /// </summary>
    public partial class MNMVEW00157 : BaseDockingForm
    {
        #region "Properties"
        private string TransactionStatus { get; set; }       
        private string BranchNo { get; set; }     
        public IList<TLMDTO00017> DrawingEncashRemittanceDTOLists { get; set; }
        #endregion

        #region Constructor
        public MNMVEW00157()
        {
            InitializeComponent();
        }
        public MNMVEW00157(IList<TLMDTO00017> DEDTOLists, string screenName)
        {           
            this.TransactionStatus = screenName;
            this.Text = this.TransactionStatus;            
            this.DrawingEncashRemittanceDTOLists = DEDTOLists;           
            InitializeComponent();
        }
        #endregion

        #region Event
        private void MNMVEW00157_Load(object sender, EventArgs e)
        {
            this.Text = TransactionStatus;
            try
            {
                if (this.DrawingEncashRemittanceDTOLists.Count > 0)
                {
                    TLMDTO00017 WithdrawlListingDTO = new TLMDTO00017();
                    WithdrawlListingDTO.BankName = CurrentUserEntity.BranchDescription;

                    BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                    WithdrawlListingDTO.BranchName = Branch.Address;
                    WithdrawlListingDTO.Phone = Branch.Phone;
                    WithdrawlListingDTO.Fax = Branch.Fax;
                 
                    rpvDrawingEncashRemittance.LocalReport.DataSources.Clear();
                    ReportParameter[] para = new ReportParameter[8];
                    para[0] = new ReportParameter("BankName", WithdrawlListingDTO.BankName);
                    para[1] = new ReportParameter("BranchName", WithdrawlListingDTO.BranchName);
                    para[2] = new ReportParameter("Phone", WithdrawlListingDTO.Phone);
                    para[3] = new ReportParameter("Fax", WithdrawlListingDTO.Fax);
                    para[4] = new ReportParameter("BrCode", Branch.BranchCode);
                    para[5] = new ReportParameter("Br_Alias", Branch.Bank_Alias);
                    para[6] = new ReportParameter("Head", TransactionStatus);
                    Image img = null;
                    string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                    using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                    {
                        img = System.Drawing.Image.FromStream(stream);

                        img.Save(tempFilePath);
                    }

                    para[7] = new ReportParameter("BankLogo", "file:////" + tempFilePath);                      
                  
                    this.rpvDrawingEncashRemittance.LocalReport.EnableExternalImages = true;
                    rpvDrawingEncashRemittance.LocalReport.SetParameters(para);
                    ReportDataSource dataset = new ReportDataSource("DrawingRemittanceClosingDataSet", DrawingEncashRemittanceDTOLists);
                    rpvDrawingEncashRemittance.LocalReport.DataSources.Add(dataset);

                    dataset.Value = DrawingEncashRemittanceDTOLists;
                    rpvDrawingEncashRemittance.LocalReport.Refresh();
                    this.rpvDrawingEncashRemittance.RefreshReport();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message+ex.InnerException.Message);
            }
        }
        private void MNMVEW00157_FormClosing(object sender, FormClosingEventArgs e)
        {
            rpvDrawingEncashRemittance.LocalReport.ReleaseSandboxAppDomain();
        }
        #endregion

        
    }
}
