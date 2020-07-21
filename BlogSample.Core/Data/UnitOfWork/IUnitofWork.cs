using BlogSample.Core.Data.Repositories;
using BlogSample.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSample.Core.Data.UnitOfWork
{
    public interface IUnitofWork
    {
        IRepository<T> GetRepository<T>() where T : Entity<int>;

        int SaveChanges();
    }
}
