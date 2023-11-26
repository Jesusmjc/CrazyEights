using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace CrazyEights.Ventanas
{
    /// <summary>
    /// Interaction logic for VentanaPersonalizacionDePerfil.xaml
    /// </summary>
    public partial class VentanaPersonalizacionDePerfil : Window
    {
        private String _recursoDeImagen = "";

        public VentanaPersonalizacionDePerfil()
        {
            InitializeComponent();
            CargarInformacion();
            CargarRecursos();
            CargarImagenDePerfil();
        }

        private void CargarRecursos()
        {
            lstbSeleccionarImagen.Items.Add("amogus");
            lstbSeleccionarImagen.Items.Add("gatoEnojado");
            lstbSeleccionarImagen.Items.Add("godzilla");
            lstbSeleccionarImagen.Items.Add("jacket");
            lstbSeleccionarImagen.Items.Add("perry");
        }

        private void CargarInformacion()
        {
            lbNombreDeJugador.Content = JugadorCliente.JugadorDeCliente.NombreUsuario;
        }
        private void CargarImagenDePerfil()
        {
            Bitmap imagenPerfil = (Bitmap)Properties.ResourcesDePerfil.ResourceManager.GetObject(JugadorCliente.JugadorDeCliente.FotoPerfil);

            BitmapSource imagenPerfilBitmap = Imaging.CreateBitmapSourceFromHBitmap(
                imagenPerfil.GetHbitmap(),
                IntPtr.Zero,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions()
                );

            imgFotoPerfil.Source = imagenPerfilBitmap;
        }

        private void SeleccionarImagen(object sender, SelectionChangedEventArgs e) //ToDo
        {
            if (lstbSeleccionarImagen.SelectedItem != null)
            {

                Bitmap imagenPerfil = (Bitmap)Properties.ResourcesDePerfil.ResourceManager.GetObject(lstbSeleccionarImagen.SelectedItem.ToString());

                BitmapSource imagenPerfilBitmap = Imaging.CreateBitmapSourceFromHBitmap(imagenPerfil.GetHbitmap(),
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions()
                    );   

                imgFotoPerfil.Source = imagenPerfilBitmap;
                _recursoDeImagen = lstbSeleccionarImagen.SelectedItem.ToString();
            }
        }

        private void CerrarVentana(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void GuardarCambiosDePerfil(object sender, RoutedEventArgs e)
        {
        }
    }
}
