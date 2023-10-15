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

        /*
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                Jugador tablaJugadores = new Jugador();
                Usuario tablaUsuarios = new Usuario();
                {
                    CrazyEightsEntities CrazyEights = new CrazyEightsEntities();
                    tablaJugadores.nombreUsuario = tbxNombreUsuario.Text;
                    tablaUsuarios.contraseña = pwbContrasena.Password;

                    CrazyEights.Jugadors.Add(tablaJugadores);
                    CrazyEights.Usuarios.Add(tablaUsuarios);
                    CrazyEights.SaveChanges();
                }
            }
        */

        private void IniciarSesion(object sender, RoutedEventArgs e)
        {

        }

        private void RecuperarContrasena(object sender, RoutedEventArgs e)
        {

        }

        private void NavegarARegistroUsuario(object sender, RoutedEventArgs e)
        {
            RegistroUsuario registroUsuario = new RegistroUsuario();
            registroUsuario.WindowStartupLocation= WindowStartupLocation.CenterScreen;
            registroUsuario.Show();
            this.Close();
        }
    }
}
