using Layout;
using Paginas_layout;
Pagina pagina1 = new Pagina("Menu Principal");
var bloco1 = new Bloco(0f, 0f, 1f, 0.2f, "Black");
pagina1.AdicionarBloco(bloco1);
var bloco2 = new Bloco(0f, 0.2f, 1f, 0.8f, "Blue");
pagina1.AdicionarBloco(bloco2);
pagina1.ExibirPagina();
int? x;
while (true)
{
    
    x = Formatacao.DecisaoMenu(Console.ReadLine());
    if (x == null)
    {
        Console.WriteLine("Valor nulo");
        Thread.Sleep(1000);
        Console.Clear();
        continue;
    }
    else if (x == 0)
    {
        break;
    }
    Formatacao.menu(x);
}

