using DataAccesss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CrazyEightsServicio
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ManejadorJugadores" in both code and config file together.
    public class ManejadorJugadores : IManejadorJugadores
    {
        //To Do
        public int GuardarJugador(Usuario usuario, Jugador jugador)
        {
            Jugadores tablaJugadores = new Jugadores();
            Usuarios tablaUsuarios = new Usuarios();
            CrazyEightsEntities CrazyEights = new CrazyEightsEntities();

            tablaUsuarios.contraseña = Encriptacion.GetSHA256(pwbContrasena.Password);
            tablaUsuarios.correoElectrónico = tbxCorreoElectronico.Text;

            tablaJugadores.nombreUsuario = tbxNombreUsuario.Text;

            CrazyEights.Usuarios.Add(tablaUsuarios);
            CrazyEights.Jugadores.Add(tablaJugadores);

            if (CrazyEights.SaveChanges() > 0)
            {
                VentanaConfirmación ventanaConfirmacion = new VentanaConfirmación();
                ventanaConfirmacion.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                ventanaConfirmacion.Show();
            }
            else
            {
                Console.WriteLine("No funciona");
            }
            return 0;
        }

    }
}
