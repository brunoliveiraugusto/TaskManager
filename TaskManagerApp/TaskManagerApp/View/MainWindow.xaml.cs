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
using TaskManagerApp.Domain;
using TaskManagerApp.Service;
using TaskManagerApp.Service.Interfaces;
using TaskManagerApp.Utils.Exceptions;
using TaskManagerApp.View;

namespace TaskManagerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ILoginService _loginService;
        protected Guid IdUsuario { get; set; }

        public MainWindow(IUsuarioService usuarioService, ILoginService loginService)
        {
            InitializeComponent();
            _usuarioService = usuarioService;
            _loginService = loginService;
        }

        private async void CadastrarUsuario(object sender, RoutedEventArgs e)
        {
            var usuario = new Usuario
            {
                Login = txtLogin.Text,
                Password = txtPassword.Password
            };

            try
            {
                IdUsuario = await _usuarioService.CadastrarNovoUsuarioAsync(usuario);
                OpenFormHome(sender, e);
            }
            catch(UserExistsException ex)
            {
                txtErroCadastro.Content = ex.Message;
            }
        }

        private void OpenFormLogin(object sender, RoutedEventArgs e)
        {
            this.Hide();
            LoginWindow loginWindow = new LoginWindow(_loginService, _usuarioService);
            loginWindow.Show();
        }

        private void OpenFormHome(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var homeWindow = new HomeWindow(IdUsuario);
            homeWindow.Show();
        }
    }
}
