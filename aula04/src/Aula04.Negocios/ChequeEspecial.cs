using System;

namespace Aula04.Negocios
{
    public class ChequeEspecial
    {
        public Guid Id { get; set; }

        public Guid ContaId { get; set; }

        public decimal Valor { get; set; }
    }
    
}
