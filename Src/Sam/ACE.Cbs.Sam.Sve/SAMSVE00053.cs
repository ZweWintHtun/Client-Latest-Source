//----------------------------------------------------------------------
// <copyright file="SAMSVE00053.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser></CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser>Nyo Me San</UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Sam.Ctr.Dao;
using Ace.Cbs.Sam.Ctr.Sve;
using Ace.Cbs.Sam.Dmd;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer.Utt;
using Ace.Windows.Core.Utt;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Ix.Core.Ctr;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Sam.Sve
{
    /// <summary>
    /// Nationality Code Service
    /// </summary>
    public class SAMSVE00053 : BaseService, ISAMSVE00053
    {
        #region Properties

        private ISAMDAO00053 _nationalityCodeDAO;
        public ISAMDAO00053 NationalityCodeDAO
        {
            get { return this._nationalityCodeDAO; }
            set { this._nationalityCodeDAO = value; }
        }

        private SAMORM00053 NationalityCodeInfo;

        #endregion

        #region Helper Method

        private SAMORM00053 GetNationalityCode(SAMDTO00053 nationalityCodeDTO, bool isDelete)
        {
            NationalityCodeInfo = new SAMORM00053();

            NationalityCodeInfo.Nationality_Code = nationalityCodeDTO.Nationality_Code;
            NationalityCodeInfo.Description = nationalityCodeDTO.Description;
            NationalityCodeInfo.Date_Time = DateTime.Now;
            NationalityCodeInfo.UserNo = nationalityCodeDTO.UserNo;
            NationalityCodeInfo.TS = nationalityCodeDTO.TS;
            NationalityCodeInfo.CreatedUserId = nationalityCodeDTO.CreatedUserId;
            NationalityCodeInfo.CreatedDate = DateTime.Now;
            NationalityCodeInfo.UpdatedUserId = nationalityCodeDTO.UpdatedUserId;
            NationalityCodeInfo.UpdatedDate = DateTime.Now;

            if (isDelete)
                NationalityCodeInfo.Active = false;
            else
                NationalityCodeInfo.Active = true;
            return NationalityCodeInfo;
        }


        #endregion

        #region Main Methods

        public virtual IList<SAMDTO00053> GetAll()
        {
            return this.NationalityCodeDAO.SelectAll();
        }

        public SAMDTO00053 SelectByNationalityCode(string nationalityCode)
        {
            return this.NationalityCodeDAO.SelectByNationalityCode(nationalityCode);
        }

        public IList<SAMDTO00053> CheckExist2(string nationalityCode, string desp)
        {
            return this.NationalityCodeDAO.CheckExist2(nationalityCode, desp);
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual SAMORM00053 Save(SAMDTO00053 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            SAMORM00053 nationality = null;
            try
            {
                if (!entity.Active)  //Active = 0 , update nature
                {
                    this.Update(entity, dvcvList, "Save");
                    SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.Nationality_Code);
                    return null;
                }
                else //Active = 1 , insert nature
                {
                    nationality = this.NationalityCodeDAO.Save(this.GetNationalityCode(entity, false));
                    this.ServiceResult.ErrorOccurred = false;
                    this.ServiceResult.MessageCode = "MI90001";// Saving Successful
                    this.SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), entity.CreatedUserId, entity.Nationality_Code);
                }
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90036";
            }
            return nationality;
        }

        public void SaveServerAndServerClient(SAMDTO00053 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {            
            try
            {
                SAMORM00053 nationality = this.Save(entity, dvcvList);
                if (nationality != null)
                {
                    if (!this.ServiceResult.ErrorOccurred)
                    {
                        Dictionary<string, object> nationalityKeyPair = new Dictionary<string, object> 
                        { 
                            { "NationalityCode", nationality.Nationality_Code }, 
                            { "Desp", nationality.Description }, 
                            { "UserNo", nationality.UserNo }, 
                            { "Date_Time", DateTime.Now } 
                        };
                        CXServiceWrapper.Instance.Invoke<ICXSVE00001>(x => x.InsertServer("NationalityCode", nationalityKeyPair, nationality.TS, nationality.CreatedUserId, nationality.CreatedDate));
                        this.ServiceResult.ErrorOccurred = false;
                        this.ServiceResult.MessageCode = "MI90001";// Saving Successful  
                    }
                }
            }
            catch
            {                
                this.ServiceResult.ErrorOccurred = true;               
                this.ServiceResult.MessageCode = "ME90036";
            }

        }

        [Transaction(TransactionPropagation.Required)]
        public virtual SAMORM00053 UpdateServer(SAMDTO00053 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            SAMORM00053 nationalitycode = null;          
            if (this.NationalityCodeDAO.CheckExist(entity.Nationality_Code, entity.Description, true))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV90001";//data already exists
            }
            else
            {
                nationalitycode = this.NationalityCodeDAO.Update(GetNationalityCode(entity, false));                              
                this.SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.Nationality_Code);                   
            }
            return nationalitycode;           
        }

        public virtual void Update(SAMDTO00053 entity, IList<DataVersionChangedValueDTO> dvcvList, string status)
        {
            try
            {      
                SAMORM00053 nationalitycode = UpdateServer(entity,dvcvList);
                if (!this.ServiceResult.ErrorOccurred)
                {                   
                    Dictionary<string, object> updateColumnsandValues = new Dictionary<string, object> { 
                    { "Nationality_Code", nationalitycode.Nationality_Code },
                    { "Description", nationalitycode.Description }, 
                    { "Active", nationalitycode.Active},
                    { "UpdatedUserId", nationalitycode.UpdatedUserId }, 
                    { "UpdatedDate", DateTime.Now },
                    {"TS",nationalitycode.TS}
                    };
                    Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "Nationality_Code", nationalitycode.Nationality_Code }};
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("SAMORM00053", updateColumnsandValues, whereColumnsandValues));
                    this.ServiceResult.ErrorOccurred = false;
                    if (status == "Update")
                        this.ServiceResult.MessageCode = "MI90002";//Update Success   
                    else
                        this.ServiceResult.MessageCode = "MI90001";//Saving Successful   
                }
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90036";
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual SAMORM00053 DeleteServer(SAMDTO00053 nationalityDTO)
        {
            SAMORM00053 nationality = this.NationalityCodeDAO.Delete(GetNationalityCode(nationalityDTO,true), false);
            this.SaveOrUpdateClientDataVersion(DataAction.Delete, new List<DataVersionChangedValueDTO>(), nationalityDTO.CreatedUserId, nationalityDTO.Nationality_Code);
            return nationality;
        }

        public virtual void Delete(IList<SAMDTO00053> itemList)
        {
            try
            {
                foreach (SAMDTO00053 item in itemList)
                {
                   SAMORM00053 nationality =  DeleteServer(item);
                   CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("SAMORM00053", "Nationality_Code", nationality.Nationality_Code, nationality.CreatedUserId,nationality.TS));
                }
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "MI90003";//Delete Success
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90036";
                throw new Exception(this.ServiceResult.MessageCode);
            }
        }

        public void SaveOrUpdateClientDataVersion(DataAction dataAction, IList<DataVersionChangedValueDTO> dvcvList, int createdUserId, string dataValueId)
        {
            ClientDataVersionDTO clientDataVersionDTO = new ClientDataVersionDTO();
            SAMORM00053 OccupationCodeORM = new SAMORM00053();

            //Require Data
            clientDataVersionDTO.ORMObjectName = OccupationCodeORM;
            clientDataVersionDTO.DataIdValue = dataValueId;
            clientDataVersionDTO.CreatedUserId = createdUserId;

            //ChangedDataContents
            IList<ChangeDataContent> cdclist = new List<ChangeDataContent>();
            foreach (DataVersionChangedValueDTO dvcvdto in dvcvList)
            {
                ChangeDataContent cdcdto = new ChangeDataContent();
                cdcdto.Property = dvcvdto.OrmPropertyName;
                cdcdto.OldValue = dvcvdto.OrmPreviousValue;
                cdcdto.NewValue = dvcvdto.OrmNewValue;
                cdclist.Add(cdcdto);
            }
            clientDataVersionDTO.ChangeDataContentList = cdclist;
            CXServiceWrapper.Instance.Invoke<IDataVersionUpdateService, bool>(x => x.SaveOrUpdateClientDataVersion(clientDataVersionDTO, dataAction));
        }

        #endregion

    }
}
