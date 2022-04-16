using System.Linq.Expressions;

namespace DataAccess
{
    public interface IRepository<T> where T : class
    {
        IList<T> ReadData(Expression<System.Func<T, bool>> lambda);
    }
}
