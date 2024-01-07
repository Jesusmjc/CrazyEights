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
        public static Dictionary<string, bool> listaEstadoJugadores = new Dictionary<string, bool>();

        public void ActualizarConfiguracionSala(Sala salaActualizada)
        {
            if (listaSalas.ContainsKey(salaActualizada.Codigo))
            {
                listaSalas[salaActualizada.Codigo] = salaActualizada;
            }
        }

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
                    operacionExitosa = true;
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

                    operacionExitosa = true;
                }
            }
            return operacionExitosa;
        }

        public void ActualizarEstadoJugadorEnSala(int codigoSala, string nombreJugador)
        {
            if (listaSalas.ContainsKey(codigoSala))
            {
                if (listaSalas[codigoSala].JugadoresEnSala.ContainsKey(nombreJugador))
                {
                    foreach (var jugadorEnSala in listaSalas[codigoSala].JugadoresEnSala)
                    {
                        if (!jugadorEnSala.Value.NombreUsuario.Equals(nombreJugador))
                        {
                            jugadorEnSala.Value.CanalCallbackServicioSala.MostrarNuevoEstadoJugadorEnSala(nombreJugador);
                        }
                    }

                    if (listaEstadoJugadores[nombreJugador])
                    {
                        listaEstadoJugadores[nombreJugador] = false;
                    }
                    else
                    {
                        listaEstadoJugadores[nombreJugador] = true;
                    }
                }
            }
        }
    }
}
