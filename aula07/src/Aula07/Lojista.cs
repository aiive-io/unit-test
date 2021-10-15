using System;

namespace Aula07
{
    public class Produto
    {
        public string Nome { get;private set; }

        public Produto(string nome)
        {
            Nome = nome;
        }
    }

    public class Lojista
    {
        public decimal CalcularDesconto(params Produto[] products)
        {
            decimal desconto = products.Length * 0.01m;
            return Math.Min(desconto, 0.2m);
        }
    }

   
}
