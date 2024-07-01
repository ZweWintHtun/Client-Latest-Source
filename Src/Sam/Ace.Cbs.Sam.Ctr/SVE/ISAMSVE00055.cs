using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Sam.Dmd.DTO;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Sam.Ctr.SVE
{
    public interface ISAMSVE00055 : IBaseService
    {
        IList<PFMDTO00004> SelectOccupationListing();
        IList<StateDTO> SelectStateListing();
        IList<CityDTO> SelectCityListing();
        IList<TownshipDTO> SelectTownshipListing();
        IList<PFMDTO00003> SelectInitialListing();
    }
}
