//----------------------------------------------------------------------
// <copyright file="SAMSVE00020.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hay Mar</CreatedUser>
// <CreatedDate>08/05/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
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

namespace Ace.Cbs.Sam.Sve
{
    /// <summary>
    /// SERVERLOG Service
    /// </summary>
	public class SAMSVE00020:BaseService,ISAMSVE00020
  	{
		#region Properties

        private ITLMDAO00027 sERVERLOGDAO;
        public ITLMDAO00027 SERVERLOGDAO
        {
            get { return this.sERVERLOGDAO; }
            set { this.sERVERLOGDAO = value; }
        }
		
		private TLMORM00027 SERVERLOGInfo;
		
		#endregion
		
		#region Logical Methods

        public virtual IList<TLMDTO00027> GetAll()
        {
            return this.SERVERLOGDAO.SelectAll();
        }

        public TLMDTO00027 SelectById(int id)
        {
            return this.SERVERLOGDAO.SelectById(id);
        }
		
		[Transaction(TransactionPropagation.Required)]
        public virtual void Save(TLMDTO00027 entity)
        {
            try
            {
                if (this.sERVERLOGDAO.CheckExist(0,entity.BRANCHNO,entity.IPADDRESS))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MV90001";//data already exists                     
                }
                else
                {
                    this.sERVERLOGDAO.Save(this.GetSERVERLOG(entity,false));
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
        public virtual void Update(TLMDTO00027 entity)
        {
            try
            {
                if (this.sERVERLOGDAO.CheckExist(entity.Id,entity.BRANCHNO ,entity.IPADDRESS))
                {
                    this.ServiceResult.ErrorOccurred = true;
                    this.ServiceResult.MessageCode = "MV90001";//data already exists
                }
                else
                {   
					entity.UpdatedDate = DateTime.Now;
                    this.sERVERLOGDAO.Update(GetSERVERLOG(entity,false));
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
        public virtual void Delete(IList<TLMDTO00027> itemList)
        {
            try
            {
                foreach (TLMDTO00027 item in itemList)
                {
                    //item.UpdatedUserId = CurrentUserEntity.CurrentUserID;
                    item.UpdatedUserId = item.UpdatedUserId;
                    item.UpdatedDate = DateTime.Now;
                    this.sERVERLOGDAO.Delete(GetSERVERLOG(item,true),false);
                } 
                this.ServiceResult.ErrorOccurred = false;
                this.ServiceResult.MessageCode = "MI90003";//Delete Success
            }
            catch (Exception)
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = "ME90036";
            }
        }
		
		#endregion
		
		#region Helper Method

        private TLMORM00027 GetSERVERLOG(TLMDTO00027 sERVERLOGDTO, bool isDelete)
        {
            SERVERLOGInfo = new TLMORM00027();
			
			SERVERLOGInfo.Id = sERVERLOGDTO.Id;   
			SERVERLOGInfo.BranchNo = sERVERLOGDTO.BRANCHNO;   
			SERVERLOGInfo.ServerName = sERVERLOGDTO.SERVERNAME;   
			SERVERLOGInfo.DbName = sERVERLOGDTO.DBNAME;   
			SERVERLOGInfo.IPAddress = sERVERLOGDTO.IPADDRESS;   
			SERVERLOGInfo.UserName = sERVERLOGDTO.USERNAME;   
			SERVERLOGInfo.Password = sERVERLOGDTO.PASSWORD;   
			SERVERLOGInfo.ISPName = sERVERLOGDTO.ISPNAME;   
			SERVERLOGInfo.UniqueId = sERVERLOGDTO.UID;   
            //SERVERLOGInfo.IBDIPAddress = sERVERLOGDTO.IBDIPADDRESS;   
			SERVERLOGInfo.Version = sERVERLOGDTO.VERSION;   
			SERVERLOGInfo.TS = sERVERLOGDTO.TS;
            //SERVERLOGInfo.CreatedUserId = CurrentUserEntity.CurrentUserID;
            SERVERLOGInfo.CreatedUserId = sERVERLOGDTO.CreatedUserId;
            SERVERLOGInfo.CreatedDate = DateTime.Now;
            //SERVERLOGInfo.UpdatedUserId = CurrentUserEntity.CurrentUserID;
            SERVERLOGInfo.UpdatedUserId = sERVERLOGDTO.UpdatedUserId;
            SERVERLOGInfo.UpdatedDate = DateTime.Now;
			
			if(isDelete)
				SERVERLOGInfo.Active=false;
			else
				SERVERLOGInfo.Active=true;
					
            return SERVERLOGInfo;
        }
		
		#endregion
		
	}	
}
