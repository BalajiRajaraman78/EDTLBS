using EDTLBS.Common.Model;
namespace EDTLBS.Repository
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetBooks();
        Book GetBook(int id);
        Book AddBook(Book book);
        Book UpdateBook(Book book);
        bool DeleteBook(int id);
    }
}
