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

namespace TaskManagerApp.View
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        private readonly ITarefaService _tarefaService;
        protected Guid IdUsuario { get; set; }

        public HomeWindow(Guid idUsuario, ITarefaService tarefaService)
        {
            InitializeComponent();
            IdUsuario = idUsuario;
            _tarefaService = tarefaService;
        }

        private async void CadastrarTarefa(object sender, RoutedEventArgs e)
        {
            var tarefa = new Tarefa
            {
                DataCriacao = DateTime.Now,
                Descricao = txtDescricaoTarefaCadastro.Text,
                IdUsuario = this.IdUsuario
            };

            await _tarefaService.CadastarTarefaAsync(tarefa);
            txtDescricaoTarefaCadastro.Text = string.Empty;
        }
    }
}
