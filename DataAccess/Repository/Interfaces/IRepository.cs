﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();

        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);

        T GetFirst(Expression<Func<T, bool>> predicate);

        void Add(T item);

        T AddIfNew(T item);

        T AddOrUpdate(T item);

        void Update(T item);

        T Create();

        void Delete(Guid id);

        T FindById(Guid id);

        void Save();
    }
}
