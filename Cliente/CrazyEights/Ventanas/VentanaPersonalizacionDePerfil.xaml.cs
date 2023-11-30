using CrazyEights.ReferenciaServicioManejoJugadores;
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
using System.Xml.Linq;

namespace CrazyEights.Ventanas
{
    /// <summary>
    /// Interaction logic for VentanaPersonalizacionDePerfil.xaml
    /// </summary>
    public partial class VentanaPersonalizacionDePerfil : Window
    {
        ReferenciaServicioManejoJugadores.ServicioManejoJugadoresClient actualizarCliente = new ReferenciaServicioManejoJugadores.ServicioManejoJugadoresClient();
        private String _recursoDeImagen = "";

        public VentanaPersonalizacionDePerfil()
        {
            InitializeComponent();
            CargarRecursos();
            CargarInformacionDeJugador();
        }

        private void CargarRecursos()
        {
            lstbSeleccionarImagen.Items.Add("catRunner");
            lstbSeleccionarImagen.Items.Add("amogus");
            lstbSeleccionarImagen.Items.Add("gatoEnojado");
            lstbSeleccionarImagen.Items.Add("godzilla");
            lstbSeleccionarImagen.Items.Add("jacket");
            lstbSeleccionarImagen.Items.Add("perry");
        }

        private void CargarInformacionDeJugador() //ToDo
        {
            SingletonJugador singletonJugador = SingletonJugador.Instance;
            int idJugador = singletonJugador.IdJugador;

            string direccionFotoPerfilActual = actualizarCliente.ObtenerDireccionFotoPerfil(idJugador);
            string nombreUsuario = actualizarCliente.ObtenerNombreUsuario(idJugador);
            string correoElectronico = singletonJugador.CorreoElectronico;

            if (direccionFotoPerfilActual != null)
            {
                Bitmap imagenPerfil = (Bitmap)Properties.ResourcesDePerfil.ResourceManager.GetObject(direccionFotoPerfilActual);

                BitmapSource imagenPerfilBitmap = Imaging.CreateBitmapSourceFromHBitmap(
                    imagenPerfil.GetHbitmap(),
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions()
                );

                imgFotoPerfil.Source = imagenPerfilBitmap;
                lbNombreDeJugador.Content = nombreUsuario;
                lbCorreoElectronico.Content = correoElectronico;
            }
            else
            {
                MessageBox.Show(Properties.Resources.msbNoSePudoRecuperarInformacion, Properties.Resources.ttlNoSePudoRecuperarInformacion, MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void SeleccionarImagen(object sender, SelectionChangedEventArgs e) 
        {
            if (lstbSeleccionarImagen.SelectedItem != null)
            {

                Bitmap imagenPerfil = (Bitmap)Properties.ResourcesDePerfil.ResourceManager.GetObject(lstbSeleccionarImagen.SelectedItem.ToString());

                BitmapSource imagenPerfilBitmap = Imaging.CreateBitmapSourceFromHBitmap(imagenPerfil.GetHbitmap(),
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions()
                    );   

                imgFotoPerfil.Source = imagenPerfilBitmap;
                _recursoDeImagen = lstbSeleccionarImagen.SelectedItem.ToString();
            }
        }

        private void CerrarVentana(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void GuardarCambiosDePerfil(object sender, RoutedEventArgs e)
        {
            SingletonJugador singletonJugador = SingletonJugador.Instance;
            int idJugador = singletonJugador.IdJugador;
            string nuevaDireccionFotoPerfil = _recursoDeImagen;
            string nuevoNombreUsuario = tbxNombreUsuario.Text;

            if (!String.IsNullOrWhiteSpace(nuevaDireccionFotoPerfil) && !String.IsNullOrWhiteSpace(nuevoNombreUsuario))
            {
                if (actualizarCliente.ActualizarNombreUsuario(idJugador, nuevoNombreUsuario) && Utilidades.ValidarNombreUsuario(nuevoNombreUsuario))
                {
                    actualizarCliente.ActualizarFotoPerfil(idJugador, nuevaDireccionFotoPerfil);
                    MessageBox.Show(Properties.Resources.msbDatosCambiados, Properties.Resources.ttlDatosCambiados, MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show(Properties.Resources.msbNombreDeUsuarioExistente, Properties.Resources.ttlNombreDeUsuarioExistente, MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else if (!String.IsNullOrWhiteSpace(nuevaDireccionFotoPerfil))
            {
                actualizarCliente.ActualizarFotoPerfil(idJugador, nuevaDireccionFotoPerfil);
                MessageBox.Show(Properties.Resources.msbFotoCambiada, Properties.Resources.ttlFotoCambiada, MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (!String.IsNullOrWhiteSpace(nuevoNombreUsuario) && Utilidades.ValidarNombreUsuario(nuevoNombreUsuario))
            {
                if (actualizarCliente.ActualizarNombreUsuario(idJugador, nuevoNombreUsuario))
                {
                    MessageBox.Show(Properties.Resources.msbNombreUsuarioCambiado, Properties.Resources.ttlNombreUsuarioCambiado, MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show(Properties.Resources.msbNombreDeUsuarioExistente, Properties.Resources.ttlNombreDeUsuarioExistente, MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show(Properties.Resources.msbDatosNoCambiados, Properties.Resources.ttlDatosNoCambiados, MessageBoxButton.OK, MessageBoxImage.Information);
            }
            VentanaPersonalizacionDePerfil ventanaPersonalizacionDePerfil = new VentanaPersonalizacionDePerfil();
            ventanaPersonalizacionDePerfil.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            ventanaPersonalizacionDePerfil.ShowDialog();
            this.Close();
        }

        private void EditarContraseña(object sender, RoutedEventArgs e)
        {
            VentanaConfigurarContraseña ventanaEdtiarContraseña = new VentanaConfigurarContraseña();
            ventanaEdtiarContraseña.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            ventanaEdtiarContraseña.ShowDialog();
        }
    }
}
