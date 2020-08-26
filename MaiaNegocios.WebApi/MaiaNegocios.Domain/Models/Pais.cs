using System;
using System.Collections.Generic;
using System.Text;

namespace MaiaNegocios.Domain
{
    public class Pais
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NamePt { get; set; }
        public string Initials { get; set; }
        public int Bacen { get; set; }
        public string Image { get; set; }
        public List<Estado> Estados { get; set; }
    }
}
