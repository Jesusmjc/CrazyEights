using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CrazyEightsServicio
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServicioManejoJugadores" in both code and config file together.
    public class ServicioManejoJugadores : IServicioManejoJugadores
    {
        public int GuardarJugador(Usuario usuario, Jugador jugador)
        {
            Jugadores tablaJugadores = new Jugadores();
            Usuarios tablaUsuarios = new Usuarios();
            CrazyEightsEntities CrazyEights = new CrazyEightsEntities();

            tablaUsuarios.contraseña = usuario.Contrasena;
            tablaUsuarios.correoElectrónico = usuario.CorreoElectronico;

            tablaJugadores.nombreUsuario = jugador.NombreUsuario;

            CrazyEights.Usuarios.Add(tablaUsuarios);
            CrazyEights.Jugadores.Add(tablaJugadores);

            //if (CrazyEights.SaveChanges() > 0)
            //{
            //    VentanaConfirmación ventanaConfirmacion = new VentanaConfirmación();
            //    ventanaConfirmacion.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //    ventanaConfirmacion.Show();
            //}
            //else
            //{
            //    Console.WriteLine("No funciona");
            //}
            int numeroCambios = 0;
            numeroCambios = CrazyEights.SaveChanges();

            return numeroCambios;
        }
    }
}
