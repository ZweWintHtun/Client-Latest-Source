using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Cx.Com.Dto
{
    /// <summary>
    /// Return values from CheckAmount (CXSVE00006 Common Module)
    /// </summary>
     [Serializable]
    public class CXDTO00009
    {
        public CXDTO00009() { }

        public CXDTO00009(string messagecode, bool islink)
        {
            this.MessageCode = messagecode;
            this.IsLink = islink;
        }
        public string MessageCode { get; set; }
        public bool IsLink { get; set; }
    }
}
