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

        public Jugador ValidarInicioSesion(Usuario usuario)
        {
            using (var context = new CrazyEightsEntities())
            {
                var usuarios = (from us in context.Usuarios
                                where us.correoElectrónico == usuario.CorreoElectronico
                                && us.contraseña == usuario.Contrasena
                                select us.IDUsuario).ToList();

                Jugador jugador = new Jugador();

                if (usuarios.Count != 0 && !jugadoresEnLinea.ContainsKey(RecuperarInformacionJugador(usuarios[0]).NombreUsuario))
                {
                    jugador = RecuperarInformacionJugador(usuarios[0]);
                }

                return jugador;
            }
        }

        private Jugador RecuperarInformacionJugador(int IdUsuario)
        {
            Jugador jugador = new Jugador();
            using (var context = new CrazyEightsEntities())
            {
                var informacionJugador = (from jug in context.Jugadores
                                         where jug.IDUsuario == IdUsuario
                                         select jug).ToList();

                jugador.IdJugador = informacionJugador[0].IDUsuario;
                jugador.NombreUsuario = informacionJugador[0].nombreUsuario;
                jugador.Monedas = informacionJugador[0].monedas ?? 0;
                jugador.FotoPerfil = informacionJugador[0].fotoPerfil;
            }

            return jugador;
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
        private static Dictionary<string, Jugador> jugadoresEnLinea = new Dictionary<string, Jugador>();
        public void NotificarNuevaConexionAJugadoresEnLinea(Jugador nuevoJugadorEnLinea)
        {
            if (!jugadoresEnLinea.ContainsKey(nuevoJugadorEnLinea.NombreUsuario))
            {
                IManejadorJugadoresCallback canalDeCallbackActualDelJugador = OperationContext.Current.GetCallbackChannel<IManejadorJugadoresCallback>();
                nuevoJugadorEnLinea.CanalCallbackManejadorJugadores = canalDeCallbackActualDelJugador;

                nuevoJugadorEnLinea.Invitaciones = new List<Invitacion>();
                jugadoresEnLinea.Add(nuevoJugadorEnLinea.NombreUsuario, nuevoJugadorEnLinea);

                foreach (var jugadorEnLinea in jugadoresEnLinea)
                {
                    if (!jugadorEnLinea.Key.Equals(nuevoJugadorEnLinea.NombreUsuario))
                    {
                        jugadorEnLinea.Value.CanalCallbackManejadorJugadores.NotificarLogInJugador(nuevoJugadorEnLinea);
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
                    jugador.Value.CanalCallbackManejadorJugadores.NotificarLogOutJugador(nombreJugador);
                }
            }
        }

        public List<Jugador> RecuperarInformacionJugadoresEnLinea()
        {
            List<Jugador> listaNombresJugadores = new List<Jugador>();

            foreach (var jugadorEnLinea in jugadoresEnLinea)
            {
                listaNombresJugadores.Add(jugadorEnLinea.Value);
            }

            return listaNombresJugadores;
        }

        public bool InvitarJugadorASala(string nombreJugadorAnfitrion, string nombreJugadorInvitado, int codigoSala, string nombreSala) 
        {
            bool operacionExitosa = false;

            if (jugadoresEnLinea.ContainsKey(nombreJugadorInvitado))
            {
                Invitacion nuevaInvitacion = new Invitacion
                {
                    NombreJugadorAnfitrion = nombreJugadorAnfitrion,
                    CodigoSala = codigoSala,
                    NombreSala = nombreSala
                };
                jugadoresEnLinea[nombreJugadorInvitado].Invitaciones.Add(nuevaInvitacion);
                jugadoresEnLinea[nombreJugadorInvitado].CanalCallbackManejadorJugadores.RecibirInvitacionASala(nuevaInvitacion);

                operacionExitosa = true;
            }

            return operacionExitosa;
        }

        public List<Invitacion> RecuperarInvitacionesDeJugador(string nombreJugador)
        { 
            List<Invitacion> invitacionesJugador = new List<Invitacion>();

            if (jugadoresEnLinea.ContainsKey(nombreJugador))
            {
                invitacionesJugador = jugadoresEnLinea[nombreJugador].Invitaciones;
            }

            return invitacionesJugador;
        }
    }
}
