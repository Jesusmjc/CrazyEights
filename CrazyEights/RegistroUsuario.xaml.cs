using ClassLibrary;
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
            Jugadores tablaJugadores = new Jugadores();
            Usuarios tablaUsuarios = new Usuarios();
            {
                CrazyEightsEntities CrazyEights = new CrazyEightsEntities();

                tablaUsuarios.contraseña = pwbContrasena.Password;
                tablaUsuarios.correoElectrónico = tbxCorreoElectronico.Text;

                tablaJugadores.nombreUsuario = tbxNombreUsuario.Text;

                CrazyEights.Usuarios.Add(tablaUsuarios);
                CrazyEights.Jugadores.Add(tablaJugadores);
                
                if (CrazyEights.SaveChanges() > 0)
                {
                    VentanaConfirmación ventanaConfirmacion = new VentanaConfirmación();
                    ventanaConfirmacion.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    ventanaConfirmacion.Show();
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
    }
}
