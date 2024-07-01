using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Dao;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Gl.Ctr.Dao;
using NHibernate;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using NHibernate.Transform;
using Ace.Cbs.Gl.Dmd;
using System.Data;

namespace Ace.Cbs.Gl.Dao
{
    public class GLMDAO00014 : DataRepository<GLMORM00001> , IGLMDAO00014
    {
        [Transaction(TransactionPropagation.Required)]
        public IList<GLMDTO00001> GetFormatFileDataListForReportFormatEntry(string formatStatus)
        {
            IQuery query = this.Session.GetNamedQuery("GLMVEW00007.SelectFormatFile");
            query.SetString("formatstatus", formatStatus);
            return query.List<GLMDTO00001>();
        }
       
        public bool CheckExist(int id, string formatType, string formatStatus)
        {
            IQuery query = this.Session.GetNamedQuery("GLMVEW00007.CheckExist");
            query.SetString("formatType", formatType);            
            query.SetString("formatStatus", formatStatus);
            //GLMDTO00001 formatfiledto = query.UniqueResult<GLMDTO00001>();
            //return formatfiledto == null ? false : (formatfiledto.Id == id ? false : true);
            IList<GLMDTO00001> formatfiledtolist = query.List<GLMDTO00001>();            
            if (formatfiledtolist != null && formatfiledtolist.Count > 0)
            {
                return true;
            }
            return false;
        }
        
        public void Delete(GLMDTO00001 deleteitem)
        {
            IQuery query = this.Session.GetNamedQuery("GLMVEW00007.DeleteFormatFile");
            //query.SetInt32("id", deleteitem.Id);
            query.SetString("formatStatus", deleteitem.FormatStatus);
            query.SetString("formatType", deleteitem.FormatType);
            query.ExecuteUpdate();            
        }

        [Transaction(TransactionPropagation.Required)]
        public void Update(GLMDTO00001 updateitem)
        {
            IQuery query = this.Session.GetNamedQuery("GLMVEW00007.UpdateFormatFile");
            query.SetString("formatType", updateitem.FormatType);
            query.SetString("formatName", updateitem.FormatName);
            //query.SetInt32("id", updateitem.Id);
            query.SetString("formatStatus", updateitem.FormatStatus);
            query.SetDateTime("updatedDate", updateitem.UpdatedDate.Value);
            query.SetInt32("updatedUserId", updateitem.UpdatedUserId.Value);
            query.ExecuteUpdate();            
        }

        public IList<GLMDTO00001> GetFormatFileDataListForFormulaEntry(string formatType,string formatStatus)
        {
            IQuery query = this.Session.GetNamedQuery("GLMVEW00018.SelectAllFormatFile");
            query.SetString("formatType", formatType);
            query.SetString("formatStatus", formatStatus);
            return query.List<GLMDTO00001>();
        }

        //[Transaction(TransactionPropagation.Required)]                       //unused Code
        //public bool CheckExist(int id, string formatType, string formatName, string formatStatus, string aCode, string showHide, string amountTotal, string other)
        //{
        //    IQuery query = this.Session.GetNamedQuery("GLMVEW00018.CheckExist");
        //    query.SetString("formatType", formatType);
        //    query.SetString("formatName", formatName);
        //    query.SetString("formatStatus", formatStatus);
        //    query.SetString("aCode", aCode);
        //    query.SetString("showHide", showHide);
        //    query.SetString("amountTotal", amountTotal);
        //    query.SetString("other", other);
        //    IList<GLMDTO00001> formatfiledtolist = query.List<GLMDTO00001>();
        //    return formatfiledto == null ? false : (formatfiledto.Id == id ? false : true);
        //    if (formatfiledtolist != null)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        public void DeleteAll(GLMDTO00001 deleteitem)
        {
            IQuery query = this.Session.GetNamedQuery("GLMVEW00018.DeleteAll");            
            query.SetInt32("lineNo", deleteitem.LineNo);
            query.SetString("formatStatus", deleteitem.FormatStatus);
            query.SetString("formatType", deleteitem.FormatType);
            query.SetString("formatName", deleteitem.FormatName);            
            query.SetString("aCode", deleteitem.ACode);
            query.SetString("dCode", deleteitem.DCode);
            query.SetString("showHide", deleteitem.ShowHide);
            query.SetString("amountTotal", deleteitem.AmountTotal);
            query.SetString("other", deleteitem.Other);
            query.ExecuteUpdate();
        }

        public IList<GLMDTO00001> SelectAllByFormatStatus(string formatStatus)
        {
            IQuery query = this.Session.GetNamedQuery("GLMDAO00014.SelectAllByFormatStatus");
            query.SetString("formatStatus", formatStatus);
            return query.List<GLMDTO00001>();
        }

        public IList<GLMDTO00001> SelectFormatFileByFormatTypeAndFormatStatus(string formatType, string formatStatus)
        {
            IQuery query = this.Session.GetNamedQuery("GLMDAO00014.SelectFormatFileByFormatTypeAndFormatStatus");
            query.SetString("formatType", formatType);
            query.SetString("formatStatus", formatStatus);
            return query.List<GLMDTO00001>();
        }

        public IList<GLMDTO00001> SelectCCOASumAmountByAcodeAndDcode(IList<string> acodeList, IList<string> dcodeList,string requiredMonth,string bfRequiredMonth)
        {
            IQuery query = this.Session.CreateQuery("select new formatFileDTO(cc.ACODE,cc.DCODE,sum(cc." + requiredMonth + "),sum(cc." + bfRequiredMonth + ")) from CurrencyChargeOfAccount as cc where cc.ACODE in(:acodeList) and cc.DCODE in (:dcodeList) and cc.Active = true group by cc.ACODE,cc.DCODE");
            query.SetParameterList("acodeList", acodeList);
            query.SetParameterList("dcodeList", dcodeList);
            IList<GLMDTO00001> result = query.List<GLMDTO00001>();
            return result;
        }

        public IList<GLMDTO00001> SelectCCOAAmountByCurAndAcodeAndDcode(IList<string> acodeList, IList<string> dcodeList, string requiredMonth, string bfRequiredMonth, string cur)
        {
            IQuery query = this.Session.CreateQuery("select new formatFileDTO(cc.ACODE,cc.DCODE,cc." + requiredMonth + ",cc." + bfRequiredMonth + ") from CurrencyChargeOfAccount as cc where cc.ACODE in(:acodeList) and cc.DCODE in (:dcodeList) and cc.CUR = :cur and cc.Active = true");
            query.SetParameterList("acodeList", acodeList);
            query.SetParameterList("dcodeList", dcodeList);
            query.SetString("cur", cur);
            IList<GLMDTO00001> result = query.List<GLMDTO00001>();
            return result;
        }

        public IList<GLMDTO00001> SelectFormatFileByFormatTypeAndFormatStatusAndStatus(string formatType, string formatStatus, string status)
        {
            IQuery query = this.Session.GetNamedQuery("GLMDAO000014.SelectFormatFileByFormatTypeAndFormatStatusAndStatus");
            query.SetString("formatType", formatType);
            query.SetString("formatStatus", formatStatus);
            query.SetString("status", status);
            return query.List<GLMDTO00001>();
        }
    }
}
