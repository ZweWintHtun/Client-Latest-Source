using System.Collections;
using System.Collections.Generic;
using Ace.Cbs.Pfm.Dmd;
using System;

namespace Ace.Cbs.Cx.Com.Ctr
{
    /// <summary>
    /// Server Version Service Interface
    /// </summary>
    public interface ICXSVE00001
    {
        IList GetListObject(int serverDataVersionId);
        object GetScalarObject(int serverDataVersionId);
        void ServerVersion_Save(PFMDTO00031 serverVersionDTO);
        IList<PFMDTO00031> GetUpdateList(string counterId, decimal currentVersion);
        void ServerVersion_UpdateVersion(IList<PFMDTO00031> list, decimal definedServerNumber);
        bool CounterVersion_Insert(PFMDTO00030 entity);
        PFMDTO00031 ServerVersionById(int serverVersionId);
        bool UpdateServer(string ormName, Dictionary<string, object> updateColumnsandValues, Dictionary<string, object> whereColumnsandValues);
        void InsertServer(string tableName, Dictionary<string, object> savecolumnsandValues, byte[] ts, int createdUserId, DateTime createdDate);
        void Save(object entity);
        bool Update(string ormName, Dictionary<string, object> updateColumnsandValues, Dictionary<string, object> whereColumnsandValues);
        bool Delete(string ormName, string primaryKey, object primaryKeyValue, int deletedUserId,byte[] ts);
    }
}
