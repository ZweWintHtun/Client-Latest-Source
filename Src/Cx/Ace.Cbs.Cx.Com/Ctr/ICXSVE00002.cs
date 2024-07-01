using System.Collections;
using System.Collections.Generic;
using Ace.Cbs.Pfm.Dmd;
using System;

namespace Ace.Cbs.Cx.Com.Ctr
{
    public interface ICXSVE00002
    {
        string GetGenerateCode(string formatCode, string checkDigitFormula, int updatedUserId, string branchCode, params dynamic[] inputFormatDefinition);
        string GetAccountNoFormatCode(string transactionType, string currencyCode);

        void UpdateFormatDefinition(string formatCode, string branchCode);
        string GenerateCodeForLoanGroupNo(string formatCode, int updatedUserId, string branchCode, params dynamic[] inputFormatDefinition);
        string GenerateLoanRecordVouncher(string formatCode, int updatedUserId, string branchCode, params dynamic[] inputFormatDefinition);
    }
}
