using CrazyEights.Properties;
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

namespace CrazyEights.Ventanas
{
    /// <summary>
    /// Interaction logic for VentanaTiendaDeJuego.xaml
    /// </summary>
    public partial class VentanaTiendaDeJuego : Window
    {
        //ToDo
        Baraja baraja = new Baraja();
        
        public VentanaTiendaDeJuego()
        {
            InitializeComponent();
        }

        private void CerrarVentana(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void CargarCartasMinimalistas(object sender, RoutedEventArgs e)
        {
            String cartasMinimalistas = "CartasMinimalistas";
            CambioDeRecurso(cartasMinimalistas);
        }

        private void CargarCartasClasicas(object sender, RoutedEventArgs e)
        {
            String cartasClasicas = "Cartas";
            CambioDeRecurso(cartasClasicas);
        }

        private void CambioDeRecurso(string cartas)
        {
            Settings.Default.Cartas = cartas;
            Properties.Settings.Default.Save();
            MessageBox.Show(Properties.Resources.msbCambioDeBaraja, Properties.Resources.ttlCambioDeBaraja, MessageBoxButton.OK, MessageBoxImage.Information);
        }
        
    }
}
