using System;

namespace Aula02
{
    public class Cliente
    {
        public int Idade { get; private set; }
        public string Nome { get; private set; }

        public Cliente(int idade, string nome)
        {
            if (!EhMaiorDeIdade(idade)) throw new Exception();

            Idade = idade;
            Nome = nome;

            //passo1
            //passo2

            //passo3
            //passo4

        }

        private bool EhMaiorDeIdade(int idade)
        {
            return idade > 18;
        }
    }

    public interface IClienteValidator
    {
        bool EhMaiorDeIdade(int idade);
    }

    public class ClienteValidator : IClienteValidator
    {
        public bool EhMaiorDeIdade(int idade)
        {
            return idade > 18;
        }
    }
}
