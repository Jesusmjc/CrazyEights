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
    /// Interaction logic for VentanaAdvertencia.xaml
    /// </summary>
    public partial class VentanaAdvertencia : Window
    {
        public VentanaAdvertencia()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        public VentanaAdvertencia(string nombreAdvertencia, string detallesAdvertencia)
        {
            InitializeComponent(); 
            lbNombreAdvertencia.Content = nombreAdvertencia;
            tbDetallesAdvertencia.Text = detallesAdvertencia;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void CerrarVentana(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            this.Close();
        }
    }
}
