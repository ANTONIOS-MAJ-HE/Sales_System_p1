using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IUserRepository
    {
        bool AuthenticateUser(NetworkCredential credential);
        void Add(Usuario userModel);
        void Edit(Usuario userModel);
        void Remove(int id);
        Usuario GetById(int id);
        Usuario GetByUsername(string username);
        IEnumerable<Usuario> GetByAll();
        //...
    }

    public interface IFacturaRepository
    {
        Factura GetById(int id);

        // Obtener todas las órdenes
        IEnumerable<Factura> GetByAll();

        // Agregar una nueva orden
        void Add(Factura order);

        // Editar una orden existente
        void Edit(Factura order);

        // Eliminar una orden por su ID
        void Remove(int id);

        Factura GetByFactura();
    }
}
