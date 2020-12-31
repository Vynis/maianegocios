using System;
using System.Collections.Generic;
using System.Text;

namespace MaiaNegocios.Domain.Models
{
    public class Banco
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Status { get; set; }

    }
}
