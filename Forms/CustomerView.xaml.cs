using Business;
using Data.Repositories;
using Forms.ViewModel;
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
    /// Lógica de interacción para CustomerView.xaml
    /// </summary>
    public partial class CustomerView : UserControl
    {
        private readonly CustomerViewModel viewModel;
        public CustomerView()
        {
            InitializeComponent();
            viewModel = new CustomerViewModel(new B_Factura(new FacturaRepository()));
            DataContext = viewModel;
            viewModel.CargarFacturas();
        }
    }
}
