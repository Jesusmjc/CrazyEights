using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class JugadorDataAccess
    {
        public void GuardarJugador(Usuario usuario, Jugador jugador)
        {
            using (var contexto = new CrazyEightsEntities())
            {
                var nuevoUsuario = contexto.Usuarios.Add(usuario);
                var nuevoJugador = contexto.Jugadores.Add(jugador);
            }
        }
        
    }
}
