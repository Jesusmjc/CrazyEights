using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CrazyEights.Ventanas
{
    /// <summary>
    /// Interaction logic for VentanaJuegoDeCartas.xaml
    /// </summary>
    public partial class VentanaJuegoDeCartas : Window
    {
        private int _NUMERO_CARTAS_2_JUGADORES = 7;
        private int _NUMERO_CARTAS_3a4_JUGADORES = 5;

        private Baraja _baraja = new Baraja();
        private LogicaJuego _logicajuego = new LogicaJuego();
        public VentanaJuegoDeCartas()
        {
            InitializeComponent();
            SacarCartaInicial();
            RepartirCartasAScroll();
        }

        public void SacarCartaInicial()
        {
            Carta cartaAleatoria = _baraja.SacarCartaAleatoria();
            if (cartaAleatoria != null)
            {
                BitmapImage cartaBitmap = new BitmapImage(new Uri(cartaAleatoria.DireccionImagen, UriKind.RelativeOrAbsolute));
                CartasJuego.Source = cartaBitmap;
                CartasJuego.Visibility = Visibility.Visible;

                CartasJuego.Tag = new Tuple<int, TipoDePalo>(cartaAleatoria.NumeroDeCarta, cartaAleatoria.TipoDePalo);
            }
        }

        private void RepartirCartasAScroll()
        {
            for (int i = 0; i < _NUMERO_CARTAS_2_JUGADORES; i++)
            {
                Carta cartaAleatoria = _baraja.SacarCartaAleatoria();
                if (cartaAleatoria != null)
                {
                    Image cartaImagen = new Image
                    {
                        Width = 75,
                        Height = 75
                    };

                    BitmapImage cartaBitmap = new BitmapImage(new Uri(cartaAleatoria.DireccionImagen, UriKind.RelativeOrAbsolute));
                    cartaImagen.Source = cartaBitmap;

                    cartaImagen.Tag = new Tuple<int, TipoDePalo>(cartaAleatoria.NumeroDeCarta, cartaAleatoria.TipoDePalo);
                    cartaImagen.MouseDown += DesplazarCartasTablero;

                    ContenedorDeCartas.Children.Add(cartaImagen);
                }
            }
        }

        private void DesplazarCartasTablero(object sender, MouseButtonEventArgs e) //Nota v1
        {
            if (sender is Image card)
            {
                DataObject data = new DataObject(typeof(Image), card);
                DragDrop.DoDragDrop(card, data, DragDropEffects.Move);
            }
        }

        private void ComerCarta(object sender, RoutedEventArgs e)
        {
            Carta cartaAleatoria =_baraja.SacarCartaAleatoria();
            if (cartaAleatoria != null)
            {
                Image cartaConsumida = new Image
                {
                    Width = 75,
                    Height = 75
                };

                BitmapImage cartaBitmap = new BitmapImage(new Uri(cartaAleatoria.DireccionImagen, UriKind.RelativeOrAbsolute));
                cartaConsumida.Source = cartaBitmap;

                cartaConsumida.Tag = new Tuple<int, TipoDePalo>(cartaAleatoria.NumeroDeCarta, cartaAleatoria.TipoDePalo);
                cartaConsumida.MouseDown += DesplazarCartasTablero;

                ContenedorDeCartas.Children.Add(cartaConsumida);
            }
            else
            {
                MessageBox.Show("Baraja vacía");
            }
        }

        private void CartaInicio_SoltarCarta(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Image))) //Nota
            {
                Image cartaArrastrada = e.Data.GetData(typeof(Image)) as Image;

                if (cartaArrastrada != null)
                {
                    var atributosCarta = (Tuple<int, TipoDePalo>)cartaArrastrada.Tag;
                    var cartaInicio = (Tuple<int, TipoDePalo>)CartasJuego.Tag;

                    if (_logicajuego.SePuedeColocarCarta(cartaInicio, atributosCarta.Item1, atributosCarta.Item2))
                    {
                        BitmapImage cartaBitmap = (BitmapImage)cartaArrastrada.Source;
                        CartasJuego.Source = cartaBitmap;
                        CartasJuego.Tag = cartaArrastrada.Tag;
                        ContenedorDeCartas.Children.Remove(cartaArrastrada);
                    }
                    else
                    {
                        MessageBox.Show("No puedes jugar esta carta");
                    }
                }
            }
        }
    }
}
