using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MaiaNegocios.Domain.Models;
using MaiaNegocios.Repository.Repository.Interfaces;

namespace MaiaNegocios.Repository.Repository.Class
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        private readonly DataContext _dataContext;

        public ClienteRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public override async Task<Cliente[]> ObterTodos()
        {
            IQueryable<Cliente> query = _dataContext.Clientes.Include(c => c.Plano);

            return await query.AsNoTracking().ToArrayAsync();
        }

        public override async Task<Cliente> ObterPorId(int id)
        {
            IQueryable<Cliente> query = _dataContext.Clientes.Include(c => c.Plano);

            return await query.AsNoTracking().OrderBy(c => c.Id).Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public override async Task<Cliente[]> Buscar(Expression<Func<Cliente, bool>> predicado)
        {
            IQueryable<Cliente> query = _dataContext.Clientes.Include(c => c.Plano);

            return await query.AsNoTracking().ToArrayAsync();
        }
    }
}
