using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Mnm.Ptr
{
    public class MNMCTL00040 : AbstractPresenter, IMNMCTL00040
    {
        #region For Initializer
        private IMNMVEW00040 _view;
        public IMNMVEW00040 View
        {
            set { this.WireTo(value); }
            get { return this._view; }
        }

        private void WireTo(IMNMVEW00040 view)
        {
            if (this._view == null)
            {
                this._view = view;
                this.Initialize(this._view, this.ViewData());
            }
        }


        IList<PFMDTO00042> PrintDataList { get; set; }

        #endregion

        #region Method
        private PFMDTO00042 ViewData()
        {
            PFMDTO00042 ViewData = new PFMDTO00042();
            ViewData.DATE_TIME = this._view.Date;
            ViewData.SourceCur = this._view.CurrencyCode;

            ViewData.IsWithReversal = this._view.IsReversal;

            if (this._view.SortByAcctNo)
                ViewData.Status = "ACCTNO";
            else  //sorybytime
                ViewData.Status = "SETTLEMENTDATE";
            return ViewData;
        }

        public void Print()
        {
            if (this.ValidateForm())
            {
                PFMDTO00042 DataDTO = this.ViewData();
                DataDTO.AccountSign = "S";
                DataDTO.RefType = "DR";
                DataDTO.TransactionCode = "ATLDRTR";
                DataDTO.SourceBranch = CurrentUserEntity.BranchCode;



                IList<PFMDTO00042> PrintDataList = CXClientWrapper.Instance.Invoke<IMNMSVE00040, IList<PFMDTO00042>>(x => x.GetAutoLinkListingReport(DataDTO, CurrentUserEntity.WorkStationId, CurrentUserEntity.CurrentUserID));


                if (PrintDataList != null && PrintDataList.Count > 0)
                {
                    CXUIScreenTransit.Transit("frmMNMVEW00144", true, new object[] { PrintDataList, this.View.FormName, this._view.Date, this.View.IsReversal });
                }


                else
                {
                    Ace.Windows.CXClient.CXUIMessageUtilities.ShowMessageByCode("MI00039");  //No Data For Report                        
                }
            }

        }
    }
        }
        #endregion
    


