using System;
using System.Collections.Generic;
using System.Text;

namespace MaiaNegocios.Domain
{
    public class Cidade
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Ibge { get; set; }
        public int EstadoId { get; set; }
        public Estado Estado { get; set; }
    }
}
