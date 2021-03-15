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

namespace TaskManagerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ILoginService _loginService;
        public string Login { get; set; }

        public MainWindow(IUsuarioService usuarioService, ILoginService loginService)
        {
            InitializeComponent();
            _usuarioService = usuarioService;
            _loginService = loginService;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private async void CadastrarUsuario(object sender, RoutedEventArgs e)
        {
            var usuario = new Usuario
            {
                Login = txtLogin.Text,
                Password = txtPassword.Text
            };

            try
            {
                await _usuarioService.CadastrarNovoUsuarioAsync(usuario);
            }
            catch(RequiredFieldException ex)
            {
                txtErroCadastro.Content = ex.Message;
            }
        }
    }
}
