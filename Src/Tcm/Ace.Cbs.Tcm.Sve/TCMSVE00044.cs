//----------------------------------------------------------------------
// <copyright file="TLMSVE00044.cs" company="ACE Data Systems">
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
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Tcm.Sve
{
    /// <summary>
    /// PO Printing Service
    /// </summary>
   public class TCMSVE00044:BaseService,ITCMSVE00044
   {
       #region "DAO"
       public ITLMDAO00001 REDAO { get; set; }
       //private ICXDAO00006 codeCheckerDAO { get; set; }
       //PFMDTO00017 caofinfoDTO { get; set; }
       #endregion

       #region "Methods"
       public IList<TLMDTO00001> SelectREDTOListForPOPrinting(DateTime requiredDate, string sourcebranchCode)
       {int i=0;
           IList<TLMDTO00001> REDTOList = new List<TLMDTO00001>();
           REDTOList = this.REDAO.SelectREDTOListForPOPrinting(requiredDate, sourcebranchCode);
           while (i != REDTOList.Count)
           {
               REDTOList[i].Ebank = CXCOM00011.Instance.GetScalarObject<BranchDTO>("Branch.Server.CityCode.Select", new object[] { REDTOList[i].Ebank,true }).BranchAlias;
               i++;
           }
           return REDTOList;
       }

       //public IList<TLMDTO00001> SelectPOPrintingList(IList<TLMDTO00001> poLists)
       //{
       //    IList<TLMDTO00001> POs = new List<TLMDTO00001>();
       //    for (int i = 0; i < poLists.Count; i++)
       //    {
       //        TLMDTO00001 PO = new TLMDTO00001();
       //        string accountSign=poLists[i].AccountSign;
       //        string accountNo=poLists[i].AccountNo;
       //        caofinfoDTO = this.SelectTopCustomerInformationByAnyAccountNoandAnyAcSign(accountNo, accountSign);
       //        PO.Name = caofinfoDTO.Name;
       //        PO.NRC = caofinfoDTO.NRC;
       //        PO.ToAddress = caofinfoDTO.Address;
       //        PO.ToPhoneNo = caofinfoDTO.Township_Code;
       //        POs.Add(PO);
       //    }
       //    return POs;
       //}

       //private PFMDTO00017 SelectTopCustomerInformationByAnyAccountNoandAnyAcSign(string acccountNo, string accountSign)
       //{
       //   // PFMDTO00017 caofinfoDTO = new PFMDTO00017();
       //    PFMDTO00016 saofinfoDTO = new PFMDTO00016();
       //    PFMDTO00021 faofinfoDTO = new PFMDTO00021();
       //    try
       //    {
       //        switch (accountSign.Substring(0, 1))
       //        {
       //            case "C": caofinfoDTO = this.codeCheckerDAO.GetTopCAOFInfoByAccountNumber(acccountNo);
       //                break;
       //            case "S": saofinfoDTO = this.codeCheckerDAO.GetTopSAOFInfoByAccountNumber(acccountNo);
       //                caofinfoDTO.Name = saofinfoDTO.Name;
       //                caofinfoDTO.NRC = saofinfoDTO.NRC;
       //                caofinfoDTO.Address = saofinfoDTO.Address;
       //                caofinfoDTO.Township_Code = saofinfoDTO.Township_Code;
       //                break;
       //            case "F": faofinfoDTO = this.codeCheckerDAO.GetTopFAOFINfoByAccountNumber(acccountNo);
       //                caofinfoDTO.Name = faofinfoDTO.Name;
       //                caofinfoDTO.NRC = faofinfoDTO.NRC;
       //                caofinfoDTO.Address = faofinfoDTO.Address;
       //                caofinfoDTO.Township_Code = faofinfoDTO.Township_Code;
       //                break;
       //            default:
       //                caofinfoDTO.Name = string.Empty;
       //                break;
       //        }
       //    }
       //    catch
       //    {

       //    }
       //    return caofinfoDTO;
       //}

       #endregion
   }
}
