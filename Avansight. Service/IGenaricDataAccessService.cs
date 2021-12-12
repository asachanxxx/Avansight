﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace Avansight.Service
{
    public interface IGenaricDataAccessService<T> where T : class
    {
        IEnumerable<T> Query<T>(string sql, object param=null , CommandType commandType = CommandType.StoredProcedure, SqlConnection sqlConnection = null);
        void Execute(string sql, object param = null, CommandType commandType = CommandType.StoredProcedure, SqlConnection sqlConnection = null);
        public void ExecuteScopedTransaction(Action<SqlConnection> transAction);
    }
}
