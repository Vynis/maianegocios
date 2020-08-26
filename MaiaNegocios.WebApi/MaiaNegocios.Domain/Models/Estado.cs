using System;
using System.Collections.Generic;
using System.Text;

namespace MaiaNegocios.Domain
{
    public class Estado
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Uf { get; set; }
        public int Ibge { get; set; }
        public string DDD { get; set; }
        public int PaisId { get; set; }
        public Pais Pais { get; set; }
        public List<Cidade> Cidades { get; set; }
    }
}
