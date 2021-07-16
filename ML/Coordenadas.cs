using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Coordenadas
    {
        public int IdCoordenada { get; set; }
        public string Estante { get; set; }
        public string Sala { get; set; }
        public string Librero { get; set; }
        public int Posicion{ get; set; }
        public List<object> CoordenadasList { get; set; }
    }
}
