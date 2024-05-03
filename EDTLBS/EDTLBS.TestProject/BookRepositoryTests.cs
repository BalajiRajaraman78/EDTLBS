using EDTLBS.Common.Model;
using EDTLBS.DAL;
using EDTLBS.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace EDTLBS.TestProject
{
    public class BookRepositoryTests 
    {
        private readonly Mock<IBookRepository> _bookRepositoryMock;
        private readonly Book _book;
        private readonly DbContextOptions<ApplicationDbContext> _options;
        public BookRepositoryTests()
        {
            _bookRepositoryMock = new Mock<IBookRepository>();
            _options = new DbContextOptionsBuilder<ApplicationDbContext>()
                            .UseInMemoryDatabase(databaseName: "BookLibraryTest") // Use in-memory database
                            .Options;
            _book = new Book { Id = 6, Title = "Title 6", Author = "Author 6", Pages = 600 };
        }

        [Fact()]
        public void GetAll_ReturnsAllBook()
        {
             // Arrange
            _bookRepositoryMock.Setup(repo => repo.GetBooks()).Returns(new List<Book> { _book });

            // Act
            var result = _bookRepositoryMock.Object.GetBooks();

            // Assert
            Assert.Single(result);
            Assert.Equal(_book, result.First());
        }

        [Fact()]
        public void GetById_ReturnsBook()
        {
            _bookRepositoryMock.Setup(repo => repo.GetBook(_book.Id)).Returns( _book);

            // Act
            var result = _bookRepositoryMock.Object.GetBook(_book.Id);

            // Assert
            Assert.Equal(_book, result);
        }

        [Fact()]
        public void AddBookTest()
        {
            // Arrange
            _bookRepositoryMock.Setup(repo => repo.AddBook(_book)).Returns(_book);

            // Act
            var result = _bookRepositoryMock.Object.AddBook(_book);

            // Assert
            Assert.Equal(_book, result);
        }
        [Fact()]
        public void UpdateBookTest()
        {
            // Arrange
            var updatedEntity = new Book { Id = 6, Title = "Title 6 - Updated" };
            _bookRepositoryMock.Setup(repo => repo.UpdateBook(updatedEntity)).Returns(updatedEntity);
            
            // Act
            var result = _bookRepositoryMock.Object.UpdateBook(updatedEntity);

            // Assert
            Assert.Equal(updatedEntity, result);
        }

        [Fact()]
        public void DeleteBookTest()
        {
            // Arrange
            _bookRepositoryMock.Setup(repo => repo.DeleteBook(_book.Id)).Returns(true);

            // Act
            var result = _bookRepositoryMock.Object.DeleteBook(_book.Id);

            // Assert
            Assert.True(result);
        }
    }
}