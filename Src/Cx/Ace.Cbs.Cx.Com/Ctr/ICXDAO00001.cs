using System;
using System.Collections;
using System.Collections.Generic;
using Ace.Cbs.Pfm.Dmd;
using Ace.Windows.Core.Dao;

namespace Ace.Cbs.Cx.Com.Ctr
{
    /// <summary>
    /// Server Version Dao Interface
    /// </summary>
    public interface ICXDAO00001 : IDataRepository<PFMORM00031>
    {
        PFMDTO00031 ServerVersionById(int id);
        IList GetListObject(string queryString, Dictionary<string, object> parameters);
        int ServerVersion_Count(string tableName, string dataId);
        int ServerVersion_Update(string tableName, string dataId, int status, DateTime updatedDate, int updatedUserId);
        IList<PFMDTO00031> ServerVersion_SelectListByCounterIdVersionNumber(string counterId, decimal currentVersionNumber);
        int ServerVersion_UpdateVersion(int serverVersionId, byte[] timestamp, decimal definedVersionNumber);
        object CounterVersion_Insert(PFMORM00030 entity);
    }
}
