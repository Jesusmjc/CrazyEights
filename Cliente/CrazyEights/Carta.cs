using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyEights
{
    public class Carta
    {
        public string Nombre { get; set; }

        public int NumeroDeCarta { get; set; }

        public TipoDePalo TipoDePalo { get; set; }

        public string DireccionImagen { get; set; }
    }

    public enum TipoDePalo
    {
        Corazon,
        Pica,
        Trebol,
        Diamante
    }
}
