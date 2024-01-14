using CrazyEights.ReferenciaServicioManejoJugadores;
using CrazyEights.Ventanas;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
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
        ReferenciaServicioManejoJugadores.ServicioManejoJugadoresClient actualizarCliente = new ServicioManejoJugadoresClient();
        public VentanaMenuPrincipal()
        {
            InitializeComponent();
            CargarImagenDePerfil();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.ResizeMode = ResizeMode.NoResize;
        }

        private void CargarImagenDePerfil()
        {
            if (!SingletonJugador.Instance.EsInvitado)
            {
                if (string.IsNullOrEmpty(SingletonJugador.Instance.FotoPerfil))
                {
                    SingletonJugador singletonJugador = SingletonJugador.Instance;
                    int idJugador = singletonJugador.IdJugador;
                    actualizarCliente.ActualizarFotoPerfil(idJugador, Properties.Settings.Default.FotoPredeterminada);
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

        private void NavegarAConfiguracionPartida(object sender, RoutedEventArgs e)
        {
            VentanaConfiguracionPartida ventanaConfiguracionPartida = new VentanaConfiguracionPartida();
            this.Close();
            ventanaConfiguracionPartida.ShowDialog();
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
            MessageBoxResult resultado = MessageBox.Show(Properties.Resources.msbCerrarSesion,
                Properties.Resources.ttlCerrarSesion, MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (resultado == MessageBoxResult.Yes)
            {
                ReferenciaServicioManejoJugadores.ServicioManejoDesconexionesClient cliente = new ReferenciaServicioManejoJugadores.ServicioManejoDesconexionesClient();
                cliente.NotificarDesconexionJugador(SingletonJugador.Instance.NombreJugador);

                MainWindow ventanaInicio = new MainWindow();
                ventanaInicio.Show();
                this.Close();
            }
        }

        public void MostrarComoJugadorEnLinea()
        {
            ReferenciaServicioManejoJugadores.ManejadorJugadoresEnLineaClient cliente = new ReferenciaServicioManejoJugadores.ManejadorJugadoresEnLineaClient();
            
            Jugador jugador = new Jugador
            {
                IdJugador = SingletonJugador.Instance.IdJugador,
                NombreUsuario = SingletonJugador.Instance.NombreJugador,
                Estado = "Conectado"
            };

            cliente.NotificarNuevaConexionAJugadoresEnLinea(jugador);
        }
    }
}
