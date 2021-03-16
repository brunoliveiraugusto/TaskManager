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
using TaskManagerApp.View;

namespace TaskManagerApp
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private ILoginService _loginService;
        private IUsuarioService _usuarioService;
        private ITarefaService _tarefaService;

        protected Guid IdUsuario { get; set; }

        public LoginWindow(ILoginService loginService, IUsuarioService usuarioService, ITarefaService tarefaService)
        {
            InitializeComponent();
            _loginService = loginService;
            _usuarioService = usuarioService;
            _tarefaService = tarefaService;
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

                IdUsuario = await _loginService.LoginAsync(usuario);
                OpenFormHome(sender, e);
            }
            catch(Exception ex)
            {
                txtErroLogin.Content = ex.Message;
            }
        }

        private void OpenFormHome(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var homeWindow = new HomeWindow(IdUsuario, _tarefaService);
            homeWindow.Show();
        }

        private void OpenFormCadastro(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var mainWindow = new MainWindow(_usuarioService, _loginService, _tarefaService);
            mainWindow.Show();
        }
    }
}
