using System.Collections.Generic;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;
using Ace.Windows.Admin.DataModel;
using System;


namespace Ace.Cbs.Cx.Com.Ctr
{
    /// <summary>
    /// Code Generator Dao Interface
    /// </summary>
    public interface ICXDAO00002 : IDataRepository<Format>
    {
        IList<FormatDefinition> SelectFormatDefinitonByFormatCode(string code, string branchCode);
        FormatDefinition SelectFormatDefinitionById(int id);
        bool FormatDefinitionUpdate(int id, string maximumValue, string branchCode, int updatedUserId, System.DateTime updatedDate, byte[] timestamp);
        void FormatDefinitionUpdateForLoanReg(int formatid, string maximumValue, string branchCode, int updatedUserId,DateTime updatedDate);
        void UpdateMaxValueForDenominationDelete(int updatedUserId, System.DateTime updatedDate,string branchCode);
    }
}
