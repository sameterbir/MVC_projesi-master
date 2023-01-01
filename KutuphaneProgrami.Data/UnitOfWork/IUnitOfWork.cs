using KutuphaneProgrami.Data.Migrations.Repositories;
using System;

namespace KutuphaneProgrami.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class;

        int SaveChanges();
    }
}
