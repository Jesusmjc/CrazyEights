﻿using System;
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
        Jugador ValidarInicioSesion(Usuario usuario);

        [OperationContract]
        bool ValidarNombreUsuarioRegistrado(Jugador jugador);

        [OperationContract]
        bool ValidarCorreoElectronicoRegistrado(Usuario usuario);

        [OperationContract]
        string EnviarCodigoAlCorreoDelUsuario(string correoElectronico);
        [OperationContract]
        bool ActualizarFotoPerfil(int idJugador, string nuevaDireccionFotoPerfil);
        [OperationContract]
        bool ActualizarNombreUsuario(int idJugador, string nuevoNombreUsuario);
        [OperationContract]
        string ObtenerDireccionFotoPerfil(int idJugador);
        [OperationContract]
        string ObtenerNombreUsuario(int idJugador);
        [OperationContract]
        bool CambiarContraseña(string correoElectronico, string nuevaContrasena);
    }

    [ServiceContract(CallbackContract = typeof(IManejadorJugadoresCallback))]
    public interface IManejadorJugadoresEnLinea
    {
        [OperationContract(IsOneWay = true)]
        void NotificarNuevaConexionAJugadoresEnLinea(Jugador jugador);

        [OperationContract(IsOneWay = true)]
        void NotificarDesconexionAJugadoresEnLinea(string nombreJugador);

        [OperationContract]
        List<Jugador> RecuperarInformacionJugadoresEnLinea();
    }

    [ServiceContract]
    public interface IManejadorJugadoresCallback
    {
        [OperationContract]
        void NotificarLogInJugador(Jugador nuevoJugadorEnLinea);

        [OperationContract]
        void NotificarLogOutJugador(string nombreJugador);

        [OperationContract]
        void NotificarJugadoresEnLinea(List<string> nombresUsuariosEnLinea);
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
        private string _estado;
        private IManejadorJugadoresCallback _canalCallback;

        [DataMember]
        public int IdJugador { get { return _idJugador; } set { _idJugador = value; } }

        [DataMember]
        public string NombreUsuario { get { return _nombreUsuario; } set { _nombreUsuario = value; } }

        [DataMember]
        public int Monedas { get { return _monedas; } set { _monedas = value; } }

        [DataMember]
        public string FotoPerfil { get { return _fotoPerfil; } set { _fotoPerfil = value; } }

        [DataMember]
        public string Estado { get { return _estado; } set { _estado = value; } }

        [DataMember]
        public IManejadorJugadoresCallback CanalCallback { get { return _canalCallback; } set { _canalCallback = value; } }
    }
}
