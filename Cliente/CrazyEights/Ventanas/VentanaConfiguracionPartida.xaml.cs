using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Configuration;
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

namespace CrazyEights.Ventanas
{
    /// <summary>
    /// Interaction logic for VentanaConfiguracionPartida.xaml
    /// </summary>
    public partial class VentanaConfiguracionPartida : Window
    {
        ReferenciaServicioManejoJugadores.ServicioSalaClient cliente = new ReferenciaServicioManejoJugadores.ServicioSalaClient();
        private Sala sala = new Sala();

        public VentanaConfiguracionPartida()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.ResizeMode = ResizeMode.NoResize;
            CargarComboBoxes();
        }

        public VentanaConfiguracionPartida(Sala sala)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.ResizeMode = ResizeMode.NoResize;
            this.sala = sala;
            CargarComboBoxes();
            CargarConfiguracionActualSala();
        }

        private Sala CrearSala()
        {
            Sala nuevaSala = new Sala
            {
                Codigo = GenerarNuevoCodigoSala(),
                Nombre = tbxNombrePartida.Text,
                ModoDeJuego = cbModoJuego.Text,
                TipoDeAcceso = cbAcceso.Text,
                NumeroDeRondas = int.Parse(cbRondas.Text),
                TiempoPorTurno = int.Parse(cbTiempoPorTurno.Text)
            };

            cliente.AgregarSalaAListaDeSalas(nuevaSala);
            return nuevaSala;
        }

        private Sala ActualizarSala()
        {
            Sala salaActualizada = new Sala
            {
                Codigo = this.sala.Codigo,
                Nombre = tbxNombrePartida.Text,
                ModoDeJuego = cbModoJuego.Text,
                TipoDeAcceso = cbAcceso.Text,
                NumeroDeRondas = int.Parse(cbRondas.Text),
                TiempoPorTurno = int.Parse(cbTiempoPorTurno.Text)
            };

            cliente.ActualizarConfiguracionSala(salaActualizada);
            return salaActualizada;
        }

        private int GenerarNuevoCodigoSala()
        {
            Random random = new Random();

            int[] codigoAleatorio = new int[4];

            for (int i = 0; i < 4; i++)
            {
                codigoAleatorio[i] = random.Next(10);
            }

            int codigo = int.Parse(string.Join("", codigoAleatorio));

            if (!cliente.VerificarCodigoSalaNoRepetido(codigo))
            {
                codigo = GenerarNuevoCodigoSala();
            }

            return codigo;
        }

        private void NavegarAMenuPrincipal(object sender, MouseButtonEventArgs e)
        {
            VentanaMenuPrincipal ventanaMenuPrincipal = new VentanaMenuPrincipal();
            this.Close();
            ventanaMenuPrincipal.ShowDialog();
        }

        private void NavegarASala(object sender, RoutedEventArgs e)
        {
            Sala salaConfigurada;

            if (ValidarCamposConfiguracion())
            {
                if (this.sala.Codigo == 0)
                {
                    salaConfigurada = CrearSala();
                }
                else
                {
                    salaConfigurada = ActualizarSala();
                }

                VentanaSala ventanaSala = new VentanaSala(salaConfigurada);
                this.Close();
                ventanaSala.ShowDialog();
            }
        }

        private void CargarComboBoxes()
        {
            CargarComboBoxModoJuego();
            CargarComboBoxAcceso();
            CargarComboBoxRondasParaGanar();
            CargarComboBoxTiempoPorTurno();
        }

        private void CargarConfiguracionActualSala()
        {
            tbxNombrePartida.Text = this.sala.Nombre;
            cbModoJuego.SelectedIndex = cbModoJuego.Items.IndexOf(this.sala.ModoDeJuego);
            cbAcceso.SelectedIndex = cbAcceso.Items.IndexOf(this.sala.TipoDeAcceso);
            cbRondas.SelectedIndex = cbRondas.Items.IndexOf(this.sala.NumeroDeRondas.ToString());
            cbTiempoPorTurno.SelectedIndex = cbTiempoPorTurno.Items.IndexOf(this.sala.TiempoPorTurno.ToString());
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

        private void CargarComboBoxTiempoPorTurno()
        {
            cbTiempoPorTurno.Items.Add("15");
            cbTiempoPorTurno.Items.Add("30");
            cbTiempoPorTurno.Items.Add("45");
            cbTiempoPorTurno.Items.Add("60");
        }

        private bool ValidarCamposConfiguracion()
        {
            bool esNombrePartidaValido = false;
            bool esModoJuegoValido = false;
            bool esAccesoValido = false;
            bool esRondasValido = false;
            bool esTiempoPorTurnoValido = false;

            if (tbxNombrePartida.Text.Length > 0 && tbxNombrePartida.Text.Length <= 20)
            {
                esNombrePartidaValido = true;
                lbAdvertenciaNombreInvalido.Visibility = Visibility.Hidden;
            }
            else
            {
                lbAdvertenciaNombreInvalido.Visibility = Visibility.Visible;
            }

            if (cbModoJuego.Text.Length > 0)
            {
                esModoJuegoValido = true;
                lbAdvertenciaModoJuegoInvalido.Visibility = Visibility.Hidden;
            }
            else
            {
                lbAdvertenciaModoJuegoInvalido.Visibility = Visibility.Visible;
            }

            if (cbAcceso.Text.Length > 0)
            {
                esAccesoValido = true;
                lbAdvertenciaAccesoInvalido.Visibility = Visibility.Hidden;
            }
            else
            {
                lbAdvertenciaAccesoInvalido.Visibility = Visibility.Visible;    
            }

            if (cbRondas.Text.Length > 0)
            {
                esRondasValido = true;
                lbAdvertenciaRondasParaGanarInvalido.Visibility = Visibility.Hidden;
            }
            else
            {
                lbAdvertenciaRondasParaGanarInvalido.Visibility = Visibility.Visible;
            }

            if (cbTiempoPorTurno.Text.Length > 0)
            {
                esTiempoPorTurnoValido = true;
                lbAdvertenciaTiempoPorTurnoInvalido.Visibility = Visibility.Hidden;
            }
            else
            {
                lbAdvertenciaTiempoPorTurnoInvalido.Visibility = Visibility.Visible;
            }

            return esNombrePartidaValido && esModoJuegoValido && esAccesoValido && esRondasValido && esTiempoPorTurnoValido;
        }
    }
}
