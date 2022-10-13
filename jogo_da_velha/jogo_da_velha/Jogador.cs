using System;

namespace jogo_da_velha
{
    internal class Jogador
    {
        public string Nome;
        public string CPF;
        public string Vitorias;

        // MÉTODO CONSTRUTOR
        public Jogador(string Nome, string CPF, string Vitorias)
        {
            Validar(Nome, CPF);
            this.Vitorias = Vitorias;
        }

        public void Validar(string Nome, string CPF)
        {
            if (String.IsNullOrEmpty(Nome))
                throw new ArgumentException("O texto digitado é nulo ou vazio!", "Nome");
            if (String.IsNullOrEmpty(CPF))
                throw new ArgumentException("O texto digitado é nulo ou vazio!", "CPF");
            if (ValidarCPF(CPF) == false)
                throw new ArgumentException("CPF digitado errado!");

            this.Nome = Nome;
            this.CPF = CPF;
        }

        public override string ToString()
        {
            return "NOME: " + Nome +
                   "\nCPF: " + CPF +
                   "\nVitórias: " + Vitorias;
        }

        public bool ValidarCPF(string CPF)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma = 0;
            int resto;

            CPF = CPF.Trim();
            CPF = CPF.Replace(".", "").Replace("-", "");

            if (CPF.Length != 11)
                return false;

            tempCpf = CPF.Substring(0, 9);

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return CPF.EndsWith(digito);
        }

        public string DadosParaArquivo()
        {
            return Nome + ";" + CPF + ";" + Vitorias;
        }

        public void venceu()
        {
            int historico = int.Parse(this.Vitorias);
            historico++;
            this.Vitorias = historico.ToString();
        }
    }

    
}
