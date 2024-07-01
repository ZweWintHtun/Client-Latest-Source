using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ace.Cbs.Cx.Com.Dto
{
    /// <summary>
    /// Store procedure output return value
    /// </summary>
    /// 
     [Serializable]
    public class CXDTO00008
    {
        public CXDTO00008() { }

        public CXDTO00008(string r)
        {
            this.ReturnValue = r;//@RETURN AS VARCHAR(15)
        }
        public CXDTO00008(int error,int retValue)
        {
            this.ErrorNo = error;//@ERROR  INT OUTPUT,
            this.ReturnType = retValue;//@RETVALUE INT OUTPUT 
        }

        public CXDTO00008(string errormsg, int returnvalue)
        {
            this.ErrorMessage = errormsg;
        }
       
        public string ErrorMessage { get; set; }

        public string ReturnValue { get; set; }
        public int ReturnType { get; set; }
        public int ErrorNo { get; set; }
    }
}
