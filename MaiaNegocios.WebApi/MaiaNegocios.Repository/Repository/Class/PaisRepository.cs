using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MaiaNegocios.Domain;
using MaiaNegocios.Repository.Repository.Interfaces;

namespace MaiaNegocios.Repository.Repository.Class
{
    public class PaisRepository : RepositoryBase<Pais>, IPaisRepository
    {
        public PaisRepository(DataContext dataContext) : base(dataContext)
        {
        }

    }
}
