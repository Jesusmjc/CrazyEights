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

        public event EventHandler<bool> EventoRegresarVerificacionCorreo;

        public VentanaCódigoVerificación(string correoElectronicoUsuario, string codigoVerificacion)
        {
            InitializeComponent();
            this.correoElectronicoUsuario = correoElectronicoUsuario;
            this.codigoVerificacionActual = codigoVerificacion;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void CompararCodigoVerificacion(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbxCodigo.Text))
            {
                lblAdvertenciaCodigoIncorrecto.Visibility = Visibility.Hidden;

                if (tbxCodigo.Text == codigoVerificacionActual)
                {
                    EventoRegresarVerificacionCorreo(this, true);
                    this.Close();
                }
                else
                {
                    lblAdvertenciaCodigoIncorrecto.Visibility = Visibility.Visible;
                }
            }
        }

        private void CerrarVentana(object sender, RoutedEventArgs e)
        {
            EventoRegresarVerificacionCorreo(this, false);
            this.Close();
        }

        private void EnviarNuevoCodigo(object sender, RoutedEventArgs e)
        {
            ReferenciaServicioManejoJugadores.ServicioManejoJugadoresClient cliente = new ReferenciaServicioManejoJugadores.ServicioManejoJugadoresClient();

            codigoVerificacionActual = cliente.EnviarCodigoAlCorreoDelUsuario(correoElectronicoUsuario);
        }
    }
}
