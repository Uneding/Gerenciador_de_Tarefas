using System.Diagnostics.Contracts;
using Tarefas;
namespace GerenciadorTarefa
{
    public class Gerenciar
    {
        public static List<Tarefa> tarefas = new List<Tarefa>();
        public static void Adicionar_Tarefa(string descricao)
        {            
            tarefas.Add(new Tarefa { ID = ++Tarefa.Contador, Concluido = false, Descricao = descricao });
        }
        public static bool ConcluirTarefa(int id)
        {
            Tarefa? tarefa = tarefas.Find(tarefa => tarefa.ID == id);
            if(tarefa == null)
            {
                return false;
            }else
            tarefa.Concluido = true;
                return true;
        }
        public static  void ListarTarefa()
        {
            foreach (var texto in tarefas)
            {
                Tarefa.ExibirTarefa(texto.ID, texto.Concluido, texto.Descricao);
            }
            Thread.Sleep(1000);
        }
        public static bool Remover_Tarefa(int id)
        {
            Tarefa? tarefa = tarefas.Find(tarefa => tarefa.ID == id);
            if(tarefa == null)
            {
                return false;
            }else
            tarefas.Remove(tarefa);
            return true;
        }
    }
}