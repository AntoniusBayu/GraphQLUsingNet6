using Microsoft.Extensions.Configuration;
using RepoDb;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class RepoDBConnection : IConnection
    {
        public IDbConnection? _dbconn { get; private set; }
        public IDbTransaction? _tran { get; set; }
        private IConfiguration _config { get; set; }
        private IConfigurationSection? _appsettings { get; set; }
        public RepoDBConnection(IConfiguration config) => _config = config;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool isDisposed)
        {
            if (isDisposed)
            {
                if (this._tran != null)
                {
                    this._tran.Dispose();
                    this._tran = null;
                }

                if (this._dbconn != null)
                {
                    this._dbconn.Dispose();
                    this._dbconn.Close();
                    this._dbconn = null;
                }
            }
        }
        public string GetAppSetting(string key)
        {
            _appsettings = _config.GetSection("AppSettings");
            return _appsettings.GetSection(key).Value;
        }
        public string GetConnectionString(string key) => _config.GetConnectionString(key);
        public void OpenConnection(string connString)
        {
            _dbconn = new SqlConnection(connString);
            _dbconn.Open();
            SqlServerBootstrap.Initialize();
        }
    }
}
