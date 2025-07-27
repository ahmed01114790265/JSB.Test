using JSB.Contracts.DTO;
using JSB.Contracts.InterfaceFactory;
using JSB.Contracts.InterfaceService;
using JSB.Contracts.ResultModel;
using JSB.Domain.Repository;
using JSB.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSB.Application.Service
{
    public class BookService : IBookService
    {
        private readonly IBookFactory _bookFactory;
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IBookFactory bookFactory,IUnitOfWork unitOfWork)
        {
            _bookFactory = bookFactory;
            _unitOfWork = unitOfWork;
        }
        public async Task<ResultModel<Guid>>  AddBook(BookDTO bookDTO)
        {

            bool Categorycheck = await _unitOfWork.CategoryRepository.CheckCategoryId(bookDTO.CategoryId);
            if (!Categorycheck)
            {
                return new ResultModel<Guid>()
                {
                    IsValid = false,
                    ErrorMessage = "Category not found"
                };
            }

            var book = _bookFactory.CreateBook(bookDTO);
            _unitOfWork.BookRepository.CreateBook(book);
            await _unitOfWork.SaveChangesAsync();
            return new ResultModel<Guid>()
            {
               IsValid= true,
               Model = book.Id,
            };  
        }
        public async Task<ResultModel<BookDTO>> GetBookById(Guid bookId)
        {
            var book = await _unitOfWork.BookRepository.GetBookById(bookId);
            if (book == null)
            {
                return new ResultModel<BookDTO>()
                {
                    IsValid = false,
                    ErrorMessage = "Book not found"
                };
            }
            var bookDTO = _bookFactory.CreateBookDTO(book);
            return new ResultModel<BookDTO>()
            {
                IsValid = true,
                Model = bookDTO
            };
        }
        public async Task<ResultList<BookDTO>> GetAllBooks()
        {
            var books = await _unitOfWork.BookRepository.GetBooks();
            if (books == null || !books.Any())
            {
                return new ResultList<BookDTO>()
                {
                    IsValid = false,
                    ErrorMessage = "No books found"
                };
            }
            var bookDTOs = books.Select(b => _bookFactory.CreateBookDTO(b)).ToList();
            return new ResultList<BookDTO>()
            {
                IsValid = true,
                ModelList = bookDTOs
            };
        }
        public async Task<ResultModel<bool>> DeleteBook(Guid bookId)
        {
           var book = await _unitOfWork.BookRepository.GetBookById(bookId);
            if (book == null)
            {
                return new ResultModel<bool>()
                {
                    IsValid = false,
                    ErrorMessage = "Book not found"
                };
            }
            await _unitOfWork.BookRepository.DeleteBook(book);
            await _unitOfWork.SaveChangesAsync();
            return new ResultModel<bool>()
            {
                IsValid = true,
                Model = true
            };


        }
        public async Task<ResultModel<Guid>> UpdateBook(BookDTO bookDTO)
        {
            if (!bookDTO.Id.HasValue)
            {
                return new ResultModel<Guid>()
                {
                    IsValid = false,
                    ErrorMessage = "Book ID mismatch"
                };
            }
            var book = await _unitOfWork.BookRepository.GetBookById(bookDTO.Id.Value);
            if (book == null)
            {
                return new ResultModel<Guid>()
                {
                    IsValid = false,
                    ErrorMessage = "Book not found"
                };
            }
            _bookFactory.UpdateBook(book, bookDTO);
            await _unitOfWork.SaveChangesAsync();
            return new ResultModel<Guid>()
            {
                IsValid = true,
                Model = bookDTO.Id.Value
            };
        }
    }
}
