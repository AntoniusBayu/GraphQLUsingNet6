using DataAccess;
using GraphQL;

namespace Business
{
    public interface IBookBusiness
    {
        Task<ExecutionResult> ReadData(GraphQLQuery query);
    }
}
