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

        public LoginWindow(ILoginService loginService)
        {
            InitializeComponent();
            _loginService = loginService;
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
    }
}
