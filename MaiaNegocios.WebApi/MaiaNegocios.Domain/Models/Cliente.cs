using System;
using System.Collections.Generic;
using System.Text;

namespace MaiaNegocios.Domain.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string CpfUser { get; set; }
        public bool FlagActive { get; set; }
        public DateTime? DataRemove { get; set; }
        public DateTime? DataInitial { get; set; }

    }
}
