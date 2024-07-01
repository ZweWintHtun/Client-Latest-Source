using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Presenter;

namespace Ace.Cbs.Pfm.Ctr.PTR
{
    public interface IPFMCTL00078 : IPresenter
    {
        IPFMVEW00078 solidarityView { set; get; }
        void Save(IList<PFMDTO00078> entity, IList<PFMDTO00078> oldSolidarity=null);
        IList<PFMDTO00078> SelectByGroupNo(string groupNo);
        void Delete(IList<PFMDTO00078> itemList);
    }
    public interface IPFMVEW00078
    {
        int Id { get; set; }
        string GroupNo { get; set; }
        string NameOnly { get; set; }
        bool IsNRC { get; set; }
        string NRCNo { get; set; }
        string NationalityCodeForNRC { get; set; }
        string TownshipCodeForNRC { get; set; }
        string StateCodeForNRC { get; set; }
        string other { get; set; }
        string FatherName { get; set; }
        string VillageCode { get; set; }
        string Address { get; set; }
        string Status { get; set; }

        PFMDTO00078 ViewData { get; set; }
        IList<PFMDTO00078> lstSolidarity { get; set; }
        IPFMCTL00078 SolidarityLendingController { get; set; }
        void Successful(string message, string groupNo);
        void Failure(string message);
    }
}
