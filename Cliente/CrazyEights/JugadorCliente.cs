using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyEights
{
    public class JugadorCliente
    {
        //Singletone
        public static JugadorCliente JugadorDeCliente { get; set; }
        //
        public int IdUsuario { get; set; }
        public int IdJugador { get ; set; }
        public string NombreUsuario { get; set; }
        public string FotoPerfil { get; set; }
        public bool EsInvitado { get; set; }
    }
}
