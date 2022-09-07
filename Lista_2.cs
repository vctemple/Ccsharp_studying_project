using System;

namespace LISTA_2
{
    internal class Program
    {
        static void EXa()
        {
            int x;

            Console.Write("Digite o primeiro número: ");
            int num1 = int.Parse(Console.ReadLine());

            Console.Write("Digite o segundo número: ");
            int num2 = int.Parse(Console.ReadLine());

            Console.Write("Digite o terceiro número: ");
            int num3 = int.Parse(Console.ReadLine());

            if(num1 >= num2)
            {
                x = num1;
                num1 = num2;
                num2 = x;
            }

            if(num1 >= num3)
            {
                x = num1;
                num1 = num3;
                num3 = x;
            }

            if (num2 >= num3)
            {
                x = num2;
                num2 = num3;
                num3 = x;
            }

            Console.Write($"Os valores em ordem crescente ficam: {num1}, {num2}, {num3}");
            Console.ReadKey();
        }

        static void EXb()
        {
            int rad2;

            Console.WriteLine("Digite o valor de um ângulo em radianos! Exemplo: 3pi/2\n");
            Console.Write("Digite o valor que é multiplicado por pi: ");
            int rad1 = int.Parse(Console.ReadLine());

            Console.Write("O valor de radianos é divido por mais de 1? [s/n]: ");
            char resp = char.Parse(Console.ReadLine());
            if (char.ToUpper(resp) == 'S')
            {
                Console.Write("Digite o valor da divisão: ");
                rad2 = int.Parse(Console.ReadLine());
            }
            else
            {
                rad2 = 1;
            }

            float radianos = (float)(rad1 * Math.PI / rad2);
            float graus = (float)(radianos * (180/Math.PI));

            Console.Write($"\nO valor em radianos é de: {radianos.ToString("F5")}\nE o valor em graus é de: {graus}º");
            Console.ReadKey();
        }

        static void EXc()
        {
            Console.Write("Digite o valor do cateto a: ");
            int cata = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor do cateto b: ");
            int catb = int.Parse(Console.ReadLine());

            float hip = (float)(Math.Sqrt(Math.Pow(cata, 2) + Math.Pow(catb, 2)));

            Console.Write("\nA hipotenusa é de: " + hip.ToString("F2"));
            Console.ReadKey();
        }
        
        static void EXd()
        {
            Console.Write("Digite o valor: ");
            int x = int.Parse(Console.ReadLine());

            if(x > 0 && x % 2 == 0)
            {
                Console.Write($"A Raiz de {x} é: " + (Math.Sqrt(x)));
            }
            else
            {
                Console.Write("Seu número é ímpar ou negativo");
            }
            Console.ReadKey();
        }

        static void EXe()
        {
            Console.Write("Digite um valor: ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Digite outro valor: ");
            int b = int.Parse(Console.ReadLine());

            if (a > b)
                Console.Write($"\n{a} é o maior valor!");
            else if (a < b)
                Console.Write($"\n{b} é o maior valor!");
            else
                Console.Write("\nNúmeros iguais!");
            Console.ReadKey();
        }

        static void EXf()
        {
            Console.Write("Digite um número correspondente ao dia da semana [1-7]: ");
            int sem = int.Parse(Console.ReadLine());

            switch (sem)
            {
                case 1:
                    Console.Write("\nÉ domingo!");
                    break;
                case 2:
                    Console.Write("\nÉ segunda-feira!");
                    break;
                case 3:
                    Console.Write("\nÉ terça-feira!");
                    break;
                case 4:
                    Console.Write("\nÉ quarta-feira!");
                    break;
                case 5:
                    Console.Write("\nÉ quinta-feira!");
                    break;
                case 6:
                    Console.Write("\nÉ sexta-feira!");
                    break;
                case 7:
                    Console.Write("\nÉ sábado!");
                    break;
                default:
                    Console.Write("Você digitou algo inválido!");
                    break;
            }
            Console.ReadKey();
        }

        static void EXg()
        {
            Console.Write("Digite um valor: ");
            float a = float.Parse(Console.ReadLine());

            Console.Write("Digite outro valor: ");
            float b = float.Parse(Console.ReadLine());

            Console.Write("Digite uma operação aritmética [+ - * /]: ");
            char op = char.Parse(Console.ReadLine());

            switch (op)
            {
                case '+':
                    Console.Write($"\n{a} {op} {b} = " + (a + b));
                    break;
                case '-':
                    Console.Write($"\n{a} {op} {b} = " + (a - b));
                    break;
                case '*':
                    Console.Write($"\n{a} {op} {b} = " + (a * b));
                    break;
                case '/':
                    Console.Write($"\n{a} {op} {b} = " + (a / b));
                    break;
                default:
                    Console.Write("\nOperação inválida");
                    break;
            }
            Console.ReadKey();
        }

