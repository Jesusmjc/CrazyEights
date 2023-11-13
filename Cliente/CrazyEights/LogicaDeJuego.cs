using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyEights
{
    public class LogicaJuego
    {
        public bool SePuedeColocarCarta(Tuple<int, TipoDePalo> CartasJuego, int numeroCarta, TipoDePalo tipoPalo)
        {
            return CartasJuego.Item1 == numeroCarta || CartasJuego.Item2 == tipoPalo || (numeroCarta == 8);
        }
    }
}
