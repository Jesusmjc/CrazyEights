using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for VentanaSala.xaml
    /// </summary>
    public partial class VentanaSala : Window, IServicioActualizacionSalaCallback
    {
        private Sala sala;
        private Grid[] gridsJugadoresEnSala = new Grid[4];
        private JugadorSala[] entradasJugadoresEnSala = new JugadorSala[4];
        private bool jugadorEsHost;

        public VentanaSala()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.ResizeMode = ResizeMode.NoResize;

            CargarListaGridsEntradaJugadores();
        }

        public void EntrarASala(Sala sala)
        {
            this.sala = sala;

            ReferenciaServicioManejoJugadores.ServicioSalaClient cliente = new ReferenciaServicioManejoJugadores.ServicioSalaClient();
            if (cliente.RecuperarSala(sala.Codigo).Codigo == 0)
            {
                cliente.AgregarSalaAListaDeSalas(this.sala);
            }
            
            InstanceContext contexto = new InstanceContext(this);
            ReferenciaServicioManejoJugadores.ServicioActualizacionSalaClient clienteCallback = new ReferenciaServicioManejoJugadores.ServicioActualizacionSalaClient(contexto);
            Jugador jugador = new Jugador
            {
                IdJugador = SingletonJugador.Instance.IdJugador,
                NombreUsuario = SingletonJugador.Instance.NombreJugador,
                FotoPerfil = SingletonJugador.Instance.FotoPerfil,
                Estado = SingletonJugador.Instance.Estado
            };
            clienteCallback.AgregarJugadorASala(sala.Codigo, jugador);
            if (!this.sala.JugadoresEnSala.ContainsKey(jugador.NombreUsuario))
            {
                this.sala.JugadoresEnSala.Add(jugador.NombreUsuario, jugador);
            }

            CargarConfiguracion();
            CargarJugadoresEnSala();
            VerificarSiJugadorNoEsHost();
        }

        private void CargarListaGridsEntradaJugadores()
        {
            gridsJugadoresEnSala[0] = gridJugadorSala1;
            gridsJugadoresEnSala[1] = gridJugadorSala2;
            gridsJugadoresEnSala[2] = gridJugadorSala3;
            gridsJugadoresEnSala[3] = gridJugadorSala4;
        }

        private void CargarJugadoresEnSala()
        {
            ReferenciaServicioManejoJugadores.ServicioSalaClient cliente = new ReferenciaServicioManejoJugadores.ServicioSalaClient();

            int i = 0;
            foreach (var jugador in cliente.RecuperarSala(this.sala.Codigo).JugadoresEnSala)
            {
                JugadorSala entradaJugadorSala = new JugadorSala(jugador.Value);

                entradaJugadorSala.imgPuntosEnEspera.Visibility = Visibility.Visible;
                if (i == 0)
                {
                    entradaJugadorSala.imgCoronaHost.Visibility = Visibility.Visible;
                    if (jugador.Value.NombreUsuario.Equals(SingletonJugador.Instance.NombreJugador))
                    {
                        jugadorEsHost = true;
                    }
                } 
                
                if (i < 4)
                {
                    gridsJugadoresEnSala[i].Children.Add(entradaJugadorSala);
                    entradasJugadoresEnSala[i] = entradaJugadorSala;
                }

                i++;
            }
        }

        private void VerificarSiJugadorNoEsHost()
        {
            if (!this.sala.Host.NombreUsuario.Equals(SingletonJugador.Instance.NombreJugador))
            {
                imgConfiguracionSala.Visibility = Visibility.Hidden;
                btnEmpezarPartida.Content = "Listo";
            }
        }

        public void CargarConfiguracion()
        {
            lbModoJuego.Content = this.sala.ModoDeJuego;
            lbNumeroRondas.Content = this.sala.NumeroDeRondas;
            lbAcceso.Content = this.sala.TipoDeAcceso;
            lbNombreSala.Content = this.sala.Nombre;
            lbCodigoSalaNumero.Content = this.sala.Codigo;
        }
        
        private void AbrirListaAmigos(object sender, MouseButtonEventArgs e)
        {
            VentanaAmigos ventanaAmigos = new VentanaAmigos(this.sala);
            this.Close();
            ventanaAmigos.ShowDialog();
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

        public void MostrarNuevoJugadorEnSala(Jugador jugador)
        {
            if (this.sala.JugadoresEnSala.Count < 4)
            {
                JugadorSala nuevoJugadorEnSala = new JugadorSala(jugador);  
                nuevoJugadorEnSala.imgPuntosEnEspera.Visibility = Visibility.Visible;             
                gridsJugadoresEnSala[this.sala.JugadoresEnSala.Count].Children.Add(nuevoJugadorEnSala);
                entradasJugadoresEnSala[this.sala.JugadoresEnSala.Count] = nuevoJugadorEnSala;

                ReferenciaServicioManejoJugadores.ServicioSalaClient cliente = new ReferenciaServicioManejoJugadores.ServicioSalaClient();
                this.sala = cliente.RecuperarSala(this.sala.Codigo);
            }
        }

        private void CambiarEstado(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < this.sala.JugadoresEnSala.Count; i++)
            {
                JugadorSala entradaJugador = entradasJugadoresEnSala[i];
                if (entradaJugador.lbNombreJugador.Content.Equals(SingletonJugador.Instance.NombreJugador))
                {
                    AlternarEstadoJugador(entradaJugador);
                }
            }

            InstanceContext contexto = new InstanceContext(this);
            ReferenciaServicioManejoJugadores.ServicioActualizacionSalaClient cliente = new ReferenciaServicioManejoJugadores.ServicioActualizacionSalaClient(contexto);
            cliente.ActualizarEstadoJugadorEnSala(this.sala.Codigo, SingletonJugador.Instance.NombreJugador);
        }

        public void AlternarEstadoJugador(JugadorSala entradaJugador)
        {
            if (entradaJugador.imgPalomitaListo.Visibility == Visibility.Visible)
            {
                entradaJugador.imgPalomitaListo.Visibility = Visibility.Hidden;
                entradaJugador.imgPuntosEnEspera.Visibility = Visibility.Visible;
            }
            else if (entradaJugador.imgPuntosEnEspera.Visibility == Visibility.Visible)
            {
                entradaJugador.imgPuntosEnEspera.Visibility = Visibility.Hidden;
                entradaJugador.imgPalomitaListo.Visibility = Visibility.Visible;
            }
        }

        public void MostrarNuevoEstadoJugadorEnSala(string nombreJugador)
        {
            for (int i = 0; i < this.sala.JugadoresEnSala.Count; i++) 
            {
                JugadorSala entradaJugador = entradasJugadoresEnSala[i];
                if (entradaJugador.lbNombreJugador.Content.Equals(nombreJugador))
                {
                    AlternarEstadoJugador(entradaJugador);
                }
            }
        }
    }
}
