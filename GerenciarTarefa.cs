using System.Diagnostics.Contracts;
using Tarefas;
namespace GerenciadorTarefa
{
    public class Gerenciar
    {
        public List<Tarefa> tarefas = new List<Tarefa>();
        public void Adicionar_Tarefa(string descricao)
        {
            tarefas.Add(new Tarefa { ID = ++Tarefa.Contador, Concluido = false, Descricao = descricao });
        }
        public void ConcluirTarefa(int id)
        {
            Tarefa? tarefa = tarefas.Find(tarefa => tarefa.ID == id);
            tarefa.Concluido = true;
        }
        public void ListarTarefa()
        {
            foreach (var texto in tarefas)
            {
                Tarefa.ExibirTarefa(texto.ID, texto.Concluido, texto.Descricao);
            }
        }
        public void Remover_Tarefa(int id)
        {
            Tarefa? tarefa = tarefas.Find(tarefa => tarefa.ID == id);
            tarefas.Remove(tarefa);
        }
    }
}