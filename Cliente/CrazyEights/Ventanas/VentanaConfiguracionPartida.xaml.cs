﻿using System;
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
    /// Interaction logic for VentanaConfiguracionPartida.xaml
    /// </summary>
    public partial class VentanaConfiguracionPartida : Window
    {
        public VentanaConfiguracionPartida()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.ResizeMode = ResizeMode.NoResize;
        }

        private void CrearSala(object sender, RoutedEventArgs e)
        {

        }

        private void CerrarVentana(object sender, MouseButtonEventArgs e)
        {

        }

        private void NavegarASala(object sender, RoutedEventArgs e)
        {
            VentanaSala ventanaSala = new VentanaSala();
            this.Close();
            ventanaSala.ShowDialog();
        }
    }
}
