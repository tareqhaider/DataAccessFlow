﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DataLibrary.DataAccess
{
    public static class SqlDataAccess
    {
        public static string GetConnectionString(string connectionName = "DemoDB")
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection con = new SqlConnection(GetConnectionString()))
            {
                return con.Query<T>(sql).ToList();
            }
        }

        public static int SaveData<T>(string sql, T data)
        {
            using (IDbConnection con = new SqlConnection(GetConnectionString()))
            {
                return con.Execute(sql, data);
            }
        }
    }
}
