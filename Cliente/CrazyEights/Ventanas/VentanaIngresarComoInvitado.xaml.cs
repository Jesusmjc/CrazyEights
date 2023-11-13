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
    /// Interaction logic for IngresarComoInvitado.xaml
    /// </summary>
    public partial class IngresarComoInvitado : Window
    {
        public IngresarComoInvitado()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void NavegarARegistroUsuario(object sender, RoutedEventArgs e)
        {
            RegistroUsuario registroUsuario = new RegistroUsuario();
            registroUsuario.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            registroUsuario.Show();
            this.Close();
        }

        private void NavegarAIniciarSesión(object sender, RoutedEventArgs e)
        {
            MainWindow inicioSesion = new MainWindow();
            inicioSesion.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            inicioSesion.Show();
            this.Close();
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
