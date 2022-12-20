using Dev.Bussines.Interfaces;
using Dev.Data.Context;
using Microsoft.EntityFrameworkCore;
using MinhaAp.Busines.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly MeuDbContext _context;
        protected readonly DbSet<TEntity> _entities;

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await _entities.AsNoTracking().Where(predicate).ToListAsync();
        }
        public async Task<TEntity> ObterPorId(Guid id)
        {
            return await _entities.FirstAsync()
        }

        public async Task<List<TEntity>> ObterTodos()
        {
            throw new NotImplementedException();
        }
        public async Task Adicionar(TEntity entity)
        {
            _entities.Add(entity);
            await SaveChanges();
        }

        public async Task Atualizar(TEntity entity)
        {
            throw new NotImplementedException();
        }       

        public async Task Deletar(Guid id)
        {
            throw new NotImplementedException();
        }                

        public async Task<int> SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
