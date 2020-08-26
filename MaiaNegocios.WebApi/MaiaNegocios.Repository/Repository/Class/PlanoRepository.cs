using System;
using System.Collections.Generic;
using System.Text;
using MaiaNegocios.Domain.Models;
using MaiaNegocios.Repository.Repository.Interfaces;

namespace MaiaNegocios.Repository.Repository.Class
{
    public class PlanoRepository : RepositoryBase<Plano>, IPlanoRepository
    {
        public PlanoRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
