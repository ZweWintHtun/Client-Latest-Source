// <CreatedUser>KSW</CreatedUser>
// <CreatedDate>08/04/2013</CreatedDate>
// <UpdatedUser>Nyo Me San</UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Cbs.Sam.Ctr.Sve;
using Ace.Cbs.Tel.Dmd;
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
    public class SAMSVE00025 : BaseService, ISAMSVE00025
    {
        #region Properties

        private ITLMDAO00029 remitBrIblDAO;
        public ITLMDAO00029 RemitBrIblDAO
        {
            get { return this.remitBrIblDAO; }
            set { this.remitBrIblDAO = value; }
        }

        private ITLMDAO00030 iblDwtRateDAO;
        public ITLMDAO00030 IblDwtRateDAO
        {
            get { return this.iblDwtRateDAO; }
            set { this.iblDwtRateDAO = value; }
        }

        private TLMORM00029 RemitBrIblInfo;
        private TLMORM00030 RmitIblRateInfo;

        #endregion

        #region Helper Methods

        private TLMORM00029 GetRemitBr(TLMDTO00029 remitBrDTO)
        {
            RemitBrIblInfo = new TLMORM00029();
            RemitBrIblInfo.Id = remitBrDTO.Id;
            RemitBrIblInfo.BranchCode = remitBrDTO.BranchCode;
            RemitBrIblInfo.TelaxCharges = remitBrDTO.TelaxCharges;
            RemitBrIblInfo.TTSerial = remitBrDTO.TTSerial;
            RemitBrIblInfo.DraftSerial = remitBrDTO.DraftSerial;
            RemitBrIblInfo.StateCode = remitBrDTO.StateCode;
            RemitBrIblInfo.DrawingAccount = remitBrDTO.DrawingAccount;
            RemitBrIblInfo.EncashAccount = remitBrDTO.EncashAccount;
            RemitBrIblInfo.IBSComAccount = remitBrDTO.IBSComAccount;
            RemitBrIblInfo.TelaxAccount = remitBrDTO.TelaxAccount;
            RemitBrIblInfo.IblSerial = remitBrDTO.IblSerial;
            RemitBrIblInfo.IRPOAccount = remitBrDTO.IRPOAccount;
            RemitBrIblInfo.UniqueIdentifier = remitBrDTO.UniqueIdentifier;
            RemitBrIblInfo.SourceBranchCode = remitBrDTO.SourceBranchCode;
            RemitBrIblInfo.Currency = remitBrDTO.Currency;
            RemitBrIblInfo.CreatedUserId = remitBrDTO.CreatedUserId;
            RemitBrIblInfo.CreatedDate = DateTime.Now;
            RemitBrIblInfo.Active = true;

            return RemitBrIblInfo;
        }

        private TLMORM00030 GetRmitRate(TLMDTO00030 rmitRateDTO, int id)
        {
            RmitIblRateInfo = new TLMORM00030();
            RmitIblRateInfo.Id = rmitRateDTO.Id;
            RmitIblRateInfo.RemitbrIblID = id;
            RmitIblRateInfo.BranchCode = rmitRateDTO.BranchCode;
            RmitIblRateInfo.StartNo = rmitRateDTO.StartNo;
            RmitIblRateInfo.EndNo = rmitRateDTO.EndNo;
            RmitIblRateInfo.Rate = rmitRateDTO.Rate;
            RmitIblRateInfo.FixAmount = rmitRateDTO.FixAmount;
            RmitIblRateInfo.Discount = rmitRateDTO.Discount;
            RmitIblRateInfo.TrDiscount = rmitRateDTO.TrDiscount;
            RmitIblRateInfo.CsDiscount = rmitRateDTO.CsDiscount;
            RmitIblRateInfo.CsMinRate = rmitRateDTO.CsMinRate;
            RmitIblRateInfo.MinRate = rmitRateDTO.MinRate;
            RmitIblRateInfo.UniqueId = rmitRateDTO.UniqueId;
            RmitIblRateInfo.SourceBranchCode = rmitRateDTO.SourceBranchCode;
            RmitIblRateInfo.Currency = rmitRateDTO.Currency;
            RmitIblRateInfo.CreatedUserId = rmitRateDTO.CreatedUserId;
            RmitIblRateInfo.CreatedDate = DateTime.Now;
            RmitIblRateInfo.Active = true;
            return RmitIblRateInfo;
        }

        #endregion

        #region Main Methods

        public TLMDTO00029 SelectById(string currency, string branchCode, string sourceBranch)
        {
            return this.RemitBrIblDAO.SelectByCode(currency, branchCode, sourceBranch);
        }

        public IList<TLMDTO00030> SelectItemlistById(int id)
        {
            return this.IblDwtRateDAO.SelectById(id);
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual TLMORM00029 SaveRemitBranchIBL(TLMDTO00029 entity, IList<DataVersionChangedValueDTO> dvcvList)
        {
            try
            {
                int oldId = 0;
                bool isDelete = false;
                if (this.remitBrIblDAO.CheckExist(0, entity.BranchCode, entity.SourceBranchCode, entity.Currency))
                {
                    oldId = entity.Id;
                    isDelete = true;
                }
                TLMORM00029 remitBrIblInfo = null;
                TLMDTO00029 remitBrIblInfoEntity = null;
                remitBrIblInfo = this.remitBrIblDAO.Save(this.GetRemitBr(entity));

                remitBrIblInfoEntity = this.RemitBrIblDAO.SelectById(remitBrIblInfo.Id, remitBrIblInfo.SourceBranchCode);


                //   this.RemitBrIblDAO.se(remitBrIblInfo.co)

                this.SaveOrUpdateClientDataVersionForRemitBrIbl(DataAction.Insert, dvcvList, entity.CreatedUserId, RemitBrIblInfo.Id.ToString());
                Dictionary<string, object> remitbriblKeyPair = new Dictionary<string, object> { { "Id", remitBrIblInfoEntity.Id }, { "BranchCode", remitBrIblInfoEntity.BranchCode }, { "TlxCharges", remitBrIblInfoEntity.TelaxCharges }, { "TTSerial", remitBrIblInfoEntity.TTSerial }, { "DrftSerial", remitBrIblInfoEntity.DraftSerial }, { "SourceBr", remitBrIblInfoEntity.SourceBranchCode }, { "Cur", remitBrIblInfoEntity.Currency }, { "DrawAc", remitBrIblInfoEntity.DrawingAccount }, { "EncashAc", remitBrIblInfoEntity.EncashAccount }, { "IBSComAc", remitBrIblInfoEntity.IBSComAccount }, { "TelexAc", remitBrIblInfoEntity.TelaxAccount }, { "IRPOAC", remitBrIblInfoEntity.IRPOAccount } };
                CXServiceWrapper.Instance.Invoke<ICXSVE00001>(x => x.InsertServer("RemitBrIbl", remitbriblKeyPair, remitBrIblInfoEntity.TS, remitBrIblInfoEntity.CreatedUserId, remitBrIblInfoEntity.CreatedDate));
                return RemitBrIblInfo;
            }
            catch
            { return null; }
        }

      
        public void SaveServerAndServerClient(TLMDTO00029 entity, IList<TLMDTO00030> itemList, IList<DataVersionChangedValueDTO> dvcvList)
        {
            int oldId = 0;
            bool isDelete = false;
            if (this.remitBrIblDAO.CheckExist(0, entity.BranchCode, entity.SourceBranchCode, entity.Currency))
            {
                oldId = entity.Id;
                isDelete = true;
            }
            TLMORM00029 remitbrIBL = this.SaveRemitBranchIBL(entity, dvcvList);
            if (remitbrIBL != null)
            {
                foreach (TLMDTO00030 item in itemList)
                {
                    //IList<TLMDTO00030> iblDwtRateEntityList = null;
                    TLMORM00030 iblDwtRate = this.iblDwtRateDAO.Save(this.GetRmitRate(item, RemitBrIblInfo.Id));
                    TLMDTO00030 data = this.iblDwtRateDAO.SelectByIdForSaveAppServer(iblDwtRate.Id);
                    this.SaveOrUpdateClientDataVersionForRemitBrIbl(DataAction.Insert, dvcvList, iblDwtRate.CreatedUserId, iblDwtRate.Id.ToString());
                    Dictionary<string, object> remitbriblKeyPair = new Dictionary<string, object> { { "Id", data.Id }, { "RemitbrIblID", data.RemitbrIblID }, { "BranchCode", data.BranchCode }, { "StartNo", data.StartNo }, { "EndNo", data.EndNo }, { "Rate", data.Rate }, { "FixAmt", data.FixAmount }, { "Discount", data.Discount }, { "TRDiscount", data.TrDiscount }, { "CSDiscount", data.CsDiscount }, { "CSMinRate", data.CsMinRate }, { "MinRate", data.MinRate }, { "UID", data.UniqueId }, { "SourceBr", data.SourceBranchCode }, { "Cur", data.Currency } };
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001>(x => x.InsertServer("IblDwtRate", remitbriblKeyPair, data.TS, data.CreatedUserId, data.CreatedDate));
                    this.ServiceResult.ErrorOccurred = false;
                    this.ServiceResult.MessageCode = "MI90001";// Saving Successful
                    //for (int i = 0; i < iblDwtRateEntityList.Count; i++)
                    //{
                    //    Dictionary<string, object> remitbriblKeyPair = new Dictionary<string, object> { { "Id", iblDwtRateEntityList[i].Id }, { " RemitbrIblID", iblDwtRateEntityList[i].RemitbrIblID }, { "BranchCode", iblDwtRateEntityList[i].BranchCode }, { "StartNo", iblDwtRateEntityList[i].StartNo }, { "EndNo", iblDwtRateEntityList[i].EndNo }, { "Rate", iblDwtRateEntityList[i].Rate }, { "FixAmt", iblDwtRateEntityList[i].FixAmount }, { "Discount", iblDwtRateEntityList[i].Discount }, { "TRDiscount", iblDwtRateEntityList[i].TrDiscount }, { "CSDiscount", iblDwtRateEntityList[i].CsDiscount }, { "CSMinRate", iblDwtRateEntityList[i].CsMinRate }, { "MinRate", iblDwtRateEntityList[i].MinRate }, { "UID", iblDwtRateEntityList[i].UniqueId }, { "SourceBr", iblDwtRateEntityList[i].SourceBranchCode }, { "Cur", iblDwtRateEntityList[i].Currency } };
                    //    CXServiceWrapper.Instance.Invoke<ICXSVE00001>(x => x.InsertServer("IblDwtRate", remitbriblKeyPair, iblDwtRateEntityList[i].TS, iblDwtRateEntityList[i].CreatedUserId, iblDwtRateEntityList[i].CreatedDate));
                    //    this.ServiceResult.ErrorOccurred = false;
                    //    this.ServiceResult.MessageCode = "MI90001";// Saving Successful 
                    //}                       
                }
            }
            else
                throw new Exception("ME90036");

            if (isDelete)
            {
                TLMDTO00029 deleteEntity = new TLMDTO00029();
                deleteEntity.Status = "Update";
                deleteEntity.Id = oldId;
                deleteEntity.CreatedUserId = entity.CreatedUserId;
                this.Delete(deleteEntity);
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "MI90002";
                // this.Delete(deleteEntity);
            }
        }

       [Transaction(TransactionPropagation.Required)]
        public virtual void Delete(TLMDTO00029 item)
        {
            try
            {
                item.Status = string.Empty;
                if (this.remitBrIblDAO.DeleteById(item.Id, item.CreatedUserId))
                {
                    this.SaveOrUpdateClientDataVersionForRemitBrIbl(DataAction.Delete, new List<DataVersionChangedValueDTO>(), item.CreatedUserId, item.Id.ToString());
                    string deleteId = item.Id.ToString();
                    TLMORM00029 remitbribl =  this.RemitBrIblDAO.Get(item.Id);
                    CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("TLMORM00029", "Id", deleteId, remitbribl.CreatedUserId, remitbribl.TS));
                    IList<TLMDTO00030> iblDwtRateList = this.iblDwtRateDAO.SelectById(item.Id);
                    if (this.iblDwtRateDAO.DeleteById(item.Id, item.CreatedUserId))
                    {
                        foreach (TLMDTO00030 data in iblDwtRateList)
                        {
                            string delId = data.Id.ToString();
                            this.SaveOrUpdateClientDataVersionForRemitBrIbl(DataAction.Delete, new List<DataVersionChangedValueDTO>(), item.CreatedUserId, data.Id.ToString());
                            TLMORM00030 iblDwt = this.iblDwtRateDAO.Get(data.Id);
                            CXServiceWrapper.Instance.Invoke<ICXSVE00001, bool>(x => x.Delete("TLMORM00030", "Id", delId, item.CreatedUserId,iblDwt.TS));
                        }

                    }
                    if (string.IsNullOrEmpty(item.Status))
                    {
                        this.ServiceResult.ErrorOccurred = false;
                        this.ServiceResult.MessageCode = "MI90003";//Delete Success
                    }

                }
                else
                    throw new Exception("ME90036");


            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90036";
                throw new Exception(this.ServiceResult.MessageCode);
            }
        }
      
      
        public void SaveOrUpdateClientDataVersionForRemitBrIbl(DataAction dataAction, IList<DataVersionChangedValueDTO> dvcvList, int createdUserId, string dataValueId)
        {
            ClientDataVersionDTO clientDataVersionDTO = new ClientDataVersionDTO();
            TLMORM00029 RemitBrIblORM = new TLMORM00029();

            //Require Data
            clientDataVersionDTO.ORMObjectName = RemitBrIblORM;
            clientDataVersionDTO.DataIdValue = dataValueId;
            //clientDataVersionDTO.DataIdValue = GlobalUtilities.ConvertClassPropertyToString(() => RemitBrIblORM.Id);
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
