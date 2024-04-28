using Business;
using Data.Repositories;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Forms.ViewModel
{
    public class CustomerViewModel : ViewModelBase
    {

        //Fields
        private readonly B_Factura _facturaBusiness;
        private List<Factura> _facturas;
        private Double _numero_orden;
        private string _ruc_proveedor;

        //Properties
        public List<Factura> Facturas
        {
            get
            {
                return _facturas;
            }

            set
            {
                _facturas = value;
                OnPropertyChanged(nameof(Facturas));
            }
        }

        public Double Numero_Orden
        {
            get
            {
                return _numero_orden;
            }

            set
            {
                _numero_orden = value;
                OnPropertyChanged(nameof(Numero_Orden));
            }
        }

        public string Ruc_Proveedor
        {
            get
            {
                return _ruc_proveedor;
            }

            set
            {
                _ruc_proveedor = value;
                OnPropertyChanged(nameof(Ruc_Proveedor));
            }
        }

        public IFacturaRepository FacturaRepository { get; }

        public CustomerViewModel(B_Factura facturaRepository)
        {
            this._facturaBusiness = facturaRepository;
        }

        public CustomerViewModel(IFacturaRepository facturaRepository)
        {
            FacturaRepository = facturaRepository;
        }

        public void CargarFacturas()
        {
            // Simulamos la carga de algunas facturas
            Facturas = _facturaBusiness.listar(); // Ajusta este método según tu lógica de negocio
        }
    }
}
