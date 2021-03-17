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
            ObterTarefasCadastradas();
            ObterTarefasCadastradasConcluidas();
            txtEdicaoTarefa.Visibility = Visibility.Hidden;
            btnConcluirEdicao.Visibility = Visibility.Hidden;
        }

        private async void CadastrarTarefa(object sender, RoutedEventArgs e)
        {
            var tarefa = new Tarefa
            {
                DataCriacao = DateTime.Now,
                Descricao = txtDescricaoTarefaCadastro.Text,
                IdUsuario = this.IdUsuario,
                TarefaConcluida = false
            };

            await _tarefaService.CadastarTarefaAsync(tarefa);
            txtDescricaoTarefaCadastro.Text = string.Empty;
            ObterTarefasCadastradas();
        }

        private async void ObterTarefasCadastradas()
        {
            listTarefas.ItemsSource = await _tarefaService.ObterTarefasCadastradasPorUsuario(IdUsuario);
        }

        private async void ObterTarefasCadastradasConcluidas()
        {
            listTarefasConcluidas.ItemsSource = await _tarefaService.ObterTarefasCadastradasPorUsuario(IdUsuario, true);
        }

        private void TarefaSelecionada(object sender, SelectionChangedEventArgs e)
        {
            Tarefa tarefa = (Tarefa)listTarefas.SelectedItem;
        }

        private async void RemoverTarefa(object sender, RoutedEventArgs e)
        {
            Tarefa tarefa = ConvertObject(listTarefas);
            if(tarefa != null)
            {
                await _tarefaService.RemoverTarefaAsync(tarefa.Id, tarefa.IdUsuario);
                ObterTarefasCadastradas();
            }
        }

        private async void ConcluirTarefa(object sender, RoutedEventArgs e)
        {
            Tarefa tarefa = ConvertObject(listTarefas);
            if(tarefa != null)
            {
                tarefa.TarefaConcluida = true;
                await _tarefaService.AtualizarTarefaAsync(tarefa);
                ObterTarefasCadastradas();
                ObterTarefasCadastradasConcluidas();
            }
            
        }

        private Tarefa ConvertObject(ListView list)
        {
            return (Tarefa)list.SelectedItem;
        }

        private async void RemoverTarefaConcluida(object sender, RoutedEventArgs e)
        {
            Tarefa tarefa = ConvertObject(listTarefasConcluidas);
            if(tarefa != null)
            {
                await _tarefaService.RemoverTarefaAsync(tarefa.Id, tarefa.IdUsuario);
                ObterTarefasCadastradasConcluidas();
            }
        }

        private void EditarTarefa(object sender, RoutedEventArgs e)
        {
            Tarefa tarefa = ConvertObject(listTarefas);
            if(tarefa != null)
            {
                AjustarExibicaoFormTarefasAhFazer(Visibility.Hidden);
                AjustarExibicaoFormEdicaoTarefa(Visibility.Visible);
                txtEdicaoTarefa.Text = tarefa.Descricao;
            }
        }

        private async void ConcluirEdicao(object sender, RoutedEventArgs e)
        {
            Tarefa tarefa = ConvertObject(listTarefas);
            if(tarefa != null)
            {
                AjustarExibicaoFormTarefasAhFazer(Visibility.Visible);
                AjustarExibicaoFormEdicaoTarefa(Visibility.Hidden);
                tarefa.Descricao = txtEdicaoTarefa.Text;
                tarefa.TarefaConcluida = true;
                await _tarefaService.AtualizarTarefaAsync(tarefa);
                ObterTarefasCadastradas();
                ObterTarefasCadastradasConcluidas();
            }
        }

        private void AjustarExibicaoFormTarefasAhFazer(Visibility visibility)
        {
            listTarefas.Visibility = visibility;
            btnEditar.Visibility = visibility;
            btnRemover.Visibility = visibility;
            btnConcluir.Visibility = visibility;
        }

        private void AjustarExibicaoFormEdicaoTarefa(Visibility visibility)
        {
            btnConcluirEdicao.Visibility = visibility;
            txtEdicaoTarefa.Visibility = visibility;
        }
    }
}
