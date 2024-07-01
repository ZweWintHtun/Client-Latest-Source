//--------------------------------------------------- Contract ------------------------------------------------//
//----------------------------------------------------------------------
// <copyright file="IPFMDAO00057.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hay Mar</CreatedUser>
// <CreatedDate>08/07/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using Ace.Windows.Core.Dao;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Pfm.Dmd.DTO;
using System;

namespace Ace.Cbs.Pfm.Ctr.Dao
{
    /// <summary>
    /// PFMDAO00057 Interface
    /// </summary>
    public interface IPFMDAO00057 : IDataRepository<PFMORM00057>
    {
        bool CheckExist(string variable, string value, bool isEdit);
        IList<PFMDTO00057> SelectAll();
        PFMDTO00057 SelectByVariable(string variable);
        void UpdateValueOfRunTrigger(string Disable_Enable, int updatedUserId);
        string SelectBudDate(string variable);
        bool UpdateByVariable(string variable, string value, int updateduserid);
        IList<PFMDTO00057> NewSetup_SelectSDateEDate();
        IList<PFMDTO00057> CheckExist2(string variable, string value);
        string GetBudget_Month_Year_Quarter(Int32 service, DateTime pDate, string branchCode, string Return);
        string YearlyPostingProcess(string budget, int createdUserId, string sourceBr);
        string YearlyPostingProcess_Initial(int createdUserId, string sourceBr);

    }
}