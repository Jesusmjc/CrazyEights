using CrazyEights.Properties;
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

        private void IdiomaEspañol(object sender, MouseButtonEventArgs e)
        {
            string idiomaEspañol = "es-MX";
            CambioDeIdioma(idiomaEspañol);
        }

        private void IdiomaInglés(object sender, MouseButtonEventArgs e)
        {
            string idiomaInglés = "en-US";
            CambioDeIdioma(idiomaInglés);
            
        }
        
        private void CambioDeIdioma(string idioma)
        {
            Settings.Default.Idioma = idioma;
            Properties.Settings.Default.Save();
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(idioma);
            MainWindow ventanaPrincipal = new MainWindow();
            ventanaPrincipal.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            ventanaPrincipal.Show();
            this.Close();
        }


    }
}