﻿using Forms.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Forms
{
    /// <summary>
    /// Lógica de interacción para FacturaView.xaml
    /// </summary>
    public partial class FacturaView : UserControl
    {
        private readonly FacturaViewModel viewModel;
        public FacturaView()
        {
            InitializeComponent();
            this.viewModel = viewModel;
        }

        private void FacturasView_Load(object sender, EventArgs e)
        {
            viewModel.CargarFacturas(); // Cargar las facturas al abrir la vista
        }
    }
}
