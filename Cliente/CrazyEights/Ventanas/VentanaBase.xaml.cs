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
    /// Interaction logic for VentanaBase.xaml
    /// </summary>
    public partial class VentanaBase : Window
    {
        public VentanaBase()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.ResizeMode = ResizeMode.NoResize;
            this.Closing += VentanaBase_Closing;
        }
    }
}
