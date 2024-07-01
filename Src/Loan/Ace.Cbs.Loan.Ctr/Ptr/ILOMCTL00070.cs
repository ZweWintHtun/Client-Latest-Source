using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Loan.Ctr.Ptr
{
    public interface ILOMCTL00070 : IPresenter
    {
        ILOMVEW00070 VillageGroupEntryView { set; get; }
        IList<LOMDTO00070> GetAll();
        void Save(LOMDTO00070 entity);
        void Delete(IList<LOMDTO00070> itemList);
    }

    public interface ILOMVEW00070
    {
        string VillageCode { get; set; }
        string Description { get; set; }
        string Status { get; set; }

        LOMDTO00070 ViewData { get; set; }
        LOMDTO00070 PreviousVillageGroupDto { get; set; }
        IList<LOMDTO00070> VillageGroupList { get; set; }
        ILOMCTL00070 Controller { get; set; }
        void focus();
        void Successful(string message);
        void Failure(string message);
    }
}
