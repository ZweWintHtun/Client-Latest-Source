//----------------------------------------------------------------------
// <copyright file="TLMDTO00031.cs" company="ACE Data Systems">
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
    public class ZONEDTO
    {
        public ZONEDTO() { }

        public string zoneType { get; set; }
        public string zoneDesp { get; set; }
        public string brCode { get; set; }
        public string aCode { get; set; }
        public string sourceBR { get; set; }
        public char uID { get; set; }
    }
}
