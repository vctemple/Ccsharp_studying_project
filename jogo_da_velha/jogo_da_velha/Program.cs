using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

namespace jogo_da_velha
{
    internal class Program
    {
        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }; // Posições no jogo
        static int jogador; // Por padrão é começado sempre com o jogador 1
        static int escolha; // variável que armazena a escolha do usuário de posição
       
        // A variável flag avalia a situaçao do jogo
        // Caso seja 1, há um jogador, caso seja -1 deu empate, caso seja 0 o jogo ainda está acontecendo
        static int situacao = 0;

        static Jogador Cadastro() // Função de cadastro do jogador
        {
            Console.Write("Digite o nickname do Jogador: ");
            string nome = Console.ReadLine();
            Console.Write("Digite o CPF do paciente: ");
            string cpf = Console.ReadLine();
            string vitorias = "1";

            try
            {
                Jogador novo = new Jogador(nome, cpf, vitorias);
                return novo;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        // Função para criação do arquivo txt para armazenar dados
        static void EscritaArquivo(Jogador[] jog, int qtd)
        {
            string caminho = "BancoDeDados.txt";
            FileStream fs = null;
            fs = new FileStream(caminho, FileMode.Create);
            try
            {

                using (StreamWriter writer = new StreamWriter(fs))
                {
                    for (int i = 0; i < qtd; i++)
                    {

                        writer.WriteLine(jog[i].DadosParaArquivo());
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("FALHA AO SALVAR BANCO DE DADOS!");
            }
            finally
            {
                if (fs != null)
                    fs.Dispose();
            }
        }

        // Função de leitura do arquivo txt onde armazena os cadastros
        static void LeituraArquivo(Jogador[] jog, ref int qtd)
        {
            // Ler e mostrar cada linha do arquivo.
            string line, caminho = "BancoDeDados.txt";
            StreamReader sr = null;
            try
            {
                if (File.Exists(caminho))
                {
                    sr = new StreamReader(caminho);
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] dados = line.Split(';');
                        jog[qtd++] = new Jogador(dados[0], dados[1], dados[2]);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("FALHA AO LER OS DADOS NO BANCO!");
            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }
        }

        static int Menuvencedor()
        {
            int opcao = -1;

            do
            {
                Console.WriteLine("| NÃO PARTICIPAR.............: 0 |");
                Console.WriteLine("| CADASTRAR NOVO JOGADOR.....: 1 |");
                Console.WriteLine("| JOGADOR JÁ CADASTRADO......: 2 |");
                Console.WriteLine("|================================|" + "\n|");
                Console.Write("|............ Opção escolhida: ");

                try
                {
                    opcao = int.Parse(Console.ReadLine());
                    if (opcao < 0 || opcao > 3)
                        throw new Exception();

                }
                catch (Exception)
                {
                    Console.WriteLine("\nTexto digitado inválido!\nClique [ENTER] para continuar...\"");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (opcao < 0 || opcao > 2);

            return opcao;
        }

        static int Menu() // Função de MENU do sistema
        {
            int opcao = -1;
            do
            {

                Console.WriteLine("|============= MENU =============|");
                Console.WriteLine("| SAIR.......................: 0 |");
                Console.WriteLine("| JOGAR SOLO.................: 1 |");
                Console.WriteLine("| PLAYER VS .................: 2 |");
                Console.WriteLine("| MOSTRAR RANKING............. 3 |");
                Console.WriteLine("|================================|" + "\n|");
                Console.Write("|............ Opção escolhida: ");
                try
                {
                    opcao = int.Parse(Console.ReadLine());
                    if (opcao < 0 || opcao > 3)
                        throw new Exception();

                }
                catch (Exception)
                {
                    Console.WriteLine("\nTexto digitado inválido!\nClique [ENTER] para continuar...\"");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            while (opcao < 0 || opcao > 5);

            return opcao;
        }
      
        static void Resettabuleiro()
        {
            for (int i = 0; i <= 9; i++)
            {
                arr[i] = Convert.ToChar(Convert.ToString(i));
            }
        }
        
        static void Hanking(params Jogador[] jog)
        {
            Jogador aux;
            for (int i = 0; i <= jog.Length - 1; i++)
            {
                int maximo = i;
                for (int j = i + 1; j <= jog.Length - 1; j++)
                {
                    if (jog[j] != null && int.Parse(jog[j].Vitorias) > int.Parse(jog[i].Vitorias))
                        maximo = j;
                }
                if(jog[i] != null && i <= maximo)
                {
                    aux = jog[i];
                    jog[i] = jog[maximo];
                    jog[maximo] = aux;
                }
            }
            Console.WriteLine("\n[TOP 10 JOGADORES]");
            for (int i = 0; i <= 9; i++)
            {
                if (jog[i] != null)
                    Console.WriteLine("\n" + jog[i]);
            }
            Console.WriteLine();
        }

        static void Tabuleiro()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[1], arr[2], arr[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[4], arr[5], arr[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[7], arr[8], arr[9]);
            Console.WriteLine("     |     |      ");
        }

        static int Checagem()
        {
            #region Vitoria horizontal
            // Primeira linha
            if (arr[1] == arr[2] && arr[2] == arr[3])
            {
                return 1;
            }
            // Segunda linha
            else if (arr[4] == arr[5] && arr[5] == arr[6])
            {
                return 1;
            }
            // Terceira linha
            else if (arr[6] == arr[7] && arr[7] == arr[8])
            {
                return 1;
            }
            #endregion
            
            #region Vitoria vertical
            // Primeira coluna
            else if (arr[1] == arr[4] && arr[4] == arr[7])
            {
                return 1;
            }
            // Segunda Coluna
            else if (arr[2] == arr[5] && arr[5] == arr[8])
            {
                return 1;
            }
            // Terceira Coluna
            else if (arr[3] == arr[6] && arr[6] == arr[9])
            {
                return 1;
            }
            #endregion
            
            #region Vitoria diagonal
            else if (arr[1] == arr[5] && arr[5] == arr[9])
            {
                return 1;
            }
            else if (arr[3] == arr[5] && arr[5] == arr[7])
            {
                return 1;
            }
            #endregion
            
            #region Empate
            // Caso tudo tenha sido preenchido e não tenha dado resultado
            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
            {
                return -1;
            }
            #endregion
            else // Jogo ainda acontecendo
            {
                return 0;
            }
        }
        
        static int jogosolo()
        {
            Random random = new Random(); // Para gerar as posições do computador
            escolha = 0;
            jogador = 1;
            do
            {
                Console.Clear();
                Console.WriteLine("[Jogador 1: X] VS [Computador: O]");
                Console.WriteLine("\n");
                Tabuleiro(); // Escreve o tabuleiro
                if (jogador % 2 != 0) // Verifica qual a vez do jogador
                {
                    Console.WriteLine("\nVez do jogador 1");
                    do
                    {
                        Console.Write("Digite a posição: ");
                        escolha = int.Parse(Console.ReadLine()); // Recebe a posição do jogador
                        try
                        {
                            if (escolha < 0 || escolha > 9)
                                throw new Exception();

                        }
                        catch (Exception)
                        {
                            Console.WriteLine("\nTexto digitado inválido!\n");
                        }
                    } while (escolha < 0 || escolha > 9);
                }
                else
                {
                    do
                    {
                        escolha = random.Next(1, 9);
                    } while (arr[escolha] == 'X' && arr[escolha] == 'O');
                    
                }
                Console.WriteLine("\n");

                // Verifica se a posição escolhida é válida ou já foi preenchida
                if (arr[escolha] != 'X' && arr[escolha] != 'O')
                {
                    if (jogador % 2 == 0) // A vez é preenchida com o símbolo referente a cada jogador
                    {
                        arr[escolha] = 'O';
                        jogador++;
                    }
                    else
                    {
                        arr[escolha] = 'X';
                        jogador++;
                    }
                }
                else // Caso a posição seja inválida
                {
                    Console.WriteLine("A posição {0} já está marcada com um {1}!!", escolha, arr[escolha]);
                    Console.WriteLine("\n");
                    Console.WriteLine("Aguarde 2 segundos para o tabuleiro regarregar.....");
                    Thread.Sleep(2000);
                }
                situacao = Checagem();// verifica a situação do jogo
            }
            while (situacao != 1 && situacao != -1);
            // Haverá looping enquanto houver posições vazias   

            Console.Clear();
            Tabuleiro();

            if (situacao == 1)
            {
                Console.WriteLine("\nVitória do jogador 1!!");
                return (jogador % 2) + 1; // Retorno o número do jogador caso vitória
            }
            else
            {
                Console.WriteLine("\nEmpate!!");
                return situacao; // Retorna -1 caso empate
            }
        }

        static int Jogovs()
        {
            jogador = 1;
            do
            {
                Console.Clear();
                Console.WriteLine("[Jogador 1: X] VS [Jogador 2: O]");
                Console.WriteLine("\n");
                Tabuleiro(); // Escreve o tabuleiro
                if (jogador % 2 == 0) // Verifica qual a vez do jogador
                {
                    Console.WriteLine("\nVez do jogador 2");
                }
                else
                {
                    Console.WriteLine("\nVez do jogador 1");
                }
                do
                {
                    Console.Write("Digite a posição: ");
                    escolha = int.Parse(Console.ReadLine()); // Recebe a posição do jogador
                    try
                    {
                        if (escolha < 0 || escolha > 9)
                            throw new Exception();

                    }
                    catch (Exception)
                    {
                        Console.WriteLine("\nTexto digitado inválido!\n");
                    }
                } while (escolha < 0 || escolha > 9);

                // Verifica se a posição escolhida é válida ou já foi preenchida
                if (arr[escolha] != 'X' && arr[escolha] != 'O')
                {
                    if (jogador % 2 == 0) // A vez é preenchida com o símbolo referente a cada jogador
                    {
                        arr[escolha] = 'O';
                        jogador++;
                    }
                    else
                    {
                        arr[escolha] = 'X';
                        jogador++;
                    }
                }
                else // Caso a posição seja inválida
                {
                    Console.WriteLine("A posição {0} já está marcada com um {1}!!", escolha, arr[escolha]);
                    Console.WriteLine("\n");
                    Console.WriteLine("Aguarde 2 segundos para o tabuleiro regarregar.....");
                    Thread.Sleep(2000);
                }
                situacao = Checagem();// verifica a situação do jogo
            }
            while (situacao != 1 && situacao != -1);
            // Haverá looping enquanto houver posições vazias   

            Console.Clear();
            Tabuleiro();

            if (situacao == 1)
            {
                Console.WriteLine("\nVitória do jogador {0}!!", (jogador % 2) + 1);
                return (jogador % 2) + 1; // Retorno o número do jogador caso vitória
            }
            else
            {
                Console.WriteLine("\nEmpate!!");
                return situacao; // Retorna -1 caso empate
            }
        }

        static void Main(string[] args)
        {
            int opcao, opven, i, vencedor, qtd = 0;
            string nomepesq;
            Jogador[] jog = new Jogador[100];
            LeituraArquivo(jog, ref qtd);

            do
            {
                opcao = Menu();

                switch (opcao)
                {
                    case 0:
                        Console.WriteLine("\nObrigado por usar o sistema!");
                        EscritaArquivo(jog, qtd);
                        break;
                    case 1:
                        vencedor = jogosolo();
                        if (vencedor == 1)
                        {
                            Console.WriteLine("\nParabéns você venceu!\nDeseja participar do ranking?\n");
                            opven = Menuvencedor();

                            switch (opven)
                            {
                                case 0:
                                    break;

                                case 1:
                                    Jogador novo = Cadastro();
                                    if (novo != null)
                                    {
                                        Console.WriteLine("CADASTRO REALIZADO COM SUCESSO!");
                                        jog[qtd] = novo;
                                        qtd++;
                                    }
                                    else
                                        Console.WriteLine("FALHA AO CADASTRAR!");
                                    break;

                                case 2:
                                    do
                                    {
                                        //nomepesq = "";
                                        Console.Write("Digite o nome do jogador: ");
                                        nomepesq = Console.ReadLine().ToLower();
                                        for (i = 0; i < qtd; i++)
                                        {
                                            if (jog[i].Nome.ToLower().Contains(nomepesq))
                                            {
                                                jog[i].venceu();
                                                break;
                                            }
                                        }
                                        if (i == qtd)
                                            Console.WriteLine("NENHUM JOGADOR COM O NOME \"{0}\" FOI ENCONTRADO!", nomepesq);
                                    } while (i == qtd);
                                    break;
                            }
                        }
                        Resettabuleiro();
                        Hanking(jog);                       
                        break;
                    case 2:
                        vencedor = Jogovs();
                        if (vencedor == 1)
                        {
                            Console.WriteLine("Parabéns você venceu!\nDeseja participar do ranking?\n");
                            opven = Menuvencedor();

                            switch (opven)
                            {
                                case 0:
                                    break;

                                case 1:
                                    Jogador novo = Cadastro();
                                    if (novo != null)
                                    {
                                        Console.WriteLine("CADASTRO REALIZADO COM SUCESSO!");
                                        jog[qtd] = novo;
                                        qtd++;
                                    }
                                    else
                                        Console.WriteLine("FALHA AO CADASTRAR!");
                                    break;

                                case 2:
                                    do
                                    {
                                        //nomepesq = "";
                                        Console.Write("Digite o nome do jogador: ");
                                        nomepesq = Console.ReadLine().ToLower();
                                        for (i = 0; i < qtd; i++)
                                        {
                                            if (jog[i].Nome.ToLower().Contains(nomepesq))
                                            {
                                                jog[i].venceu();
                                                Console.WriteLine("\n======== JOGADOR {0}========", i + 1);
                                                Console.WriteLine("NOME: " + jog[i].Nome + "\n" +
                                                                  "CPF: " + jog[i].CPF +
                                                                  "VITÓRIAS: " + jog[i].Vitorias);
                                                break;
                                            }
                                        }
                                        if (i == qtd)
                                            Console.WriteLine("NENHUM JOGADOR COM O NOME \"{0}\" FOI ENCONTRADO!", nomepesq);
                                    } while (i == qtd);
                                    break;
                            }
                        }
                        Resettabuleiro();
                        Hanking(jog);
                        break;

                    case 3:
                        Hanking(jog);
                        break;
                }
                Console.WriteLine("Clique [ENTER] para continuar...");
                Console.ReadKey();
                Console.Clear();

            } while (opcao != 0);
        }
    }
}
