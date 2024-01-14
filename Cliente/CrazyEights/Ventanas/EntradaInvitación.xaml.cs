using CrazyEights.ReferenciaServicioManejoJugadores;
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

namespace CrazyEights.Ventanas
{
    /// <summary>
    /// Interaction logic for EntradaInvitación.xaml
    /// </summary>
    public partial class EntradaInvitación : UserControl
    {
        private Invitacion invitacion;
        private VentanaAmigos ventanaAmigos;

        public EntradaInvitación(Invitacion invitacion)
        {
            InitializeComponent();
            lbNombreJugador.Content = invitacion.NombreJugadorAnfitrion;
            this.invitacion = invitacion;
            Loaded += EntradaInvitacion_Loaded;
        }

        private void UnirseASala(object sender, RoutedEventArgs e)
        {
            ReferenciaServicioManejoJugadores.ServicioSalaClient clienteSala = new ReferenciaServicioManejoJugadores.ServicioSalaClient();
            Sala sala = clienteSala.RecuperarSala(invitacion.CodigoSala);

            ReferenciaServicioManejoJugadores.ServicioInvitacionesClient clienteInvitaciones = new ReferenciaServicioManejoJugadores.ServicioInvitacionesClient();
            clienteInvitaciones.QuitarInvitacionAJugador(SingletonJugador.Instance.NombreJugador, invitacion);

            if (sala.Codigo != 0)
            {
                VentanaSala ventanaSala = new VentanaSala();
                ventanaSala.EntrarASala(sala);

                if (ventanaAmigos != null)
                {
                    ventanaAmigos.Close();
                }

                ventanaAmigos.OcultarInvitacion(invitacion);
                ventanaSala.ShowDialog();
            }
            else
            {
                MessageBox.Show("La sala a la que intenta unirse ya no existe.", "Sala no existe", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void QuitarInvitacion(object sender, RoutedEventArgs e)
        {
            ReferenciaServicioManejoJugadores.ServicioInvitacionesClient clienteInvitaciones = new ReferenciaServicioManejoJugadores.ServicioInvitacionesClient();
            clienteInvitaciones.QuitarInvitacionAJugador(SingletonJugador.Instance.NombreJugador, invitacion);

            ventanaAmigos.OcultarInvitacion(invitacion);
        }

        private void EntradaInvitacion_Loaded(object sender, RoutedEventArgs e)
        {
            this.ventanaAmigos = (VentanaAmigos)Window.GetWindow(this);
        }

        
    }
}
