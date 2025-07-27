using JSB.Contracts.DTO;
using JSB.Contracts.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSB.Contracts.InterfaceService
{
    public interface IBookService
    {
        Task<ResultModel<Guid>> AddBook(BookDTO bookDTO);
        Task<ResultModel<BookDTO>> GetBookById(Guid bookId);
        Task<ResultList<BookDTO>> GetAllBooks();
        Task<ResultModel<Guid>> UpdateBook(BookDTO bookDTO);
        Task<ResultModel<bool>> DeleteBook(Guid bookId);
    }
}
