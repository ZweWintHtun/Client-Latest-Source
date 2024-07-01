using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Pfm.Ctr.DAO;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Windows.Ix.Core.DataModel;
using Spring.Transaction.Interceptor;
using Spring.Transaction;
using Ace.Windows.Core.DataModel;
using Ace.Windows.CXServer.Utt;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Windows.Ix.Core.Ctr;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Ser;
using AutoMapper;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Cx.Ser.Sve;
using Ace.Cbs.Pfm.Ctr.Sve;

namespace Ace.Cbs.Pfm.Sve
{
    public class PFMSVE00078 : BaseService, IPFMSVE00078
    {
        #region Properties
        private PFMORM00078 lsSolidarityLendingInfo;

        public ICXSVE00002 CodeGenerator { get; set; }

        private IPFMDAO00078 _solidarityLendingDAO;
        public IPFMDAO00078 SolidarityLendingDAO
        {
            get { return this._solidarityLendingDAO; }
            set { this._solidarityLendingDAO = value; }
        }
        #endregion

        #region Method
        public string GenerateSolidarityLendingGroupNo()
        {
            return this.SolidarityLendingDAO.SelectSolidarityCountNo();
        }

        public IList<PFMDTO00078> SelectByGroupNo(string groupNo)
        {
            return this.SolidarityLendingDAO.SelectByGroupNo(groupNo);
        }

        public string SaveServerAndServerClient(IList<PFMDTO00078> lstSolidarity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            try
            {
                string groupNo = this.CodeGenerator.GenerateCodeForLoanGroupNo(CXCOM00009.LoanGroupNo, Convert.ToInt32(lstSolidarity.Select(x => x.CreatedUserId).FirstOrDefault().ToString()), lstSolidarity.Select(x => x.SourceBr).FirstOrDefault().ToString(), new object[] { lstSolidarity.Select(x => x.SourceBr).FirstOrDefault().ToString() });
                int count = 0;
                lstSolidarity.ToList().ForEach(x => x.GroupNo = groupNo);
                foreach (PFMDTO00078 lsSolid in lstSolidarity)
                {
                    lsSolid.CreatedUserId = CurrentUserEntity.CurrentUserID;
                    PFMORM00078 lsSolidDTO = this.Save(lsSolid, dvcvList);
                    if (lsSolidDTO != null)
                    {
                        count++;
                       
                    }
                }
                if (count == 3)
                {
                    if (!this.ServiceResult.ErrorOccurred)
                    {
                        this.ServiceResult.ErrorOccurred = false;
                        this.ServiceResult.MessageCode = "MI00051";// Saving Successful                      
                    }
                }
                return groupNo;
            }
            catch
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90036";//Error Occur!!! Please contact your administrator.
                return string.Empty;
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual PFMORM00078 Save(PFMDTO00078 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            PFMORM00078 lsSolidarityLending = null;
            lsSolidarityLending = this.SolidarityLendingDAO.Save(this.GetLsSolidarity(entity, false));
            
            return lsSolidarityLending;
        }

        private PFMORM00078 GetLsSolidarity(PFMDTO00078 lsSolidarityDTO, bool isDelete)
        {
            lsSolidarityLendingInfo = new PFMORM00078();

            lsSolidarityLendingInfo.Id = lsSolidarityDTO.Id;
            lsSolidarityLendingInfo.GroupNo = lsSolidarityDTO.GroupNo;
            lsSolidarityLendingInfo.NameOnly = lsSolidarityDTO.NameOnly;
            lsSolidarityLendingInfo.IsNRC = lsSolidarityDTO.IsNRC;
            lsSolidarityLendingInfo.IsLeader = lsSolidarityDTO.IsLeader;
            lsSolidarityLendingInfo.NRCNo = lsSolidarityDTO.NRCNo;
            lsSolidarityLendingInfo.FatherName = lsSolidarityDTO.FatherName;
            lsSolidarityLendingInfo.VillageCode = lsSolidarityDTO.VillageCode;
            lsSolidarityLendingInfo.Address = lsSolidarityDTO.Address;
            lsSolidarityLendingInfo.OpenDate = DateTime.Now;
            lsSolidarityLendingInfo.UserNo = lsSolidarityDTO.UserNo;
            lsSolidarityLendingInfo.SourceBr = lsSolidarityDTO.SourceBr;
            lsSolidarityLendingInfo.TS = lsSolidarityDTO.TS;
            lsSolidarityLendingInfo.CreatedUserId = lsSolidarityDTO.CreatedUserId;
            lsSolidarityLendingInfo.CreatedDate = DateTime.Now;
            lsSolidarityLendingInfo.UpdatedUserId = lsSolidarityDTO.UpdatedUserId;
            lsSolidarityLendingInfo.UpdatedDate = DateTime.Now;

            if (isDelete)
                lsSolidarityLendingInfo.Active = false;
            else
                lsSolidarityLendingInfo.Active = true;

            return lsSolidarityLendingInfo;
        }

        [Transaction(TransactionPropagation.Required)]
        public void Delete(IList<PFMDTO00078> itemList)
        {
            try
            {
                foreach (PFMDTO00078 item in itemList)
                {
                    PFMORM00078 deletedEntity = this.DeleteServer(item);
                }
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "MI90003";//Delete Success
            }
            catch
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90036";//Error Occur!!! Please contact your administrator.
                throw new Exception(this.ServiceResult.MessageCode);
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual PFMORM00078 DeleteServer(PFMDTO00078 solidarityDTO)
        {
            try
            {
                PFMORM00078 solidarityList = this.GetLsSolidarity(solidarityDTO, true);
                PFMORM00078 deletedEntity = this.SolidarityLendingDAO.Delete(solidarityList, false);
                return deletedEntity;
            }
            catch
            {
                throw;
            }
        }
       
        /* Update Client(SQLite) */
        [Transaction(TransactionPropagation.Required)]
        public virtual void Update(PFMDTO00078 entity, IList<DataVersionChangedValueDTO> dvcvList, string status)
        {
            try
            {
                if (this.UpdateServer(entity, dvcvList) != null)
                {
                    PFMORM00078 solidarity = this.UpdateServer(entity, dvcvList);
                    if (!this.ServiceResult.ErrorOccurred)
                    {
                        this.ServiceResult.ErrorOccurred = false;
                        if (status == "Update")
                            this.ServiceResult.MessageCode = "MI90002";//Update Success
                        else
                            this.ServiceResult.MessageCode = "MI90001";//Saving Successful
                    }
                    else
                    {
                        this.ServiceResult.ErrorOccurred = true;
                        this.ServiceResult.MessageCode = "ME90036";
                    }
                }
            }
            catch
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90036";
            }
        }

        /* Update To SQLServer by using DAO Query */
        [Transaction(TransactionPropagation.Required)]
        public PFMORM00078 UpdateServer(PFMDTO00078 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            try
            {
                PFMORM00078 SolidarityEntity = null;
                if (this.SolidarityLendingDAO.UpdateSolidarity(entity) == true)
                {
                    SolidarityEntity = this.GetLsSolidarity(entity, false);
                    return SolidarityEntity;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                throw;
            }
        }
        #endregion       
    }
}
