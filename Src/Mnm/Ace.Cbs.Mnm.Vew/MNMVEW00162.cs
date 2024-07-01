//----------------------------------------------------------------------
// <copyright file="MNMVEW00162.cs" company="ACE Data Systems">
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
    ///.listing--> Interest(payment)--> Fixed Deposit Interest--> Interst Withdrawal Listing
    /// </summary>
    public partial class MNMVEW00162 : BaseDockingForm
    {
          #region "Properties"
        private string TransactionStatus { get; set; }       
        private string BranchNo { get; set; }
        private string DateType { get; set; }
        public IList<TLMDTO00019> FixInterestWithDTOLists { get; set; }
        #endregion

        #region Constructor
         public MNMVEW00162()
        {
            InitializeComponent();
        }
         public MNMVEW00162(IList<TLMDTO00019> fixintwithDTOLists, string datetype,DateTime startDate,DateTime endDate)
        {           
            this.TransactionStatus = "Listing of Fixed Interest Withdraw By "+ datetype+" date "+"From "+startDate.ToShortDateString()+ " "+"To "+endDate.ToShortDateString();
            this.Text = this.TransactionStatus;
            this.DateType = datetype;
            this.FixInterestWithDTOLists = fixintwithDTOLists;           
            InitializeComponent();
        }
        #endregion
      

        private void MNMVEW00162_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.FixInterestWithDTOLists.Count > 0)
                {
                    TLMDTO00019 intFixWithDTO = new TLMDTO00019();
                    intFixWithDTO.BankName = CurrentUserEntity.BranchDescription;

                    BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                    intFixWithDTO.BranchName = Branch.Address;
                    intFixWithDTO.Phone = Branch.Phone;
                    intFixWithDTO.Fax = Branch.Fax;

                    rpvFixedInterestWithdrawListing.LocalReport.DataSources.Clear();
                    ReportParameter[] para = new ReportParameter[9];
                    para[0] = new ReportParameter("BankName", intFixWithDTO.BankName);
                    para[1] = new ReportParameter("BranchName", intFixWithDTO.BranchName);
                    para[2] = new ReportParameter("Phone", intFixWithDTO.Phone);
                    para[3] = new ReportParameter("Fax", intFixWithDTO.Fax);
                    para[4] = new ReportParameter("BrCode", Branch.BranchCode);
                    para[5] = new ReportParameter("Br_Alias", Branch.Bank_Alias);
                    para[6] = new ReportParameter("Header", TransactionStatus);                   
                    Image img = null;
                    string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                    using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                    {
                        img = System.Drawing.Image.FromStream(stream);

                        img.Save(tempFilePath);
                    }

                    para[7] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                    para[8] = new ReportParameter("DateType",DateType );

                    this.rpvFixedInterestWithdrawListing.LocalReport.EnableExternalImages = true;
                    rpvFixedInterestWithdrawListing.LocalReport.SetParameters(para);
                    ReportDataSource dataset = new ReportDataSource("FixedDepositInterestWithdrawDataSet", FixInterestWithDTOLists);
                    rpvFixedInterestWithdrawListing.LocalReport.DataSources.Add(dataset);

                    dataset.Value = FixInterestWithDTOLists;
                    rpvFixedInterestWithdrawListing.LocalReport.Refresh();                   
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + ex.InnerException.Message);
            }
            this.rpvFixedInterestWithdrawListing.RefreshReport();
        }

        private void MNMVEW00162_FormClosing(object sender, FormClosingEventArgs e)
        {
            rpvFixedInterestWithdrawListing.LocalReport.ReleaseSandboxAppDomain();
        }
    }
}
