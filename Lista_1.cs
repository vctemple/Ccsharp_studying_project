using System;

namespace Lista_1
{
    internal class Program
    {
        static void EX1()
        {
            Console.Write("Digite o valor do salário mínino: ");
            float salario_minino = float.Parse(Console.ReadLine());

            Console.Write("Digite o seu salário: ");
            float seu_salario = float.Parse(Console.ReadLine());

            float salario_liquido = (float)(seu_salario * (1 - 0.085)) / salario_minino;

            Console.Write("Seu salário líquido convertido em salários minimos é de: " + salario_liquido);
            Console.ReadKey();
        }

        static void EX2()
        {
            Console.Write("Digite um valor em metros: ");
            float valor_m = float.Parse(Console.ReadLine());

            float valor_cm = valor_m * 100;
            float valor_mm = valor_m * 1000;

            Console.WriteLine("Valor em centímetros: " + valor_cm);
            Console.WriteLine("Valor em milímetros: " + valor_mm);
            Console.ReadKey();
        }
        
        static void EX3()
        {
            Console.WriteLine("Digite uma temperatura em Fahrenheit!");

            Console.Write("Como float: ");
            float tempf_float = float.Parse(Console.ReadLine());

            Console.Write("Como int: ");
            int tempf_int = int.Parse(Console.ReadLine());

            float tempc_float = (float)((tempf_float - 32.0) * (5.0 / 9.0));
            int tempc_int = (int)((tempf_int - 32.0) * (5.0 / 9.0));

            Console.WriteLine("Valor em Celsius como float: " + tempc_float);
            Console.WriteLine("Valor em Calsius como int: " + tempc_int);
            Console.ReadKey ();
        }

        static void EX4()
        {
            Console.Write("Digite a sua altura em metros: ");
            float altura = float.Parse(Console.ReadLine());

            Console.Write("Digite o seu peso em Kilogramas: ");
            float peso = float.Parse(Console.ReadLine());

            float imc = (float)(peso / (Math.Pow(altura, 2)));
            Console.WriteLine("Seu IMC é de: " + imc);
            Console.ReadKey ();
        }

        static void EX5()
        {
            Console.Write("Digite o número [1]: ");
            float num1 = float.Parse(Console.ReadLine());
            Console.Write("Digite um peso para o número [1]: ");
            int peso1 = int.Parse(Console.ReadLine());

            Console.Write("Digite o número [2]: ");
            float num2 = float.Parse(Console.ReadLine());
            Console.Write("Digite um peso para o número [2]: ");
            int peso2 = int.Parse(Console.ReadLine());

            Console.Write("Digite o número [3]: ");
            float num3 = float.Parse(Console.ReadLine());
            Console.Write("Digite um peso para o número [3]: ");
            int peso3 = int.Parse(Console.ReadLine());

            float media = (float)(((num1 * peso1) + (num2 * peso2) + (num3 * peso3)) / (peso1+peso2+peso3));

            Console.Write("A média ponderada é de: " + media);
            Console.ReadKey();
        }

        static void EX6()
        {
            Console.Write("Digite a distâcia percorrida em metros: ");
            float AS = float.Parse(Console.ReadLine());

            Console.Write("Digite o tempo gasto para percorrer esta distância em segundos: ");
            float AT = float.Parse(Console.ReadLine());

            float Vm = (float)(AS / AT);

            Console.Write("A velocidade média do trajeto é de: " + Vm + " m/s");
            Console.ReadKey();
        }

        static void EX7()
        {
            Console.Write("Digite o seu salário: ");
            float salario = float.Parse(Console.ReadLine());

            float novo_salario = salario * 1.337f;

            Console.Write("Seu novo salário é de: " + novo_salario + " reais");
            Console.ReadKey();
        }

        static void EX8()
        {
            Console.Write("Digite um valor em reais: ");
            float reais = float.Parse(Console.ReadLine());

            float dolar = reais * 0.1934285f;

            Console.Write("O valor em dolares é de: " + dolar);
            Console.ReadKey();
        }

        static void EX9()
        {
            Console.Write("Digite um número: ");
            int num = int.Parse(Console.ReadLine());

            Console.Write("A soma do antecessor do triplo com o sucessor do dobro é: " + (((num * 3) - 1) + (num * 2) + 1));
            Console.ReadKey();
        }

        static void EX10()
        {
            Console.Write("Digite um número de 4 dígitos: ");
            int num = int.Parse(Console.ReadLine());

            Console.WriteLine("D1: " + (num / 1000));

            num %= 1000;
            Console.WriteLine("D2: " + (num / 100));

            num %= 100;
            Console.WriteLine("D3: " + (num / 10));

            Console.Write("D4: " + (num % 10));
            Console.ReadKey();
        }

        static void EX11()
        {
            float invest = 1000;

            float D1 = invest * (1f - 0.124f);
            float D2 = D1 * 1.018f;
            float D3 = D2 * 1.056f;
            float D4 = D3 * (1f - 0.045f);

            Console.WriteLine("Seu investimento sofreu a seguinte ocilação.");
            Console.WriteLine("Dia 1: R$" + D1.ToString("F2"));
            Console.WriteLine("Dia 2: R$" + D2.ToString("F2"));
            Console.WriteLine("Dia 3: R$" + D3.ToString("F2"));
            Console.Write("Dia 4: R$" + D4.ToString("F2"));
            Console.ReadKey();
        }

        static void EX12()
        {
            Console.Write("Digite sua altura em metros: ");
            float altura = float.Parse(Console.ReadLine());

            Console.Write("Digite o seu sexo [M/F]: ");
            char sexo = char.Parse(Console.ReadLine());

            if (char.ToUpper(sexo) == 'M')
            {
                Console.Write("Seu peso ideal é de: " + ((72.7f * altura) - 58f).ToString("F2") + "Kg");
            }

            if(char.ToUpper(sexo) == 'F')
            {
                Console.Write("Seu peso ideal é de: " + ((62.1f * altura) - 44.7f).ToString("F2") + "Kg");
            }
            Console.ReadKey();
        }

        static int menu()
        {
            Console.WriteLine("===[MENU DE OPCOES]===");
            Console.WriteLine("............SAIR: [00]");
            Console.WriteLine("............EX01: [01]");
            Console.WriteLine("............EX02: [02]");
            Console.WriteLine("............EX03: [03]");
            Console.WriteLine("............EX04: [04]");
            Console.WriteLine("............EX05: [05]");
            Console.WriteLine("............EX06: [06]");
            Console.WriteLine("............EX07: [07]");
            Console.WriteLine("............EX08: [08]");
            Console.WriteLine("............EX09: [09]");
            Console.WriteLine("............EX10: [10]");
            Console.WriteLine("............EX11: [11]");
            Console.WriteLine("............EX12: [12]");
            Console.WriteLine("\n");
            Console.Write("Digite a opcao desejada: ");
            int op = int.Parse(Console.ReadLine());

            return op;
        }

        static void Main(string[] args)
        {
            int op, Menu;

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
                    case 7:
                        EX7();
                        break;
                    case 8:
                        EX8();
                        break;
                    case 9:
                        EX9();
                        break;
                    case 10:
                        EX10();
                        break;
                    case 11:
                        EX11();
                        break;
                    case 12:
                        EX12();
                        break;
                }
                Console.Clear();
            } while(Menu != 0);
        }
    }
}
