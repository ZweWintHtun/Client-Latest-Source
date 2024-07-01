using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Core.Utt;
using Ace.Windows.CXClient;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Gl.Ctr.Ptr;
using Ace.Cbs.Gl.Ctr.Sve;
using Ace.Cbs.Gl.Dmd;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Gl.Ptr
{
    public class GLMCTL00018 : AbstractPresenter , IGLMCTL00018
    {
        public GLMCTL00018() { }

        IList<GLMDTO00001> FormatFileDataList { get; set; }
        public IGLMVEW00018 View { get; set; }
       

        public IList<GLMDTO00001> GetFormatFileDataSource(string formatType, string formatStatus)
        {
            FormatFileDataList = CXClientWrapper.Instance.Invoke<IGLMSVE00018, IList<GLMDTO00001>>(x => x.GetAllFormatFile(formatType,formatStatus));
            return FormatFileDataList;
        }

        //public string GetDescriptionByACode(string aCode)
        //{
        //    string description = CXClientWrapper.Instance.Invoke<IGLMSVE00008, string>(x => x.GetDescription(aCode));
        //    return description;
        //}

        public void Save(IList<GLMDTO00001> GridViewDataList)
        {
            int i = 0;
            foreach (GLMDTO00001 DataDTO in GridViewDataList)
            {
                GridViewDataList[i].CreatedDate = DateTime.Now;
                GridViewDataList[i].CreatedUserId = CurrentUserEntity.CurrentUserID;
                i++;
            }            
            CXClientWrapper.Instance.Invoke<IGLMSVE00018>(x => x.Save(GridViewDataList));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
            {
                this.View.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);  //Saving Successful
            }
            else
            {
                this.View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);  //Saving error
            }
        }

        public void Delete(IList<GLMDTO00001> DeleteList)
        {
            CXClientWrapper.Instance.Invoke<IGLMSVE00018>(x => x.Delete(DeleteList));
        }
    }
}
