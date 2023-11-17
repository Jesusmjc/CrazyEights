using CrazyEights.Ventanas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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
    /// Interaction logic for VentanaMenuPrincipal.xaml
    /// </summary>
    public partial class VentanaMenuPrincipal : Window
    {
        public VentanaMenuPrincipal()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            MostrarComoJugadorEnLinea();
        }

        private void NavegarAListaAmigos(object sender, MouseButtonEventArgs e)
        {
            VentanaAmigos ventanaAmigos = new VentanaAmigos();
            this.Close();
            ventanaAmigos.ShowDialog();
        }

        //No muestra los nuevos métodos de callback en el contrato del servicio
        private void MostrarComoJugadorEnLinea()
        {
            InstanceContext contexto = new InstanceContext(this);
            ReferenciaServicioManejoJugadores.ManejadorJugadoresEnLineaClient cliente = new ReferenciaServicioManejoJugadores.ManejadorJugadoresEnLineaClient(contexto);
            cliente.NotificarNuevaConexionAJugadoresEnLinea(SingletonJugador.Instance.NombreUsuario);
        }
    }
}
