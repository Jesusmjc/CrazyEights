using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyEightsServicio
{
    public partial class ServicioManejoJugadores : IServicioSala
    {
        public static Dictionary<int, Sala> listaSalas = new Dictionary<int, Sala>();

        public int ActualizarConfiguracionSala(Sala salaActualizada)
        {
            if (listaSalas.ContainsKey(salaActualizada.Codigo))
            {
                listaSalas[salaActualizada.Codigo] = salaActualizada;
            }

            return 1;
        }

        public void AgregarJugadorASala(int codigoSala, Jugador nuevoJugador) 
        {
            
        }

        public void AgregarSalaAListaDeSalas(Sala nuevaSala)
        {
            listaSalas.Add(nuevaSala.Codigo, nuevaSala);
        }

        public bool VerificarCodigoSalaNoRepetido(int codigoSala)
        {
            bool esCodigoNoRepetido = true;

            foreach (var sala in listaSalas)
            {
                if(sala.Key.Equals(codigoSala))
                {
                    esCodigoNoRepetido = false;
                }
            }

            return esCodigoNoRepetido;
        }
    }
}
