using EDTLBS.Common.Model;
using EDTLBS.DAL;
using EDTLBS.Repository;
using Microsoft.EntityFrameworkCore;

public class BookRepository : IBookRepository
{
    private readonly ApplicationDbContext _context;

    public BookRepository(ApplicationDbContext context)
    {
        _context = context;
        InitialiseBooks();
    }

    public IEnumerable<Book> GetBooks()
    {
        return _context.Books.ToList();
    }

    public Book GetBook(int id)
    {
        if (id <= 0)
            return new Book();

        var book =  _context.Books.Find(id);
        if(book == null)
            return new Book();
        else
            return book;
    }

    public Book AddBook(Book book)
    {
        _context.Books.Add(book);
        _context.SaveChanges();
        return book;
    }

    public Book UpdateBook(Book book)
    {
        _context.Entry(book).State = EntityState.Modified;
        _context.SaveChanges();
        return book;
    }

    public bool DeleteBook(int id)
    {
        var book = _context.Books.Find(id);
        if (book == null)
            return false; 
        _context.Books.Remove(book);
        _context.SaveChanges();
        return true;
    }
    private IList<Book> InitialiseBooks()
    {
       if(_context.Books.Count() <= 0)
        {
            _context.Books.Add(new Book { Id = 1, Title = "Title 1", Author = "Author 1", Pages = 100 });
            _context.Books.Add(new Book { Id = 2, Title = "Title 2", Author = "Author 2", Pages = 200 });
            _context.Books.Add(new Book { Id = 3, Title = "Title 3", Author = "Author 3", Pages = 300 });
            _context.Books.Add(new Book { Id = 4, Title = "Title 4", Author = "Author 4", Pages = 400 });
            _context.Books.Add(new Book { Id = 5, Title = "Title 5", Author = "Author 5", Pages = 500 });
            _context.SaveChanges();
        }
        return _context.Books.ToList();
    }
}
