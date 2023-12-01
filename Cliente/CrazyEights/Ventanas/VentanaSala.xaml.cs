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
using System.Windows.Shapes;
using CrazyEights.ReferenciaServicioManejoJugadores;

namespace CrazyEights.Ventanas
{
    /// <summary>
    /// Interaction logic for VentanaSala.xaml
    /// </summary>
    public partial class VentanaSala : Window
    {
        public VentanaSala()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.ResizeMode = ResizeMode.NoResize;
            Jugador jugadorEnSala1 = new Jugador
            {
                NombreUsuario = "jesusManuel2"
            };
            Jugador jugadorEnSala2 = new Jugador
            {
                NombreUsuario = "alvaro3"
            };
            Jugador jugadorEnSala3 = new Jugador
            {
                NombreUsuario = "elrevo"
            };
            
            JugadorSala jugadorSala1 = new JugadorSala(jugadorEnSala1);
            JugadorSala jugadorSala2 = new JugadorSala(jugadorEnSala2);
            JugadorSala jugadorSala3 = new JugadorSala(jugadorEnSala3);
            //JugadorSala jugadorSala4 = new JugadorSala();
            gridJugadorSala1.Children.Add(jugadorSala1);
            gridJugadorSala2.Children.Add(jugadorSala2);
            gridJugadorSala3.Children.Add(jugadorSala3);
            //gridJugadorSala4.Children.Add(jugadorSala4);
        }

        private void AbrirListaAmigos(object sender, MouseButtonEventArgs e)
        {

        }

        private void NavegarAMenuPrincipal(object sender, MouseButtonEventArgs e)
        {
            VentanaMenuPrincipal ventanaMenuPrincipal = new VentanaMenuPrincipal();
            this.Close();
            ventanaMenuPrincipal.ShowDialog();
        }

        private void NavegarAConfiguracionPartida(object sender, MouseButtonEventArgs e)
        {
            VentanaConfiguracionPartida ventanaConfiguracionPartida = new VentanaConfiguracionPartida();
            this.Close();
            ventanaConfiguracionPartida.ShowDialog();
        }
    }
}
