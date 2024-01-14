using CrazyEights.ReferenciaServicioManejoJugadores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CrazyEights.Ventanas
{
    /// <summary>
    /// Interaction logic for VentanaAmigos.xaml
    /// </summary>
    public partial class VentanaAmigos : Window, IServicioActualizacionJugadoresEnLineaCallback
    {
        private Sala sala = new Sala();
        public ObservableCollection<EntradaJugador> ListaDeJugadoresConectados { get; } = new ObservableCollection<EntradaJugador>();
        public ObservableCollection<EntradaInvitación> ListaDeInvitaciones { get; } = new ObservableCollection<EntradaInvitación>();

        public VentanaAmigos()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.ResizeMode = ResizeMode.NoResize;
            DataContext = this;
            MostrarJugadoresEnLinea();
        }

        public VentanaAmigos(Sala sala)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.ResizeMode = ResizeMode.NoResize;
            DataContext = this;
            this.sala = sala;
            MostrarJugadoresEnLinea();
        }

        public void MostrarJugadoresEnLinea()
        {
            InstanceContext contexto = new InstanceContext(this);
            ReferenciaServicioManejoJugadores.ServicioActualizacionJugadoresEnLineaClient cliente = new ReferenciaServicioManejoJugadores.ServicioActualizacionJugadoresEnLineaClient(contexto);
            Jugador[] jugadoresEnLinea = cliente.RecuperarInformacionJugadoresEnLinea(SingletonJugador.Instance.NombreJugador);

            ListaDeJugadoresConectados.Clear();
            svListaAmigos.Visibility = Visibility.Visible;
            svListaInvitaciones.Visibility = Visibility.Collapsed;

            foreach (var jugadorEnLinea in jugadoresEnLinea)
            {
                if (jugadorEnLinea.NombreUsuario != SingletonJugador.Instance.NombreJugador)
                {
                    MostrarEntradaJugadorEnLinea(jugadorEnLinea);
                }
            }
        }

        private void MostrarInvitaciones(object sender, MouseButtonEventArgs e)
        {
            InstanceContext contexto = new InstanceContext(this);
            ReferenciaServicioManejoJugadores.ServicioActualizacionJugadoresEnLineaClient cliente = new ReferenciaServicioManejoJugadores.ServicioActualizacionJugadoresEnLineaClient(contexto);
            Invitacion[] invitacionesDelJugador = cliente.RecuperarInvitacionesDeJugador(SingletonJugador.Instance.NombreJugador);

            ListaDeInvitaciones.Clear();
            svListaAmigos.Visibility = Visibility.Collapsed;
            svListaInvitaciones.Visibility = Visibility.Visible;

            foreach (var invitacion in invitacionesDelJugador)
            {
                MostrarEntradaInvitacionDeJugador(invitacion);
            }
        }

        private void MostrarEntradaJugadorEnLinea(Jugador jugadorEnLinea)
        {
            EntradaJugador entradaJugadorConectado = new EntradaJugador(jugadorEnLinea);

            if (this.sala.Codigo == 0)
            {
                entradaJugadorConectado.btnInvitarAPartida.Visibility = Visibility.Hidden;
            }
            else
            {
                entradaJugadorConectado.EstablecerInformacionSala(this.sala.Codigo, this.sala.Nombre);
            }
            ListaDeJugadoresConectados.Add(entradaJugadorConectado);
        }

        private void MostrarEntradaInvitacionDeJugador(Invitacion invitacion)
        {
            EntradaInvitación entradaInvitacion = new EntradaInvitación(invitacion);

            ListaDeInvitaciones.Add(entradaInvitacion);
        }

        public void NotificarLogInJugador(Jugador nuevoJugador)
        {
            MostrarEntradaJugadorEnLinea(nuevoJugador);
        }

        public void NotificarLogOutJugador(string nombreJugador)
        {
            EntradaJugador jugadorARemover = new EntradaJugador();
            foreach (var jugadorConectado in ListaDeJugadoresConectados)
            {
                if (jugadorConectado.lbNombreJugador.Content.Equals(nombreJugador))
                {
                    jugadorARemover = jugadorConectado;
                }
            }

            ListaDeJugadoresConectados.Remove(jugadorARemover);
        }

        public void RecibirInvitacionASala(Invitacion invitacion)
        {
            MostrarEntradaInvitacionDeJugador(invitacion);
        }

        private void CerrarVentanaAmigos(object sender, MouseButtonEventArgs e)
        {
            if (this.sala.Codigo == 0)
            {
                VentanaMenuPrincipal ventanaMenuPrincipal = new VentanaMenuPrincipal();
                this.Close();
                ventanaMenuPrincipal.ShowDialog();
            }
            else
            {
                VentanaSala ventanaSala = new VentanaSala();
                ventanaSala.EntrarASala(this.sala);
                this.Close();
                ventanaSala.ShowDialog();
            }
        }

        public void OcultarInvitacion(Invitacion invitacion)
        {
            EntradaInvitación invitacionAOcultar = new EntradaInvitación(invitacion);
            ListaDeInvitaciones.Remove(invitacionAOcultar);
        }

        private void CambiarAListaAmigos(object sender, MouseButtonEventArgs e)
        {
            MostrarJugadoresEnLinea();
        }
    }
}
