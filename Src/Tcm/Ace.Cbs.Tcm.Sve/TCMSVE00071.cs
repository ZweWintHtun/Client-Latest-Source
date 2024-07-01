using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Windows.Core.Service;
using Ace.Cbs.Tcm.Ctr.Sve;

namespace Ace.Cbs.Tcm.Sve
{
    public class TCMSVE00071 : BaseService, ITCMSVE00071
    {
        #region Properties
        private IPFMDAO00033 balDAO;
        public IPFMDAO00033 BalDAO
        {
            get { return this.balDAO; }
            set { this.balDAO = value; }
        }
        #endregion

        #region Methods

        //Added by HWKO (15-May-2017)
        public string BackupDatabaseImmediately()
        {
            return BalDAO.BackupDatabaseImmediately();
        }

        //Added by HWKO (15-May-2017)
        public string BackupDatabaseDaily()
        {
            return BalDAO.BackupDatabaseDaily();
        }

        //Added by HWKO (15-May-2017)
        public string BackupDatabaseBefore()
        {
            return BalDAO.BackupDatabaseBefore();
        }

        //Added by HWKO (15-May-2017)
        public string BackupDatabaseAfter()
        {
            return BalDAO.BackupDatabaseAfter();
        }

        #endregion
    }
}
