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
            SingletonJugador.Instance.Estado = "En espera";

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

        public void NotificarCambiosConfiguracionSala()
        {
            InstanceContext contexto = new InstanceContext(this);
            ReferenciaServicioManejoJugadores.ServicioActualizacionSalaClient cliente = new ReferenciaServicioManejoJugadores.ServicioActualizacionSalaClient(contexto);
            cliente.ActualizarConfiguracionDeSala(this.sala.Codigo, this.sala.Nombre, this.sala.ModoDeJuego, this.sala.TipoDeAcceso, this.sala.NumeroDeRondas, this.sala.TiempoPorTurno);
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
            Sala salaEnServidor = cliente.RecuperarSala(this.sala.Codigo);
            foreach (var jugador in salaEnServidor.JugadoresEnSala)
            {
                JugadorSala entradaJugadorSala = new JugadorSala(jugador.Value);

                entradaJugadorSala.imgPuntosEnEspera.Visibility = Visibility.Visible;
                if (salaEnServidor.Host.NombreUsuario.Equals(jugador.Value.NombreUsuario))
                {
                    entradaJugadorSala.imgCoronaHost.Visibility = Visibility.Visible;
                } 
                
                if (i < 4)
                {
                    gridsJugadoresEnSala[i].Children.Add(entradaJugadorSala);
                    entradasJugadoresEnSala[i] = entradaJugadorSala;
                }

                MostrarEstadoJugador(jugador.Value.Estado, entradaJugadorSala);

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
            MessageBoxResult resultado = MessageBox.Show("Salir de Sala",
                "¿Estás seguro de que quieres salir de la sala?", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (resultado == MessageBoxResult.Yes)
            {
                InstanceContext contexto = new InstanceContext(this);
                ReferenciaServicioManejoJugadores.ServicioActualizacionSalaClient cliente = new ReferenciaServicioManejoJugadores.ServicioActualizacionSalaClient(contexto);
                cliente.NotificarDesconexionDeSala(this.sala.Codigo, SingletonJugador.Instance.NombreJugador);

                VentanaMenuPrincipal ventanaMenuPrincipal = new VentanaMenuPrincipal();
                this.Close();
                ventanaMenuPrincipal.ShowDialog();
            }
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

                this.sala.JugadoresEnSala.Add(jugador.NombreUsuario, jugador);
            }
        }

        private void CambiarEstado(object sender, RoutedEventArgs e)
        {
            if (SingletonJugador.Instance.Estado.Equals("En espera"))
            {
                SingletonJugador.Instance.Estado = "Listo";
                this.sala.JugadoresEnSala[SingletonJugador.Instance.NombreJugador].Estado = "Listo";
            }
            else
            {
                SingletonJugador.Instance.Estado = "En espera";
                this.sala.JugadoresEnSala[SingletonJugador.Instance.NombreJugador].Estado = "En espera";
            }
            
            for (int i = 0; i < this.sala.JugadoresEnSala.Count; i++)
            {
                JugadorSala entradaJugador = entradasJugadoresEnSala[i];
                if (entradaJugador.lbNombreJugador.Content.Equals(SingletonJugador.Instance.NombreJugador))
                {
                    MostrarEstadoJugador(SingletonJugador.Instance.Estado, entradaJugador);
                }
            }

            BloquearBotones();
            VerificarSiJugadoresEstanListos();

            InstanceContext contexto = new InstanceContext(this);
            ReferenciaServicioManejoJugadores.ServicioActualizacionSalaClient cliente = new ReferenciaServicioManejoJugadores.ServicioActualizacionSalaClient(contexto);
            cliente.ActualizarEstadoJugadorEnSala(this.sala.Codigo, SingletonJugador.Instance.NombreJugador, SingletonJugador.Instance.Estado);
        }

        public void MostrarEstadoJugador(string estadoJugador, JugadorSala entradaJugador)
        {
            if (estadoJugador.Equals("En espera"))
            {
                entradaJugador.imgPalomitaListo.Visibility = Visibility.Hidden;
                entradaJugador.imgPuntosEnEspera.Visibility = Visibility.Visible;
            }
            else if (estadoJugador.Equals("Listo"))
            {
                entradaJugador.imgPuntosEnEspera.Visibility = Visibility.Hidden;
                entradaJugador.imgPalomitaListo.Visibility = Visibility.Visible;
            }
        }

        public void BloquearBotones()
        {
            if (SingletonJugador.Instance.Estado.Equals("Listo"))
            {
                if (SingletonJugador.Instance.NombreJugador.Equals(this.sala.Host.NombreUsuario))
                {
                    imgConfiguracionSala.Visibility = Visibility.Hidden;
                }
                btnCerrarVentana.IsEnabled = false;
                imgAmigos.IsEnabled = false;
                imgConfiguracionSala.IsEnabled = false;
            }
            else
            {
                btnCerrarVentana.IsEnabled = true;
                imgAmigos.IsEnabled = true;
                imgConfiguracionSala.IsEnabled = true;
                if (SingletonJugador.Instance.NombreJugador.Equals(this.sala.Host.NombreUsuario))
                {
                    imgConfiguracionSala.Visibility = Visibility.Visible;
                }
            }
        }

        private void VerificarSiJugadoresEstanListos()
        {
            if (SingletonJugador.Instance.NombreJugador.Equals(this.sala.Host.NombreUsuario))
            {
                bool jugadoresListosParaIniciarPartida = true;
                if (this.sala.JugadoresEnSala.Count > 1)
                {
                    foreach (var jugador in this.sala.JugadoresEnSala)
                    {
                        if (!jugador.Value.Estado.Equals("Listo"))
                        {
                            jugadoresListosParaIniciarPartida = false;
                        }
                    }
                } 
                else
                {
                    jugadoresListosParaIniciarPartida = false;
                }
                
                if (jugadoresListosParaIniciarPartida)
                {
                    imgFlechaIniciarPartida.Visibility = Visibility.Visible;
                }
                else
                {
                    imgFlechaIniciarPartida.Visibility = Visibility.Hidden;
                }
            }
        }

        public void MostrarNuevoEstadoJugadorEnSala(string nombreJugador, string estadoJugador)
        {
            this.sala.JugadoresEnSala[nombreJugador].Estado = estadoJugador;

            for (int i = 0; i < this.sala.JugadoresEnSala.Count; i++) 
            {
                JugadorSala entradaJugador = entradasJugadoresEnSala[i];
                if (entradaJugador.lbNombreJugador.Content.Equals(nombreJugador))
                {
                    MostrarEstadoJugador(estadoJugador, entradaJugador);
                }
            }

            VerificarSiJugadoresEstanListos();
        }

        private void EmpezarPartida(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("En este punto se iniciaría la partida.", "Empieza la partida", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void MostrarNuevoConfiguracionSala(string nombre, string modoJuego, string tipoAcceso, int numeroRondas, int tiempoPorTurno)
        {
            this.sala.Nombre = nombre;
            this.sala.ModoDeJuego = modoJuego;
            this.sala.TipoDeAcceso = tipoAcceso;
            this.sala.NumeroDeRondas = numeroRondas;
            this.sala.TiempoPorTurno = tiempoPorTurno;

            CargarConfiguracion();
        }

        public void MostrarDesconexionJugador(string nombreJugadorDesconectado)
        {
            for (int i = 0; i < this.sala.JugadoresEnSala.Count; i++)
            {
                if (entradasJugadoresEnSala[i].lbNombreJugador.Content.Equals(nombreJugadorDesconectado))
                {
                    gridsJugadoresEnSala[i].Children.Remove(entradasJugadoresEnSala[i]);

                    AjustarEntradasJugadoresEnSala(i);
                }
            }

            if (this.sala.JugadoresEnSala.ContainsKey(nombreJugadorDesconectado))
            {
                this.sala.JugadoresEnSala.Remove(nombreJugadorDesconectado);
            }
        }

        public void SalirDeSala()
        {
            throw new NotImplementedException();
        }

        private void AjustarEntradasJugadoresEnSala(int posicionJugadorDesconectado)
        {
            for (int i = posicionJugadorDesconectado; i < this.sala.JugadoresEnSala.Count - 1; i++)
            {
                entradasJugadoresEnSala[i] = entradasJugadoresEnSala[i + 1];

                gridsJugadoresEnSala[i + 1].Children.Remove(entradasJugadoresEnSala[i]);
                gridsJugadoresEnSala[i].Children.Add(entradasJugadoresEnSala[i]);
            }
        }
    }
}
