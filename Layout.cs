using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using GerenciadorTarefa;
using Tarefas;


namespace Layout
{
    public class Formatacao
    {

        public void Aplicar_Cor_Fundo(string Cor_Fundo)
        {
            if (Enum.TryParse(Cor_Fundo, true, out ConsoleColor corTexto))
            {
                Console.ForegroundColor = corTexto;
            }
            else
            {
                Console.WriteLine("Uma das cores não é válida. Tente novamente.");
            }
        }
        public void Aplicar_Cor_Text(string Cor_text)
        {
            if (Enum.TryParse(Cor_text, true, out ConsoleColor corTexto))
            {
                Console.BackgroundColor = corTexto;
            }
            else
            {
                Console.WriteLine("Uma das cores não é válida. Tente novamente.");
            }

        }
        public static void ImprimirCabecalho()
        {
            Console.Clear();
            Cabecalho("Gerenciador de Tarefas");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("         Escolha as opções: \n           1 - Adicionar Tarefa\n           2 - Listar Tarefas \n           3 - Concluir Tarefa\n           4 - Remover Tarefa\n           0 - Sair\n");
        }
        public static void Cabecalho(string text)
        {
            int Centro_X = Console.WindowWidth / 2;
            Console.SetCursorPosition(Centro_X - ((text.Length / 2) + 2), 10);
            Console.Write("╔");
            for (int i = 0; i <= (text.Length + 1); i++)
            {
                Console.Write("═");
            }
            Console.Write("╗");
            Console.SetCursorPosition(Centro_X - ((text.Length / 2) + 2), 11);
            Console.Write($"║ {text} ║");
            Console.SetCursorPosition(Centro_X - ((text.Length / 2) + 2), 12);
            Console.Write("╚");
            for (int i = 0; i <= (text.Length + 1); i++)
            {
                Console.Write("═");
            }
            Console.Write("╝");
            Console.WriteLine();
        }
        public void Tamanho(int x, int y)
        {
            Console.WindowHeight = x;
            Console.WindowWidth = y;
        }
        public static int? DecisaoMenu(string y)
        {
            if (!int.TryParse(y, out int x) || x <= -1 || x >= 5)
            {
                return null;
            }
            return x;
        }
        public static void menu(int? x)
        {
            switch (x)
            {
                case 1:
                    Console.WriteLine("Entre com a Tarefa");
                    string? descricao = Console.ReadLine();
                    while (true)
                    {
                        if (!string.IsNullOrEmpty(descricao))
                        {
                            Gerenciar.Adicionar_Tarefa(descricao);
                            break;
                        }
                        Console.WriteLine("Descrição vazia");
                    }

                    break;
                case 2:
                    Gerenciar.ListarTarefa();
                    break;
                case 3:
                    Console.WriteLine("Entre com o ID da Tarefa");
                    while (true)
                    {
                        if (int.TryParse(Console.ReadLine(), out int fica))
                        {
                            if (Gerenciar.ConcluirTarefa(fica))
                            {
                                Console.WriteLine("Tarefa Concluida");
                                break;
                            }
                            Console.WriteLine("Tarefa não Existe");
                            continue;
                        }
                        Console.WriteLine("Descrição vazia");
                    }
                    break;
                case 4:
                    Console.WriteLine("Entre com o ID da Tarefa");
                    while (true)
                    {
                        if (int.TryParse(Console.ReadLine(), out int fica))
                        {
                            if (Gerenciar.Remover_Tarefa(fica))
                            {
                                Console.WriteLine("Tarefa Removida");
                                break;
                            }
                            Console.WriteLine("Tarefa não Existe");
                            continue;
                        }
                        Console.WriteLine("Descrição vazia");
                    }
                    break;
                case 0:

                    break;
            }
        }
    }
}

