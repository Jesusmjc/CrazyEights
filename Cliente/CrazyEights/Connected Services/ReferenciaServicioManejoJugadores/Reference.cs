﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CrazyEights.ReferenciaServicioManejoJugadores {
    using System.Runtime.Serialization;
    using System;
    using System.ServiceModel;

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Usuario", Namespace="http://schemas.datacontract.org/2004/07/CrazyEightsServicio")]
    [System.SerializableAttribute()]
    public partial class Usuario : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ContrasenaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CorreoElectronicoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdJugadorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdUsuarioField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Contrasena {
            get {
                return this.ContrasenaField;
            }
            set {
                if ((object.ReferenceEquals(this.ContrasenaField, value) != true)) {
                    this.ContrasenaField = value;
                    this.RaisePropertyChanged("Contrasena");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CorreoElectronico {
            get {
                return this.CorreoElectronicoField;
            }
            set {
                if ((object.ReferenceEquals(this.CorreoElectronicoField, value) != true)) {
                    this.CorreoElectronicoField = value;
                    this.RaisePropertyChanged("CorreoElectronico");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdJugador {
            get {
                return this.IdJugadorField;
            }
            set {
                if ((this.IdJugadorField.Equals(value) != true)) {
                    this.IdJugadorField = value;
                    this.RaisePropertyChanged("IdJugador");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdUsuario {
            get {
                return this.IdUsuarioField;
            }
            set {
                if ((this.IdUsuarioField.Equals(value) != true)) {
                    this.IdUsuarioField = value;
                    this.RaisePropertyChanged("IdUsuario");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Jugador", Namespace="http://schemas.datacontract.org/2004/07/CrazyEightsServicio")]
    [System.SerializableAttribute()]
    public partial class Jugador : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FotoPerfilField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdJugadorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdUsuarioField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int MonedasField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NombreUsuarioField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FotoPerfil {
            get {
                return this.FotoPerfilField;
            }
            set {
                if ((object.ReferenceEquals(this.FotoPerfilField, value) != true)) {
                    this.FotoPerfilField = value;
                    this.RaisePropertyChanged("FotoPerfil");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdJugador {
            get {
                return this.IdJugadorField;
            }
            set {
                if ((this.IdJugadorField.Equals(value) != true)) {
                    this.IdJugadorField = value;
                    this.RaisePropertyChanged("IdJugador");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdUsuario {
            get {
                return this.IdUsuarioField;
            }
            set {
                if ((this.IdUsuarioField.Equals(value) != true)) {
                    this.IdUsuarioField = value;
                    this.RaisePropertyChanged("IdUsuario");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Monedas {
            get {
                return this.MonedasField;
            }
            set {
                if ((this.MonedasField.Equals(value) != true)) {
                    this.MonedasField = value;
                    this.RaisePropertyChanged("Monedas");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NombreUsuario {
            get {
                return this.NombreUsuarioField;
            }
            set {
                if ((object.ReferenceEquals(this.NombreUsuarioField, value) != true)) {
                    this.NombreUsuarioField = value;
                    this.RaisePropertyChanged("NombreUsuario");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ReferenciaServicioManejoJugadores.IServicioManejoJugadores")]
    public interface IServicioManejoJugadores {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioManejoJugadores/GuardarJugador", ReplyAction="http://tempuri.org/IServicioManejoJugadores/GuardarJugadorResponse")]
        int GuardarJugador(CrazyEights.ReferenciaServicioManejoJugadores.Usuario usuario, CrazyEights.ReferenciaServicioManejoJugadores.Jugador jugador);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioManejoJugadores/GuardarJugador", ReplyAction="http://tempuri.org/IServicioManejoJugadores/GuardarJugadorResponse")]
        System.Threading.Tasks.Task<int> GuardarJugadorAsync(CrazyEights.ReferenciaServicioManejoJugadores.Usuario usuario, CrazyEights.ReferenciaServicioManejoJugadores.Jugador jugador);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioManejoJugadores/ValidarInicioSesion", ReplyAction="http://tempuri.org/IServicioManejoJugadores/ValidarInicioSesionResponse")]
        bool ValidarInicioSesion(CrazyEights.ReferenciaServicioManejoJugadores.Usuario usuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioManejoJugadores/ValidarInicioSesion", ReplyAction="http://tempuri.org/IServicioManejoJugadores/ValidarInicioSesionResponse")]
        System.Threading.Tasks.Task<bool> ValidarInicioSesionAsync(CrazyEights.ReferenciaServicioManejoJugadores.Usuario usuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioManejoJugadores/ValidarNombreUsuarioRegistrado", ReplyAction="http://tempuri.org/IServicioManejoJugadores/ValidarNombreUsuarioRegistradoRespons" +
            "e")]
        bool ValidarNombreUsuarioRegistrado(CrazyEights.ReferenciaServicioManejoJugadores.Jugador jugador);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioManejoJugadores/ValidarNombreUsuarioRegistrado", ReplyAction="http://tempuri.org/IServicioManejoJugadores/ValidarNombreUsuarioRegistradoRespons" +
            "e")]
        System.Threading.Tasks.Task<bool> ValidarNombreUsuarioRegistradoAsync(CrazyEights.ReferenciaServicioManejoJugadores.Jugador jugador);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioManejoJugadores/ValidarCorreoElectronicoRegistrado", ReplyAction="http://tempuri.org/IServicioManejoJugadores/ValidarCorreoElectronicoRegistradoRes" +
            "ponse")]
        bool ValidarCorreoElectronicoRegistrado(CrazyEights.ReferenciaServicioManejoJugadores.Usuario usuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioManejoJugadores/ValidarCorreoElectronicoRegistrado", ReplyAction="http://tempuri.org/IServicioManejoJugadores/ValidarCorreoElectronicoRegistradoRes" +
            "ponse")]
        System.Threading.Tasks.Task<bool> ValidarCorreoElectronicoRegistradoAsync(CrazyEights.ReferenciaServicioManejoJugadores.Usuario usuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioManejoJugadores/EnviarCodigoAlCorreoDelUsuario", ReplyAction="http://tempuri.org/IServicioManejoJugadores/EnviarCodigoAlCorreoDelUsuarioRespons" +
            "e")]
        string EnviarCodigoAlCorreoDelUsuario(string correoElectronico);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioManejoJugadores/EnviarCodigoAlCorreoDelUsuario", ReplyAction="http://tempuri.org/IServicioManejoJugadores/EnviarCodigoAlCorreoDelUsuarioRespons" +
            "e")]
        System.Threading.Tasks.Task<string> EnviarCodigoAlCorreoDelUsuarioAsync(string correoElectronico);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServicioManejoJugadoresChannel : CrazyEights.ReferenciaServicioManejoJugadores.IServicioManejoJugadores, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServicioManejoJugadoresClient : System.ServiceModel.ClientBase<CrazyEights.ReferenciaServicioManejoJugadores.IServicioManejoJugadores>, CrazyEights.ReferenciaServicioManejoJugadores.IServicioManejoJugadores {
        
        public ServicioManejoJugadoresClient() {
        }
        
        public ServicioManejoJugadoresClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServicioManejoJugadoresClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioManejoJugadoresClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioManejoJugadoresClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }

        public ServicioManejoJugadoresClient(InstanceContext callbackInstance) : base(callbackInstance)
        {
        }

        public int GuardarJugador(CrazyEights.ReferenciaServicioManejoJugadores.Usuario usuario, CrazyEights.ReferenciaServicioManejoJugadores.Jugador jugador) {
            return base.Channel.GuardarJugador(usuario, jugador);
        }
        
        public System.Threading.Tasks.Task<int> GuardarJugadorAsync(CrazyEights.ReferenciaServicioManejoJugadores.Usuario usuario, CrazyEights.ReferenciaServicioManejoJugadores.Jugador jugador) {
            return base.Channel.GuardarJugadorAsync(usuario, jugador);
        }
        
        public bool ValidarInicioSesion(CrazyEights.ReferenciaServicioManejoJugadores.Usuario usuario) {
            return base.Channel.ValidarInicioSesion(usuario);
        }
        
        public System.Threading.Tasks.Task<bool> ValidarInicioSesionAsync(CrazyEights.ReferenciaServicioManejoJugadores.Usuario usuario) {
            return base.Channel.ValidarInicioSesionAsync(usuario);
        }
        
        public bool ValidarNombreUsuarioRegistrado(CrazyEights.ReferenciaServicioManejoJugadores.Jugador jugador) {
            return base.Channel.ValidarNombreUsuarioRegistrado(jugador);
        }
        
        public System.Threading.Tasks.Task<bool> ValidarNombreUsuarioRegistradoAsync(CrazyEights.ReferenciaServicioManejoJugadores.Jugador jugador) {
            return base.Channel.ValidarNombreUsuarioRegistradoAsync(jugador);
        }
        
        public bool ValidarCorreoElectronicoRegistrado(CrazyEights.ReferenciaServicioManejoJugadores.Usuario usuario) {
            return base.Channel.ValidarCorreoElectronicoRegistrado(usuario);
        }
        
        public System.Threading.Tasks.Task<bool> ValidarCorreoElectronicoRegistradoAsync(CrazyEights.ReferenciaServicioManejoJugadores.Usuario usuario) {
            return base.Channel.ValidarCorreoElectronicoRegistradoAsync(usuario);
        }
        
        public string EnviarCodigoAlCorreoDelUsuario(string correoElectronico) {
            return base.Channel.EnviarCodigoAlCorreoDelUsuario(correoElectronico);
        }
        
        public System.Threading.Tasks.Task<string> EnviarCodigoAlCorreoDelUsuarioAsync(string correoElectronico) {
            return base.Channel.EnviarCodigoAlCorreoDelUsuarioAsync(correoElectronico);
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ReferenciaServicioManejoJugadores.IManejadorJugadoresEnLinea", CallbackContract=typeof(CrazyEights.ReferenciaServicioManejoJugadores.IManejadorJugadoresEnLineaCallback))]
    public interface IManejadorJugadoresEnLinea {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IManejadorJugadoresEnLinea/NotificarNuevaConexionAJugadoresEnL" +
            "inea")]
        void NotificarNuevaConexionAJugadoresEnLinea(string nombreJugador);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IManejadorJugadoresEnLinea/NotificarNuevaConexionAJugadoresEnL" +
            "inea")]
        System.Threading.Tasks.Task NotificarNuevaConexionAJugadoresEnLineaAsync(string nombreJugador);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IManejadorJugadoresEnLinea/NotificarDesconexionAJugadoresEnLin" +
            "ea")]
        void NotificarDesconexionAJugadoresEnLinea(string nombreJugador);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IManejadorJugadoresEnLinea/NotificarDesconexionAJugadoresEnLin" +
            "ea")]
        System.Threading.Tasks.Task NotificarDesconexionAJugadoresEnLineaAsync(string nombreJugador);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IManejadorJugadoresEnLineaCallback {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManejadorJugadoresEnLinea/NotificarLogInJugador", ReplyAction="http://tempuri.org/IManejadorJugadoresEnLinea/NotificarLogInJugadorResponse")]
        void NotificarLogInJugador(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManejadorJugadoresEnLinea/NotificarLogOutJugador", ReplyAction="http://tempuri.org/IManejadorJugadoresEnLinea/NotificarLogOutJugadorResponse")]
        void NotificarLogOutJugador(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManejadorJugadoresEnLinea/NotificarJugadoresEnLinea", ReplyAction="http://tempuri.org/IManejadorJugadoresEnLinea/NotificarJugadoresEnLineaResponse")]
        void NotificarJugadoresEnLinea(string[] nombresUsuariosEnLinea);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IManejadorJugadoresEnLineaChannel : CrazyEights.ReferenciaServicioManejoJugadores.IManejadorJugadoresEnLinea, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ManejadorJugadoresEnLineaClient : System.ServiceModel.DuplexClientBase<CrazyEights.ReferenciaServicioManejoJugadores.IManejadorJugadoresEnLinea>, CrazyEights.ReferenciaServicioManejoJugadores.IManejadorJugadoresEnLinea {
        
        public ManejadorJugadoresEnLineaClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public ManejadorJugadoresEnLineaClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public ManejadorJugadoresEnLineaClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ManejadorJugadoresEnLineaClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ManejadorJugadoresEnLineaClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void NotificarNuevaConexionAJugadoresEnLinea(string nombreJugador) {
            base.Channel.NotificarNuevaConexionAJugadoresEnLinea(nombreJugador);
        }
        
        public System.Threading.Tasks.Task NotificarNuevaConexionAJugadoresEnLineaAsync(string nombreJugador) {
            return base.Channel.NotificarNuevaConexionAJugadoresEnLineaAsync(nombreJugador);
        }
        
        public void NotificarDesconexionAJugadoresEnLinea(string nombreJugador) {
            base.Channel.NotificarDesconexionAJugadoresEnLinea(nombreJugador);
        }
        
        public System.Threading.Tasks.Task NotificarDesconexionAJugadoresEnLineaAsync(string nombreJugador) {
            return base.Channel.NotificarDesconexionAJugadoresEnLineaAsync(nombreJugador);
        }
    }
}
