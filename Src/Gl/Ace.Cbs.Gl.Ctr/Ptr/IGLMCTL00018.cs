using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Gl.Dmd;

namespace Ace.Cbs.Gl.Ctr.Ptr
{
    public interface IGLMCTL00018 : IPresenter
    {
        IGLMVEW00018 View { get; set; }
        IList<GLMDTO00001> GetFormatFileDataSource(string formatType, string formatStatus);
        void Save(IList<GLMDTO00001> GridViewDataList);
        void Delete(IList<GLMDTO00001> DeleteList);
        //string GetDescriptionByACode(string aCode);
    }
    public interface IGLMVEW00018
    {
        IGLMCTL00018 Controller { get; set; }        
        IList<GLMDTO00001> FormatFileDataSource { get; set; }
        int RowCount { get; set; }
        string ParentFormId { get; set; }

        void Successful(string message);
        void Failure(string message);
    }
}
