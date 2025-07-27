using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSB.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        public bool SaveChanges();
        public Task<bool> SaveChangesAsync();


    }
}
