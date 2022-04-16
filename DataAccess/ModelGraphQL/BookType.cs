using GraphQL.Types;

namespace DataAccess
{
    public class BookType : ObjectGraphType<Book>
    {
        public BookType()
        {
            Name = "Book";
            Field(x => x.AutoID, type: typeof(IdGraphType)).Description("The id of Book Model");
            Field(x => x.Description, type: typeof(StringGraphType)).Description("Description");
            Field(x => x.CreatedDate, type: typeof(DateTimeGraphType)).Description("Datetime");
            Field(x => x.IsActive, type: typeof(BooleanGraphType)).Description("Boolean");
        }
    }
}
