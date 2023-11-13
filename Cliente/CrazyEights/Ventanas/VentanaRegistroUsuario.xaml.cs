using CrazyEights.ReferenciaServicioManejoJugadores;
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
            if (ValidarCampos())
            {
                ReferenciaServicioManejoJugadores.ServicioManejoJugadoresClient cliente = new ReferenciaServicioManejoJugadores.ServicioManejoJugadoresClient();

                Usuario usuario = new Usuario();
                usuario.Contrasena = Encriptacion.GetSHA256(pwbContrasena.Password);
                usuario.CorreoElectronico = tbxCorreoElectronico.Text;

                Jugador jugador = new Jugador();
                jugador.NombreUsuario = tbxNombreUsuario.Text;

                if (!cliente.ValidarNombreUsuarioRegistrado(jugador) && !cliente.ValidarCorreoElectronicoRegistrado(usuario))
                {
                    string codigoVerificacion;
                    codigoVerificacion = cliente.EnviarCodigoAlCorreoDelUsuario(usuario.CorreoElectronico);
                    VentanaCódigoVerificación ventanaCodigo = new VentanaCódigoVerificación(usuario.CorreoElectronico, codigoVerificacion);
                    ventanaCodigo.EventoRegresarVerificacionCorreo += VentanaCódigoVerificación_EventoRegresarVerificacionCorreo;
                    ventanaCodigo.ShowDialog();
                }
                else
                {
                    if (cliente.ValidarNombreUsuarioRegistrado(jugador))
                    {
                        lbAdvertenciaNombreUsuarioInvalido.Content = "El nombre de usuario ya existe.";
                        lbAdvertenciaNombreUsuarioInvalido.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        lbAdvertenciaNombreUsuarioInvalido.Visibility = Visibility.Hidden;
                    }

                    if (cliente.ValidarCorreoElectronicoRegistrado(usuario))
                    {
                        lbAdvertenciaCorreoInvalido.Content = "Ya existe un usuario con el correo ingresado.";
                        lbAdvertenciaCorreoInvalido.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        lbAdvertenciaCorreoInvalido.Visibility = Visibility.Hidden;
                    }
                }
            }
        }

        private void NavegarAIniciarSesión(object sender, RoutedEventArgs e)
        {
            MainWindow inicioSesión = new MainWindow();
            this.Close();
            inicioSesión.ShowDialog();
        }

        private void EntrarComoInvitado(object sender, RoutedEventArgs e)
        {
            IngresarComoInvitado ingresarInvitado = new IngresarComoInvitado();
            ingresarInvitado.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            ingresarInvitado.Show();
            this.Close();
        }

        private bool ValidarCampos()
        {
            lbAdvertenciaCamposVacios.Visibility = Visibility.Hidden;

            bool esNombreUsuarioValido = false;
            bool esContrasenaValida = false;
            bool esCorreoElectronicoValido = false;

            if (!string.IsNullOrEmpty(tbxNombreUsuario.Text) && !string.IsNullOrEmpty(tbxCorreoElectronico.Text) && !string.IsNullOrEmpty(pwbContrasena.Password))
            {
                if (Utilidades.ValidarNombreUsuario(tbxNombreUsuario.Text))
                {
                    esNombreUsuarioValido = true;
                    lbAdvertenciaNombreUsuarioInvalido.Visibility = Visibility.Hidden;
                } 
                else
                {
                    esNombreUsuarioValido = false;
                    lbAdvertenciaNombreUsuarioInvalido.Visibility = Visibility.Visible;
                }

                if (Utilidades.ValidarCorreoElectronico(tbxCorreoElectronico.Text))
                {
                    esCorreoElectronicoValido = true;
                    lbAdvertenciaCorreoInvalido.Visibility = Visibility.Hidden;
                }
                else
                {
                    esCorreoElectronicoValido = false;
                    lbAdvertenciaCorreoInvalido.Visibility = Visibility.Visible;
                }

                if (Utilidades.ValidarContrasena(pwbContrasena.Password))
                {
                    esContrasenaValida = true;
                    lbAdvertenciaContrasenaInvalida.Visibility = Visibility.Hidden;
                }
                else
                {
                    esContrasenaValida = false;
                    lbAdvertenciaContrasenaInvalida.Visibility = Visibility.Visible;
                }
            }
            else
            {
                lbAdvertenciaCamposVacios.Visibility = Visibility.Visible;
            }

            return esNombreUsuarioValido && esCorreoElectronicoValido && esContrasenaValida;
        }

        private void VentanaCódigoVerificación_EventoRegresarVerificacionCorreo(object sender, bool esCorreoVerificado)
        {
            if (esCorreoVerificado) 
            {
                ReferenciaServicioManejoJugadores.ServicioManejoJugadoresClient cliente = new ReferenciaServicioManejoJugadores.ServicioManejoJugadoresClient();

                Usuario usuario = new Usuario();
                usuario.Contrasena = Encriptacion.GetSHA256(pwbContrasena.Password);
                usuario.CorreoElectronico = tbxCorreoElectronico.Text;

                Jugador jugador = new Jugador();
                jugador.NombreUsuario = tbxNombreUsuario.Text;

                int cambiosGuardados;
                cambiosGuardados = cliente.GuardarJugador(usuario, jugador);
                if (cambiosGuardados > 0)
                {
                    VentanaConfirmación ventanaConfirmacion = new VentanaConfirmación("Registro Exitoso", "Se ha creado la nueva cuenta correctamente.");
                    ventanaConfirmacion.ShowDialog();
                }
                else
                {
                    VentanaAdvertencia ventanaAdvertencia = new VentanaAdvertencia("No fue posible crear la cuenta", "Ocurrió un error al crear la cuenta, posiblemente debido a un error con la conexión.");
                    ventanaAdvertencia.ShowDialog();
                }

                MainWindow ventanaInicioSesion = new MainWindow();
                this.Close();
                ventanaInicioSesion.ShowDialog();
            }
            else
            {
                VentanaAdvertencia ventanAdvertencia = new VentanaAdvertencia("No fue posible crear la cuenta", "Por favor verifique su correo electrónico ingresando el código que enviamos.");
                ventanAdvertencia.ShowDialog();
            }
        }

        private void Configuracion(object sender, MouseButtonEventArgs e)
        {
            VentanaConfiguracion configuracion = new VentanaConfiguracion();
            configuracion.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            configuracion.Show();
            this.Close();
        }
    }
}
