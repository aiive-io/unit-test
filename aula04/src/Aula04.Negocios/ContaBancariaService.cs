using System;

namespace Aula04.Negocios
{
    public class ContaBancariaService : IContaBancariaService
    {
        private readonly IContaBancariaRepositorio _contaBancariaRepositorio;
        private readonly IChequeEspecialRepositorio _chequeEspecialRepositorio;

        public ContaBancariaService(
            IContaBancariaRepositorio contaBancariaRepositorio, 
            IChequeEspecialRepositorio chequeEspecialRepositorio)
        {
            _contaBancariaRepositorio = contaBancariaRepositorio;
            _chequeEspecialRepositorio = chequeEspecialRepositorio;
        }

        public void Debitar(Guid id, decimal valor)
        {
            var conta = _contaBancariaRepositorio.GetById(id);

            if(conta.Saldo >= valor)
            {
                conta.Saldo -= valor;
            }
            else if(conta.SaldoEmprestimo >= valor)
            {
                conta.SaldoEmprestimo -= valor;
                _chequeEspecialRepositorio.CriarEmprestimo(id, valor);
            }
            else
            {
                throw new NegocioException("Saldo insuficiente.");
            }

            _contaBancariaRepositorio.Atualizar(conta);
        }
    }
    
}
