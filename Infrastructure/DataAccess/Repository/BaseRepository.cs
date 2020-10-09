using Core.Model;
using Infrastructure.DataAccess.DataContext;
using Infrastructure.DataAccess.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.DataAccess.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        protected void SaveAsync() => _context.SaveChangesAsync();

        protected void Save() => _context.SaveChanges();

        public int Count(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate).Count();
        }

        public void Create(T entity)
        {
            _context.Add(entity);
            Save();
        }

        public T CreateAndReturn(T entity)
        {
            Create(entity);

            return entity;
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);

            Save();
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> ToList()
        {
            return _context.Set<T>().ToList<T>();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            Save();
        }

        public List<T> CreateMultiple(List<T> entity)
        {
            _context.Set<T>().AddRange(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
