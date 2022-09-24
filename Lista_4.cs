using System;

namespace Lista_4
{
    internal class Program
    {
        static int Menu()
        {
            int opcao;

            Console.WriteLine("============ [MENU] ============");
            Console.WriteLine("[0]:........................Sair");
            Console.WriteLine("[1]:..........Cadastrar paciente");
            Console.WriteLine("[2]:...Listar todos os pacientes");
            Console.WriteLine("[3]:....Buscar paciente por nome");
            Console.WriteLine("[4]:.............Editar paciente");
            Console.WriteLine("[5]:............Excluir paciente\n");

            opcao = int.Parse(Console.ReadLine());
            return opcao;
        }

        static void Main(string[] args)
        {
            string[] nome = new string[100];
            string[] telefone = new string[100];
            string x, nomebuscado, telbuscado;
            int opcao, qtd = 0, i, certo = 0;
            bool pesq = true, validacao = false;

            do
            {
                opcao = Menu();

                switch (opcao)
                {
                    case 0:
                        Console.WriteLine("Saindo do sistema sistema!\nDigite qualquer tecla para finalizá-lo");
                        break;
                    case 1:
                        if (qtd >= 100)
                            Console.WriteLine("Entre em contato com o administrador para adquirir mais espaço de memória.");
                        else
                        {
                            Console.Write("Digite o nome do paciente: ");
                            nome[qtd] = Console.ReadLine();
                            Console.Write("Digite telefone do paciente: ");
                            telefone[qtd] = Console.ReadLine();
                            qtd++;
                        }
                        break;
                    case 2:
                        for (i = 0; i < qtd; i++)
                        {
                            Console.WriteLine("\nPaciente [{0}] ==========", i + 1);
                            Console.WriteLine("Nome: " + nome[i]);
                            Console.WriteLine("telefone: " + telefone[i] +"\n");
                        }
                        break;

                    case 3:
                        do
                        {
                            Console.Write("Digite o nome do paciente: ");
                            nomebuscado = Console.ReadLine().ToLower();
                            Console.Write("Digite o telefone do paciente: ");
                            telbuscado = Console.ReadLine();
                            Console.Write("Deseja realizar uma pesquisa restrita? [S/N]: ");
                            x = Console.ReadLine().ToLower();
                            if (x == "s")
                                for (i = 0; i < qtd; i++)
                                {
                                    if (nome[i].ToLower().Contains(nomebuscado) && telefone[i].Contains(telbuscado))
                                    {
                                        Console.WriteLine("\nPaciente [{0}] ==========", i + 1);
                                        Console.WriteLine("Nome: " + nome[i]);
                                        Console.WriteLine("telefone: " + telefone[i] + "\n");
                                        validacao = true;
                                    }
                                }
                            else
                            {
                                for (i = 0; i < qtd; i++)
                                {
                                    if (nome[i].ToLower().Contains(nomebuscado) || telefone[i].Contains(telbuscado))
                                    {
                                        Console.WriteLine("\nPaciente [{0}] ==========", i + 1);
                                        Console.WriteLine("Nome: " + nome[i]);
                                        Console.WriteLine("telefone: " + telefone[i] + "\n");
                                        validacao = true;
                                    }
                                }
                            }
                            if (!validacao)
                                Console.WriteLine("Nenhum paciente com o nome {0} cadastrado", nomebuscado);
                            
                            Console.Write("Deseja realizar a pesquisa novamente [S/N]: ");
                            x = Console.ReadLine().ToLower();
                            if (x != "s")
                                pesq = false;
                        }while (pesq == true) ;
                        break;
                    case 4:
                        string resp;
                        do
                        {                            
                            Console.Write("Digite o nome do paciente: ");
                            nomebuscado = Console.ReadLine().ToLower();
                            Console.Write("Digite o telefone do paciente: ");
                            telbuscado = Console.ReadLine();
                            Console.Write("Deseja realizar uma pesquisa restrita? [S/N]: ");
                            x = Console.ReadLine().ToLower();
                            if (x == "s")
                                for (i = 0; i < qtd; i++)
                                {
                                    if (nome[i].ToLower().Contains(nomebuscado) && telefone[i].Contains(telbuscado))
                                    {
                                        Console.WriteLine("\nPaciente [{0}] ==========", i + 1);
                                        Console.WriteLine("Nome: " + nome[i]);
                                        Console.WriteLine("telefone: " + telefone[i] + "\n");
                                        validacao = true;
                                        certo = i;
                                    }
                                }
                            else
                            {
                                for (i = 0; i < qtd; i++)
                                {
                                    if (nome[i].ToLower().Contains(nomebuscado) || telefone[i].Contains(telbuscado))
                                    {
                                        Console.WriteLine("\nPaciente [{0}] ==========", i + 1);
                                        Console.WriteLine("Nome: " + nome[i]);
                                        Console.WriteLine("telefone: " + telefone[i] + "\n");
                                        validacao = true;
                                    }
                                }
                            }
                            if (!validacao)
                                Console.WriteLine("Nenhum paciente com o nome {0} cadastrado", nomebuscado);
                                                       
                            Console.Write("Deseja realizar a pesquisa novamente [S/N]: ");
                            x = Console.ReadLine().ToLower();
                            if (x != "s")
                                pesq = false;
                        } while (pesq == true);

                        Console.Write($"Confirmar paciente para edição?  --> Nome: {nome[certo]}; Telefone: {telefone[certo]} <-- [S/N]: ");
                        x = Console.ReadLine().ToLower();
                        if(x == "s")
                        {
                            Console.Write("Para: " + nome[certo] + "Digite um novo nome: ");
                            resp = Console.ReadLine();
                            nome[certo] = resp.Length == 0 ? nome[certo] : resp;
                            Console.Write("telefone: " + telefone[certo] + "Digite um novo telefone: ");
                            resp = Console.ReadLine();
                            telefone[certo] = resp.Length == 0 ? telefone[certo] : resp;
                        }                      
                        break;
                    case 5:
                        do
                        {
                            Console.Write("Digite nome do paciente: ");
                            nomebuscado = Console.ReadLine().ToLower();
                            Console.Write("Digite o telefone do paciente: ");
                            telbuscado = Console.ReadLine();
                            Console.Write("Deseja realizar uma pesquisa restrita? [S/N]: ");
                            x = Console.ReadLine().ToLower();
                            if (x == "s")
                                for (i = 0; i < qtd; i++)
                                {
                                    if (nome[i].ToLower().Contains(nomebuscado) && telefone[i].Contains(telbuscado))
                                    {
                                        Console.WriteLine("\nPaciente [{0}] ==========", i + 1);
                                        Console.WriteLine("Nome: " + nome[i]);
                                        Console.WriteLine("telefone: " + telefone[i] + "\n");
                                        validacao = true;
                                        certo = i;
                                    }
                                }
                            else
                            {
                                for (i = 0; i < qtd; i++)
                                {
                                    if (nome[i].ToLower().Contains(nomebuscado) || telefone[i].Contains(telbuscado))
                                    {
                                        Console.WriteLine("\nPaciente [{0}] ==========", i + 1);
                                        Console.WriteLine("Nome: " + nome[i]);
                                        Console.WriteLine("telefone: " + telefone[i] + "\n");
                                        validacao = true;
                                    }
                                }
                            }
                            if (!validacao)
                                Console.WriteLine("Nenhum paciente com o nome {0} cadastrado", nomebuscado);

                            Console.Write("Deseja realizar a pesquisa novamente [S/N]: ");
                            x = Console.ReadLine().ToLower();
                            if (x != "s")
                                pesq = false;
                        } while (pesq == true);

                        Console.Write($"Confirmar paciente para exclusão? --> Nome: {nome[certo]}; Telefone: {telefone[certo]} <-- [S/N]: ");
                        x = Console.ReadLine().ToLower();
                        if (x == "s")
                        {
                            for(i = certo; i < qtd; i++)
                            {
                                nome[i] = nome[i+1];
                                telefone[i] = telefone[i+1];
                            }
                            qtd -= 1;
                            Console.WriteLine("Nome excluido");
                        }
                        break;
                }
                Console.WriteLine("Aperte [ENTER]");
                Console.ReadLine();
                Console.Clear();
            } while (opcao != 0);
        }
    }
}
