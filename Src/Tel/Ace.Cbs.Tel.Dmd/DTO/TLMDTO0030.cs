//----------------------------------------------------------------------
// <copyright file="TLMDTO00030.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Ye Mann Aung</CreatedUser>
// <CreatedDate>2013-05-22</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version>1.0</Version>
//----------------------------------------------------------------------
using System;
using ACE.Windows.Core.DataModel;

namespace ACE.CBS.TLM.DMD
{
    [Serializable]
    public class IBLDWTRATEDTO : Supportfields<IBLDWTRATEDTO>
    {
        public IBLDWTRATEDTO() { }

        public string fixAMT { get; set; }
        public double rate { get; set; }
    }

}
