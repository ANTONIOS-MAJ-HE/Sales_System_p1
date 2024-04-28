using Data.Repositories;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class B_Factura 
    {
        private readonly IFacturaRepository FacturaRepository;

        public B_Factura(IFacturaRepository facturaRepository)
        {
            this.FacturaRepository = facturaRepository;
        }

        public List<Factura> listar()
        {
            return FacturaRepository.GetByAll().ToList();
        }
    }
}
