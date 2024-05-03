using EDTLBS.Common.Model;

namespace EDTLBS.Services
{
    public interface IBookServices
    {
        IEnumerable<Book> GetBooks();
        Book GetBook(int id);
        Book AddBook(Book book);
        Book UpdateBook(Book book);
        bool DeleteBook(int id);
    }
}
