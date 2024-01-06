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
        private Window ventanaAmigos;

        public EntradaInvitación(Invitacion invitacion)
        {
            InitializeComponent();
            lbNombreJugador.Content = invitacion.NombreJugadorAnfitrion;
            this.invitacion = invitacion;
            Loaded += EntradaInvitacion_Loaded;
        }

        private void UnirseASala(object sender, RoutedEventArgs e)
        {
            ReferenciaServicioManejoJugadores.ServicioSalaClient cliente = new ReferenciaServicioManejoJugadores.ServicioSalaClient();
            Sala sala = cliente.RecuperarSala(invitacion.CodigoSala);

            VentanaSala ventanaSala = new VentanaSala();
            ventanaSala.EntrarASala(sala);
            if (ventanaAmigos != null)
            {
                ventanaAmigos.Close();
            }
            ventanaSala.ShowDialog();
        }

        private void RechazarInvitacion(object sender, RoutedEventArgs e)
        {

        }

        private void EntradaInvitacion_Loaded(object sender, RoutedEventArgs e)
        {
            ventanaAmigos = Window.GetWindow(this);
        }
    }
}
