using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KutuphaneProgrami.Data.Migrations.Repositories;

namespace KutuphaneProgrami.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly Context _context;

        public UnitOfWork()
        {
            _context = new Context();
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(_context);
        }

        public int SaveChanges()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool disposed = false; // dikkat et buraya
        protected virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        

       
    }
}
