using System;
using System.Collections.Generic;
using System.Text;

namespace MaiaNegocios.Domain.Models
{
    public class Plano
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public bool FlagActive { get; set; }
        public DateTime? DateInitial { get; set; }
        public DateTime? DateRemove { get; set; }

        public List<Cliente> Clientes { get; set; }
    }
}
