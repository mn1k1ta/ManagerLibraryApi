﻿using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity>
       where TEntity : class
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _entities;

        public BaseRepository(DbContext context)
        {
            _context = context;
            _entities = _context.Set<TEntity>();
        }
        public void Create(TEntity entity)
        {
            _entities.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _entities.AsNoTracking();
        }

        public async Task<ICollection<TEntity>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }
      

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _entities.FindAsync(id);
        }

        public IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> expression)
        {
            return _entities.AsNoTracking().Where(expression);
        }

        public async Task<ICollection<TEntity>> GetWhereAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await GetWhere(expression).ToListAsync();
        }

        public void Update(TEntity entity)
        {
            _context.Attach(entity).State = EntityState.Modified;
        }
    }
}
