using System;

namespace LISTA_3
{
    internal class Program
    {      
        static void EX1()
        {
            Random random = new Random();
            int minimo, i, j;
            double aux, soma = 0;
            double[] x = new double[213];
            
            Console.WriteLine("Este programa vai gerar 213 valores randômicos de 1 a 1000 e retornará o maior e menor valor encontrado.\n");

            for( i = 0; i <= 212; i++)
            {
                x[i] = random.Next(1, 1000) * random.NextDouble();
                soma += x[i];
            }

            for (i = 0; i <= 212; i++)
            {
                minimo = i;
                for (j = i + 1; j <= 212; j++)
                {
                    if (x[j] < x[minimo])
                        minimo = j;
                }
                if (i != minimo)
                {
                    aux = x[i];
                    x[i] = x[minimo];
                    x[minimo] = aux;
                }
                Console.Write(x[i].ToString("F2") + "\t");
            }
            Console.WriteLine($"\n\nMédia aritimética dos valores: [{soma.ToString("F2")} / 213] = {(soma / 213).ToString("F2")}");
            Console.WriteLine($"Menor valor gerado: {x[0].ToString("F2")}");
            Console.WriteLine($"Maior valor gerado: {x[212].ToString("F2")}");
            Console.ReadKey();
        }

        static void EX2()
        {
            float soma = 0;
            int x, count = 0;
            Console.WriteLine("Digite um valor para ser somado ao montante ou [0] para sair!");
            do
            {
                Console.Write($"Valor [{count + 1}]: ");
                x = int.Parse(Console.ReadLine());
                if (x != 0)
                {
                    soma += x;
                    count += 1;
                }
                    
            }while (x != 0);
            Console.WriteLine($"A soma dos valores foi de: {soma}");
            Console.WriteLine($"A quantidade de entradas foi de: {count}");
            Console.WriteLine($"A média aritimética é de: {(soma / count).ToString("F2")}");
            Console.ReadKey();
        }

        static void EX3()
        {
            Console.WriteLine("Digite um range de valores entre X e Y!");
            Console.Write($"Para [X]: ");
            int x = int.Parse(Console.ReadLine());
            Console.Write($"Para [Y]: ");
            int y = int.Parse(Console.ReadLine());

            Console.WriteLine($"Os valores com resto = 3 quando divididos por 7 no range de {x} a {y} são:");
            for( int i = x; i <= y; i++)
            {
                if ((i % 7) == 3)
                    Console.Write(i + "\t");
            }
            Console.ReadKey();
        }
        
        static void EX4()
        {
            Random random = new Random();
            int[] x = new int[97];
            int soma_par = 0, soma_impar = 0;
            
            Console.WriteLine("Este programa vai gerar 97 valores randômicos de 0 a 1000 e retornará a soma dos valores pares e dos ímpares.\n");

            for (int i = 0; i <= 96; i++)
            {
                x[i] = random.Next(0, 1000);
                Console.Write(x[i] + "\t");
                
                if(x[i] % 2 == 0)
                    soma_par += x[i];
                else
                    soma_impar += x[i];
            }
            Console.WriteLine($"\n\nSoma dos valores pares: {soma_par}");
            Console.WriteLine($"Soma dos valores ímpares: {soma_impar}");
            Console.ReadKey();
        }

        static void EX5()
        {
            int i = 0, count = 0;
            Console.Write("Digite um valor para que seu quadrado seja o limite: ");
            int x = int.Parse(Console.ReadLine());

            Console.WriteLine($"Os primeiros {Math.Pow(x, 2)} números divisíveis por 3 mas não por 6 são: ");
            do
            {
                if ((i % 3 == 0) && (i % 6 != 0))
                {
                    Console.Write(i + "\t");
                    count += 1;
                }
                i++;
                    
            }while(count < Math.Pow(x, 2));
            Console.ReadKey();
        }

        static void EX6()
        {
            Console.Write("Digite o número de linhas para compor a figura: ");
            int linhas = int.Parse(Console.ReadLine());
            Console.WriteLine("");
            for(int i = 0; i <= linhas-1; i++)
            {
                for (int j = 0; j <= i; j++)
                    Console.Write("*");
                Console.WriteLine("");
            }
            Console.ReadKey();
        }

        static int menu()
        {
            Console.WriteLine("===[MENU DE OPCOES]===");
            Console.WriteLine("............SAIR: [0]");
            Console.WriteLine("............EX 1: [1]");
            Console.WriteLine("............EX 2: [2]");
            Console.WriteLine("............EX 3: [3]");
            Console.WriteLine("............EX 4: [4]");
            Console.WriteLine("............EX 5: [5]");
            Console.WriteLine("............EX 6: [6]");
            Console.WriteLine("\n");
            Console.Write("Digite a opcao desejada: ");
            int op = int.Parse(Console.ReadLine());

            return op;
        }

        static void Main(string[] args)
        {
            int Menu;

            do
            {
                Menu = menu();
                switch (Menu)
                {
                    case 0:
                        Console.WriteLine("\nSair do programa.\nDigite [ENTER]");
                        Console.ReadKey();
                        break;
                    case 1:
                        EX1();
                        break;
                    case 2:
                        EX2();
                        break;
                    case 3:
                        EX3();
                        break;
                    case 4:
                        EX4();
                        break;
                    case 5:
                        EX5();
                        break;
                    case 6:
                        EX6();
                        break;
                }
                Console.Clear();
            }while (Menu != 0);
        }
    }
}
