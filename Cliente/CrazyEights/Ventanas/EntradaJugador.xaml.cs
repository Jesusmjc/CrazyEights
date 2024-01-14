using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
    public partial class EntradaJugador : UserControl
    {
        private Jugador jugador;
        private string nombreSala;
        private int codigoSala;

        public EntradaJugador() {}
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
            ReferenciaServicioManejoJugadores.ServicioInvitacionesClient cliente = new ReferenciaServicioManejoJugadores.ServicioInvitacionesClient();

            if (cliente.InvitarJugadorASala(SingletonJugador.Instance.NombreJugador, jugador.NombreUsuario, this.codigoSala, this.nombreSala))
            {
                MessageBox.Show("Se ha enviado la invitación correctamente.", "Invitación exitosa", MessageBoxButton.OK, MessageBoxImage.Information);
            } else
            {
                MessageBox.Show("No se ha podido enviar la invitación al jugador.", "Ocurrió un error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
