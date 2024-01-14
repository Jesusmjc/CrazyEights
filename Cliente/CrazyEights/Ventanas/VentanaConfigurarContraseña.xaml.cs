using CrazyEights.ReferenciaServicioManejoJugadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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

namespace CrazyEights.Ventanas
{
    /// <summary>
    /// Interaction logic for VentanaConfigurarContraseña.xaml
    /// </summary>
    public partial class VentanaConfigurarContraseña : Window
    {
        public VentanaConfigurarContraseña()
        {
            InitializeComponent();
        }
        private void CambiarContraseña(object sender, RoutedEventArgs e)
        {
            lbCamposVacios.Visibility = Visibility.Hidden;
            tbContraseñaInvalida.Visibility = Visibility.Hidden;
            lbContraseñaActualInvalida.Visibility = Visibility.Hidden;

            string nuevaContraseña = tbxNuevaContraseña.Text;
            string confirmarNuevaContraseña = tbxConfirmarNuevaContraseña.Text;

            ReferenciaServicioManejoJugadores.ServicioManejoJugadoresClient cliente = new ReferenciaServicioManejoJugadores.ServicioManejoJugadoresClient();

            Usuario usuarioAValidar = new Usuario(); 
            usuarioAValidar.CorreoElectronico = SingletonJugador.Instance.CorreoElectronico;
            usuarioAValidar.Contrasena = Encriptacion.GetSHA256(pwbContraseñaPasada.Password).Trim();

            Jugador jugadorCambioContraseña = new Jugador();
            jugadorCambioContraseña = cliente.ValidarInicioSesion(usuarioAValidar);

            if (!ValidarCampos())
            {
                if (Utilidades.ValidarContrasena(nuevaContraseña) && Utilidades.ValidarContrasena(confirmarNuevaContraseña))
                {
                    if (!Utilidades.ValidarNuevaContraseña(nuevaContraseña, confirmarNuevaContraseña))
                    {
                        if (jugadorCambioContraseña != null)
                        {
                            string codigoVerificacion;
                            codigoVerificacion = cliente.EnviarCodigoAlCorreoDelUsuario(usuarioAValidar.CorreoElectronico);
                            VentanaCódigoVerificación ventanaCodigo = new VentanaCódigoVerificación(usuarioAValidar.CorreoElectronico, codigoVerificacion);
                            ventanaCodigo.EventoRegresarVerificacionCorreo += VentanaCódigoVerificación_EventoRegresarVerificacionCorreo;
                            ventanaCodigo.ShowDialog();
                        }
                        else
                        {
                            lbContraseñaActualInvalida.Visibility = Visibility.Visible;
                        }
                    }
                    else
                    {
                        MessageBox.Show(Properties.Resources.msbContraseñasNoIguales, Properties.Resources.ttlContraseñasNoIguales, MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    tbContraseñaInvalida.Visibility = Visibility.Visible;
                }
            }
        }

        private bool ValidarCampos()
        {
            bool nuevaContraseña = string.IsNullOrWhiteSpace(tbxNuevaContraseña.Text);
            bool confirmarNuevaContraseña = string.IsNullOrWhiteSpace(tbxConfirmarNuevaContraseña.Text);
            bool contraseñaPasada = string.IsNullOrWhiteSpace(pwbContraseñaPasada.Password);

            if (nuevaContraseña || confirmarNuevaContraseña || contraseñaPasada)
            {
                lbCamposVacios.Visibility = Visibility.Visible;
            }
            return nuevaContraseña || confirmarNuevaContraseña || contraseñaPasada;
        }

        private void VentanaCódigoVerificación_EventoRegresarVerificacionCorreo(object sender, bool esCorreoVerificado)
        {
            if (esCorreoVerificado)
            {
                ReferenciaServicioManejoJugadores.ServicioManejoJugadoresClient cliente = new ReferenciaServicioManejoJugadores.ServicioManejoJugadoresClient();

                string correoElectronico = SingletonJugador.Instance.CorreoElectronico.ToString();
                string nuevaContraseña = Encriptacion.GetSHA256(tbxNuevaContraseña.Text);

                if (cliente.CambiarContraseña(correoElectronico,nuevaContraseña))
                {
                    MessageBox.Show(Properties.Resources.msbContraseñaCambiada, Properties.Resources.ttlContraseñaCambiada, MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show(Properties.Resources.msbContraseñaNoCambiada, Properties.Resources.ttlContraseñaNoCambiada, MessageBoxButton.OK, MessageBoxImage.Information);
                }
                this.Close();
            }
        }

        private void Cancelar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
