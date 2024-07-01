//----------------------------------------------------------------------
// <copyright file="MNMCTL00001.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>HM</CreatedUser>
// <CreatedDate>12/27/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ace.Cbs.Mnm.Ctr.Ptr;
using Ace.Windows.Core.Presenter;
using Ace.Windows.CXClient;
using Ace.Cbs.Mnm.Ctr.Sve;
using Ace.Windows.Core.Utt;
using Ace.Cbs.Mnm.Dmd;
using System.Windows.Forms;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Dmd;
using Ace.Cbs.Cx.Com.Ctr;
using Ace.Cbs.Cx.Com.Utt;

namespace Ace.Cbs.Mnm.Ptr
{
    public class MNMCTL00124 : AbstractPresenter, IMNMCTL00124
    {
        //IList<PFMDTO00042> PrintDataList {get;set;}

        public IMNMVEW00124 View { get; set; }       
       

        public IList<PFMDTO00042> Print()
        {
            IList<PFMDTO00042> PrintDataList = CXClientWrapper.Instance.Invoke<IMNMSVE00124, IList<PFMDTO00042>>(x => x.GetIROutstandingReport(CurrentUserEntity.BranchCode));

            if (PrintDataList == null || PrintDataList.Count == 0)
            {
                CXUIMessageUtilities.ShowMessageByCode("MI00039"); //No Data for Report
                return PrintDataList;
            }
            else
            {
                return PrintDataList;
            }
        }
    }
}
