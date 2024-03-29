﻿using CrazyEights.ReferenciaServicioManejoJugadores;
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
            this.ResizeMode = ResizeMode.NoResize;
        }

        private void IniciarSesion(object sender, RoutedEventArgs e)
        {
            if (ValidarCampos())
            {
                ReferenciaServicioManejoJugadores.ServicioManejoJugadoresClient cliente = new ReferenciaServicioManejoJugadores.ServicioManejoJugadoresClient();

                Usuario usuarioAValidar = new Usuario();
                usuarioAValidar.CorreoElectronico = tbxCorreoElectronico.Text;
                usuarioAValidar.Contrasena = Encriptacion.GetSHA256(pwbContrasena.Password);

                Jugador jugadorInicioSesion = new Jugador();
                jugadorInicioSesion = cliente.ValidarInicioSesion(usuarioAValidar);

                if (jugadorInicioSesion.IdJugador > 0)
                {
                    SingletonJugador singletonJugador = SingletonJugador.Instance;
                    singletonJugador.NombreJugador = jugadorInicioSesion.NombreUsuario;
                    singletonJugador.IdJugador = jugadorInicioSesion.IdJugador;
                    singletonJugador.FotoPerfil = jugadorInicioSesion.FotoPerfil;
                    singletonJugador.CorreoElectronico = usuarioAValidar.CorreoElectronico;
                    singletonJugador.Estado = "Conectado";

                    VentanaMenuPrincipal ventanaMenuPrincipal = new VentanaMenuPrincipal();
                    ventanaMenuPrincipal.MostrarComoJugadorEnLinea();
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
            lbAdvertenciaCamposVacios.Visibility = Visibility.Hidden;
            lbAdvertenciaContraseñaInvalida.Visibility = Visibility.Hidden;
            lbAdvertenciaCorreoElectronicoInvalido.Visibility = Visibility.Hidden;

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
                    lbAdvertenciaContraseñaInvalida.Visibility = Visibility.Visible;
                }
            }
            else
            {
                lbAdvertenciaCamposVacios.Visibility = Visibility.Visible;
            }

            return esCorreoElectronicoValido && esContrasenaValida;
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
