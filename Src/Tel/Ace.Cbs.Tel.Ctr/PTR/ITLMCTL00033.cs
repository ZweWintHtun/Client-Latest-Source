//----------------------------------------------------------------------
// <copyright file="ITLMCTL00033.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hsu Wai Htoo </CreatedUser>
// <CreatedDate>2013-06-11</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using System.Drawing;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Tel.Ctr.Ptr
{
    public interface ITLMCTL00033 : IPresenter
    {
       // public IList<PFMDTO00037> BranchStatusDTOList();
         ITLMVEW00033 IBLReconsileView { get; set; }
         IList<BranchDTO> GetReconsileDTOList();
        
       //  void UpdateCurselReconsile();
        // void Reconcile(IList<BranchDTO> branches, DateTime date,string transactiontyp);
         void Reconcile(IList<BranchDTO> branches, DateTime date, string tansactiontype);
       
       
    }

    public interface ITLMVEW00033
    {
        DateTime Date { get; set; }
         //bool Drawing{get;set;}
         //bool Encash{get;set;}
         //bool TransactionCheck { get; set; }
         ITLMCTL00033 IBLReconcileController { get; set; }
         IList<BranchDTO> Branches { get; set; }
         string TransactionType { get; set; }
         void BindGridView();
         
    }
}
