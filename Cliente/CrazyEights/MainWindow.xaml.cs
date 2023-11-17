using CrazyEights.ReferenciaServicioManejoJugadores;
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


namespace CrazyEights
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void IniciarSesion(object sender, RoutedEventArgs e)
        {
            if (ValidarCampos())
            {
                ReferenciaServicioManejoJugadores.ServicioManejoJugadoresClient cliente = new ReferenciaServicioManejoJugadores.ServicioManejoJugadoresClient();

                Usuario usuarioAValidar = new Usuario();
                usuarioAValidar.CorreoElectronico = tbxCorreoElectronico.Text;
                usuarioAValidar.Contrasena = Encriptacion.GetSHA256(pwbContrasena.Password);

                bool esInicioSesionValido = false;
                esInicioSesionValido = cliente.ValidarInicioSesion(usuarioAValidar);

                if (esInicioSesionValido)
                {
                    SingletonJugador singletonJugador = SingletonJugador.Instance;
                    singletonJugador.NombreUsuario = 
                    VentanaMenuPrincipal ventanaMenuPrincipal = new VentanaMenuPrincipal();
                    this.Close();
                    ventanaMenuPrincipal.ShowDialog();
                }
                else
                {
                    VentanaAdvertencia ventanaAdvertencia = new VentanaAdvertencia("No fue posible iniciar sesión", "Las credenciales ingresadas no coinciden con ninguna cuenta.");
                    ventanaAdvertencia.ShowDialog();
                }
            }
        }

        private void RecuperarContrasena(object sender, RoutedEventArgs e)
        {
            
        }

        private void NavegarARegistroUsuario(object sender, RoutedEventArgs e)
        {
            RegistroUsuario registroUsuario = new RegistroUsuario();
            registroUsuario.WindowStartupLocation= WindowStartupLocation.CenterScreen;
            this.Close();
            registroUsuario.ShowDialog();
        }

        private bool ValidarCampos()
        {
            bool esCorreoElectronicoValido = false;
            bool esContrasenaValida = false;

            if (!string.IsNullOrEmpty(tbxCorreoElectronico.Text) && !string.IsNullOrEmpty(pwbContrasena.Password))
            {

                if (Utilidades.ValidarCorreoElectronico(tbxCorreoElectronico.Text))
                {
                    esCorreoElectronicoValido = true;
                }
                else
                {
                    lbAdvertenciaCorreoElectronicoInvalido.Visibility = Visibility.Visible;
                }

                if (Utilidades.ValidarContrasena(pwbContrasena.Password))
                {
                    esContrasenaValida = true;
                }
                else
                {
                    lbAdvertenciaContrasenaInvalida.Visibility = Visibility.Visible;
                }
            }

            return esCorreoElectronicoValido && esContrasenaValida;
        }
    }
}
