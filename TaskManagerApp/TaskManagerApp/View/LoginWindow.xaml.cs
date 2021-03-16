using System;
using System.Collections.Generic;
using System.Text;
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
using TaskManagerApp.Service.Interfaces;

namespace TaskManagerApp
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private ILoginService _loginService;
        private IUsuarioService _usuarioService;

        public LoginWindow(ILoginService loginService, IUsuarioService usuarioService)
        {
            InitializeComponent();
            _loginService = loginService;
            _usuarioService = usuarioService;
        }

        private async void Login(object sender, RoutedEventArgs e)
        {
            try
            {
                var usuario = new Usuario
                {
                    Login = txtLogin.Text,
                    Password = txtPassword.Password
                };

                await _loginService.LoginAsync(usuario);
            }
            catch(Exception ex)
            {
                txtErroLogin.Content = ex.Message;
            }
        }

        private void OpenFormCadastro(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var mainWindow = new MainWindow(_usuarioService, _loginService);
            mainWindow.Show();
        }
    }
}
