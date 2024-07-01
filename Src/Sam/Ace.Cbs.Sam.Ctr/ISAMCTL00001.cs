//----------------------------------------------------------- Contract ------------------------------------//
//----------------------------------------------------------------------
// <copyright file="ISAMCTL00001.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>arkar</CreatedUser>
// <CreatedDate>07/09/2013</CreatedDate>
// <UpdatedUser>ksw</UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using ACE.CBS.SAM.DMD;
using ACE.CBS.CX.COM.DMD;
using System.Collections.Generic;
using ACE.Windows.Core.Presenter;

namespace ACE.CBS.SAM.CTR.PTR
{
    public interface ISAMCTL00001 : IPresenter
    {
        ISAMVEW00001 AccountTypeView { set; get; }
        IList<SAMDTO00001> GetAll();
        void Save(SAMDTO00001 entity);
        void Delete(IList<SAMDTO00001> itemList);
        SAMDTO00001 SelectById(int id);
    }

    public interface ISAMVEW00001
    {
        int Id { get; }
        string Code { get; set; }
        string Description { get; set; }
        string Symbol { get; set; }
        string Status { get; set; }

        SAMDTO00001 ViewData { get; set; }
        IList<SAMDTO00001> AccountTypes { get; set; }
        ISAMCTL00001 Controller { set; get; }
        void Successful(string message);
        void Failure(string message);
    }
}