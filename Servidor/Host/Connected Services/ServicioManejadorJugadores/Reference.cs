﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Host.ServicioManejadorJugadores {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServicioManejadorJugadores.IManejadorJugadores")]
    public interface IManejadorJugadores {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManejadorJugadores/GuardarJugador", ReplyAction="http://tempuri.org/IManejadorJugadores/GuardarJugadorResponse")]
        int GuardarJugador(CrazyEightsServicio.Usuario usuario, CrazyEightsServicio.Jugador jugador);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManejadorJugadores/GuardarJugador", ReplyAction="http://tempuri.org/IManejadorJugadores/GuardarJugadorResponse")]
        System.Threading.Tasks.Task<int> GuardarJugadorAsync(CrazyEightsServicio.Usuario usuario, CrazyEightsServicio.Jugador jugador);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IManejadorJugadoresChannel : Host.ServicioManejadorJugadores.IManejadorJugadores, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ManejadorJugadoresClient : System.ServiceModel.ClientBase<Host.ServicioManejadorJugadores.IManejadorJugadores>, Host.ServicioManejadorJugadores.IManejadorJugadores {
        
        public ManejadorJugadoresClient() {
        }
        
        public ManejadorJugadoresClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ManejadorJugadoresClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ManejadorJugadoresClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ManejadorJugadoresClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int GuardarJugador(CrazyEightsServicio.Usuario usuario, CrazyEightsServicio.Jugador jugador) {
            return base.Channel.GuardarJugador(usuario, jugador);
        }
        
        public System.Threading.Tasks.Task<int> GuardarJugadorAsync(CrazyEightsServicio.Usuario usuario, CrazyEightsServicio.Jugador jugador) {
            return base.Channel.GuardarJugadorAsync(usuario, jugador);
        }
    }
}
