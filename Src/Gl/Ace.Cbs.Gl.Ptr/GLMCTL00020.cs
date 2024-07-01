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
    public class GLMCTL00020 : AbstractPresenter, IGLMCTL00020
    {
        public GLMCTL00020() { }

        private IGLMVEW00020 view;
        public IGLMVEW00020 View
        {
            get { return this.view; }
            set { this.WireTo(value); }
        }

        private void WireTo(IGLMVEW00020 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view, this.GetEntity());
            }
        }

        public ChargeOfAccountDTO GetEntity()
        {
            ChargeOfAccountDTO ViewData = new ChargeOfAccountDTO();
            ViewData.ACode = this.View.FromAccountNo;
            ViewData.AccountName = this.View.ToAccountNo;

            return ViewData;
        }

        public bool Validate_Form()
        {
            return this.ValidateForm(this.GetEntity());
        }

        public bool send()
        {
            if (this.Validate_Form())
            {
                return true;
            }
            return false;
        }
    }
}
