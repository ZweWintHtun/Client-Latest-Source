//----------------------------------------------------------------------
// <copyright file="SAMCTL00031.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo</CreatedUser>
// <CreatedDate>2015-02-20</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Sam.Ctr.PTR;
using Ace.Windows.Core.Presenter;
using Ace.Windows.CXClient;
using Ace.Cbs.Sam.Ctr.SVE;
using Ace.Cbs.Sam.Dmd;

namespace Ace.Cbs.Sam.Ptr
{
    public class SAMCTL00031:AbstractPresenter,ISAMCTL00031
    {
        #region Properties
		
		public SAMCTL00031() { }
        private ISAMVEW00031 view;
        public ISAMVEW00031 InterestRateListingView
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }
       
        private void WireTo(ISAMVEW00031 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetRateFile());
            }
        }
      				
		#endregion

        #region Private Method
        private SAMDTO00056 GetRateFile()
        {
            SAMDTO00056 ratefiledto = new SAMDTO00056();
            ratefiledto.RATE = this.InterestRateListingView.RateType;
            ratefiledto.STATUS = this.InterestRateListingView.Status;
            ratefiledto.CODE = this.InterestRateListingView.SelectedRate;
            return ratefiledto;
        }
        #endregion

        #region Public Methods
        public IList<SAMDTO00056> SelectRateFileList(string rateActiveStatus)
        {
            try
            {
                IList<SAMDTO00056> RateFileList = CXClientWrapper.Instance.Invoke<ISAMSVE00031, SAMDTO00056>(x => x.SelectRateFileListByRateActive(rateActiveStatus));
                return RateFileList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException + ex.Message);
            }
        }
        public IList<SAMDTO00056> SelectRateFileList()
        {
            try
            {
                IList<SAMDTO00056> RateFileList = CXClientWrapper.Instance.Invoke<ISAMSVE00031, SAMDTO00056>(x => x.SelectRateFileList(this.InterestRateListingView.RateType, this.InterestRateListingView.Status, this.InterestRateListingView.SelectedRate));
                return RateFileList;
            }
            catch (Exception ex)
            {                
                throw new Exception (ex.InnerException+ex.Message);
            }
        }
        #endregion
    }
}
