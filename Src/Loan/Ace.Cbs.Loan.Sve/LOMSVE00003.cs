using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Loan.Ctr.Dao;
using Ace.Cbs.Loan.Ctr.Sve;
using Ace.Cbs.Loan.Dmd;
using Ace.Windows.Core.Service;
using Ace.Windows.CXServer.Utt;
using Ace.Windows.Core.Utt;
using Spring.Transaction;
using Spring.Transaction.Interceptor;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Windows.Ix.Core.Ctr;
using Ace.Windows.Core.DataModel;

namespace Ace.Cbs.Loan.Sve
{
    /// <summary>
    /// Customer Character Code Service
    /// </summary>
    public class LOMSVE00003 : BaseService, ILOMSVE00003
    {
        #region Properties

        private ILOMDAO00003 _customercharactercodeDAO;
        public ILOMDAO00003 CustomerCharacterDAO
        {
            get { return this._customercharactercodeDAO; }
            set { this._customercharactercodeDAO = value; }
        }

        private LOMORM00003 CharacterCodeInfo;

        #endregion

        #region OldCode

        //public virtual IList<LOMDTO00001> GetAll()
        //{
        //    return this.CustomerCharacterDAO.SelectAll();
        //}

        //public LOMDTO00001 SelectByCode(string characterCode)
        //{
        //    return this.CustomerCharacterDAO.SelectByCode(characterCode);
        //}

        //public void SaveServerAndServerClient(LOMDTO00001 entity)
        //{
        //    LOMDTO00001 charactercodeEntity = null;


        //    try
        //    {
        //        LOMORM00003 charactercode = this.Save(entity);
        //        if (charactercode != null)
        //            charactercodeEntity = CustomerCharacterDAO.SelectByCode(charactercode.Code);
        //        if (charactercodeEntity != null)
        //        {

        //            Dictionary<string, object> charactercodeKeyPair = new Dictionary<string, object> { { "CharacterCode", charactercodeEntity.Code }, { "CharacterDescription", charactercodeEntity.Description } };
        //            CXServiceWrapper.Instance.Invoke<ICXSVE00001>(x => x.InsertServer("CustomerCharacterCode", charactercodeKeyPair, charactercodeEntity.TS, charactercodeEntity.CreatedUserId, charactercodeEntity.CreatedDate));
        //            this.ServiceResult.ErrorOccurred = false;
        //            this.ServiceResult.MessageCode = "MI90001";// Saving Successful  
        //        }
        //    }

        //    catch
        //    {

        //        this.ServiceResult.ErrorOccurred = true;
        //        if (!string.IsNullOrEmpty(this.ServiceResult.MessageCode))
        //            this.ServiceResult.MessageCode = this.ServiceResult.MessageCode;
        //        else
        //            this.ServiceResult.MessageCode = "ME90036";   //Error Occur!!! Please contact your administrator.
        //    }
        //}

        //[Transaction(TransactionPropagation.Required)]
        //public virtual LOMORM00003 Save(LOMDTO00001 entity)
        //{
        //    LOMORM00003 nationality = null;
        //    try
        //    {
        //        if (this.CustomerCharacterDAO.CheckExist(entity.Code, entity.Description, false))
        //        {
        //            this.ServiceResult.ErrorOccurred = true;
        //            this.ServiceResult.MessageCode = "MV90001";//data already exists                     
        //        }
        //        else
        //        {
        //            nationality = this.CustomerCharacterDAO.Save(this.GetCharacterCode(entity, false));

        //            this.ServiceResult.MessageCode = "MI90001";// Saving Successful
        //            this.SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), entity.CreatedUserId, entity.Code);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        this.ServiceResult.ErrorOccurred = true;
        //        this.ServiceResult.MessageCode = "ME90036";  //Error Occur!!! Please contact your administrator.
        //    }
        //    return nationality;
        //}

