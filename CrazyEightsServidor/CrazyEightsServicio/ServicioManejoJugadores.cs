using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CrazyEightsServicio
{
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

        public bool validarInicioSesion(Usuario usuario)
        {
            using (var context = new CrazyEightsEntities())
            {
                var usuarios = (from us in context.Usuarios
                                where us.correoElectrónico == usuario.CorreoElectronico
                                where us.contraseña == usuario.Contrasena
                                select us).ToList();

                bool esUsuarioValido = false;
                if (usuarios.Count != 0) 
                {
                    esUsuarioValido = true;
                }

                return esUsuarioValido;
            }
        }
    }
}
