using JSB.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSB.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        IBookRepository BookRepository { get; }
        ICategoryRepository CategoryRepository { get; }

        public bool SaveChanges();
        public Task<bool> SaveChangesAsync();
       

        }
}
