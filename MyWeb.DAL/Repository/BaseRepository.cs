using Microsoft.Data.SqlClient;
using MyWeb.DAL.Data;
using System.Data;

namespace MyWeb.DAL.Repository
{
    public abstract class BaseRepository
    {
        private readonly ConfigOptions _config;

        public static IDbConnection _db;

        public BaseRepository(ConfigOptions config)
        {
            _config = config;

            if (_db == null)
                _db = new SqlConnection(_config.DefaultConnection);

            if (_db.State == ConnectionState.Closed || _db.State == null)
                _db.Open();
        }
    }
}
