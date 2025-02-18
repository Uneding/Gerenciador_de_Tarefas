using System.Data.Common;
using System.Diagnostics.Contracts;
using System.Dynamic;
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
        Cabecalho? cabecalho{get;set;} = new Cabecalho();
        public float PercentualX { get; set; }
        public float PercentualY { get; set; }
        public float PercentualLargura { get; set; }
        public float PercentualAltura { get; set; }
        public string Cor { get; set; }
        public Bloco(float percentualX, float percentualY, float percentualLargura, float percentualAltura, string cor, Corpo? tes, Cabecalho? x)
        {
            PercentualX = percentualX;
            PercentualY = percentualY;
            PercentualLargura = percentualLargura;
            PercentualAltura = percentualAltura;
            Cor = cor;
            corpo = tes;
            cabecalho = x;
        }
        public void ExibirBloco()
        {
            int contadorLinha = 0;
            int posX = (int)(Console.WindowWidth * PercentualX);
            int posY = (int)(Console.WindowHeight * PercentualY);
            int largura = (int)(Console.WindowWidth * PercentualLargura);
            int altura = (int)(Console.WindowHeight * PercentualAltura);
            int referencia_Cabeca= ((altura-posX)/2)-2;
            bool Confirma = true;
            if(cabecalho != null)
            {
                cabecalho.Adicionar_Referencia_Bloco(largura-posX,altura-posY);
            }         
            Console.SetCursorPosition(posX, posY);
            Console.BackgroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), Cor, true);

            for (int i = 0; i < altura; i++)
            {
                int contadorCaractere = 0;
                string linhaAtual = (corpo != null && contadorLinha < corpo.Linhas.Count) ? corpo.Linhas[contadorLinha] : " ";
                for (int x = 0; x < largura; x++)
                {
                    Console.SetCursorPosition(posX + x, posY + i);
                    if (corpo != null && posX + x == corpo.Posicao_Coluna && posY + i == corpo.Posicao_Linha_inicio)
                    {
                        if (contadorLinha < corpo.Linhas.Count)
                        {
                            contadorLinha++;
                            while (contadorCaractere < linhaAtual.Length)
                            {
                                Console.Write(linhaAtual[contadorCaractere]);
                                contadorCaractere++;
                                x++;
                            }
                            Console.Write(" ");
                            corpo.Posicao_Linha_inicio++;
                        }else
                        {
                            Console.Write(" ");
                        }
                    }
                    else if (cabecalho != null && posX + x == largura/2-cabecalho.Referecia_Tamanho_Titulo && i == referencia_Cabeca && Confirma) 
                    {
                            cabecalho.Caixa();
                            ++cabecalho.contador;
                            referencia_Cabeca++;
                            if(cabecalho.contador > 2)
                            {
                                cabecalho.contador = 0;
                                Confirma = false;
                            }
                            x += cabecalho.Titulo.Length + 3;
                           
                    }else
                    {

                        Console.Write(" ");
                    }
                    
                }
            }
            Console.SetCursorPosition(posX + 1, posY + 1);
            Console.ResetColor();
        }
    }
}