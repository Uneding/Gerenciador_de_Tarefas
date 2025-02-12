using System.Data.Common;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
namespace Tarefas
{
    public class Tarefa
    {
        public static int Contador = 0;
        public  int ID {get;set;}
        public  bool Concluido {get;set;}
        public  string Descricao {get;set;}
        public static void ExibirTarefa(int id, bool concluid, string descricao)
        {
            if (concluid == false)
            {
                Console.WriteLine($"ID{id}-[ ] {descricao}");
            }else
            {
                Console.WriteLine($"ID{id}-[x] {descricao}");
            }
            
        }
    }
}