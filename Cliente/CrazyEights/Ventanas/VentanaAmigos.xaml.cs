using CrazyEights.ReferenciaServicioManejoJugadores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace CrazyEights.Ventanas
{
    /// <summary>
    /// Interaction logic for VentanaAmigos.xaml
    /// </summary>
    public partial class VentanaAmigos : Window, IManejadorJugadoresEnLineaCallback
    {
        public ObservableCollection<EntradaJugador> ListaDeJugadoresConectados { get; } = new ObservableCollection<EntradaJugador>();

        public VentanaAmigos()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.ResizeMode = ResizeMode.NoResize;
            DataContext = this;
            MostrarJugadoresEnLinea();
        }

        public void MostrarJugadoresEnLinea()
        {
            InstanceContext contexto = new InstanceContext(this);
            ReferenciaServicioManejoJugadores.ManejadorJugadoresEnLineaClient cliente = new ReferenciaServicioManejoJugadores.ManejadorJugadoresEnLineaClient(contexto);

            Jugador[] jugadoresEnLinea = cliente.RecuperarInformacionJugadoresEnLinea();

            foreach (var jugadorEnLinea in jugadoresEnLinea)
            {
                if (jugadorEnLinea.NombreUsuario != SingletonJugador.Instance.NombreJugador)
                {
                    ListaDeJugadoresConectados.Add(new EntradaJugador(jugadorEnLinea.NombreUsuario, "ID: " + jugadorEnLinea.IdJugador, jugadorEnLinea.Estado));
                }
            }
        }

        public void NotificarLogInJugador(Jugador nuevoJugador)
        {
            ListaDeJugadoresConectados.Add(new EntradaJugador(nuevoJugador.NombreUsuario, "ID: " + nuevoJugador.IdJugador, nuevoJugador.Estado));
        }

        public void NotificarLogOutJugador(string nombreJugador)
        {
            foreach (var jugadorConectado in ListaDeJugadoresConectados)
            {
                if (jugadorConectado.lbNombreJugador.Content.Equals(nombreJugador))
                {
                    ListaDeJugadoresConectados.Remove(jugadorConectado);
                }
            }
        }

        public void NotificarJugadoresEnLinea(string[] nombresUsuariosEnLinea)
        {
            throw new NotImplementedException();
        }

        private void NavegarAMenuPrincipal(object sender, MouseButtonEventArgs e)
        {
            VentanaMenuPrincipal ventanaMenuPrincipal = new VentanaMenuPrincipal();
            this.Close();
            ventanaMenuPrincipal.ShowDialog();
        }
    }
}
