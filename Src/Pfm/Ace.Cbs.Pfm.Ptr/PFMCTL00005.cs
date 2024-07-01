using System;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.PTR;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;
using Ace.Windows.CXClient;

namespace Ace.Cbs.Pfm.Ptr
{
    public class PFMCTL00005 : AbstractPresenter, IPFMCTL00005
    {
        #region For Initialize

        private IPFMVEW00005 view;
        public IPFMVEW00005 CustomerIdSearchView
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        private void WireTo(IPFMVEW00005 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.view.ViewData);
            }
        } 

        #endregion

        #region Public Methods

        public void SearchCustomerId(PFMDTO00001 customeridDTO)
        { 
          //  int maxSearchCounts = Convert.ToInt32(CXCOM00007.Instance.GetValueByKeyName(CXCOM00009.MaxSearchRecords));

        //   PFMDTO00074 result = CXClientWrapper.Instance.Invoke<IPFMSVE00005, PFMDTO00074>(service => service.SelectByCustomerSearchInfo(customeridDTO,maxSearchCounts));
            //New //
              PFMDTO00074 result = CXClientWrapper.Instance.Invoke<IPFMSVE00005, PFMDTO00074>(service => service.SelectByCustomerSearchInfo(customeridDTO));

           if (result.TotalRecordCount == 0)
           {
               // Customer not found.
              // this.CustomerIdSearchView.ShowMessage(CXMessage.MV00019, 0, 0);
               this.CustomerIdSearchView.ShowMessage(CXMessage.MV00019, 0);
           }
          // else if (result.TotalRecordCount > maxSearchCounts)
           else
           {
               // Total records {0} found.But show {0} records in grid view.
            //   this.CustomerIdSearchView.ShowMessage(CXMessage.MI00002,result.TotalRecordCount,maxSearchCounts);
               this.CustomerIdSearchView.ShowMessage(CXMessage.MI90073, result.TotalRecordCount);
           }

           this.CustomerIdSearchView.gvCustomerId_Databind(result.SearchResultList);
        } 

        #endregion
    }
}