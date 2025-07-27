using JSB.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSB.Domain.UnitOfWork
{
   public class UnitOfWork : IUnitOfWork
    {
        JSBDbContext JSBDbContext;
       public IBookRepository BookRepository { get; }
       public ICategoryRepository CategoryRepository { get; }

        public UnitOfWork(JSBDbContext jSBDbContext,IBookRepository bookRepository ,ICategoryRepository categoryRepository)
        {
            JSBDbContext = jSBDbContext;
            this.BookRepository = bookRepository;
            this.CategoryRepository = categoryRepository;
        }
        public bool SaveChanges()
        {
            JSBDbContext.SaveChanges();
            return true;    
        }
        public async Task<bool> SaveChangesAsync()
        {
            await JSBDbContext.SaveChangesAsync();
            return true;
        }
        


    }
}
