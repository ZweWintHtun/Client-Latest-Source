using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Windows.Core.Dao;
using NHibernate;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Mnm.Ctr.Dao;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Mnm.Ctr.Dao;

namespace Ace.Cbs.Mnm.Dao
{
    public class FormatDao:DataRepository<Format>,IFormatDao
    {
        public IList<FormatDefinitionDTO> SelectFormatDefinitionByCodeAndPortionCode(string code, string branchCode)
        {
            IQuery query = this.Session.GetNamedQuery("FormatDefinitionDAO.SelectFormatDefinitonByFormatCode");
            query.SetString("code", code);
            query.SetString("branchCode", branchCode);
            IList<FormatDefinitionDTO> formatDefinitionDTO = query.List<FormatDefinitionDTO>();
            return formatDefinitionDTO;
        }

    }
}
