//----------------------------------------------------------------------
// <copyright file="TLMDTO00033.cs" company="ACE Data Systems">
// Copyright (c) ACE Data Systems. All rights reserved.
// </copyright>
// <CreatedUser>Ye Mann Aung</CreatedUser>
// <CreatedDate>2013-05-22</CreatedDate>
// <UpdatedUser></UpdatedUser>
// <UpdatedDate></UpdatedDate>
// <Version>1.0</Version>
//----------------------------------------------------------------------
using System.Collections.Generic;
using ACE.Windows.Core.DataModel;

namespace ACE.CBS.TLM.DMD
{
    [System.Serializable]
    public class TLMDTO00033
    {
        TLMDTO00033() { }

        public char uID { get; set; }
        public string currency { get; set; }
        public string desp { get; set; }
        public int d1 { get; set; }
        public int d2 { get; set; }
        public char symbol { get; set; }
        public int cal { get; set; }
    }
}
