using System.Diagnostics.Contracts;
using System.Net.Http.Headers;
using Layout;
namespace Paginas_layout
{
    public class Teclas
    {
        public static string CapsLock(string texto)
        {
            if (Console.CapsLock)
            {
                return texto;
            }
            else
            {
                return null;
            }
        }

    }
    public class Pagina
    {
        public string Nome { get; set; }
        public List<Bloco> Blocos { get; set; } = new List<Bloco>();

        public Pagina(string nome)
        {
            Nome = nome;
            DefinirTelaCheia();
        }
        private void DefinirTelaCheia()
        {
            var larguraMax = Console.LargestWindowWidth;
            var alturaMax = Console.LargestWindowHeight;

            Console.SetWindowSize(larguraMax, alturaMax);
            Console.SetBufferSize(larguraMax, alturaMax);
            Console.Clear();
        }
        public void AdicionarBloco(Bloco bloco)
        {
            Blocos.Add(bloco);
        }
        public void ExibirPagina()
        {
            foreach (var bloco in Blocos)
            {
                bloco.ExibirBloco();
            }
        }
    }
    public class Bloco
    {
        Corpo corpo = new Corpo();
        public float PercentualX { get; set; }
        public float PercentualY { get; set; }
        public float PercentualLargura { get; set; }
        public float PercentualAltura { get; set; }
        public string Cor { get; set; }
        public Bloco(float percentualX, float percentualY, float percentualLargura, float percentualAltura, string cor, Corpo corpo)
        {
            PercentualX = percentualX;
            PercentualY = percentualY;
            PercentualLargura = percentualLargura;
            PercentualAltura = percentualAltura;
            Cor = cor;
        }
        public void ExibirBloco()
        {
            int posX = (int)(Console.WindowWidth * PercentualX);
            int posY = (int)(Console.WindowHeight * PercentualY);
            int largura = (int)(Console.WindowWidth * PercentualLargura);
            int altura = (int)(Console.WindowHeight * PercentualAltura);
            Console.SetCursorPosition(posX, posY);
            Console.BackgroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), Cor, true);
            for (int i = 0; i < altura; i++)
            {
                Console.SetCursorPosition(posX, posY + i);
                Console.Write(new string(' ', largura));
            }
            Console.SetCursorPosition(posX + 1, posY + 1);
            Console.ResetColor();
        }
    }
}

