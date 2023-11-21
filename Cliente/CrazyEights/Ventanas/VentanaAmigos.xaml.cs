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
            DataContext = this;
            mostrarJugadoresEnLinea();
        }

        public void mostrarJugadoresEnLinea()
        {
            InstanceContext contexto = new InstanceContext(this);
            ReferenciaServicioManejoJugadores.ManejadorJugadoresEnLineaClient cliente = new ReferenciaServicioManejoJugadores.ManejadorJugadoresEnLineaClient(contexto);

            string[] nombresJugadoresEnLinea = cliente.RecuperarNombresJugadoresEnLinea();

            foreach (var nombreJugador in nombresJugadoresEnLinea)
            {
                if (nombreJugador != SingletonJugador.Instance.NombreJugador)
                {
                    ListaDeJugadoresConectados.Add(new EntradaJugador(nombreJugador, "ID: WIP", "Estado WIP"));
                }
            }
        }

        public void NotificarLogInJugador(string nombreJugador)
        {
            ListaDeJugadoresConectados.Add(new EntradaJugador(nombreJugador, "ID: WIP", "Estado WIP"));
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
    }
}
