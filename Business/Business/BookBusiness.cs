using DataAccess;
using GraphQL;
using GraphQL.Types;

namespace Business
{
    public class BookBusiness : IBookBusiness
    {
        private IUnitofWork _uow { get; set; }
        public BookBusiness(IUnitofWork uow) => _uow = uow;
        public async Task<ExecutionResult> ReadData(GraphQLQuery query)
        {
            try
            {
                _uow.OpenConnection(_uow.GetConnectionString(ConstConnectionString.LocalDBConnection));

                var schema = new Schema
                {
                    Query = new BookRepository(_uow)
                };

                var result = await new DocumentExecuter().ExecuteAsync(x =>
                {
                    x.Schema = schema;
                    x.Query = query.Query;
                    x.OperationName = query.OperationName;
                });

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                _uow.Dispose();
            }
        }
    }
}
