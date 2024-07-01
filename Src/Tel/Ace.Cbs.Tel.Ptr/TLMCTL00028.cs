using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Tel.Ctr.Ptr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.CXClient;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Tel.Dmd;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Tel.Ptr
{
    public class TLMCTL00028:AbstractPresenter,ITLMCTL00028
    {

        private ITLMVEW00028 view;
        public ITLMVEW00028 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }
        private void WireTo(ITLMVEW00028 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetViewData());
            }
        }

        public PFMDTO00042 GetViewData()
        {
            PFMDTO00042 viewData = new PFMDTO00042();
        
            viewData.TransactionCode=this.view.TranType;
            viewData.BranchName=this.view.BranchCode;
            viewData.StartDate=this.view.StartDate;
            viewData.EndDate=this.view.EndDate;
            viewData.SourceCur = this.view.BranchCode;
            //viewData.IsAllBranches=this.view.AllBranch;
            viewData.IsWithReversal=this.view.isReversal;
            viewData.IsActive=this.view.isActive;
            //viewData.SourceBranch = CurrentUserEntity.BranchCode;

            return viewData;
        }

        public void Print(string forReversalCase)
        {
            if (this.CheckDate())
            {
                PFMDTO00042 viewDTO = GetViewData();
                
                viewDTO.TransactionCode = this.view.GetTranType();

                if (this.view.FormName == "Income Listing")
                {
                    viewDTO.TransactionCode = "Income Listing";
                }
                else if (this.view.FormName == "Online Transaction Listing")
                {
                    viewDTO.TransactionCode = "Online Transaction Listing";
                }

          

                #region Income
                if (this.ValidateForm(viewDTO))
                {

                if (this.view.FormName == "Income Listing")
                {

                    if (!viewDTO.IsActive)
                    {
                        if (CXClientWrapper.Instance.Invoke<ITLMSVE00048, IList<TLMDTO00004>>(x => x.HomeIncomeListingByAllBranch(viewDTO.StartDate, viewDTO.EndDate,CurrentUserEntity.BranchCode,this.view.BranchCode)).Count > 0)
                        {
                            CXUIScreenTransit.Transit("frmTLMVEW00048", true, new object[] { "frmTLMVEW00028IncomeListing", viewDTO.StartDate, viewDTO.EndDate, viewDTO.IsAllBranches,this.view.BranchCode, viewDTO.IsActive });
                        }
                        else
                        {
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");//No data for reports
                        }

                    }

                    else
                    {
                        if (CXClientWrapper.Instance.Invoke<ITLMSVE00048, IList<TLMDTO00004>>(x => x.ActiveIncomeListingByAllBranch(viewDTO.StartDate, viewDTO.EndDate,CurrentUserEntity.BranchCode, this.view.BranchCode)).Count > 0)
                        {
                            CXUIScreenTransit.Transit("frmTLMVEW00048", true, new object[] { "frmTLMVEW00028IncomeListing", viewDTO.StartDate, viewDTO.EndDate, viewDTO.IsAllBranches, this.view.BranchCode, viewDTO.IsActive });
                        }
                        else
                        {
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                        }

                    }


                }
                #endregion

                #region Online
                else if (this.view.FormName == "Online Transaction Listing")
                {
                    if (!viewDTO.IsActive)
                    {


                        IList<TLMDTO00004> List = CXClientWrapper.Instance.Invoke<ITLMSVE00047, IList<TLMDTO00004>>(x => x.HomeOnlineTransactionListingByAllBranch(viewDTO.StartDate, viewDTO.EndDate, viewDTO.SourceCur, CurrentUserEntity.BranchCode));
                        if (List.Count > 0)
                        {
                            CXUIScreenTransit.Transit("frmTLMVEW00047", true, new object[] { List,"frmTLMVEW00028OnlineTransactionListing", viewDTO.StartDate, viewDTO.EndDate, viewDTO.SourceCur, forReversalCase, viewDTO.IsAllBranches, viewDTO.BranchName, viewDTO.IsActive, viewDTO.IsWithReversal });
                        }
                        else
                        {
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                        }
                    }
                    else
                    {
                        IList<TLMDTO00004> List = CXClientWrapper.Instance.Invoke<ITLMSVE00047, IList<TLMDTO00004>>(x => x.ActiveOnlineTransactionListingByAllBranch(viewDTO.StartDate, viewDTO.EndDate, viewDTO.SourceCur, CurrentUserEntity.BranchCode, forReversalCase));
                        if (List.Count > 0)
                        {
                            CXUIScreenTransit.Transit("frmTLMVEW00047", true, new object[] { List,"frmTLMVEW00028OnlineTransactionListing", viewDTO.StartDate, viewDTO.EndDate,viewDTO.SourceCur,forReversalCase, viewDTO.IsAllBranches, viewDTO.BranchName, viewDTO.IsActive, viewDTO.IsWithReversal });
                        }
                        else
                        {
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                        }
                    }
                }
                #endregion

                #region Transaction By Branch
                else
                {
                  
                   
                        if (!viewDTO.IsActive)
                        {
                          IList<TLMDTO00004> ibl = CXClientWrapper.Instance.Invoke<ITLMSVE00046, IList<TLMDTO00004>>(x => x.HomeTransactionListinByBranch(viewDTO.StartDate, viewDTO.EndDate, viewDTO.TransactionCode, viewDTO.BranchName, CurrentUserEntity.BranchCode, viewDTO.IsWithReversal));
                            if(ibl.Count>0)
                            {
                                CXUIScreenTransit.Transit("frmTLMVEW00046", true, new object[] { "frmTLMVEW00028TransactionListingByBranch", viewDTO.StartDate, viewDTO.EndDate, viewDTO.BranchName, viewDTO.IsActive, viewDTO.IsWithReversal, viewDTO.TransactionCode });

                            }
                            else
                            {
                                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                            }
                        }
                        else
                        {
                            if (CXClientWrapper.Instance.Invoke<ITLMSVE00046, IList<TLMDTO00004>>(x => x.ActiveTransactionListinByBranch(viewDTO.StartDate, viewDTO.EndDate, viewDTO.TransactionCode, viewDTO.BranchName, CurrentUserEntity.BranchCode, viewDTO.IsWithReversal)).Count > 0)
                            {
                                CXUIScreenTransit.Transit("frmTLMVEW00046", true, new object[] { "frmTLMVEW00028TransactionListingByBranch", viewDTO.StartDate, viewDTO.EndDate, viewDTO.BranchName, viewDTO.IsActive, viewDTO.IsWithReversal, viewDTO.TransactionCode });

                            }
                            else
                            {
                                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                            }
                        }

                    }
                #endregion
                }
            }
        }


        public bool CheckDate()
        {
            try
            {
                bool date = CXCOM00006.Instance.IsValidStartDateEndDate(this.view.StartDate, this.view.EndDate);
                if (date == false)
                {
                    if (CXClientWrapper.Instance.ServiceResult.MessageCode == CXMessage.MV00159)
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00159, new object[] { this.view.StartDate });

                    }
                    else
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }


                    return false;
                }

                return date;
            }

            catch(Exception ex)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(ex.Message);
                return false;
            }

        }
    }
}

