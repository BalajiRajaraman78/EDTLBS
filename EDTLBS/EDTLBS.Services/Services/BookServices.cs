using EDTLBS.Common.Model;
using EDTLBS.Repository;

namespace EDTLBS.Services
{
    public class BookServices : IBookServices
    {
        private readonly IBookRepository _bookRepository;
        public BookServices(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public IEnumerable<Book> GetBooks()
        {
            return _bookRepository.GetBooks();
        }
        public Book GetBook(int id)
        {
            return _bookRepository.GetBook(id);
        }
        public Book AddBook(Book book)
        {
            return _bookRepository.AddBook(book);
        }
        public Book UpdateBook(Book book)
        {
            return _bookRepository.UpdateBook(book);
        }
        public bool DeleteBook(int id)
        {
            return _bookRepository.DeleteBook(id);
        }
    }
}
