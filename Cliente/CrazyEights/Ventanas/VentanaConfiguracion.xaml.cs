using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for VentanaConfiguracion.xaml
    /// </summary>
    public partial class VentanaConfiguracion : Window
    {
        public VentanaConfiguracion()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void btnIdiomaEspañol(object sender, MouseButtonEventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-MX");
            MainWindow ventanaPrincipal = new MainWindow();
            ventanaPrincipal.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            ventanaPrincipal.Show();
            this.Close();
        }

        private void btnIdiomaInglés(object sender, MouseButtonEventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            MainWindow ventanaPrincipal = new MainWindow();
            ventanaPrincipal.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            ventanaPrincipal.Show();
            this.Close();
        }

        
    }
}