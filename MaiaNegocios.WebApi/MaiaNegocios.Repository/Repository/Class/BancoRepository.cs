using MaiaNegocios.Domain.Models;
using MaiaNegocios.Repository.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaiaNegocios.Repository.Repository.Class
{
    public class BancoRepository : RepositoryBase<Banco>, IBancoRepository
    {
        public BancoRepository(DataContext dataContext) : base(dataContext)
        {

        } 
    }
}
