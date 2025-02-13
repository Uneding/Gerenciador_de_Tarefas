using Layout;
using Paginas_layout;
Pagina pagina1 = new Pagina("Menu Principal");
Corpo menu = new Corpo();
menu.Adcionar_Posicao(10, 40);
menu.Adicionar_Linha("1 - Adicionar Tarefa.");
menu.Adicionar_Linha("2 - Listar Tarefas.");
menu.Adicionar_Linha("3 - Concluir Tarefa.");
menu.Adicionar_Linha("4 - Remover Tarefa.");
menu.Adicionar_Linha("0 - Sair.");
var bloco1 = new Bloco(0f, 0f, 1f, 0.2f, "Black", null);
pagina1.AdicionarBloco(bloco1);
var bloco2 = new Bloco(0f, 0.2f, 1f, 0.8f, "Blue", menu);
pagina1.AdicionarBloco(bloco2);
pagina1.ExibirPagina();
Console.ReadLine();
// int? x;
// while (true)
// {
    
//     x = Formatacao.DecisaoMenu(Console.ReadLine());
//     if (x == null)
//     {
//         Console.WriteLine("Valor nulo");
//         Thread.Sleep(1000);
//         Console.Clear();
//         continue;
//     }
//     else if (x == 0)
//     {
//         break;
//     }
//     Formatacao.menu(x);
// }

