using CrazyEights.ManejadorJugadoresServicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CrazyEights
{
    /// <summary>
    /// Interaction logic for RegistroUsuario.xaml
    /// </summary>
    public partial class RegistroUsuario : Window
    {
        public RegistroUsuario()
        {
            InitializeComponent();
        }

        private void GuardarInformaciónUsuario(object sender, RoutedEventArgs e)
        {
            if (tbxNombreUsuario.Text != "" && tbxCorreoElectronico.Text != "" && pwbContrasena.Password != "")
            {
                lblAdvertenciaCamposVacios.Visibility = Visibility.Hidden;

                bool esNombreUsuarioValido = false;
                bool esContrasenaValida = false;
                bool esCorreoElectronicoValido = false;

                esNombreUsuarioValido = ValidarNombreUsuario();
                esContrasenaValida = ValidarContrasena();
                esCorreoElectronicoValido = ValidarCorreoElectronico();

                if (esNombreUsuarioValido && esContrasenaValida && esCorreoElectronicoValido)
                {
                    ManejadorJugadoresServicio.ManejadorJugadoresClient cliente = new ManejadorJugadoresServicio.ManejadorJugadoresClient();

                    int cambiosGuardados = 0;

                    Usuario usuario = new Usuario();
                    usuario.Contrasena = Encriptacion.GetSHA256(pwbContrasena.Password);
                    usuario.CorreoElectronico = tbxCorreoElectronico.Text;

                    Jugador jugador = new Jugador();
                    jugador.NombreUsuario = tbxNombreUsuario.Text;

                    cambiosGuardados = cliente.GuardarJugador(usuario, jugador);
                }
            }
            else
            {
                lblAdvertenciaCamposVacios.Visibility = Visibility.Visible;
            }
        }

        private void NavegarAIniciarSesión(object sender, RoutedEventArgs e)
        {
            MainWindow inicioSesión = new MainWindow();
            inicioSesión.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            inicioSesión.Show();
            this.Close();
        }

        private void EntrarComoInvitado(object sender, RoutedEventArgs e)
        {

        }

        private bool ValidarNombreUsuario()
        {
            bool esNombreUsuarioValido = false;
            if (tbxNombreUsuario.Text.Length >= 6)
            {
                esNombreUsuarioValido = true;
                lblAdvertenciaNombreUsuarioInvalido.Visibility = Visibility.Hidden;
            }
            else
            {
                lblAdvertenciaNombreUsuarioInvalido.Visibility = Visibility.Visible;
            }

            return esNombreUsuarioValido;
        }

        private bool ValidarContrasena()
        {
            bool esContrasenaValida = false;
            if (Regex.IsMatch(pwbContrasena.Password, "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[$@$!%*?&#.$($)\\-_])[A-Za-z\\d$@$!%*?&#.$($)\\-_]{8,16}$"))
            {
                esContrasenaValida = true;
                lblAdvertenciaContrasenaInvalida.Visibility = Visibility.Hidden;
            }
            else
            {
                lblAdvertenciaContrasenaInvalida.Visibility = Visibility.Visible;
            }

            return esContrasenaValida;
        }

        private bool ValidarCorreoElectronico()
        {
            bool esCorreoValido = false;
            if (Regex.IsMatch(tbxCorreoElectronico.Text, "^[a-zA-Z0-9\\-_]{5,20}@(gmail|outlook|hotmail)\\.com$"))
            {
                esCorreoValido = true;
                lblAdvertenciaCorreoInvalido.Visibility = Visibility.Hidden;
            }
            else
            {
                lblAdvertenciaCorreoInvalido.Visibility = Visibility.Visible;
            }

            return esCorreoValido;
        }
    }
}
