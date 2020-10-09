using Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DataAccess.Repository.Abstractions
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();

        IEnumerable<T> Find(Func<T, bool> predicate);

        T GetById(int id);

        void Create(T entity);

        List<T> CreateMultiple(List<T> entity);

        T CreateAndReturn(T entity);

        void Update(T entity);

        void Delete(T entity);

        int Count(Func<T, bool> predicate);

        List<T> ToList();
    }
}
