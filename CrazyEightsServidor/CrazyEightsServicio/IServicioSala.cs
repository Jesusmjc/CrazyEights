using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CrazyEightsServicio
{
    [ServiceContract]
    public interface IServicioSala
    {
        [OperationContract]
        void AgregarSalaAListaDeSalas(Sala nuevaSala);

        [OperationContract]
        bool VerificarCodigoSalaNoRepetido(int codigoSala);

        [OperationContract]
        Sala RecuperarSala(int codigoSala);
    }

    [ServiceContract(CallbackContract = typeof(IServicioSalaCallback))]
    public interface IServicioActualizacionSala
    {
        [OperationContract]
        bool AgregarJugadorASala(int codigoSala, Jugador nuevoJugador);

        [OperationContract]
        void ActualizarEstadoJugadorEnSala(int codigoSala, string nombreJugador, string estadoJugador);

        [OperationContract]
        void ActualizarConfiguracionDeSala(int codigoSala, string nombre, string modoJuego, string tipoAcceso, int numeroRondas, int tiempoPorTurno);

        [OperationContract]
        void NotificarDesconexionDeSala(int codigoSala, string nombreJugadorDesconectado);
    }

    [ServiceContract]
    public interface IServicioSalaCallback
    {
        [OperationContract]
        void MostrarNuevoJugadorEnSala(Jugador jugador);

        [OperationContract]
        void MostrarNuevoEstadoJugadorEnSala(string nombreJugador, string estadoJugador);

        [OperationContract]
        void MostrarNuevoConfiguracionSala(string nombre, string modoJuego, string tipoAcceso, int numeroRondas, int tiempoPorTurno);

        [OperationContract]
        void MostrarDesconexionJugador(string nombreJugadorDesconectado);

        [OperationContract]
        void SalirDeSala();
    }

    [DataContract]
    public class Sala
    {
        private int _idSala;
        private int _codigo;
        private string _nombre;
        private string _modoDeJuego;
        private int _numeroDeRondas;
        private string _tipoDeAcceso;
        private Jugador _host;
        private Dictionary<string, Jugador> _jugadoresEnSala;

        [DataMember]
        public int IdSala { get; set; }

        [DataMember]
        public int Codigo { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string ModoDeJuego { get; set; }

        [DataMember]
        public int NumeroDeRondas { get; set; }

        [DataMember]
        public string TipoDeAcceso { get; set; }

        [DataMember]
        public int TiempoPorTurno { get; set; }

        [DataMember]
        public Jugador Host { get; set; }

        [DataMember]
        public Dictionary<string, Jugador> JugadoresEnSala {  get; set; }
    }
}
