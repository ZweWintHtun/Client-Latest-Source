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
using System.IO;
using Microsoft.Reporting.WinForms;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Tel.Vew
{
    public partial class TLMVEW00047 : BaseForm, ITLMVEW00047
    {
        public TLMVEW00047()
        {
            InitializeComponent();
        }

        #region Controller
        private ITLMCTL00047 controller;
        public ITLMCTL00047 Controller
        {
            get { return this.controller; }
            set
            {
                this.controller = value;
                this.controller.View = this;
            }
        }

        public TLMVEW00047(IList<TLMDTO00004> _list,string parentFormId, DateTime startDate, DateTime endDate, bool allBranch, string branchCode, bool isActive, bool isReversal)
        {
            InitializeComponent();
            this.ParentFormId = parentFormId;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.AllBranch = allBranch;
            this.BranchCode = branchCode;
            this.IsActive = isActive;
            this.IsReversal = isReversal;
            this.List = _list;

        }

        public TLMVEW00047(IList<TLMDTO00004> _list, string parentFormId, DateTime startDate, DateTime endDate, string branchCode, string forReversalCase, bool allBranch, string branch, bool isActive, bool isReversal)
        {
            InitializeComponent();
            this.ParentFormId = parentFormId;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.ForReversalCase = forReversalCase;
            this.AllBranch = allBranch;
            this.Branch  = branch;
            this.IsActive = isActive;
            this.IsReversal = isReversal;
            this.List = _list;
           
        }
         private string parentFormId = string.Empty;
        public string ParentFormId
        {
            get { return this.parentFormId; }
            set { this.parentFormId = value; }
        }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ForReversalCase { get; set; }
        public bool AllBranch { get; set; }
        public string Branch { get; set; }
        public string BranchCode { get; set; }
        public bool IsActive { get; set; }
        public bool IsReversal { get; set; }
        public IList<TLMDTO00004> List { get; set; }
        public string SourceBr
        {
            get { return CurrentUserEntity.BranchCode; }
            set { this.SourceBr = CurrentUserEntity.BranchCode; }
        }
            

        #endregion

          private void TLMVEW00047_Load(object sender, EventArgs e)
          {

              try
              {
                 
                                 
                  TLMDTO00004 ibltlfDTO = new TLMDTO00004();
                  ibltlfDTO.StartDate = this.StartDate;
                  ibltlfDTO.EndDate = this.EndDate;
                  string forReversal = this.ForReversalCase;
                  //IList<TLMDTO00004> list = new List<TLMDTO00004>();

                  #region Active
                  if (this.IsActive == true)
                  {
                      //list = this.controller.ActiveOnlineTransactionListingByAllBranch(forReversal);
                      
                      if (List.Count > 0)
                      {
                          foreach (TLMDTO00004 item in List)
                          {
                              if (!string.IsNullOrEmpty(item.RelatedAccount))
                              {
                                  item.ActiveAccount = item.RelatedAccount;
                              }
                              else if (item.IncomeType.Value == 1)
                              {
                                  item.ActiveAccount = "Cash";
                              }
                              else
                              {
                                  item.ActiveAccount = "Transfer";
                              }

                              if (string.IsNullOrEmpty(this.BranchCode))
                              {
                                  Ace.Windows.Admin.DataModel.BranchDTO branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { item.ToBranch });
                                  item.SourceBranchCode = branch.BranchDescription;
                              }
                              else
                              {
                                  Ace.Windows.Admin.DataModel.BranchDTO branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { this.BranchCode });
                                  item.SourceBranchCode = branch.BranchDescription;
                              }

                              item.BranchDescription = CurrentUserEntity.BranchDescription;

                          }

                          this.ActiveDebitCreditCashAndTransfer(List);

                      }
                  }

                  #endregion

                  #region Home
                  else
                  {

                      //list = this.controller.HomeOnlineTransactionListingByAllBranch();
                      if (List.Count > 0)
                      {
                          foreach (TLMDTO00004 item in List)
                          {
                              if (item.RelatedAccount != null)
                              {
                                  item.ActiveAccount = item.RelatedAccount;
                              }
                              else if (item.IncomeType.Value == 1)
                              {
                                  item.ActiveAccount = "Cash";
                              }
                              else
                              {
                                  item.ActiveAccount = "Transfer";
                              }

                              if (string.IsNullOrEmpty(this.BranchCode))
                              {
                                  Ace.Windows.Admin.DataModel.BranchDTO branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { item.FromBranch });
                                  item.BranchDescription = branch.BranchDescription;
                              }
                              else
                              {
                                  Ace.Windows.Admin.DataModel.BranchDTO branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { this.BranchCode });
                                  item.BranchDescription = branch.BranchDescription;
                              }
                              Ace.Windows.Admin.DataModel.BranchDTO sourcebranch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { item.SourceBranchCode });
                              item.SourceBranchCode = sourcebranch.BranchDescription;

                          }
                      }

                      this.HomeDebitCreditCashAndTransfer(List);

                      }

                  if (!AllBranch)
                  {
                      ibltlfDTO.ReportTitle = "Online Transaction Initiated by " + CurrentUserEntity.BranchDescription + " " + "from " + StartDate.ToString("dd/MM/yyyy") + " " + "to " + EndDate.ToString("dd/MM/yyyy");
                  }
                  else
                  {
                      ibltlfDTO.ReportTitle = "Online Transaction Initiated by ALL Branches from " + StartDate.ToString("dd/MM/yyyy") + " " + "to " + EndDate.ToString("dd/MM/yyyy");
                  }

                  #endregion
                        
                      
                      ibltlfDTO.BankName = CurrentUserEntity.BranchDescription;
                      Ace.Windows.Admin.DataModel.BranchDTO Branch = CXCLE00002.Instance.GetScalarObject<Ace.Windows.Admin.DataModel.BranchDTO>("Branch.Client.isOtherBank.Select", new object[] { CurrentUserEntity.BranchCode });
                      ibltlfDTO.BranchName = Branch.Address;
                      //ibltlfDTO.SourceBranchCode = Branch.BranchCode;

                      rpvOnlineTransaction.LocalReport.DataSources.Clear();
                      ReportParameter[] para = new ReportParameter[10];
                      para[0] = new ReportParameter("BankName", ibltlfDTO.BankName);
                      para[1] = new ReportParameter("BranchName", ibltlfDTO.BranchName);
                      para[2] = new ReportParameter("Phone", Branch.Phone);
                      para[3] = new ReportParameter("Fax", Branch.Fax);

                      para[8] = new ReportParameter("BrCode", Branch.BranchCode);
                      para[9] = new ReportParameter("Br_Alias", Branch.BranchAlias);

  

                      Image img = null;
                      string tempFilePath = Application.StartupPath + "\\banklogo.jpg";
                      using (MemoryStream stream = new MemoryStream(CXCOM00007.Instance.GetBinaryValueByKeyName(CXCOM00009.BankLogo)))
                      {
                          img = System.Drawing.Image.FromStream(stream);

                          img.Save(tempFilePath);
                      }

                      para[4] = new ReportParameter("BankLogo", "file:////" + tempFilePath);
                      para[5] = new ReportParameter("ReportTitle", ibltlfDTO.ReportTitle);
                      para[6] = new ReportParameter("TotalRecords", List.Count.ToString());
                      para[7] = new ReportParameter("HomeBranch", CurrentUserEntity.BranchDescription);

                      this.rpvOnlineTransaction.LocalReport.EnableExternalImages = true;
                      rpvOnlineTransaction.LocalReport.SetParameters(para);
                      ReportDataSource dataset = new ReportDataSource("IBLHomeIncomeReportDataSet", List);
                      rpvOnlineTransaction.LocalReport.DataSources.Add(dataset);

                      dataset.Value = List;
                      this.rpvOnlineTransaction.RefreshReport();

                
                  }
              catch (Exception ex)
              { }
          }

          public void HomeDebitCreditCashAndTransfer(IList<TLMDTO00004> list)
          {
              foreach (TLMDTO00004 item in list)
              {
                  #region Home Branch
                  #region Debit Cash
                  if (((item.TranType.Substring(1,1) == "D" && item.TranType.Substring(0, 1) == "C")) || ((item.TranType.Substring(1,1) == "D" && item.TranType.Substring(0,1) == "R")))
                  {
                      item.HomeDebitCashAmount = item.Amount;

                  }

                  else
                  {
                      item.HomeDebitCashAmount = 0;
                  }

                  #endregion

                  #region Debit Transfer              

                  if (item.TranType.Substring(1,1) == "D" && item.TranType.Substring(0,1) == "T")
                  {
                      item.HomeDebitTransferAmount = item.Amount;
                  }
                  else
                  {
                      item.HomeDebitTransferAmount = 0;
 
                  }
                  #endregion

                  #region Credit Cash
                  if (((item.TranType.Substring(1,1) == "C" && item.TranType.Substring(0,1) == "C")) || ((item.TranType.Substring(1,1) == "C" && item.TranType.Substring(0,1) == "R")))
                  {
                      item.HomeCreditCashAmount = item.Amount;

                  }

                  else
                  {
                      item.HomeCreditCashAmount = 0;
                  }
                  #endregion

                  #region Credit Transfer

                  if (item.TranType.Substring(1,1) == "C" && item.TranType.Substring(0,1) == "T")
                  {
                      item.HomeCreditTransferAmount = item.Amount;
                  }
                  else
                  {
                      item.HomeCreditTransferAmount = 0;

                  }
                  #endregion

                  #endregion

                  #region Active Branch
                  #region Debit Cash 
                  //if (item.InOut) //Not Need to test Inout Case
                  //{
                      if (((item.TranType.Substring(1,1) == "C" && item.TranType.Substring(0,1) == "C")) || ((item.TranType.Substring(1,1) == "C" && item.TranType.Substring(0,1) == "R")))
                      {
                          item.ActiveDebitCashAmount = item.Amount;

                      }

                      else
                      {
                          item.ActiveDebitCashAmount = 0;
                      }
                  //}

                  //else
                  //{
                  //    item.ActiveDebitCashAmount = 0; 
                  //}


                  #endregion

                  #region Debit Transfer

                 //if (item.InOut) //Not Need to test Inout Case
                  //{
                      if (item.TranType.Substring(1,1) == "C" && item.TranType.Substring(0,1) == "T")
                      {
                          item.ActiveDebitTransferAmount = item.Amount;
                      }
                      else
                      {
                          item.ActiveDebitTransferAmount = 0;

                      }
                  //}
                  //else
                  //{
                  //    item.ActiveDebitTransferAmount = 0;

                  //}
                  #endregion

                  #region Credit Cash
                  if (((item.TranType.Substring(1,1) == "D" && item.TranType.Substring(0,1) == "C")) || ((item.TranType.Substring(1,1) == "C" && item.TranType.Substring(0,1) == "R")))
                  {
                      //item.HomeCreditCashAmount = item.Amount;
                      item.ActiveCreditCashAmount = item.Amount;

                  }

                  else
                  {
                      item.ActiveCreditCashAmount = 0;
                      //item.HomeCreditCashAmount = 0;
                  }
                  #endregion

                  #region Credit Transfer

                  if (item.TranType.Substring(1,1) == "C" && item.TranType.Substring(0,1) == "T")
                  {
                      item.HomeCreditTransferAmount = item.Amount;
                      //item.HomeCreditTransferAmount = item.Amount;
                  }
                  else
                  {
                      item.HomeCreditTransferAmount = 0;

                  }
                  #endregion

                  #endregion


              }




              
 
          }

          public void ActiveDebitCreditCashAndTransfer(IList<TLMDTO00004> list)
          {
              foreach (TLMDTO00004 item in list)
              {
                  #region Home Branch
                  #region Debit Cash
                  if (((item.TranType.Substring(1, 1) == "D" && item.TranType.Substring(0, 1) == "C")) || ((item.TranType.Substring(1, 1) == "C" && item.TranType.Substring(0, 1) == "R")))
                  {
                      item.HomeDebitCashAmount = item.Amount;

                  }

                  else
                  {
                      item.HomeDebitCashAmount = 0;
                  }

                  #endregion

                  #region Debit Transfer

                  if (item.TranType.Substring(1, 1) == "D" && item.TranType.Substring(0, 1) == "T")
                  {
                      item.HomeDebitTransferAmount = item.Amount;
                  }
                  else
                  {
                      item.HomeDebitTransferAmount = 0;

                  }
                  #endregion

                  #region Credit Cash
                  if (((item.TranType.Substring(1, 1) == "C" && item.TranType.Substring(0, 1) == "C")) || ((item.TranType.Substring(1, 1) == "D" && item.TranType.Substring(0, 1) == "R")))
                  {
                      item.HomeCreditCashAmount = item.Amount;

                  }

                  else
                  {
                      item.HomeCreditCashAmount = 0;
                  }
                  #endregion

                  #region Credit Transfer

                  if (item.TranType.Substring(1, 1) == "C" && item.TranType.Substring(0, 1) == "T")
                  {
                      item.HomeCreditTransferAmount = item.Amount;
                  }
                  else
                  {
                      item.HomeCreditTransferAmount = 0;

                  }
                  #endregion

                  #endregion

                  #region Active Branch
                  #region Debit Cash
                  //if (item.InOut) //Not Need to test Inout Case
                  //{
                     if (((item.TranType.Substring(1, 1) == "C" && item.TranType.Substring(0, 1) == "C")) || ((item.TranType.Substring(1, 1) == "D " && item.TranType.Substring(0, 1) == "R")))
                      {
                          item.ActiveDebitCashAmount = item.Amount;

                      }

                      else
                      {
                          item.ActiveDebitCashAmount = 0;
                      }
                  //}

                  //else
                  //{
                  //    item.ActiveDebitCashAmount = 0;
                  //}


                  #endregion

                  #region Debit Transfer

                  //if (item.InOut) //Not Need to test Inout Case
                  //{
                      if (item.TranType.Substring(1, 1) == "C" && item.TranType.Substring(0, 1) == "T")
                      {
                          item.ActiveDebitTransferAmount = item.Amount;
                      }
                      else
                      {
                          item.ActiveDebitTransferAmount = 0;

                      }
                  //}
                  //else
                  //{
                  //    item.ActiveDebitTransferAmount = 0;

                  //}
                  #endregion

                  #region Credit Cash
                  //if (((item.TranType.Substring(1, 1) == "D" && item.TranType.Substring(0, 1) == "C")) || ((item.TranType.Substring(1, 1) == "C" && item.TranType.Substring(0, 1) == "R")))
                      if (((item.TranType.Substring(1, 1) == "C" && item.TranType.Substring(0, 1) == "C")) || ((item.TranType.Substring(1, 1) == "C" && item.TranType.Substring(0, 1) == "R")))
                  {
                      item.HomeCreditCashAmount = item.Amount;
                      //item.ActiveCreditCashAmount = item.Amount;

                  }

                    else if (((item.TranType.Substring(1, 1) == "D" && item.TranType.Substring(0, 1) == "C")))
                    {
                        //item.HomeCreditCashAmount = item.Amount;
                        item.ActiveCreditCashAmount = item.Amount;

                    }
                  else
                  {
                      item.HomeCreditCashAmount = 0;
                      
                  }
                  #endregion

                  #region Credit Transfer

                if (item.TranType.Substring(1, 1) == "D" && item.TranType.Substring(0, 1) == "T")
                {
                    item.ActiveCreditTransferAmount = item.Amount;

                }
                  else
                  {
                      item.ActiveCreditTransferAmount = 0;

                  }
                  #endregion

                  #endregion


              }






          }

   
    }
}
