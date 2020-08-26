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

    }
}
