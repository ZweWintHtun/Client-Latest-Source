using System;
using System.Collections.Generic;
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
    public class GLMCTL00007 : AbstractPresenter, IGLMCTL00007
    {
        public GLMCTL00007() { }

        #region "Data Properties"
       
        private IList<GLMDTO00001> FormatFileDataList { get; set; }
        #endregion

        private IGLMVEW00007 _view;
        public IGLMVEW00007 View
        {
            set { this.WireTo(value); }
            get { return this._view; }
        }
        private void WireTo(IGLMVEW00007 view)
        {
            if (this._view == null)
            {
                this._view = view;
                this.Initialize(this._view, this.GetValidateData());
            }
        }

        public GLMDTO00001 GetValidateData()
        {
            GLMDTO00001 ViewData = new GLMDTO00001();
            ViewData.FormatType = this.View.FormatType;
            ViewData.FormatName = this.View.FormatName;            
            return ViewData;
        }

        public IList<GLMDTO00001> GetFormatFileDataSource(string formatStatus)
        {
            FormatFileDataList = CXClientWrapper.Instance.Invoke<IGLMSVE00007, IList<GLMDTO00001>>(x => x.GetFormatFileDataList(formatStatus));
            return FormatFileDataList;
        }

        public void Save(GLMDTO00001 viewData)
        {
            if (this.ValidateForm(viewData))
            {
                if (this.View.Status.Equals("Save"))
                {
                    viewData.CreatedUserId = CurrentUserEntity.CurrentUserID;
                    viewData.CreatedDate = DateTime.Now;
                    CXClientWrapper.Instance.Invoke<IGLMSVE00007>(x => x.Save(viewData));
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                    {
                        this.View.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                    else
                    {
                        this.View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);                        
                    }
                }
                else
                {
                    viewData.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                    viewData.UpdatedDate = DateTime.Now;                    
                    CXClientWrapper.Instance.Invoke<IGLMSVE00007>(x => x.Update(viewData));
                    if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
                    {
                        this.View.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
                    }
                    else
                    {
                        this.View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);                       
                    }
                }
            }
        }

        public void Delete(IList<GLMDTO00001> deleteitemList)
        {            
            CXClientWrapper.Instance.Invoke<IGLMSVE00007>(x => x.Delete(deleteitemList));
            if (CXClientWrapper.Instance.ServiceResult.ErrorOccurred == false)
            {
                this.View.Successful(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
            else
            {
                this.View.Failure(CXClientWrapper.Instance.ServiceResult.MessageCode);
            }
        }

    }
}
