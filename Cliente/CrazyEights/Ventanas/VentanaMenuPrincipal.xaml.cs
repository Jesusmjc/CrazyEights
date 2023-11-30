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
    public partial class VentanaMenuPrincipal : Window, IManejadorJugadoresEnLineaCallback
    {
        ReferenciaServicioManejoJugadores.ServicioManejoJugadoresClient actualizarCliente = new ServicioManejoJugadoresClient();
        public VentanaMenuPrincipal()
        {
            InitializeComponent();
            CargarImagenDePerfil();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.ResizeMode = ResizeMode.NoResize;
            MostrarComoJugadorEnLinea();
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

        private void MostrarComoJugadorEnLinea()
        {
            InstanceContext contexto = new InstanceContext(this);
            ReferenciaServicioManejoJugadores.ManejadorJugadoresEnLineaClient cliente = new ReferenciaServicioManejoJugadores.ManejadorJugadoresEnLineaClient(contexto);
            Jugador jugador = new Jugador
            {
                IdJugador = SingletonJugador.Instance.IdJugador,
                NombreUsuario = SingletonJugador.Instance.NombreJugador,
                Estado = "Conectado"
            };

            cliente.NotificarNuevaConexionAJugadoresEnLinea(jugador);
        }

        //Es necesario implementarlos para ejecutar la línea 43, pero no hacen nada en esta ventana.
        public void NotificarLogInJugador(Jugador jugador)
        {
            Console.WriteLine("Se ha conectado un nuevo usuario: " + jugador.NombreUsuario);
        }

        public void NotificarLogOutJugador(string username)
        {
            throw new NotImplementedException();
        }

        public void NotificarJugadoresEnLinea(string[] nombresUsuariosEnLinea)
        {
            throw new NotImplementedException();
        }
    }
}
