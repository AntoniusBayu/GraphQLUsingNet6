namespace DataAccess
{
    public interface IConnection : IDisposable
    {
        string GetConnectionString(string key);
        string GetAppSetting(string key);
        void OpenConnection(string connString);
    }
}
