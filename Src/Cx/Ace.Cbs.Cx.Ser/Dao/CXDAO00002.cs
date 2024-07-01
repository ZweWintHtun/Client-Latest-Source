using System.Collections;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;
using Ace.Windows.Admin.DataModel;
using NHibernate;
using Spring.Stereotype;
using Spring.Transaction;
using Spring.Transaction.Interceptor;

namespace Ace.Cbs.Cx.Ser.Dao
{
    /// <summary>
    /// Code Generator Dao class
    /// </summary>
    [Repository]
    public class CXDAO00002 : DataRepository<Format>, ICXDAO00002
    {

        public IList<FormatDefinition> SelectFormatDefinitonByFormatCode(string code,string branchCode)
        {
            IQuery query = this.Session.GetNamedQuery("FormatDefinitionDAO.SelectFormatDefinitonByFormatCode");
            query.SetString("code", code);
            query.SetString("branchCode", branchCode);
            IList<FormatDefinition> list = query.List<FormatDefinition>();
            return list;
        }


        public FormatDefinition SelectFormatDefinitionById(int id)
        {
            IQuery query = this.Session.GetNamedQuery("FormatDefinitionDAO.SelectById");
            query.SetInt32("id", id);
            return query.UniqueResult<FormatDefinition>();
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual bool FormatDefinitionUpdate(int id, string maximumValue,string branchCode, int updatedUserId, System.DateTime updatedDate, byte[] timestamp)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00002.FormatDefinitionUpdate");
            query.SetInt32("id", id);
            query.SetString("branchCode", branchCode);
            query.SetString("maximumValue", maximumValue);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", updatedDate);
            query.SetBinary("ts", timestamp);

            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual void FormatDefinitionUpdateForLoanReg(int id, string maximumValue, string branchCode, int updatedUserId, System.DateTime updatedDate)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00002.FormatDefinitionUpdateForLoanReg");
            query.SetInt32("formatid", id);
            query.SetString("branchCode", branchCode);
            query.SetString("maximumValue", maximumValue);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", updatedDate);
          //  query.SetBinary("ts", timestamp);

            query.ExecuteUpdate();
        }

        //CXDAO00002.UpdateMaxValueForDenominationDelete
        [Transaction(TransactionPropagation.Required)]
        public virtual void UpdateMaxValueForDenominationDelete(int updatedUserId, System.DateTime updatedDate,string branchCode)
        {
            IQuery query = this.Session.GetNamedQuery("CXDAO00002.UpdateMaxValueForDenominationDelete");            
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", updatedDate);
            query.SetString("branchCode", branchCode);
            query.ExecuteUpdate() ;
        }
    }
}
