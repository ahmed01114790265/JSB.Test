using JSB.Contracts.DTO;
using JSB.Contracts.InterfaceFactory;
using JSB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JSB.Application.Factory
{
    public class BookFactory : IBookFactory
    {
        public Book CreateBook(BookDTO bookDTO)
        {
            return new Book()
            {
                Id = Guid.NewGuid(),
                Name = bookDTO.Name,
                Author = bookDTO.Author,
                Description = bookDTO.Description,
                Price = bookDTO.Price,
                Stock = bookDTO.Stock,
                CategoryId = bookDTO.CategoryId
            };
        }
        public BookDTO CreateBookDTO(Book book)
        {
            return new BookDTO()
            {
                Id = book.Id,
                Name = book.Name,
                Author = book.Author,
                Description = book.Description,
                Price = book.Price,
                Stock = book.Stock
            };
        }
        public void UpdateBook(Book book, BookDTO bookDTO)
        {
            book.Name = bookDTO.Name;
            book.Author = bookDTO.Author;
            book.Description = bookDTO.Description;
            book.Price = bookDTO.Price;
            book.Stock = bookDTO.Stock;
        }
        public bool ValidateBeforeDelet(Guid bookId, Guid bookDTOId)
        {
            if (bookId == bookDTOId)
                return true;
            return false;
        }

    }
}
