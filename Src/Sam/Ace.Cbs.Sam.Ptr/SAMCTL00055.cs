using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Sam.Ctr.PTR;
using Ace.Cbs.Sam.Dmd.DTO;
using Ace.Windows.CXClient;
using Ace.Cbs.Sam.Ctr.SVE;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Sam.Ptr
{
    public class SAMCTL00055 : AbstractPresenter, ISAMCTL00055
    {
        #region Properties
        public SAMCTL00055() { }
        private ISAMVEW00055 view;
        public ISAMVEW00055 View
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }

        private void WireTo(ISAMVEW00055 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetViewData());
            }
        }

        public SAMDTO00055 GetViewData()
        {
            SAMDTO00055 codeListingDTO = new SAMDTO00055();
            codeListingDTO.CodeType = this.view.CodeType;
            return codeListingDTO;
        }

        #endregion      


        public IList<PFMDTO00004> SelectOccupation()
        {
           return CXClientWrapper.Instance.Invoke<ISAMSVE00055, PFMDTO00004>(x => x.SelectOccupationListing());
        }

        public IList<PFMDTO00003> SelectInitial()
        {
           return CXClientWrapper.Instance.Invoke<ISAMSVE00055, PFMDTO00003>(x => x.SelectInitialListing());
        }

        public IList<CityDTO> SelectCity()
        {
            return CXClientWrapper.Instance.Invoke<ISAMSVE00055, CityDTO>(x => x.SelectCityListing());
        }

        public IList<StateDTO> SelectState()
        {
            try
            {
                return CXClientWrapper.Instance.Invoke<ISAMSVE00055, StateDTO>(x => x.SelectStateListing());
            }
            catch (Exception ex)
            { return null; }
        }

        public IList<TownshipDTO> SelectTownship()
        {
            try
            {
                return CXClientWrapper.Instance.Invoke<ISAMSVE00055, TownshipDTO>(x => x.SelectTownshipListing());
            }
            catch (Exception ex)
            { return null; }
        }
    }
}
