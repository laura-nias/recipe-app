using System;
namespace DataAccess
{
    public interface IMainDataAccess
    {
        List<T> LoadData<T, U>(string sql, U parameters, string connectionString);

        void AddData<T>(string sql, T parameters, string connectionString);

        void RemoveData<T>(string sql, T parameters, string connectionString);
    }
}

