using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for EntradaJugador.xaml
    /// </summary>
    public partial class EntradaJugador : UserControl
    {
        private string nombreJugador;
        private string idJugador;
        private string estadoJugador;

        public EntradaJugador(string nombreJugador, string idJugador, string estadoJugador)
        {
            InitializeComponent();
            lbNombreJugador.Content = nombreJugador;
            lbIdJugador.Content = idJugador;
            lbEstadoJugador.Content = estadoJugador;
        }

        private void EnviarMensaje(object sender, RoutedEventArgs e)
        {

        }

        private void InvitarJugadorAPartida(object sender, RoutedEventArgs e)
        {

        }
    }
}