        //[Transaction(TransactionPropagation.Required)]
        //public virtual void Update(LOMDTO00001 entity, IList<DataVersionChangedValueDTO> dvcvList)
        //{
        //    try
        //    {
        //        if (this.CustomerCharacterDAO.CheckExist(entity.Code, entity.Description, true))
        //        {
        //            this.ServiceResult.ErrorOccurred = true;
        //            this.ServiceResult.MessageCode = "MV90001";//data already exists
        //        }
        //        else
        //        {
        //            entity.UpdatedDate = DateTime.Now;
        //            entity.UpdatedUserId = entity.CreatedUserId;
        //            LOMORM00003 charactercode = GetCharacterCode(entity, false);
        //            this.CustomerCharacterDAO.Update(charactercode);
        //            Dictionary<string, object> updateColumnsandValues = new Dictionary<string, object> { { "Code", charactercode.Code }, { "Description", charactercode.Description }, { "UpdatedDate", charactercode.UpdatedDate }, { "UpdatedUserId", charactercode.UpdatedUserId } };
        //            Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "Code", charactercode.Code }, { "Active", true } };
        //            CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("LOMORM00003", updateColumnsandValues, whereColumnsandValues));

        //            this.ServiceResult.ErrorOccurred = false;
        //            this.ServiceResult.MessageCode = "MI90002";//Update Success
        //            this.SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.Code);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        this.ServiceResult.ErrorOccurred = true;
        //        this.ServiceResult.MessageCode = "ME90036";
        //    }
        //}

        //[Transaction(TransactionPropagation.Required)]
        //public virtual void Delete(IList<LOMDTO00001> itemList)
        //{
        //    try
        //    {
        //        foreach (LOMDTO00001 item in itemList)
        //        {
             
        //            item.UpdatedUserId = item.UpdatedUserId;
        //            item.UpdatedDate = DateTime.Now;
        //            this.CustomerCharacterDAO.Delete(GetCharacterCode(item, true), false);
        //            this.SaveOrUpdateClientDataVersion(DataAction.Delete, new List<DataVersionChangedValueDTO>(), item.CreatedUserId, item.Code);
        //            CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("LOMORM00003", "Code", item.Code, item.CreatedUserId, item.TS));

        //        }
        //        this.ServiceResult.ErrorOccurred = false;
        //        this.ServiceResult.MessageCode = "MI90003";//Delete Success
        //    }
        //    catch (Exception)
        //    {
        //        this.ServiceResult.ErrorOccurred = true;
        //        this.ServiceResult.MessageCode = "ME90036";  //Error Occur!!! Please contact your administrator.
        //        //throw new Exception(this.ServiceResult.MessageCode);
        //    }
        //}

        #endregion

        #region NewCode
        public virtual IList<LOMDTO00001> GetAll()
        {
            return this.CustomerCharacterDAO.SelectAll();
        }

        public LOMDTO00001 SelectByCode(string characterCode)
        {
            return this.CustomerCharacterDAO.SelectByCode(characterCode);
        }

        public IList<LOMDTO00001> CheckExist2(string characterCode, string desp)
        {
            return this.CustomerCharacterDAO.CheckExist2(characterCode, desp);
        }

