using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Gl.Ctr.Sve;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Mnm.Dmd;
using Ace.Cbs.Gl.Ctr.Dao;
using Ace.Windows.Core.Utt;

namespace Ace.Cbs.Gl.Sve
{
    public class GLMSVE00008 : BaseService,IGLMSVE00008
    {
        #region DAOProperties

        IGLMDAO00008 EnquiryOnLedgerDAO { get; set; }
        #endregion

        public MNMDTO00010 GetCCOAandCOA_ByACodeAndCurrency(MNMDTO00010 DataDTO)
        {
            MNMDTO00010 GetInfo = new MNMDTO00010();
            GetInfo = EnquiryOnLedgerDAO.GetCCOAAndCOAInfo(DataDTO.ACODE, DataDTO.CUR, DataDTO.Sourcebranch);
            return GetInfo;
        }
    }
}
