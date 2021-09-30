using System;

namespace Aula02
{
    public class Produto
    {
        public DateTime? DataValidade { get; set; }

        public bool EstaValido(DateTime data)
        {
            return DataValidade >= data;
        }
    }
}
