using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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
            OcultarBotonSalir();
        }

        private void CrearSala()
        {
            this.sala.Codigo = GenerarNuevoCodigoSala();
            this.sala.Nombre = tbxNombrePartida.Text;
            this.sala.ModoDeJuego = cbModoJuego.Text;
            this.sala.TipoDeAcceso = cbAcceso.Text;
            this.sala.NumeroDeRondas = int.Parse(cbRondas.Text);
            this.sala.TiempoPorTurno = int.Parse(cbTiempoPorTurno.Text);
            this.sala.JugadoresEnSala = new Dictionary<string, Jugador>();
           
            Jugador jugador = new Jugador
            {
                IdJugador = SingletonJugador.Instance.IdJugador,
                NombreUsuario = SingletonJugador.Instance.NombreJugador,
                FotoPerfil = SingletonJugador.Instance.FotoPerfil,
                Estado = "En espera"
            };
            this.sala.JugadoresEnSala.Add(jugador.NombreUsuario, jugador);
            this.sala.Host = jugador;
        }

        private void ActualizarSala()
        {
            this.sala.Nombre = tbxNombrePartida.Text;
            this.sala.ModoDeJuego = cbModoJuego.Text;
            this.sala.TipoDeAcceso = cbAcceso.Text;
            this.sala.NumeroDeRondas = int.Parse(cbRondas.Text);
            this.sala.TiempoPorTurno = int.Parse(cbTiempoPorTurno.Text);
        }

        private int GenerarNuevoCodigoSala()
        {
            Random random = new Random();

            int codigoAleatorio = random.Next(1000, 10000);

            ReferenciaServicioManejoJugadores.ServicioSalaClient cliente = new ReferenciaServicioManejoJugadores.ServicioSalaClient();
            if (!cliente.VerificarCodigoSalaNoRepetido(codigoAleatorio))
            {
                codigoAleatorio = GenerarNuevoCodigoSala();
            }

            return codigoAleatorio;
        }

        private void NavegarAMenuPrincipal(object sender, MouseButtonEventArgs e)
        {
            VentanaMenuPrincipal ventanaMenuPrincipal = new VentanaMenuPrincipal();
            this.Close();
            ventanaMenuPrincipal.ShowDialog();
        }

        private void NavegarASala(object sender, RoutedEventArgs e)
        {
            if (ValidarCamposConfiguracion())
            {


                if (this.sala.Codigo == 0)
                {
                    CrearSala();

                }
                else
                {
                    ActualizarSala();
                }

                VentanaSala ventanaSala = new VentanaSala();
                ventanaSala.EntrarASala(this.sala);
                ventanaSala.NotificarCambiosConfiguracionSala();
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
            cbRondas.Items.Add("4");
            cbRondas.Items.Add("5");
        }

        private void CargarComboBoxTiempoPorTurno()
        {
            cbTiempoPorTurno.Items.Add("5");
            cbTiempoPorTurno.Items.Add("10");
            cbTiempoPorTurno.Items.Add("15");
            cbTiempoPorTurno.Items.Add("20");
        }

        private void OcultarBotonSalir()
        {
            btnCerrarVentana.Visibility = Visibility.Hidden;
            lbCerrarVentana.Visibility = Visibility.Hidden;
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
