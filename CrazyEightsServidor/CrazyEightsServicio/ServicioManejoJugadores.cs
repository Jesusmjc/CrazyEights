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
            int numeroCambios = 0;
            numeroCambios = CrazyEights.SaveChanges();

            return numeroCambios;
        }

        public bool ValidarInicioSesion(Usuario usuario)
        {
            using (var context = new CrazyEightsEntities())
            {
                var usuarios = (from us in context.Usuarios
                                where us.correoElectrónico == usuario.CorreoElectronico
                                && us.contraseña == usuario.Contrasena
                                select us).ToList();

                bool esUsuarioValido = false;
                if (usuarios.Count != 0)
                {
                    esUsuarioValido = true;
                }

                return esUsuarioValido;
            }

            
        }

        public bool ValidarNombreUsuarioRegistrado(Jugador jugador)
        {
            bool existeJugador = true;
            using (var contexto = new CrazyEightsEntities())
            {
                var jugadores = (from jug in contexto.Jugadores
                                 where jug.nombreUsuario == jugador.NombreUsuario
                                 select jug).ToList();

                if (jugadores.Count == 0)
                {
                    existeJugador = false;
                }
            }   

            return existeJugador;
        }

        public bool ValidarCorreoElectronicoRegistrado(Usuario usuario)
        {
            bool existeUsuario = true;
            using (var contexto = new CrazyEightsEntities())
            {
                var usuarios = (from us in contexto.Usuarios
                                where us.correoElectrónico == usuario.CorreoElectronico
                                select us).ToList();

                if (usuarios.Count == 0)
                {
                    existeUsuario = false;
                }
            }
            return existeUsuario;
        }
    }
}
