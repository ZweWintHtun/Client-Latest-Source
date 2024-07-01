using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.CXClient;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Ser;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Gl.Dmd;
using Ace.Cbs.Gl.Ctr.Ptr;
using Ace.Cbs.Gl.Ctr.Sve;

namespace Ace.Cbs.Gl.Ptr
{
    public class GLMCTL00019 : AbstractPresenter, IGLMCTL00019
    {
        public GLMCTL00019() { }

        private IGLMVEW00019 view;
        public IGLMVEW00019 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(IGLMVEW00019 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetEntity());
            }
        }

        public GLMDTO00001 GetEntity()
        {
            GLMDTO00001 ViewData = new GLMDTO00001();
            ViewData.LineNo = this.View.LineNo;
            ViewData.ACode = this.View.AccountNo;
            ViewData.DCode = this.View.Department;

            return ViewData;
        }

        //public bool Validate_Form()
        //{
        //    return this.ValidateForm(this.GetEntity());
        //}

        //public bool Send()
        //{
        //    if (this.Validate_Form())
        //    {
        //        return true;
        //    }
        //    return false;
        //}
    }
}
