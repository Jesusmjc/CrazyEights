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
using CrazyEights.ReferenciaServicioManejoJugadores;

namespace CrazyEights
{
    /// <summary>
    /// Interaction logic for VentanaCódigoVerificación.xaml
    /// </summary>
    public partial class VentanaCódigoVerificación : Window
    {
        private Usuario usuario;
        public VentanaCódigoVerificación()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void GenerarNuevoCodigo(object sender, MouseButtonEventArgs e)
        {
            ReferenciaServicioManejoJugadores.ServicioManejoJugadoresClient cliente = new ReferenciaServicioManejoJugadores.ServicioManejoJugadoresClient();

            cliente.EnviarCodigoAlCorreoDelUsuario(Usuario usuario);
        }
    }
}
