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

namespace CrazyEights
{
    /// <summary>
    /// Interaction logic for VentanaConfirmación.xaml
    /// </summary>
    public partial class VentanaConfirmación : Window
    {
        public VentanaConfirmación()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        public VentanaConfirmación(string nombreOperacionExitosa, string detallesOperacionExitosa)
        {
            InitializeComponent();
            lbNombreOperacionExitosa.Content = nombreOperacionExitosa;
            tbDetallesOperacionExitosa.Text = detallesOperacionExitosa;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void CerrarVentana(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            this.Close();
        }
    }
}
