using System;
using System.Collections.Generic;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Transform;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using System.Linq;
using Ace.Windows.Admin.DataModel;
using Ace.Cbs.Pfm.Dmd.DTO;

namespace Ace.Cbs.Pfm.Dao
{
    // CustomerId Dao
    public class PFMDAO00001 : DataRepository<PFMORM00001>, IPFMDAO00001
    {
        #region IPFMDAO00001 Members
        //Added by ZMS For Budget End Flexible
        public IList<PFMDTO00079> GetBLFInfoByStartDate(DateTime pDate, string sourceBr)
        {
            IList<PFMDTO00079> result;
            IQuery query = this.Session.GetNamedQuery("GetBLFInfoByStartDate");
            query.SetDateTime("pDate", pDate);
            query.SetString("sourceBr", sourceBr);

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(PFMDTO00079)));
            IList<PFMDTO00079> multilist = query.List<PFMDTO00079>();
            return multilist;
        }
        //CustomerId Check Exists
        public bool CheckExist(string nrc)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00001.CheckExist");
            query.SetString("nrc", nrc);
            PFMDTO00001 customerId = query.UniqueResult<PFMDTO00001>();
            return customerId == null ? false : (customerId.NRC == nrc ? true : false);
        }


        //CustomerId Select All
        public IList<PFMDTO00001> SelectAll()
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00001.SelectAll");
            return query.List<PFMDTO00001>();
        }

        public PFMDTO00001 SelectTopCustomerId()
        {
            var query = this.Session.CreateCriteria<PFMORM00001>("c").AddOrder(Order.Asc("CustomerId")).SetMaxResults(1);
            query.CreateAlias("CustPhoto", "cp", NHibernate.SqlCommand.JoinType.LeftOuterJoin);

            query.SetProjection(Projections.ProjectionList()
                .Add(Projections.Id(), "CustomerId")
                .Add(Projections.Property("c.Name"), "Name")
                .Add(Projections.Property("c.NRC"), "NRC")
                .Add(Projections.Property("c.GuardianName"), "GuardianName")
                .Add(Projections.Property("c.GuardianNRCNo"), "GuardianNRCNo")
                .Add(Projections.Property("c.FatherName"), "FatherName")
                .Add(Projections.Property("c.Address"), "Address")
                .Add(Projections.Property("c.PhoneNo"), "PhoneNo")
                .Add(Projections.Property("c.FaxNo"), "FaxNo")
                .Add(Projections.Property("c.Email"), "Email")
                .Add(Projections.Property("c.Signature"), "Signature")
                .Add(Projections.Property("c.IsVIP"), "IsVIP")
                .Add(Projections.Property("c.Gender"), "Gender")
                .Add(Projections.Property("c.Remark"), "Remark")
                .Add(Projections.Property("c.PassportNo"), "PassportNo")
                .Add(Projections.Property("c.DateOfBirth"), "DateOfBirth")
                .Add(Projections.Property("c.NameOnly"), "NameOnly")
                .Add(Projections.Property("c.NickName"), "NickName")
                .Add(Projections.Property("c.Nationality"), "Nationality")
                .Add(Projections.Property("c.CityCode"), "CityCode")
                .Add(Projections.Property("c.StateCode"), "StateCode")
                .Add(Projections.Property("c.TownshipCode"), "TownshipCode")
                .Add(Projections.Property("c.Initial"), "Initial")
                .Add(Projections.Property("c.OccupationCode"), "OccupationCode")
                .Add(Projections.Property("cp.CustPhotos"), "CustPhotos")
                );

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(PFMDTO00001)));
            PFMDTO00001 result = query.UniqueResult<PFMDTO00001>();
            return result;
        }

        public PFMDTO00001 SelectLastCustomerId()
        {
            var query = this.Session.CreateCriteria<PFMORM00001>("c").AddOrder(Order.Desc("CustomerId")).SetMaxResults(1);

            query.CreateAlias("CustPhoto", "cp", NHibernate.SqlCommand.JoinType.LeftOuterJoin);

            query.SetProjection(Projections.ProjectionList()
                .Add(Projections.Id(), "CustomerId")
                .Add(Projections.Property("c.Name"), "Name")
                .Add(Projections.Property("c.NRC"), "NRC")
                .Add(Projections.Property("c.GuardianName"), "GuardianName")
                .Add(Projections.Property("c.GuardianNRCNo"), "GuardianNRCNo")
                .Add(Projections.Property("c.FatherName"), "FatherName")
                .Add(Projections.Property("c.Address"), "Address")
                .Add(Projections.Property("c.PhoneNo"), "PhoneNo")
                .Add(Projections.Property("c.FaxNo"), "FaxNo")
                .Add(Projections.Property("c.Email"), "Email")
                .Add(Projections.Property("c.Signature"), "Signature")
                .Add(Projections.Property("c.IsVIP"), "IsVIP")
                .Add(Projections.Property("c.Gender"), "Gender")
                .Add(Projections.Property("c.Remark"), "Remark")
                .Add(Projections.Property("c.PassportNo"), "PassportNo")
                .Add(Projections.Property("c.DateOfBirth"), "DateOfBirth")
                .Add(Projections.Property("c.NameOnly"), "NameOnly")
                .Add(Projections.Property("c.NickName"), "NickName")
                .Add(Projections.Property("c.Nationality"), "Nationality")
                .Add(Projections.Property("c.CityCode"), "CityCode")
                .Add(Projections.Property("c.StateCode"), "StateCode")
                .Add(Projections.Property("c.TownshipCode"), "TownshipCode")
                .Add(Projections.Property("c.Initial"), "Initial")
                .Add(Projections.Property("c.OccupationCode"), "OccupationCode")
                .Add(Projections.Property("cp.CustPhotos"), "CustPhotos")
                );

            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(PFMDTO00001)));
            PFMDTO00001 result = query.UniqueResult<PFMDTO00001>();
            return result;
        }

        public int CountByCustomerSearchInfo(PFMDTO00001 custDTO)
        {
            ICriteria query = this.Session.CreateCriteria<PFMORM00001>("c");

            query.CreateAlias("CustPhoto", "cp", NHibernate.SqlCommand.JoinType.LeftOuterJoin);

            if (custDTO.Name.Length > 0)
            {
                if (custDTO.isCheckName)
                {
                    query.Add(Expression.Eq("NameOnly", custDTO.Name));
                }
                else
                {
                    query.Add(Expression.Like("NameOnly", custDTO.Name, MatchMode.Anywhere));
                }
            }

            if (custDTO.NRC.Length > 0)
            {
                if (custDTO.isCheckNRC)
                {
                    query.Add(Expression.Eq("NRC", custDTO.NRC));
                }
                else
                {
                    query.Add(Expression.Like("NRC", custDTO.NRC, MatchMode.Anywhere));
                }
            }

            if (custDTO.FatherName.Length > 0)
            {
                if (custDTO.isCheckFatherName)
                {
                    query.Add(Expression.Eq("FatherName", custDTO.FatherName));
                }
                else
                {
                    query.Add(Expression.Like("FatherName", custDTO.FatherName, MatchMode.Anywhere));
                }
            }

            query.SetProjection(Projections.CountDistinct("CustomerId"));

            return (int)query.UniqueResult();
        }

        //  public IList<PFMDTO00001> SelectByCustomerSearchInfo(PFMDTO00001 custDTO, int maxSearchRecordCounts)

        public IList<PFMDTO00001> SelectByCustomerSearchInfo(PFMDTO00001 custDTO)
        {
            ICriteria query = this.Session.CreateCriteria<PFMORM00001>("c");

            query.CreateAlias("Occupation", "oc", NHibernate.SqlCommand.JoinType.LeftOuterJoin)
            .CreateAlias("Township", "ts", NHibernate.SqlCommand.JoinType.LeftOuterJoin)
            .CreateAlias("City", "ct", NHibernate.SqlCommand.JoinType.LeftOuterJoin)
            .CreateAlias("State", "st", NHibernate.SqlCommand.JoinType.LeftOuterJoin)
            .CreateAlias("InitialEntity", "ie", NHibernate.SqlCommand.JoinType.LeftOuterJoin);

            query.SetProjection(Projections.ProjectionList()
                 .Add(Projections.Id(), "CustomerId")
                 .Add(Projections.Property("c.Nationality"), "Nationality")
                .Add(Projections.Property("c.Name"), "Name")
                .Add(Projections.Property("c.NRC"), "NRC")
                .Add(Projections.Property("c.DateOfBirth"), "DateOfBirth")
                .Add(Projections.Property("c.FatherName"), "FatherName")
                .Add(Projections.Property("c.GuardianName"), "GuardianName")
                .Add(Projections.Property("c.GuardianNRCNo"), "GuardianNRCNo")
                .Add(Projections.Property("c.Address"), "Address")
                .Add(Projections.Property("c.PhoneNo"), "PhoneNo")
                 .Add(Projections.Property("c.Gender"), "Gender")
                .Add(Projections.Property("c.FaxNo"), "FaxNo")
                .Add(Projections.Property("c.Email"), "Email")
                 .Add(Projections.Property("c.CityCode"), "CityCode")
                 .Add(Projections.Property("c.StateCode"), "StateCode")
                 .Add(Projections.Property("c.TownshipCode"), "TownshipCode")
                  .Add(Projections.Property("c.Initial"), "Initial")
                   .Add(Projections.Property("c.OccupationCode"), "OccupationCode")
                .Add(Projections.Property("ct.Description"), "CityDesp")
                .Add(Projections.Property("st.Description"), "StateDesp")
                .Add(Projections.Property("ts.Description"), "TownshipDesp")
                .Add(Projections.Property("oc.Description"), "OccupationDesp")
                );

            if (custDTO.Name.Length > 0)
            {
                if (custDTO.isCheckName)
                {
                    query.Add(Expression.Eq("NameOnly", custDTO.Name));
                }
                else
                {
                    query.Add(Expression.Like("NameOnly", custDTO.Name, MatchMode.Anywhere));
                }
            }

            if (custDTO.NRC.Length > 0)
            {
                if (custDTO.isCheckNRC)
                {
                    query.Add(Expression.Eq("NRC", custDTO.NRC));
                }
                else
                {
                    query.Add(Expression.Like("NRC", custDTO.NRC, MatchMode.Anywhere));
                }
            }

            if (custDTO.FatherName.Length > 0)
            {
                if (custDTO.isCheckFatherName)
                {
                    query.Add(Expression.Eq("FatherName", custDTO.FatherName));
                }
                else
                {
                    query.Add(Expression.Like("FatherName", custDTO.FatherName, MatchMode.Anywhere));
                }
            }

            query.Add(Expression.Eq("c.Active", true));
            query.Add(Expression.Eq("oc.Active", true));
            query.Add(Expression.Eq("ts.Active", true));
            query.Add(Expression.Eq("ct.Active", true));
            query.Add(Expression.Eq("st.Active", true));
            query.Add(Expression.Eq("ie.Active", true));

            // query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(PFMDTO00001))).SetMaxResults(maxSearchRecordCounts);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(PFMDTO00001)));
            return query.List<PFMDTO00001>();
        }

        #endregion

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateCloseAccount(string id, int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00001.UpdateCloseAccount");
            query.SetString("id", id);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateName(PFMDTO00001 custEntity)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00001.UpdateCustomerId");
            query.SetString("customerid", custEntity.CustomerId);
            query.SetString("name", custEntity.Name);
            query.SetBoolean("IsNRC", custEntity.IsNRC);
            query.SetString("nrc", custEntity.NRC);
            query.SetString("guardianName", custEntity.GuardianName);
            query.SetBoolean("IsGuardianNRC", custEntity.IsGuardianNRC);
            query.SetString("guardiannrcNo", custEntity.GuardianNRCNo);
            query.SetString("fatherName", custEntity.FatherName);
            query.SetString("address", custEntity.Address);
            query.SetString("phoneNo", custEntity.PhoneNo);
            query.SetString("faxNo", custEntity.FaxNo);
            query.SetString("email", custEntity.Email);
            query.SetBinary("siganture", (System.Byte[])custEntity.Signature);
            query.SetBoolean("isVIP", custEntity.IsVIP);
            query.SetString("gender", custEntity.Gender);
            query.SetString("remark", custEntity.Remark);
            query.SetString("passportNo", custEntity.PassportNo);
            query.SetDateTime("dateofbirth", custEntity.DateOfBirth);
            query.SetString("nameonly", custEntity.NameOnly);
            query.SetString("nickname", custEntity.NickName);
            query.SetString("nationality", custEntity.Nationality);
            query.SetString("statecode", custEntity.StateCode);
            query.SetString("citycode", custEntity.CityCode);
            query.SetString("townshipCode", custEntity.TownshipCode);
            query.SetString("initial", custEntity.Initial);
            query.SetString("occupationCode", custEntity.OccupationCode);
            query.SetDateTime("datetime", custEntity.DATE_TIME);
            //query.SetString("sourcebranch", custEntity.SourceBranch);
            query.SetDateTime("updateddate", (System.DateTime)custEntity.UpdatedDate);
            query.SetInt32("updateduserId", (System.Int32)custEntity.UpdatedUserId);
            return query.ExecuteUpdate() > 0;
        }

        public IList<PFMDTO00001> SelectListByCustId(IList<string> customerlist)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00001.CustomerId_SelectListByCustId");
            query.SetParameterList("customerlist", customerlist);
            IList<PFMDTO00001> list = query.List<PFMDTO00001>();
            return list;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateOpenAccount(string id, int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00001.UpdateOpenAccount");
            query.SetString("id", id);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            return query.ExecuteUpdate() > 0;
        }

        [Transaction(TransactionPropagation.Required)]
        public bool UpdateOpenAccount_Minus(string id, int updatedUserId)
        {
            IQuery query = this.Session.GetNamedQuery("PFMDAO00001.UpdateOpenAccount_Minus");
            query.SetString("id", id);
            query.SetInt32("updatedUserId", updatedUserId);
            query.SetDateTime("updatedDate", DateTime.Now);
            return query.ExecuteUpdate() > 0;
        }

        public PFMDTO00001 SelectCustomerByCustID(string customerId)
        {
            IQuery query = this.Session.GetNamedQuery("CustomerIdDAO.SelectDatasByCustomerId");
            query.SetString("custid", customerId);
            PFMDTO00001 customerIdDTO = query.UniqueResult<PFMDTO00001>();
            return customerIdDTO;
        }

        #region IPFMDAO00001 Members

        public PFMDTO00001 SelectByCustomerId(string customerid)
        {
            PFMDTO00001 result = new PFMDTO00001();
            var query = this.Session.CreateCriteria<PFMORM00001>("c").Add(Restrictions.Eq("CustomerId", customerid));
            query.CreateAlias("CustPhoto", "cp", NHibernate.SqlCommand.JoinType.LeftOuterJoin);

            query.SetProjection(Projections.ProjectionList()
                 .Add(Projections.Id(), "CustomerId")
                 .Add(Projections.Property("c.Name"), "Name")
                 .Add(Projections.Property("c.IsNRC"), "IsNRC")
                 .Add(Projections.Property("c.NRC"), "NRC")
                 .Add(Projections.Property("c.GuardianName"), "GuardianName")
                 .Add(Projections.Property("c.IsGuardianNRC"), "IsGuardianNRC")
                 .Add(Projections.Property("c.GuardianNRCNo"), "GuardianNRCNo")
                 .Add(Projections.Property("c.FatherName"), "FatherName")
                 .Add(Projections.Property("c.Address"), "Address")
                 .Add(Projections.Property("c.PhoneNo"), "PhoneNo")
                 .Add(Projections.Property("c.FaxNo"), "FaxNo")
                 .Add(Projections.Property("c.Email"), "Email")
                 .Add(Projections.Property("c.Signature"), "Signature")
                 .Add(Projections.Property("c.IsVIP"), "IsVIP")
                 .Add(Projections.Property("c.Gender"), "Gender")
                 .Add(Projections.Property("c.Remark"), "Remark")
                 .Add(Projections.Property("c.PassportNo"), "PassportNo")
                 .Add(Projections.Property("c.DateOfBirth"), "DateOfBirth")
                 .Add(Projections.Property("c.NameOnly"), "NameOnly")
                 .Add(Projections.Property("c.NickName"), "NickName")
                 .Add(Projections.Property("c.Nationality"), "Nationality")
                 .Add(Projections.Property("c.CityCode"), "CityCode")
                 .Add(Projections.Property("c.StateCode"), "StateCode")
                 .Add(Projections.Property("c.TownshipCode"), "TownshipCode")
                 .Add(Projections.Property("c.Initial"), "Initial")
                 .Add(Projections.Property("c.OccupationCode"), "OccupationCode")
                 .Add(Projections.Property("c.TS"), "TS")
                 .Add(Projections.Property("cp.CustPhotoName"), "CustPhotoName")
                 .Add(Projections.Property("cp.CustPhotos"), "CustPhotos")
                 .Add(Projections.Property("cp.TS"), "TS")
                 .Add(Projections.Property("cp.Active"), "Active")
                 .Add(Projections.Property("cp.Id"), "Id")
                 );
            query.AddOrder(Order.Desc("cp.Id"));
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(PFMDTO00001)));
            IList<PFMDTO00001> list = query.List<PFMDTO00001>();
            result = list.FirstOrDefault();
            return result;
        }

        //public PFMDTO00001 SelectCustomerInfoFromCAOFByAccountNo(string accountNo)
        //{
        //    IQuery query = this.Session.GetNamedQuery("PFMDAO00001.SelectCustomerInformationFromCAOFByAccountNo");
        //    query.SetString("accountNo", accountNo);
        //    return query.UniqueResult<PFMDTO00001>();
        //}
        #endregion

        public PFMDTO00001 GetTownshipCode(string customerId)
        {
            IQuery query = this.Session.GetNamedQuery("TownshipCodeDAO.SelectTownshipCodeByCustId");
            query.SetString("custId", customerId);
            return query.UniqueResult<PFMDTO00001>();
        }

        public TownshipDTO SelectTownship(string townshipCode)
        {
            IQuery query = this.Session.GetNamedQuery("Township.SelectTownshipDesp");
            query.SetString("townshipCode", townshipCode);

            return query.UniqueResult<TownshipDTO>();
        }

        //Added by ZMS to check Black List
        public PFMDTO00080 CheckNRCForExternalBlackListCustomer(string nRC, string BranchCode)
        {
            IQuery query = this.Session.GetNamedQuery("SP_CheckNRCForExternalBlackListCustomer");
            query.SetString("nrc", nRC);
            query.SetString("branchCode", BranchCode);
            query.SetTimeout(10000);
            query.SetResultTransformer(new AliasToBeanResultTransformer(typeof(PFMDTO00080)));
            return query.UniqueResult<PFMDTO00080>();
        }
    }
}