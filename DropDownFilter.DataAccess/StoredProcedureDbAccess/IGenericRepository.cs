﻿using System.Collections.Generic;
using System.Data;

namespace DropDownFilter.StoredProcedureDbAccess
{
    public interface IGenericRepository<TEntity>
    {
        IDbConnection GetOpenConnection();
        TEntity GetSingle(int aSingleId);
        IEnumerable<TEntity> GetAll();

    }
}
