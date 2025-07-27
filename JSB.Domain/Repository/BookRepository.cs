using JSB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JSB.Domain.Repository;
using JSB.Domain.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace JSB.Domain.Repository
{
    public class BookRepository : IBookRepository
    {
       JSBDbContext _context;

        public BookRepository(JSBDbContext context)
        {
            _context = context;
        }
        public void CreateBook(Book book)
        {
            _context.Books.Add(book);
        }
        public async Task<Book> GetBookById(Guid BookId)
        {
            return await _context.Books.FirstOrDefaultAsync(x=> x.Id == BookId);
        }   

        public async Task<List<Book>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }
        public async Task DeleteBook(Book book)
        {
             _context.Books.Remove(book);   
        }

    }
}
