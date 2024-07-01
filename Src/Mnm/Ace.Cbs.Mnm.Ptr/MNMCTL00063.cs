using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Windows.Core.Presenter;
using Ace.Windows.CXClient;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Mnm.Dmd;

namespace Ace.Cbs.Mnm.Ptr
{
    public class MNMCTL00063 : AbstractPresenter, IMNMCTL00063
    {
        private IMNMVEW00063 view;
        public IMNMVEW00063 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(IMNMVEW00063 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetEntity());
            }
        }

        public bool Validate_Form()
        {
            return this.ValidateForm(this.GetEntity());
        }

        public MNMDTO00040 GetEntity()
        {
            MNMDTO00040 entity = new MNMDTO00040();
            entity.StartAmount = this.view.StartAmount;
            entity.EndAmount = this.view.EndAmount;
            entity.Cur = this.view.Currency;
            entity.IscheckAllCurrency = this.view.IscheckAllCurrency;
            entity.IsrdoCurrent = this.view.IsrdoCurrent;
            entity.TransactionStatus = this.view.ParentFormName;
            entity.SourceBr = CurrentUserEntity.BranchCode;

            return entity;
        }

        public void Print()
        {
            if (this.Validate_Form())
            {
                if (this.view.StartAmount >= 0)
                {
                    if (this.view.StartAmount >= 0 && this.view.EndAmount != 0)
                    {
                        if (this.view.StartAmount > this.view.EndAmount)
                        {
                            CXUIMessageUtilities.ShowMessageByCode("MV00202"); //End amount must be greater than start amount.
                        }
                        else
                        {
                            MNMDTO00040 DTO = this.GetEntity();
                            bool isCheckCurrency = false;
                            if (this.view.IscheckAllCurrency == true)
                            {
                                isCheckCurrency = true;
                                this.view.Currency = string.Empty;
                            }

                            IList<MNMDTO00040> DTOList = CXClientWrapper.Instance.Invoke<IMNMSVE00063, IList<MNMDTO00040>>(x => x.GetReportData(DTO, isCheckCurrency, this.view.IsrdoCurrent));
                            if (DTOList.Count > 0)
                            {
                                decimal startAmount = this.view.StartAmount;
                                decimal endAmount = this.view.EndAmount;
                                string currency = this.view.Currency;
                                string header = string.Empty;
                                if (this.view.IsrdoCurrent == "Current Account")
                                {
                                    header = "Ledger Balance Listing (Current) By Grade";
                                    CXUIScreenTransit.Transit("frmMNMVEW00112.ReportViewer", true, new object[] { DTOList, startAmount, endAmount, currency, header });
                                }
                                else
                                {
                                    header = "Ledger Balance Listing (Saving) By Grade";
                                    CXUIScreenTransit.Transit("frmMNMVEW00112.ReportViewer", true, new object[] { DTOList, startAmount, endAmount, currency, header });
                                }
                            }
                            else
                            {
                                CXUIMessageUtilities.ShowMessageByCode("MI00039");//No Data For Report.
                            }
                        }
                    }
                    else
                    {
                        CXUIMessageUtilities.ShowMessageByCode("MV20084"); //End Amount must not be zero.
                    }
                }
                else
                {
                    CXUIMessageUtilities.ShowMessageByCode("MV20030"); //Invalid Start Amount
                }
            }                       
        }
    }
}
