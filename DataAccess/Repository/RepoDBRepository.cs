using GraphQL.Types;
using RepoDb;
using System.Linq.Expressions;

namespace DataAccess
{
    public abstract class RepoDBRepository<T> : ObjectGraphType<T>, IRepository<T> where T : class
    {
        private RepoDBUoW _uow { get; set; }
        public RepoDBRepository(IUnitofWork uow) => _uow = (RepoDBUoW)uow;
        public IList<T> ReadData(Expression<System.Func<T, bool>> lambda)
        {
            var data = _uow._Connection._dbconn.Query<T>(lambda);
            return data.ToList();
        }
    }
}
