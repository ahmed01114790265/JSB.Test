using JSB.Contracts.DTO;
using JSB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSB.Contracts.InterfaceFactory
{
     public interface IBookFactory
    {
        Book CreateBook(BookDTO bookDTO);
        BookDTO CreateBookDTO(Book book);
        void UpdateBook(Book book, BookDTO bookDTO);
        bool ValidateBeforeDelet(Guid bookId, Guid bookDTOId);
    }
}
