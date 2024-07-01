using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Windows.Core.Service;
using Ace.Cbs.Gl.Ctr.Dao;
using Ace.Cbs.Gl.Ctr.Sve;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Cx.Cle;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Gl.Sve
{
    public class GLMSVE00012 : BaseService
    {
        //public CXCLE00001 CXCLEDAO { get; set; }
        

        public GLMSVE00012() { }

        public IList<ChargeOfAccountDTO> SelectCOAAccountNameByACTypeL()
        {
            //IList<ChargeOfAccountDTO> DTOList = CXCLEDAO.SelectCOAAccountNameByACTypeL();
            IList<ChargeOfAccountDTO> DTOList = CXCOM00012.Instance.SelectCOAAccountNameByACTypeL();
            return DTOList;
        }

        public IList<ChargeOfAccountDTO> SelectCOAAccountNameByACode(string acode)
        {
            //IList<ChargeOfAccountDTO> DTOList = CXCLEDAO.SelectCOAAccountNameByACode(acode);
            IList<ChargeOfAccountDTO> DTOList = CXCOM00012.Instance.SelectCOAAccountNameByACode(acode);
            return DTOList;
        }
    }
}
