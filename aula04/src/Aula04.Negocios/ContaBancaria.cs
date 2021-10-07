using System;

namespace Aula04.Negocios
{
    public class ContaBancaria
    {
        public Guid Id { get; set; }

        public decimal Saldo { get; set; }

        public decimal TotalEmprestimo { get; set; }

        public decimal SaldoTotal => Saldo - TotalEmprestimo;
        
        public decimal SaldoEmprestimo { get; set; }
    }
    
}
