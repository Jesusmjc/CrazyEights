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
        private string _correoElectronicoUsuario;
        private string _codigoVerificacionActual;

        public event EventHandler<bool> EventoRegresarVerificacionCorreo;

        public VentanaCódigoVerificación(string correoElectronicoUsuario, string codigoVerificacion)
        {
            InitializeComponent();
            this._correoElectronicoUsuario = correoElectronicoUsuario;
            this._codigoVerificacionActual = codigoVerificacion;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void CompararCodigoVerificacion(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbxCodigo.Text))
            {
                lbAdvertenciaCodigoIncorrecto.Visibility = Visibility.Hidden;
                lbNuevoCodigoEnviado.Visibility = Visibility.Hidden;

                if (tbxCodigo.Text == _codigoVerificacionActual)
                {
                    this.Close();
                    EventoRegresarVerificacionCorreo(this, true);
                }
                else
                {
                    lbAdvertenciaCodigoIncorrecto.Visibility = Visibility.Visible;
                }
            }
        }

        private void CerrarVentana(object sender, RoutedEventArgs e)
        {
            this.Close();
            EventoRegresarVerificacionCorreo(this, false);
        }

        private void EnviarNuevoCodigo(object sender, RoutedEventArgs e)
        {
            ReferenciaServicioManejoJugadores.ServicioManejoJugadoresClient cliente = new ReferenciaServicioManejoJugadores.ServicioManejoJugadoresClient();

            _codigoVerificacionActual = cliente.EnviarCodigoAlCorreoDelUsuario(_correoElectronicoUsuario);
            lbAdvertenciaCodigoIncorrecto.Visibility = Visibility.Hidden;
            lbNuevoCodigoEnviado.Visibility = Visibility.Visible;
        }

        private void ValidarSoloCaracteresNumericos(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !int.TryParse(e.Text, out _);
        }
    }

}
