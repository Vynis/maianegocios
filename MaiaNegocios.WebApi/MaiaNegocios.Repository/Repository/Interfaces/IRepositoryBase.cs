using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MaiaNegocios.Repository.Repository.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Adicionar(TEntity entity);

        void Atualizar(TEntity entity);

        void Remover(TEntity entity);

        Task<bool> SaveChangesAsync();

        Task<TEntity[]> ObterTodos();

        Task<TEntity> ObterPorId(int id);

        Task<TEntity[]> Buscar(Expression<Func<TEntity, bool>> predicado);
    }
}
