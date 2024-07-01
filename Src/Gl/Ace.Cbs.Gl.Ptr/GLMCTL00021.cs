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
    public class GLMCTL00021 : AbstractPresenter, IGLMCTL00021
    {
        public GLMCTL00021() { }

        private IGLMVEW00021 view;
        public IGLMVEW00021 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(IGLMVEW00021 view)
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
            ViewData.Id = this.View.FromLineNo;
            ViewData.LineNo = this.View.ToLineNo;

            return ViewData;
        }
        public bool Validate_Form()
        {
            return this.ValidateForm(this.GetEntity());
        }

        public bool Send()
        {
            if (this.Validate_Form())
            {
                return true;
            }
            return false;
        }
    }
}
