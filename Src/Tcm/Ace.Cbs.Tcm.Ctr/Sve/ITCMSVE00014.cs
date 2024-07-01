//----------------------------------------------------------------------
// <copyright file="ITCMSVE00014.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Nyo Me San</CreatedUser>
// <CreatedDate></CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Cbs.Tcm.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Ix.Core.DataModel;


namespace Ace.Cbs.Tcm.Ctr.Sve
{
  public  interface ITCMSVE00014 :IBaseService
    {
      TCMDTO00001 SelectStartBySourceBr(string sourcebr);
      bool StartUp(TCMDTO00001 startdto);
      IList<PFMDTO00075> SelectAllByLastModify();
      void GetCurRate(int updatedUserid, IList<PFMDTO00075> rateInfodtos, PFMDTO00075 newRateDto,int rowCount,DataVersionChangedValueDTO dvcvList);  //edited by ASDA
      bool CalculateServiceCharge(int createduserid, string sourcebr);
      void UpdateRateInfo_ForCurRate(int currentuserId, DateTime clientDate, IList<DataVersionChangedValueDTO> dvcvList, int rowcount, IList<PFMDTO00075> newrateinfos, IList<PFMDTO00075> rateinfos);
    
    }
}
