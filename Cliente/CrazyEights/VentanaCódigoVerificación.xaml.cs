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
        private string correoElectronicoUsuario;
        private string codigoVerificacionActual;

        public VentanaCódigoVerificación(string correoElectronicoUsuario, string codigoVerificacion)
        {
            InitializeComponent();
            this.correoElectronicoUsuario = correoElectronicoUsuario;
            this.codigoVerificacionActual = codigoVerificacion;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void GenerarNuevoCodigo(object sender, MouseButtonEventArgs e)
        {
            ReferenciaServicioManejoJugadores.ServicioManejoJugadoresClient cliente = new ReferenciaServicioManejoJugadores.ServicioManejoJugadoresClient();

            this.codigoVerificacionActual = cliente.EnviarCodigoAlCorreoDelUsuario(correoElectronicoUsuario);
        }

        private void CompararCodigoVerificacion(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbxCodigo.Text))
            {
                if (tbxCodigo.Text == codigoVerificacionActual)
                {
                    Console.WriteLine("Se he verificado el correo electrónico del usuario");
                }
            }
        }
    }
}
