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
    /// Interaction logic for VentanaConfiguracionPartida.xaml
    /// </summary>
    public partial class VentanaConfiguracionPartida : Window
    {
        public VentanaConfiguracionPartida()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.ResizeMode = ResizeMode.NoResize;
            CargarComboBoxes();
        }

        private void CrearSala(object sender, RoutedEventArgs e)
        {

        }

        private void NavegarAMenuPrincipal(object sender, MouseButtonEventArgs e)
        {
            VentanaMenuPrincipal ventanaMenuPrincipal = new VentanaMenuPrincipal();
            this.Close();
            ventanaMenuPrincipal.ShowDialog();
        }

        private void NavegarASala(object sender, RoutedEventArgs e)
        {
            VentanaSala ventanaSala = new VentanaSala();
            this.Close();
            ventanaSala.ShowDialog();
        }

        private void CargarComboBoxes()
        {
            CargarComboBoxModoJuego();
            CargarComboBoxAcceso();
            CargarComboBoxRondasParaGanar();
            CargarComboBoxTiempoPorRonda();
        }

        private void CargarComboBoxModoJuego()
        {
            cbModoJuego.Items.Add("Clásico");
            cbModoJuego.Items.Add("Crazy");
        }

        private void CargarComboBoxAcceso()
        {
            cbAcceso.Items.Add("Público");
            cbAcceso.Items.Add("Privado");
        }

        private void CargarComboBoxRondasParaGanar()
        {
            cbRondas.Items.Add("3");
            cbRondas.Items.Add("5");
            cbRondas.Items.Add("7");
        }

        private void CargarComboBoxTiempoPorRonda()
        {
            cbTiempoPorTurno.Items.Add("10");
            cbTiempoPorTurno.Items.Add("15");
            cbTiempoPorTurno.Items.Add("20");
            cbTiempoPorTurno.Items.Add("25");
            cbTiempoPorTurno.Items.Add("30");
            cbTiempoPorTurno.Items.Add("40");
            cbTiempoPorTurno.Items.Add("50");
            cbTiempoPorTurno.Items.Add("60");
        }
    }
}
