using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dapper;

namespace Avansight.Service
{
    public class GenaricDataAccessService<T> : IGenaricDataAccessService<T> where T : class
    {
        public GenaricDataAccessService()
        {

        }

        public virtual void Execute(string sql, object param = null, CommandType commandType = CommandType.StoredProcedure, SqlConnection sqlConnection = null)
        {
            throw new NotImplementedException();
        }

        public void ExecuteScopedTransaction(Action<SqlConnection> transAction)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Query<T>(string sql, object param = null, CommandType commandType = CommandType.StoredProcedure, SqlConnection sqlConnection = null)
        {
            throw new NotImplementedException();
        }
    }
}
