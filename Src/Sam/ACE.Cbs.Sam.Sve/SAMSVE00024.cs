// <copyright file="SAMSVE00024.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>KSW</CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser>Nyo Me San</UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Sam.Ctr.Dao;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Sam.Ctr.Sve;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer.Utt;
using Ace.Windows.Core.Utt;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Windows.Admin.DataModel;
using Ace.Windows.Ix.Core.Ctr;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Core.DataModel;


namespace Ace.Cbs.Sam.Sve
{
    /// <summary>
    /// Denomination Entry Service
    /// </summary>
    public class SAMSVE00024 : BaseService, ISAMSVE00024
    {
        #region Properties

        private ITLMDAO00012 denoDAO;
        public ITLMDAO00012 DenoDAO
        {
            get { return this.denoDAO; }
            set { this.denoDAO = value; }
        }

        private TLMORM00012 DenoInfo;

        #endregion    

        #region Helper Method

        private TLMORM00012 GetDeno(TLMDTO00012 denoDTO, bool isDelete)
        {
            DenoInfo = new TLMORM00012();
            DenoInfo.Id = denoDTO.Id;
            DenoInfo.Description = denoDTO.Description;
            DenoInfo.D1 = denoDTO.D1;
            DenoInfo.D2 = denoDTO.D2;
            DenoInfo.UId = denoDTO.UID;
            DenoInfo.Currency = denoDTO.Currency;
            DenoInfo.Symbol = denoDTO.Symbol;
            DenoInfo.TS = denoDTO.TS;
            DenoInfo.CreatedUserId = denoDTO.CreatedUserId;
            DenoInfo.CreatedDate = DateTime.Now;
            DenoInfo.UpdatedUserId = denoDTO.UpdatedUserId;
            DenoInfo.UpdatedDate = DateTime.Now;
            if (isDelete)
                DenoInfo.Active = false;
            else
                DenoInfo.Active = true;
            return DenoInfo;
        }

        #endregion

        #region Logical Methods

        public virtual IList<TLMDTO00012> GetAll()
        {
            return this.DenoDAO.SelectAll();
        }

        public TLMDTO00012 SelectById(int id)
        {
            return this.DenoDAO.SelectById(id);
        }


        public IList<CurrencyDTO> GetCur()
        {
            return null;
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual TLMORM00012 Save(TLMDTO00012 entity)
        {
            TLMORM00012 deno = null;            
            if (this.denoDAO.CheckExistForSave(0, entity.Description, entity.Symbol))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV90001";//data already exists                     
            }               
            else
            {
                    deno = this.denoDAO.Save(this.GetDeno(entity, false));                   
                SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), deno.CreatedUserId, deno.Id.ToString());
            }           
            return deno;
        }

        public void SaveServerAndServerClient(TLMDTO00012 entity)
        {         
            try
            {
                TLMORM00012 deno = this.Save(entity);
                if (!this.ServiceResult.ErrorOccurred)
                {
                    Dictionary<string, object> accounttypeKeyPair = new Dictionary<string, object> {
                    { "Id", deno.Id },
                    { "Desp", deno.Description },
                    { "D1", deno.D1 }, 
                    { "D2", deno.D2 },
                    { "Cur", deno.Currency },
                    { "Symbol", deno.Symbol } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001>(x => x.InsertServer("Deno", accounttypeKeyPair, deno.TS, deno.CreatedUserId, deno.CreatedDate));
                    this.ServiceResult.ErrorOccurred = false;
                    this.ServiceResult.MessageCode = "MI90001";// Saving Successful  
                }
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;                
                this.ServiceResult.MessageCode = "ME90036";
            }

        }

        [Transaction(TransactionPropagation.Required)]
        public virtual TLMORM00012 UpdateServer(TLMDTO00012 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            TLMORM00012 deno = null;
            if (this.denoDAO.CheckExistForUpdate(entity.Id, entity.Description, entity.Symbol))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV90001";//data already exists
            }
            else
            {
                deno = this.denoDAO.Update(GetDeno(entity,false));
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.Id.ToString());
            }
            return deno;
        }

        public virtual void Update(TLMDTO00012 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            try
            {
                TLMORM00012 deno = this.UpdateServer(entity,dvcvList);               
                if(!this.ServiceResult.ErrorOccurred)
                {  
                    Dictionary<string, object> updateColumnsandValues = new Dictionary<string, object> {
                    { "Currency", deno.Currency }, 
                    { "Description", deno.Description }, 
                    { "D1", deno.D1 }, 
                    { "D2", deno.D2 },
                    { "Symbol", deno.Symbol }, 
                    { "UpdatedUserId", deno.UpdatedUserId }, 
                    { "UpdatedDate", DateTime.Now } ,
                    {"TS",deno.TS}
                    };
                    Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "Id", deno.Id }, { "Active", true } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("TLMORM00012", updateColumnsandValues, whereColumnsandValues));

                    this.ServiceResult.ErrorOccurred = false;
                    this.ServiceResult.MessageCode = "MI90002";//Update Success
               }
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90036";
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual TLMORM00012 DeleteServer(TLMDTO00012 denoDTO)
        {
           TLMORM00012 deno = this.denoDAO.Delete(GetDeno(denoDTO,true), false);
           SaveOrUpdateClientDataVersion(DataAction.Delete, new List<DataVersionChangedValueDTO>(), denoDTO.CreatedUserId, denoDTO.Id.ToString());
           return deno;                  
        }

        public virtual void Delete(IList<TLMDTO00012> itemList)
        {
            try
            {
                foreach (TLMDTO00012 item in itemList)
                {
                   TLMORM00012 deno = DeleteServer(item);
                    string id = deno.Id.ToString();
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("TLMORM00012", "Id", id, deno.CreatedUserId, deno.TS));
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

        #endregion

      

        #region Data Version Update Service
        public void SaveOrUpdateClientDataVersion(DataAction dataAction, IList<DataVersionChangedValueDTO> dvcvList, int createdUserId,string dataValueId)
        {
            ClientDataVersionDTO clientDataVersionDTO = new ClientDataVersionDTO();
            TLMORM00012 DenoInfoORM = new TLMORM00012();

            //Require Data
            clientDataVersionDTO.ORMObjectName = DenoInfoORM;
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