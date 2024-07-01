using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Presenter;
using Ace.Cbs.Tcm.Ctr.Ptr;
using Ace.Windows.CXClient;
using Ace.Cbs.Tcm.Ctr.Sve;

namespace Ace.Cbs.Tcm.Ptr
{
    public class TCMCTL00071 : AbstractPresenter,ITCMCTL00071
    {
        #region Properties
        public TCMCTL00071() 
        { }

        private ITCMVEW00071 view;
        public ITCMVEW00071 View
        {
            set { this.WireTo(value); }
            get { return this.view; }
        }
        private void WireTo(ITCMVEW00071 view)
        {
            if (this.view == null)
            {
                this.view = view;
                this.Initialize(this.view,this.View);
            }
        }
        #endregion

        #region Methods
        public string BackupDatabaseImmediately()
        {
            string result = CXClientWrapper.Instance.Invoke<ITCMSVE00071, string>(x => x.BackupDatabaseImmediately());
            return result;
        }

        public string BackupDatabaseDaily()
        {
            string result = CXClientWrapper.Instance.Invoke<ITCMSVE00071, string>(x => x.BackupDatabaseDaily());
            return result;
        }

        public string BackupDatabaseBefore()
        {
            string result = CXClientWrapper.Instance.Invoke<ITCMSVE00071, string>(x => x.BackupDatabaseBefore());
            return result;
        }

        public string BackupDatabaseAfter()
        {
            string result = CXClientWrapper.Instance.Invoke<ITCMSVE00071, string>(x => x.BackupDatabaseAfter());
            return result;
        }
        #endregion
    }
}
