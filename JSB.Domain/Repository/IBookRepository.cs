using JSB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSB.Domain.Repository
{
   public interface IBookRepository
    {
       void CreateBook(Book book);
        Task<Book> GetBookById(Guid BookId);
        Task<List<Book>> GetBooks();
        Task DeleteBook(Book book);

    }
}
