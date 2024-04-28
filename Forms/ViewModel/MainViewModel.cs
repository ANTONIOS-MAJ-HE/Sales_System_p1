using Business;
using Data.Repositories;
using FontAwesome.Sharp;
using Model;
using Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;

namespace Forms.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        // Campos privados para almacenar datos y estados
        private UserAccountModel _usuarioActual; // Información de la cuenta de usuario actual
        private Usuario _usuarioActual2;
        private ViewModelBase _vistaActual; // Vista secundaria actual
        private string _tituloVista; // Título de la vista actual
        private IconChar _icono; // Ícono asociado a la vista actual

        private IUserRepository _repositorioUsuario; // Repositorio de usuarios para cargar datos de usuario
        private IFacturaRepository _repositorioFactura;

        private bool _dashboardVisible;
        private UserService _userService;

        // Propiedades públicas para vincularse con la interfaz de usuario
        public UserAccountModel UsuarioActual
        {
            get { return _usuarioActual; }
            set
            {
                _usuarioActual = value;
                OnPropertyChanged(nameof(UsuarioActual)); // Notificar cambios a la interfaz de usuario
            }
        }

        public Usuario UsuarioActual2
        {
            get { return _usuarioActual2; }
            set
            {
                _usuarioActual2 = value;
                OnPropertyChanged(nameof(UsuarioActual2)); // Notificar cambios a la interfaz de usuario
            }
        }

        public ViewModelBase VistaActual
        {
            get { return _vistaActual; }
            set
            {
                _vistaActual = value;
                OnPropertyChanged(nameof(VistaActual)); // Notificar cambios a la interfaz de usuario
            }
        }

        public string TituloVista
        {
            get { return _tituloVista; }
            set
            {
                _tituloVista = value;
                OnPropertyChanged(nameof(TituloVista)); // Notificar cambios a la interfaz de usuario
            }
        }

        public IconChar Icono
        {
            get { return _icono; }
            set
            {
                _icono = value;
                OnPropertyChanged(nameof(Icono)); // Notificar cambios a la interfaz de usuario
            }
        }

        public bool DashboardVisible
        {
            get { return _dashboardVisible; }
            set
            {
                _dashboardVisible = value;
                OnPropertyChanged(nameof(DashboardVisible));
            }
        }

        // Comandos para manejar acciones del usuario en la interfaz
        public ICommand ShowHomeViewCommand { get; }
        public ICommand ShowCustomerViewCommand { get; }
        public ICommand ShowInicioViewCommand { get; }

        // Constructor para inicializar el ViewModel
        public MainViewModel(Usuario usuario = null)
        {
            // Asignar usuario actual
            if (usuario == null)
                UsuarioActual2 = new Usuario() { NombreCompleto = "ADMIN PREDEFINIDO", IdUsuario = 1 };
            else
                UsuarioActual2 = usuario;

            // Inicializar el repositorio de usuarios y la cuenta de usuario actual
            _repositorioUsuario = new UserRepository();
            _usuarioActual = new UserAccountModel();
            _repositorioFactura = new FacturaRepository();
            _userService = new UserService();

            // Inicializar los comandos
            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            ShowCustomerViewCommand = new ViewModelCommand(ExecuteShowCustomerViewCommand);
            ShowInicioViewCommand = new ViewModelCommand(ExecuteShowInicioViewCommand);

            // Mostrar la vista de inicio por defecto al inicio de la aplicación
            ExecuteShowHomeViewCommand(null);

            // Cargar los datos del usuario actual
            LoadCurrentUserData();
            LoadPermissions();
        }

        // Método para mostrar la vista de inicio
        private void ExecuteShowHomeViewCommand(object obj)
        {
            VistaActual = new HomeViewModel(); // Crear una nueva instancia de la vista de inicio
            TituloVista = "Dashboard"; // Establecer el título de la vista
            Icono = IconChar.Home; // Establecer el ícono asociado a la vista
        }

        // Método para mostrar la vista de clientes
        private void ExecuteShowCustomerViewCommand(object obj)
        {
            VistaActual = new CustomerViewModel(_repositorioFactura); // Crear una nueva instancia de la vista de clientes
            TituloVista = "Customers"; // Establecer el título de la vista
            Icono = IconChar.UserGroup; // Establecer el ícono asociado a la vista
        }

        // Método para mostrar la vista de inicio de la aplicación (Order)
        private void ExecuteShowInicioViewCommand(object obj)
        {
            VistaActual = new InicioViewModel(); // Crear una nueva instancia de la vista de inicio de la aplicación
            TituloVista = "Order"; // Establecer el título de la vista
            Icono = IconChar.Truck; // Establecer el ícono asociado a la vista
        }

        // Método para cargar los datos del usuario actual desde el repositorio
        public void LoadCurrentUserData()
        {
            UsuarioActual = _userService.LoadCurrentUserData();
        }

        public void LoadPermissions()
        {
            _userService.LoadPermissions(UsuarioActual2);
        }
    }
}
