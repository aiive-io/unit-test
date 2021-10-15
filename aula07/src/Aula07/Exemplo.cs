using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula07
{
    public interface Teste { }
    public interface Teste1 { }
    public interface Teste2 { }

    public interface IExemploService { }

    public class ExemploService : IExemploService
    {
        public ExemploService(Teste teste, Teste1 teste1, Teste2 teste2) 
        {
        }
    }

    public class Exemplo
    {
        public Exemplo(IExemploService service)
        {

        }
    }
}
