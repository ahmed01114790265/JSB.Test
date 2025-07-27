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

        public UnitOfWork(JSBDbContext jSBDbContext)
        {
            JSBDbContext = jSBDbContext;
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
