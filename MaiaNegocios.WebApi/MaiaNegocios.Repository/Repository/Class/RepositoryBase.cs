using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MaiaNegocios.Repository.Repository.Interfaces;

namespace MaiaNegocios.Repository.Repository.Class
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly DataContext _dataContext;

        public RepositoryBase(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public virtual void Adicionar(TEntity entity)
        {
            _dataContext.Add(entity);
        }

        public virtual void Atualizar(TEntity entity)
        {
            _dataContext.Update(entity);
        }

        public virtual void Remover(TEntity entity)
        {
            _dataContext.Remove(entity);
        }

        public virtual async Task<TEntity[]> Buscar(Expression<Func<TEntity, bool>> predicado)
        {
            return await _dataContext.Set<TEntity>().Where(predicado).ToArrayAsync();
        }

        public virtual async Task<TEntity> ObterPorId(int id)
        {
            return await _dataContext.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<TEntity[]> ObterTodos()
        {
            return await _dataContext.Set<TEntity>().ToArrayAsync();
        }

    }
}
