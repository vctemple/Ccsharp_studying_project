using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maior_saldo_negativo
{
    internal class Program
    {
        public static void ClearLastLine()
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.BufferWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
        }

        public static List<string> MaiorDivida(List<List<string>> dividas)
        {
            List<string> devedores = new List<string>();
            List<Contas> contas = new List<Contas>();

            foreach (List<string> lista in dividas)
            {
                bool exists = true;
                foreach (Contas c in contas)
                {
                    if (c.pessoa.Equals(lista[0])) // Soma saldo positivo
                    {
                        c.valor += int.Parse(lista[2]);
                        exists = false;
                        break;
                    }
                }
                if (exists)
                    contas.Add(new Contas(lista[0], int.Parse(lista[2]))); // Cria a pessoa

                exists = true;
                foreach (Contas c in contas)
                {
                    if (c.pessoa.Equals(lista[1])) // Soma saldo negativo
                    {
                        c.valor -= int.Parse(lista[2]);
                        exists = false;
                        break;
                    }
                }
                if (exists)
                    contas.Add(new Contas(lista[1], -1 * int.Parse(lista[2]))); // Cria a pessoa
            }
            int saldo = 0;

            //Verificar qual é o maior saldo negativo
            foreach (Contas c in contas)
            {
                Console.WriteLine(c.pessoa + "\t:" + c.valor);
                if (c.valor < saldo)
                    saldo = c.valor;
            }

            if (saldo >= 0)
                return new List<string>() { "A conta foi balanciada!" };

            //Pegar todos com o maior saldo negativo
            foreach (Contas c in contas)
            {
                if (c.valor == saldo)
                    devedores.Add(c.pessoa);
            }
            devedores.Sort();
            Console.WriteLine();
            return devedores;
        }
        static void Main(string[] args)
        {
            // Criando a matriz de duas dimensões 
            List<List<string>> dividas = new List<List<string>>();
            char resp;
            bool add;

            Console.WriteLine("========[ BALANÇO DA GALERA ]========\n");

            do
            {
                // Recebendo os dados
                List<string> dados = new List<string>(new string[3]);
                Console.Write("Digite o nome do credor: ");
                dados[0] = Console.ReadLine();
                Console.Write("Digite o nome do devedor: ");
                dados[1] = Console.ReadLine();
                Console.Write("Digite o valor emprestado: ");
                dados[2] = Console.ReadLine();
                dividas.Add(dados);

                Console.Write("Deseja adicionar mais um débito? [S/N]: ");
                resp = Convert.ToChar(Console.ReadLine());
                if (Char.ToUpper(resp) == 'S')
                    add = true;
                else
                    add = false;

                ClearLastLine();
                Console.WriteLine("====================================\n");
            } while (add);

            Console.WriteLine("....... SALDOS ...........\n");

            foreach (string i in MaiorDivida(dividas))
            {
                Console.WriteLine($"O maior devedor é: {i}");
            }
            Console.ReadKey();
        }
    }
}