        public void SaveServerAndServerClient(LOMDTO00001 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {            
            try
            {
                LOMORM00003 charactercode = this.Save(entity,dvcvList);
                if (charactercode != null)
                {
                    if (!this.ServiceResult.ErrorOccurred)
                    {
                        Dictionary<string, object> charactercodeKeyPair = new Dictionary<string, object> {
                        { "CharacterCode", charactercode.Code },
                        { "CharacterDescription", charactercode.Description } };
                        CXServiceWrapper.Instance.Invoke<ICXSVE00001>(x => x.InsertServer("CustomerCharacterCode", charactercodeKeyPair, charactercode.TS, charactercode.CreatedUserId, charactercode.CreatedDate));
                        this.ServiceResult.ErrorOccurred = false;
                        this.ServiceResult.MessageCode = "MI90001";// Saving Successful  
                    }
                }
            }
            catch
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90036";   //Error Occur!!! Please contact your administrator.
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual LOMORM00003 Save(LOMDTO00001 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            LOMORM00003 CustomerCharacterCode = null;
            if (!entity.Active)  //Active = 0 , update nature
            {
                this.Update(entity, dvcvList, "Save");
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.Code);
                return null;
            }
            else    //Active = 1 , insert nature  
            {
                CustomerCharacterCode = this.CustomerCharacterDAO.Save(this.GetCharacterCode(entity, false));
                this.SaveOrUpdateClientDataVersion(DataAction.Insert, new List<DataVersionChangedValueDTO>(), entity.CreatedUserId, entity.Code);
            }
            return CustomerCharacterCode;
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual void Update(LOMDTO00001 entity, IList<DataVersionChangedValueDTO> dvcvList,string status)
        {
            try
            {
                LOMORM00003 customerCharacterCode = this.UpdateServer(entity, dvcvList);
                if (!this.ServiceResult.ErrorOccurred)
                {   
                    Dictionary<string, object> updateColumnsandValues = new Dictionary<string, object> { 
                    { "Code", customerCharacterCode.Code }, 
                    { "Description", customerCharacterCode.Description },
                    { "Active", customerCharacterCode.Active},
                    { "UpdatedDate", customerCharacterCode.UpdatedDate },
                    { "UpdatedUserId", customerCharacterCode.UpdatedUserId },
                    { "TS",customerCharacterCode.TS }};
                    Dictionary<string, object> whereColumnsandValues = new Dictionary<string, object> { { "Code", customerCharacterCode.Code } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Update("LOMORM00003", updateColumnsandValues, whereColumnsandValues));
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
        public virtual LOMORM00003 UpdateServer(LOMDTO00001 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            LOMORM00003 customerCharacterCodeEntity = null;

            if (this.CustomerCharacterDAO.CheckExist(entity.Code, entity.Description, true))
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "MV90001";//data already exists
            }
            else
            {
                customerCharacterCodeEntity = this.CustomerCharacterDAO.Update(this.GetCharacterCode(entity, false));
                SaveOrUpdateClientDataVersion(DataAction.Update, dvcvList, entity.CreatedUserId, entity.Code);
            }
            return customerCharacterCodeEntity;
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual void Delete(IList<LOMDTO00001> itemList)
        {
            try
            {
                foreach (LOMDTO00001 item in itemList)
                {
                    LOMORM00003 deletedEntity = this.DeleteServer(item);                         
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("LOMORM00003", "Code", item.Code, item.CreatedUserId, item.TS));
                }
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "MI90003";//Delete Success
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90036";  //Error Occur!!! Please contact your administrator.
                throw new Exception(this.ServiceResult.MessageCode);
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual LOMORM00003 DeleteServer(LOMDTO00001 customerCharacterCodeDTO)
        {
            LOMORM00003 customerCharacterCode = this.GetCharacterCode(customerCharacterCodeDTO, true);
            LOMORM00003 deletedEntity = this.CustomerCharacterDAO.Delete(customerCharacterCode, false);
            SaveOrUpdateClientDataVersion(DataAction.Delete, new List<DataVersionChangedValueDTO>(), customerCharacterCodeDTO.CreatedUserId, customerCharacterCodeDTO.Code);
            return deletedEntity;
        }
        #endregion

        #region Helper Method

        private LOMORM00003 GetCharacterCode(LOMDTO00001 characterCodeDTO, bool isDelete)
        {
            CharacterCodeInfo = new LOMORM00003();

            CharacterCodeInfo.Code = characterCodeDTO.Code;
            CharacterCodeInfo.Description = characterCodeDTO.Description;

            CharacterCodeInfo.TS = characterCodeDTO.TS;
            CharacterCodeInfo.CreatedUserId = characterCodeDTO.CreatedUserId;
            CharacterCodeInfo.CreatedDate = DateTime.Now;
            CharacterCodeInfo.UpdatedUserId = characterCodeDTO.UpdatedUserId;
            CharacterCodeInfo.UpdatedDate = DateTime.Now;

            if (isDelete)
                CharacterCodeInfo.Active = false;
            else
                CharacterCodeInfo.Active = true;

            return CharacterCodeInfo;
        }


        #endregion

        #region Data Version Update Service
        public void SaveOrUpdateClientDataVersion(DataAction dataAction, IList<DataVersionChangedValueDTO> dvcvList, int createdUserId, string dataValueId)
        {
            ClientDataVersionDTO clientDataVersionDTO = new ClientDataVersionDTO();
            LOMORM00003 BusinessCodeORM = new LOMORM00003();

            //Require Data
            clientDataVersionDTO.ORMObjectName = BusinessCodeORM;
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
