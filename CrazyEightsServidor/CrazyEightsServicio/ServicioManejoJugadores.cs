using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;

namespace CrazyEightsServicio
{
    public partial class ServicioManejoJugadores : IServicioManejoJugadores
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

        public string EnviarCodigoAlCorreoDelUsuario(string correoElectronico)
        {
            Random random = new Random();
            string codigoGenerado = random.Next(100000, 999999).ToString("D6");

            var smtpCliente = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("crazyeights63@gmail.com", "yegj ejiq lxlu fvbv"),
                EnableSsl = true,
            };

            var mensajeCorreo = new MailMessage
            {
                From = new MailAddress("crazyeights63@gmail.com"),
                Subject = "Código de Verificación Crazy Eights",
                Body = "Tu código de verificación es: " + codigoGenerado,
                Priority = MailPriority.High,
            };

            mensajeCorreo.To.Add(correoElectronico);
            smtpCliente.Send(mensajeCorreo);

            return codigoGenerado;
        }
    }

    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public partial class ServicioManejoJugadores : IManejadorJugadoresEnLinea
    {
        private static Dictionary<string, IManejadorJugadoresCallback> jugadoresEnLinea = new Dictionary<string, IManejadorJugadoresCallback>();

        public void NotificarNuevaConexionAJugadoresEnLinea(string nombreJugador)
        {
            if(!jugadoresEnLinea.ContainsKey(nombreJugador))
            {
                IManejadorJugadoresCallback canalDeCallbackActualDelJugador = OperationContext.Current.GetCallbackChannel<IManejadorJugadoresCallback>();

                List<string> nombresJugadoresEnLinea = jugadoresEnLinea.Keys.ToList();
                canalDeCallbackActualDelJugador.NotificarJugadoresEnLinea(nombresJugadoresEnLinea);

                jugadoresEnLinea.Add(nombreJugador, canalDeCallbackActualDelJugador);

                foreach (var jugador in jugadoresEnLinea)
                {
                    if (jugador.Key != nombreJugador)
                    {
                        jugador.Value.NotificarLogInJugador(nombreJugador);
                    }
                }

            }
        }

        public void NotificarDesconexionAJugadoresEnLinea(string nombreJugador)
        {
            if (jugadoresEnLinea.ContainsKey(nombreJugador))
            {
                jugadoresEnLinea.Remove(nombreJugador);

                foreach (var jugador in jugadoresEnLinea)
                {
                    jugador.Value.NotificarLogOutJugador(nombreJugador);
                }
            }
        }
    }
}
