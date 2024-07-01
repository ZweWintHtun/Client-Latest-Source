using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Sam.Ctr.PTR
{
    public interface ISAMCTL00055 : IPresenter
    {
        ISAMVEW00055 View { get; set; }
        IList<PFMDTO00004> SelectOccupation();
        IList<PFMDTO00003> SelectInitial();
        IList<CityDTO> SelectCity();
        IList<StateDTO> SelectState();
        IList<TownshipDTO> SelectTownship();
    }

    public interface ISAMVEW00055 
    {
        ISAMCTL00055 Controller { get; set; }
        string CodeType { get; set; }
    }


}
