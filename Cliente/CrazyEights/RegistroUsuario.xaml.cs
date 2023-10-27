﻿using CrazyEights.ReferenciaServicioManejoJugadores;
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
                    int cambiosGuardados = 0;
                    cambiosGuardados = cliente.GuardarJugador(usuario, jugador);
                    if (cambiosGuardados > 0)
                    {
                        VentanaConfirmación ventanaConfirmacion = new VentanaConfirmación("Registro Exitoso", "Se ha creado la nueva cuenta correctamente.");
                        ventanaConfirmacion.Show();
                    }
                    else
                    {
                        VentanaAdvertencia ventanaAdvertencia = new VentanaAdvertencia("No fue posible crear la cuenta", "Ocurrió un error al crear la cuenta, posiblemente debido a un error con la conexión.");
                        ventanaAdvertencia.Show();
                    }
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
            inicioSesión.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            inicioSesión.Show();
            this.Close();
        }

        private void EntrarComoInvitado(object sender, RoutedEventArgs e)
        {

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
    }
}
