using System.Data;
using MySql.Data.MySqlClient;
using Dapper;


namespace DataAccess;

public class MainDataAccess : IMainDataAccess
{
    public List<T> LoadData<T, U>(string sql, U parameters, string connectionString)
    {
        using (IDbConnection connection = new MySqlConnection(connectionString))
        {
            IEnumerable<T> rows = connection.Query<T>(sql, parameters);

            return rows.ToList();
        }
    }

    public void AddData<T>(string sql, T parameters, string connectionString)
    {
        using (IDbConnection connection = new MySqlConnection(connectionString))
        {
            connection.Execute(sql, parameters);
        }
    }

    public void RemoveData<T>(string sql, T parameters, string connectionString)
    {
        using (IDbConnection connection = new MySqlConnection(connectionString))
        {
            connection.Execute(sql, parameters);
        }
    }

    public void UpdateData<T>(string sql, T parameters, string connectionString)
    {
        using (IDbConnection connection = new MySqlConnection(connectionString))
        {
            connection.Execute(sql, parameters);
        }
    }
}

