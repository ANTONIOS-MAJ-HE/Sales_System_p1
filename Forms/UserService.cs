using Data.Repositories;
using Model;
using Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Forms
{
    public class UserService
    {
        private IUserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public UserAccountModel LoadCurrentUserData()
        {
            var user = _userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                return new UserAccountModel
                {
                    Username = user.NombreCompleto,
                    DisplayName = $"Welcome {user.NombreCompleto}",
                    ProfilePicture = null
                };
            }
            else
            {
                return new UserAccountModel
                {
                    DisplayName = "Invalid user, not logged in"
                };
            }
        }

        public void LoadPermissions(Usuario userAccount)
        {
            var permisoService = new CN_Permiso();
            var listaPermisos = permisoService.Listar(userAccount.IdUsuario);

            // Actualizar la visibilidad de cada botón del menú según los permisos del usuario
            userAccount.DashboardVisible = listaPermisos.Any(p => p.NombreMenu == "Dashboard");
            // Repite el mismo patrón para cada botón del menú...
        }
    }
}
