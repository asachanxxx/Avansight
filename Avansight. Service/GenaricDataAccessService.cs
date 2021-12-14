using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Avansight.Service.Implimentation;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Transactions;

namespace Avansight.Service
{
    public class GenaricDataAccessService<T> : IGenaricDataAccessService<T> where T : class
    {
        private readonly DapperContext _config;
        public GenaricDataAccessService(IConfiguration configuration)
        {
            _config = new DapperContext(configuration);
        }

        public virtual void Execute(string sql, object param = null, CommandType commandType = CommandType.StoredProcedure)
        {
            using (var connection = _config.CreateConnection())
            {
                var affectedRows = connection.Execute(sql: sql, param: param, commandType: CommandType.StoredProcedure);
            }
        }
        public IEnumerable<T> Query<TR>(string sql, object param = null, CommandType commandType = CommandType.StoredProcedure)
        {
            using (var connection = _config.CreateConnection())
            {
                return connection.Query<T>(sql: sql, param: param, commandType: commandType);
            }
        }

        public T QuerySingle(string sql, object param = null, CommandType commandType = CommandType.StoredProcedure)
        {
            using (var connection = _config.CreateConnection())
            {
                return connection.QueryFirstOrDefault<T>(sql: sql, param: param, commandType: commandType);
            }
        }

        public void ExecuteScopedTransaction(Action<SqlConnection> transAction)
        {
            using (var connection = _config.CreateConnection())
            {
                connection.Open();
                TransactionOptions options = new TransactionOptions
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted,
                    Timeout = new TimeSpan(0, 15, 0)
                    
                };
                using (var scope = new TransactionScope(TransactionScopeOption.Required, options))
                {
                    transAction?.Invoke(connection);
                    scope.Complete();
                }
            }
        }
    }
}
