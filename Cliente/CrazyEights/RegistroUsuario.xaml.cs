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
                bool esNombreUsuarioValido = false;
                bool esContrasenaValida = false;
                bool esCorreoValido = false;

                if (tbxNombreUsuario.Text.Length >= 6) {
                    esNombreUsuarioValido = true;
                    lblAdvertenciaNombreUsuarioInvalido.Visibility = Visibility.Hidden;
                } else
                {
                    lblAdvertenciaNombreUsuarioInvalido.Visibility = Visibility.Visible;
                }

                if (Regex.IsMatch(pwbContrasena.Password, "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[$@$!%*?&#.$($)\\-_])[A-Za-z\\d$@$!%*?&#.$($)\\-_]{8,16}$"))
                {
                    esContrasenaValida = true;
                    lblAdvertenciaContrasenaInvalida.Visibility = Visibility.Hidden;
                } else
                {
                    lblAdvertenciaCorreoInvalido.Visibility = Visibility.Visible;
                }

                if (Regex.IsMatch(tbxCorreoElectronico.Text, "^[a-zA-Z0-9\\-_]{5,20}@(gmail|outlook|hotmail)\\.com$"))
                {
                    esCorreoValido = true;
                    lblAdvertenciaCorreoInvalido.Visibility = Visibility.Hidden;
                }
                else
                {
                    lblAdvertenciaCorreoInvalido.Visibility = Visibility.Visible;
                }

                if (esNombreUsuarioValido && esContrasenaValida && esCorreoValido)
                {
                   // Usuario usuario = new Usuario();
                    //Jugador jugador = new Jugador();
                    
                    //GuardarJugador(usuario, jugador);
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
    }
}
