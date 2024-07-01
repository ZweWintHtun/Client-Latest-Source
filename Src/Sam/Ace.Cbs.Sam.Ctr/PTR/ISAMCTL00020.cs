//----------------------------------------------------------- Contract ------------------------------------//
//----------------------------------------------------------------------
// <copyright file="ISAMCTL00020.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Hay Mar</CreatedUser>
// <CreatedDate>08/05/2013</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version></Version>
//----------------------------------------------------------------------
using System;
using Ace.Cbs.Tel.Dmd;
using Ace.Cbs.Pfm.Dmd;
using Ace.Cbs.Cx.Com.Dmd;
using System.Collections.Generic;
using Ace.Windows.Core.Presenter;
using Ace.Windows.Admin.DataModel;

namespace Ace.Cbs.Sam.Ctr.Ptr
{
    public interface ISAMCTL00020 : IPresenter
    {
        ISAMVEW00020 SERVERLOGView { set; get; }
        IList<TLMDTO00027> GetAll();
        IList<BranchDTO> GetAllBranchCode();
        void Save(TLMDTO00027 entity);
        void Delete(IList<TLMDTO00027> itemList);
        TLMDTO00027 SelectById(int id);
    }

    public interface ISAMVEW00020
    {
        int Id { get; }
        string BranchCode { get; set; }
        string SERVERNAME { get; set; }
        string IPADDRESS { get; set;}
        bool NewSystem { get; set; }
        bool OldSystem { get; set; }
        bool Vsat { get; set; }
        bool IPStar { get; set; }
        string DBNAME { get; set; }
        //string IBDIPADDRESS { get; set; }
        //string ISPNAME { get; set; }       
        //string VERSION { get; set; }
        string Status { get; set; }

        TLMDTO00027 ViewData { get; set; }
        IList<TLMDTO00027> SERVERLOGs { get; set; }
        ISAMCTL00020 Controller { set; get; }

        void Successful(string message);
        void Failure(string message);
    }
}