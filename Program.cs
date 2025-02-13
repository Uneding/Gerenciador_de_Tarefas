using Layout;
int ? x;
while(true)
{
    Formatacao.ImprimirCabecalho();
    x = Formatacao.DecisaoMenu(Console.ReadLine());
    if(x == null)
    {
        Console.WriteLine("Valor nulo");
        Thread.Sleep(1000);
        Console.Clear();
        continue;
    }else if(x==0)
    {
        break;
    }
    Formatacao.menu(x);
}
   
