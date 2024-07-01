using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter ;
using Ace.Cbs.Gl.Dmd;

namespace Ace.Cbs.Gl.Ctr.Ptr
{
    public interface IGLMCTL00007 : IPresenter
    {
        IGLMVEW00007 View { get; set; }
        IList<GLMDTO00001> GetFormatFileDataSource(string formatStatus);
        void Save(GLMDTO00001 viewData);
        void Delete(IList<GLMDTO00001> deleteList);        
    }
    public interface IGLMVEW00007
    {
        IGLMCTL00007 Controller { get; set; }
        string FormatType { get; set; }
        string FormatName { get; set; }
        string Status { get; set; }
        IList<GLMDTO00001> FormatFileDataSource { get; set; }
        void Successful(string message);
        void Failure(string message);
    }
}
