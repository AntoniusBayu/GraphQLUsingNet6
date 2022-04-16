using GraphQL.Types;

namespace DataAccess
{
    public class BookRepository : RepoDBRepository<Book>
    {
        public BookRepository(IUnitofWork uow) : base(uow)
        {
            Field<ListGraphType<BookType>>(
                "Books",
                resolve: context =>
                {
                    var data = ReadData(x => x.AutoID == context.Source.AutoID);
                    return data.ToList();
                });
        }
    }
}
