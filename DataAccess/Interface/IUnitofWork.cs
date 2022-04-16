namespace DataAccess
{
    public interface IUnitofWork : IConnection, IDisposable
    {
        void BeginTran();
        void CommitTran();
        void Rollback();
    }
}
