using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maior_saldo_negativo
{
    internal class Contas
    {
        public string pessoa;
        public int valor;

        public Contas(string d, int v)
        {
            pessoa = d;
            valor = v;
        }
    }
}
