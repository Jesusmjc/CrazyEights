using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CrazyEightsServicio
{
    public partial class ServicioManejoJugadores : IServicioSala
    {
        public static Dictionary<int, Sala> listaSalas = new Dictionary<int, Sala>();

        public void AgregarSalaAListaDeSalas(Sala nuevaSala)
        {
            if (!listaSalas.ContainsKey(nuevaSala.Codigo))
            {
                listaSalas.Add(nuevaSala.Codigo, nuevaSala);
            }
        }

        public bool VerificarCodigoSalaNoRepetido(int codigoNuevaSala)
        {
            bool esCodigoNoRepetido = true;

            if (listaSalas.ContainsKey(codigoNuevaSala))
            {
                esCodigoNoRepetido = false;
            }

            return esCodigoNoRepetido;
        }

        public Sala RecuperarSala(int codigoSala)
        {
            Sala sala = new Sala();

            if (listaSalas.ContainsKey(codigoSala))
            {
                sala = listaSalas[codigoSala];
            }

            return sala;
        }
    }

    public partial class ServicioManejoJugadores : IServicioActualizacionSala
    {
        public bool AgregarJugadorASala(int codigoSala, Jugador nuevoJugador)
        {
            bool operacionExitosa = false;

            if (listaSalas.ContainsKey(codigoSala))
            {
                if (listaSalas[codigoSala].JugadoresEnSala.ContainsKey(nuevoJugador.NombreUsuario))
                {
                    listaSalas[codigoSala].JugadoresEnSala[nuevoJugador.NombreUsuario].CanalCallbackServicioSala = OperationContext.Current.GetCallbackChannel<IServicioSalaCallback>();
                }
                else if (listaSalas[codigoSala].JugadoresEnSala.Count <= 3)
                {
                    nuevoJugador.CanalCallbackServicioSala = OperationContext.Current.GetCallbackChannel<IServicioSalaCallback>();
                    listaSalas[codigoSala].JugadoresEnSala.Add(nuevoJugador.NombreUsuario, nuevoJugador);

                    foreach (var jugador in listaSalas[codigoSala].JugadoresEnSala)
                    {
                        if (!jugador.Value.NombreUsuario.Equals(nuevoJugador.NombreUsuario))
                        {
                            jugador.Value.CanalCallbackServicioSala.MostrarNuevoJugadorEnSala(nuevoJugador);
                        }
                    }
                }

                listaSalas[codigoSala].JugadoresEnSala[nuevoJugador.NombreUsuario].Estado = "En espera";
                operacionExitosa = true;
            }
            return operacionExitosa;
        }

        public void ActualizarEstadoJugadorEnSala(int codigoSala, string nombreJugador, string estadoJugador)
        {
            if (listaSalas.ContainsKey(codigoSala))
            {
                if (listaSalas[codigoSala].JugadoresEnSala.ContainsKey(nombreJugador))
                {
                    listaSalas[codigoSala].JugadoresEnSala[nombreJugador].Estado = estadoJugador;

                    foreach (var jugadorEnSala in listaSalas[codigoSala].JugadoresEnSala)
                    {
                        if (!jugadorEnSala.Value.NombreUsuario.Equals(nombreJugador))
                        {
                            jugadorEnSala.Value.CanalCallbackServicioSala.MostrarNuevoEstadoJugadorEnSala(nombreJugador, estadoJugador);
                        }
                    }
                }
            }
        }

        public void ActualizarConfiguracionDeSala(int codigoSala, string nombre, string modoJuego, string tipoAcceso, int numeroRondas, int tiempoPorTurno)
        {
            if (listaSalas.ContainsKey(codigoSala))
            {
                listaSalas[codigoSala].Nombre = nombre;
                listaSalas[codigoSala].ModoDeJuego = modoJuego;
                listaSalas[codigoSala].TipoDeAcceso = tipoAcceso;
                listaSalas[codigoSala].NumeroDeRondas = numeroRondas;
                listaSalas[codigoSala].TiempoPorTurno = tiempoPorTurno;

                foreach (var jugador in listaSalas[codigoSala].JugadoresEnSala)
                {
                    if (!jugador.Value.NombreUsuario.Equals(listaSalas[codigoSala].Host.NombreUsuario))
                    {
                        jugador.Value.CanalCallbackServicioSala.MostrarNuevoConfiguracionSala(nombre, modoJuego, tipoAcceso, numeroRondas, tiempoPorTurno);
                    }
                }
            }
        }

        public void NotificarDesconexionDeSala(int codigoSala, string nombreJugadorDesconectado)
        { 
            if (listaSalas.ContainsKey(codigoSala))
            {
                if (listaSalas[codigoSala].JugadoresEnSala.ContainsKey(nombreJugadorDesconectado))
                {
                    listaSalas[codigoSala].JugadoresEnSala.Remove(nombreJugadorDesconectado);

                    if (listaSalas[codigoSala].JugadoresEnSala.Count > 0)
                    {
                        if (nombreJugadorDesconectado.Equals(listaSalas[codigoSala].Host.NombreUsuario))
                        {
                            foreach (var jugador in listaSalas[codigoSala].JugadoresEnSala)
                            {
                                jugador.Value.CanalCallbackServicioSala.SalirDeSala();
                            }

                            listaSalas.Remove(codigoSala);
                        }
                        else
                        {
                            foreach (var jugador in listaSalas[codigoSala].JugadoresEnSala)
                            {
                                jugador.Value.CanalCallbackServicioSala.MostrarDesconexionJugador(nombreJugadorDesconectado);
                            }  
                        }
                    }
                    else
                    {
                        listaSalas.Remove(codigoSala);
                    }
                }
            }
        }
    }
}
