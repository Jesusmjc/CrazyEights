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

namespace CrazyEights.Ventanas
{
    /// <summary>
    /// Interaction logic for VentanaSala.xaml
    /// </summary>
    public partial class VentanaSala : Window
    {
        private Sala sala;
        private Grid[] gridsJugadoresEnSala = new Grid[4];
        private bool estaSalaLlena = false;

        public VentanaSala(Sala sala)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.ResizeMode = ResizeMode.NoResize;

            sala.JugadoresEnSala = new Dictionary<string, Jugador>();
            this.sala = sala;
            CargarListaGridsEntradaJugadores();
            AgregarJugadorASala(new Jugador
            {
                IdJugador = SingletonJugador.Instance.IdJugador,
                NombreUsuario = SingletonJugador.Instance.NombreJugador,
                FotoPerfil = SingletonJugador.Instance.FotoPerfil,
                Estado = SingletonJugador.Instance.Estado
            });
            CargarConfiguracion();
        }

        private void CargarListaGridsEntradaJugadores()
        {
            gridsJugadoresEnSala[0] = gridJugadorSala1;
            gridsJugadoresEnSala[1] = gridJugadorSala2;
            gridsJugadoresEnSala[2] = gridJugadorSala3;
            gridsJugadoresEnSala[3] = gridJugadorSala4;
        }

        public void AgregarJugadorASala(Jugador jugador)
        {
            if (!estaSalaLlena)
            {
                sala.JugadoresEnSala.Add(jugador.NombreUsuario, jugador);
                
                JugadorSala entradaJugadorSala = new JugadorSala(jugador);
                gridsJugadoresEnSala[sala.JugadoresEnSala.Count].Children.Add(entradaJugadorSala);

                if (sala.JugadoresEnSala.Count == 4)
                {
                    estaSalaLlena = true;
                }
            }
        }

        public void CargarConfiguracion()
        {
            lbModoJuego.Content = sala.ModoDeJuego;
            lbNumeroRondas.Content = sala.NumeroDeRondas;
            lbAcceso.Content = sala.TipoDeAcceso;
            lbNombreSala.Content = sala.Nombre;
            lbCodigoSalaNumero.Content = sala.Codigo;
        }
        
        private void AbrirListaAmigos(object sender, MouseButtonEventArgs e)
        {

        }

        private void NavegarAMenuPrincipal(object sender, MouseButtonEventArgs e)
        {
            VentanaMenuPrincipal ventanaMenuPrincipal = new VentanaMenuPrincipal();
            this.Close();
            ventanaMenuPrincipal.ShowDialog();
        }

        private void NavegarAConfiguracionPartida(object sender, MouseButtonEventArgs e)
        {
            VentanaConfiguracionPartida ventanaConfiguracionPartida = new VentanaConfiguracionPartida(this.sala);
            this.Close();
            ventanaConfiguracionPartida.ShowDialog();
        }
    }
}
