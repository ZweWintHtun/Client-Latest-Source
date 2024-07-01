//------------------------------------------------------------- Contract ---------------------------------------//
//----------------------------------------------------------------------
// <copyright file="ILOMSVE00006.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>KKM</CreatedUser>
// <CreatedDate>09/01/2015</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Windows.Core.Service;
using Ace.Windows.Ix.Core.DataModel;
using Ace.Cbs.Loan.Dmd;

namespace Ace.Cbs.Loan.Ctr.Sve
{
    public interface ILOMSVE00006 : IBaseService
    {
        IList<LOMDTO00004> GetAll();
      
        void Update(LOMDTO00004 entity,IList<DataVersionChangedValueDTO> dvcvList, string status);
        void Delete(IList<LOMDTO00004> itemList);
        LOMDTO00004 SelectByINSUCODE(string iNSUCODE);

        //void SaveServerAndServerClient(LOMDTO00004 entity);
        void SaveServerAndServerClient(LOMDTO00004 entity, IList<DataVersionChangedValueDTO> dvcvList);
        IList<LOMDTO00004> CheckExist2(string typeOfAdvanceCode, string description);
        
    }
}