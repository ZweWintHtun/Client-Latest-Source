using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;
using Spring.Transaction.Interceptor;
using NHibernate.Transform;


namespace Ace.Cbs.Loan.Dao
{
    public class LOMDAO00075 : DataRepository<LOMORM00075>, ILOMDAO00075
    {
        //public bool CheckExist(string id,string productCode, string seasonCode,string uMCode, string startDate, string endDate,string deadLineDate,string username,DateTime date, bool isEdit)
        //{
        //    IQuery query = this.Session.GetNamedQuery("AGLoanProductTypeItemDAO.CheckExist");
        //    query.SetString("id", id);
        //    query.SetString("productCode", productCode);
        //    query.SetString("seasonCode", seasonCode);
        //    query.SetString("uMCode", uMCode);
        //    query.SetString("startDate", startDate);
        //    query.SetString("endDate", endDate);
        //    query.SetString("deadLineDate", deadLineDate);
        //    query.SetString("USERNO", username);
        //    query.SetDateTime("DATE_TIME", date);
        //    IList<LOMDTO00075> AGLoansList = query.List<LOMDTO00075>();

        //    return AGLoansList.Count == 0 ? false : this.CheckDTOList(AGLoansList, id, isEdit);           
        //    //return AGLoansList.Count == 0 ? false : this.CheckList(AGLoansList, id,productCode, seasonCode, cropCode, uMCode, startDate, endDate, deadLineDate, isEdit);
        //}

        //public IList<LOMDTO00075> CheckExist2(string id, string productCode, string seasonCode, string uMCode, string startDate, string endDate, string deadLineDate, string username, DateTime date)
        //{
        //    IQuery query = this.Session.GetNamedQuery("AGLoanProductTypeItemDAO.CheckExist2");
        //    query.SetString("id", id);
        //    query.SetString("productCode", productCode);
        //    query.SetString("seasonCode", seasonCode);
        //    query.SetString("uMCode", uMCode);
        //    query.SetString("startDate", startDate);
        //    query.SetString("endDate", endDate);
        //    query.SetString("deadLineDate", deadLineDate);
        //    query.SetString("USERNO", username);
        //    query.SetDateTime("DATE_TIME", date);
        //    IList<LOMDTO00075> advanceList = query.List<LOMDTO00075>();
        //    return advanceList;
        //}
        public bool CheckExist(string seasonCode, bool isEdit)
        {
            IQuery query = this.Session.GetNamedQuery("AGLoanProductTypeItemDAO.CheckExist");
            query.SetString("seasonCode", seasonCode);
            IList<LOMDTO00075> AGLoansList = query.List<LOMDTO00075>();

            return AGLoansList.Count == null ? false : this.CheckDTOList(AGLoansList, seasonCode, isEdit);
        }

        public IList<LOMDTO00075> CheckExist2(string seasonCode)
        {
            IQuery query = this.Session.GetNamedQuery("AGLoanProductTypeItemDAO.CheckExist2");
            query.SetString("seasonCode", seasonCode);
            IList<LOMDTO00075> AGLoansList = query.List<LOMDTO00075>();
            return AGLoansList;
        }
        //public IList<LOMDTO00075> SelectAllAGLoanProductTypeItem()
        //{
        //    IQuery query = this.Session.GetNamedQuery("AGLoanProductTypeItemDAO.SelectAll");
        //    return query.List<LOMDTO00075>();
        //}

        //public LOMDTO00075 SelectByAGLoanProductTypeItemSeasonCode(string seasonCode)
        //{
        //    IQuery query = this.Session.GetNamedQuery("AGLoanProductTypeItemDAO.SelectByAGLoanProductTypeItemSeasonCode");
        //    query.SetString("seasonCode", seasonCode);
        //    return query.UniqueResult<LOMDTO00075>();
        //}
          
        public bool CheckDTOList(IList<LOMDTO00075> aGLoansList, string seasoncode, bool isEdit)
        {
            foreach (LOMDTO00075 aGLoansDto in aGLoansList)
            {
                if (aGLoansDto.SeasonCode != seasoncode && isEdit)
                    return true;

                else if (!isEdit)
                    return true;
            }
            return false;
        }
        public IList<LOMDTO00075> GetAllAGLoanProductTypeItem()
        {
            IList<LOMDTO00075> result;
            IQuery query = this.Session.GetNamedQuery("SP_GetAllAGLoanProductTypeItem");
            //query.SetString("sourceBr", sourceBr);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00075)));
            result = query.List<LOMDTO00075>();
            return result;
        }
        public LOMDTO00075 GetAllAGLoanProductTypeItemBySeasonCode(string seasonCode)
        {
            IList<LOMDTO00075> result;
            IQuery query = this.Session.GetNamedQuery("SP_GetAllAGLoanProductTypeItemBySeasonCode");
            query.SetString("seasonCode", seasonCode);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(LOMDTO00075)));
            return query.UniqueResult<LOMDTO00075>();
        }
        // public bool CheckList(IList<LOMDTO00075> AGLoansList,int id,string productCode, string seasonCode, string cropCode, string uMCode, string startDate, string endDate,string deadLineDate,bool isEdit)
        //{
        //    foreach (LOMDTO00075 AGLoansKey in AGLoansList)
        //    {
        //        if (AGLoansKey.Id == id)     
        //        {

        //            for (int i = 0; i < AGLoansList.Count; i++)
        //            {
        //                if ((AGLoansKey.Id != AGLoansList[i].Id) && (AGLoansList[i].Code == code || AGLoansList[i].Value == value))
        //                {
        //                    return true;
        //                }
        //            }
        //            return false;
        //        }
        //    }
        //    return true;
        //}
    }
}
