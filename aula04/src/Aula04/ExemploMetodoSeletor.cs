using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula04
{
    public interface IARepository
    {
        void CallA();
    }

    public interface IBRepository
    {
        void CallB();
    }

    public class ExemploMetodoSeletor
    {
        private readonly IARepository _aRepository;
        private readonly IBRepository _bRepository;

        public ExemploMetodoSeletor(IARepository aRepository,
            IBRepository bRepository)
        {
            _aRepository = aRepository;
            _bRepository = bRepository;
        }

        public void Seletor(string parametro)
        {
            if (parametro == "A") A();

            else B();
        }

        public void A()
        {
            _aRepository.CallA();
        }

        public void B()
        {
            _bRepository.CallB();
        }
    }
}
