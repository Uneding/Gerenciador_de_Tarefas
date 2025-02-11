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
            if (Enum.TryParse(Cor_text, true, out ConsoleColor corTexto) )
        {
            Console.BackgroundColor = corTexto;
        }
        else
        {
            Console.WriteLine("Uma das cores não é válida. Tente novamente.");
        }
        }
        public static void ImprimirCabecalho(string text)
        {
            Console.Clear();
            int Centro_X = Console.WindowWidth / 2;
            Console.SetCursorPosition(Centro_X-((text.Length/2)+2), 10);
            Console.Write("╔");
            for (int i = 0; i <= (text.Length+1); i++)
            {
                Console.Write("═");
            }
            Console.Write("╗");
            Console.SetCursorPosition(Centro_X-((text.Length/2)+2), 11);
            Console.Write($"║ {text} ║");
            Console.SetCursorPosition(Centro_X-((text.Length/2)+2), 12);
            Console.Write("╚");
            for (int i = 0; i <= (text.Length+1); i++)
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
    }
}

