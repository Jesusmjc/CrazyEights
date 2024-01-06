using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CrazyEights.ReferenciaServicioManejoJugadores;

namespace CrazyEights.Ventanas
{
    /// <summary>
    /// Interaction logic for EntradaJugador.xaml
    /// </summary>
    public partial class EntradaJugador : UserControl, IManejadorJugadoresEnLineaCallback
    {
        private Jugador jugador;
        private string nombreSala;
        private int codigoSala;

        public EntradaJugador(Jugador jugadorEnLinea)
        {
            InitializeComponent();
            jugador = jugadorEnLinea;
            MostrarInformacionJugador();
        }

        private void MostrarInformacionJugador()
        {
            lbIdJugador.Content = jugador.IdJugador;
            lbNombreJugador.Content = jugador.NombreUsuario;
            lbEstadoJugador.Content = jugador.Estado;
        }

        public void EstablecerInformacionSala(int codigoSala, string nombreSala)
        {
            this.codigoSala = codigoSala;
            this.nombreSala = nombreSala;
        }

        private void InvitarJugadorAPartida(object sender, RoutedEventArgs e)
        {
            InstanceContext contexto = new InstanceContext(this);
            ReferenciaServicioManejoJugadores.ManejadorJugadoresEnLineaClient cliente = new ReferenciaServicioManejoJugadores.ManejadorJugadoresEnLineaClient(contexto);

            cliente.InvitarJugadorASala(SingletonJugador.Instance.NombreJugador, jugador.NombreUsuario, this.codigoSala, this.nombreSala);
        }

        public void NotificarLogInJugador(Jugador nuevoJugadorEnLinea)
        {
            throw new NotImplementedException();
        }

        public void NotificarLogOutJugador(string nombreJugador)
        {
            throw new NotImplementedException();
        }

        public void NotificarJugadoresEnLinea(string[] nombresUsuariosEnLinea)
        {
            throw new NotImplementedException();
        }

        public void RecibirInvitacionASala(Invitacion invitacion)
        {
            throw new NotImplementedException();
        }
    }
}
