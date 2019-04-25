using System;

namespace Jogo
{

    /*
     * 
     *   Jogo "Batalha Naval".
     *   Atividade prática em laboratório como complemento na aprendizagem sobre
     *   vetores e matrizes.
     *     
     *   Autor: Rodrigo Cezario da Silva
     *   Data: 25/04/2019 (original desenvolvido em Java em 19/10/2015)    
     *   
     *   ===== Descrição dos elementos visuais =====
     *     
     *   Elementos de metáfora (imagens) utilizados na matriz mapaNavios[,] 
     *   <--> Submarino       : Precisa de 4 posições do mapa
     *   <_t_> Destroyer      : Precisa de 5 posições do mapa
     *   <=##=> Cruzador      : Precisa de 6 posições do mapa
     *   <===##> porta-aviões : Precisa de 7 posições do mapa
     *     
     *   Demais metáforas (exibidas em 1 posição)
     *   ~  :  representa água (ondas do mar) 
     *   ö  :  representa tiro na água (errou o tiro) 
     * 
     *   ===================================
     * 
     *   Elementos utilizados na matriz mapa[,]
     *   ?  :  representa uma posição que foi jogada
     * 
     */


    public class BatalhaNaval
    {

        static int mapaQtLinha, mapaQtColuna;

        static char[,] mapa; //acumula as jogadas
        static char[,] mapaNavios; //apresenta os elementos do jogo


        public static void Main(string[] args)
        {

            Console.WriteLine("\t\t*** JOGO BATALHA NAVAL ***\n");
            Console.WriteLine("\t\t======= Regras do jogo ======\n");
            Console.WriteLine("- O tamanho mínimo para o mapa deve de ser 6 x 9");
            Console.WriteLine("- Você deve acertar todos os navios para finalizar o " +
            	"jogo.");
            Console.WriteLine("- O objetivo é acertar todos os navios com o mínimo " +
            	"de tiros possíveis.");
            Console.WriteLine("- Você tem apenas 5 chances de errar.");
            Console.Write("- Os seguintes navios deverão ser sorteados:\n"
                    + "\t 2 - Submarino \t\t <--> \n"
                    + "\t 2 - Destroyer \t\t <_t_> \n"
                    + "\t 1 - Cruzador \t\t <=##=> \n"
                    + "\t 1 - Porta-aviões \t <===##> \n\n");
            Console.Write("\t... Tecle ENTER para continuar ...\n");

            Console.ReadKey();

            do
            {
                Console.WriteLine("Informe o tamanho do mapa (mínimo 6 X 9):");
                Console.Write("Nº. de linha para o mapa: ");

                mapaQtLinha = Convert.ToInt32(Console.ReadLine());

                Console.Write("Nº. de colunas para o mapa: ");

                mapaQtColuna = Convert.ToInt32(Console.ReadLine());

            } while ((mapaQtLinha < 6) || (mapaQtColuna < 9));

            //Definindo o tamanho do mapa
            mapa = new char[mapaQtLinha, mapaQtColuna];
            mapaNavios = new char[mapaQtLinha, mapaQtColuna];

            Console.Write("\n\n");// só para ficar visualmente melhor

            //Inicializando as matrizes que contram o jogo com ondas ~ ~ ~
            for (int i = 0; i < mapaQtLinha; i++)
            {
                for (int j = 0; j < mapaQtColuna; j++)
                {
                    mapa[i, j] = '~'; // iniciando com ondas
                    mapaNavios[i, j] = '~';
                }
            }

            // Preenchimento da matriz com os navios
            criaNavios();

            /*
             * === Dicas para o desenvolvimento da atividade:
             *             
             * Você deverá implementar ainda as seguintes funcionalidades:
             * - Criar os navios: implemente o método criaNavios()
             * - Solicitar jogada;
             * - Verificar se a jogada já não foi realizada;
             * - Adicionar (marcar) a jogada (tiro dado) no mapa (matriz mapa[,]) 
             * para isso atribua a posição o símbolo de ? (interrogação)
             * - O jogador não pode errar mais que 5 tiros
             * 
             */


            imprimirMapa();

        }


        /// <summary>
        /// Criação dos navios.
        /// </summary>
        /// <remarks>
        /// Este método você deve-se implementar a criação dos navios. Utilize a
        /// classe Random para inicializar mapaNavios[,]. Este método deverá ser
        /// chamado uma única vez na inicialização do jogo.
        /// 
        /// Lembre-se que você deve sortiar aleatóriamente pelo menos 6 navios, 
        /// sendo:
        /// 
        ///      2 (dois) - Submarino         <-->
        ///      2 (dois) - Destroyer         <_t_>
        ///      1 (um) - Cruzador            <=##=>
        ///      1 (um) - porta-aviões        <===##>
        /// 
        /// Cabe lembrar que a representação gráfica do navio está ao lado do nome.
        /// </remarks>
        public static void criaNavios()
        {
            //implemente aqui a criação dos navios.
        }


        /// <summary>
        /// Exibi o mapa na tela.
        /// </summary>
        /// <remarks>
        /// Este método imprime Mapa do jogo. Este método deverá ser chamado
        /// toda vez que houver uma jogada. Não é necessário a modificação
        /// deste método, no entanto, você poderá modificar caso ache necessário
        /// </remarks>
        public static void imprimirMapa()
        {
            // Primeiro é exibido o número da coluna
            for (int i = 0; i < mapaQtColuna; i++)
            {
                if (i == 0)
                {
                    Console.Write("  ");
                }
                Console.Write(" " + (i + 1));
            }
            Console.Write("\n");

            //Exibi as letras correspondentes das linhas
            for (int i = 0; i < mapaQtLinha; i++)
            {
                /*
                 * 65 é valor decimal correspondente a letra A maiúscula da tabela
                 * ASCII. A codificação ASCII é usada para representar caracteres
                 * por meio de números, seja decimal, hexadecimal ou octal.
                 */
                Console.Write(((char)(65 + i)) + " ");

                //Exibi os elementos na tela (água, navios e erros)
                for (int j = 0; j < mapaQtColuna; j++)
                {
                    //verificado se a posição no mapa já foi jogada
                    if (mapa[i, j] == '?')
                    {
                        if (mapaNavios[i, j] != '~')
                        {
                            Console.Write(" " + mapaNavios[i, j]);
                        }
                        else
                        {
                            Console.Write(" ö");
                        }
                    }
                    else
                    {
                        Console.Write(" ~");
                    }
                }
                Console.Write("\n");
            }
        }



    }
}
