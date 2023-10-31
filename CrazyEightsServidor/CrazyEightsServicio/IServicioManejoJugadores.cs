using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CrazyEightsServicio
 {
    [ServiceContract]
    public interface IServicioManejoJugadores
    {
        [OperationContract]
        int GuardarJugador(Usuario usuario, Jugador jugador);

        [OperationContract]
        bool ValidarInicioSesion(Usuario usuario);

        [OperationContract]
        bool ValidarNombreUsuarioRegistrado(Jugador jugador);

        [OperationContract]
        bool ValidarCorreoElectronicoRegistrado(Usuario usuario);

        [OperationContract]
        string EnviarCodigoAlCorreoDelUsuario(string correoElectronico);
    }

    [DataContract]
    public class Usuario
    {
        private int _idUsuario;
        private string _contrasena;
        private string _correoElectronico;
        private int _idJugador;

        [DataMember]
        public int IdUsuario { get { return _idUsuario; } set { _idUsuario = value; } }

        [DataMember]
        public string Contrasena { get { return _contrasena; } set { _contrasena = value; } }

        [DataMember]
        public string CorreoElectronico { get { return _correoElectronico; } set { _correoElectronico = value; } }

        [DataMember]
        public int IdJugador { get { return _idJugador; } set { _idJugador = value; } }
    }

    [DataContract]
    public class Jugador
    {
        private int _idJugador;
        private string _nombreUsuario;
        private int _monedas;
        private string _fotoPerfil;
        private int _idUsuario;

        [DataMember]
        public int IdJugador { get { return _idJugador; } set { _idJugador = value; } }

        [DataMember]
        public string NombreUsuario { get { return _nombreUsuario; } set { _nombreUsuario = value; } }

        [DataMember]
        public int Monedas { get { return _monedas; } set { _monedas = value; } }

        [DataMember]
        public string FotoPerfil { get { return _fotoPerfil; } set { _fotoPerfil = value; } }

        [DataMember]
        public int IdUsuario { get { return _idUsuario; } set { _idUsuario = value; } }
    }
}
