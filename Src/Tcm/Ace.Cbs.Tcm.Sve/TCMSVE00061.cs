//----------------------------------------------------------------------
// <copyright file="TLMSVE00061.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-12-10</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;
using Ace.Cbs.Pfm.Ctr.Dao;
using Ace.Cbs.Pfm.Ctr.Sve;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Tel.Ctr.Dao;
using Ace.Windows.Core.Service;
using Spring.Transaction;
using Ace.Windows.CXServer.Utt;
using Spring.Transaction.Interceptor;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Cx.Com.Dto;
using Ace.Cbs.Tcm.Ctr.Sve;
using Ace.Cbs.Cx.Com.Dmd;
using System.Linq;
namespace Ace.Cbs.Tcm.Sve
{
   public class TCMSVE00061:BaseService,ITCMSVE00061
   {
       #region "Properties"
       private ICXDAO00006 codeCheckerDAO { get; set; }
        PFMDTO00017 caofinfoDTO { get; set; }
        private ITLMDAO00001 REDAO { get; set; }
       #endregion

        #region "Methods"
        public IList<TLMDTO00001> SelectPOPrintingList(IList<TLMDTO00001> poLists,int currentUserId)
        {
            IList<TLMDTO00001> POs = poLists;
            for (int i = 0; i < poLists.Count; i++)
            {
                TLMDTO00001 PO = new TLMDTO00001();
                string accountSign = poLists[i].AccountSign;
                string accountNo = poLists[i].ToAccountNo;
                if (accountSign != null)
                {
                    caofinfoDTO = this.SelectTopCustomerInformationByAnyAccountNoandAnyAcSign(accountNo, accountSign);
                    POs[i].Name = caofinfoDTO.Name;
                    POs[i].NRC = caofinfoDTO.NRC;
                    POs[i].ToAddress = caofinfoDTO.Address;
                    POs[i].ToPhoneNo = caofinfoDTO.Township_Code;
                    POs[i].DebitOrCredit = POs[i].Date_Time.Value.Date.ToString("dd-MM-yyyy");
                }
                else
                {
                    PO.Name = string.Empty;
                    POs[i].DebitOrCredit = POs[i].Date_Time.Value.Date.ToString("dd-MM-yyyy");
                }
                
                this.UpdatePrintStatus(POs,currentUserId);               
            }
            return POs;
        }

        [Transaction(TransactionPropagation.Required)]
        private bool UpdatePrintStatus(IList<TLMDTO00001> POLists,int currentUserId)
        {
            bool isUpdate=false;
            try
            {
                for (int i = 0; i < POLists.Count; i++)
                {
                    POLists[i].PrintStatus = (POLists[i].PrintStatus == null) ? 0 : POLists[i].PrintStatus;
                    this.REDAO.UpdatePrintStautsByRegisterNo(POLists[i].RegisterNo, POLists[i].PrintStatus, currentUserId);
                    isUpdate=true;
                }
            }
            catch
            {
                this.ServiceResult.ErrorOccurred = true;
                this.ServiceResult.MessageCode = FXCXMessage.ME90001;
                throw new Exception(this.ServiceResult.MessageCode);
            }
            return isUpdate;            
        }

        private PFMDTO00017 SelectTopCustomerInformationByAnyAccountNoandAnyAcSign(string acccountNo, string accountSign)
        {
            PFMDTO00016 saofinfoDTO = new PFMDTO00016();
            PFMDTO00021 faofinfoDTO = new PFMDTO00021();
            try
            {
                switch (accountSign.Substring(0, 1))
                {
                    case "C": caofinfoDTO = this.codeCheckerDAO.GetTopCAOFInfoByAccountNumber(acccountNo);
                        break;
                    case "S": saofinfoDTO = this.codeCheckerDAO.GetTopSAOFInfoByAccountNumber(acccountNo);
                        caofinfoDTO.Name = saofinfoDTO.Name;
                        caofinfoDTO.NRC = saofinfoDTO.NRC;
                        caofinfoDTO.Address = saofinfoDTO.Address;
                        caofinfoDTO.Township_Code = saofinfoDTO.Township_Code;
                        break;
                    case "F": faofinfoDTO = this.codeCheckerDAO.GetTopFAOFINfoByAccountNumber(acccountNo);
                        caofinfoDTO.Name = faofinfoDTO.Name;
                        caofinfoDTO.NRC = faofinfoDTO.NRC;
                        caofinfoDTO.Address = faofinfoDTO.Address;
                        caofinfoDTO.Township_Code = faofinfoDTO.Township_Code;
                        break;
                    default:
                        caofinfoDTO.Name = string.Empty;
                        break;
                }
            }
            catch
            {

            }
            return caofinfoDTO;
        }
        #endregion
   }
}
