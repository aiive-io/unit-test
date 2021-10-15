using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula07
{
    public class Pedido
    {
        private readonly List<Produto> _produtos = new List<Produto>();
        public IReadOnlyList<Produto> Produtos => _produtos.ToList();

        public void AdicionarProduto(Produto product)
        {
            _produtos.Add(product);
        }
    }
    
}