        static void EXh()
        {
            Console.Write("Digite um valor: ");
            float x = float.Parse(Console.ReadLine());

            if(x % 3 == 0 && x % 5 == 0)
                Console.Write($"\n{x} é divisível por 3 e 5!");
            else if(x % 3 == 0)
                Console.Write($"\n{x} é divisível por 3, mas não por 5!");
            else if(x % 5 == 0)
                Console.Write($"\n{x} é divisível por 5, mas não por 3!");
            else
                Console.Write($"\n{x} não é divisível nem por 3, nem por 5!");
            Console.ReadKey();
        }

        static void EXi()
        {
            Console.Write("Digite a distância percorrida pelo carro em Quilometros: ");
            float km = float.Parse(Console.ReadLine());

            Console.Write("Digite o consumo de gasolina em litros: ");
            float gas = float.Parse(Console.ReadLine());

            if(km / gas < 8.0)
                Console.Write($"\n{km/gas} Km/l.\nVenda o carro ou compre um posto!");
            else if((km / gas >= 8.0) && (km / gas < 14.0))
                Console.Write($"\n{km / gas} Km/l.\nEconômico!");
            else if(km / gas >= 14.0)
                Console.Write($"\n{km/gas} Km/l.\nSuper econômico!");
            Console.ReadKey();
        }

        static void EXj()
        {
            Console.Write("Digite um valor para a: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Digite um valor para b: ");
            int b = int.Parse(Console.ReadLine());
            Console.Write("Digite um valor para c: ");
            int c = int.Parse(Console.ReadLine());
            Console.Write("\nMédia Ponderada   [1]\n" +
                            "Média Harmônica   [2]\n" +
                            "Média Aritimética [3]\n");
            Console.Write("Escolha o tipo de média para ser efetuada! ");
            int op = int.Parse(Console.ReadLine());

            switch (op)
            {
                case 1:
                    Console.Write("(a+2b+3c)/6 = " + (float)((a + 2.0 * b + 3.0 * c) / 6.0));
                    break;
                case 2:
                    Console.Write("1/((1/a)+(1/b)+(1/c)) = " + (float)(1.0 / ((1.0 / a) + (1.0 / b) + (1.0 / c))));
                    break;
                case 3:
                    Console.Write("(a+b+c)/3 = " + (float)(a + b + c) / 3.0);
                    break;
                default:
                    Console.Write("Entrada inválida de dados!");
                    break;
            }
            Console.ReadKey();
        }

        static void EXk()
        {
            float comissao = 0;
            
            Console.Write("Digite o valor da venda do imóvel: ");
            float venda = float.Parse(Console.ReadLine());

            if (venda >= 100000.0)
                comissao = (700f + (venda * 0.16f));
            else if (venda < 100000.0 && venda >= 80000.0)
                comissao = (650f + (venda * 0.14f));
            else if (venda < 80000.0 && venda >= 60000.0)
                comissao = (600 + (venda * 0.14f));
            else if (venda < 60000.0 && venda >= 40000.0)
                comissao = (550 + (venda * 0.14f));
            else if (venda < 40000.0 && venda >= 20000.0)
                comissao = (500 + (venda * 0.14f));
            else if (venda < 20000.0)
                comissao = (400 + (venda * 0.14f));

            Console.Write($"Sua comissão é de: R${comissao:F2}");
            Console.ReadKey();
        }

        static int menu()
        {
            Console.WriteLine("===[MENU DE OPCOES]===");
            Console.WriteLine("............SAIR: [00]");
            Console.WriteLine("............EX A: [01]");
            Console.WriteLine("............EX B: [02]");
            Console.WriteLine("............EX C: [03]");
            Console.WriteLine("............EX D: [04]");
            Console.WriteLine("............EX E: [05]");
            Console.WriteLine("............EX F: [06]");
            Console.WriteLine("............EX G: [07]");
            Console.WriteLine("............EX H: [08]");
            Console.WriteLine("............EX I: [09]");
            Console.WriteLine("............EX J: [10]");
            Console.WriteLine("............EX K: [11]");
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
                        EXa();
                        break;
                    case 2:
                        EXb();
                        break;
                    case 3:
                        EXc();
                        break;
                    case 4:
                        EXd();
                        break;
                    case 5:
                        EXe();
                        break;
                    case 6:
                        EXf();
                        break;
                    case 7:
                        EXg();
                        break;
                    case 8:
                        EXh();
                        break;
                    case 9:
                        EXi();
                        break;
                    case 10:
                        EXj();
                        break;
                    case 11:
                        EXk();
                        break;
                }
                Console.Clear();
            } while (Menu != 0);
        }
    }
}
