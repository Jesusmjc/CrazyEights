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
        int ActualizarConfiguracionSala(Sala sala);

        [OperationContract]
        void AgregarJugadorASala(int codigoSala, Jugador nuevoJugador);

        [OperationContract]
        void AgregarSalaAListaDeSalas(Sala nuevaSala);

        [OperationContract]
        bool VerificarCodigoSalaNoRepetido(int codigoSala);
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
        public Dictionary<string, Jugador> JugadoresEnSala {  get; set; }
    }
}
