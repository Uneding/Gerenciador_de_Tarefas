using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
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
    public class Corpo
    {
        public int Posicao_Coluna { get; set; }
        public int Posicao_Linha_inicio { get; set; }
        public List<String> Linhas = new List<string>();
        public void Adicionar_Linha(string Linha)
        {
            Linhas.Add(Linha);
        }
        public void Adcionar_Posicao(int x, int y)
        {
            Posicao_Coluna = x;
            Posicao_Linha_inicio = y;
        }
    }
    public class Cabecalho
    {
        string Titulo { get; set; }
        int Largura_Bloco { get; set; }
        public int contador = 0;
        int Altura_Bloco { get; set; }
        public int Referecia_Tamanho_Titulo()
        {
            return Titulo.Length / 2 + 2;
        }
        public void Adicionar_Referencia_Bloco(int lar_Bloco, int Alt_Bloco)
        {
            Largura_Bloco = lar_Bloco;
            Altura_Bloco = Alt_Bloco;
        }
        public void Caixa()
        {
            int Centro_X = Largura_Bloco / 2;
            Console.SetCursorPosition(Centro_X - ((Titulo.Length / 2) + 2), Altura_Bloco / 2 - 1);
            switch (contador)
            {
                case 0:
                    Console.Write("╔");
                    for (int i = 0; i <= (Titulo.Length + 1); i++)
                    {
                        Console.Write("═");
                    }
                    break;
                case 1:
                    Console.Write("╗");
                    Console.SetCursorPosition(Centro_X - ((Titulo.Length / 2) + 2), Altura_Bloco / 2);
                    Console.Write($"║ {Titulo} ║");
                    Console.SetCursorPosition(Centro_X - ((Titulo.Length / 2) + 2), Altura_Bloco / 2 + 1);
                    Console.Write("╚");
                    break;
                case 2:
                    for (int i = 0; i <= (Titulo.Length + 1); i++)
                    {
                        Console.Write("═");
                    }
                    Console.Write("╝");
                    break;
                default:
                    contador = 0;
                    break;

            }
        }
        public void Adicionar_Titulo(string titulo)
        {
            Titulo = titulo;
        }
    }
}