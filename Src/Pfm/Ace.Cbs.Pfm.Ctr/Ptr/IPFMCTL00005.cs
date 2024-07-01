using System.Collections.Generic;
using Ace.Cbs.Pfm.Dmd;

namespace Ace.Cbs.Pfm.Ctr.PTR
{
    public interface IPFMCTL00005
    {
        IPFMVEW00005 CustomerIdSearchView { set; get; }
        void SearchCustomerId(PFMDTO00001 customeridDTO);
    }

    public interface IPFMVEW00005
    {
        PFMDTO00001 ViewData { get; set; }    
        IPFMCTL00005 CustomerIdSearchController { set; get; }
        void gvCustomerId_Databind(IList<PFMDTO00001> CustomerId);
       // void ShowMessage(string message, int totalRecordCounts, int maxSearchCounts);
        void ShowMessage(string message, int totalRecordCounts);
    }
}