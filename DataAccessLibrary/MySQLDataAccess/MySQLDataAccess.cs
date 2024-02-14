using System.Collections.Generic;
using System.Data;
using System.Linq;

using Dapper;

using MySql.Data.MySqlClient;

namespace DataAccessLibrary.MySQLDataAccess
{
	internal static class MySQLDataAccess
	{
		internal static List<T> ReadData<T, U>(string sqlStatement, U parameters, string connectionString)
		{
			using ( IDbConnection connection = new MySqlConnection(connectionString) )
			{
				List<T> data = connection.Query<T>(sqlStatement, parameters).ToList();
				return data;
			}
		}

		internal static void WriteData<T>(string sqlStatement, T parameters, string connectionString)
		{
			using ( IDbConnection connection = new MySqlConnection(connectionString) )
			{
				_ = connection.Execute(sqlStatement, parameters);
			}
		}
	}
}
