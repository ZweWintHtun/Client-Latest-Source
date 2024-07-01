using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Tel.Ctr.Sve;
using Ace.Cbs.Tel.Ctr.Ptr;
using System.Linq;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.Admin.DataModel;


namespace Ace.Cbs.Tel.Ptr
{
    public class TLMCTL00036 : AbstractPresenter, ITLMCTL00036
    {
        private ITLMVEW00036 view;
        public ITLMVEW00036 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(ITLMVEW00036 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetDayBookEntity());
            }
        }

        private TLMDTO00058 GetDayBookEntity()
        {
            TLMDTO00058 dayBookDTO = new TLMDTO00058();
            dayBookDTO.SourceCur = this.view.CurrencyCode;
            dayBookDTO.BranchCode = this.view.BranchCode;
            return dayBookDTO;
        }

        public void GetCurrentBranch()
        {
            this.view.BranchCode = CurrentUserEntity.BranchCode;            
        }

        public bool Validate()
        {
            return this.ValidateForm(this.GetDayBookEntity());
        }

        public void ClearCustomErrorMessage()
        {
            this.ClearAllCustomErrorMessage();
        }

        public void CurrentDayBook()
        {
             
            if (this.Validate())
            {      
              string workstation = CurrentUserEntity.WorkStationId.ToString();

                #region Home Cur

                if(!this.view.IsSourceCurrency)
                {   
                    #region Reversal

                 if (this.view.IsReversal)
                 {
                    IList<TLMDTO00058> currentreversal = CXClientWrapper.Instance.Invoke<ITLMSVE00053, IList<TLMDTO00058>>(x => x.SelectCurrentHomeReversalDayBook(this.view.RequireDate, CurrentUserEntity.CurrentUserID,this.view.AccountSign, this.view.CurrencyCode, this.view.BranchCode, workstation,this.view.IsSettlementDate,this.view.SortByTime));

                    if (currentreversal.Count > 0)
                    {
                        CXUIScreenTransit.Transit("frmTLMVEW00053", true, new object[] {this.view.RequireDate, this.view.IsTransactionDate, 
                            this.view.BranchCode, this.view.CurrencyCode, this.view.IsReversal, this.view.IsSourceCurrency, this.view.SortByTime,this.view.AccountSign,this.view.IsSettlementDate });
                    }

                    else
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                        return;
                    }

                 }

                #endregion 

                #region Without Reversal
                 if (!this.view.IsReversal)
                 {
                     IList<TLMDTO00058> current = CXClientWrapper.Instance.Invoke<ITLMSVE00053, IList<TLMDTO00058>>(x => x.SelectCurrentHomeDayBook(this.view.RequireDate, CurrentUserEntity.CurrentUserID, this.view.AccountSign, this.view.CurrencyCode, this.view.BranchCode, workstation, this.view.IsSettlementDate, this.view.SortByTime));

                     if (current.Count > 0)
                     {
                         CXUIScreenTransit.Transit("frmTLMVEW00053", true, new object[] {this.view.RequireDate, this.view.IsTransactionDate, 
                            this.view.BranchCode, this.view.CurrencyCode, this.view.IsReversal, this.view.IsSourceCurrency, this.view.SortByTime,this.view.AccountSign,this.view.IsSettlementDate });
                     }

                     else
                     {
                         Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                         return;
                     }

                 }
                #endregion

                }
                #endregion

                #region Source Cur

                if (this.view.IsSourceCurrency)
                {
                    #region Reversal

                    if (this.view.IsReversal)
                    {
                        IList<TLMDTO00058> currentreversal = CXClientWrapper.Instance.Invoke<ITLMSVE00053, IList<TLMDTO00058>>(x => x.SelectCurrentReversalDayBook(this.view.RequireDate, CurrentUserEntity.CurrentUserID, this.view.AccountSign, this.view.CurrencyCode, this.view.BranchCode, workstation, this.view.IsSettlementDate, this.view.SortByTime));

                        if (currentreversal.Count > 0)
                        {
                            CXUIScreenTransit.Transit("frmTLMVEW00053", true, new object[] {this.view.RequireDate, this.view.IsTransactionDate, 
                            this.view.BranchCode, this.view.CurrencyCode, this.view.IsReversal, this.view.IsSourceCurrency, this.view.SortByTime,this.view.AccountSign,this.view.IsSettlementDate });
                        }

                        else
                        {
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                            return;
                        }

                    }

                    #endregion

                    #region Without Reversal
                    if (!this.view.IsReversal)
                    {
                        IList<TLMDTO00058> currentreversal = CXClientWrapper.Instance.Invoke<ITLMSVE00053, IList<TLMDTO00058>>(x => x.SelectCurrentDayBook(this.view.RequireDate, CurrentUserEntity.CurrentUserID, this.view.AccountSign, this.view.CurrencyCode, this.view.BranchCode, workstation, this.view.IsSettlementDate, this.view.SortByTime));

                        if (currentreversal.Count > 0)
                        {
                            CXUIScreenTransit.Transit("frmTLMVEW00053", true, new object[] {this.view.RequireDate, this.view.IsTransactionDate, 
                            this.view.BranchCode, this.view.CurrencyCode, this.view.IsReversal, this.view.IsSourceCurrency, this.view.SortByTime,this.view.AccountSign,this.view.IsSettlementDate });
                        }

                        else
                        {
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                            return;
                        }

                    }
                    #endregion

                }

                

                #endregion

            }
        }    

        public void SavingDayBook()
        {
            if (this.Validate())
            {

              //  Ace.Windows.Admin.DataModel.ChargeOfAccountDTO coaDTOforcurrent = CXCLE00001.Instance.SelectACode(CXCOM00009.SavControl);
                string workstation = CurrentUserEntity.WorkStationId.ToString();             
               
                    #region Reversal

                    if (this.view.IsReversal)
                    {
                        IList<TLMDTO00058> savingreversal = CXClientWrapper.Instance.Invoke<ITLMSVE00054, IList<TLMDTO00058>>(x => x.SelectSavingReversalDayBook(this.view.RequireDate, CurrentUserEntity.CurrentUserID, this.view.AccountSign,
                            this.view.CurrencyCode, this.view.BranchCode, workstation, this.view.IsSettlementDate));

                        if (savingreversal.Count > 0)
                        {
                            CXUIScreenTransit.Transit("frmTLMVEW00054", true, new object[] {this.view.RequireDate, this.view.IsTransactionDate, 
                            this.view.BranchCode , this.view.CurrencyCode, this.view.IsReversal, this.view.IsSourceCurrency, this.view.SortByTime,this.view.AccountSign,this.view.IsSaving,this.view.IsSettlementDate });
                        }

                        else
                        {
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                            return;
                        }

                    }

                    #endregion

                    #region Without Reversal
                    if (!this.view.IsReversal)
                    {
                        IList<TLMDTO00058> saving = CXClientWrapper.Instance.Invoke<ITLMSVE00054, IList<TLMDTO00058>>(x => x.SelectSavingDayBook(this.view.RequireDate, CurrentUserEntity.CurrentUserID, this.view.AccountSign, this.view.CurrencyCode, this.view.BranchCode, workstation, this.view.IsSettlementDate));

                        if (saving.Count > 0)
                        {
                            CXUIScreenTransit.Transit("frmTLMVEW00054", true, new object[] {this.view.RequireDate, this.view.IsTransactionDate, 
                            this.view.BranchCode, this.view.CurrencyCode, this.view.IsReversal, this.view.IsSourceCurrency, this.view.SortByTime,this.view.AccountSign,this.view.IsSaving,this.view.IsSettlementDate });
                        }

                        else
                        {
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                            return;
                        }

                    }
                    #endregion                     

            }
        }

        public void FixedDayBook()
        {
            if (this.Validate())
            {

               // Ace.Windows.Admin.DataModel.ChargeOfAccountDTO coaDTOforcurrent = CXCLE00001.Instance.SelectACode(CXCOM00009.FixControl);
                string workstation = CurrentUserEntity.WorkStationId.ToString();

                #region Reversal

                if (this.view.IsReversal)
                {
                    IList<TLMDTO00058> fixreversal = CXClientWrapper.Instance.Invoke<ITLMSVE00054, IList<TLMDTO00058>>(x => x.SelectFixedReversalDayBook(this.view.RequireDate, CurrentUserEntity.CurrentUserID, this.view.AccountSign, this.view.CurrencyCode, this.view.BranchCode, workstation, this.view.IsSettlementDate));

                    if (fixreversal.Count > 0)
                    {
                        CXUIScreenTransit.Transit("frmTLMVEW00054", true, new object[] {this.view.RequireDate, this.view.IsTransactionDate, 
                            this.view.BranchCode, this.view.CurrencyCode, this.view.IsReversal, this.view.IsSourceCurrency, this.view.SortByTime,this.view.AccountSign,this.view.IsSaving,this.view.IsSettlementDate });
                    }

                    else
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                        return;
                    }

                }

                #endregion

                #region Without Reversal
                if (!this.view.IsReversal)
                {
                    IList<TLMDTO00058> fix = CXClientWrapper.Instance.Invoke<ITLMSVE00054, IList<TLMDTO00058>>(x => x.SelectFixedDayBook(this.view.RequireDate, CurrentUserEntity.CurrentUserID, this.view.AccountSign, this.view.CurrencyCode, this.view.BranchCode, workstation, this.view.IsSettlementDate));

                    if (fix.Count > 0)
                    {
                        CXUIScreenTransit.Transit("frmTLMVEW00054", true, new object[] {this.view.RequireDate, this.view.IsTransactionDate, 
                            this.view.BranchCode, this.view.CurrencyCode, this.view.IsReversal, this.view.IsSourceCurrency, this.view.SortByTime,this.view.AccountSign,this.view.IsSaving,this.view.IsSettlementDate});
                    }

                    else
                    {
                        Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                        return;
                    }

                }
                #endregion

            }
        }

        public void DomesticDayBook()
        {
            if (this.Validate())
            {

               // Ace.Windows.Admin.DataModel.ChargeOfAccountDTO coaDTOforcurrent = CXCLE00001.Instance.SelectACode(CXCOM00009.CurControl);
                string workstation = CurrentUserEntity.WorkStationId.ToString();

                #region Home Cur
                if (!this.view.IsSourceCurrency)
                {
                    #region Reversal

                    if (this.view.IsReversal)
                    {
                        IList<TLMDTO00058> domestichomereversal = CXClientWrapper.Instance.Invoke<ITLMSVE00055, IList<TLMDTO00058>>(x => x.SelectDomesticHomeReversalDayBook(this.view.RequireDate, CurrentUserEntity.CurrentUserID, this.view.CurrencyCode, this.view.BranchCode, workstation, this.view.IsSettlementDate, this.view.SortByTime));

                        if (domestichomereversal.Count > 0)
                        {
                            CXUIScreenTransit.Transit("frmTLMVEW00055", true, new object[] {this.view.RequireDate, this.view.IsTransactionDate, 
                            this.view.BranchCode, this.view.CurrencyCode, this.view.IsReversal, this.view.IsSourceCurrency, this.view.SortByTime,this.view.AccountSign,this.view.IsSettlementDate });
                        }

                        else
                        {
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                            return;
                        }

                    }

                    #endregion

                    #region Without Reversal
                    if (!this.view.IsReversal)
                    {
                        IList<TLMDTO00058> domestic = CXClientWrapper.Instance.Invoke<ITLMSVE00055, IList<TLMDTO00058>>(x => x.SelectDomesticHomeDayBook(this.view.RequireDate, CurrentUserEntity.CurrentUserID, this.view.CurrencyCode, this.view.BranchCode, workstation, this.view.IsSettlementDate, this.view.SortByTime));

                        if (domestic.Count > 0)
                        {
                            CXUIScreenTransit.Transit("frmTLMVEW00055", true, new object[] {this.view.RequireDate, this.view.IsTransactionDate, 
                            this.view.BranchCode, this.view.CurrencyCode, this.view.IsReversal, this.view.IsSourceCurrency, this.view.SortByTime,this.view.AccountSign,this.view.IsSettlementDate });
                        }

                        else
                        {
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                            return;
                        }

                    }
                    #endregion

                }
                #endregion

                #region Source Cur

                if (this.view.IsSourceCurrency)
                {
                    #region Reversal

                    if (this.view.IsReversal)
                    {
                        IList<TLMDTO00058> domesticreversal = CXClientWrapper.Instance.Invoke<ITLMSVE00055, IList<TLMDTO00058>>(x => x.SelectDomesticReversalDayBook(this.view.RequireDate, CurrentUserEntity.CurrentUserID, this.view.CurrencyCode, this.view.BranchCode, workstation, this.view.IsSettlementDate, this.view.SortByTime));

                        if (domesticreversal.Count > 0)
                        {
                            CXUIScreenTransit.Transit("frmTLMVEW00055", true, new object[] {this.view.RequireDate, this.view.IsTransactionDate, 
                            this.view.BranchCode, this.view.CurrencyCode, this.view.IsReversal, this.view.IsSourceCurrency, this.view.SortByTime,this.view.AccountSign,this.view.IsSettlementDate });
                        }

                        else
                        {
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                            return;
                        }

                    }

                    #endregion

                    #region Without Reversal
                    if (!this.view.IsReversal)
                    {
                        IList<TLMDTO00058> domestic = CXClientWrapper.Instance.Invoke<ITLMSVE00055, IList<TLMDTO00058>>(x => x.SelectDomesticDayBook(this.view.RequireDate, CurrentUserEntity.CurrentUserID, this.view.CurrencyCode, this.view.BranchCode, workstation, this.view.IsSettlementDate, this.view.SortByTime));

                        if (domestic.Count > 0)
                        {
                            CXUIScreenTransit.Transit("frmTLMVEW00055", true, new object[] {this.view.RequireDate, this.view.IsTransactionDate, 
                            this.view.BranchCode, this.view.CurrencyCode, this.view.IsReversal, this.view.IsSourceCurrency, this.view.SortByTime,this.view.AccountSign,this.view.IsSettlementDate});
                        }

                        else
                        {
                            Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");
                            return;
                        }

                    }
                    #endregion

                }



                #endregion

            }

        }

        public bool CheckDate()
        {
            DateTime today = DateTime.Now.Date;
            DateTime reqDate = this.view.RequireDate.Date;


            if (reqDate > today)
            {
                Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode(CXMessage.MV00160, new object[] { this.view.RequireDate.Date.ToString("dd/MM/yyyy") });
                return false;

            }
            else
            {
                return true;
            }
        }

    }
}