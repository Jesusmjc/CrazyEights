using CrazyEights.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyEights
{
    public class Baraja
    {
        List<Carta> cartas;
        public Baraja()
        {
            cartas = GenerarTodasLasCartas();
            AsociarCartasAImagenes();
        }

        public Carta SacarCartaAleatoria()
        {
            if (cartas.Count > 0)
            {
                Random aleatorio = new Random();
                int indiceAleatorio = aleatorio.Next(0, cartas.Count);

                Carta carta = cartas[indiceAleatorio];
                cartas.RemoveAt(indiceAleatorio);

                return carta;
            }
            else
            {
                return null;
            }
        }

        private void AsociarCartasAImagenes()
        {
            string direccionBaseDeDirectorio = System.AppDomain.CurrentDomain.BaseDirectory;
            Directory.SetCurrentDirectory(System.IO.Path.Combine(direccionBaseDeDirectorio, "..\\..\\"));

            string directorioActual = Directory.GetCurrentDirectory();
            string nombreFolderRecursos = Settings.Default.Cartas;
            string direccionFinalDeFolderRecursos = System.IO.Path.Combine(directorioActual, nombreFolderRecursos);

            foreach (var carta in cartas)
            {
                string imagePath = System.IO.Path.Combine(direccionFinalDeFolderRecursos, $"{carta.Nombre}.png");
                carta.DireccionImagen = imagePath;
            }
        }

        private List<Carta> GenerarTodasLasCartas()
        {
            return new List<Carta>
            {
                new Carta
                {
                    Nombre = "10C",
                    NumeroDeCarta = 10,
                    TipoDePalo = TipoDePalo.Corazon
                },
                new Carta
                {
                    Nombre = "10D",
                    NumeroDeCarta = 10,
                    TipoDePalo = TipoDePalo.Diamante
                },
                new Carta
                {
                    Nombre = "10P",
                    NumeroDeCarta = 10,
                    TipoDePalo = TipoDePalo.Pica
                },
                new Carta
                {
                    Nombre = "10T",
                    NumeroDeCarta = 10,
                    TipoDePalo = TipoDePalo.Trebol
                },
                new Carta
                {
                    Nombre = "2C",
                    NumeroDeCarta = 2,
                    TipoDePalo = TipoDePalo.Corazon
                },
                new Carta
                {
                    Nombre = "2D",
                    NumeroDeCarta = 2,
                    TipoDePalo = TipoDePalo.Diamante
                },
                new Carta
                {
                    Nombre = "2P",
                    NumeroDeCarta = 2,
                    TipoDePalo = TipoDePalo.Pica
                },
                new Carta
                {
                    Nombre = "2T",
                    NumeroDeCarta = 2,
                    TipoDePalo = TipoDePalo.Trebol
                },
                new Carta
                {
                    Nombre = "3C",
                    NumeroDeCarta = 3,
                    TipoDePalo = TipoDePalo.Corazon
                },
                new Carta
                {
                    Nombre = "3D",
                    NumeroDeCarta = 3,
                    TipoDePalo = TipoDePalo.Diamante
                },
                new Carta
                {
                    Nombre = "3P",
                    NumeroDeCarta = 3,
                    TipoDePalo = TipoDePalo.Pica
                },
                new Carta
                {
                    Nombre = "3T",
                    NumeroDeCarta = 3,
                    TipoDePalo = TipoDePalo.Trebol
                },
                new Carta
                {
                    Nombre = "4C",
                    NumeroDeCarta = 4,
                    TipoDePalo = TipoDePalo.Corazon
                },
                new Carta
                {
                    Nombre = "4D",
                    NumeroDeCarta = 4,
                    TipoDePalo = TipoDePalo.Diamante
                },
                new Carta
                {
                    Nombre = "4P",
                    NumeroDeCarta = 4,
                    TipoDePalo = TipoDePalo.Pica
                },
                new Carta
                {
                    Nombre = "4T",
                    NumeroDeCarta = 4,
                    TipoDePalo = TipoDePalo.Trebol
                },
                new Carta
                {
                    Nombre = "5C",
                    NumeroDeCarta = 5,
                    TipoDePalo = TipoDePalo.Corazon
                },
                new Carta
                {
                    Nombre = "5D",
                    NumeroDeCarta = 5,
                    TipoDePalo = TipoDePalo.Diamante
                },
                new Carta
                {
                    Nombre = "5P",
                    NumeroDeCarta = 5,
                    TipoDePalo = TipoDePalo.Pica
                },
                new Carta
                {
                    Nombre = "5T",
                    NumeroDeCarta = 5,
                    TipoDePalo = TipoDePalo.Trebol
                },
                new Carta
                {
                    Nombre = "6C",
                    NumeroDeCarta = 6,
                    TipoDePalo = TipoDePalo.Corazon
                },
                new Carta
                {
                    Nombre = "6D",
                    NumeroDeCarta = 6,
                    TipoDePalo = TipoDePalo.Diamante
                },
                new Carta
                {
                    Nombre = "6P",
                    NumeroDeCarta = 6,
                    TipoDePalo = TipoDePalo.Pica
                },
                new Carta
                {
                    Nombre = "6T",
                    NumeroDeCarta = 6,
                    TipoDePalo = TipoDePalo.Trebol
                },
                new Carta
                {
                    Nombre = "7C",
                    NumeroDeCarta = 7,
                    TipoDePalo = TipoDePalo.Corazon
                },
                new Carta
                {
                    Nombre = "7D",
                    NumeroDeCarta = 7,
                    TipoDePalo = TipoDePalo.Diamante
                },
                new Carta
                {
                    Nombre = "7P",
                    NumeroDeCarta = 7,
                    TipoDePalo = TipoDePalo.Pica
                },
                new Carta
                {
                    Nombre = "7T",
                    NumeroDeCarta = 7,
                    TipoDePalo = TipoDePalo.Trebol
                },
                new Carta
                {
                    Nombre = "8C",
                    NumeroDeCarta = 8,
                    TipoDePalo = TipoDePalo.Corazon
                },
                new Carta
                {
                    Nombre = "8D",
                    NumeroDeCarta = 8,
                    TipoDePalo = TipoDePalo.Diamante
                },
                new Carta
                {
                    Nombre = "8P",
                    NumeroDeCarta = 8,
                    TipoDePalo = TipoDePalo.Pica
                },
                new Carta
                {
                    Nombre = "8T",
                    NumeroDeCarta = 8,
                    TipoDePalo = TipoDePalo.Trebol
                },
                new Carta
                {
                    Nombre = "9C",
                    NumeroDeCarta = 9,
                    TipoDePalo = TipoDePalo.Corazon
                },
                new Carta
                {
                    Nombre = "9D",
                    NumeroDeCarta = 9,
                    TipoDePalo = TipoDePalo.Diamante
                },
                new Carta
                {
                    Nombre = "9P",
                    NumeroDeCarta = 9,
                    TipoDePalo = TipoDePalo.Pica
                },
                new Carta
                {
                    Nombre = "9T",
                    NumeroDeCarta = 9,
                    TipoDePalo = TipoDePalo.Trebol
                },
                new Carta
                {
                    Nombre = "AC",
                    NumeroDeCarta = 1,
                    TipoDePalo = TipoDePalo.Corazon
                },
                new Carta
                {
                    Nombre = "AD",
                    NumeroDeCarta = 1,
                    TipoDePalo = TipoDePalo.Diamante
                },
                new Carta
                {
                    Nombre = "AP",
                    NumeroDeCarta = 1,
                    TipoDePalo = TipoDePalo.Pica
                },
                new Carta
                {
                    Nombre = "AT",
                    NumeroDeCarta = 1,
                    TipoDePalo = TipoDePalo.Trebol
                },
                new Carta
                {
                    Nombre = "JC",
                    NumeroDeCarta = 11,
                    TipoDePalo = TipoDePalo.Corazon
                },
                new Carta
                {
                    Nombre = "JD",
                    NumeroDeCarta = 11,
                    TipoDePalo = TipoDePalo.Diamante
                },
                new Carta
                {
                    Nombre = "JP",
                    NumeroDeCarta = 11,
                    TipoDePalo = TipoDePalo.Pica
                },
                new Carta
                {
                    Nombre = "JT",
                    NumeroDeCarta = 11,
                    TipoDePalo = TipoDePalo.Trebol
                },
                new Carta
                {
                    Nombre = "QC",
                    NumeroDeCarta = 12,
                    TipoDePalo = TipoDePalo.Corazon
                },
                new Carta
                {
                    Nombre = "QD",
                    NumeroDeCarta = 12,
                    TipoDePalo = TipoDePalo.Diamante
                },
                new Carta
                {
                    Nombre = "QP",
                    NumeroDeCarta = 12,
                    TipoDePalo = TipoDePalo.Pica
                },
                new Carta
                {
                    Nombre = "QT",
                    NumeroDeCarta = 12,
                    TipoDePalo = TipoDePalo.Trebol
                },
                new Carta
                {
                    Nombre = "RC",
                    NumeroDeCarta = 13,
                    TipoDePalo = TipoDePalo.Corazon
                },
                new Carta
                {
                    Nombre = "RD",
                    NumeroDeCarta = 13,
                    TipoDePalo = TipoDePalo.Diamante
                },
                new Carta
                {
                    Nombre = "RP",
                    NumeroDeCarta = 13,
                    TipoDePalo = TipoDePalo.Pica
                },
                new Carta
                {
                    Nombre = "RT",
                    NumeroDeCarta = 13,
                    TipoDePalo = TipoDePalo.Trebol
                }

            };

        }

    }
}
