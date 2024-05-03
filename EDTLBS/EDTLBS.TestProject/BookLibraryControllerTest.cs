using EDTLBS.Common.Model;
using EDTLBS.Controllers;
using EDTLBS.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace EDTLBS.TestProject
{
    public class BookLibraryControllerTest
    {
        private readonly Mock<IBookServices> _bookServicesMock;
        private readonly BookLibraryController _controller;
        public BookLibraryControllerTest()
        {
            _bookServicesMock = new Mock<IBookServices>();
            _controller = new BookLibraryController(_bookServicesMock.Object);
        }
        [Fact]
        public void GetAll_ReturnsAllBook()
        {
            int bookId = 1;
            // Arrange
            _bookServicesMock.Setup(repo => repo.GetBooks()).Returns(GetBooks());
            
            // Act
            var result = _controller.GetBooks();
            
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Book>>(okResult.Value);
            var book = returnValue.FirstOrDefault();
            Assert.Equal(bookId, book.Id);
        }
        [Fact]
        public void GetBooks_NoCondition_Returns_OkObjectResult()
        {
            // Arrange
            _bookServicesMock.Setup(repo => repo.GetBooks()).Returns(GetBooks());
            // Act
            var result = _controller.GetBooks();
            var okResult = Assert.IsType<OkObjectResult>(result);
            // Assert
            Assert.NotNull(okResult);
            Assert.True(okResult.StatusCode is StatusCodes.Status200OK);            
        }
        [Fact()]
        public void GetBooks_ReturnsOkResult_WithListOfBooks()
        {
            // Arrange
            _bookServicesMock.Setup(repo => repo.GetBooks()).Returns(GetBooks());
            
            // Act
            var result = _controller.GetBooks();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Book>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }
        [Fact]
        public void GetBook_ExistingIdPassed_ReturnsOkResult()
        {
            // Arrange
            var bookId = 1;
            _bookServicesMock.Setup(repo => repo.GetBook(bookId)).Returns(new Book { Id = bookId });

            // Act
            var result = _controller.GetBook(bookId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<Book>(okResult.Value);
        }
        [Fact]
        public void GetById_ReturnsEntityById()
        {
            var bookId = 1;
            // Arrange
            _bookServicesMock.Setup(repo => repo.GetBook(bookId)).Returns(new Book { Id = bookId });

            // Act
            var result = _controller.GetBook(bookId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var book = Assert.IsType<Book>(okResult.Value);
            Assert.Equal(bookId, book.Id);
        }
        [Fact]
        public void GetBook_NonExistingIdPassed_ReturnsNotFoundResult()
        {
            // Arrange
            var bookId = 1;
            _bookServicesMock.Setup(repo => repo.GetBook(bookId)).Returns((Book)null);

            // Act
            var result = _controller.GetBook(bookId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
        [Fact()]
        public void AddBookTest()
        {
            // Arrange
            var book = new Book { Id = 6, Title = "Title 6", Author = "Author 6", Pages = 600 };
            _bookServicesMock.Setup(repo => repo.AddBook(book)).Returns(book);
            // Act
            var result = _controller.AddBook(book);
            var okResult = Assert.IsType<OkObjectResult>(result);
            // Assert
            Assert.NotNull(okResult.Value);
            Assert.True(okResult.StatusCode is StatusCodes.Status200OK);
        }

        [Fact]
        public void AddBook_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            var _book = new Book { Id = 7, Title = "Title 7", Author = "Author 7", Pages = 700 };
            _bookServicesMock.Setup(repo => repo.AddBook(_book)).Returns(_book);

            // Act
            var result = _controller.AddBook(_book);

            // Assert
            var createdAtActionResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<Book>(createdAtActionResult.Value);
        }

        [Fact]
        public void UpdateBook_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            var _updatebook = new Book { Id = 7, Title = "Title 7 - Updated", Author = "Author 7", Pages = 700 };
            _bookServicesMock.Setup(repo => repo.UpdateBook(_updatebook)).Returns(_updatebook);

            // Act
            var result = _controller.UpdateBook(_updatebook.Id, _updatebook);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Book>(okResult.Value);

            Assert.Equal(_updatebook, returnValue);
        }

        [Fact]
        public void Delete_DeletesEntity()
        {
            var _deleteBook = new Book { Id = 9, Title = "Title 9", Author = "Author 9", Pages = 900 };
            // Arrange
            _bookServicesMock.Setup(repo => repo.DeleteBook(_deleteBook.Id)).Returns(true);
            // Act
            var addbookresult =  _controller.AddBook(_deleteBook);
            var result = _controller.DeleteBook(_deleteBook.Id);

            // Assert
            var noFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.True(noFoundResult.StatusCode is StatusCodes.Status404NotFound);
        }
        private IList<Book> GetBooks() 
        {
            return new List<Book>()
            {
                new Book { Id = 1, Title = "Title 1", Author = "Author 1", Pages = 200 },
                new Book { Id = 2, Title = "Title 2", Author = "Author 2", Pages = 300 },
            };
        }
    }
}