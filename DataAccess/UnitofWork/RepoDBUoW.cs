using System.Data;

namespace DataAccess
{
    public class RepoDBUoW : IUnitofWork
    {
        public RepoDBConnection _Connection { get; private set; }
        public RepoDBUoW(IConnection conn) => _Connection = (RepoDBConnection)conn;
        public void BeginTran()
        {
            if (_Connection._dbconn == null)
                throw new ArgumentNullException("_Connection._dbconn");

            _Connection._tran = _Connection._dbconn.BeginTransaction(IsolationLevel.ReadUncommitted);
        }
        public void CommitTran()
        {
            if (_Connection._tran == null)
                throw new ArgumentNullException("_Connection._tran");

            if (_Connection._tran.Connection != null)
                _Connection._tran.Commit();
        }
        public void Dispose() => _Connection.Dispose();
        public string GetAppSetting(string key) => _Connection.GetAppSetting(key);
        public string GetConnectionString(string key) => _Connection.GetConnectionString(key);
        public void OpenConnection(string connString)
        {
            if (_Connection._dbconn == null)
                _Connection.OpenConnection(connString);
        }
        public void Rollback()
        {
            if (_Connection._tran == null)
                throw new ArgumentNullException("_Connection._tran");

            if (_Connection._tran.Connection != null)
                _Connection._tran.Rollback();

        }
    }
}
