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
using System.Data.Entity.Infrastructure;
using System.Runtime.Remoting.Contexts;

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

        public bool ActualizarFotoPerfil(int idJugador, string nuevaDireccionFotoPerfil)
        {
            bool resultado = false;
            try
            {
                using (var contexto = new CrazyEightsEntities())
                {
                    var jugador = contexto.Jugadores.FirstOrDefault(j => j.IDJugador == idJugador);

                    if (jugador != null)
                    {
                        jugador.fotoPerfil = nuevaDireccionFotoPerfil;
                        contexto.SaveChanges();
                        resultado = true;
                    }

                    return resultado;
                }
            }
            catch (Exception ex)
            {
                return resultado;
            }
        }

        public string ObtenerDireccionFotoPerfil(int idJugador)
        {
            using (var contexto = new CrazyEightsEntities())
            {
                var jugador = contexto.Jugadores.FirstOrDefault(j => j.IDUsuario == idJugador);

                if (jugador != null && !string.IsNullOrEmpty(jugador.fotoPerfil))
                {
                    return jugador.fotoPerfil;
                }

                return null;
            }
        }

        public bool ActualizarNombreUsuario(int idJugador, string nuevoNombreUsuario)
        {
            bool resultado = false;
            try
            {
                using (var contexto = new CrazyEightsEntities())
                {
                    var nombreUsuarioExistente = contexto.Jugadores.Any(j => j.nombreUsuario == nuevoNombreUsuario && j.IDJugador != idJugador);

                    if (nombreUsuarioExistente)
                    {
                        return resultado;
                    }

                    var jugador = contexto.Jugadores.FirstOrDefault(j => j.IDJugador == idJugador);

                    if (jugador != null)
                    {
                        jugador.nombreUsuario = nuevoNombreUsuario;
                        contexto.SaveChanges();
                        resultado = true;
                    }
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                return resultado;
            }

        }

        public string ObtenerNombreUsuario(int idJugador) //ToDo
        {
            using (var contexto = new CrazyEightsEntities())
            {
                var jugador = contexto.Jugadores.FirstOrDefault(j => j.IDUsuario == idJugador);

                if (jugador != null && !string.IsNullOrEmpty(jugador.nombreUsuario))
                {
                    return jugador.nombreUsuario;
                }
                return null;
            }
        }

        public bool CambiarContraseña(string correoElectronico, string nuevaContraseña)
        {
            bool resultado = false;
            try
            {
                using (var contexto = new CrazyEightsEntities())
                {
                    var usuario = contexto.Usuarios.FirstOrDefault(u => u.correoElectrónico == correoElectronico);

                    if (usuario != null)
                    {
                        usuario.contraseña = nuevaContraseña;
                        contexto.SaveChanges();
                        resultado = true;
                    }
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                return resultado;
            }
        }
    }

    public partial class ServicioManejoJugadores : IServicioManejoDesconexiones
    {
        public void NotificarDesconexionJugador(string nombreJugadorDesconectado)
        {
            if (jugadoresEnLinea.ContainsKey(nombreJugadorDesconectado))
            {
                if (jugadoresEnLinea.Remove(nombreJugadorDesconectado))
                {
                    foreach (var jugadorEnLinea in jugadoresEnLinea)
                    {
                        if (jugadorEnLinea.Value.CanalCallbackActualizacionJugadores != null)
                        {
                            jugadorEnLinea.Value.CanalCallbackActualizacionJugadores.NotificarLogOutJugador(nombreJugadorDesconectado);
                        }
                    }
                }
            }
        }
    }

    [ServiceBehavior]
    public partial class ServicioManejoJugadores : IManejadorJugadoresEnLinea
    {
        private static Dictionary<string, Jugador> jugadoresEnLinea = new Dictionary<string, Jugador>();

        public void NotificarNuevaConexionAJugadoresEnLinea(Jugador nuevoJugadorEnLinea)
        {
            if (!jugadoresEnLinea.ContainsKey(nuevoJugadorEnLinea.NombreUsuario))
            {
                nuevoJugadorEnLinea.Invitaciones = new List<Invitacion>();
                jugadoresEnLinea.Add(nuevoJugadorEnLinea.NombreUsuario, nuevoJugadorEnLinea);

                foreach (var jugadorEnLinea in jugadoresEnLinea)
                {
                    if (!jugadorEnLinea.Key.Equals(nuevoJugadorEnLinea.NombreUsuario) && jugadorEnLinea.Value.CanalCallbackActualizacionJugadores != null)
                    {
                        jugadorEnLinea.Value.CanalCallbackActualizacionJugadores.NotificarLogInJugador(nuevoJugadorEnLinea);
                    }
                }

            }
        }
    }

    public partial class ServicioManejoJugadores : IServicioInvitaciones
    {
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

                if (!jugadoresEnLinea[nombreJugadorInvitado].Invitaciones.Contains(nuevaInvitacion))
                {
                    jugadoresEnLinea[nombreJugadorInvitado].Invitaciones.Add(nuevaInvitacion);
                    if (jugadoresEnLinea[nombreJugadorInvitado].CanalCallbackActualizacionJugadores != null)
                    {
                        jugadoresEnLinea[nombreJugadorInvitado].CanalCallbackActualizacionJugadores.RecibirInvitacionASala(nuevaInvitacion);
                    }
                }

                operacionExitosa = true;
            }

            return operacionExitosa;
        }

        public void QuitarInvitacionAJugador(string nombreJugador, Invitacion invitacionAQuitar)
        {
            Invitacion invitacionAux = new Invitacion();

            foreach (Invitacion invitacion in jugadoresEnLinea[nombreJugador].Invitaciones)
            {
                if (invitacion.NombreSala.Equals(invitacionAQuitar.NombreSala) && invitacion.NombreJugadorAnfitrion.Equals(invitacionAQuitar.NombreJugadorAnfitrion))
                {
                    invitacionAux = invitacion;
                }
            }

            jugadoresEnLinea[nombreJugador].Invitaciones.Remove(invitacionAux);
        }
    }

    public partial class ServicioManejoJugadores : IServicioActualizacionJugadoresEnLinea
    {
        public List<Jugador> RecuperarInformacionJugadoresEnLinea(string nombreJugador)
        {
            IServicioActualizacionJugadoresEnLineaCallback canalDeCallbackDelJugador = OperationContext.Current.GetCallbackChannel<IServicioActualizacionJugadoresEnLineaCallback>();
            jugadoresEnLinea[nombreJugador].CanalCallbackActualizacionJugadores = canalDeCallbackDelJugador;

            List<Jugador> listaNombresJugadores = new List<Jugador>();
            foreach (var jugadorEnLinea in jugadoresEnLinea)
            {
                if (!jugadorEnLinea.Value.NombreUsuario.Equals(nombreJugador))
                {
                    listaNombresJugadores.Add(jugadorEnLinea.Value);
                }  
            }

            return listaNombresJugadores;
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
