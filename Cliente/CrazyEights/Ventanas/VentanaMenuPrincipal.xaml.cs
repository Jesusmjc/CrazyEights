using CrazyEights.ReferenciaServicioManejoJugadores;
using CrazyEights.Ventanas;
using System;
using System.Collections.Generic;
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

namespace CrazyEights
{
    /// <summary>
    /// Interaction logic for VentanaMenuPrincipal.xaml
    /// </summary>
    public partial class VentanaMenuPrincipal : Window, IManejadorJugadoresEnLineaCallback
    {
        public VentanaMenuPrincipal()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            MostrarComoJugadorEnLinea();
        }

        private void NavegarAListaAmigos(object sender, MouseButtonEventArgs e)
        {
            VentanaAmigos ventanaAmigos = new VentanaAmigos();
            this.Close();
            ventanaAmigos.ShowDialog();
        }

        private void MostrarComoJugadorEnLinea()
        {
            InstanceContext contexto = new InstanceContext(this);
            ReferenciaServicioManejoJugadores.ManejadorJugadoresEnLineaClient cliente = new ReferenciaServicioManejoJugadores.ManejadorJugadoresEnLineaClient(contexto);
            Jugador jugador = new Jugador
            {
                IdJugador = SingletonJugador.Instance.IdJugador,
                NombreUsuario = SingletonJugador.Instance.NombreJugador,
                Estado = "Conectado"
            };

            cliente.NotificarNuevaConexionAJugadoresEnLinea(jugador);
        }

        //Es necesario implementarlos para ejecutar la línea 43, pero no hacen nada en esta ventana.
        public void NotificarLogInJugador(Jugador jugador)
        {
            Console.WriteLine("Se ha conectado un nuevo usuario: " + jugador.NombreUsuario);
        }

        public void NotificarLogOutJugador(string username)
        {
            throw new NotImplementedException();
        }

        public void NotificarJugadoresEnLinea(string[] nombresUsuariosEnLinea)
        {
            throw new NotImplementedException();
        }
    }
}
