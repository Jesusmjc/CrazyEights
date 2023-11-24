using CrazyEights.Ventanas;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CrazyEights
{
    /// <summary>
    /// Interaction logic for VentanaMenuPrincipal.xaml
    /// </summary>
    public partial class VentanaMenuPrincipal : Window
    {
        public VentanaMenuPrincipal()
        {
            InitializeComponent();
            CargarImagenDePerfil();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void CargarImagenDePerfil()
        {
            if (!JugadorCliente.JugadorDeCliente.EsInvitado)
            {
                if (string.IsNullOrEmpty(JugadorCliente.JugadorDeCliente.FotoPerfil))
                {
                    JugadorCliente.JugadorDeCliente.FotoPerfil = "predeterminada"; //ToDo
                }
            }
        }
        private void NavegarAListaAmigos(object sender, MouseButtonEventArgs e)
        {
            VentanaAmigos ventanaAmigos = new VentanaAmigos();
            this.Close();
            ventanaAmigos.ShowDialog();
        }

        private void NavegarAyudaJuego(object sender, MouseButtonEventArgs e)
        {
            VentanaAyudaDeJuego ventanaAyudaDeJuego = new VentanaAyudaDeJuego();
            ventanaAyudaDeJuego.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            ventanaAyudaDeJuego.ShowDialog();
        }

        private void NavegarATienda(object sender, RoutedEventArgs e) //ToDoTemp
        {
            VentanaTiendaDeJuego ventanaTiendaDeJuego = new VentanaTiendaDeJuego();
            ventanaTiendaDeJuego.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            ventanaTiendaDeJuego.ShowDialog();
        }

        private void NavegarAJuego(object sender, RoutedEventArgs e) //ToDoTemp
        {
            VentanaJuegoDeCartas ventanaJuegoDeCartas = new VentanaJuegoDeCartas();
            ventanaJuegoDeCartas.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            ventanaJuegoDeCartas.Show();
            this.Close();
        }

        private void NavegarAMisiones(object sender, MouseButtonEventArgs e)
        {
            VentanaMisionesDeJuego ventanaMisionesDeJuego = new VentanaMisionesDeJuego();
            ventanaMisionesDeJuego.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            ventanaMisionesDeJuego.ShowDialog();
        }

        private void NavegarAPersonalizacionDePerfil(object sender, MouseButtonEventArgs e)
        {
            VentanaPersonalizacionDePerfil ventanaPersonalizacionDePerfil = new VentanaPersonalizacionDePerfil();
            ventanaPersonalizacionDePerfil.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            ventanaPersonalizacionDePerfil.ShowDialog();
        }

        private void CerrarSesion(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(Properties.Resources.msbCerrarSesion, 
                Properties.Resources.ttlCerrarSesion, MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                MainWindow ventanaInicio = new MainWindow();
                ventanaInicio.Show();
                this.Close();
            }
        }
    }
}
